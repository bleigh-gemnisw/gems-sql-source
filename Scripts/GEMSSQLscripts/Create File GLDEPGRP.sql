/****** Object:  Table [dbo].[GLDEPGRP]    Script Date: 12/11/2020 8:35:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[GLDEPGRP](
	[CODE] [numeric](2, 0) NOT NULL,
	[DESC] [char](30) NOT NULL,
	[EXCTOT] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[GLDEPGRP] ADD  DEFAULT ((0)) FOR [CODE]
GO

ALTER TABLE [dbo].[GLDEPGRP] ADD  DEFAULT ('') FOR [DESC]
GO

ALTER TABLE [dbo].[GLDEPGRP] ADD  DEFAULT ('') FOR [EXCTOT]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'GROUP CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEPGRP', @level2type=N'COLUMN',@level2name=N'CODE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GROUP CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEPGRP', @level2type=N'COLUMN',@level2name=N'CODE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Caption', @value=N'EXCLUDEFUNDTOTAL?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEPGRP', @level2type=N'COLUMN',@level2name=N'EXCTOT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EXCLUDE FUND TOTAL?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEPGRP', @level2type=N'COLUMN',@level2name=N'EXCTOT'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_AccessPath', @value=N'<AccessPath Unique="F"><KeyField Name="CODE" Order="A"/></AccessPath>' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEPGRP'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_FileOrMember', @value=N'*BOTH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEPGRP'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_MaxMembers', @value=N'1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEPGRP'
GO

EXEC sys.sp_addextendedproperty @name=N'ASNA_WaitForRecord', @value=N'60' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GLDEPGRP'
GO


