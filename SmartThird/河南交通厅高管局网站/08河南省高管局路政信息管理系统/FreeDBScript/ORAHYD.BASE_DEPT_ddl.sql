-- Start of DDL Script for Table ORAHYD.BASE_DEPT
-- Generated 18-����-2012 18:27:14 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_DEPT
DROP TABLE orahyd.base_dept CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_dept
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





-- Constraints for ORAHYD.BASE_DEPT

ALTER TABLE orahyd.base_dept
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


-- Triggers for ORAHYD.BASE_DEPT

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_DEPT
 BEFORE 
 INSERT
 ON BASE_DEPT
 REFERENCING OLD AS OLD NEW AS NEW
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


-- Comments for ORAHYD.BASE_DEPT

COMMENT ON TABLE orahyd.base_dept IS '������Ϣ��'
/
COMMENT ON COLUMN orahyd.base_dept.deptid IS '���ű��'
/
COMMENT ON COLUMN orahyd.base_dept.dptinfo IS '��������'
/
COMMENT ON COLUMN orahyd.base_dept.dptname IS '��������'
/
COMMENT ON COLUMN orahyd.base_dept.parentid IS '�ϼ����ű�ţ����ڵ�0��'
/
COMMENT ON COLUMN orahyd.base_dept.status IS '״̬��0������ 1���رգ�'
/

-- End of DDL Script for Table ORAHYD.BASE_DEPT

