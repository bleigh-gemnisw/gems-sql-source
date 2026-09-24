/****** Object:  Table [dbo].[CSHBCH]    Script Date: 12/11/2020 7:20:18 AM ******/
DROP TABLE CSHBCH
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CSHBCH](
	[BCHNO] [numeric](3, 0) NOT NULL,
	[RECNO] [numeric](4, 0) NOT NULL,
	[TRNDT] [numeric](8, 0) NOT NULL,
	[FDNBR] [numeric](3, 0) NOT NULL,
	[SFUND] [numeric](3, 0) NOT NULL,
	[DPNBR] [numeric](4, 0) NOT NULL,
	[OBNBR] [numeric](3, 0) NOT NULL,
	[FNPGM] [numeric](4, 0) NOT NULL,
	[SUBFN] [numeric](4, 0) NOT NULL,
	[DSCTX] [char](20) NOT NULL,
	[AMTCS] [numeric](11, 2) NOT NULL,
	[REFNO] [numeric](7, 0) NOT NULL,
	[FDNBD] [numeric](3, 0) NOT NULL,
	[SFUDD] [numeric](3, 0) NOT NULL,
	[DPNBD] [numeric](4, 0) NOT NULL,
	[OBNBD] [numeric](3, 0) NOT NULL,
	[FNPGD] [numeric](4, 0) NOT NULL,
	[SUBFD] [numeric](4, 0) NOT NULL,
	[ARPST] [numeric](8, 0) NOT NULL,
 CONSTRAINT [PK_CSHBCH] PRIMARY KEY CLUSTERED 
(
	[BCHNO] ASC,
	[RECNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [BCHNO]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [RECNO]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [TRNDT]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [FDNBR]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [SFUND]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [DPNBR]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [OBNBR]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [FNPGM]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [SUBFN]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ('') FOR [DSCTX]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [AMTCS]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [REFNO]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [FDNBD]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [SFUDD]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [DPNBD]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [OBNBD]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [FNPGD]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [SUBFD]
GO

ALTER TABLE [dbo].[CSHBCH] ADD  DEFAULT ((0)) FOR [ARPST]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'BATCHNO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'BCHNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BATCH NO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'BCHNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'RECORDSEQNO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'RECNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RECORD SEQNO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'RECNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'TRANS.DATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'TRNDT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRANS. DATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'TRNDT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'FUNDNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'FDNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FUND NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'FDNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'SUBFUND' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'SFUND'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SUB FUND' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'SFUND'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'DEPTNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'DPNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DEPT NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'DPNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'OBJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'OBNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'OBJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'OBNBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'FUNC/PROG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'FNPGM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FUNC/PROG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'FNPGM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'SUBFUNCTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'SUBFN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SUB FUNCTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'SUBFN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'DESCRIPTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'DSCTX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DESCRIPTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'DSCTX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'CASHAMOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'AMTCS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CASH AMOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'AMTCS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'REFERENCE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'REFNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'REFERENCE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'REFNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'FUNDNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'FDNBD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FUND NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'FDNBD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'SUBFUND' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'SFUDD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SUB FUND' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'SFUDD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'DEPTNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'DPNBD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DEPT NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'DPNBD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'OBJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'OBNBD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'OBJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'OBNBD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'FUNC/PROG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'FNPGD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FUNC/PROG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'FNPGD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'SUBFUNCTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'SUBFD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SUB FUNCTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'SUBFD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'POSTINGDATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'ARPST'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'POSTING DATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CSHBCH', @level2type=N'COLUMN',@level2name=N'ARPST'
GO


