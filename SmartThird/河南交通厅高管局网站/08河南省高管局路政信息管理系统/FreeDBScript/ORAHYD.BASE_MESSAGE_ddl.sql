-- Start of DDL Script for Table ORAHYD.BASE_MESSAGE
-- Generated 29-五月-2012 14:23:44 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_message
    (messageid                      NUMBER NOT NULL,
    sender                         NUMBER NOT NULL,
    touser                         NUMBER NOT NULL,
    messagebody                    VARCHAR2(200) NOT NULL,
    senddate                       DATE DEFAULT sysdate NOT NULL,
    state                          NUMBER DEFAULT 0 NOT NULL)
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





-- Constraints for ORAHYD.BASE_MESSAGE

ALTER TABLE orahyd.base_message
ADD CONSTRAINT pk_base_message PRIMARY KEY (messageid)
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


-- Triggers for ORAHYD.BASE_MESSAGE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_MESSAGE
 BEFORE 
 INSERT
 ON BASE_MESSAGE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_MESSAGE.NEXTVAL
     INTO :NEW.MESSAGEID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_MESSAGE

COMMENT ON TABLE orahyd.base_message IS '消息记录信息表'
/
COMMENT ON COLUMN orahyd.base_message.messagebody IS '消息内容'
/
COMMENT ON COLUMN orahyd.base_message.messageid IS '主键，自动增长'
/
COMMENT ON COLUMN orahyd.base_message.senddate IS '发送时间'
/
COMMENT ON COLUMN orahyd.base_message.sender IS '发送者编号'
/
COMMENT ON COLUMN orahyd.base_message.state IS '消息状态（0未读，1已读）'
/
COMMENT ON COLUMN orahyd.base_message.touser IS '接收者编号'
/

-- End of DDL Script for Table ORAHYD.BASE_MESSAGE

