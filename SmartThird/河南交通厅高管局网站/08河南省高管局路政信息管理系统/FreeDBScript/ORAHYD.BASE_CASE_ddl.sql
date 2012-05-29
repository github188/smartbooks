-- Start of DDL Script for Table ORAHYD.BASE_CASE
-- Generated 29-五月-2012 14:19:11 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_case
    (id                             NUMBER NOT NULL,
    casecode                       VARCHAR2(50) NOT NULL,
    userid                         NUMBER NOT NULL,
    ticktime                       DATE DEFAULT SYSDATE NOT NULL,
    weather                        VARCHAR2(50) NOT NULL,
    linename                       VARCHAR2(50) NOT NULL,
    stakek                         NUMBER NOT NULL,
    stakem                         NUMBER NOT NULL,
    linetype                       VARCHAR2(50) NOT NULL,
    accidenttype                   VARCHAR2(50) NOT NULL,
    accidentcause                  VARCHAR2(50) NOT NULL,
    action                         VARCHAR2(50) NOT NULL,
    launch                         VARCHAR2(50) NOT NULL,
    presenters                     VARCHAR2(50) NOT NULL,
    presentersid                   VARCHAR2(50) NOT NULL,
    presentersduty                 VARCHAR2(50) NOT NULL,
    inquest                        VARCHAR2(50) NOT NULL,
    inquestid                      VARCHAR2(50) NOT NULL,
    inquestduty                    VARCHAR2(50) NOT NULL,
    inquestbegintime               DATE NOT NULL,
    inquestendtime                 DATE NOT NULL,
    invite                         VARCHAR2(50) NOT NULL,
    invitetel                      VARCHAR2(50) NOT NULL,
    inviteduty                     VARCHAR2(50) NOT NULL,
    busloss                        NUMBER DEFAULT 0 NOT NULL,
    death                          NUMBER DEFAULT 0 NOT NULL,
    weight                         NUMBER DEFAULT 0 NOT NULL,
    light                          NUMBER DEFAULT 0 NOT NULL,
    summary                        VARCHAR2(1000) NOT NULL,
    createtime                     DATE DEFAULT SYSDATE NOT NULL)
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





-- Constraints for ORAHYD.BASE_CASE

ALTER TABLE orahyd.base_case
ADD CONSTRAINT pk_base_case PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_CASE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_CASE
 BEFORE 
 INSERT
 ON BASE_CASE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_case.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_CASE

COMMENT ON TABLE orahyd.base_case IS '路产案件表'
/
COMMENT ON COLUMN orahyd.base_case.accidentcause IS '事故发生原因'
/
COMMENT ON COLUMN orahyd.base_case.accidenttype IS '事故类型'
/
COMMENT ON COLUMN orahyd.base_case.action IS '案由'
/
COMMENT ON COLUMN orahyd.base_case.busloss IS '车货损失'
/
COMMENT ON COLUMN orahyd.base_case.casecode IS '案件编号'
/
COMMENT ON COLUMN orahyd.base_case.createtime IS '立案日期'
/
COMMENT ON COLUMN orahyd.base_case.death IS '死亡人数'
/
COMMENT ON COLUMN orahyd.base_case.id IS '编号'
/
COMMENT ON COLUMN orahyd.base_case.inquest IS '勘验检查人'
/
COMMENT ON COLUMN orahyd.base_case.inquestbegintime IS '勘验检查时间起'
/
COMMENT ON COLUMN orahyd.base_case.inquestduty IS '勘验检查人职务'
/
COMMENT ON COLUMN orahyd.base_case.inquestendtime IS '勘验检查时间止'
/
COMMENT ON COLUMN orahyd.base_case.inquestid IS '勘验检查人执法证编号'
/
COMMENT ON COLUMN orahyd.base_case.invite IS '被邀请人'
/
COMMENT ON COLUMN orahyd.base_case.inviteduty IS '被邀请人职务'
/
COMMENT ON COLUMN orahyd.base_case.invitetel IS '被邀请人电话'
/
COMMENT ON COLUMN orahyd.base_case.launch IS '立案人'
/
COMMENT ON COLUMN orahyd.base_case.light IS '轻伤人数'
/
COMMENT ON COLUMN orahyd.base_case.linename IS '线路名称'
/
COMMENT ON COLUMN orahyd.base_case.linetype IS '路段类型'
/
COMMENT ON COLUMN orahyd.base_case.presenters IS '办案主持人'
/
COMMENT ON COLUMN orahyd.base_case.presentersduty IS '办案主持人职务'
/
COMMENT ON COLUMN orahyd.base_case.presentersid IS '办案主持人执法证编号'
/
COMMENT ON COLUMN orahyd.base_case.stakek IS '桩号（K）'
/
COMMENT ON COLUMN orahyd.base_case.stakem IS '桩号（M）'
/
COMMENT ON COLUMN orahyd.base_case.summary IS '案情摘要'
/
COMMENT ON COLUMN orahyd.base_case.ticktime IS '发生时间'
/
COMMENT ON COLUMN orahyd.base_case.userid IS '案件登记人'
/
COMMENT ON COLUMN orahyd.base_case.weather IS '天气情况'
/
COMMENT ON COLUMN orahyd.base_case.weight IS '重伤人数'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE

