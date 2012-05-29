-- Start of DDL Script for Table ORAHYD.BASE_CASE
-- Generated 29-����-2012 14:19:11 from ORAHYD@ORAHYD

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

COMMENT ON TABLE orahyd.base_case IS '·��������'
/
COMMENT ON COLUMN orahyd.base_case.accidentcause IS '�¹ʷ���ԭ��'
/
COMMENT ON COLUMN orahyd.base_case.accidenttype IS '�¹�����'
/
COMMENT ON COLUMN orahyd.base_case.action IS '����'
/
COMMENT ON COLUMN orahyd.base_case.busloss IS '������ʧ'
/
COMMENT ON COLUMN orahyd.base_case.casecode IS '�������'
/
COMMENT ON COLUMN orahyd.base_case.createtime IS '��������'
/
COMMENT ON COLUMN orahyd.base_case.death IS '��������'
/
COMMENT ON COLUMN orahyd.base_case.id IS '���'
/
COMMENT ON COLUMN orahyd.base_case.inquest IS '��������'
/
COMMENT ON COLUMN orahyd.base_case.inquestbegintime IS '������ʱ����'
/
COMMENT ON COLUMN orahyd.base_case.inquestduty IS '��������ְ��'
/
COMMENT ON COLUMN orahyd.base_case.inquestendtime IS '������ʱ��ֹ'
/
COMMENT ON COLUMN orahyd.base_case.inquestid IS '��������ִ��֤���'
/
COMMENT ON COLUMN orahyd.base_case.invite IS '��������'
/
COMMENT ON COLUMN orahyd.base_case.inviteduty IS '��������ְ��'
/
COMMENT ON COLUMN orahyd.base_case.invitetel IS '�������˵绰'
/
COMMENT ON COLUMN orahyd.base_case.launch IS '������'
/
COMMENT ON COLUMN orahyd.base_case.light IS '��������'
/
COMMENT ON COLUMN orahyd.base_case.linename IS '��·����'
/
COMMENT ON COLUMN orahyd.base_case.linetype IS '·������'
/
COMMENT ON COLUMN orahyd.base_case.presenters IS '�참������'
/
COMMENT ON COLUMN orahyd.base_case.presentersduty IS '�참������ְ��'
/
COMMENT ON COLUMN orahyd.base_case.presentersid IS '�참������ִ��֤���'
/
COMMENT ON COLUMN orahyd.base_case.stakek IS '׮�ţ�K��'
/
COMMENT ON COLUMN orahyd.base_case.stakem IS '׮�ţ�M��'
/
COMMENT ON COLUMN orahyd.base_case.summary IS '����ժҪ'
/
COMMENT ON COLUMN orahyd.base_case.ticktime IS '����ʱ��'
/
COMMENT ON COLUMN orahyd.base_case.userid IS '�����Ǽ���'
/
COMMENT ON COLUMN orahyd.base_case.weather IS '�������'
/
COMMENT ON COLUMN orahyd.base_case.weight IS '��������'
/

-- End of DDL Script for Table ORAHYD.BASE_CASE

