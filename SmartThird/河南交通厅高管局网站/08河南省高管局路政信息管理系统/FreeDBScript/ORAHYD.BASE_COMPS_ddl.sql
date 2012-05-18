-- Start of DDL Script for Table ORAHYD.BASE_COMPS
-- Generated 18-五月-2012 18:27:09 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_COMPS
DROP TABLE orahyd.base_comps CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_comps
    (id                             NUMBER NOT NULL,
    compsname                      VARCHAR2(50) NOT NULL,
    unit                           VARCHAR2(10) NOT NULL,
    money                          NUMBER NOT NULL,
    remark                         VARCHAR2(50))
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





-- Constraints for ORAHYD.BASE_COMPS

ALTER TABLE orahyd.base_comps
ADD CONSTRAINT pk_base_comps PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_COMPS

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_COMPS
 BEFORE 
 INSERT
 ON BASE_COMPS
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_COMPS.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_COMPS

COMMENT ON TABLE orahyd.base_comps IS '赔偿标准信息表'
/
COMMENT ON COLUMN orahyd.base_comps.compsname IS '项目名称'
/
COMMENT ON COLUMN orahyd.base_comps.money IS '金额（人民币）'
/
COMMENT ON COLUMN orahyd.base_comps.remark IS '备注'
/
COMMENT ON COLUMN orahyd.base_comps.unit IS '单位'
/

-- End of DDL Script for Table ORAHYD.BASE_COMPS

