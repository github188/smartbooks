-- Start of DDL Script for Table ORAHYD.BASE_ARTICLE_UNIT
-- Generated 29-五月-2012 14:17:56 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_article_unit
    (id                             NUMBER NOT NULL,
    articleid                      NUMBER NOT NULL,
    dptcode                        NUMBER NOT NULL,
    isread                         NUMBER DEFAULT 0 NOT NULL,
    readtime                       DATE DEFAULT sysdate NOT NULL)
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





-- Constraints for ORAHYD.BASE_ARTICLE_UNIT

ALTER TABLE orahyd.base_article_unit
ADD CONSTRAINT pk_base_article_unit PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_ARTICLE_UNIT

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_ARTICLE_UNIT
 BEFORE 
 INSERT
 ON BASE_ARTICLE_UNIT
 REFERENCING OLD AS OLE NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_article_unit.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_ARTICLE_UNIT

COMMENT ON TABLE orahyd.base_article_unit IS '公文发送单位表'
/
COMMENT ON COLUMN orahyd.base_article_unit.articleid IS '公文编号'
/
COMMENT ON COLUMN orahyd.base_article_unit.dptcode IS '部门编号'
/
COMMENT ON COLUMN orahyd.base_article_unit.id IS '主键,自增'
/
COMMENT ON COLUMN orahyd.base_article_unit.isread IS '查阅状态：0未查阅，1已查阅'
/
COMMENT ON COLUMN orahyd.base_article_unit.readtime IS '查阅时间'
/

-- End of DDL Script for Table ORAHYD.BASE_ARTICLE_UNIT

