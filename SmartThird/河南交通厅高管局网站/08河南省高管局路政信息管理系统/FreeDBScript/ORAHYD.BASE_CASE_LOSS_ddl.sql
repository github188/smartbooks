-- Start of DDL Script for Table ORAHYD.BASE_CASE_LOSS
-- Generated 18-五月-2012 18:27:04 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_CASE_LOSS
DROP TABLE orahyd.base_case_loss CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_case_loss
    (id                             NUMBER NOT NULL,
    compsid                        NUMBER NOT NULL,
    caseid                         NUMBER NOT NULL,
    amount                         NUMBER NOT NULL)
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





-- Constraints for ORAHYD.BASE_CASE_LOSS

ALTER TABLE orahyd.base_case_loss
ADD CONSTRAINT pk_base_case_loss PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_CASE_LOSS

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_CASE_LOSS
 BEFORE 
 INSERT
 ON BASE_CASE_LOSS
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_case_LOSS.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_CASE_LOSS

COMMENT ON TABLE orahyd.base_case_loss IS '路产案件损失表'
/
COMMENT ON COLUMN orahyd.base_case_loss.amount IS '损失单位量'
/
COMMENT ON COLUMN orahyd.base_case_loss.caseid IS '路产案件编号'
/
COMMENT ON COLUMN orahyd.base_case_loss.compsid IS '赔偿项目标准'
/
COMMENT ON COLUMN orahyd.base_case_loss.id IS 'id,primary'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE_LOSS

