-- Start of DDL Script for Table ORAHYD.BASE_OBSERVED
-- Generated 29-����-2012 14:24:04 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_observed
    (observedid                     NUMBER DEFAULT 0 NOT NULL,
    patroluser                     VARCHAR2(50) NOT NULL,
    weather                        VARCHAR2(50) NOT NULL,
    begintime                      DATE DEFAULT SYSDATE NOT NULL,
    enddate                        DATE DEFAULT SYSDATE NOT NULL,
    log                            VARCHAR2(500) NOT NULL,
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





-- Constraints for ORAHYD.BASE_OBSERVED

ALTER TABLE orahyd.base_observed
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


-- Triggers for ORAHYD.BASE_OBSERVED

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_OBSERVED
 BEFORE 
 INSERT
 ON BASE_OBSERVED
 REFERENCING OLD AS OLD NEW AS NEW
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


-- Comments for ORAHYD.BASE_OBSERVED

COMMENT ON TABLE orahyd.base_observed IS '����Ѳ����־��'
/
COMMENT ON COLUMN orahyd.base_observed.begintime IS 'Ѳ�鿪ʼʱ��'
/
COMMENT ON COLUMN orahyd.base_observed.deptid IS '����'
/
COMMENT ON COLUMN orahyd.base_observed.enddate IS 'Ѳ�����ʱ��'
/
COMMENT ON COLUMN orahyd.base_observed.log IS 'Ѳ�鴦�����'
/
COMMENT ON COLUMN orahyd.base_observed.observedid IS '����Ѳ����־���'
/
COMMENT ON COLUMN orahyd.base_observed.patroluser IS 'Ѳ����Ա'
/
COMMENT ON COLUMN orahyd.base_observed.weather IS '����'
/

-- End of DDL Script for Table ORAHYD.BASE_OBSERVED

