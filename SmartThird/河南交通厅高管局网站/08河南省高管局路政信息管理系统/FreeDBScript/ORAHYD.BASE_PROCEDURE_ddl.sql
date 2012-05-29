-- Start of DDL Script for Table ORAHYD.BASE_PROCEDURE
-- Generated 29-����-2012 14:26:12 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_procedure
    (pid                            NUMBER NOT NULL,
    requisitionid                  NUMBER NOT NULL,
    department                     VARCHAR2(50),
    transactor                     VARCHAR2(50),
    contents                       VARCHAR2(50),
    result                         VARCHAR2(50),
    p_date                         DATE,
    p_status                       NUMBER DEFAULT 0)
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





-- Constraints for ORAHYD.BASE_PROCEDURE

ALTER TABLE orahyd.base_procedure
ADD CONSTRAINT pk_base_procedure PRIMARY KEY (pid)
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


-- Triggers for ORAHYD.BASE_PROCEDURE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_PROCEDURE
 BEFORE 
 INSERT
 ON BASE_PROCEDURE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_BASE_PROCEDURE.NEXTVAL
     INTO :NEW.PID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_PROCEDURE

COMMENT ON TABLE orahyd.base_procedure IS '·��������̱�'
/
COMMENT ON COLUMN orahyd.base_procedure.contents IS '�������'
/
COMMENT ON COLUMN orahyd.base_procedure.department IS '����λ(����)'
/
COMMENT ON COLUMN orahyd.base_procedure.p_date IS '����ʱ��'
/
COMMENT ON COLUMN orahyd.base_procedure.p_status IS '״̬(0:������)'
/
COMMENT ON COLUMN orahyd.base_procedure.pid IS '���'
/
COMMENT ON COLUMN orahyd.base_procedure.requisitionid IS '·��������뵥���'
/
COMMENT ON COLUMN orahyd.base_procedure.result IS '������'
/
COMMENT ON COLUMN orahyd.base_procedure.transactor IS '������'
/

-- End of DDL Script for Table ORAHYD.BASE_PROCEDURE

