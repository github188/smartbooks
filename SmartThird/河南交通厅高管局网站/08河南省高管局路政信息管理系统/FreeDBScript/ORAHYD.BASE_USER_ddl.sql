-- Start of DDL Script for Table ORAHYD.BASE_USER
-- Generated 2012-6-15 ���� 07:03:17 from ORAHYD@ORAHYD

CREATE TABLE base_user
    (userid                         NUMBER DEFAULT 0 NOT NULL,
    username                       VARCHAR2(50) NOT NULL,
    userpwd                        VARCHAR2(32) NOT NULL,
    parentid                       NUMBER DEFAULT 0,
    sex                            NUMBER DEFAULT 0,
    deptid                         NUMBER DEFAULT 0 NOT NULL,
    birthday                       DATE DEFAULT SYSDATE,
    degree                         VARCHAR2(50),
    face                           VARCHAR2(50),
    idnumber                       VARCHAR2(18),
    jobnumber                      VARCHAR2(50),
    photo                          VARCHAR2(200),
    prof                           VARCHAR2(50),
    remark                         VARCHAR2(50) DEFAULT '��',
    ststus                         NUMBER DEFAULT 0 NOT NULL,
    phone                          VARCHAR2(50) NOT NULL,
    realname                       VARCHAR2(50) NOT NULL,
    isline                         NUMBER DEFAULT 0)
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





-- Constraints for BASE_USER

ALTER TABLE base_user
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


-- Triggers for BASE_USER

CREATE OR REPLACE TRIGGER trg_base_user
 BEFORE
  INSERT
 ON base_user
REFERENCING NEW AS NEW OLD AS OLD
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


-- Comments for BASE_USER

COMMENT ON TABLE base_user IS '�û���Ϣ��'
/
COMMENT ON COLUMN base_user.birthday IS '��������'
/
COMMENT ON COLUMN base_user.degree IS 'ѧ��'
/
COMMENT ON COLUMN base_user.deptid IS '�û���������'
/
COMMENT ON COLUMN base_user.face IS '������ò'
/
COMMENT ON COLUMN base_user.idnumber IS '���֤����'
/
COMMENT ON COLUMN base_user.isline IS '�Ƿ����ߣ�0�����ߣ�1�����ߣ�'
/
COMMENT ON COLUMN base_user.jobnumber IS '����֤��'
/
COMMENT ON COLUMN base_user.parentid IS '�û���ID��ţ����ڶ�����˻���'
/
COMMENT ON COLUMN base_user.phone IS '��ϵ�绰'
/
COMMENT ON COLUMN base_user.photo IS '��Ա��Ƭ'
/
COMMENT ON COLUMN base_user.prof IS 'רҵ'
/
COMMENT ON COLUMN base_user.realname IS '��ʵ����'
/
COMMENT ON COLUMN base_user.remark IS '��ע'
/
COMMENT ON COLUMN base_user.sex IS '�Ա�0���� 1��Ů��'
/
COMMENT ON COLUMN base_user.ststus IS '״̬��0��������1��ɾ����'
/
COMMENT ON COLUMN base_user.userid IS '�û�ID���'
/
COMMENT ON COLUMN base_user.username IS '�û��˺ţ���¼ʹ�ã�'
/
COMMENT ON COLUMN base_user.userpwd IS '�û����루��¼ʹ�ã�'
/

-- End of DDL Script for Table ORAHYD.BASE_USER

