-- Start of DDL Script for Table ORAHYD.BASE_ARTICLE
-- Generated 29-五月-2012 14:17:07 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_article
    (id                             NUMBER NOT NULL,
    userid                         NUMBER NOT NULL,
    deptid                         NUMBER NOT NULL,
    parentid                       NUMBER DEFAULT 0 NOT NULL,
    title                          VARCHAR2(200) NOT NULL,
    content                        VARCHAR2(4000) NOT NULL,
    timestamp                      DATE DEFAULT sysdate NOT NULL,
    score                          NUMBER DEFAULT 0 NOT NULL,
    annex                          VARCHAR2(200) NOT NULL,
    status                         NUMBER DEFAULT 0 NOT NULL,
    isreply                        NUMBER DEFAULT 0 NOT NULL,
    typeid                         NUMBER NOT NULL,
    sendcode                       VARCHAR2(80) NOT NULL)
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





-- Constraints for ORAHYD.BASE_ARTICLE

ALTER TABLE orahyd.base_article
ADD CONSTRAINT pk_base_article PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_ARTICLE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_ARTICLE
 BEFORE 
 INSERT
 ON BASE_ARTICLE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_article.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_ARTICLE

COMMENT ON TABLE orahyd.base_article IS '公文信息表'
/
COMMENT ON COLUMN orahyd.base_article.annex IS '附件(服务器相对路径)'
/
COMMENT ON COLUMN orahyd.base_article.content IS '公文内容'
/
COMMENT ON COLUMN orahyd.base_article.deptid IS '部门编号'
/
COMMENT ON COLUMN orahyd.base_article.id IS '主键,自增'
/
COMMENT ON COLUMN orahyd.base_article.isreply IS '允许回复：0允许回复,1不允许回复'
/
COMMENT ON COLUMN orahyd.base_article.parentid IS '0父发文编号，1回复发文编号'
/
COMMENT ON COLUMN orahyd.base_article.score IS '分值'
/
COMMENT ON COLUMN orahyd.base_article.sendcode IS '发文字号,回文指发文字号'
/
COMMENT ON COLUMN orahyd.base_article.status IS '状态：0已审核，1未审核，2草稿，3已删除，4隐藏，5结贴'
/
COMMENT ON COLUMN orahyd.base_article.timestamp IS '时间戳'
/
COMMENT ON COLUMN orahyd.base_article.title IS '公文标题'
/
COMMENT ON COLUMN orahyd.base_article.typeid IS '公文所属分类编号'
/
COMMENT ON COLUMN orahyd.base_article.userid IS '用户编号'
/

-- End of DDL Script for Table ORAHYD.BASE_ARTICLE

