-- Start of DDL Script for Table ORAHYD.BASE_TERM_TYPE
-- Generated 18-五月-2012 18:29:22 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_TERM_TYPE
DROP TABLE orahyd.base_term_type CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_term_type
    (typeid                         NUMBER NOT NULL,
    typename                       VARCHAR2(50) NOT NULL)
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





-- Constraints for ORAHYD.BASE_TERM_TYPE

ALTER TABLE orahyd.base_term_type
ADD CONSTRAINT pk_base_term_type PRIMARY KEY (typeid)
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


-- Triggers for ORAHYD.BASE_TERM_TYPE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_TERM_TYPE
 BEFORE 
 INSERT
 ON BASE_TERM_TYPE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_TERM_TYPE.NEXTVAL
     INTO :NEW.TYPEID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_TERM_TYPE

COMMENT ON TABLE orahyd.base_term_type IS '装备类型表'
/
COMMENT ON COLUMN orahyd.base_term_type.typeid IS '装备类型编号'
/
COMMENT ON COLUMN orahyd.base_term_type.typename IS '装备类型名称'
/

-- End of DDL Script for Table ORAHYD.BASE_TERM_TYPE

