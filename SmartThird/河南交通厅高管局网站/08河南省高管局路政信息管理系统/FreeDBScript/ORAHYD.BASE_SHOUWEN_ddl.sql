-- Start of DDL Script for Table ORAHYD.BASE_SHOUWEN
-- Generated 29-����-2012 14:28:50 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_shouwen
    (sid                            NUMBER NOT NULL,
    s_numbers                      VARCHAR2(50) NOT NULL,
    s_organ                        VARCHAR2(50) NOT NULL,
    s_fromdate                     DATE,
    s_title                        VARCHAR2(50) NOT NULL,
    s_handlingtime                 DATE,
    s_dep_organ                    VARCHAR2(50),
    s_handleprogress               VARCHAR2(50),
    s_result                       VARCHAR2(200),
    s_applicant                    VARCHAR2(50),
    s_handler                      VARCHAR2(50),
    remarks                        VARCHAR2(200))
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





-- Constraints for ORAHYD.BASE_SHOUWEN

ALTER TABLE orahyd.base_shouwen
ADD CONSTRAINT pk_base_shouwen PRIMARY KEY (sid)
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


-- Triggers for ORAHYD.BASE_SHOUWEN

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_SHOUWEN
 BEFORE 
 INSERT
 ON BASE_SHOUWEN
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_shouwen.NEXTVAL
     INTO :NEW.SID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_SHOUWEN

COMMENT ON TABLE orahyd.base_shouwen IS '������Ϣ��'
/
COMMENT ON COLUMN orahyd.base_shouwen.remarks IS '��ע'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_applicant IS '������'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_dep_organ IS '�漰�����Ӫ����λ'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_fromdate IS '����ʱ��'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_handleprogress IS '�������'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_handler IS '��ص�λ�а���'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_handlingtime IS '�а�ʱ��'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_numbers IS 'ԭ��'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_organ IS '���Ļ���'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_result IS '������'
/
COMMENT ON COLUMN orahyd.base_shouwen.s_title IS '����'
/
COMMENT ON COLUMN orahyd.base_shouwen.sid IS '������Ϣ ���'
/

-- End of DDL Script for Table ORAHYD.BASE_SHOUWEN

