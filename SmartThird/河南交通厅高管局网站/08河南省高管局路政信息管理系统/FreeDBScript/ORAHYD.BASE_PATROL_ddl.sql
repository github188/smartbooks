-- Start of DDL Script for Table ORAHYD.BASE_PATROL
-- Generated 12-六月-2012 9:24:55 from ORAHYD@ORAHYD

CREATE TABLE base_patrol
    (patrolid                       NUMBER NOT NULL,
    deptid                         NUMBER NOT NULL,
    respuser                       VARCHAR2(20) NOT NULL,
    patroluser                     VARCHAR2(20) NOT NULL,
    busnumber                      VARCHAR2(20) NOT NULL,
    mileage                        NUMBER DEFAULT 0 NOT NULL,
    weather                        VARCHAR2(50) NOT NULL,
    log                            VARCHAR2(500) DEFAULT '无' NOT NULL,
    begintime                      DATE DEFAULT SYSDATE NOT NULL,
    endtime                        DATE DEFAULT SYSDATE NOT NULL,
    transfer                       NUMBER NOT NULL,
    accept                         NUMBER NOT NULL,
    within                         VARCHAR2(500) DEFAULT '无' NOT NULL,
    nextwithin                     VARCHAR2(500) DEFAULT '无' NOT NULL,
    acceptcaptain                  VARCHAR2(20) NOT NULL,
    shiftcaptain                   VARCHAR2(20) NOT NULL,
    acceptbusnumber                VARCHAR2(20) NOT NULL,
    ticktime                       DATE DEFAULT SYSDATE NOT NULL,
    buskm                          NUMBER DEFAULT 0 NOT NULL,
    goods                          VARCHAR2(500) NOT NULL,
    state                          NUMBER DEFAULT 0 NOT NULL,
    attention                      VARCHAR2(500),
    remark                         VARCHAR2(500))
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





-- Constraints for BASE_PATROL

ALTER TABLE base_patrol
ADD CONSTRAINT pk_base_patrol PRIMARY KEY (patrolid)
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


-- Triggers for BASE_PATROL

CREATE OR REPLACE TRIGGER trg_base_patrol
 BEFORE
  INSERT
 ON base_patrol
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_PATROL.NEXTVAL
     INTO :NEW.PATROLID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_PATROL

COMMENT ON TABLE base_patrol IS '人工巡逻日志表'
/
COMMENT ON COLUMN base_patrol.accept IS '接收人'
/
COMMENT ON COLUMN base_patrol.acceptbusnumber IS '接班巡逻车牌号'
/
COMMENT ON COLUMN base_patrol.acceptcaptain IS '接班中队长'
/
COMMENT ON COLUMN base_patrol.attention IS '重点关注'
/
COMMENT ON COLUMN base_patrol.begintime IS '巡查开始时间'
/
COMMENT ON COLUMN base_patrol.buskm IS '接班巡逻车里程表（KM）'
/
COMMENT ON COLUMN base_patrol.busnumber IS '巡查车牌号'
/
COMMENT ON COLUMN base_patrol.deptid IS '巡查中队'
/
COMMENT ON COLUMN base_patrol.endtime IS '巡查结束时间'
/
COMMENT ON COLUMN base_patrol.goods IS '移交器材'
/
COMMENT ON COLUMN base_patrol.log IS '巡查处理情况'
/
COMMENT ON COLUMN base_patrol.mileage IS '巡查里程'
/
COMMENT ON COLUMN base_patrol.nextwithin IS '移交下班处理事项'
/
COMMENT ON COLUMN base_patrol.patrolid IS '巡逻日志ID'
/
COMMENT ON COLUMN base_patrol.patroluser IS '巡查人员'
/
COMMENT ON COLUMN base_patrol.remark IS '备注'
/
COMMENT ON COLUMN base_patrol.respuser IS '巡查负责人'
/
COMMENT ON COLUMN base_patrol.shiftcaptain IS '交班中队长'
/
COMMENT ON COLUMN base_patrol.state IS '状态（0：正常，1：删除；）'
/
COMMENT ON COLUMN base_patrol.ticktime IS '交接班时间'
/
COMMENT ON COLUMN base_patrol.transfer IS '移交人'
/
COMMENT ON COLUMN base_patrol.weather IS '天气'
/
COMMENT ON COLUMN base_patrol.within IS '移交内业处理事项'
/

-- End of DDL Script for Table ORAHYD.BASE_PATROL

