-- Start of DDL Script for Table ORAHYD.BASE_SHOUWEN
-- Generated 29-五月-2012 14:28:50 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_shouwen
    (sid                            NUMBER NOT NULL,
    s_numbers                      VARCHAR2(50) NOT NULL,
    s_organ                        VARCHAR2(50) NOT NULL,
    s_fromdate                     DATE,
    s_title                        VARCHAR2(50) NOT NULL,
    s_handlingtime                 DATE,
    s_dep_organ                    VARCHAR2(50),
    s_handleprogress               VARCHAR2(50),
    s_result                       VARCHAR2(200),
    s_applicant                    VARCHAR2(50),
    s_handler                      VARCHAR2(50),
    remarks                        VARCHAR2(200))
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





-- Constraints for ORAHYD.BASE_SHOUWEN

ALTER TABLE orahyd.base_shouwen
ADD CONSTRAINT pk_base_shouwen PRIMARY KEY (sid)
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


-- Triggers for ORAHYD.BASE_SHOUWEN

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_SHOUWEN
 BEFORE 
 INSERT
 ON BASE_SHOUWEN
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_shouwen.NEXTVAL
     INTO :NEW.SID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_SHOUWEN

COMMENT ON TABLE orahyd.base_shouwen IS '收文信息表'
/
COMMENT ON COLUMN orahyd.base_shouwen.remarks IS '备注'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_applicant IS '申请人'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_dep_organ IS '涉及相关运营管理单位'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_fromdate IS '来文时间'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_handleprogress IS '办理进度'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_handler IS '相关单位承办人'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_handlingtime IS '承办时间'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_numbers IS '原号'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_organ IS '来文机关'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_result IS '办理结果'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_title IS '标题'
/
COMMENT ON COLUMN orahyd.base_shouwen.sid IS '收文信息 编号'
/

-- End of DDL Script for Table ORAHYD.BASE_SHOUWEN

