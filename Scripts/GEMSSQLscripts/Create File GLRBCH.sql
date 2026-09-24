
/****** Object:  Table [dbo].[GLRBCH]    Script Date: 5/14/2020 8:51:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[GLRBCH](
	[BCHNO] [decimal](3, 0) NOT NULL,
	[TRNBR] [numeric](5, 0) NOT NULL,
	[JRNSEQ] [numeric](4, 0) NOT NULL,
	[TRNTYP] [char](1) NOT NULL,
	[AMTTYP] [char](1) NOT NULL,
	[AMT] [decimal](11, 2) NOT NULL,
	[TOTCR] [decimal](12, 2) NOT NULL,
	[TOTDR] [decimal](12, 2) NOT NULL,
	[FDNBR] [numeric](3, 0) NOT NULL,
	[SFUND] [numeric](3, 0) NOT NULL,
	[DPNBR] [numeric](4, 0) NOT NULL,
	[OBNBR] [numeric](3, 0) NOT NULL,
	[FNPGM] [numeric](4, 0) NOT NULL,
	[SUBFN] [numeric](4, 0) NOT NULL,
	[DESCR] [char](20) NOT NULL,
	[GLTYP] [char](1) NOT NULL,
	[REFNO] [numeric](7, 0) NOT NULL,
	[JENT8] [numeric](8, 0) NOT NULL,
	[JACT8] [numeric](8, 0) NOT NULL,
	[PRJ] [numeric](10, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BCHNO] ASC,
	[TRNBR] ASC,
	[JRNSEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [ASNA_KEY_GLRBCH] UNIQUE NONCLUSTERED 
(
	[BCHNO] ASC,
	[TRNBR] ASC,
	[JRNSEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [BCHNO]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [TRNBR]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [JRNSEQ]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ('') FOR [TRNTYP]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ('') FOR [AMTTYP]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [AMT]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [TOTCR]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [TOTDR]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [FDNBR]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [SFUND]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [DPNBR]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [OBNBR]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [FNPGM]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [SUBFN]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ('') FOR [DESCR]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ('') FOR [GLTYP]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [REFNO]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [JENT8]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [JACT8]
GO

ALTER TABLE [dbo].[GLRBCH] ADD  DEFAULT ((0)) FOR [PRJ]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'BATCHNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'BCHNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BATCH NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'BCHNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'TRN.NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'TRNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRN. NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'TRNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'JRN-SEQNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'JRNSEQ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'JRN-SEQ NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'JRNSEQ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'TRN.TYPE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'TRNTYP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRN. TYPE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'TRNTYP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'DEBITCREDIT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'AMTTYP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DEBIT CREDIT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'AMTTYP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'TRANSAMOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRANS AMOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'TOTAL CREDIT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'TOTCR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TOTAL CREDIT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'TOTCR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'TOTAL DEBIT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'TOTDR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TOTAL DEBIT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'TOTDR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'FUNDNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'FDNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FUND NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'FDNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'SUBFUND' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'SFUND'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SUB FUND' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'SFUND'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'DEPTNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'DPNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DEPT NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'DPNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'OBJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'OBNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'OBJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'OBNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'FUNC/PROG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'FNPGM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FUNC/PROG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'FNPGM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'SUBFUNCTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'SUBFN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SUB FUNCTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'SUBFN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'DESCRIPTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'DESCR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DESCRIPTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'DESCR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'GLTYPE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'GLTYP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GL TYPE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'GLTYP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'PO/CHK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'REFNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PO/CHK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'REFNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'JRN.ENTDATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'JENT8'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'JRN. ENT DATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'JENT8'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'JRN.ACTDATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'JACT8'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'JRN. ACT DATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'JACT8'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'PROJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'PRJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PROJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH', @level2type=N'COLUMN',@level2name=N'PRJ'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_AccessPath', @value=N'<AccessPath Unique="T"><KeyField Name="BCHNO" Order="A"/><KeyField Name="TRNBR" Order="A"/><KeyField Name="JRNSEQ" Order="A"/></AccessPath>' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_Description', @value=N'Re-Occuring Journal batch entry file       Y2k -N' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_WaitForRecord', @value=N'60' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLRBCH'
GO


