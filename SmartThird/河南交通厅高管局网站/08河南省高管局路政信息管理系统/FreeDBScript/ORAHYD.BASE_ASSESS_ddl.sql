-- Start of DDL Script for Table ORAHYD.BASE_ASSESS
-- Generated 29-五月-2012 14:18:15 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_assess
    (assessid                       NUMBER NOT NULL,
    assessname                     VARCHAR2(50) NOT NULL,
    assessdept                     VARCHAR2(20),
    assessresult                   NUMBER,
    assessdescription              VARCHAR2(200),
    assesscriterion                VARCHAR2(100),
    assessformat                   VARCHAR2(100),
    assesscontent                  VARCHAR2(100),
    assesstime                     VARCHAR2(50))
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





-- Constraints for ORAHYD.BASE_ASSESS

ALTER TABLE orahyd.base_assess
ADD CONSTRAINT pk_base_assess PRIMARY KEY (assessid)
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


-- Triggers for ORAHYD.BASE_ASSESS

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_ASSESS
 BEFORE 
 INSERT
 ON BASE_ASSESS
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_assess.NEXTVAL
     INTO :NEW.ASSESSID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_ASSESS

COMMENT ON TABLE orahyd.base_assess IS '考核信息表'
/
COMMENT ON COLUMN orahyd.base_assess.assesscontent IS '目标内容'
/
COMMENT ON COLUMN orahyd.base_assess.assesscriterion IS '考核标准'
/
COMMENT ON COLUMN orahyd.base_assess.assessdept IS '考核项目所属单位'
/
COMMENT ON COLUMN orahyd.base_assess.assessdescription IS '考核信息备注'
/
COMMENT ON COLUMN orahyd.base_assess.assessformat IS '考核形式'
/
COMMENT ON COLUMN orahyd.base_assess.assessid IS '考核信息编号'
/
COMMENT ON COLUMN orahyd.base_assess.assessname IS '考核项目名称'
/
COMMENT ON COLUMN orahyd.base_assess.assessresult IS '考核分值'
/
COMMENT ON COLUMN orahyd.base_assess.assesstime IS '上报时间'
/

-- End of DDL Script for Table ORAHYD.BASE_ASSESS

