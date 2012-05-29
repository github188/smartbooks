-- Start of DDL Script for Table ORAHYD.BASE_AREA_TYPE
-- Generated 29-五月-2012 14:16:46 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_area_type
    (typename                       VARCHAR2(50) NOT NULL,
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





-- Constraints for ORAHYD.BASE_AREA_TYPE

ALTER TABLE orahyd.base_area_type
ADD CONSTRAINT pk_base_area_type PRIMARY KEY (typeid)
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


-- Triggers for ORAHYD.BASE_AREA_TYPE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_AREA_TYPE
 BEFORE 
 INSERT
 ON BASE_AREA_TYPE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_area_type.NEXTVAL
     INTO :NEW.TYPEID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_AREA_TYPE

COMMENT ON TABLE orahyd.base_area_type IS '控制区违章类型表'
/
COMMENT ON COLUMN orahyd.base_area_type.typeid IS 'id,主键，自增'
/
COMMENT ON COLUMN orahyd.base_area_type.typename IS '分类名称'
/

-- End of DDL Script for Table ORAHYD.BASE_AREA_TYPE

