-- Start of DDL Script for Table ORAHYD.BASE_ASSESS
-- Generated 29-����-2012 14:18:15 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_assess
    (assessid                       NUMBER NOT NULL,
    assessname                     VARCHAR2(50) NOT NULL,
    assessdept                     VARCHAR2(20),
    assessresult                   NUMBER,
    assessdescription              VARCHAR2(200),
    assesscriterion                VARCHAR2(100),
    assessformat                   VARCHAR2(100),
    assesscontent                  VARCHAR2(100),
    assesstime                     VARCHAR2(50))
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





-- Constraints for ORAHYD.BASE_ASSESS

ALTER TABLE orahyd.base_assess
ADD CONSTRAINT pk_base_assess PRIMARY KEY (assessid)
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


-- Triggers for ORAHYD.BASE_ASSESS

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_ASSESS
 BEFORE 
 INSERT
 ON BASE_ASSESS
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_assess.NEXTVAL
     INTO :NEW.ASSESSID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_ASSESS

COMMENT ON TABLE orahyd.base_assess IS '������Ϣ��'
/
COMMENT ON COLUMN orahyd.base_assess.assesscontent IS 'Ŀ������'
/
COMMENT ON COLUMN orahyd.base_assess.assesscriterion IS '���˱�׼'
/
COMMENT ON COLUMN orahyd.base_assess.assessdept IS '������Ŀ������λ'
/
COMMENT ON COLUMN orahyd.base_assess.assessdescription IS '������Ϣ��ע'
/
COMMENT ON COLUMN orahyd.base_assess.assessformat IS '������ʽ'
/
COMMENT ON COLUMN orahyd.base_assess.assessid IS '������Ϣ���'
/
COMMENT ON COLUMN orahyd.base_assess.assessname IS '������Ŀ����'
/
COMMENT ON COLUMN orahyd.base_assess.assessresult IS '���˷�ֵ'
/
COMMENT ON COLUMN orahyd.base_assess.assesstime IS '�ϱ�ʱ��'
/

-- End of DDL Script for Table ORAHYD.BASE_ASSESS

