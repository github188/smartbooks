-- Start of DDL Script for Table ORAHYD.BASE_FILETYPE
-- Generated 18-五月-2012 18:27:28 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_FILETYPE
DROP TABLE orahyd.base_filetype CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_filetype
    (ftid                           NUMBER NOT NULL,
    ft_name                        VARCHAR2(50) NOT NULL,
    ft_describe                    VARCHAR2(50) NOT NULL,
    ft_dept                        VARCHAR2(50) NOT NULL,
    ft_prefix                      VARCHAR2(50) NOT NULL,
    ft_suffix                      VARCHAR2(50) NOT NULL,
    ft_state                       NUMBER DEFAULT 0 NOT NULL)
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





-- Constraints for ORAHYD.BASE_FILETYPE

ALTER TABLE orahyd.base_filetype
ADD CONSTRAINT pk_base_filetype PRIMARY KEY (ftid)
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


-- Triggers for ORAHYD.BASE_FILETYPE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_FILETYPE
 BEFORE 
 INSERT
 ON BASE_FILETYPE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_BASE_FILETYPE.NEXTVAL
     INTO :NEW.FTID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_FILETYPE

COMMENT ON TABLE orahyd.base_filetype IS '公文类型表'
/
COMMENT ON COLUMN orahyd.base_filetype.ft_dept IS '所属分类'
/
COMMENT ON COLUMN orahyd.base_filetype.ft_describe IS '公文类型说明'
/
COMMENT ON COLUMN orahyd.base_filetype.ft_name IS '公文类型名称'
/
COMMENT ON COLUMN orahyd.base_filetype.ft_prefix IS '默认文号前缀'
/
COMMENT ON COLUMN orahyd.base_filetype.ft_state IS '状态(0正常；1已删除)'
/
COMMENT ON COLUMN orahyd.base_filetype.ft_suffix IS '默认文号后缀'
/
COMMENT ON COLUMN orahyd.base_filetype.ftid IS '编号'
/

-- End of DDL Script for Table ORAHYD.BASE_FILETYPE

