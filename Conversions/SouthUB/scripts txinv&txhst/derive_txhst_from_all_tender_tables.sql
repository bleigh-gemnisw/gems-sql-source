/*--------------------
This is the main script to generate TXHST records. It is self-contained.
Run AFTER the TXINV build.
--------------------*/

/* ============================================================
   TXHST Build (UI-aligned receipts)
   - Receipt identity driven by ar_history_header (a_receipt)
   - UI Date rule: ar_history_header.a_effective_date (fallback: posting -> entry)
   - Winner mapping: same as your logic (+ utactcid range gate)
   - Tender totals: ar_paymnt_method + ar_web_payment
   - Amounts:
       Primary: ar_receipt_all (receipt-level applied amounts)
       Fallback (only when receipt sum = 0): ar_history_detail buckets
         allocated to receipts for that bill+service by tender share
   ============================================================ */

DELETE FROM GEMSDTAB.dbo.TXHST WHERE [TYPE] = 'D';

SET NOCOUNT ON;

DECLARE @AcctLike varchar(30) = '%';
DECLARE @FromPostingDate date = NULL;      -- optional filter (posting date)
DECLARE @ToPostingDate   date = NULL;

IF OBJECT_ID('tempdb..#winner')   IS NOT NULL DROP TABLE #winner;
IF OBJECT_ID('tempdb..#hh')       IS NOT NULL DROP TABLE #hh;
IF OBJECT_ID('tempdb..#tender')   IS NOT NULL DROP TABLE #tender;
IF OBJECT_ID('tempdb..#rt')       IS NOT NULL DROP TABLE #rt;
IF OBJECT_ID('tempdb..#ra')       IS NOT NULL DROP TABLE #ra;
IF OBJECT_ID('tempdb..#hd')       IS NOT NULL DROP TABLE #hd;
IF OBJECT_ID('tempdb..#alloc')    IS NOT NULL DROP TABLE #alloc;

;WITH
/* ----------------------------------------------------------------------
   LOGUT dedupe: latest row per (CID, accountNo)
---------------------------------------------------------------------- */
lg_pick AS (
    SELECT *
    FROM (
        SELECT
            lg.*,
            ROW_NUMBER() OVER (
                PARTITION BY lg.[CUCNT#], lg.[CUMETN]
                ORDER BY lg.[LOGDTE] DESC, lg.[LOGTIM] DESC, lg.[LOGCMT] DESC
            ) AS rn
        FROM GEMSDTAB.dbo.LOGUT lg
    ) x
    WHERE x.rn = 1
),

/* ----------------------------------------------------------------------
   Bills: keep ALL bills (no rn=1 early-bill bias), gate by utactcid range
---------------------------------------------------------------------- */
src AS (
    SELECT
        lg.CUACCT       AS [LIST#],
        bh.a_bill_year  AS [YEAR],

        lg.CUCNT#        AS dbg_CUCNT,
        lg.CUMETN        AS dbg_CUMETN,

        ROW_NUMBER() OVER (
            PARTITION BY lg.CUACCT, bh.a_bill_year
            ORDER BY
                bh.bh_bill_date1 DESC,
                bh.a_bill_number DESC,
                lg.LOGDTE DESC, lg.LOGTIM DESC, lg.LOGCMT DESC
        ) AS pk_rn
    FROM TOSUTILITY.dbo.ub_bill_header bh
    JOIN lg_pick lg
        ON lg.CUCNT# = bh.a_acct
       AND lg.CUMETN = bh.a_account
    CROSS APPLY (
        SELECT TOP (1) ac.utacd_key
        FROM TOSUTILITY.dbo.utactcid ac
        WHERE ac.utacd_cid = bh.a_acct
          AND ac.utacd_account = bh.a_account
          AND bh.bh_bill_date1 >= CONVERT(date, ac.utacd_start_date)
          AND bh.bh_bill_date1 <= CONVERT(date, ac.utacd_stop_date)
        ORDER BY
            DATEDIFF(day, CONVERT(date, ac.utacd_start_date), CONVERT(date, ac.utacd_stop_date)) DESC,
            ac.utacd_start_date ASC,
            ac.utacd_stop_date DESC,
            ac.utacd_key DESC
    ) acp
    WHERE
        bh.a_account LIKE @AcctLike
        AND lg.CUACCT IS NOT NULL
)
SELECT
    s.[LIST#],
    s.[YEAR],
    s.dbg_CUCNT  AS win_CID,
    s.dbg_CUMETN AS win_ACCOUNT
INTO #winner
FROM src s
WHERE s.pk_rn = 1;

CREATE CLUSTERED INDEX IX_winner_Year_CID
ON #winner ([YEAR], win_CID);

/* ----------------------------------------------------------------------
   History header for receipts (UI date rule: effective date)
   Winner-only (year + CID), account filter kept aligned to @AcctLike
---------------------------------------------------------------------- */
SELECT
    w.[LIST#],
    w.[YEAR],
    hh.a_bill_year,
    hh.a_bill_number,
    hh.a_receipt,
    hh.a_account AS trans_CID,

    CAST(hh.a_effective_date AS date) AS hdr_eff_dt,
    CAST(hh.hh_posting_date  AS date) AS hdr_post_dt,
    CAST(hh.a_entry_date     AS date) AS hdr_entry_dt,

    hh.hh_entry_time,
    hh.hh_batch
INTO #hh
FROM #winner w
JOIN TOSUTILITY.dbo.ar_history_header hh
    ON hh.a_bill_year = w.[YEAR]
   AND hh.a_account   = w.win_CID
WHERE
    hh.a_receipt IS NOT NULL
    AND hh.a_account IS NOT NULL
    AND w.win_ACCOUNT LIKE @AcctLike
    AND (@FromPostingDate IS NULL OR CAST(hh.hh_posting_date AS date) >= @FromPostingDate)
    AND (@ToPostingDate   IS NULL OR CAST(hh.hh_posting_date AS date) <= @ToPostingDate);

CREATE INDEX IX_hh_year_receipt ON #hh (a_bill_year, a_receipt);

/* ----------------------------------------------------------------------
   Tender totals per receipt
---------------------------------------------------------------------- */
;WITH wp AS (
    SELECT a_bill_year, a_receipt, wh_card_type, wh_confirmation_num
    FROM TOSUTILITY.dbo.ar_web_payment
),
pm AS (
    SELECT a_bill_year, a_receipt, hp_payment_method, hp_ref_number, hp_amount_decimal
    FROM TOSUTILITY.dbo.ar_paymnt_method
)
SELECT
    pm.a_bill_year,
    pm.a_receipt,

    SUM(CASE WHEN pm.hp_payment_method = '2'
             THEN ISNULL(pm.hp_amount_decimal,0) ELSE 0 END) AS cash_total,

    SUM(CASE
            WHEN pm.hp_payment_method IN ('1','3','7')
                THEN ISNULL(pm.hp_amount_decimal,0)
            WHEN pm.hp_payment_method = '5'
                 AND (wp.wh_card_type IS NULL OR LTRIM(RTRIM(wp.wh_card_type)) = '')
                THEN ISNULL(pm.hp_amount_decimal,0)
            ELSE 0
        END) AS check_total,

    SUM(CASE
            WHEN pm.hp_payment_method = '4'
                THEN ISNULL(pm.hp_amount_decimal,0)
            WHEN pm.hp_payment_method = '5'
                 AND LTRIM(RTRIM(ISNULL(wp.wh_card_type,''))) <> ''
                THEN ISNULL(pm.hp_amount_decimal,0)
            ELSE 0
        END) AS credit_total,

    MAX(CASE
            WHEN pm.hp_payment_method = '5' AND wp.wh_confirmation_num IS NOT NULL
                THEN RIGHT('0000000000' + CAST(wp.wh_confirmation_num AS varchar(20)), 10)
            WHEN NULLIF(LTRIM(RTRIM(pm.hp_ref_number)), '') IS NOT NULL
                THEN RIGHT('0000000000' + LTRIM(RTRIM(pm.hp_ref_number)), 10)
            ELSE NULL
        END) AS ref10
INTO #tender
FROM pm
LEFT JOIN wp
    ON wp.a_bill_year = pm.a_bill_year
   AND wp.a_receipt   = pm.a_receipt
JOIN (SELECT DISTINCT a_bill_year, a_receipt FROM #hh) r
    ON r.a_bill_year = pm.a_bill_year
   AND r.a_receipt   = pm.a_receipt
GROUP BY pm.a_bill_year, pm.a_receipt;

CREATE UNIQUE CLUSTERED INDEX IX_tender ON #tender (a_bill_year, a_receipt);

/* ----------------------------------------------------------------------
   Receipt total (for tender prorating)
   Use tender sum as the "receipt total money" anchor.
---------------------------------------------------------------------- */
SELECT
    t.a_bill_year,
    t.a_receipt,
    CAST(ISNULL(t.cash_total,0) + ISNULL(t.check_total,0) + ISNULL(t.credit_total,0) AS decimal(12,2)) AS receipt_total_amt
INTO #rt
FROM #tender t;

CREATE UNIQUE CLUSTERED INDEX IX_rt ON #rt (a_bill_year, a_receipt);

/* ----------------------------------------------------------------------
   Receipt application lines (receipt + bill + service)
   Primary source: ar_receipt_all (receipt-level, correctly keyed by receipt)
---------------------------------------------------------------------- */
SELECT
    h.[LIST#],
    h.[YEAR],
    h.a_receipt,
    h.a_bill_number,

    COALESCE(h.hdr_eff_dt, h.hdr_post_dt, h.hdr_entry_dt) AS ui_pay_dt,
    h.hdr_eff_dt,
    h.hdr_post_dt,
    h.hdr_entry_dt,
    h.hh_entry_time,
    h.hh_batch,

    LTRIM(RTRIM(ra.a_charge_def)) AS SERV,

    CAST(ISNULL(ra.hd_principle_paid,0) AS decimal(12,2)) AS ra_prin,
    CAST(ISNULL(ra.hd_interest_paid,0)  AS decimal(12,2)) AS ra_int,
    CAST(ISNULL(ra.hd_principle_paid,0) + ISNULL(ra.hd_interest_paid,0) AS decimal(12,2)) AS ra_sum,

    CAST(ra.hh_posting_date AS date) AS ra_post_dt,
    CAST(ra.a_entry_date    AS date) AS ra_entry_dt,
    CAST(ra.hd_last_payment AS date) AS last_pay_dt
INTO #ra
FROM #hh h
JOIN TOSUTILITY.dbo.ar_receipt_all ra
    ON ra.a_bill_year = h.a_bill_year
   AND ra.a_receipt   = h.a_receipt
   AND ra.hh_account  = h.trans_CID;

CREATE INDEX IX_ra_receipt ON #ra ([YEAR], a_receipt);
CREATE INDEX IX_ra_billserv ON #ra ([YEAR], a_bill_number, SERV);

/* ----------------------------------------------------------------------
   UI-style detail buckets by (bill, service)
   This is the "truth" you used to match the UI, but it is NOT receipt-keyed.
---------------------------------------------------------------------- */
SELECT
    d.a_bill_year  AS [YEAR],
    d.a_bill_number,
    LTRIM(RTRIM(d.a_charge_code)) AS SERV,

    CAST(SUM(ISNULL(d.bd_original_amount,0)) AS decimal(12,2)) AS chg_original,

    CAST(SUM(
            ISNULL(d.bd_paid_amount,0)
          + ISNULL(d.bd_payment_adj,0)
          + ISNULL(d.bd_adjust_amount,0)
          + ISNULL(d.bd_abate_amount,0)
          + ISNULL(d.bd_discount_amount,0)
          + ISNULL(d.bd_ref_amount,0)
          + ISNULL(d.bd_writeoff,0)
        ) AS decimal(12,2)) AS hd_paid_applied,

    CAST(SUM(ISNULL(d.bd_interest_paid,0)) AS decimal(12,2)) AS hd_interest_paid,

    MAX(CASE WHEN ISNULL(d.bd_original_lien,'') <> '' THEN 1 ELSE 0 END) AS hd_has_lien
INTO #hd
FROM TOSUTILITY.dbo.ar_history_detail d
GROUP BY
    d.a_bill_year,
    d.a_bill_number,
    LTRIM(RTRIM(d.a_charge_code));

CREATE INDEX IX_hd_billserv ON #hd ([YEAR], a_bill_number, SERV);

/* ----------------------------------------------------------------------
   Allocate fallback amounts (only when a receipt’s RA sum is 0)
   Strategy:
     - For each receipt/bill/service row where ra_sum=0, pull hd totals
     - Distribute hd totals across receipts for that SAME bill+service
       proportional to receipt tender total (receipt_total_amt)
---------------------------------------------------------------------- */
;WITH
ra_billserv_receipts AS (
    SELECT
        r.[LIST#],
        r.[YEAR],
        r.a_bill_number,
        r.SERV,
        r.a_receipt,
        r.ui_pay_dt,
        r.hdr_eff_dt, r.hdr_post_dt, r.hdr_entry_dt,
        r.hh_entry_time,
        r.hh_batch,
        r.last_pay_dt,

        r.ra_prin,
        r.ra_int,
        r.ra_sum,

        CAST(ISNULL(rt.receipt_total_amt,0) AS decimal(12,2)) AS tender_sum
    FROM #ra r
    LEFT JOIN #rt rt
        ON rt.a_bill_year = r.[YEAR]
       AND rt.a_receipt   = r.a_receipt
),
billserv_tot AS (
    SELECT
        [YEAR],
        a_bill_number,
        SERV,
        SUM(CASE WHEN tender_sum > 0 THEN tender_sum ELSE 0 END) AS billserv_tender_sum
    FROM ra_billserv_receipts
    GROUP BY [YEAR], a_bill_number, SERV
)
SELECT
    x.[LIST#],
    x.[YEAR],
    x.a_receipt,
    x.a_bill_number,
    x.SERV,

    x.ui_pay_dt,
    x.hdr_eff_dt, x.hdr_post_dt, x.hdr_entry_dt,
    x.hh_entry_time,
    x.hh_batch,
    x.last_pay_dt,

    x.ra_prin,
    x.ra_int,
    x.ra_sum,

    h.hd_paid_applied,
    h.hd_interest_paid,
    h.hd_has_lien,

    x.tender_sum,
    bt.billserv_tender_sum,

    CAST(
        CASE
            WHEN x.ra_sum <> 0 THEN x.ra_prin
            WHEN ISNULL(bt.billserv_tender_sum,0) = 0 THEN 0
            ELSE (ISNULL(h.hd_paid_applied,0) * (x.tender_sum / bt.billserv_tender_sum))
        END
    AS decimal(12,2)) AS eff_paid_applied,

    CAST(
        CASE
            WHEN x.ra_sum <> 0 THEN x.ra_int
            WHEN ISNULL(bt.billserv_tender_sum,0) = 0 THEN 0
            ELSE (ISNULL(h.hd_interest_paid,0) * (x.tender_sum / bt.billserv_tender_sum))
        END
    AS decimal(12,2)) AS eff_interest_paid
INTO #alloc
FROM ra_billserv_receipts x
LEFT JOIN #hd h
    ON h.[YEAR]        = x.[YEAR]
   AND h.a_bill_number = x.a_bill_number
   AND h.SERV          = x.SERV
LEFT JOIN billserv_tot bt
    ON bt.[YEAR]        = x.[YEAR]
   AND bt.a_bill_number = x.a_bill_number
   AND bt.SERV          = x.SERV;

CREATE INDEX IX_alloc_receipt ON #alloc ([YEAR], a_receipt);

/* ----------------------------------------------------------------------
   Aggregate to one TXHST row per (LIST#, YEAR, receipt)
   Classify principal/interest/lien using utcharge short description (your style)
   But amounts now come from eff_* (RA primary, HD fallback).
---------------------------------------------------------------------- */
;WITH
per_receipt AS (
    SELECT
        a.[LIST#],
        a.[YEAR],
        a.a_receipt,

        MAX(a.ui_pay_dt) AS ui_pay_dt,
        MAX(a.hh_batch)  AS hh_batch,
        MAX(a.hh_entry_time) AS hh_entry_time,
        MAX(a.last_pay_dt) AS last_pay_dt,

		SUM(CASE
				WHEN sc.utch_charge IS NULL THEN ISNULL(a.eff_paid_applied,0)

				-- ONLY charges whose utch_long contains "LIEN FEE" go to lien bucket
				WHEN UPPER(LTRIM(RTRIM(ISNULL(sc.utch_long,'')))) LIKE '%LIEN FEE%' THEN 0

				-- Interest bucket (keep your existing convention)
				WHEN UPPER(LTRIM(RTRIM(ISNULL(sc.utch_short,'')))) LIKE 'INTER%' THEN 0

				ELSE ISNULL(a.eff_paid_applied,0)
			END) AS principal_amt,

		SUM(CASE
				WHEN sc.utch_charge IS NULL THEN ISNULL(a.eff_interest_paid,0)

				-- lien-fee rule doesn't affect interest; interest still interest
				WHEN UPPER(LTRIM(RTRIM(ISNULL(sc.utch_short,'')))) LIKE 'INTER%' THEN ISNULL(a.eff_interest_paid,0)

				ELSE 0
			END) AS interest_amt,

		SUM(CASE
				WHEN sc.utch_charge IS NULL THEN 0

				-- ONLY "…LIEN FEE…" goes into LAMT
				WHEN UPPER(LTRIM(RTRIM(ISNULL(sc.utch_long,'')))) LIKE '%LIEN FEE%'
					THEN ISNULL(a.eff_paid_applied,0) + ISNULL(a.eff_interest_paid,0)

				ELSE 0
			END) AS lien_amt
	FROM #alloc a
    LEFT JOIN TOSUTILITY.dbo.utcharge sc
        ON sc.utch_charge = a.SERV
    GROUP BY
        a.[LIST#], a.[YEAR], a.a_receipt
),
rows_for_insert AS (
    SELECT
        p.*,
        rt.receipt_total_amt,

        t.cash_total,
        t.check_total,
        t.credit_total,
        t.ref10,

        ROW_NUMBER() OVER (
            PARTITION BY ISNULL(p.hh_batch, 0)
            ORDER BY
                CAST(p.ui_pay_dt AS datetime2) ASC,
                p.a_receipt ASC,
                p.[LIST#] ASC,
                p.[YEAR] ASC
        ) AS batch_seq
    FROM per_receipt p
    LEFT JOIN #rt rt
        ON rt.a_bill_year = p.[YEAR]
       AND rt.a_receipt   = p.a_receipt
    LEFT JOIN #tender t
        ON t.a_bill_year = p.[YEAR]
       AND t.a_receipt   = p.a_receipt
)
INSERT INTO GEMSDTAB.dbo.TXHST (
    RECID, RCODE, [LIST#], [YEAR], [TYPE],
    PAMT, IAMT, LAMT, PCAMT, PENCD,
    CASH, [CHECK], CREDIT,
    CORC, DIST, REF, COMM, ADJCD,
    BATCHN, BATCHS, BATCHA,
    PDATE, CDATE,
    SUSCD, THAJCD, THINPD,
    INTOR, PRF, CHDATE, CHTIME
)
SELECT
    CAST(r.a_receipt AS numeric(9,0)) AS RECID,
    CAST(' ' AS char(1)) AS RCODE,

    CAST(r.[LIST#] AS numeric(6,0)) AS [LIST#],
    CAST(r.[YEAR]  AS numeric(4,0)) AS [YEAR],
    CAST('D' AS char(1)) AS [TYPE],

    CAST(
        ROUND(
            ISNULL(r.principal_amt,0)
            + CASE WHEN ABS(ISNULL(r.lien_amt,0)) > 999.99 THEN ISNULL(r.lien_amt,0) ELSE 0 END
        , 2)
        AS numeric(11,2)
    ) AS PAMT,

    CAST(
        ROUND(ISNULL(r.interest_amt,0), 2)
        AS numeric(7,2)
    ) AS IAMT,

    CAST(
        ROUND(
            CASE
                WHEN ABS(ISNULL(r.lien_amt,0)) > 999.99 THEN 0
                ELSE ISNULL(r.lien_amt,0)
            END
        , 2)
        AS numeric(5,2)
    ) AS LAMT,

    CAST(0 AS numeric(9,2)) AS PCAMT,
    CAST('  ' AS char(2)) AS PENCD,

    CAST(
        CASE WHEN ISNULL(r.receipt_total_amt,0) = 0 THEN 0
             ELSE ROUND(ISNULL(r.cash_total,0)   * ((ISNULL(r.principal_amt,0)+ISNULL(r.interest_amt,0)+ISNULL(r.lien_amt,0)) / r.receipt_total_amt), 2)
        END
        AS numeric(11,2)
    ) AS CASH,

    CAST(
        CASE WHEN ISNULL(r.receipt_total_amt,0) = 0 THEN 0
             ELSE ROUND(ISNULL(r.check_total,0)  * ((ISNULL(r.principal_amt,0)+ISNULL(r.interest_amt,0)+ISNULL(r.lien_amt,0)) / r.receipt_total_amt), 2)
        END
        AS numeric(11,2)
    ) AS [CHECK],

    CAST(
        CASE WHEN ISNULL(r.receipt_total_amt,0) = 0 THEN 0
             ELSE ROUND(ISNULL(r.credit_total,0) * ((ISNULL(r.principal_amt,0)+ISNULL(r.interest_amt,0)+ISNULL(r.lien_amt,0)) / r.receipt_total_amt), 2)
        END
        AS numeric(11,2)
    ) AS CREDIT,

    CAST(' ' AS char(1)) AS CORC,
    CAST(0 AS numeric(3,0)) AS DIST,
    CAST(ISNULL(r.ref10,'') AS char(10)) AS REF,
    CAST('' AS char(20)) AS COMM,
    CAST(' ' AS char(1)) AS ADJCD,

    CAST(ISNULL(r.hh_batch,0) AS numeric(5,0)) AS BATCHN,
    CAST(ISNULL(r.batch_seq,0) AS numeric(6,0)) AS BATCHS,
    CAST(' ' AS char(1)) AS BATCHA,

    CAST(
        ISNULL(CONVERT(int, CONVERT(char(8), CAST(r.ui_pay_dt AS date), 112)), 0)
        AS numeric(8,0)
    ) AS PDATE,

    CAST(
        ISNULL(CONVERT(int, CONVERT(char(8), CAST(r.ui_pay_dt AS date), 112)), 0)
        AS numeric(8,0)
    ) AS CDATE,

    CAST(' ' AS char(1)) AS SUSCD,
    CAST(' ' AS char(1)) AS THAJCD,
    CAST(' ' AS char(1)) AS THINPD,

    CAST(0 AS numeric(7,2)) AS INTOR,
    CAST('' AS char(10)) AS PRF,

    CAST(
        ISNULL(CONVERT(int, CONVERT(char(8), CAST(r.last_pay_dt AS date), 112)), 0)
        AS numeric(8,0)
    ) AS CHDATE,

    CAST(
        CASE
            WHEN r.hh_entry_time LIKE '[0-2][0-9]:[0-5][0-9]:[0-5][0-9]'
                THEN REPLACE(r.hh_entry_time, ':', '')
            WHEN r.hh_entry_time LIKE '[0-2][0-9]:[0-5][0-9]'
                THEN REPLACE(r.hh_entry_time, ':', '') + '00'
            WHEN r.hh_entry_time LIKE '[0-2][0-9][0-5][0-9][0-5][0-9]'
                THEN r.hh_entry_time
            ELSE '000000'
        END
        AS numeric(6,0)
    ) AS CHTIME
FROM rows_for_insert r;