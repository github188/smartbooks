-- Start of DDL Script for Table ORAHYD.BASE_LICENSE_ACCEPT
-- Generated 18-����-2012 18:27:33 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_LICENSE_ACCEPT
DROP TABLE orahyd.base_license_accept CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_license_accept
    (requisitionid                  NUMBER NOT NULL,
    requisitionname                VARCHAR2(50) NOT NULL,
    address                        VARCHAR2(50),
    tel                            VARCHAR2(50),
    phone                          VARCHAR2(50),
    email                          VARCHAR2(50),
    post                           VARCHAR2(20),
    requisitioncontent             VARCHAR2(200),
    deputy                         VARCHAR2(20),
    materials                      VARCHAR2(20),
    mark                           VARCHAR2(20),
    creatdate                      DATE,
    auditor                        VARCHAR2(20),
    audit_state                    NUMBER DEFAULT 0,
    file_path                      VARCHAR2(50),
    audit_desc                     VARCHAR2(200),
    audit_reply                    VARCHAR2(200))
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





-- Constraints for ORAHYD.BASE_LICENSE_ACCEPT

ALTER TABLE orahyd.base_license_accept
ADD CONSTRAINT pk_base_license_accept PRIMARY KEY (requisitionid)
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


-- Triggers for ORAHYD.BASE_LICENSE_ACCEPT

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_LICENSE_ACCEPT
 BEFORE 
 INSERT
 ON BASE_LICENSE_ACCEPT
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_BASE_LICENSE_ACCEPT.NEXTVAL
     INTO :NEW.REQUISITIONID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_LICENSE_ACCEPT

COMMENT ON TABLE orahyd.base_license_accept IS '·����������'
/
COMMENT ON COLUMN orahyd.base_license_accept.address IS '������סַ'
/
COMMENT ON COLUMN orahyd.base_license_accept.audit_desc IS '������'
/
COMMENT ON COLUMN orahyd.base_license_accept.audit_reply IS '����ظ�'
/
COMMENT ON COLUMN orahyd.base_license_accept.audit_state IS '���״̬(0:δ��ˣ�)'
/
COMMENT ON COLUMN orahyd.base_license_accept.auditor IS '�����'
/
COMMENT ON COLUMN orahyd.base_license_accept.creatdate IS '��������'
/
COMMENT ON COLUMN orahyd.base_license_accept.deputy IS 'ί�д�����'
/
COMMENT ON COLUMN orahyd.base_license_accept.email IS '����'
/
COMMENT ON COLUMN orahyd.base_license_accept.file_path IS '����·��'
/
COMMENT ON COLUMN orahyd.base_license_accept.mark IS '��ע'
/
COMMENT ON COLUMN orahyd.base_license_accept.materials IS '�������Ŀ¼'
/
COMMENT ON COLUMN orahyd.base_license_accept.phone IS '�ֻ�'
/
COMMENT ON COLUMN orahyd.base_license_accept.post IS '�ʱ�'
/
COMMENT ON COLUMN orahyd.base_license_accept.requisitioncontent IS '��������������'
/
COMMENT ON COLUMN orahyd.base_license_accept.requisitionid IS '��������'
/
COMMENT ON COLUMN orahyd.base_license_accept.requisitionname IS '�����˼���������������'
/
COMMENT ON COLUMN orahyd.base_license_accept.tel IS '�绰'
/

-- End of DDL Script for Table ORAHYD.BASE_LICENSE_ACCEPT

