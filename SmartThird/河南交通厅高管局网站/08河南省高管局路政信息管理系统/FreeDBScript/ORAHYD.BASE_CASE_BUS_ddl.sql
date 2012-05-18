-- Start of DDL Script for Table ORAHYD.BASE_CASE_BUS
-- Generated 18-����-2012 18:26:54 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_CASE_BUS
DROP TABLE orahyd.base_case_bus CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_case_bus
    (id                             NUMBER NOT NULL,
    party                          VARCHAR2(50) NOT NULL,
    sex                            NUMBER DEFAULT 0 NOT NULL,
    age                            NUMBER NOT NULL,
    phone                          VARCHAR2(51) NOT NULL,
    driving                        NUMBER NOT NULL,
    cardid                         VARCHAR2(16) NOT NULL,
    bustype                        VARCHAR2(20) NOT NULL,
    busnumber                      VARCHAR2(20) NOT NULL,
    label                          VARCHAR2(20),
    pattern                        VARCHAR2(20) NOT NULL,
    address                        VARCHAR2(80) NOT NULL,
    zipcode                        VARCHAR2(10) NOT NULL,
    attrib                         VARCHAR2(10) NOT NULL,
    caseid                         NUMBER NOT NULL)
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





-- Constraints for ORAHYD.BASE_CASE_BUS

ALTER TABLE orahyd.base_case_bus
ADD CONSTRAINT pk_base_case_bus PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_CASE_BUS

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_CASE_BUS
 BEFORE 
 INSERT
 ON BASE_CASE_BUS
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_case_bus.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_CASE_BUS

COMMENT ON TABLE orahyd.base_case_bus IS '·��������������Ա��Ϣ��'
/
COMMENT ON COLUMN orahyd.base_case_bus.address IS '������λ���ַ'
/
COMMENT ON COLUMN orahyd.base_case_bus.age IS '����'
/
COMMENT ON COLUMN orahyd.base_case_bus.attrib IS '������'
/
COMMENT ON COLUMN orahyd.base_case_bus.busnumber IS '���ƺ���'
/
COMMENT ON COLUMN orahyd.base_case_bus.bustype IS '��������'
/
COMMENT ON COLUMN orahyd.base_case_bus.cardid IS '֤������'
/
COMMENT ON COLUMN orahyd.base_case_bus.caseid IS '�������'
/
COMMENT ON COLUMN orahyd.base_case_bus.driving IS '����'
/
COMMENT ON COLUMN orahyd.base_case_bus.id IS 'ID���'
/
COMMENT ON COLUMN orahyd.base_case_bus.label IS '����'
/
COMMENT ON COLUMN orahyd.base_case_bus.party IS '������'
/
COMMENT ON COLUMN orahyd.base_case_bus.pattern IS '�ͺ�'
/
COMMENT ON COLUMN orahyd.base_case_bus.phone IS '��ϵ�绰'
/
COMMENT ON COLUMN orahyd.base_case_bus.sex IS '�Ա�0���� 1��Ů��'
/
COMMENT ON COLUMN orahyd.base_case_bus.zipcode IS '�ʱ�'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE_BUS

