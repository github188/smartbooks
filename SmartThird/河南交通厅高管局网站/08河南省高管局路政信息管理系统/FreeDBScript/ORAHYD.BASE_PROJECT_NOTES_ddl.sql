-- Start of DDL Script for Table ORAHYD.BASE_PROJECT_NOTES
-- Generated 29-五月-2012 14:26:31 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_project_notes
    (pid                            NUMBER NOT NULL,
    assessid                       NUMBER NOT NULL,
    reply_content                  VARCHAR2(200),
    reply_preson                   VARCHAR2(50),
    reply_date                     DATE,
    score                          NUMBER)
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





-- Constraints for ORAHYD.BASE_PROJECT_NOTES

ALTER TABLE orahyd.base_project_notes
ADD CONSTRAINT pk_base_project_notes PRIMARY KEY (pid)
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


-- Triggers for ORAHYD.BASE_PROJECT_NOTES

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_PROJECT_NOTES
 BEFORE 
 INSERT
 ON BASE_PROJECT_NOTES
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_project_notes.NEXTVAL
     INTO :NEW.PID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_PROJECT_NOTES

COMMENT ON TABLE orahyd.base_project_notes IS '考核项目记录表'
/
COMMENT ON COLUMN orahyd.base_project_notes.assessid IS '考核信息编号'
/
COMMENT ON COLUMN orahyd.base_project_notes.pid IS '编号'
/
COMMENT ON COLUMN orahyd.base_project_notes.reply_content IS '考核批复内容'
/
COMMENT ON COLUMN orahyd.base_project_notes.reply_date IS '批复时间'
/
COMMENT ON COLUMN orahyd.base_project_notes.reply_preson IS '批复人'
/
COMMENT ON COLUMN orahyd.base_project_notes.score IS '分值'
/

-- End of DDL Script for Table ORAHYD.BASE_PROJECT_NOTES

