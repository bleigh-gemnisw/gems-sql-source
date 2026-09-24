/****** Object:  View [dbo].[LEDGERPR]    Script Date: 12/14/2020 12:10:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[LEDGERPR] AS Select 
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
WHERE "SRCDE" = 5 OR  (NOT( (5=5) ) AND((5=5)))
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_AccessPath', @value=N'<AccessPath Unique="F"><KeyField Name="PSTDT" Order="A"/><KeyField Name="INVNR" Order="A"/></AccessPath>' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LEDGERPR'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_FileOrMember', @value=N'*BOTH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LEDGERPR'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_MaxMembers', @value=N'1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LEDGERPR'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_WaitForRecord', @value=N'60' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LEDGERPR'
GO


