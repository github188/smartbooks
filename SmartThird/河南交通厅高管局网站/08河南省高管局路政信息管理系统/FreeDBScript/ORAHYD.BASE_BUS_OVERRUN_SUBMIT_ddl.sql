-- Start of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN_SUBMIT
-- Generated 18-����-2012 18:26:43 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_BUS_OVERRUN_SUBMIT
DROP TABLE orahyd.base_bus_overrun_submit CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_bus_overrun_submit
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





-- Constraints for ORAHYD.BASE_BUS_OVERRUN_SUBMIT

ALTER TABLE orahyd.base_bus_overrun_submit
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


-- Triggers for ORAHYD.BASE_BUS_OVERRUN_SUBMIT

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_BUS_OVERRUN_SUBMIT
 BEFORE 
 INSERT
 ON BASE_BUS_OVERRUN_SUBMIT
 REFERENCING OLD AS OLD NEW AS NEW
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


-- Comments for ORAHYD.BASE_BUS_OVERRUN_SUBMIT

COMMENT ON TABLE orahyd.base_bus_overrun_submit IS '�鴦�Ƿ����޳�������'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.buscode IS '���ƺ���'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.busheight IS '�߶�'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.buslong IS '�����ܳ�'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.busunit IS '����������λ'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.buswidth IS '���'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.deptid IS '�鴦��λ'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.id IS 'id������������'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.inname IS '���վ����'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.location IS '�鴦�ص�'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.outname IS '����վ����'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.photo IS '������Ƭ'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.remarks IS '��ע'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.ticktime IS '�鴦ʱ��'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.userid IS '�鴦��'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.weight IS '������'
/

-- End of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN_SUBMIT

