SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_Group]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_Group](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](30) NOT NULL,
	[GroupOrder] [int] NOT NULL CONSTRAINT [DF_RGP_UserGroup_UserGroupOrder]  DEFAULT ((0)),
	[GroupDescription] [nvarchar](50) NULL,
	[GroupType] [int] NOT NULL CONSTRAINT [DF_RGP_Groups_GroupType]  DEFAULT ((0)),
 CONSTRAINT [PK_RGP_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分组ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Group', @level2type=N'COLUMN', @level2name=N'GroupID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Group', @level2type=N'COLUMN', @level2name=N'GroupName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Group', @level2type=N'COLUMN', @level2name=N'GroupOrder'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Group', @level2type=N'COLUMN', @level2name=N'GroupDescription'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分组类型 用户组0,角色组1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Group', @level2type=N'COLUMN', @level2name=N'GroupType'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_ModuleAuthorityList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_ModuleAuthorityList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NOT NULL,
	[AuthorityTag] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RGP_ModuleAuthorityList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块权限ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_ModuleAuthorityList', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_ModuleAuthorityList', @level2type=N'COLUMN', @level2name=N'ModuleID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限标识' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_ModuleAuthorityList', @level2type=N'COLUMN', @level2name=N'AuthorityTag'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_Module]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_Module](
	[ModuleID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleTypeID] [int] NOT NULL,
	[ModuleName] [nvarchar](30) NOT NULL,
	[ModuleTag] [nvarchar](50) NOT NULL,
	[ModuleURL] [nvarchar](500) NULL,
	[ModuleDisabled] [bit] NOT NULL CONSTRAINT [DF_RGP_Modules_ModuleDisabled]  DEFAULT ((1)),
	[ModuleOrder] [int] NOT NULL CONSTRAINT [DF_RGP_Modules_ModuleOrder]  DEFAULT ((0)),
	[ModuleDescription] [nvarchar](50) NULL,
	[IsMenu] [bit] NOT NULL CONSTRAINT [DF_RGP_Modules_IsMenu]  DEFAULT ((1)),
	[ModuleICO] [nvarchar](50) NULL CONSTRAINT [DF_Base_Module_ModuleICO]  DEFAULT (N'~/Images/menuload.png'),
 CONSTRAINT [PK_RGP_Modules] PRIMARY KEY CLUSTERED 
(
	[ModuleID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Module', @level2type=N'COLUMN', @level2name=N'ModuleID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Module', @level2type=N'COLUMN', @level2name=N'ModuleTypeID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Module', @level2type=N'COLUMN', @level2name=N'ModuleName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块标识' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Module', @level2type=N'COLUMN', @level2name=N'ModuleTag'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块地址' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Module', @level2type=N'COLUMN', @level2name=N'ModuleURL'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否禁用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Module', @level2type=N'COLUMN', @level2name=N'ModuleDisabled'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Module', @level2type=N'COLUMN', @level2name=N'ModuleOrder'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Module', @level2type=N'COLUMN', @level2name=N'ModuleDescription'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示在导航菜单中' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Module', @level2type=N'COLUMN', @level2name=N'IsMenu'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_ModuleType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_ModuleType](
	[ModuleTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleTypeName] [nvarchar](30) NOT NULL,
	[ModuleTypeOrder] [int] NOT NULL CONSTRAINT [DF_ModuleGroup_ModuleGroupOrder]  DEFAULT ((0)),
	[ModuleTypeDescription] [nvarchar](50) NULL,
	[ModuleTypeDepth] [int] NOT NULL CONSTRAINT [DF_RGP_ModuleType_ModuleTypeDepth]  DEFAULT ((0)),
	[ModuleTypeSuperiorID] [int] NOT NULL CONSTRAINT [DF_RGP_ModuleType_ModuleTypeSuperiorID]  DEFAULT ((0)),
	[ModuleTypeCount] [int] NOT NULL CONSTRAINT [DF_RGP_ModuleType_ModuleTypeCount]  DEFAULT ((0)),
 CONSTRAINT [PK_RGP_ModuleType_1] PRIMARY KEY CLUSTERED 
(
	[ModuleTypeID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块分类ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_ModuleType', @level2type=N'COLUMN', @level2name=N'ModuleTypeID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块类型名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_ModuleType', @level2type=N'COLUMN', @level2name=N'ModuleTypeName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_ModuleType', @level2type=N'COLUMN', @level2name=N'ModuleTypeOrder'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_ModuleType', @level2type=N'COLUMN', @level2name=N'ModuleTypeDescription'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'深度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_ModuleType', @level2type=N'COLUMN', @level2name=N'ModuleTypeDepth'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_ModuleType', @level2type=N'COLUMN', @level2name=N'ModuleTypeSuperiorID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下级个数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_ModuleType', @level2type=N'COLUMN', @level2name=N'ModuleTypeCount'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_RoleAuthorityList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_RoleAuthorityList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL CONSTRAINT [DF_RGP_RoleAuthorityList_UserID]  DEFAULT ((0)),
	[RoleID] [int] NOT NULL CONSTRAINT [DF_RGP_RoleAuthorityList_RoleID]  DEFAULT ((0)),
	[GroupID] [int] NOT NULL CONSTRAINT [DF_RGP_RoleAuthorityList_GroupID]  DEFAULT ((0)),
	[ModuleID] [int] NOT NULL,
	[AuthorityTag] [nvarchar](50) NOT NULL,
	[Flag] [bit] NOT NULL CONSTRAINT [DF_RGP_RoleAuthorityList_Flag]  DEFAULT ((1)),
 CONSTRAINT [PK_RGP_RoleAuthorityList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_RoleAuthorityList', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_RoleAuthorityList', @level2type=N'COLUMN', @level2name=N'UserID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_RoleAuthorityList', @level2type=N'COLUMN', @level2name=N'RoleID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分组ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_RoleAuthorityList', @level2type=N'COLUMN', @level2name=N'GroupID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_RoleAuthorityList', @level2type=N'COLUMN', @level2name=N'ModuleID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限标识' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_RoleAuthorityList', @level2type=N'COLUMN', @level2name=N'AuthorityTag'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1为允许，0为不禁止' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_RoleAuthorityList', @level2type=N'COLUMN', @level2name=N'Flag'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleGroupID] [int] NOT NULL,
	[RoleName] [nvarchar](30) NOT NULL,
	[RoleDescription] [nvarchar](50) NULL,
	[RoleOrder] [int] NOT NULL CONSTRAINT [DF_RGP_Roles_RoleOrder]  DEFAULT ((0)),
 CONSTRAINT [PK_RGP_Roles_1] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Role', @level2type=N'COLUMN', @level2name=N'RoleID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分组ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Role', @level2type=N'COLUMN', @level2name=N'RoleGroupID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Role', @level2type=N'COLUMN', @level2name=N'RoleName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Role', @level2type=N'COLUMN', @level2name=N'RoleDescription'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_UserGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_UserGroup](
	[UG_ID] [int] IDENTITY(1,1) NOT NULL,
	[UG_Name] [nvarchar](30) NOT NULL,
	[UG_Order] [int] NOT NULL,
	[UG_Description] [nvarchar](50) NOT NULL,
	[UG_Depth] [int] NOT NULL CONSTRAINT [DF_t_UserGroup_UG_Depth]  DEFAULT ((0)),
	[UG_SuperiorID] [int] NOT NULL CONSTRAINT [DF_t_UserGroup_UG_SuperiorID]  DEFAULT ((0)),
	[UG_Count] [int] NOT NULL CONSTRAINT [DF_t_UserGroup_UG_Count]  DEFAULT ((0)),
 CONSTRAINT [PK_t_UserGroup] PRIMARY KEY CLUSTERED 
(
	[UG_ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户组ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_UserGroup', @level2type=N'COLUMN', @level2name=N'UG_ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户分组名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_UserGroup', @level2type=N'COLUMN', @level2name=N'UG_Name'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户分组排序' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_UserGroup', @level2type=N'COLUMN', @level2name=N'UG_Order'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户分组描述' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_UserGroup', @level2type=N'COLUMN', @level2name=N'UG_Description'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户分组深度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_UserGroup', @level2type=N'COLUMN', @level2name=N'UG_Depth'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户分组上级' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_UserGroup', @level2type=N'COLUMN', @level2name=N'UG_SuperiorID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户分组下级数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_UserGroup', @level2type=N'COLUMN', @level2name=N'UG_Count'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_UserRole]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_UserRole](
	[UR_ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_t_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UR_ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](128) NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Question] [nvarchar](100) NULL,
	[Answer] [nvarchar](100) NULL,
	[RoleID] [int] NOT NULL CONSTRAINT [DF_Users_RoleID]  DEFAULT ((0)),
	[UserGroup] [int] NOT NULL CONSTRAINT [DF_Users_UserGroup]  DEFAULT ((0)),
	[CreateTime] [datetime] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[Status] [int] NOT NULL CONSTRAINT [DF_Users_Status]  DEFAULT ((1)),
	[IsOnline] [bit] NOT NULL CONSTRAINT [DF_Users_IsOnline]  DEFAULT ((0)),
	[IsLimit] [bit] NOT NULL CONSTRAINT [DF_Users_IsLimit]  DEFAULT ((0)),
 CONSTRAINT [PK_User_ID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'UserID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名，用户Email' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'UserName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'Password'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'重置密码的问题' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'Question'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'重置密码的答案' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'Answer'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'RoleID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户组' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'UserGroup'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐户创建时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'CreateTime'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上一次登录的时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'LastLoginTime'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户状态' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'Status'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否在线' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'IsOnline'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否受权限限制，0为受限制' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User', @level2type=N'COLUMN', @level2name=N'IsLimit'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户帐户信息表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_User'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_Event]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_Event](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [varchar](50) NULL,
	[Summary] [varchar](50) NULL,
	[Score] [int] NULL CONSTRAINT [DF_BASE_TOPIC_SCORE]  DEFAULT ((0)),
	[EventIDParent] [int] NULL CONSTRAINT [DF_BASE_TOPIC_TOPICIDPARENT]  DEFAULT ((0)),
	[Enable] [int] NULL CONSTRAINT [DF_BASE_TOPIC_ENABLE]  DEFAULT ((0)),
	[Sort] [int] NULL CONSTRAINT [DF_BASE_TOPIC_SORT]  DEFAULT ((1)),
 CONSTRAINT [PK_BASE_TOPIC] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专题信息表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Event'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_Word]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_Word](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[WordName] [varchar](50) NULL,
	[Score] [float] NULL CONSTRAINT [DF_BASE_WORD_SCORE]  DEFAULT ((0)),
	[WordIDParent] [int] NULL CONSTRAINT [DF_BASE_WORD_WORDIDPARENT]  DEFAULT ((0)),
	[Enable] [int] NULL CONSTRAINT [DF_BASE_WORD_ENABLE]  DEFAULT ((0)),
 CONSTRAINT [PK_BASE_WORD] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键字信息表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Word'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_EventWord]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_EventWord](
	[EventWordID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[WordID] [int] NULL,
 CONSTRAINT [PK_BASE_EVENTSWORD] PRIMARY KEY CLUSTERED 
(
	[EventWordID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_UserEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_UserEvent](
	[ID] [int] NOT NULL,
	[UserID] [int] NULL,
	[EventID] [int] NULL,
 CONSTRAINT [PK_BASE_USEREVENT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_Message]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_Message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Detail] [varchar](50) NULL,
	[CreateTime] [datetime] NULL CONSTRAINT [DF_BASE_WARNING_GENERATEDATE]  DEFAULT (getdate()),
	[Status] [int] NULL CONSTRAINT [DF_BASE_WARNING_ENABLE]  DEFAULT ((0)),
	[Snapshop] [varchar](50) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_BASE_WARNING] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预警信息表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Message'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_Article]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_Article](
	[ArticleID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NULL,
	[Detail] [varchar](8000) NULL,
	[SendTime] [datetime] NULL,
	[Media] [varchar](50) NULL,
	[Author] [varchar](50) NULL,
	[ClickNum] [int] NULL CONSTRAINT [DF_BASE_ARTICLE_CLICK]  DEFAULT ((0)),
	[CommentNum] [int] NULL CONSTRAINT [DF_BASE_ARTICLE_COMMENT]  DEFAULT ((0)),
	[Url] [varchar](1024) NULL,
	[ExtractionTime] [datetime] NULL CONSTRAINT [DF_BASE_ARTICLE_EXTRACTIONDATE]  DEFAULT (getdate()),
	[Score] [float] NULL CONSTRAINT [DF_BASE_ARTICLE_SCORE]  DEFAULT ((0)),
 CONSTRAINT [PK_BASE_ARTICLE] PRIMARY KEY CLUSTERED 
(
	[ArticleID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章信息表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Article'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_EventArticle]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_EventArticle](
	[ID] [int] NOT NULL,
	[ArticleID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
 CONSTRAINT [PK_Base_EventArticle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_AuthorityDir]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_AuthorityDir](
	[AuthorityID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorityName] [nvarchar](30) NOT NULL,
	[AuthorityTag] [nvarchar](50) NOT NULL,
	[AuthorityDescription] [nvarchar](50) NULL,
	[AuthorityOrder] [int] NOT NULL CONSTRAINT [DF_AuthorityDir_AuthorityOrder]  DEFAULT ((0)),
 CONSTRAINT [PK_RGP_AuthorityDir_1] PRIMARY KEY CLUSTERED 
(
	[AuthorityID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_AuthorityDir', @level2type=N'COLUMN', @level2name=N'AuthorityID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_AuthorityDir', @level2type=N'COLUMN', @level2name=N'AuthorityName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限标识' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_AuthorityDir', @level2type=N'COLUMN', @level2name=N'AuthorityTag'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_AuthorityDir', @level2type=N'COLUMN', @level2name=N'AuthorityDescription'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_AuthorityDir', @level2type=N'COLUMN', @level2name=N'AuthorityOrder'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Base_Configuration]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Base_Configuration](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) NOT NULL,
	[ItemValue] [nvarchar](500) NULL,
	[ItemDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_Sys_Configuration] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配置项ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Configuration', @level2type=N'COLUMN', @level2name=N'ItemID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配置名' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Configuration', @level2type=N'COLUMN', @level2name=N'ItemName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配置值' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Configuration', @level2type=N'COLUMN', @level2name=N'ItemValue'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Base_Configuration', @level2type=N'COLUMN', @level2name=N'ItemDescription'