/*
This is the query I used to compare to their spreadsheets before converting it to the TXHST generation query.
*/

SET NOCOUNT ON;

DECLARE @AccountNoExact varchar(64) = '108924.00';
DECLARE @FromDate date = NULL;
DECLARE @ToDate   date = NULL;

;WITH
/* Bill date per bill (1 row per bill) */
bill_dt AS (
    SELECT
        ab.a_bill_year,
        ab.a_bill_number,
        CAST(MAX(ab.bh_date1_bill) AS date) AS bill_date
    FROM TOSUTILITY.dbo.ar_all_bills ab
    WHERE ab.a_property_code = @AccountNoExact
      AND ab.bh_date1_bill IS NOT NULL
    GROUP BY ab.a_bill_year, ab.a_bill_number
),

/* Receipt-driven header rows for this account (for payment dates) */
hh AS (
    SELECT
        hh.a_bill_year,
        hh.a_bill_number,
        hh.a_receipt,
        hh.a_account       AS trans_CID,
        hh.a_property_code AS accountNo,

        CAST(hh.a_effective_date AS date) AS hdr_eff_dt,
        CAST(hh.hh_posting_date  AS date) AS hdr_post_dt,
        CAST(hh.a_entry_date     AS date) AS hdr_entry_dt,

        hh.hh_batch
    FROM TOSUTILITY.dbo.ar_history_header hh
    WHERE hh.a_property_code = @AccountNoExact
      AND hh.a_receipt IS NOT NULL
      AND hh.a_account IS NOT NULL
),

/* ONE payment-date row per bill+receipt (avoid duplicates from weird header repeats) */
hh_dedup AS (
    SELECT *
    FROM (
        SELECT
            h.*,
            ROW_NUMBER() OVER (
                PARTITION BY h.a_bill_year, h.a_bill_number, h.a_receipt
                ORDER BY
                    h.hdr_eff_dt DESC,
                    h.hdr_post_dt DESC,
                    h.hdr_entry_dt DESC
            ) AS rn
        FROM hh h
    ) x
    WHERE x.rn = 1
),

/* Tender ref (check/reference display) by (bill_year, receipt) */
tender AS (
    SELECT
        pm.a_bill_year,
        pm.a_receipt,
        MAX(CASE
                WHEN pm.hp_payment_method = '5' AND wp.wh_confirmation_num IS NOT NULL
                    THEN RIGHT('0000000000' + CAST(wp.wh_confirmation_num AS varchar(20)), 10)
                WHEN NULLIF(LTRIM(RTRIM(pm.hp_ref_number)), '') IS NOT NULL
                    THEN RIGHT('0000000000' + LTRIM(RTRIM(pm.hp_ref_number)), 10)
                ELSE NULL
            END) AS ref10
    FROM TOSUTILITY.dbo.ar_paymnt_method pm
    LEFT JOIN TOSUTILITY.dbo.ar_web_payment wp
        ON wp.a_bill_year = pm.a_bill_year
       AND wp.a_receipt   = pm.a_receipt
    JOIN (SELECT DISTINCT a_bill_year, a_receipt FROM hh_dedup) r
        ON r.a_bill_year = pm.a_bill_year
       AND r.a_receipt   = pm.a_receipt
    GROUP BY pm.a_bill_year, pm.a_receipt
),

/* Detail sums per BILL + SERVICE (NOT per line) */
hd_bill_serv AS (
    SELECT
        d.a_bill_year,
        d.a_bill_number,
        LTRIM(RTRIM(d.a_charge_code)) AS SERV,

        SUM(ISNULL(d.bd_original_amount,0)) AS chg_original,

        SUM(
            ISNULL(d.bd_paid_amount,0)
          + ISNULL(d.bd_payment_adj,0)
          + ISNULL(d.bd_adjust_amount,0)
          + ISNULL(d.bd_abate_amount,0)
          + ISNULL(d.bd_discount_amount,0)
          + ISNULL(d.bd_ref_amount,0)
          + ISNULL(d.bd_writeoff,0)
        ) AS pay_applied,

        SUM(ISNULL(d.bd_interest_paid,0)) AS pay_interest
    FROM TOSUTILITY.dbo.ar_history_detail d
    GROUP BY
        d.a_bill_year,
        d.a_bill_number,
        LTRIM(RTRIM(d.a_charge_code))
),

/* PAYMENTS: one row per (receipt, bill, service) using header effective date rule */
pay_lines AS (
    SELECT
        CAST(COALESCE(h.hdr_eff_dt, h.hdr_post_dt, h.hdr_entry_dt) AS date) AS [Date],
        CASE
            WHEN h.hdr_eff_dt IS NOT NULL THEN 'EFF'
            WHEN h.hdr_post_dt IS NOT NULL THEN 'POST'
            WHEN h.hdr_entry_dt IS NOT NULL THEN 'ENTRY'
            ELSE 'NONE'
        END AS DateSource,

        h.a_bill_number AS BillNumber,

        d.SERV,
        sc.utch_short AS SERVDESC,

        'Payment' AS [Type],
        t.ref10 AS [Check],

        CAST(-1.0 * d.pay_applied  AS decimal(12,2)) AS Amount,
        CAST(-1.0 * d.pay_interest AS decimal(12,2)) AS Interest
    FROM hh_dedup h
    JOIN hd_bill_serv d
        ON d.a_bill_year   = h.a_bill_year
       AND d.a_bill_number = h.a_bill_number
    LEFT JOIN tender t
        ON t.a_bill_year = h.a_bill_year
       AND t.a_receipt   = h.a_receipt
    LEFT JOIN TOSUTILITY.dbo.utcharge sc
        ON sc.utch_charge = d.SERV
    WHERE
        (d.pay_applied <> 0 OR d.pay_interest <> 0)
        AND (@FromDate IS NULL OR COALESCE(h.hdr_eff_dt, h.hdr_post_dt, h.hdr_entry_dt) >= @FromDate)
        AND (@ToDate   IS NULL OR COALESCE(h.hdr_eff_dt, h.hdr_post_dt, h.hdr_entry_dt) <= @ToDate)
),

/* CHARGES: one row per (bill, service) using bill date */
chg_lines AS (
    SELECT
        b.bill_date AS [Date],
        'BILL' AS DateSource,

        d.a_bill_number AS BillNumber,

        d.SERV,
        sc.utch_short AS SERVDESC,

        'Charge' AS [Type],
        CAST(NULL AS varchar(10)) AS [Check],

        CAST(d.chg_original AS decimal(12,2)) AS Amount,
        CAST(0.00 AS decimal(12,2)) AS Interest
    FROM bill_dt b
    JOIN hd_bill_serv d
        ON d.a_bill_year   = b.a_bill_year
       AND d.a_bill_number = b.a_bill_number
    LEFT JOIN TOSUTILITY.dbo.utcharge sc
        ON sc.utch_charge = d.SERV
    WHERE
        d.chg_original <> 0
        AND (@FromDate IS NULL OR b.bill_date >= @FromDate)
        AND (@ToDate   IS NULL OR b.bill_date <= @ToDate)
)

SELECT
    [Date],
    BillNumber,
    SERV,
    SERVDESC,
    [Type],
    [Check],
    Amount,
    Interest,
    DateSource
FROM pay_lines

UNION ALL

SELECT
    [Date],
    BillNumber,
    SERV,
    SERVDESC,
    [Type],
    [Check],
    Amount,
    Interest,
    DateSource
FROM chg_lines

ORDER BY
    [Date] DESC,
    BillNumber DESC,
    [Type] DESC,
    SERV ASC;