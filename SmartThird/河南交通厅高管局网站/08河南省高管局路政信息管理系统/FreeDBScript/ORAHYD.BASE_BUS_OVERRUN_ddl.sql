-- Start of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN
-- Generated 29-����-2012 14:18:34 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_bus_overrun
    (id                             NUMBER NOT NULL,
    vehiclelicense                 VARCHAR2(200),
    entrystation                   NUMBER,
    entrystationname               VARCHAR2(200),
    entrytime                      DATE,
    exitstation                    NUMBER,
    exitstationname                VARCHAR2(200),
    exittime                       DATE,
    paytype                        VARCHAR2(200),
    axisnum                        NUMBER,
    overloadrate                   NUMBER,
    totalweight                    NUMBER,
    totaltoll                      NUMBER,
    distance                       NUMBER,
    importdate                     DATE DEFAULT sysdate NOT NULL)
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





-- Constraints for ORAHYD.BASE_BUS_OVERRUN

ALTER TABLE orahyd.base_bus_overrun
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


-- Triggers for ORAHYD.BASE_BUS_OVERRUN

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_BUS_OVERRUN
 BEFORE 
 INSERT
 ON BASE_BUS_OVERRUN
 REFERENCING OLD AS OLD NEW AS NEW
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


-- Comments for ORAHYD.BASE_BUS_OVERRUN

COMMENT ON TABLE orahyd.base_bus_overrun IS '���ٹ�·���޳������ݱ�'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.axisnum IS '����'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.distance IS '����'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.entrystation IS '��ڳ�վ'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.entrystationname IS '���վ��'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.entrytime IS '���ʱ��'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.exitstation IS '���ڳ�վ'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.exitstationname IS '����վ��'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.exittime IS '����ʱ��'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.id IS 'id,����,����'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.importdate IS '���ݵ���ʱ��'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.overloadrate IS 'ʵ�ʳ�����'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.paytype IS '֧����ʽ'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.totaltoll IS '�ܼ������'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.totalweight IS '������'
/
COMMENT ON COLUMN orahyd.base_bus_overrun.vehiclelicense IS '���ƺ���'
/

-- End of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN

