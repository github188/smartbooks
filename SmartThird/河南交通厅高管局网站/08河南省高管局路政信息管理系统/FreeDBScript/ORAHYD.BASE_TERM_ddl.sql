-- Start of DDL Script for Table ORAHYD.BASE_TERM
-- Generated 29-����-2012 14:29:06 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_term
    (termid                         NUMBER NOT NULL,
    deptid                         NUMBER NOT NULL,
    termcode                       VARCHAR2(50) NOT NULL,
    termname                       VARCHAR2(50) NOT NULL,
    serialcode                     VARCHAR2(50) NOT NULL,
    format                         VARCHAR2(50) NOT NULL,
    brand                          VARCHAR2(50) NOT NULL,
    use                            VARCHAR2(50) NOT NULL,
    usetime                        DATE DEFAULT SYSDATE NOT NULL,
    savepoint                      VARCHAR2(50) NOT NULL,
    remark                         VARCHAR2(50) NOT NULL,
    status                         NUMBER DEFAULT 0 NOT NULL,
    typeid                         NUMBER NOT NULL)
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





-- Constraints for ORAHYD.BASE_TERM

ALTER TABLE orahyd.base_term
ADD CONSTRAINT pk_base_term PRIMARY KEY (termid)
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


-- Triggers for ORAHYD.BASE_TERM

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_TERM
 BEFORE 
 INSERT
 ON BASE_TERM
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_TERM.NEXTVAL
     INTO :NEW.TERMID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_TERM

COMMENT ON TABLE orahyd.base_term IS 'װ����Ϣ��'
/
COMMENT ON COLUMN orahyd.base_term.brand IS '���쳧��'
/
COMMENT ON COLUMN orahyd.base_term.deptid IS '��������'
/
COMMENT ON COLUMN orahyd.base_term.format IS '����ͺ�'
/
COMMENT ON COLUMN orahyd.base_term.remark IS '��ע'
/
COMMENT ON COLUMN orahyd.base_term.savepoint IS '��ŵص�'
/
COMMENT ON COLUMN orahyd.base_term.serialcode IS '�������'
/
COMMENT ON COLUMN orahyd.base_term.status IS '״̬��0��������1��ɾ����'
/
COMMENT ON COLUMN orahyd.base_term.termcode IS '�豸���'
/
COMMENT ON COLUMN orahyd.base_term.termid IS '���'
/
COMMENT ON COLUMN orahyd.base_term.termname IS '�豸����'
/
COMMENT ON COLUMN orahyd.base_term.typeid IS 'װ������'
/
COMMENT ON COLUMN orahyd.base_term.use IS 'װ����;'
/
COMMENT ON COLUMN orahyd.base_term.usetime IS 'Ͷ��ʹ��ʱ��'
/

-- End of DDL Script for Table ORAHYD.BASE_TERM

