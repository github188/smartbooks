-- Start of DDL Script for Table ORAHYD.BASE_USER_ROLE
-- Generated 29-����-2012 14:30:09 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_user_role
    (userroleid                     NUMBER DEFAULT 0 NOT NULL,
    userid                         NUMBER DEFAULT 0 NOT NULL,
    roleid                         NUMBER DEFAULT 0 NOT NULL,
    menuid                         NUMBER DEFAULT 0 NOT NULL,
    actionid                       NUMBER DEFAULT 0 NOT NULL)
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





-- Constraints for ORAHYD.BASE_USER_ROLE

ALTER TABLE orahyd.base_user_role
ADD CONSTRAINT pk_base_user_role PRIMARY KEY (userroleid)
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


-- Triggers for ORAHYD.BASE_USER_ROLE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_USER_ROLE
 BEFORE 
 INSERT
 ON BASE_USER_ROLE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_USER_ROLE.NEXTVAL
     INTO :NEW.USERROLEID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_USER_ROLE

COMMENT ON TABLE orahyd.base_user_role IS '�û���ɫ��Ϣ��'
/
COMMENT ON COLUMN orahyd.base_user_role.actionid IS '�û�ģ�����Ȩ��'
/
COMMENT ON COLUMN orahyd.base_user_role.menuid IS '�˵����'
/
COMMENT ON COLUMN orahyd.base_user_role.roleid IS '��ɫ���'
/
COMMENT ON COLUMN orahyd.base_user_role.userid IS '�û����'
/
COMMENT ON COLUMN orahyd.base_user_role.userroleid IS '�û���ɫ���'
/

-- End of DDL Script for Table ORAHYD.BASE_USER_ROLE

