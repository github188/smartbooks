-- Start of DDL Script for Table ORAHYD.BASE_USER
-- Generated 18-五月-2012 18:29:27 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_USER
DROP TABLE orahyd.base_user CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_user
    (userid                         NUMBER DEFAULT 0 NOT NULL,
    username                       VARCHAR2(50) NOT NULL,
    userpwd                        VARCHAR2(32) NOT NULL,
    parentid                       NUMBER DEFAULT 0 NOT NULL,
    sex                            NUMBER DEFAULT 0 NOT NULL,
    deptid                         NUMBER DEFAULT 0 NOT NULL,
    birthday                       DATE DEFAULT SYSDATE NOT NULL,
    degree                         VARCHAR2(50) NOT NULL,
    face                           VARCHAR2(50) NOT NULL,
    idnumber                       VARCHAR2(18) NOT NULL,
    jobnumber                      VARCHAR2(50) NOT NULL,
    photo                          VARCHAR2(200) NOT NULL,
    prof                           VARCHAR2(50) NOT NULL,
    remark                         VARCHAR2(50) DEFAULT '无',
    ststus                         NUMBER DEFAULT 0 NOT NULL,
    phone                          VARCHAR2(50) NOT NULL)
  PCTFREE     10
  INITRANS    1
  MAXTRANS    255
  TABLESPACE  users
  STORAGE   (
    INITIAL     65536
    MINEXTENTS  1
    MAXEXTENTS  2147483645
  )
/





-- Constraints for ORAHYD.BASE_USER

ALTER TABLE orahyd.base_user
ADD CONSTRAINT pk_base_user PRIMARY KEY (userid)
USING INDEX
  PCTFREE     10
  INITRANS    2
  MAXTRANS    255
  TABLESPACE  users
  STORAGE   (
    INITIAL     65536
    MINEXTENTS  1
    MAXEXTENTS  2147483645
  )
/


-- Triggers for ORAHYD.BASE_USER

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_USER
 BEFORE 
 INSERT
 ON BASE_USER
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_USER.NEXTVAL
     INTO :NEW.USERID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_USER

COMMENT ON TABLE orahyd.base_user IS '用户信息表'
/
COMMENT ON COLUMN orahyd.base_user.birthday IS '出生年月'
/
COMMENT ON COLUMN orahyd.base_user.degree IS '学历'
/
COMMENT ON COLUMN orahyd.base_user.deptid IS '用户所属部门'
/
COMMENT ON COLUMN orahyd.base_user.face IS '政治面貌'
/
COMMENT ON COLUMN orahyd.base_user.idnumber IS '身份证号码'
/
COMMENT ON COLUMN orahyd.base_user.jobnumber IS '工作证号'
/
COMMENT ON COLUMN orahyd.base_user.parentid IS '用户父ID编号（用于多个子账户）'
/
COMMENT ON COLUMN orahyd.base_user.phone IS '联系电话'
/
COMMENT ON COLUMN orahyd.base_user.photo IS '人员照片'
/
COMMENT ON COLUMN orahyd.base_user.prof IS '专业'
/
COMMENT ON COLUMN orahyd.base_user.remark IS '备注'
/
COMMENT ON COLUMN orahyd.base_user.sex IS '性别（0：男 1：女）'
/
COMMENT ON COLUMN orahyd.base_user.ststus IS '状态（0：正常，1：删除）'
/
COMMENT ON COLUMN orahyd.base_user.userid IS '用户ID编号'
/
COMMENT ON COLUMN orahyd.base_user.username IS '用户账号（登录使用）'
/
COMMENT ON COLUMN orahyd.base_user.userpwd IS '用户密码（登录使用）'
/

-- End of DDL Script for Table ORAHYD.BASE_USER

