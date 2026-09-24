/****** Object:  Table [dbo].[ACCNARL]    Script Date: 12/11/2020 8:29:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ACCNARL](
	[FUND] [numeric](3, 0) NOT NULL,
	[SFUND] [numeric](3, 0) NOT NULL,
	[DEPT] [numeric](4, 0) NOT NULL,
	[OBJ] [numeric](3, 0) NOT NULL,
	[FUNC] [numeric](4, 0) NOT NULL,
	[SFUNC] [numeric](4, 0) NOT NULL,
	[SEQ4] [numeric](4, 0) NOT NULL,
	[NARR] [char](74) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ACCNARL] ADD  DEFAULT ((0)) FOR [FUND]
GO

ALTER TABLE [dbo].[ACCNARL] ADD  DEFAULT ((0)) FOR [SFUND]
GO

ALTER TABLE [dbo].[ACCNARL] ADD  DEFAULT ((0)) FOR [DEPT]
GO

ALTER TABLE [dbo].[ACCNARL] ADD  DEFAULT ((0)) FOR [OBJ]
GO

ALTER TABLE [dbo].[ACCNARL] ADD  DEFAULT ((0)) FOR [FUNC]
GO

ALTER TABLE [dbo].[ACCNARL] ADD  DEFAULT ((0)) FOR [SFUNC]
GO

ALTER TABLE [dbo].[ACCNARL] ADD  DEFAULT ((0)) FOR [SEQ4]
GO

ALTER TABLE [dbo].[ACCNARL] ADD  DEFAULT ('') FOR [NARR]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'FUNDNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'FUND'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FUND NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'FUND'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'SUBFUND' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'SFUND'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SUB FUND' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'SFUND'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'DEPTNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'DEPT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DEPT NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'DEPT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'OBJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'OBJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'OBJECT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'OBJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'FUNC/PROG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'FUNC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FUNC/PROG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'FUNC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'SUBFUNCTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'SFUNC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SUB FUNCTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'SFUNC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'SEQ4'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'SEQ4'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'NARRATIVE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'NARR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NARRATIVE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL', @level2type=N'COLUMN',@level2name=N'NARR'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_AccessPath', @value=N'<AccessPath Unique="F"><KeyField Name="FUND" Order="A"/><KeyField Name="SFUND" Order="A"/><KeyField Name="DEPT" Order="A"/><KeyField Name="OBJ" Order="A"/><KeyField Name="FUNC" Order="A"/><KeyField Name="SFUNC" Order="A"/><KeyField Name="SEQ4" Order="A"/></AccessPath>' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_Description', @value=N'Account Narrative-Ledyard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_FileOrMember', @value=N'*BOTH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_MaxMembers', @value=N'1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_WaitForRecord', @value=N'60' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACCNARL'
GO


