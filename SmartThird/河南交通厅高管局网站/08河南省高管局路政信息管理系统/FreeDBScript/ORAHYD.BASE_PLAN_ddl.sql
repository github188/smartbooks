-- Start of DDL Script for Table ORAHYD.BASE_PLAN
-- Generated 12-����-2012 9:25:45 from ORAHYD@ORAHYD

CREATE TABLE base_plan
    (calendarid                     NUMBER NOT NULL,
    userid                         NUMBER NOT NULL,
    calendarcontent                VARCHAR2(200),
    start_date                     DATE DEFAULT sysdate,
    end_date                       DATE DEFAULT sysdate,
    calendarremind                 DATE DEFAULT sysdate NOT NULL,
    calendartype                   VARCHAR2(50),
    state                          NUMBER DEFAULT 0 NOT NULL,
    title                          VARCHAR2(50))
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





-- Constraints for BASE_PLAN

ALTER TABLE base_plan
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


-- Triggers for BASE_PLAN

CREATE OR REPLACE TRIGGER trg_base_plan
 BEFORE
  INSERT
 ON base_plan
REFERENCING NEW AS NEW OLD AS OLD
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


-- Comments for BASE_PLAN

COMMENT ON TABLE base_plan IS '�ճ���Ϣ��'
/
COMMENT ON COLUMN base_plan.calendarcontent IS '�ճ�����'
/
COMMENT ON COLUMN base_plan.calendarid IS '�ճ���Ϣ���'
/
COMMENT ON COLUMN base_plan.calendarremind IS '����ʱ��'
/
COMMENT ON COLUMN base_plan.calendartype IS '��������'
/
COMMENT ON COLUMN base_plan.end_date IS '����ʱ��'
/
COMMENT ON COLUMN base_plan.start_date IS '��ʼʱ��'
/
COMMENT ON COLUMN base_plan.state IS '����״̬��0��������1��ɾ����'
/
COMMENT ON COLUMN base_plan.title IS '�������'
/
COMMENT ON COLUMN base_plan.userid IS '�û����'
/

-- End of DDL Script for Table ORAHYD.BASE_PLAN

