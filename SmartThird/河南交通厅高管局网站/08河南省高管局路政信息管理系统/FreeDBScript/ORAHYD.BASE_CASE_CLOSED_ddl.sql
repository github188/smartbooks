-- Start of DDL Script for Table ORAHYD.BASE_CASE_CLOSED
-- Generated 29-五月-2012 14:19:57 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_case_closed
    (id                             NUMBER NOT NULL,
    motiontime                     DATE DEFAULT SYSDATE NOT NULL,
    motionlocation                 DATE NOT NULL,
    motionpro                      VARCHAR2(50) NOT NULL,
    record                         VARCHAR2(50) NOT NULL,
    discuss                        VARCHAR2(500) NOT NULL,
    lead                           VARCHAR2(500) NOT NULL,
    closedtime                     DATE DEFAULT SYSDATE NOT NULL,
    recoverloss                    NUMBER DEFAULT 0 NOT NULL,
    closedeay                      VARCHAR2(500) NOT NULL,
    result                         VARCHAR2(500) NOT NULL,
    remark                         VARCHAR2(500),
    caseid                         NUMBER NOT NULL)
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





-- Constraints for ORAHYD.BASE_CASE_CLOSED

ALTER TABLE orahyd.base_case_closed
ADD CONSTRAINT pk_base_case_closed PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_CASE_CLOSED

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_CASE_CLOSED
 BEFORE 
 INSERT
 ON BASE_CASE_CLOSED
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_case_closed.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_CASE_CLOSED

COMMENT ON TABLE orahyd.base_case_closed IS '路产案件（议案结案表）'
/
COMMENT ON COLUMN orahyd.base_case_closed.caseid IS '案件编号'
/
COMMENT ON COLUMN orahyd.base_case_closed.closedeay IS '结案方式'
/
COMMENT ON COLUMN orahyd.base_case_closed.closedtime IS '结案日期'
/
COMMENT ON COLUMN orahyd.base_case_closed.discuss IS '讨论意见'
/
COMMENT ON COLUMN orahyd.base_case_closed.lead IS '主管领导意见'
/
COMMENT ON COLUMN orahyd.base_case_closed.motionlocation IS '议案地点'
/
COMMENT ON COLUMN orahyd.base_case_closed.motionpro IS '主持人'
/
COMMENT ON COLUMN orahyd.base_case_closed.motiontime IS '议案时间'
/
COMMENT ON COLUMN orahyd.base_case_closed.record IS '议案记录人'
/
COMMENT ON COLUMN orahyd.base_case_closed.recoverloss IS '追回损失'
/
COMMENT ON COLUMN orahyd.base_case_closed.remark IS '备注'
/
COMMENT ON COLUMN orahyd.base_case_closed.result IS '处理结果'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE_CLOSED

