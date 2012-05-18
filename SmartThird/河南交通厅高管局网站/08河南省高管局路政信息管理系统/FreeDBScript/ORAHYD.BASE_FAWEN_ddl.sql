-- Start of DDL Script for Table ORAHYD.BASE_FAWEN
-- Generated 18-����-2012 18:27:19 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_FAWEN
DROP TABLE orahyd.base_fawen CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_fawen
    (fid                            NUMBER NOT NULL,
    f_number                       VARCHAR2(50) NOT NULL,
    f_title                        VARCHAR2(50) NOT NULL,
    f_type                         VARCHAR2(50) NOT NULL,
    f_content                      VARCHAR2(800),
    f_annex                        VARCHAR2(100),
    f_date                         DATE,
    remark                         VARCHAR2(500),
    f_organ                        VARCHAR2(50),
    f_level                        VARCHAR2(50),
    f_degree                       VARCHAR2(50),
    f_delstate                     NUMBER DEFAULT 0 NOT NULL)
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





-- Constraints for ORAHYD.BASE_FAWEN

ALTER TABLE orahyd.base_fawen
ADD CONSTRAINT pk_base_fawen PRIMARY KEY (fid)
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


-- Triggers for ORAHYD.BASE_FAWEN

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_FAWEN
 BEFORE 
 INSERT
 ON BASE_FAWEN
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_Fawen.NEXTVAL
     INTO :NEW.Fid
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_FAWEN

COMMENT ON TABLE orahyd.base_fawen IS '������Ϣ��'
/
COMMENT ON COLUMN orahyd.base_fawen.f_annex IS '���ĸ���·��'
/
COMMENT ON COLUMN orahyd.base_fawen.f_content IS '��������'
/
COMMENT ON COLUMN orahyd.base_fawen.f_date IS '��������'
/
COMMENT ON COLUMN orahyd.base_fawen.f_degree IS '�����̶�'
/
COMMENT ON COLUMN orahyd.base_fawen.f_delstate IS '״̬(0:�ѱ��棻1���ѷ��ͣ�2����ɾ��)'
/
COMMENT ON COLUMN orahyd.base_fawen.f_level IS '�ܼ�'
/
COMMENT ON COLUMN orahyd.base_fawen.f_number IS '���ĺ�'
/
COMMENT ON COLUMN orahyd.base_fawen.f_organ IS '���ĵ�λ����'
/
COMMENT ON COLUMN orahyd.base_fawen.f_title IS '���ı���'
/
COMMENT ON COLUMN orahyd.base_fawen.f_type IS '��������'
/
COMMENT ON COLUMN orahyd.base_fawen.fid IS '���'
/
COMMENT ON COLUMN orahyd.base_fawen.remark IS '��ע'
/

-- End of DDL Script for Table ORAHYD.BASE_FAWEN

