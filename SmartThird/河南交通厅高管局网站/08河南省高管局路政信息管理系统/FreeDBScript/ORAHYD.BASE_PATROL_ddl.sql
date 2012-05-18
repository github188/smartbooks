-- Start of DDL Script for Table ORAHYD.BASE_PATROL
-- Generated 18-����-2012 18:28:03 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_PATROL
DROP TABLE orahyd.base_patrol CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_patrol
    (patrolid                       NUMBER NOT NULL,
    deptid                         NUMBER NOT NULL,
    respuser                       VARCHAR2(20) NOT NULL,
    patroluser                     VARCHAR2(20) NOT NULL,
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
    acceptcaptain                  VARCHAR2(20) NOT NULL,
    shiftcaptain                   VARCHAR2(20) NOT NULL,
    acceptbusnumber                VARCHAR2(20) NOT NULL,
    ticktime                       DATE DEFAULT SYSDATE NOT NULL,
    buskm                          NUMBER DEFAULT 0 NOT NULL,
    goods                          VARCHAR2(500) NOT NULL)
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





-- Constraints for ORAHYD.BASE_PATROL

ALTER TABLE orahyd.base_patrol
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


-- Triggers for ORAHYD.BASE_PATROL

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_PATROL
 BEFORE 
 INSERT
 ON BASE_PATROL
 REFERENCING OLD AS OLD NEW AS NEW
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


-- Comments for ORAHYD.BASE_PATROL

COMMENT ON TABLE orahyd.base_patrol IS '�˹�Ѳ����־��'
/
COMMENT ON COLUMN orahyd.base_patrol.accept IS '������'
/
COMMENT ON COLUMN orahyd.base_patrol.acceptbusnumber IS '�Ӱ�Ѳ�߳��ƺ�'
/
COMMENT ON COLUMN orahyd.base_patrol.acceptcaptain IS '�Ӱ��жӳ�'
/
COMMENT ON COLUMN orahyd.base_patrol.begintime IS 'Ѳ�鿪ʼʱ��'
/
COMMENT ON COLUMN orahyd.base_patrol.buskm IS '�Ӱ�Ѳ�߳���̱�KM��'
/
COMMENT ON COLUMN orahyd.base_patrol.busnumber IS 'Ѳ�鳵�ƺ�'
/
COMMENT ON COLUMN orahyd.base_patrol.deptid IS 'Ѳ���ж�'
/
COMMENT ON COLUMN orahyd.base_patrol.endtime IS 'Ѳ�����ʱ��'
/
COMMENT ON COLUMN orahyd.base_patrol.goods IS '�ƽ�����'
/
COMMENT ON COLUMN orahyd.base_patrol.log IS 'Ѳ�鴦�����'
/
COMMENT ON COLUMN orahyd.base_patrol.mileage IS 'Ѳ�����'
/
COMMENT ON COLUMN orahyd.base_patrol.nextwithin IS '�ƽ��°ദ������'
/
COMMENT ON COLUMN orahyd.base_patrol.patrolid IS 'Ѳ����־ID'
/
COMMENT ON COLUMN orahyd.base_patrol.patroluser IS 'Ѳ����Ա'
/
COMMENT ON COLUMN orahyd.base_patrol.respuser IS 'Ѳ�鸺����'
/
COMMENT ON COLUMN orahyd.base_patrol.shiftcaptain IS '�����жӳ�'
/
COMMENT ON COLUMN orahyd.base_patrol.ticktime IS '���Ӱ�ʱ��'
/
COMMENT ON COLUMN orahyd.base_patrol.transfer IS '�ƽ���'
/
COMMENT ON COLUMN orahyd.base_patrol.weather IS '����'
/
COMMENT ON COLUMN orahyd.base_patrol.within IS '�ƽ���ҵ��������'
/

-- End of DDL Script for Table ORAHYD.BASE_PATROL

