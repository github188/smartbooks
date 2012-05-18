-- Start of DDL Script for Table ORAHYD.BASE_ARTICLE_TYPE
-- Generated 18-五月-2012 18:26:25 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_ARTICLE_TYPE
DROP TABLE orahyd.base_article_type CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_article_type
    (id                             NUMBER DEFAULT 0 NOT NULL,
    typename                       VARCHAR2(50) NOT NULL,
    summary                        VARCHAR2(200) NOT NULL,
    status                         NUMBER DEFAULT 0 NOT NULL,
    parent                         NUMBER DEFAULT 0 NOT NULL,
    sort                           NUMBER DEFAULT 0 NOT NULL,
    deptid                         NUMBER DEFAULT 0 NOT NULL)
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





-- Constraints for ORAHYD.BASE_ARTICLE_TYPE

ALTER TABLE orahyd.base_article_type
ADD CONSTRAINT pk_base_article_type PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_ARTICLE_TYPE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_ARTICLE_TYPE
 BEFORE 
 INSERT
 ON BASE_ARTICLE_TYPE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_article_type.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_ARTICLE_TYPE

COMMENT ON TABLE orahyd.base_article_type IS '公文类别表'
/
COMMENT ON COLUMN orahyd.base_article_type.deptid IS '所属部门'
/
COMMENT ON COLUMN orahyd.base_article_type.id IS '主键，自增'
/
COMMENT ON COLUMN orahyd.base_article_type.parent IS '父分类编号：0根节点'
/
COMMENT ON COLUMN orahyd.base_article_type.sort IS '排序'
/
COMMENT ON COLUMN orahyd.base_article_type.status IS '状态：0正常，1删除'
/
COMMENT ON COLUMN orahyd.base_article_type.summary IS '分类描述'
/
COMMENT ON COLUMN orahyd.base_article_type.typename IS '分类名称'
/

-- End of DDL Script for Table ORAHYD.BASE_ARTICLE_TYPE

