-- Start of DDL Script for Table ORAHYD.BASE_ROAD_TERM
-- Generated 18-����-2012 18:28:37 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_ROAD_TERM
DROP TABLE orahyd.base_road_term CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_road_term
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





-- Constraints for ORAHYD.BASE_ROAD_TERM

ALTER TABLE orahyd.base_road_term
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


-- Triggers for ORAHYD.BASE_ROAD_TERM

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_ROAD_TERM
 BEFORE 
 INSERT
 ON BASE_ROAD_TERM
 REFERENCING OLD AS OLD NEW AS NEW
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


-- Comments for ORAHYD.BASE_ROAD_TERM

COMMENT ON TABLE orahyd.base_road_term IS '·���豸��Ϣ��'
/
COMMENT ON COLUMN orahyd.base_road_term.comptime IS '����ʱ��'
/
COMMENT ON COLUMN orahyd.base_road_term.deptid IS '���ű��'
/
COMMENT ON COLUMN orahyd.base_road_term.id IS '·���豸���'
/
COMMENT ON COLUMN orahyd.base_road_term.linename IS '���ٹ�·����'
/
COMMENT ON COLUMN orahyd.base_road_term.photo IS '�豸��Ƭ'
/
COMMENT ON COLUMN orahyd.base_road_term.regtime IS '�Ǽ�ʱ��'
/
COMMENT ON COLUMN orahyd.base_road_term.remark IS '��ע'
/
COMMENT ON COLUMN orahyd.base_road_term.roadname IS '·���豸����'
/
COMMENT ON COLUMN orahyd.base_road_term.stakek IS '׮�ţ�K��'
/
COMMENT ON COLUMN orahyd.base_road_term.stakem IS '׮�ţ�M��'
/
COMMENT ON COLUMN orahyd.base_road_term.status IS '״̬��0��������1ɾ����'
/
COMMENT ON COLUMN orahyd.base_road_term.summary IS 'λ������'
/
COMMENT ON COLUMN orahyd.base_road_term.typeid IS '·���豸���ͱ��'
/

-- End of DDL Script for Table ORAHYD.BASE_ROAD_TERM

