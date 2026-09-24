/****** Object:  Table [dbo].[GLDEP]    Script Date: 12/11/2020 8:33:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[GLDEP](
	[DEPT] [numeric](4, 0) NOT NULL,
	[DESC] [char](30) NOT NULL,
	[DEGRP] [numeric](2, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DEPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[GLDEP] ADD  DEFAULT ((0)) FOR [DEPT]
GO

ALTER TABLE [dbo].[GLDEP] ADD  DEFAULT ('') FOR [DESC]
GO

ALTER TABLE [dbo].[GLDEP] ADD  DEFAULT ((0)) FOR [DEGRP]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'DEPTNUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEP', @level2type=N'COLUMN',@level2name=N'DEPT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DEPT NUMBER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEP', @level2type=N'COLUMN',@level2name=N'DEPT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'GROUP CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEP', @level2type=N'COLUMN',@level2name=N'DEGRP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GROUP CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEP', @level2type=N'COLUMN',@level2name=N'DEGRP'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_AccessPath', @value=N'<AccessPath Unique="F"><KeyField Name="DEPT" Order="A"/></AccessPath>' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEP'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_FileOrMember', @value=N'*BOTH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEP'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_MaxMembers', @value=N'1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEP'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_WaitForRecord', @value=N'60' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEP'
GO


