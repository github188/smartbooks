/*创建SmartCampusDB数据库*/
/*创建表、视图、过程、函数*/
/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2000                    */
/* Created on:     2012-1-22 15:12:56                           */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_ARTICLE')
            and   type = 'U')
   drop table BASE_ARTICLE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_CRET')
            and   type = 'U')
   drop table BASE_CRET
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_CRET_CROUP')
            and   type = 'U')
   drop table BASE_CRET_CROUP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_CRET_LEVAL')
            and   type = 'U')
   drop table BASE_CRET_LEVAL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_FILE')
            and   type = 'U')
   drop table BASE_FILE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_LINK')
            and   type = 'U')
   drop table BASE_LINK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_MENU')
            and   type = 'U')
   drop table BASE_MENU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_PHOTO')
            and   type = 'U')
   drop table BASE_PHOTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_PHOTO_GROUP')
            and   type = 'U')
   drop table BASE_PHOTO_GROUP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_STUDENT')
            and   type = 'U')
   drop table BASE_STUDENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_STUDENT_CRET')
            and   type = 'U')
   drop table BASE_STUDENT_CRET
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_USER')
            and   type = 'U')
   drop table BASE_USER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BASE_USER_ROLE')
            and   type = 'U')
   drop table BASE_USER_ROLE
go

/*==============================================================*/
/* Table: BASE_ARTICLE                                          */
/*==============================================================*/
create table BASE_ARTICLE (
   ARTICLEID            INT                  not null,
   TITLE                VARCHAR(200)         null,
   CONTENT              TEXT                 null,
   SDATE                DATETIME             null,
   EDATE                DATETIME             null,
   [READ]               INT                  null,
   COMMENT              INT                  null,
   COPYRIGHT            VARCHAR(2000)        null,
   AUTHOR               VARCHAR(20)          null,
   QUOTE                VARCHAR(200)         null,
   MENUID               VARCHAR(200)         null,
   PHOTOID              VARCHAR(200)         null,
   FILEID               VARCHAR(200)         null,
   VERSION              VARCHAR(10)          null,
   STATUS               INT                  null,
   ICON                 VARCHAR(200)         null,
   constraint PK_BASE_ARTICLE primary key nonclustered (ARTICLEID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章信息表',
   'user', @CurrentUser, 'table', 'BASE_ARTICLE'
go

/*==============================================================*/
/* Table: BASE_CRET                                             */
/*==============================================================*/
create table BASE_CRET (
   CRETID               int                  not null,
   CRETNO               varchar(50)          null,
   CRETNAME             varchar(50)          null,
   CRETGROUPID          int                  null,
   SUMMARY              varchar(5000)        null,
   IMAGE                varchar(200)         null,
   SDATE                datetime             null,
   EDATE                datetime             null,
   constraint PK_BASE_CRET primary key (CRETID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '证书信息表',
   'user', @CurrentUser, 'table', 'BASE_CRET'
go

/*==============================================================*/
/* Table: BASE_CRET_CROUP                                       */
/*==============================================================*/
create table BASE_CRET_CROUP (
   CRETGROUPID          int                  not null,
   TITLE                varchar(50)          null,
   SUMMARY              varchar(200)         null,
   PARENTID             int                  null,
   STATUS               int                  null,
   constraint PK_BASE_CRET_CROUP primary key (CRETGROUPID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '证书分类信息表',
   'user', @CurrentUser, 'table', 'BASE_CRET_CROUP'
go

/*==============================================================*/
/* Table: BASE_CRET_LEVAL                                       */
/*==============================================================*/
create table BASE_CRET_LEVAL (
   CRETLEVALID          int                  not null,
   CRETID               int                  null,
   SCORE                float                null,
   TITLE                varchar(50)          null,
   SUMMARY              varchar(200)         null,
   STATUS               int                  null,
   constraint PK_BASE_CRET_LEVAL primary key (CRETLEVALID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '证书考试成绩等级表',
   'user', @CurrentUser, 'table', 'BASE_CRET_LEVAL'
go

/*==============================================================*/
/* Table: BASE_FILE                                             */
/*==============================================================*/
create table BASE_FILE (
   FILEID               INT                  not null,
   TITLE                VARCHAR(50)          null,
   SUMMARY              VARCHAR(200)         null,
   PATH                 VARCHAR(200)         null,
   SDATE                DATETIME             null,
   EDATE                DATETIME             null,
   VERSION              VARCHAR(10)          null,
   ICON                 VARCHAR(200)         null,
   constraint PK_BASE_FILE primary key nonclustered (FILEID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '附件信息表',
   'user', @CurrentUser, 'table', 'BASE_FILE'
go

/*==============================================================*/
/* Table: BASE_LINK                                             */
/*==============================================================*/
create table BASE_LINK (
   LINKID               INT                  not null,
   TITLE                VARCHAR(50)          null,
   SUMMARY              VARCHAR(200)         null,
   HOME                 VARCHAR(200)         null,
   PR                   INT                  null,
   IMAGE                VARCHAR(200)         null,
   SDATE                DATETIME             null,
   EDATE                DATETIME             null,
   STATUS               INT                  null,
   VERSION              VARCHAR(10)          null,
   ICON                 VARCHAR(200)         null,
   constraint PK_BASE_LINK primary key nonclustered (LINKID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '友情链接信息表',
   'user', @CurrentUser, 'table', 'BASE_LINK'
go

/*==============================================================*/
/* Table: BASE_MENU                                             */
/*==============================================================*/
create table BASE_MENU (
   MENUID               INT                  not null,
   TITLE                VARCHAR(50)          null,
   SUMMARY              VARCHAR(50)          null,
   PATH                 VARCHAR(200)         null,
   PARENTID             INT                  null,
   STATUS               INT                  null,
   SORT                 INT                  null,
   ICON                 VARCHAR(200)         null,
   LICENSECODE          VARCHAR(32)          null,
   VERSION              VARCHAR(10)          null,
   SDATE                DATETIME             null,
   EDATE                DATETIME             null,
   constraint PK_BASE_MENU primary key nonclustered (MENUID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单信息表',
   'user', @CurrentUser, 'table', 'BASE_MENU'
go

/*==============================================================*/
/* Table: BASE_PHOTO                                            */
/*==============================================================*/
create table BASE_PHOTO (
   PHOTOID              INT                  not null,
   TITLE                VARCHAR(50)          null,
   SUMMARY              VARCHAR(200)         null,
   PATH                 VARCHAR(200)         null,
   VERSION              VARCHAR(10)          null,
   SDATE                DATETIME             null,
   EDATE                DATETIME             null,
   GROUPID              VARCHAR(200)         null,
   STATUS               INT                  null,
   ICON                 VARCHAR(200)         null,
   constraint PK_BASE_PHOTO primary key nonclustered (PHOTOID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '照片信息表',
   'user', @CurrentUser, 'table', 'BASE_PHOTO'
go

/*==============================================================*/
/* Table: BASE_PHOTO_GROUP                                      */
/*==============================================================*/
create table BASE_PHOTO_GROUP (
   GROUPID              INT                  not null,
   TITLE                VARCHAR(50)          null,
   SUMMARY              VARCHAR(50)          null,
   SORT                 INT                  null,
   STATUS               INT                  null,
   PARENTID             INT                  null,
   SDATE                DATETIME             null,
   EDATE                DATETIME             null,
   VERSION              VARCHAR(10)          null,
   ICON                 VARCHAR(200)         null,
   constraint PK_BASE_PHOTO_GROUP primary key nonclustered (GROUPID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片分类表',
   'user', @CurrentUser, 'table', 'BASE_PHOTO_GROUP'
go

/*==============================================================*/
/* Table: BASE_STUDENT                                          */
/*==============================================================*/
create table BASE_STUDENT (
   STUDENTID            int                  not null,
   USERNAME             varchar(12)          null,
   PWD                  varchar(32)          null,
   SEX                  varchar(2)           null,
   CARDNUMBER           varchar(20)          null,
   SDATE                datetime             null,
   EDATE                datetime             null,
   PHOTO                varchar(200)         null,
   ADDRESS              varchar(200)         null,
   constraint PK_BASE_STUDENT primary key (STUDENTID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学员信息表',
   'user', @CurrentUser, 'table', 'BASE_STUDENT'
go

/*==============================================================*/
/* Table: BASE_STUDENT_CRET                                     */
/*==============================================================*/
create table BASE_STUDENT_CRET (
   STUDENTCRETID        int                  not null,
   STUDENTID            int                  null,
   CRETID               int                  null,
   SDATE                datetime             null,
   EDATE                datetime             null,
   BISHI                float                null,
   JISHI                float                null,
   STATUS               int                  null,
   CRETLEVALID          int                  null,
   constraint PK_BASE_STUDENT_CRET primary key (STUDENTCRETID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学员证书信息表',
   'user', @CurrentUser, 'table', 'BASE_STUDENT_CRET'
go

/*==============================================================*/
/* Table: BASE_USER                                             */
/*==============================================================*/
create table BASE_USER (
   USERID               INT                  not null,
   USERNAME             VARCHAR(12)          null,
   PWD                  VARCHAR(32)          null,
   SEX                  VARCHAR(2)           null,
   EMAIL                VARCHAR(50)          null,
   TEL                  VARCHAR(11)          null,
   SDATE                DATETIME             null,
   EDATE                DATETIME             null,
   VERSION              VARCHAR(10)          null,
   STATUS               INT                  null,
   ICON                 VARCHAR(200)         null,
   ROLEID               VARCHAR(200)         null,
   constraint PK_BASE_USER primary key nonclustered (USERID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户信息表',
   'user', @CurrentUser, 'table', 'BASE_USER'
go

/*==============================================================*/
/* Table: BASE_USER_ROLE                                        */
/*==============================================================*/
create table BASE_USER_ROLE (
   ROLEID               INT                  not null,
   TITLE                VARCHAR(50)          null,
   SUMMARY              VARCHAR(200)         null,
   SDATE                DATETIME             null,
   EDATE                DATETIME             null,
   STATUS               INT                  null,
   VERSION              VARCHAR(10)          null,
   constraint PK_BASE_USER_ROLE primary key nonclustered (ROLEID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色信息表',
   'user', @CurrentUser, 'table', 'BASE_USER_ROLE'
go

