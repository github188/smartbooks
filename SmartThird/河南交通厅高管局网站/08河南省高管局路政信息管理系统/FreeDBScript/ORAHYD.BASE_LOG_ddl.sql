-- Start of DDL Script for Table ORAHYD.BASE_LOG
-- Generated 29-五月-2012 14:22:52 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_log
    (logid                          NUMBER DEFAULT 0 NOT NULL,
    logtype                        VARCHAR2(50) NOT NULL,
    createdate                     DATE DEFAULT sysdate NOT NULL,
    operatorid                     NUMBER NOT NULL,
    description                    VARCHAR2(200) NOT NULL,
    ipaddress                      VARCHAR2(50) NOT NULL)
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





-- Constraints for ORAHYD.BASE_LOG

ALTER TABLE orahyd.base_log
ADD CONSTRAINT pk_base_log PRIMARY KEY (logid)
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


-- Triggers for ORAHYD.BASE_LOG

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_LOG
 BEFORE 
 INSERT
 ON BASE_LOG
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_log.NEXTVAL
     INTO :NEW.LOGID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_LOG

COMMENT ON TABLE orahyd.base_log IS '系统日志表'
/
COMMENT ON COLUMN orahyd.base_log.createdate IS '日志创建时间'
/
COMMENT ON COLUMN orahyd.base_log.description IS '日志信息描述'
/
COMMENT ON COLUMN orahyd.base_log.ipaddress IS 'Ip地址'
/
COMMENT ON COLUMN orahyd.base_log.logid IS '日志编号'
/
COMMENT ON COLUMN orahyd.base_log.logtype IS '日志类型(操作日志、异常日志)'
/
COMMENT ON COLUMN orahyd.base_log.operatorid IS '操作人'
/

-- End of DDL Script for Table ORAHYD.BASE_LOG

