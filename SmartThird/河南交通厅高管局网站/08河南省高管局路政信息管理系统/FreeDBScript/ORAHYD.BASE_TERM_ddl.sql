-- Start of DDL Script for Table ORAHYD.BASE_TERM
-- Generated 29-五月-2012 14:29:06 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_term
    (termid                         NUMBER NOT NULL,
    deptid                         NUMBER NOT NULL,
    termcode                       VARCHAR2(50) NOT NULL,
    termname                       VARCHAR2(50) NOT NULL,
    serialcode                     VARCHAR2(50) NOT NULL,
    format                         VARCHAR2(50) NOT NULL,
    brand                          VARCHAR2(50) NOT NULL,
    use                            VARCHAR2(50) NOT NULL,
    usetime                        DATE DEFAULT SYSDATE NOT NULL,
    savepoint                      VARCHAR2(50) NOT NULL,
    remark                         VARCHAR2(50) NOT NULL,
    status                         NUMBER DEFAULT 0 NOT NULL,
    typeid                         NUMBER NOT NULL)
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





-- Constraints for ORAHYD.BASE_TERM

ALTER TABLE orahyd.base_term
ADD CONSTRAINT pk_base_term PRIMARY KEY (termid)
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


-- Triggers for ORAHYD.BASE_TERM

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_TERM
 BEFORE 
 INSERT
 ON BASE_TERM
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_TERM.NEXTVAL
     INTO :NEW.TERMID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_TERM

COMMENT ON TABLE orahyd.base_term IS '装备信息表'
/
COMMENT ON COLUMN orahyd.base_term.brand IS '制造厂商'
/
COMMENT ON COLUMN orahyd.base_term.deptid IS '所属部门'
/
COMMENT ON COLUMN orahyd.base_term.format IS '规格型号'
/
COMMENT ON COLUMN orahyd.base_term.remark IS '备注'
/
COMMENT ON COLUMN orahyd.base_term.savepoint IS '存放地点'
/
COMMENT ON COLUMN orahyd.base_term.serialcode IS '出厂编号'
/
COMMENT ON COLUMN orahyd.base_term.status IS '状态（0：正常，1：删除）'
/
COMMENT ON COLUMN orahyd.base_term.termcode IS '设备编号'
/
COMMENT ON COLUMN orahyd.base_term.termid IS '编号'
/
COMMENT ON COLUMN orahyd.base_term.termname IS '设备名称'
/
COMMENT ON COLUMN orahyd.base_term.typeid IS '装备类型'
/
COMMENT ON COLUMN orahyd.base_term.use IS '装备用途'
/
COMMENT ON COLUMN orahyd.base_term.usetime IS '投入使用时间'
/

-- End of DDL Script for Table ORAHYD.BASE_TERM

