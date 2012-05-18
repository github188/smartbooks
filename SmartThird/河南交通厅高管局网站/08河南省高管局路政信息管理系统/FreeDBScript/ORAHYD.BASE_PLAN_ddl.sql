-- Start of DDL Script for Table ORAHYD.BASE_PLAN
-- Generated 18-����-2012 18:28:14 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_PLAN
DROP TABLE orahyd.base_plan CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_plan
    (calendarid                     NUMBER NOT NULL,
    userid                         NUMBER NOT NULL,
    calendarcontent                VARCHAR2(200),
    start_date                     DATE DEFAULT sysdate,
    end_date                       DATE DEFAULT sysdate,
    calendarremind                 DATE DEFAULT sysdate NOT NULL,
    calendartype                   VARCHAR2(50))
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





-- Constraints for ORAHYD.BASE_PLAN

ALTER TABLE orahyd.base_plan
ADD CONSTRAINT pk_base_plan PRIMARY KEY (calendarid)
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


-- Triggers for ORAHYD.BASE_PLAN

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_PLAN
 BEFORE 
 INSERT
 ON BASE_PLAN
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_plan.NEXTVAL
     INTO :NEW.CALENDARID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_PLAN

COMMENT ON TABLE orahyd.base_plan IS '�ճ���Ϣ��'
/
COMMENT ON COLUMN orahyd.base_plan.calendarcontent IS '�ճ�����'
/
COMMENT ON COLUMN orahyd.base_plan.calendarid IS '�ճ���Ϣ���'
/
COMMENT ON COLUMN orahyd.base_plan.calendarremind IS '����ʱ��'
/
COMMENT ON COLUMN orahyd.base_plan.calendartype IS '��������'
/
COMMENT ON COLUMN orahyd.base_plan.end_date IS '����ʱ��'
/
COMMENT ON COLUMN orahyd.base_plan.start_date IS '��ʼʱ��'
/
COMMENT ON COLUMN orahyd.base_plan.userid IS '�û����'
/

-- End of DDL Script for Table ORAHYD.BASE_PLAN

