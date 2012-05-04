-- Start of DDL Script for Table ORAHYD.BASE_ACTION
-- Generated 4-五月-2012 18:46:29 from ORAHYD@ORCL

CREATE TABLE base_action
    (actionid                       NUMBER DEFAULT 0 NOT NULL,
    actionname                     VARCHAR2(50) NOT NULL,
    status                         NUMBER DEFAULT 0 NOT NULL,
    actioninfo                     VARCHAR2(50) DEFAULT '无' NOT NULL)
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





-- Constraints for BASE_ACTION

ALTER TABLE base_action
ADD CONSTRAINT pk_base_action PRIMARY KEY (actionid)
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


-- Triggers for BASE_ACTION

CREATE OR REPLACE TRIGGER trg_base_action
 BEFORE
  INSERT
 ON base_action
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_action.NEXTVAL
     INTO :NEW.ACTIONID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_ACTION

COMMENT ON TABLE base_action IS '动作信息表'
/
COMMENT ON COLUMN base_action.actionid IS '动作编号'
/
COMMENT ON COLUMN base_action.actioninfo IS '动作描述'
/
COMMENT ON COLUMN base_action.actionname IS '动作名称'
/
COMMENT ON COLUMN base_action.status IS '状态（0：正常 1关闭）'
/

-- End of DDL Script for Table ORAHYD.BASE_ACTION

-- Start of DDL Script for Table ORAHYD.BASE_AFFICHE
-- Generated 4-五月-2012 18:46:29 from ORAHYD@ORCL

CREATE TABLE base_affiche
    (afficheid                      NUMBER NOT NULL,
    affichetitle                   VARCHAR2(60),
    affichecontents                VARCHAR2(200),
    afficher                       VARCHAR2(20),
    affichedate                    DATE DEFAULT sysdate)
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





-- Comments for BASE_AFFICHE

COMMENT ON TABLE base_affiche IS '公告信息表'
/
COMMENT ON COLUMN base_affiche.affichecontents IS '公告内容'
/
COMMENT ON COLUMN base_affiche.affichedate IS '公告发布时间'
/
COMMENT ON COLUMN base_affiche.afficheid IS '公告编号'
/
COMMENT ON COLUMN base_affiche.afficher IS '公告发布人'
/
COMMENT ON COLUMN base_affiche.affichetitle IS '公告标题'
/

-- End of DDL Script for Table ORAHYD.BASE_AFFICHE

-- Start of DDL Script for Table ORAHYD.BASE_AREA
-- Generated 4-五月-2012 18:46:29 from ORAHYD@ORCL

CREATE TABLE base_area
    (id                             NUMBER NOT NULL,
    areaname                       VARCHAR2(50) NOT NULL,
    typeid                         NUMBER NOT NULL,
    linename                       VARCHAR2(50) NOT NULL,
    stakek                         NUMBER NOT NULL,
    stakem                         NUMBER NOT NULL,
    summary                        VARCHAR2(50) NOT NULL,
    comptime                       DATE DEFAULT SYSDATE NOT NULL,
    regtime                        DATE DEFAULT SYSDATE NOT NULL,
    owner                          VARCHAR2(50) NOT NULL,
    detailed                       VARCHAR2(200) DEFAULT '无' NOT NULL,
    status                         VARCHAR2(200) DEFAULT '无' NOT NULL,
    remark                         VARCHAR2(200) DEFAULT '无' NOT NULL,
    photo                          VARCHAR2(200) NOT NULL,
    deptid                         NUMBER NOT NULL)
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





-- Constraints for BASE_AREA

ALTER TABLE base_area
ADD CONSTRAINT pk_base_area PRIMARY KEY (id)
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


-- Triggers for BASE_AREA

CREATE OR REPLACE TRIGGER trg_base_area
 BEFORE
  INSERT
 ON base_area
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_area.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_AREA

COMMENT ON TABLE base_area IS '控制区违章信息表'
/
COMMENT ON COLUMN base_area.areaname IS '违章名称'
/
COMMENT ON COLUMN base_area.comptime IS '竣工时间'
/
COMMENT ON COLUMN base_area.deptid IS '部门编号'
/
COMMENT ON COLUMN base_area.detailed IS '详细描述'
/
COMMENT ON COLUMN base_area.id IS '编号'
/
COMMENT ON COLUMN base_area.linename IS '公路名称'
/
COMMENT ON COLUMN base_area.owner IS '物主名称'
/
COMMENT ON COLUMN base_area.photo IS '现场照片'
/
COMMENT ON COLUMN base_area.regtime IS '登记时间'
/
COMMENT ON COLUMN base_area.remark IS '详细备注'
/
COMMENT ON COLUMN base_area.stakek IS '桩号（K）'
/
COMMENT ON COLUMN base_area.stakem IS '桩号（M）'
/
COMMENT ON COLUMN base_area.status IS '现状描述'
/
COMMENT ON COLUMN base_area.summary IS '位置描述'
/
COMMENT ON COLUMN base_area.typeid IS '分类编号'
/

-- End of DDL Script for Table ORAHYD.BASE_AREA

-- Start of DDL Script for Table ORAHYD.BASE_AREA_TYPE
-- Generated 4-五月-2012 18:46:30 from ORAHYD@ORCL

CREATE TABLE base_area_type
    (typename                       VARCHAR2(50) NOT NULL,
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





-- Constraints for BASE_AREA_TYPE

ALTER TABLE base_area_type
ADD CONSTRAINT pk_base_area_type PRIMARY KEY (typeid)
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


-- Triggers for BASE_AREA_TYPE

CREATE OR REPLACE TRIGGER trg_base_area_type
 BEFORE
  INSERT
 ON base_area_type
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_area_type.NEXTVAL
     INTO :NEW.TYPEID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_AREA_TYPE

COMMENT ON TABLE base_area_type IS '控制区违章类型表'
/
COMMENT ON COLUMN base_area_type.typeid IS 'id,主键，自增'
/
COMMENT ON COLUMN base_area_type.typename IS '分类名称'
/

-- End of DDL Script for Table ORAHYD.BASE_AREA_TYPE

-- Start of DDL Script for Table ORAHYD.BASE_ASSESS
-- Generated 4-五月-2012 18:46:30 from ORAHYD@ORCL

CREATE TABLE base_assess
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





-- Comments for BASE_ASSESS

COMMENT ON TABLE base_assess IS '考核信息表'
/
COMMENT ON COLUMN base_assess.assesscontent IS '目标内容'
/
COMMENT ON COLUMN base_assess.assesscriterion IS '考核标准'
/
COMMENT ON COLUMN base_assess.assessdept IS '考核项目所属单位'
/
COMMENT ON COLUMN base_assess.assessdescription IS '考核信息备注'
/
COMMENT ON COLUMN base_assess.assessformat IS '考核形式'
/
COMMENT ON COLUMN base_assess.assessid IS '考核信息编号'
/
COMMENT ON COLUMN base_assess.assessname IS '考核项目名称'
/
COMMENT ON COLUMN base_assess.assessresult IS '考核分值'
/
COMMENT ON COLUMN base_assess.assesstime IS '上报时间'
/

-- End of DDL Script for Table ORAHYD.BASE_ASSESS

-- Start of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN
-- Generated 4-五月-2012 18:46:30 from ORAHYD@ORCL

CREATE TABLE base_bus_overrun
    (id                             NUMBER NOT NULL,
    buscode                        VARCHAR2(20) NOT NULL,
    inname                         VARCHAR2(50) NOT NULL,
    intime                         DATE DEFAULT SYSDATE NOT NULL,
    outname                        VARCHAR2(50) NOT NULL,
    outtime                        DATE DEFAULT SYSDATE NOT NULL,
    pay                            VARCHAR2(20) DEFAULT '现金' NOT NULL,
    axis                           NUMBER DEFAULT 0 NOT NULL,
    overloadrate                   NUMBER DEFAULT 0 NOT NULL,
    totalweight                    NUMBER DEFAULT 0 NOT NULL,
    money                          NUMBER DEFAULT 0 NOT NULL,
    mileage                        NUMBER DEFAULT 0 NOT NULL)
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





-- Constraints for BASE_BUS_OVERRUN

ALTER TABLE base_bus_overrun
ADD CONSTRAINT pk_base_bus_overrun PRIMARY KEY (id)
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


-- Triggers for BASE_BUS_OVERRUN

CREATE OR REPLACE TRIGGER trg_base_bus_overrun
 BEFORE
  INSERT
 ON base_bus_overrun
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_bus_overrun.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_BUS_OVERRUN

COMMENT ON TABLE base_bus_overrun IS '高速公路超限车辆数据表'
/
COMMENT ON COLUMN base_bus_overrun.axis IS '轴数'
/
COMMENT ON COLUMN base_bus_overrun.buscode IS '车牌号码'
/
COMMENT ON COLUMN base_bus_overrun.id IS 'ID编号'
/
COMMENT ON COLUMN base_bus_overrun.inname IS '入口站名'
/
COMMENT ON COLUMN base_bus_overrun.intime IS '入口时间'
/
COMMENT ON COLUMN base_bus_overrun.mileage IS '里程'
/
COMMENT ON COLUMN base_bus_overrun.money IS '金额'
/
COMMENT ON COLUMN base_bus_overrun.outname IS '出口站名'
/
COMMENT ON COLUMN base_bus_overrun.outtime IS '出口时间'
/
COMMENT ON COLUMN base_bus_overrun.overloadrate IS '超载率'
/
COMMENT ON COLUMN base_bus_overrun.pay IS '支付形式'
/
COMMENT ON COLUMN base_bus_overrun.totalweight IS '总重'
/

-- End of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN

-- Start of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN_SUBMIT
-- Generated 4-五月-2012 18:46:30 from ORAHYD@ORCL

CREATE TABLE base_bus_overrun_submit
    (id                             NUMBER NOT NULL,
    buscode                        VARCHAR2(20) NOT NULL,
    buslong                        NUMBER NOT NULL,
    buswidth                       NUMBER NOT NULL,
    busheight                      NUMBER NOT NULL,
    weight                         NUMBER NOT NULL,
    photo                          VARCHAR2(200) NOT NULL,
    inname                         VARCHAR2(50) NOT NULL,
    outname                        VARCHAR2(50) NOT NULL,
    ticktime                       DATE NOT NULL,
    userid                         NUMBER NOT NULL,
    deptid                         NUMBER NOT NULL,
    location                       VARCHAR2(100) NOT NULL,
    busunit                        VARCHAR2(50) NOT NULL,
    remarks                        VARCHAR2(50) DEFAULT '无')
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





-- Constraints for BASE_BUS_OVERRUN_SUBMIT

ALTER TABLE base_bus_overrun_submit
ADD CONSTRAINT pk_base_bus_overrun_submit PRIMARY KEY (id)
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


-- Triggers for BASE_BUS_OVERRUN_SUBMIT

CREATE OR REPLACE TRIGGER trg_base_bus_overrun_submit
 BEFORE
  INSERT
 ON base_bus_overrun_submit
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_BASE_BUS_OVERRUN_SUBMIT.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_BUS_OVERRUN_SUBMIT

COMMENT ON TABLE base_bus_overrun_submit IS '查处非法超限车辆数据'
/
COMMENT ON COLUMN base_bus_overrun_submit.buscode IS '车牌号码'
/
COMMENT ON COLUMN base_bus_overrun_submit.busheight IS '高度'
/
COMMENT ON COLUMN base_bus_overrun_submit.buslong IS '车货总长'
/
COMMENT ON COLUMN base_bus_overrun_submit.busunit IS '车辆所属单位'
/
COMMENT ON COLUMN base_bus_overrun_submit.buswidth IS '宽度'
/
COMMENT ON COLUMN base_bus_overrun_submit.deptid IS '查处单位'
/
COMMENT ON COLUMN base_bus_overrun_submit.id IS 'id，主键，自增'
/
COMMENT ON COLUMN base_bus_overrun_submit.inname IS '入口站名称'
/
COMMENT ON COLUMN base_bus_overrun_submit.location IS '查处地点'
/
COMMENT ON COLUMN base_bus_overrun_submit.outname IS '出口站名称'
/
COMMENT ON COLUMN base_bus_overrun_submit.photo IS '车货照片'
/
COMMENT ON COLUMN base_bus_overrun_submit.remarks IS '备注'
/
COMMENT ON COLUMN base_bus_overrun_submit.ticktime IS '查处时间'
/
COMMENT ON COLUMN base_bus_overrun_submit.userid IS '查处人'
/
COMMENT ON COLUMN base_bus_overrun_submit.weight IS '总重量'
/

-- End of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN_SUBMIT

-- Start of DDL Script for Table ORAHYD.BASE_CASE
-- Generated 4-五月-2012 18:46:31 from ORAHYD@ORCL

CREATE TABLE base_case
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





-- Constraints for BASE_CASE

ALTER TABLE base_case
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


-- Triggers for BASE_CASE

CREATE OR REPLACE TRIGGER trg_base_case
 BEFORE
  INSERT
 ON base_case
REFERENCING NEW AS NEW OLD AS OLD
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


-- Comments for BASE_CASE

COMMENT ON TABLE base_case IS '路产案件表'
/
COMMENT ON COLUMN base_case.accidentcause IS '事故发生原因'
/
COMMENT ON COLUMN base_case.accidenttype IS '事故类型'
/
COMMENT ON COLUMN base_case.action IS '案由'
/
COMMENT ON COLUMN base_case.busloss IS '车货损失'
/
COMMENT ON COLUMN base_case.casecode IS '案件编号'
/
COMMENT ON COLUMN base_case.createtime IS '立案日期'
/
COMMENT ON COLUMN base_case.death IS '死亡人数'
/
COMMENT ON COLUMN base_case.id IS '编号'
/
COMMENT ON COLUMN base_case.inquest IS '勘验检查人'
/
COMMENT ON COLUMN base_case.inquestbegintime IS '勘验检查时间起'
/
COMMENT ON COLUMN base_case.inquestduty IS '勘验检查人职务'
/
COMMENT ON COLUMN base_case.inquestendtime IS '勘验检查时间止'
/
COMMENT ON COLUMN base_case.inquestid IS '勘验检查人执法证编号'
/
COMMENT ON COLUMN base_case.invite IS '被邀请人'
/
COMMENT ON COLUMN base_case.inviteduty IS '被邀请人职务'
/
COMMENT ON COLUMN base_case.invitetel IS '被邀请人电话'
/
COMMENT ON COLUMN base_case.launch IS '立案人'
/
COMMENT ON COLUMN base_case.light IS '轻伤人数'
/
COMMENT ON COLUMN base_case.linename IS '线路名称'
/
COMMENT ON COLUMN base_case.linetype IS '路段类型'
/
COMMENT ON COLUMN base_case.presenters IS '办案主持人'
/
COMMENT ON COLUMN base_case.presentersduty IS '办案主持人职务'
/
COMMENT ON COLUMN base_case.presentersid IS '办案主持人执法证编号'
/
COMMENT ON COLUMN base_case.stakek IS '桩号（K）'
/
COMMENT ON COLUMN base_case.stakem IS '桩号（M）'
/
COMMENT ON COLUMN base_case.summary IS '案情摘要'
/
COMMENT ON COLUMN base_case.ticktime IS '发生时间'
/
COMMENT ON COLUMN base_case.userid IS '案件登记人'
/
COMMENT ON COLUMN base_case.weather IS '天气情况'
/
COMMENT ON COLUMN base_case.weight IS '重伤人数'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE

-- Start of DDL Script for Table ORAHYD.BASE_CASE_BUS
-- Generated 4-五月-2012 18:46:31 from ORAHYD@ORCL

CREATE TABLE base_case_bus
    (id                             NUMBER NOT NULL,
    party                          VARCHAR2(50) NOT NULL,
    sex                            NUMBER DEFAULT 0 NOT NULL,
    age                            NUMBER NOT NULL,
    phone                          VARCHAR2(51) NOT NULL,
    driving                        NUMBER NOT NULL,
    cardid                         VARCHAR2(16) NOT NULL,
    bustype                        VARCHAR2(20) NOT NULL,
    busnumber                      VARCHAR2(20) NOT NULL,
    label                          VARCHAR2(20),
    pattern                        VARCHAR2(20) NOT NULL,
    address                        VARCHAR2(80) NOT NULL,
    zipcode                        VARCHAR2(10) NOT NULL,
    attrib                         VARCHAR2(10) NOT NULL,
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





-- Constraints for BASE_CASE_BUS

ALTER TABLE base_case_bus
ADD CONSTRAINT pk_base_case_bus PRIMARY KEY (id)
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


-- Triggers for BASE_CASE_BUS

CREATE OR REPLACE TRIGGER trg_base_case_bus
 BEFORE
  INSERT
 ON base_case_bus
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_case_bus.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_CASE_BUS

COMMENT ON TABLE base_case_bus IS '路产案件（车辆人员信息）'
/
COMMENT ON COLUMN base_case_bus.address IS '工作单位或地址'
/
COMMENT ON COLUMN base_case_bus.age IS '年龄'
/
COMMENT ON COLUMN base_case_bus.attrib IS '车籍地'
/
COMMENT ON COLUMN base_case_bus.busnumber IS '车牌号码'
/
COMMENT ON COLUMN base_case_bus.bustype IS '车辆类型'
/
COMMENT ON COLUMN base_case_bus.cardid IS '证件号码'
/
COMMENT ON COLUMN base_case_bus.caseid IS '案件编号'
/
COMMENT ON COLUMN base_case_bus.driving IS '驾龄'
/
COMMENT ON COLUMN base_case_bus.id IS 'ID编号'
/
COMMENT ON COLUMN base_case_bus.label IS '厂牌'
/
COMMENT ON COLUMN base_case_bus.party IS '当事人'
/
COMMENT ON COLUMN base_case_bus.pattern IS '型号'
/
COMMENT ON COLUMN base_case_bus.phone IS '联系电话'
/
COMMENT ON COLUMN base_case_bus.sex IS '性别（0：男 1：女）'
/
COMMENT ON COLUMN base_case_bus.zipcode IS '邮编'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE_BUS

-- Start of DDL Script for Table ORAHYD.BASE_CASE_CLOSED
-- Generated 4-五月-2012 18:46:31 from ORAHYD@ORCL

CREATE TABLE base_case_closed
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





-- Constraints for BASE_CASE_CLOSED

ALTER TABLE base_case_closed
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


-- Triggers for BASE_CASE_CLOSED

CREATE OR REPLACE TRIGGER trg_base_case_closed
 BEFORE
  INSERT
 ON base_case_closed
REFERENCING NEW AS NEW OLD AS OLD
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


-- Comments for BASE_CASE_CLOSED

COMMENT ON TABLE base_case_closed IS '路产案件（议案结案表）'
/
COMMENT ON COLUMN base_case_closed.caseid IS '案件编号'
/
COMMENT ON COLUMN base_case_closed.closedeay IS '结案方式'
/
COMMENT ON COLUMN base_case_closed.closedtime IS '结案日期'
/
COMMENT ON COLUMN base_case_closed.discuss IS '讨论意见'
/
COMMENT ON COLUMN base_case_closed.lead IS '主管领导意见'
/
COMMENT ON COLUMN base_case_closed.motionlocation IS '议案地点'
/
COMMENT ON COLUMN base_case_closed.motionpro IS '主持人'
/
COMMENT ON COLUMN base_case_closed.motiontime IS '议案时间'
/
COMMENT ON COLUMN base_case_closed.record IS '议案记录人'
/
COMMENT ON COLUMN base_case_closed.recoverloss IS '追回损失'
/
COMMENT ON COLUMN base_case_closed.remark IS '备注'
/
COMMENT ON COLUMN base_case_closed.result IS '处理结果'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE_CLOSED

-- Start of DDL Script for Table ORAHYD.BASE_CASE_LOSS
-- Generated 4-五月-2012 18:46:32 from ORAHYD@ORCL

CREATE TABLE base_case_loss
    (id                             NUMBER NOT NULL,
    compsid                        NUMBER NOT NULL,
    caseid                         NUMBER NOT NULL,
    amount                         NUMBER NOT NULL)
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





-- Constraints for BASE_CASE_LOSS

ALTER TABLE base_case_loss
ADD CONSTRAINT pk_base_case_loss PRIMARY KEY (id)
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


-- Triggers for BASE_CASE_LOSS

CREATE OR REPLACE TRIGGER trg_base_case_loss
 BEFORE
  INSERT
 ON base_case_loss
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_case_LOSS.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_CASE_LOSS

COMMENT ON TABLE base_case_loss IS '路产案件损失表'
/
COMMENT ON COLUMN base_case_loss.amount IS '损失单位量'
/
COMMENT ON COLUMN base_case_loss.caseid IS '路产案件编号'
/
COMMENT ON COLUMN base_case_loss.compsid IS '赔偿项目标准'
/
COMMENT ON COLUMN base_case_loss.id IS 'id,primary'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE_LOSS

-- Start of DDL Script for Table ORAHYD.BASE_COMPS
-- Generated 4-五月-2012 18:46:32 from ORAHYD@ORCL

CREATE TABLE base_comps
    (id                             NUMBER NOT NULL,
    compsname                      VARCHAR2(50) NOT NULL,
    unit                           VARCHAR2(10) NOT NULL,
    money                          NUMBER NOT NULL,
    remark                         VARCHAR2(50))
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





-- Constraints for BASE_COMPS

ALTER TABLE base_comps
ADD CONSTRAINT pk_base_comps PRIMARY KEY (id)
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


-- Triggers for BASE_COMPS

CREATE OR REPLACE TRIGGER trg_base_comps
 BEFORE
  INSERT
 ON base_comps
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_COMPS.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_COMPS

COMMENT ON TABLE base_comps IS '赔偿标准信息表'
/
COMMENT ON COLUMN base_comps.compsname IS '项目名称'
/
COMMENT ON COLUMN base_comps.money IS '金额（人民币）'
/
COMMENT ON COLUMN base_comps.remark IS '备注'
/
COMMENT ON COLUMN base_comps.unit IS '单位'
/

-- End of DDL Script for Table ORAHYD.BASE_COMPS

-- Start of DDL Script for Table ORAHYD.BASE_DEPT
-- Generated 4-五月-2012 18:46:32 from ORAHYD@ORCL

CREATE TABLE base_dept
    (deptid                         NUMBER NOT NULL,
    dptname                        VARCHAR2(50) NOT NULL,
    dptinfo                        VARCHAR2(50) NOT NULL,
    parentid                       NUMBER DEFAULT 0 NOT NULL,
    status                         NUMBER DEFAULT 0 NOT NULL)
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





-- Constraints for BASE_DEPT

ALTER TABLE base_dept
ADD CONSTRAINT pk_base_dept PRIMARY KEY (deptid)
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


-- Triggers for BASE_DEPT

CREATE OR REPLACE TRIGGER trg_base_dept
 BEFORE
  INSERT
 ON base_dept
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_DEPT.NEXTVAL
     INTO :NEW.DEPTID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_DEPT

COMMENT ON TABLE base_dept IS '部门信息表'
/
COMMENT ON COLUMN base_dept.deptid IS '部门编号'
/
COMMENT ON COLUMN base_dept.dptinfo IS '部门描述'
/
COMMENT ON COLUMN base_dept.dptname IS '部门名称'
/
COMMENT ON COLUMN base_dept.parentid IS '上级部门编号（根节点0）'
/
COMMENT ON COLUMN base_dept.status IS '状态（0：正常 1：关闭）'
/

-- End of DDL Script for Table ORAHYD.BASE_DEPT

-- Start of DDL Script for Table ORAHYD.BASE_FILES
-- Generated 4-五月-2012 18:46:32 from ORAHYD@ORCL

CREATE TABLE base_files
    (cartularyid                    NUMBER DEFAULT 0,
    cartularyname                  VARCHAR2(50),
    cartularytypes                 VARCHAR2(50),
    cartularysrc                   VARCHAR2(100),
    cartularydescription           VARCHAR2(200),
    cartularstate                  NUMBER,
    cartular_numbers               VARCHAR2(50),
    c_dates                        DATE)
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





-- Comments for BASE_FILES

COMMENT ON TABLE base_files IS '文件档案信息表'
/
COMMENT ON COLUMN base_files.c_dates IS '归档时间'
/
COMMENT ON COLUMN base_files.cartular_numbers IS '文号'
/
COMMENT ON COLUMN base_files.cartularstate IS '档案状态'
/
COMMENT ON COLUMN base_files.cartularydescription IS '档案描述'
/
COMMENT ON COLUMN base_files.cartularyid IS '档案编号'
/
COMMENT ON COLUMN base_files.cartularyname IS '档案名称'
/
COMMENT ON COLUMN base_files.cartularysrc IS '档案存储路径'
/
COMMENT ON COLUMN base_files.cartularytypes IS '档案类型'
/

-- End of DDL Script for Table ORAHYD.BASE_FILES

-- Start of DDL Script for Table ORAHYD.BASE_LICENSE_ACCEPT
-- Generated 4-五月-2012 18:46:32 from ORAHYD@ORCL

CREATE TABLE base_license_accept
    (requisitionid                  NUMBER NOT NULL,
    requisitionname                VARCHAR2(50),
    address                        VARCHAR2(50),
    tel                            VARCHAR2(50),
    phone                          VARCHAR2(50),
    email                          VARCHAR2(50),
    post                           VARCHAR2(20),
    requisitioncontent             VARCHAR2(200),
    deputy                         VARCHAR2(20),
    materials                      VARCHAR2(20),
    mark                           VARCHAR2(20),
    creatdate                      DATE,
    auditor                        VARCHAR2(20),
    audit_state                    NUMBER,
    file_path                      VARCHAR2(50),
    audit_desc                     VARCHAR2(200),
    audit_reply                    VARCHAR2(200))
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





-- Comments for BASE_LICENSE_ACCEPT

COMMENT ON TABLE base_license_accept IS '路政许可申请表'
/
COMMENT ON COLUMN base_license_accept.address IS '申请人住址'
/
COMMENT ON COLUMN base_license_accept.audit_desc IS '审核意见'
/
COMMENT ON COLUMN base_license_accept.audit_reply IS '意见回复'
/
COMMENT ON COLUMN base_license_accept.audit_state IS '审核状态'
/
COMMENT ON COLUMN base_license_accept.auditor IS '审核人'
/
COMMENT ON COLUMN base_license_accept.creatdate IS '申请日期'
/
COMMENT ON COLUMN base_license_accept.deputy IS '委托代理人'
/
COMMENT ON COLUMN base_license_accept.email IS '邮箱'
/
COMMENT ON COLUMN base_license_accept.file_path IS '附件路径'
/
COMMENT ON COLUMN base_license_accept.mark IS '备注'
/
COMMENT ON COLUMN base_license_accept.materials IS '申请材料目录'
/
COMMENT ON COLUMN base_license_accept.phone IS '手机'
/
COMMENT ON COLUMN base_license_accept.post IS '邮编'
/
COMMENT ON COLUMN base_license_accept.requisitioncontent IS '申请许可事项及内容'
/
COMMENT ON COLUMN base_license_accept.requisitionid IS '申请书编号'
/
COMMENT ON COLUMN base_license_accept.requisitionname IS '申请人及法定代表人名称'
/
COMMENT ON COLUMN base_license_accept.tel IS '电话'
/

-- End of DDL Script for Table ORAHYD.BASE_LICENSE_ACCEPT

-- Start of DDL Script for Table ORAHYD.BASE_LOG
-- Generated 4-五月-2012 18:46:33 from ORAHYD@ORCL

CREATE TABLE base_log
    (logid                          NUMBER DEFAULT 0,
    logtype                        VARCHAR2(50),
    createdate                     DATE DEFAULT sysdate,
    operatorid                     NUMBER,
    description                    VARCHAR2(200))
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





-- Comments for BASE_LOG

COMMENT ON TABLE base_log IS '系统日志表'
/
COMMENT ON COLUMN base_log.createdate IS '日志创建时间'
/
COMMENT ON COLUMN base_log.description IS '日志信息描述'
/
COMMENT ON COLUMN base_log.logid IS '日志编号'
/
COMMENT ON COLUMN base_log.logtype IS '日志类型'
/
COMMENT ON COLUMN base_log.operatorid IS '操作人'
/

-- End of DDL Script for Table ORAHYD.BASE_LOG

-- Start of DDL Script for Table ORAHYD.BASE_MENU
-- Generated 4-五月-2012 18:46:33 from ORAHYD@ORCL

CREATE TABLE base_menu
    (menuid                         NUMBER(*,0) NOT NULL,
    menuname                       VARCHAR2(50) NOT NULL,
    menuinfo                       VARCHAR2(200) NOT NULL,
    menuurl                        VARCHAR2(200) NOT NULL,
    icon                           VARCHAR2(50) NOT NULL,
    parentid                       NUMBER(*,0) DEFAULT 0 NOT NULL,
    status                         NUMBER(*,0) DEFAULT 0 NOT NULL)
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





-- Constraints for BASE_MENU

ALTER TABLE base_menu
ADD CONSTRAINT base_menu_pk PRIMARY KEY (menuid)
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


-- Triggers for BASE_MENU

CREATE OR REPLACE TRIGGER trg_base_menu
 BEFORE
  INSERT
 ON base_menu
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_MENU.NEXTVAL
     INTO :NEW.MENUID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_MENU

COMMENT ON TABLE base_menu IS '菜单信息表'
/
COMMENT ON COLUMN base_menu.icon IS '菜单图标'
/
COMMENT ON COLUMN base_menu.menuid IS '菜单编号'
/
COMMENT ON COLUMN base_menu.menuinfo IS '菜单说明'
/
COMMENT ON COLUMN base_menu.menuname IS '菜单名称'
/
COMMENT ON COLUMN base_menu.menuurl IS '菜单URL地址'
/
COMMENT ON COLUMN base_menu.parentid IS '父菜单编号（根节点0）'
/
COMMENT ON COLUMN base_menu.status IS '状态（0：正常 1：关闭）'
/

-- End of DDL Script for Table ORAHYD.BASE_MENU

-- Start of DDL Script for Table ORAHYD.BASE_MESSAGE
-- Generated 4-五月-2012 18:46:33 from ORAHYD@ORCL

CREATE TABLE base_message
    (messageid                      NUMBER NOT NULL,
    sender                         NUMBER NOT NULL,
    touser                         NUMBER NOT NULL,
    messagebody                    VARCHAR2(200),
    senddate                       DATE,
    state                          NUMBER DEFAULT 0)
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





-- Comments for BASE_MESSAGE

COMMENT ON TABLE base_message IS '消息记录信息表'
/
COMMENT ON COLUMN base_message.messagebody IS '消息内容'
/
COMMENT ON COLUMN base_message.messageid IS '消息编号'
/
COMMENT ON COLUMN base_message.senddate IS '发送时间'
/
COMMENT ON COLUMN base_message.sender IS '发送者编号'
/
COMMENT ON COLUMN base_message.state IS '消息状态（0未读，1已读）'
/
COMMENT ON COLUMN base_message.touser IS '接收者编号'
/

-- End of DDL Script for Table ORAHYD.BASE_MESSAGE

-- Start of DDL Script for Table ORAHYD.BASE_OBSERVED
-- Generated 4-五月-2012 18:46:33 from ORAHYD@ORCL

CREATE TABLE base_observed
    (observedid                     NUMBER DEFAULT 0 NOT NULL,
    patroluser                     NUMBER NOT NULL,
    weather                        VARCHAR2(50) NOT NULL,
    begintime                      DATE DEFAULT SYSDATE NOT NULL,
    enddate                        DATE DEFAULT SYSDATE NOT NULL,
    log                            VARCHAR2(500) NOT NULL)
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
COMMENT ON COLUMN base_observed.enddate IS '巡查结束时间'
/
COMMENT ON COLUMN base_observed.log IS '巡查处理情况'
/
COMMENT ON COLUMN base_observed.observedid IS '电子巡逻日志编号'
/
COMMENT ON COLUMN base_observed.patroluser IS '巡查人员'
/
COMMENT ON COLUMN base_observed.weather IS '天气'
/

-- End of DDL Script for Table ORAHYD.BASE_OBSERVED

-- Start of DDL Script for Table ORAHYD.BASE_PATROL
-- Generated 4-五月-2012 18:46:33 from ORAHYD@ORCL

CREATE TABLE base_patrol
    (patrolid                       NUMBER NOT NULL,
    deptid                         NUMBER NOT NULL,
    respuser                       NUMBER NOT NULL,
    patroluser                     NUMBER NOT NULL,
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
    acceptcaptain                  NUMBER NOT NULL,
    shiftcaptain                   NUMBER NOT NULL,
    acceptbusnumber                VARCHAR2(20) NOT NULL,
    ticktime                       DATE DEFAULT SYSDATE NOT NULL,
    buskm                          NUMBER DEFAULT 0 NOT NULL)
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
COMMENT ON COLUMN base_patrol.respuser IS '巡查负责人'
/
COMMENT ON COLUMN base_patrol.shiftcaptain IS '交班中队长'
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

-- Start of DDL Script for Table ORAHYD.BASE_PATROL_GOODS
-- Generated 4-五月-2012 18:46:34 from ORAHYD@ORCL

CREATE TABLE base_patrol_goods
    (patrolgoodsid                  NUMBER NOT NULL,
    patrolid                       NUMBER NOT NULL,
    amount                         NUMBER DEFAULT 0 NOT NULL,
    toolname                       VARCHAR2(50) DEFAULT '无' NOT NULL)
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





-- Constraints for BASE_PATROL_GOODS

ALTER TABLE base_patrol_goods
ADD CONSTRAINT pk_base_patrol_goods PRIMARY KEY (patrolgoodsid)
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


-- Triggers for BASE_PATROL_GOODS

CREATE OR REPLACE TRIGGER trg_base_patrol_goods
 BEFORE
  INSERT
 ON base_patrol_goods
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_PATROL_GOODS.NEXTVAL
     INTO :NEW.PATROLGOODSID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_PATROL_GOODS

COMMENT ON TABLE base_patrol_goods IS '移交器材表'
/
COMMENT ON COLUMN base_patrol_goods.amount IS '器材数量'
/
COMMENT ON COLUMN base_patrol_goods.patrolgoodsid IS '编号'
/
COMMENT ON COLUMN base_patrol_goods.patrolid IS '巡逻日志编号'
/
COMMENT ON COLUMN base_patrol_goods.toolname IS '器材名称'
/

-- End of DDL Script for Table ORAHYD.BASE_PATROL_GOODS

-- Start of DDL Script for Table ORAHYD.BASE_PLAN
-- Generated 4-五月-2012 18:46:34 from ORAHYD@ORCL

CREATE TABLE base_plan
    (calendarid                     NUMBER NOT NULL,
    userid                         NUMBER NOT NULL,
    calendarcontent                VARCHAR2(200),
    start_date                     DATE DEFAULT sysdate,
    end_date                       DATE DEFAULT sysdate,
    calendarremind                 DATE DEFAULT sysdate NOT NULL)
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





-- Comments for BASE_PLAN

COMMENT ON TABLE base_plan IS '日程信息表'
/
COMMENT ON COLUMN base_plan.calendarcontent IS '日程内容'
/
COMMENT ON COLUMN base_plan.calendarid IS '日程信息编号'
/
COMMENT ON COLUMN base_plan.calendarremind IS '提醒时间'
/
COMMENT ON COLUMN base_plan.end_date IS '结束时间'
/
COMMENT ON COLUMN base_plan.start_date IS '开始时间'
/
COMMENT ON COLUMN base_plan.userid IS '用户编号'
/

-- End of DDL Script for Table ORAHYD.BASE_PLAN

-- Start of DDL Script for Table ORAHYD.BASE_PROCEDURE
-- Generated 4-五月-2012 18:46:34 from ORAHYD@ORCL

CREATE TABLE base_procedure
    (pid                            NUMBER NOT NULL,
    requisitionid                  NUMBER NOT NULL,
    department                     VARCHAR2(50),
    transactor                     VARCHAR2(50),
    contents                       VARCHAR2(50),
    result                         VARCHAR2(50),
    p_date                         DATE)
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





-- Comments for BASE_PROCEDURE

COMMENT ON TABLE base_procedure IS '路政许可流程表'
/
COMMENT ON COLUMN base_procedure.contents IS '审理意见'
/
COMMENT ON COLUMN base_procedure.department IS '审理单位(部门)'
/
COMMENT ON COLUMN base_procedure.p_date IS '审理时间'
/
COMMENT ON COLUMN base_procedure.pid IS '编号'
/
COMMENT ON COLUMN base_procedure.requisitionid IS '路政许可申请单编号'
/
COMMENT ON COLUMN base_procedure.result IS '审理结果'
/
COMMENT ON COLUMN base_procedure.transactor IS '审理人'
/

-- End of DDL Script for Table ORAHYD.BASE_PROCEDURE

-- Start of DDL Script for Table ORAHYD.BASE_PROJECT_NOTES
-- Generated 4-五月-2012 18:46:34 from ORAHYD@ORCL

CREATE TABLE base_project_notes
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





-- Comments for BASE_PROJECT_NOTES

COMMENT ON TABLE base_project_notes IS '考核项目记录表'
/
COMMENT ON COLUMN base_project_notes.assessid IS '考核信息编号'
/
COMMENT ON COLUMN base_project_notes.pid IS '编号'
/
COMMENT ON COLUMN base_project_notes.reply_content IS '考核批复内容'
/
COMMENT ON COLUMN base_project_notes.reply_date IS '批复时间'
/
COMMENT ON COLUMN base_project_notes.reply_preson IS '批复人'
/
COMMENT ON COLUMN base_project_notes.score IS '分值'
/

-- End of DDL Script for Table ORAHYD.BASE_PROJECT_NOTES

-- Start of DDL Script for Table ORAHYD.BASE_ROAD_CONDITION
-- Generated 4-五月-2012 18:46:34 from ORAHYD@ORCL

CREATE TABLE base_road_condition
    (id                             NUMBER NOT NULL)
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





-- Comments for BASE_ROAD_CONDITION

COMMENT ON TABLE base_road_condition IS '路况信息表(未创建完成)'
/
COMMENT ON COLUMN base_road_condition.id IS '路况信息编号'
/

-- End of DDL Script for Table ORAHYD.BASE_ROAD_CONDITION

-- Start of DDL Script for Table ORAHYD.BASE_ROAD_TERM
-- Generated 4-五月-2012 18:46:34 from ORAHYD@ORCL

CREATE TABLE base_road_term
    (id                             NUMBER NOT NULL,
    roadname                       VARCHAR2(50) NOT NULL,
    linename                       VARCHAR2(50) NOT NULL,
    stakek                         NUMBER NOT NULL,
    stakem                         NUMBER NOT NULL,
    summary                        VARCHAR2(50) DEFAULT '无',
    comptime                       DATE DEFAULT SYSDATE NOT NULL,
    regtime                        DATE DEFAULT SYSDATE NOT NULL,
    photo                          VARCHAR2(200) NOT NULL,
    remark                         VARCHAR2(200) DEFAULT '无',
    status                         NUMBER DEFAULT 0 NOT NULL,
    typeid                         NUMBER NOT NULL,
    deptid                         NUMBER NOT NULL)
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





-- Constraints for BASE_ROAD_TERM

ALTER TABLE base_road_term
ADD CONSTRAINT pk_base_road_term PRIMARY KEY (id)
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


-- Triggers for BASE_ROAD_TERM

CREATE OR REPLACE TRIGGER trg_base_road_term
 BEFORE
  INSERT
 ON base_road_term
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_ROAD_TERM.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_ROAD_TERM

COMMENT ON TABLE base_road_term IS '路产设备信息表'
/
COMMENT ON COLUMN base_road_term.comptime IS '竣工时间'
/
COMMENT ON COLUMN base_road_term.deptid IS '部门编号'
/
COMMENT ON COLUMN base_road_term.id IS '路产设别编号'
/
COMMENT ON COLUMN base_road_term.linename IS '高速公路名称'
/
COMMENT ON COLUMN base_road_term.photo IS '设备照片'
/
COMMENT ON COLUMN base_road_term.regtime IS '登记时间'
/
COMMENT ON COLUMN base_road_term.remark IS '备注'
/
COMMENT ON COLUMN base_road_term.roadname IS '路产设备名称'
/
COMMENT ON COLUMN base_road_term.stakek IS '桩号（K）'
/
COMMENT ON COLUMN base_road_term.stakem IS '桩号（M）'
/
COMMENT ON COLUMN base_road_term.status IS '状态（0：正常，1删除）'
/
COMMENT ON COLUMN base_road_term.summary IS '位置描述'
/
COMMENT ON COLUMN base_road_term.typeid IS '路产设备类型编号'
/

-- End of DDL Script for Table ORAHYD.BASE_ROAD_TERM

-- Start of DDL Script for Table ORAHYD.BASE_ROAD_TERM_TYPE
-- Generated 4-五月-2012 18:46:34 from ORAHYD@ORCL

CREATE TABLE base_road_term_type
    (typeid                         NUMBER NOT NULL,
    typename                       VARCHAR2(50) NOT NULL)
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





-- Constraints for BASE_ROAD_TERM_TYPE

ALTER TABLE base_road_term_type
ADD CONSTRAINT pk_base_road_term_type PRIMARY KEY (typeid)
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


-- Triggers for BASE_ROAD_TERM_TYPE

CREATE OR REPLACE TRIGGER trg_base_road_term_type
 BEFORE
  INSERT
 ON base_road_term_type
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_ROAD_TERM_TYPE.NEXTVAL
     INTO :NEW.TYPEID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_ROAD_TERM_TYPE

COMMENT ON TABLE base_road_term_type IS '路产设备类型表'
/
COMMENT ON COLUMN base_road_term_type.typeid IS '路产设备类型编号'
/
COMMENT ON COLUMN base_road_term_type.typename IS '路产设备类型名称'
/

-- End of DDL Script for Table ORAHYD.BASE_ROAD_TERM_TYPE

-- Start of DDL Script for Table ORAHYD.BASE_ROLE
-- Generated 4-五月-2012 18:46:35 from ORAHYD@ORCL

CREATE TABLE base_role
    (roleid                         NUMBER NOT NULL,
    rolename                       VARCHAR2(50) NOT NULL,
    roleinfo                       VARCHAR2(20) NOT NULL)
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





-- Constraints for BASE_ROLE

ALTER TABLE base_role
ADD CONSTRAINT pk_base_role PRIMARY KEY (roleid)
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


-- Triggers for BASE_ROLE

CREATE OR REPLACE TRIGGER trg_base_role
 BEFORE
  INSERT
 ON base_role
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_ROLE.NEXTVAL
     INTO :NEW.ROLEID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_ROLE

COMMENT ON TABLE base_role IS '角色信息表'
/
COMMENT ON COLUMN base_role.roleid IS '角色编号'
/
COMMENT ON COLUMN base_role.roleinfo IS '角色描述'
/
COMMENT ON COLUMN base_role.rolename IS '角色名称'
/

-- End of DDL Script for Table ORAHYD.BASE_ROLE

-- Start of DDL Script for Table ORAHYD.BASE_SHOUWEN
-- Generated 4-五月-2012 18:46:35 from ORAHYD@ORCL

CREATE TABLE base_shouwen
    (sid                            NUMBER NOT NULL,
    s_numbers                      VARCHAR2(50),
    s_organ                        VARCHAR2(50),
    s_fromdate                     DATE,
    s_title                        VARCHAR2(50),
    s_handlingtime                 DATE,
    s_dep_organ                    VARCHAR2(50),
    s_handleprogress               VARCHAR2(50),
    s_result                       VARCHAR2(200),
    s_applicant                    VARCHAR2(50),
    s_handler                      VARCHAR2(50),
    remarks                        VARCHAR2(200),
    s_content                      VARCHAR2(300))
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





-- Comments for BASE_SHOUWEN

COMMENT ON TABLE base_shouwen IS '收文信息表'
/
COMMENT ON COLUMN base_shouwen.remarks IS '备注'
/
COMMENT ON COLUMN base_shouwen.s_applicant IS '申请人'
/
COMMENT ON COLUMN base_shouwen.s_content IS '来文内容'
/
COMMENT ON COLUMN base_shouwen.s_dep_organ IS '涉及相关运营管理单位'
/
COMMENT ON COLUMN base_shouwen.s_fromdate IS '来文时间'
/
COMMENT ON COLUMN base_shouwen.s_handleprogress IS '办理进度'
/
COMMENT ON COLUMN base_shouwen.s_handler IS '相关单位承办人'
/
COMMENT ON COLUMN base_shouwen.s_handlingtime IS '承办时间'
/
COMMENT ON COLUMN base_shouwen.s_numbers IS '原号'
/
COMMENT ON COLUMN base_shouwen.s_organ IS '来文机关'
/
COMMENT ON COLUMN base_shouwen.s_result IS '办理结果'
/
COMMENT ON COLUMN base_shouwen.s_title IS '标题'
/
COMMENT ON COLUMN base_shouwen.sid IS '收文信息 编号'
/

-- End of DDL Script for Table ORAHYD.BASE_SHOUWEN

-- Start of DDL Script for Table ORAHYD.BASE_TERM
-- Generated 4-五月-2012 18:46:35 from ORAHYD@ORCL

CREATE TABLE base_term
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





-- Constraints for BASE_TERM

ALTER TABLE base_term
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


-- Triggers for BASE_TERM

CREATE OR REPLACE TRIGGER trg_base_term
 BEFORE
  INSERT
 ON base_term
REFERENCING NEW AS NEW OLD AS OLD
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


-- Comments for BASE_TERM

COMMENT ON TABLE base_term IS '装备信息表'
/
COMMENT ON COLUMN base_term.brand IS '制造厂商'
/
COMMENT ON COLUMN base_term.deptid IS '所属部门'
/
COMMENT ON COLUMN base_term.format IS '规格型号'
/
COMMENT ON COLUMN base_term.remark IS '备注'
/
COMMENT ON COLUMN base_term.savepoint IS '存放地点'
/
COMMENT ON COLUMN base_term.serialcode IS '出厂编号'
/
COMMENT ON COLUMN base_term.status IS '状态（0：正常，1：删除）'
/
COMMENT ON COLUMN base_term.termcode IS '设备编号'
/
COMMENT ON COLUMN base_term.termid IS '编号'
/
COMMENT ON COLUMN base_term.termname IS '设备名称'
/
COMMENT ON COLUMN base_term.typeid IS '装备类型'
/
COMMENT ON COLUMN base_term.use IS '装备用途'
/
COMMENT ON COLUMN base_term.usetime IS '投入使用时间'
/

-- End of DDL Script for Table ORAHYD.BASE_TERM

-- Start of DDL Script for Table ORAHYD.BASE_TERM_TYPE
-- Generated 4-五月-2012 18:46:35 from ORAHYD@ORCL

CREATE TABLE base_term_type
    (typeid                         NUMBER NOT NULL,
    typename                       VARCHAR2(50) NOT NULL)
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





-- Constraints for BASE_TERM_TYPE

ALTER TABLE base_term_type
ADD CONSTRAINT pk_base_term_type PRIMARY KEY (typeid)
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


-- Triggers for BASE_TERM_TYPE

CREATE OR REPLACE TRIGGER trg_base_term_type
 BEFORE
  INSERT
 ON base_term_type
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_TERM_TYPE.NEXTVAL
     INTO :NEW.TYPEID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_TERM_TYPE

COMMENT ON TABLE base_term_type IS '装备类型表'
/
COMMENT ON COLUMN base_term_type.typeid IS '装备类型编号'
/
COMMENT ON COLUMN base_term_type.typename IS '装备类型名称'
/

-- End of DDL Script for Table ORAHYD.BASE_TERM_TYPE

-- Start of DDL Script for Table ORAHYD.BASE_USER
-- Generated 4-五月-2012 18:46:35 from ORAHYD@ORCL

CREATE TABLE base_user
    (userid                         NUMBER DEFAULT 0 NOT NULL,
    username                       VARCHAR2(50) NOT NULL,
    userpwd                        VARCHAR2(32) NOT NULL,
    parentid                       NUMBER DEFAULT 0 NOT NULL,
    sex                            NUMBER DEFAULT 0 NOT NULL,
    deptid                         NUMBER DEFAULT 0 NOT NULL,
    birthday                       DATE DEFAULT SYSDATE NOT NULL,
    degree                         VARCHAR2(50) NOT NULL,
    face                           VARCHAR2(50) NOT NULL,
    idnumber                       VARCHAR2(18) NOT NULL,
    jobnumber                      VARCHAR2(50) NOT NULL,
    photo                          VARCHAR2(200) NOT NULL,
    prof                           VARCHAR2(50) NOT NULL,
    remark                         VARCHAR2(50) DEFAULT '无',
    ststus                         NUMBER DEFAULT 0 NOT NULL)
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





-- Constraints for BASE_USER

ALTER TABLE base_user
ADD CONSTRAINT pk_base_user PRIMARY KEY (userid)
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


-- Triggers for BASE_USER

CREATE OR REPLACE TRIGGER trg_base_user
 BEFORE
  INSERT
 ON base_user
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_USER.NEXTVAL
     INTO :NEW.USERID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_USER

COMMENT ON TABLE base_user IS '用户信息表'
/
COMMENT ON COLUMN base_user.birthday IS '出生年月'
/
COMMENT ON COLUMN base_user.degree IS '学历'
/
COMMENT ON COLUMN base_user.deptid IS '用户所属部门'
/
COMMENT ON COLUMN base_user.face IS '政治面貌'
/
COMMENT ON COLUMN base_user.idnumber IS '身份证号码'
/
COMMENT ON COLUMN base_user.jobnumber IS '执法证号'
/
COMMENT ON COLUMN base_user.parentid IS '用户父ID编号（用于多个子账户）'
/
COMMENT ON COLUMN base_user.photo IS '人员照片'
/
COMMENT ON COLUMN base_user.prof IS '专业'
/
COMMENT ON COLUMN base_user.remark IS '备注'
/
COMMENT ON COLUMN base_user.sex IS '性别（0：男 1：女）'
/
COMMENT ON COLUMN base_user.ststus IS '状态（0：正常，1：删除）'
/
COMMENT ON COLUMN base_user.userid IS '用户ID编号'
/
COMMENT ON COLUMN base_user.username IS '用户账号（登录使用）'
/
COMMENT ON COLUMN base_user.userpwd IS '用户密码（登录使用）'
/

-- End of DDL Script for Table ORAHYD.BASE_USER

-- Start of DDL Script for Table ORAHYD.BASE_USER_ROLE
-- Generated 4-五月-2012 18:46:36 from ORAHYD@ORCL

CREATE TABLE base_user_role
    (userroleid                     NUMBER DEFAULT 0 NOT NULL,
    userid                         NUMBER DEFAULT 0 NOT NULL,
    roleid                         NUMBER DEFAULT 0 NOT NULL,
    menuid                         NUMBER DEFAULT 0 NOT NULL,
    actionid                       NUMBER DEFAULT 0 NOT NULL)
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





-- Constraints for BASE_USER_ROLE

ALTER TABLE base_user_role
ADD CONSTRAINT pk_base_user_role PRIMARY KEY (userroleid)
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


-- Triggers for BASE_USER_ROLE

CREATE OR REPLACE TRIGGER trg_base_user_role
 BEFORE
  INSERT
 ON base_user_role
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_USER_ROLE.NEXTVAL
     INTO :NEW.USERROLEID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_USER_ROLE

COMMENT ON TABLE base_user_role IS '用户角色信息表'
/
COMMENT ON COLUMN base_user_role.actionid IS '用户模块操作权限'
/
COMMENT ON COLUMN base_user_role.menuid IS '菜单编号'
/
COMMENT ON COLUMN base_user_role.roleid IS '角色编号'
/
COMMENT ON COLUMN base_user_role.userid IS '用户编号'
/
COMMENT ON COLUMN base_user_role.userroleid IS '用户角色编号'
/

-- End of DDL Script for Table ORAHYD.BASE_USER_ROLE

