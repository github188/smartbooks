-- Start of DDL Script for Table ORAHYD.BASE_FAWEN
-- Generated 18-五月-2012 18:27:19 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_FAWEN
DROP TABLE orahyd.base_fawen CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_fawen
    (fid                            NUMBER NOT NULL,
    f_number                       VARCHAR2(50) NOT NULL,
    f_title                        VARCHAR2(50) NOT NULL,
    f_type                         VARCHAR2(50) NOT NULL,
    f_content                      VARCHAR2(800),
    f_annex                        VARCHAR2(100),
    f_date                         DATE,
    remark                         VARCHAR2(500),
    f_organ                        VARCHAR2(50),
    f_level                        VARCHAR2(50),
    f_degree                       VARCHAR2(50),
    f_delstate                     NUMBER DEFAULT 0 NOT NULL)
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





-- Constraints for ORAHYD.BASE_FAWEN

ALTER TABLE orahyd.base_fawen
ADD CONSTRAINT pk_base_fawen PRIMARY KEY (fid)
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


-- Triggers for ORAHYD.BASE_FAWEN

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_FAWEN
 BEFORE 
 INSERT
 ON BASE_FAWEN
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_Fawen.NEXTVAL
     INTO :NEW.Fid
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_FAWEN

COMMENT ON TABLE orahyd.base_fawen IS '发文信息表'
/
COMMENT ON COLUMN orahyd.base_fawen.f_annex IS '公文附件路径'
/
COMMENT ON COLUMN orahyd.base_fawen.f_content IS '公文内容'
/
COMMENT ON COLUMN orahyd.base_fawen.f_date IS '发文日期'
/
COMMENT ON COLUMN orahyd.base_fawen.f_degree IS '缓急程度'
/
COMMENT ON COLUMN orahyd.base_fawen.f_delstate IS '状态(0:已保存；1：已发送；2：已删除)'
/
COMMENT ON COLUMN orahyd.base_fawen.f_level IS '密级'
/
COMMENT ON COLUMN orahyd.base_fawen.f_number IS '公文号'
/
COMMENT ON COLUMN orahyd.base_fawen.f_organ IS '发文单位部门'
/
COMMENT ON COLUMN orahyd.base_fawen.f_title IS '公文标题'
/
COMMENT ON COLUMN orahyd.base_fawen.f_type IS '公文类型'
/
COMMENT ON COLUMN orahyd.base_fawen.fid IS '编号'
/
COMMENT ON COLUMN orahyd.base_fawen.remark IS '备注'
/

-- End of DDL Script for Table ORAHYD.BASE_FAWEN

