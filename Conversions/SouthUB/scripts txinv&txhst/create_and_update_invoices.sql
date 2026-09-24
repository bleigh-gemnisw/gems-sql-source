-- TRUNCATE TABLE GEMSDTAB.dbo.TXINV;
-- SELECT COUNT(*) FROM  GEMSDTAB.dbo.TXINV WHERE [TYPE] = 'D';
DELETE FROM GEMSDTAB.dbo.TXINV WHERE [TYPE] = 'D';

DECLARE @AcctLike varchar(30) = '%';   -- change later if you want (e.g. '%102378%')

IF OBJECT_ID('tempdb..#src')    IS NOT NULL DROP TABLE #src;
IF OBJECT_ID('tempdb..#winner') IS NOT NULL DROP TABLE #winner;

;WITH
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

/* ============================================================================
   CHANGE: bh_pick no longer chooses rn=1 (earliest bill). Keep ALL bills.
   - Eliminates early-bill bias
   - pk_rn (latest bill within LIST#/YEAR) still selects the single winner
============================================================================ */
bh_pick AS (
    SELECT
        bh.*
    FROM TOSUTILITY.dbo.ub_bill_header bh
)

SELECT
    -- TXINV payload
    ''              AS [ICODE],
    lg.CUACCT       AS [LIST#],
    bh.a_bill_year  AS [YEAR],
    'D'             AS [TYPE],

    lg.CUNAM1       AS [NAME],
    lg.CUNAM2       AS [SNAME],
    lg.CUADD1       AS [ADD1],
    lg.CUADD2       AS [ADD2],
    lg.CUCITY       AS [CITY],
    lg.CUST         AS [STATE],

    ISNULL(
        TRY_CONVERT(
            numeric(5,0),
            CASE
                WHEN LEFT(LEFT(REPLACE(LTRIM(RTRIM(lg.CUZIP)),'-',''), 5), 1) = 'O'
                THEN '0' + SUBSTRING(LEFT(REPLACE(LTRIM(RTRIM(lg.CUZIP)),'-',''), 5), 2, 4)
                ELSE LEFT(REPLACE(LTRIM(RTRIM(lg.CUZIP)),'-',''), 5)
            END
        ),
        0
    ) AS [ZIP5],

    lg.CUDST        AS [PDST],

    bh.bh_bill_amount AS [TAXT],
    bh.bh_bill_amount AS [TAX1],
    0.00 AS [TAX2],
    0.00 AS [TX3RD],
    0.00 AS [TX4TH],

    lg.CULOC#       AS [LOC#],
    lg.CULOC        AS [LOC],

    0.00            AS [PAYREC],
    0.00            AS [NEWPAY],
    bh.bh_unpd_bal  AS [BALD],

    ''              AS [LIEN],
    0               AS [CCNO],
    0.00            AS [CCETAX],
    0.00            AS [CCTX1],
    0.00            AS [CCTX2],
    0               AS [CDATE],
    ''              AS [CCRSN],

    lg.CUMAP        AS [MAP],
    SUBSTRING(lg.CUNAM1, 1, 1) AS [LETT],
    lg.CUVOLM       AS [VOL],
    lg.CUPAGE       AS [IPAGE],

    0.00            AS [INTPD],
    0.00            AS [LNPD],
    0.00            AS [RPD],

    lg.OID          AS [OID],
    ''              AS [FEC1],
    ''              AS [FEC2],
    0.00            AS [FED1],
    0.00            AS [FED2],
    ''              AS [STCD1],
    ''              AS [CCM],
    ''              AS [ACCTN],
    ''              AS [PRF],

    -- debug identity used for consistent updates
    lg.CUCNT#        AS dbg_CUCNT,
    lg.CUMETN        AS dbg_CUMETN,
    bh.a_bill_number AS dbg_bill_number,
    bh.bh_bill_date1 AS dbg_bill_date,

    -- PK collision resolver: keep latest bill for (LIST#, YEAR)
    ROW_NUMBER() OVER (
        PARTITION BY lg.CUACCT, bh.a_bill_year
        ORDER BY
            bh.bh_bill_date1 DESC,
            bh.a_bill_number DESC,
            lg.LOGDTE DESC, lg.LOGTIM DESC, lg.LOGCMT DESC
    ) AS pk_rn
INTO #src
FROM bh_pick bh
JOIN lg_pick lg
    ON lg.CUCNT# = bh.a_acct
   AND lg.CUMETN = bh.a_account
CROSS APPLY (
    -- choose the utactcid row whose range contains the bill date;
    -- if multiple match (overlap), prefer the widest range
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
    AND lg.CUACCT IS NOT NULL;

-- Insert winners only
INSERT INTO GEMSDTAB.dbo.TXINV
(
    [ICODE],[LIST#],[YEAR],[TYPE],[NAME],[SNAME],[ADD1],[ADD2],[CITY],[STATE],[ZIP5],[PDST],
    [TAXT],[TAX1],[TAX2],[TX3RD],[TX4TH],[LOC#],[LOC],[PAYREC],[NEWPAY],[BALD],[LIEN],[CCNO],
    [CCETAX],[CCTX1],[CCTX2],[CDATE],[CCRSN],[MAP],[LETT],[VOL],[IPAGE],[INTPD],[LNPD],[RPD],
    [OID],[FEC1],[FEC2],[FED1],[FED2],[STCD1],[CCM],[ACCTN],[PRF]
)
SELECT
    [ICODE],[LIST#],[YEAR],[TYPE],[NAME],[SNAME],[ADD1],[ADD2],[CITY],[STATE],[ZIP5],[PDST],
    [TAXT],[TAX1],[TAX2],[TX3RD],[TX4TH],[LOC#],[LOC],[PAYREC],[NEWPAY],[BALD],[LIEN],[CCNO],
    [CCETAX],[CCTX1],[CCTX2],[CDATE],[CCRSN],[MAP],[LETT],[VOL],[IPAGE],[INTPD],[LNPD],[RPD],
    [OID],[FEC1],[FEC2],[FED1],[FED2],[STCD1],[CCM],[ACCTN],[PRF]
FROM #src
WHERE pk_rn = 1;

-- Build the winner map (THIS is what keeps updates consistent with the inserted row)
SELECT
    s.[LIST#],
    s.[YEAR],
    s.dbg_CUCNT  AS win_CID,
    s.dbg_CUMETN AS win_ACCOUNT
INTO #winner
FROM #src s
WHERE s.pk_rn = 1;

--------------------------------------------------------------------------------
-- Update: apply bills 2/3/4 (TAX2/TX3RD/TX4TH and add totals) for the WINNER only
--------------------------------------------------------------------------------
;WITH bh_rank AS (
    SELECT
        bh.a_acct,
        bh.a_account,
        bh.a_bill_year,
        bh.a_bill_number,
        bh.bh_bill_date1,
        bh.bh_bill_amount,
        bh.bh_unpd_bal,
        ROW_NUMBER() OVER (
            PARTITION BY bh.a_acct, bh.a_account, bh.a_bill_year
            ORDER BY bh.bh_bill_date1 ASC, bh.a_bill_number ASC
        ) AS rn
    FROM TOSUTILITY.dbo.ub_bill_header bh
    JOIN #winner w
        ON w.win_CID     = bh.a_acct
       AND w.win_ACCOUNT = bh.a_account
       AND w.[YEAR]      = bh.a_bill_year
),
bh_agg AS (
    SELECT
        w.[LIST#],
        w.[YEAR],

        SUM(CASE WHEN b.rn IN (2,3,4) THEN ISNULL(b.bh_bill_amount,0) ELSE 0 END) AS Add_TAXT,
        SUM(CASE WHEN b.rn IN (2,3,4) THEN ISNULL(b.bh_unpd_bal,0)  ELSE 0 END) AS Add_BALD,

        MAX(CASE WHEN b.rn = 2 THEN ISNULL(b.bh_bill_amount, 0) ELSE 0 END) AS Set_TAX2,
        MAX(CASE WHEN b.rn = 3 THEN ISNULL(b.bh_bill_amount, 0) ELSE 0 END) AS Set_TX3RD,
        MAX(CASE WHEN b.rn = 4 THEN ISNULL(b.bh_bill_amount, 0) ELSE 0 END) AS Set_TX4TH
    FROM #winner w
    JOIN bh_rank b
        ON b.a_acct      = w.win_CID
       AND b.a_account   = w.win_ACCOUNT
       AND b.a_bill_year = w.[YEAR]
       AND b.rn IN (2,3,4)
    GROUP BY
        w.[LIST#],
        w.[YEAR]
)
UPDATE tx
SET
    tx.TAXT  = ISNULL(tx.TAXT, 0) + ISNULL(a.Add_TAXT, 0),
    tx.BALD  = ISNULL(tx.BALD, 0) + ISNULL(a.Add_BALD, 0),

    tx.TAX2  = COALESCE(a.Set_TAX2,  tx.TAX2),
    tx.TX3RD = COALESCE(a.Set_TX3RD, tx.TX3RD),
    tx.TX4TH = COALESCE(a.Set_TX4TH, tx.TX4TH)
FROM GEMSDTAB.dbo.TXINV tx
JOIN bh_agg a
    ON a.[LIST#] = tx.[LIST#]
   AND a.[YEAR]  = tx.[YEAR]
WHERE
    tx.[TYPE] = 'D';

--------------------------------------------------------------------------------
-- Update: apply payments for the WINNER only
--------------------------------------------------------------------------------
;WITH ap_agg AS (
    SELECT
        w.[LIST#],
        w.[YEAR],

        -- TXIDT is numeric(8,0): YYYYMMDD
        MAX(CONVERT(int, CONVERT(char(8), ap.utap_date, 112))) AS New_TXIDT,
        SUM(ap.utap_amt) AS Add_PAYREC
    FROM #winner w
    JOIN TOSUtility.dbo.utapcrdp ap
        ON ap.utap_cid      = w.win_CID
       AND ap.utap_account  = w.win_ACCOUNT
       AND CAST(ap.utap_bill_year AS int) = w.[YEAR]
    WHERE
        ap.utap_account LIKE @AcctLike
    GROUP BY
        w.[LIST#],
        w.[YEAR]
)
UPDATE tx
SET
    tx.TXIDT  = a.New_TXIDT,
    tx.PAYREC = ISNULL(tx.PAYREC, 0) + ISNULL(a.Add_PAYREC, 0)
FROM GEMSDTAB.dbo.TXINV tx
JOIN ap_agg a
    ON a.[LIST#] = tx.[LIST#]
   AND a.[YEAR]  = tx.[YEAR]
WHERE
    tx.[TYPE] = 'D';