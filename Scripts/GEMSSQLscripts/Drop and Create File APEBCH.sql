DROP TABLE APEBCH
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[APEBCH](
	[BCHNO] [decimal](5, 0) NOT NULL,
	[SEQNO] [decimal](4, 0) NOT NULL,
	[VNDNR] [char](5) NOT NULL,
	[VENNM] [char](25) NOT NULL,
	[INVNO] [char](30) NOT NULL,
	[PONBR] [numeric](7, 0) NOT NULL,
	[FSCYR] [numeric](4, 0) NOT NULL,
	[DSCTX] [char](20) NOT NULL,
	[PRJ] [numeric](10, 0) NOT NULL,
	[AMTGR] [decimal](11, 2) NOT NULL,
	[AMTDS] [decimal](11, 2) NOT NULL,
	[AMTSH] [decimal](11, 2) NOT NULL,
	[AMTNT] [decimal](11, 2) NOT NULL,
	[F1099] [char](1) NOT NULL,
	[PPCKN] [numeric](7, 0) NOT NULL,
	[PPAMT] [numeric](11, 2) NOT NULL,
	[LEOPN] [char](1) NOT NULL,
	[RSQDG] [numeric](1, 0) NOT NULL,
	[BNKCD] [char](5) NOT NULL,
	[CSHYN] [char](1) NOT NULL,
	[HINV] [char](1) NOT NULL,
	[INVD8] [numeric](8, 0) NOT NULL,
	[DUED8] [numeric](8, 0) NOT NULL,
	[PPDT8] [numeric](8, 0) NOT NULL,
	[APPST] [numeric](8, 0) NOT NULL,
 CONSTRAINT [PK__APEBCH__B3CAA00FE4A4B274] PRIMARY KEY CLUSTERED 
(
	[BCHNO] ASC,
	[SEQNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__RECNO__2FF123C1]  DEFAULT ((0)) FOR [BCHNO]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__VNDNR__36A89750]  DEFAULT ('') FOR [VNDNR]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__VENNM__421A49FC]  DEFAULT ('') FOR [VENNM]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__INVNO__30EFBDFA]  DEFAULT ('') FOR [INVNO]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__PONBR__379CBB89]  DEFAULT ((0)) FOR [PONBR]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__FSCYR__45EADAE0]  DEFAULT ((0)) FOR [FSCYR]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__DSCTX__35B47317]  DEFAULT ('') FOR [DSCTX]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__PRJ__4BA3B436]  DEFAULT ((0)) FOR [PRJ]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__AMTGR__31E3E233]  DEFAULT ((0)) FOR [AMTGR]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__AMTDS__32D8066C]  DEFAULT ((0)) FOR [AMTDS]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__AMTSH__33CC2AA5]  DEFAULT ((0)) FOR [AMTSH]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__AMTNT__34C04EDE]  DEFAULT ((0)) FOR [AMTNT]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__F1099__3890DFC2]  DEFAULT ('') FOR [F1099]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__PPCKN__398503FB]  DEFAULT ((0)) FOR [PPCKN]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__PPAMT__3A792834]  DEFAULT ((0)) FOR [PPAMT]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__LEOPN__3B6D4C6D]  DEFAULT ('') FOR [LEOPN]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__RSQDG__430E6E35]  DEFAULT ((0)) FOR [RSQDG]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__BNKCD__4402926E]  DEFAULT ('') FOR [BNKCD]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__CSHYN__44F6B6A7]  DEFAULT ('') FOR [CSHYN]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__HINV__46DEFF19]  DEFAULT ('') FOR [HINV]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__INVD8__48C7478B]  DEFAULT ((0)) FOR [INVD8]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__DUED8__49BB6BC4]  DEFAULT ((0)) FOR [DUED8]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__PPDT8__4AAF8FFD]  DEFAULT ((0)) FOR [PPDT8]
GO

ALTER TABLE [dbo].[APEBCH] ADD  CONSTRAINT [DF__APEBCH__APPST__4C97D86F]  DEFAULT ((0)) FOR [APPST]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'VENDORNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'VNDNR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VENDOR NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'VNDNR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'VENDORNAME' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'VENNM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VENDOR NAME' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'VENNM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'INVOICENUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'INVNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'INVOICE NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'INVNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'PONUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'PONBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PO NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'PONBR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'POFISCALYR' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'FSCYR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PO FISCAL YR' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'FSCYR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'DESCRIPTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'DSCTX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DESCRIPTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'DSCTX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'PROJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'PRJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PROJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'PRJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'GROSSAMOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'AMTGR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GROSS AMOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'AMTGR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'AMOUNTDISCOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'AMTDS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AMOUNT DISCOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'AMTDS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'AMOUNTS/H' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'AMTSH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AMOUNT S/H' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'AMTSH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'NETAMOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'AMTNT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NET AMOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'AMTNT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'1099FLAG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'F1099'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1099 FLAG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'F1099'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'PREPAIDCHKNO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'PPCKN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PREPAID CHKNO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'PPCKN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'PREPAIDAMOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'PPAMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PREPAID AMOUNT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'PPAMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'LEAVEENCUMOPEN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'LEOPN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LEAVE ENCUM OPEN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'LEOPN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'RSQDG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'RSQDG'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'BANKCODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'BNKCD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BANK CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'BNKCD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'CASHACCOUNTY/N' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'CSHYN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CASH ACCOUNT Y/N' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'CSHYN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'HOLDINVOICE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'HINV'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'HOLD INVOICE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'HINV'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'INVOICEDATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'INVD8'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'INVOICE DATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'INVD8'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'DUEDATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'DUED8'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DUE DATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'DUED8'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'PREPAIDDATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'PPDT8'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PREPAID DATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'PPDT8'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'POSTINGDATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'APPST'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'POSTING DATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH', @level2type=N'COLUMN',@level2name=N'APPST'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_AccessPath', @value=N'<AccessPath Unique="F"><KeyField Name="VNDNR" Order="A"/><KeyField Name="INVNO" Order="A"/><KeyField Name="RECNO" Order="A"/><KeyField Name="RSQDG" Order="A"/></AccessPath>' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_Description', @value=N'AP batch entry/maint file                   CHGY2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_WaitForRecord', @value=N'60' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APEBCH'
GO


