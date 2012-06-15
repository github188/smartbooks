-- Start of DDL Script for Table ORAHYD.BASE_DEPT
-- Generated 2012-6-15 ���� 07:07:05 from ORAHYD@ORAHYD

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

