/****** Object:  View [dbo].[LEDGERAP]    Script Date: 9/30/2020 1:03:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[LEDGERPO] AS Select 
    "BALFC",
    "TRTYP",
    "CBLCD",
    "GLTYP",
    "TRFTO",
    "FDNBR",
    "DPNBR",
    "OBNBR",
    "FNPGM",
    "DATED",
    "FIL10",
    "SRCDE",
    "TRAMT",
    "TDESC",
    "REFNO",
    "ORIG",
    "SUBFN",
    "AUTOG",
    "FIL045",
    "BCHNO",
    "TRNBR",
    "JRNSQ",
    "GLPST",
    "AMTYP",
    "INVNR",
    "SFUND",
    "PRF",
    "ROCR",
    "PSTDT",
    "TDATE",
    "PONBR",
    "CHKN",
    "FSCYR",
    "CNTRL",
    "RECLS"
FROM "LEDGER"
WHERE "SRCDE" = 4 
GO

