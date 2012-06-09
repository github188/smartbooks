-- Start of DDL Script for Table ORAHYD.BASE_OBSERVED
-- Generated 2012-6-9 下午 07:03:42 from ORAHYD@ORAHYD

CREATE TABLE base_observed
    (observedid                     NUMBER DEFAULT 0 NOT NULL,
    patroluser                     VARCHAR2(50) NOT NULL,
    weather                        VARCHAR2(50) NOT NULL,
    begintime                      DATE DEFAULT SYSDATE NOT NULL,
    enddate                        DATE DEFAULT SYSDATE NOT NULL,
    log                            VARCHAR2(500) NOT NULL,
    deptid                         NUMBER NOT NULL,
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





-- Constraints for BASE_OBSERVED

ALTER TABLE base_observed
ADD CONSTRAINT pk_base_observed PRIMARY KEY (observedid)
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


-- Triggers for BASE_OBSERVED

CREATE OR REPLACE TRIGGER trg_base_observed
 BEFORE
  INSERT
 ON base_observed
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_OBSERVED.NEXTVAL
     INTO :NEW.OBSERVEDID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_OBSERVED

COMMENT ON TABLE base_observed IS '电子巡逻日志表'
/
COMMENT ON COLUMN base_observed.begintime IS '巡查开始时间'
/
COMMENT ON COLUMN base_observed.deptid IS '部门'
/
COMMENT ON COLUMN base_observed.enddate IS '巡查结束时间'
/
COMMENT ON COLUMN base_observed.log IS '巡查处理情况'
/
COMMENT ON COLUMN base_observed.observedid IS '电子巡逻日志编号'
/
COMMENT ON COLUMN base_observed.patroluser IS '巡查人员'
/
COMMENT ON COLUMN base_observed.state IS '状态（0：正常，1：删除）'
/
COMMENT ON COLUMN base_observed.weather IS '天气'
/

-- End of DDL Script for Table ORAHYD.BASE_OBSERVED

