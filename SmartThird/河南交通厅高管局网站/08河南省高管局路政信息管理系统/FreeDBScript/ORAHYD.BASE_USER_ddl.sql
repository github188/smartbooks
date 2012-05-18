-- Start of DDL Script for Table ORAHYD.BASE_USER
-- Generated 18-����-2012 18:29:27 from ORAHYD@ORAHYD

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
    remark                         VARCHAR2(50) DEFAULT '��',
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

COMMENT ON TABLE orahyd.base_user IS '�û���Ϣ��'
/
COMMENT ON COLUMN orahyd.base_user.birthday IS '��������'
/
COMMENT ON COLUMN orahyd.base_user.degree IS 'ѧ��'
/
COMMENT ON COLUMN orahyd.base_user.deptid IS '�û���������'
/
COMMENT ON COLUMN orahyd.base_user.face IS '������ò'
/
COMMENT ON COLUMN orahyd.base_user.idnumber IS '���֤����'
/
COMMENT ON COLUMN orahyd.base_user.jobnumber IS '����֤��'
/
COMMENT ON COLUMN orahyd.base_user.parentid IS '�û���ID��ţ����ڶ�����˻���'
/
COMMENT ON COLUMN orahyd.base_user.phone IS '��ϵ�绰'
/
COMMENT ON COLUMN orahyd.base_user.photo IS '��Ա��Ƭ'
/
COMMENT ON COLUMN orahyd.base_user.prof IS 'רҵ'
/
COMMENT ON COLUMN orahyd.base_user.remark IS '��ע'
/
COMMENT ON COLUMN orahyd.base_user.sex IS '�Ա�0���� 1��Ů��'
/
COMMENT ON COLUMN orahyd.base_user.ststus IS '״̬��0��������1��ɾ����'
/
COMMENT ON COLUMN orahyd.base_user.userid IS '�û�ID���'
/
COMMENT ON COLUMN orahyd.base_user.username IS '�û��˺ţ���¼ʹ�ã�'
/
COMMENT ON COLUMN orahyd.base_user.userpwd IS '�û����루��¼ʹ�ã�'
/

-- End of DDL Script for Table ORAHYD.BASE_USER

