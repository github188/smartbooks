-- Start of DDL Script for Table ORAHYD.BASE_ACTION
-- Generated 4-����-2012 18:46:29 from ORAHYD@ORCL

CREATE TABLE base_action
    (actionid                       NUMBER DEFAULT 0 NOT NULL,
    actionname                     VARCHAR2(50) NOT NULL,
    status                         NUMBER DEFAULT 0 NOT NULL,
    actioninfo                     VARCHAR2(50) DEFAULT '��' NOT NULL)
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

COMMENT ON TABLE base_action IS '������Ϣ��'
/
COMMENT ON COLUMN base_action.actionid IS '�������'
/
COMMENT ON COLUMN base_action.actioninfo IS '��������'
/
COMMENT ON COLUMN base_action.actionname IS '��������'
/
COMMENT ON COLUMN base_action.status IS '״̬��0������ 1�رգ�'
/

-- End of DDL Script for Table ORAHYD.BASE_ACTION

-- Start of DDL Script for Table ORAHYD.BASE_AFFICHE
-- Generated 4-����-2012 18:46:29 from ORAHYD@ORCL

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

COMMENT ON TABLE base_affiche IS '������Ϣ��'
/
COMMENT ON COLUMN base_affiche.affichecontents IS '��������'
/
COMMENT ON COLUMN base_affiche.affichedate IS '���淢��ʱ��'
/
COMMENT ON COLUMN base_affiche.afficheid IS '������'
/
COMMENT ON COLUMN base_affiche.afficher IS '���淢����'
/
COMMENT ON COLUMN base_affiche.affichetitle IS '�������'
/

-- End of DDL Script for Table ORAHYD.BASE_AFFICHE

-- Start of DDL Script for Table ORAHYD.BASE_AREA
-- Generated 4-����-2012 18:46:29 from ORAHYD@ORCL

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
    detailed                       VARCHAR2(200) DEFAULT '��' NOT NULL,
    status                         VARCHAR2(200) DEFAULT '��' NOT NULL,
    remark                         VARCHAR2(200) DEFAULT '��' NOT NULL,
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

COMMENT ON TABLE base_area IS '������Υ����Ϣ��'
/
COMMENT ON COLUMN base_area.areaname IS 'Υ������'
/
COMMENT ON COLUMN base_area.comptime IS '����ʱ��'
/
COMMENT ON COLUMN base_area.deptid IS '���ű��'
/
COMMENT ON COLUMN base_area.detailed IS '��ϸ����'
/
COMMENT ON COLUMN base_area.id IS '���'
/
COMMENT ON COLUMN base_area.linename IS '��·����'
/
COMMENT ON COLUMN base_area.owner IS '��������'
/
COMMENT ON COLUMN base_area.photo IS '�ֳ���Ƭ'
/
COMMENT ON COLUMN base_area.regtime IS '�Ǽ�ʱ��'
/
COMMENT ON COLUMN base_area.remark IS '��ϸ��ע'
/
COMMENT ON COLUMN base_area.stakek IS '׮�ţ�K��'
/
COMMENT ON COLUMN base_area.stakem IS '׮�ţ�M��'
/
COMMENT ON COLUMN base_area.status IS '��״����'
/
COMMENT ON COLUMN base_area.summary IS 'λ������'
/
COMMENT ON COLUMN base_area.typeid IS '������'
/

-- End of DDL Script for Table ORAHYD.BASE_AREA

-- Start of DDL Script for Table ORAHYD.BASE_AREA_TYPE
-- Generated 4-����-2012 18:46:30 from ORAHYD@ORCL

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

COMMENT ON TABLE base_area_type IS '������Υ�����ͱ�'
/
COMMENT ON COLUMN base_area_type.typeid IS 'id,����������'
/
COMMENT ON COLUMN base_area_type.typename IS '��������'
/

-- End of DDL Script for Table ORAHYD.BASE_AREA_TYPE

-- Start of DDL Script for Table ORAHYD.BASE_ASSESS
-- Generated 4-����-2012 18:46:30 from ORAHYD@ORCL

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

COMMENT ON TABLE base_assess IS '������Ϣ��'
/
COMMENT ON COLUMN base_assess.assesscontent IS 'Ŀ������'
/
COMMENT ON COLUMN base_assess.assesscriterion IS '���˱�׼'
/
COMMENT ON COLUMN base_assess.assessdept IS '������Ŀ������λ'
/
COMMENT ON COLUMN base_assess.assessdescription IS '������Ϣ��ע'
/
COMMENT ON COLUMN base_assess.assessformat IS '������ʽ'
/
COMMENT ON COLUMN base_assess.assessid IS '������Ϣ���'
/
COMMENT ON COLUMN base_assess.assessname IS '������Ŀ����'
/
COMMENT ON COLUMN base_assess.assessresult IS '���˷�ֵ'
/
COMMENT ON COLUMN base_assess.assesstime IS '�ϱ�ʱ��'
/

-- End of DDL Script for Table ORAHYD.BASE_ASSESS

-- Start of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN
-- Generated 4-����-2012 18:46:30 from ORAHYD@ORCL

CREATE TABLE base_bus_overrun
    (id                             NUMBER NOT NULL,
    buscode                        VARCHAR2(20) NOT NULL,
    inname                         VARCHAR2(50) NOT NULL,
    intime                         DATE DEFAULT SYSDATE NOT NULL,
    outname                        VARCHAR2(50) NOT NULL,
    outtime                        DATE DEFAULT SYSDATE NOT NULL,
    pay                            VARCHAR2(20) DEFAULT '�ֽ�' NOT NULL,
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

COMMENT ON TABLE base_bus_overrun IS '���ٹ�·���޳������ݱ�'
/
COMMENT ON COLUMN base_bus_overrun.axis IS '����'
/
COMMENT ON COLUMN base_bus_overrun.buscode IS '���ƺ���'
/
COMMENT ON COLUMN base_bus_overrun.id IS 'ID���'
/
COMMENT ON COLUMN base_bus_overrun.inname IS '���վ��'
/
COMMENT ON COLUMN base_bus_overrun.intime IS '���ʱ��'
/
COMMENT ON COLUMN base_bus_overrun.mileage IS '���'
/
COMMENT ON COLUMN base_bus_overrun.money IS '���'
/
COMMENT ON COLUMN base_bus_overrun.outname IS '����վ��'
/
COMMENT ON COLUMN base_bus_overrun.outtime IS '����ʱ��'
/
COMMENT ON COLUMN base_bus_overrun.overloadrate IS '������'
/
COMMENT ON COLUMN base_bus_overrun.pay IS '֧����ʽ'
/
COMMENT ON COLUMN base_bus_overrun.totalweight IS '����'
/

-- End of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN

-- Start of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN_SUBMIT
-- Generated 4-����-2012 18:46:30 from ORAHYD@ORCL

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
    remarks                        VARCHAR2(50) DEFAULT '��')
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

COMMENT ON TABLE base_bus_overrun_submit IS '�鴦�Ƿ����޳�������'
/
COMMENT ON COLUMN base_bus_overrun_submit.buscode IS '���ƺ���'
/
COMMENT ON COLUMN base_bus_overrun_submit.busheight IS '�߶�'
/
COMMENT ON COLUMN base_bus_overrun_submit.buslong IS '�����ܳ�'
/
COMMENT ON COLUMN base_bus_overrun_submit.busunit IS '����������λ'
/
COMMENT ON COLUMN base_bus_overrun_submit.buswidth IS '���'
/
COMMENT ON COLUMN base_bus_overrun_submit.deptid IS '�鴦��λ'
/
COMMENT ON COLUMN base_bus_overrun_submit.id IS 'id������������'
/
COMMENT ON COLUMN base_bus_overrun_submit.inname IS '���վ����'
/
COMMENT ON COLUMN base_bus_overrun_submit.location IS '�鴦�ص�'
/
COMMENT ON COLUMN base_bus_overrun_submit.outname IS '����վ����'
/
COMMENT ON COLUMN base_bus_overrun_submit.photo IS '������Ƭ'
/
COMMENT ON COLUMN base_bus_overrun_submit.remarks IS '��ע'
/
COMMENT ON COLUMN base_bus_overrun_submit.ticktime IS '�鴦ʱ��'
/
COMMENT ON COLUMN base_bus_overrun_submit.userid IS '�鴦��'
/
COMMENT ON COLUMN base_bus_overrun_submit.weight IS '������'
/

-- End of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN_SUBMIT

-- Start of DDL Script for Table ORAHYD.BASE_CASE
-- Generated 4-����-2012 18:46:31 from ORAHYD@ORCL

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

COMMENT ON TABLE base_case IS '·��������'
/
COMMENT ON COLUMN base_case.accidentcause IS '�¹ʷ���ԭ��'
/
COMMENT ON COLUMN base_case.accidenttype IS '�¹�����'
/
COMMENT ON COLUMN base_case.action IS '����'
/
COMMENT ON COLUMN base_case.busloss IS '������ʧ'
/
COMMENT ON COLUMN base_case.casecode IS '�������'
/
COMMENT ON COLUMN base_case.createtime IS '��������'
/
COMMENT ON COLUMN base_case.death IS '��������'
/
COMMENT ON COLUMN base_case.id IS '���'
/
COMMENT ON COLUMN base_case.inquest IS '��������'
/
COMMENT ON COLUMN base_case.inquestbegintime IS '������ʱ����'
/
COMMENT ON COLUMN base_case.inquestduty IS '��������ְ��'
/
COMMENT ON COLUMN base_case.inquestendtime IS '������ʱ��ֹ'
/
COMMENT ON COLUMN base_case.inquestid IS '��������ִ��֤���'
/
COMMENT ON COLUMN base_case.invite IS '��������'
/
COMMENT ON COLUMN base_case.inviteduty IS '��������ְ��'
/
COMMENT ON COLUMN base_case.invitetel IS '�������˵绰'
/
COMMENT ON COLUMN base_case.launch IS '������'
/
COMMENT ON COLUMN base_case.light IS '��������'
/
COMMENT ON COLUMN base_case.linename IS '��·����'
/
COMMENT ON COLUMN base_case.linetype IS '·������'
/
COMMENT ON COLUMN base_case.presenters IS '�참������'
/
COMMENT ON COLUMN base_case.presentersduty IS '�참������ְ��'
/
COMMENT ON COLUMN base_case.presentersid IS '�참������ִ��֤���'
/
COMMENT ON COLUMN base_case.stakek IS '׮�ţ�K��'
/
COMMENT ON COLUMN base_case.stakem IS '׮�ţ�M��'
/
COMMENT ON COLUMN base_case.summary IS '����ժҪ'
/
COMMENT ON COLUMN base_case.ticktime IS '����ʱ��'
/
COMMENT ON COLUMN base_case.userid IS '�����Ǽ���'
/
COMMENT ON COLUMN base_case.weather IS '�������'
/
COMMENT ON COLUMN base_case.weight IS '��������'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE

-- Start of DDL Script for Table ORAHYD.BASE_CASE_BUS
-- Generated 4-����-2012 18:46:31 from ORAHYD@ORCL

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

COMMENT ON TABLE base_case_bus IS '·��������������Ա��Ϣ��'
/
COMMENT ON COLUMN base_case_bus.address IS '������λ���ַ'
/
COMMENT ON COLUMN base_case_bus.age IS '����'
/
COMMENT ON COLUMN base_case_bus.attrib IS '������'
/
COMMENT ON COLUMN base_case_bus.busnumber IS '���ƺ���'
/
COMMENT ON COLUMN base_case_bus.bustype IS '��������'
/
COMMENT ON COLUMN base_case_bus.cardid IS '֤������'
/
COMMENT ON COLUMN base_case_bus.caseid IS '�������'
/
COMMENT ON COLUMN base_case_bus.driving IS '����'
/
COMMENT ON COLUMN base_case_bus.id IS 'ID���'
/
COMMENT ON COLUMN base_case_bus.label IS '����'
/
COMMENT ON COLUMN base_case_bus.party IS '������'
/
COMMENT ON COLUMN base_case_bus.pattern IS '�ͺ�'
/
COMMENT ON COLUMN base_case_bus.phone IS '��ϵ�绰'
/
COMMENT ON COLUMN base_case_bus.sex IS '�Ա�0���� 1��Ů��'
/
COMMENT ON COLUMN base_case_bus.zipcode IS '�ʱ�'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE_BUS

-- Start of DDL Script for Table ORAHYD.BASE_CASE_CLOSED
-- Generated 4-����-2012 18:46:31 from ORAHYD@ORCL

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

COMMENT ON TABLE base_case_closed IS '·���������鰸�᰸��'
/
COMMENT ON COLUMN base_case_closed.caseid IS '�������'
/
COMMENT ON COLUMN base_case_closed.closedeay IS '�᰸��ʽ'
/
COMMENT ON COLUMN base_case_closed.closedtime IS '�᰸����'
/
COMMENT ON COLUMN base_case_closed.discuss IS '�������'
/
COMMENT ON COLUMN base_case_closed.lead IS '�����쵼���'
/
COMMENT ON COLUMN base_case_closed.motionlocation IS '�鰸�ص�'
/
COMMENT ON COLUMN base_case_closed.motionpro IS '������'
/
COMMENT ON COLUMN base_case_closed.motiontime IS '�鰸ʱ��'
/
COMMENT ON COLUMN base_case_closed.record IS '�鰸��¼��'
/
COMMENT ON COLUMN base_case_closed.recoverloss IS '׷����ʧ'
/
COMMENT ON COLUMN base_case_closed.remark IS '��ע'
/
COMMENT ON COLUMN base_case_closed.result IS '������'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE_CLOSED

-- Start of DDL Script for Table ORAHYD.BASE_CASE_LOSS
-- Generated 4-����-2012 18:46:32 from ORAHYD@ORCL

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

COMMENT ON TABLE base_case_loss IS '·��������ʧ��'
/
COMMENT ON COLUMN base_case_loss.amount IS '��ʧ��λ��'
/
COMMENT ON COLUMN base_case_loss.caseid IS '·���������'
/
COMMENT ON COLUMN base_case_loss.compsid IS '�⳥��Ŀ��׼'
/
COMMENT ON COLUMN base_case_loss.id IS 'id,primary'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE_LOSS

-- Start of DDL Script for Table ORAHYD.BASE_COMPS
-- Generated 4-����-2012 18:46:32 from ORAHYD@ORCL

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

COMMENT ON TABLE base_comps IS '�⳥��׼��Ϣ��'
/
COMMENT ON COLUMN base_comps.compsname IS '��Ŀ����'
/
COMMENT ON COLUMN base_comps.money IS '������ң�'
/
COMMENT ON COLUMN base_comps.remark IS '��ע'
/
COMMENT ON COLUMN base_comps.unit IS '��λ'
/

-- End of DDL Script for Table ORAHYD.BASE_COMPS

-- Start of DDL Script for Table ORAHYD.BASE_DEPT
-- Generated 4-����-2012 18:46:32 from ORAHYD@ORCL

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

COMMENT ON TABLE base_dept IS '������Ϣ��'
/
COMMENT ON COLUMN base_dept.deptid IS '���ű��'
/
COMMENT ON COLUMN base_dept.dptinfo IS '��������'
/
COMMENT ON COLUMN base_dept.dptname IS '��������'
/
COMMENT ON COLUMN base_dept.parentid IS '�ϼ����ű�ţ����ڵ�0��'
/
COMMENT ON COLUMN base_dept.status IS '״̬��0������ 1���رգ�'
/

-- End of DDL Script for Table ORAHYD.BASE_DEPT

-- Start of DDL Script for Table ORAHYD.BASE_FILES
-- Generated 4-����-2012 18:46:32 from ORAHYD@ORCL

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

COMMENT ON TABLE base_files IS '�ļ�������Ϣ��'
/
COMMENT ON COLUMN base_files.c_dates IS '�鵵ʱ��'
/
COMMENT ON COLUMN base_files.cartular_numbers IS '�ĺ�'
/
COMMENT ON COLUMN base_files.cartularstate IS '����״̬'
/
COMMENT ON COLUMN base_files.cartularydescription IS '��������'
/
COMMENT ON COLUMN base_files.cartularyid IS '�������'
/
COMMENT ON COLUMN base_files.cartularyname IS '��������'
/
COMMENT ON COLUMN base_files.cartularysrc IS '�����洢·��'
/
COMMENT ON COLUMN base_files.cartularytypes IS '��������'
/

-- End of DDL Script for Table ORAHYD.BASE_FILES

-- Start of DDL Script for Table ORAHYD.BASE_LICENSE_ACCEPT
-- Generated 4-����-2012 18:46:32 from ORAHYD@ORCL

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

COMMENT ON TABLE base_license_accept IS '·����������'
/
COMMENT ON COLUMN base_license_accept.address IS '������סַ'
/
COMMENT ON COLUMN base_license_accept.audit_desc IS '������'
/
COMMENT ON COLUMN base_license_accept.audit_reply IS '����ظ�'
/
COMMENT ON COLUMN base_license_accept.audit_state IS '���״̬'
/
COMMENT ON COLUMN base_license_accept.auditor IS '�����'
/
COMMENT ON COLUMN base_license_accept.creatdate IS '��������'
/
COMMENT ON COLUMN base_license_accept.deputy IS 'ί�д�����'
/
COMMENT ON COLUMN base_license_accept.email IS '����'
/
COMMENT ON COLUMN base_license_accept.file_path IS '����·��'
/
COMMENT ON COLUMN base_license_accept.mark IS '��ע'
/
COMMENT ON COLUMN base_license_accept.materials IS '�������Ŀ¼'
/
COMMENT ON COLUMN base_license_accept.phone IS '�ֻ�'
/
COMMENT ON COLUMN base_license_accept.post IS '�ʱ�'
/
COMMENT ON COLUMN base_license_accept.requisitioncontent IS '��������������'
/
COMMENT ON COLUMN base_license_accept.requisitionid IS '��������'
/
COMMENT ON COLUMN base_license_accept.requisitionname IS '�����˼���������������'
/
COMMENT ON COLUMN base_license_accept.tel IS '�绰'
/

-- End of DDL Script for Table ORAHYD.BASE_LICENSE_ACCEPT

-- Start of DDL Script for Table ORAHYD.BASE_LOG
-- Generated 4-����-2012 18:46:33 from ORAHYD@ORCL

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

COMMENT ON TABLE base_log IS 'ϵͳ��־��'
/
COMMENT ON COLUMN base_log.createdate IS '��־����ʱ��'
/
COMMENT ON COLUMN base_log.description IS '��־��Ϣ����'
/
COMMENT ON COLUMN base_log.logid IS '��־���'
/
COMMENT ON COLUMN base_log.logtype IS '��־����'
/
COMMENT ON COLUMN base_log.operatorid IS '������'
/

-- End of DDL Script for Table ORAHYD.BASE_LOG

-- Start of DDL Script for Table ORAHYD.BASE_MENU
-- Generated 4-����-2012 18:46:33 from ORAHYD@ORCL

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

COMMENT ON TABLE base_menu IS '�˵���Ϣ��'
/
COMMENT ON COLUMN base_menu.icon IS '�˵�ͼ��'
/
COMMENT ON COLUMN base_menu.menuid IS '�˵����'
/
COMMENT ON COLUMN base_menu.menuinfo IS '�˵�˵��'
/
COMMENT ON COLUMN base_menu.menuname IS '�˵�����'
/
COMMENT ON COLUMN base_menu.menuurl IS '�˵�URL��ַ'
/
COMMENT ON COLUMN base_menu.parentid IS '���˵���ţ����ڵ�0��'
/
COMMENT ON COLUMN base_menu.status IS '״̬��0������ 1���رգ�'
/

-- End of DDL Script for Table ORAHYD.BASE_MENU

-- Start of DDL Script for Table ORAHYD.BASE_MESSAGE
-- Generated 4-����-2012 18:46:33 from ORAHYD@ORCL

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

COMMENT ON TABLE base_message IS '��Ϣ��¼��Ϣ��'
/
COMMENT ON COLUMN base_message.messagebody IS '��Ϣ����'
/
COMMENT ON COLUMN base_message.messageid IS '��Ϣ���'
/
COMMENT ON COLUMN base_message.senddate IS '����ʱ��'
/
COMMENT ON COLUMN base_message.sender IS '�����߱��'
/
COMMENT ON COLUMN base_message.state IS '��Ϣ״̬��0δ����1�Ѷ���'
/
COMMENT ON COLUMN base_message.touser IS '�����߱��'
/

-- End of DDL Script for Table ORAHYD.BASE_MESSAGE

-- Start of DDL Script for Table ORAHYD.BASE_OBSERVED
-- Generated 4-����-2012 18:46:33 from ORAHYD@ORCL

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

COMMENT ON TABLE base_observed IS '����Ѳ����־��'
/
COMMENT ON COLUMN base_observed.begintime IS 'Ѳ�鿪ʼʱ��'
/
COMMENT ON COLUMN base_observed.enddate IS 'Ѳ�����ʱ��'
/
COMMENT ON COLUMN base_observed.log IS 'Ѳ�鴦�����'
/
COMMENT ON COLUMN base_observed.observedid IS '����Ѳ����־���'
/
COMMENT ON COLUMN base_observed.patroluser IS 'Ѳ����Ա'
/
COMMENT ON COLUMN base_observed.weather IS '����'
/

-- End of DDL Script for Table ORAHYD.BASE_OBSERVED

-- Start of DDL Script for Table ORAHYD.BASE_PATROL
-- Generated 4-����-2012 18:46:33 from ORAHYD@ORCL

CREATE TABLE base_patrol
    (patrolid                       NUMBER NOT NULL,
    deptid                         NUMBER NOT NULL,
    respuser                       NUMBER NOT NULL,
    patroluser                     NUMBER NOT NULL,
    busnumber                      VARCHAR2(20) NOT NULL,
    mileage                        NUMBER DEFAULT 0 NOT NULL,
    weather                        VARCHAR2(50) NOT NULL,
    log                            VARCHAR2(500) DEFAULT '��' NOT NULL,
    begintime                      DATE DEFAULT SYSDATE NOT NULL,
    endtime                        DATE DEFAULT SYSDATE NOT NULL,
    transfer                       NUMBER NOT NULL,
    accept                         NUMBER NOT NULL,
    within                         VARCHAR2(500) DEFAULT '��' NOT NULL,
    nextwithin                     VARCHAR2(500) DEFAULT '��' NOT NULL,
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

COMMENT ON TABLE base_patrol IS '�˹�Ѳ����־��'
/
COMMENT ON COLUMN base_patrol.accept IS '������'
/
COMMENT ON COLUMN base_patrol.acceptbusnumber IS '�Ӱ�Ѳ�߳��ƺ�'
/
COMMENT ON COLUMN base_patrol.acceptcaptain IS '�Ӱ��жӳ�'
/
COMMENT ON COLUMN base_patrol.begintime IS 'Ѳ�鿪ʼʱ��'
/
COMMENT ON COLUMN base_patrol.buskm IS '�Ӱ�Ѳ�߳���̱�KM��'
/
COMMENT ON COLUMN base_patrol.busnumber IS 'Ѳ�鳵�ƺ�'
/
COMMENT ON COLUMN base_patrol.deptid IS 'Ѳ���ж�'
/
COMMENT ON COLUMN base_patrol.endtime IS 'Ѳ�����ʱ��'
/
COMMENT ON COLUMN base_patrol.log IS 'Ѳ�鴦�����'
/
COMMENT ON COLUMN base_patrol.mileage IS 'Ѳ�����'
/
COMMENT ON COLUMN base_patrol.nextwithin IS '�ƽ��°ദ������'
/
COMMENT ON COLUMN base_patrol.patrolid IS 'Ѳ����־ID'
/
COMMENT ON COLUMN base_patrol.patroluser IS 'Ѳ����Ա'
/
COMMENT ON COLUMN base_patrol.respuser IS 'Ѳ�鸺����'
/
COMMENT ON COLUMN base_patrol.shiftcaptain IS '�����жӳ�'
/
COMMENT ON COLUMN base_patrol.ticktime IS '���Ӱ�ʱ��'
/
COMMENT ON COLUMN base_patrol.transfer IS '�ƽ���'
/
COMMENT ON COLUMN base_patrol.weather IS '����'
/
COMMENT ON COLUMN base_patrol.within IS '�ƽ���ҵ��������'
/

-- End of DDL Script for Table ORAHYD.BASE_PATROL

-- Start of DDL Script for Table ORAHYD.BASE_PATROL_GOODS
-- Generated 4-����-2012 18:46:34 from ORAHYD@ORCL

CREATE TABLE base_patrol_goods
    (patrolgoodsid                  NUMBER NOT NULL,
    patrolid                       NUMBER NOT NULL,
    amount                         NUMBER DEFAULT 0 NOT NULL,
    toolname                       VARCHAR2(50) DEFAULT '��' NOT NULL)
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

COMMENT ON TABLE base_patrol_goods IS '�ƽ����ı�'
/
COMMENT ON COLUMN base_patrol_goods.amount IS '��������'
/
COMMENT ON COLUMN base_patrol_goods.patrolgoodsid IS '���'
/
COMMENT ON COLUMN base_patrol_goods.patrolid IS 'Ѳ����־���'
/
COMMENT ON COLUMN base_patrol_goods.toolname IS '��������'
/

-- End of DDL Script for Table ORAHYD.BASE_PATROL_GOODS

-- Start of DDL Script for Table ORAHYD.BASE_PLAN
-- Generated 4-����-2012 18:46:34 from ORAHYD@ORCL

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

COMMENT ON TABLE base_plan IS '�ճ���Ϣ��'
/
COMMENT ON COLUMN base_plan.calendarcontent IS '�ճ�����'
/
COMMENT ON COLUMN base_plan.calendarid IS '�ճ���Ϣ���'
/
COMMENT ON COLUMN base_plan.calendarremind IS '����ʱ��'
/
COMMENT ON COLUMN base_plan.end_date IS '����ʱ��'
/
COMMENT ON COLUMN base_plan.start_date IS '��ʼʱ��'
/
COMMENT ON COLUMN base_plan.userid IS '�û����'
/

-- End of DDL Script for Table ORAHYD.BASE_PLAN

-- Start of DDL Script for Table ORAHYD.BASE_PROCEDURE
-- Generated 4-����-2012 18:46:34 from ORAHYD@ORCL

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

COMMENT ON TABLE base_procedure IS '·��������̱�'
/
COMMENT ON COLUMN base_procedure.contents IS '�������'
/
COMMENT ON COLUMN base_procedure.department IS '����λ(����)'
/
COMMENT ON COLUMN base_procedure.p_date IS '����ʱ��'
/
COMMENT ON COLUMN base_procedure.pid IS '���'
/
COMMENT ON COLUMN base_procedure.requisitionid IS '·��������뵥���'
/
COMMENT ON COLUMN base_procedure.result IS '������'
/
COMMENT ON COLUMN base_procedure.transactor IS '������'
/

-- End of DDL Script for Table ORAHYD.BASE_PROCEDURE

-- Start of DDL Script for Table ORAHYD.BASE_PROJECT_NOTES
-- Generated 4-����-2012 18:46:34 from ORAHYD@ORCL

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

COMMENT ON TABLE base_project_notes IS '������Ŀ��¼��'
/
COMMENT ON COLUMN base_project_notes.assessid IS '������Ϣ���'
/
COMMENT ON COLUMN base_project_notes.pid IS '���'
/
COMMENT ON COLUMN base_project_notes.reply_content IS '������������'
/
COMMENT ON COLUMN base_project_notes.reply_date IS '����ʱ��'
/
COMMENT ON COLUMN base_project_notes.reply_preson IS '������'
/
COMMENT ON COLUMN base_project_notes.score IS '��ֵ'
/

-- End of DDL Script for Table ORAHYD.BASE_PROJECT_NOTES

-- Start of DDL Script for Table ORAHYD.BASE_ROAD_CONDITION
-- Generated 4-����-2012 18:46:34 from ORAHYD@ORCL

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

COMMENT ON TABLE base_road_condition IS '·����Ϣ��(δ�������)'
/
COMMENT ON COLUMN base_road_condition.id IS '·����Ϣ���'
/

-- End of DDL Script for Table ORAHYD.BASE_ROAD_CONDITION

-- Start of DDL Script for Table ORAHYD.BASE_ROAD_TERM
-- Generated 4-����-2012 18:46:34 from ORAHYD@ORCL

CREATE TABLE base_road_term
    (id                             NUMBER NOT NULL,
    roadname                       VARCHAR2(50) NOT NULL,
    linename                       VARCHAR2(50) NOT NULL,
    stakek                         NUMBER NOT NULL,
    stakem                         NUMBER NOT NULL,
    summary                        VARCHAR2(50) DEFAULT '��',
    comptime                       DATE DEFAULT SYSDATE NOT NULL,
    regtime                        DATE DEFAULT SYSDATE NOT NULL,
    photo                          VARCHAR2(200) NOT NULL,
    remark                         VARCHAR2(200) DEFAULT '��',
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

COMMENT ON TABLE base_road_term IS '·���豸��Ϣ��'
/
COMMENT ON COLUMN base_road_term.comptime IS '����ʱ��'
/
COMMENT ON COLUMN base_road_term.deptid IS '���ű��'
/
COMMENT ON COLUMN base_road_term.id IS '·�������'
/
COMMENT ON COLUMN base_road_term.linename IS '���ٹ�·����'
/
COMMENT ON COLUMN base_road_term.photo IS '�豸��Ƭ'
/
COMMENT ON COLUMN base_road_term.regtime IS '�Ǽ�ʱ��'
/
COMMENT ON COLUMN base_road_term.remark IS '��ע'
/
COMMENT ON COLUMN base_road_term.roadname IS '·���豸����'
/
COMMENT ON COLUMN base_road_term.stakek IS '׮�ţ�K��'
/
COMMENT ON COLUMN base_road_term.stakem IS '׮�ţ�M��'
/
COMMENT ON COLUMN base_road_term.status IS '״̬��0��������1ɾ����'
/
COMMENT ON COLUMN base_road_term.summary IS 'λ������'
/
COMMENT ON COLUMN base_road_term.typeid IS '·���豸���ͱ��'
/

-- End of DDL Script for Table ORAHYD.BASE_ROAD_TERM

-- Start of DDL Script for Table ORAHYD.BASE_ROAD_TERM_TYPE
-- Generated 4-����-2012 18:46:34 from ORAHYD@ORCL

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

COMMENT ON TABLE base_road_term_type IS '·���豸���ͱ�'
/
COMMENT ON COLUMN base_road_term_type.typeid IS '·���豸���ͱ��'
/
COMMENT ON COLUMN base_road_term_type.typename IS '·���豸��������'
/

-- End of DDL Script for Table ORAHYD.BASE_ROAD_TERM_TYPE

-- Start of DDL Script for Table ORAHYD.BASE_ROLE
-- Generated 4-����-2012 18:46:35 from ORAHYD@ORCL

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

COMMENT ON TABLE base_role IS '��ɫ��Ϣ��'
/
COMMENT ON COLUMN base_role.roleid IS '��ɫ���'
/
COMMENT ON COLUMN base_role.roleinfo IS '��ɫ����'
/
COMMENT ON COLUMN base_role.rolename IS '��ɫ����'
/

-- End of DDL Script for Table ORAHYD.BASE_ROLE

-- Start of DDL Script for Table ORAHYD.BASE_SHOUWEN
-- Generated 4-����-2012 18:46:35 from ORAHYD@ORCL

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

COMMENT ON TABLE base_shouwen IS '������Ϣ��'
/
COMMENT ON COLUMN base_shouwen.remarks IS '��ע'
/
COMMENT ON COLUMN base_shouwen.s_applicant IS '������'
/
COMMENT ON COLUMN base_shouwen.s_content IS '��������'
/
COMMENT ON COLUMN base_shouwen.s_dep_organ IS '�漰�����Ӫ����λ'
/
COMMENT ON COLUMN base_shouwen.s_fromdate IS '����ʱ��'
/
COMMENT ON COLUMN base_shouwen.s_handleprogress IS '�������'
/
COMMENT ON COLUMN base_shouwen.s_handler IS '��ص�λ�а���'
/
COMMENT ON COLUMN base_shouwen.s_handlingtime IS '�а�ʱ��'
/
COMMENT ON COLUMN base_shouwen.s_numbers IS 'ԭ��'
/
COMMENT ON COLUMN base_shouwen.s_organ IS '���Ļ���'
/
COMMENT ON COLUMN base_shouwen.s_result IS '������'
/
COMMENT ON COLUMN base_shouwen.s_title IS '����'
/
COMMENT ON COLUMN base_shouwen.sid IS '������Ϣ ���'
/

-- End of DDL Script for Table ORAHYD.BASE_SHOUWEN

-- Start of DDL Script for Table ORAHYD.BASE_TERM
-- Generated 4-����-2012 18:46:35 from ORAHYD@ORCL

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

COMMENT ON TABLE base_term IS 'װ����Ϣ��'
/
COMMENT ON COLUMN base_term.brand IS '���쳧��'
/
COMMENT ON COLUMN base_term.deptid IS '��������'
/
COMMENT ON COLUMN base_term.format IS '����ͺ�'
/
COMMENT ON COLUMN base_term.remark IS '��ע'
/
COMMENT ON COLUMN base_term.savepoint IS '��ŵص�'
/
COMMENT ON COLUMN base_term.serialcode IS '�������'
/
COMMENT ON COLUMN base_term.status IS '״̬��0��������1��ɾ����'
/
COMMENT ON COLUMN base_term.termcode IS '�豸���'
/
COMMENT ON COLUMN base_term.termid IS '���'
/
COMMENT ON COLUMN base_term.termname IS '�豸����'
/
COMMENT ON COLUMN base_term.typeid IS 'װ������'
/
COMMENT ON COLUMN base_term.use IS 'װ����;'
/
COMMENT ON COLUMN base_term.usetime IS 'Ͷ��ʹ��ʱ��'
/

-- End of DDL Script for Table ORAHYD.BASE_TERM

-- Start of DDL Script for Table ORAHYD.BASE_TERM_TYPE
-- Generated 4-����-2012 18:46:35 from ORAHYD@ORCL

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

COMMENT ON TABLE base_term_type IS 'װ�����ͱ�'
/
COMMENT ON COLUMN base_term_type.typeid IS 'װ�����ͱ��'
/
COMMENT ON COLUMN base_term_type.typename IS 'װ����������'
/

-- End of DDL Script for Table ORAHYD.BASE_TERM_TYPE

-- Start of DDL Script for Table ORAHYD.BASE_USER
-- Generated 4-����-2012 18:46:35 from ORAHYD@ORCL

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
    remark                         VARCHAR2(50) DEFAULT '��',
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

COMMENT ON TABLE base_user IS '�û���Ϣ��'
/
COMMENT ON COLUMN base_user.birthday IS '��������'
/
COMMENT ON COLUMN base_user.degree IS 'ѧ��'
/
COMMENT ON COLUMN base_user.deptid IS '�û���������'
/
COMMENT ON COLUMN base_user.face IS '������ò'
/
COMMENT ON COLUMN base_user.idnumber IS '���֤����'
/
COMMENT ON COLUMN base_user.jobnumber IS 'ִ��֤��'
/
COMMENT ON COLUMN base_user.parentid IS '�û���ID��ţ����ڶ�����˻���'
/
COMMENT ON COLUMN base_user.photo IS '��Ա��Ƭ'
/
COMMENT ON COLUMN base_user.prof IS 'רҵ'
/
COMMENT ON COLUMN base_user.remark IS '��ע'
/
COMMENT ON COLUMN base_user.sex IS '�Ա�0���� 1��Ů��'
/
COMMENT ON COLUMN base_user.ststus IS '״̬��0��������1��ɾ����'
/
COMMENT ON COLUMN base_user.userid IS '�û�ID���'
/
COMMENT ON COLUMN base_user.username IS '�û��˺ţ���¼ʹ�ã�'
/
COMMENT ON COLUMN base_user.userpwd IS '�û����루��¼ʹ�ã�'
/

-- End of DDL Script for Table ORAHYD.BASE_USER

-- Start of DDL Script for Table ORAHYD.BASE_USER_ROLE
-- Generated 4-����-2012 18:46:36 from ORAHYD@ORCL

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

COMMENT ON TABLE base_user_role IS '�û���ɫ��Ϣ��'
/
COMMENT ON COLUMN base_user_role.actionid IS '�û�ģ�����Ȩ��'
/
COMMENT ON COLUMN base_user_role.menuid IS '�˵����'
/
COMMENT ON COLUMN base_user_role.roleid IS '��ɫ���'
/
COMMENT ON COLUMN base_user_role.userid IS '�û����'
/
COMMENT ON COLUMN base_user_role.userroleid IS '�û���ɫ���'
/

-- End of DDL Script for Table ORAHYD.BASE_USER_ROLE

