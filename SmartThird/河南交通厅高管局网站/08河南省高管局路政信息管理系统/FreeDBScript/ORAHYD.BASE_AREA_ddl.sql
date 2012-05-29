-- Start of DDL Script for Table ORAHYD.BASE_AREA
-- Generated 29-����-2012 14:16:19 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_area
    (id                             NUMBER NOT NULL,
    areaname                       VARCHAR2(50) NOT NULL,
    typeid                         NUMBER NOT NULL,
    linename                       VARCHAR2(50) NOT NULL,
    stakek                         NUMBER NOT NULL,
    stakem                         NUMBER NOT NULL,
    summary                        VARCHAR2(50) NOT NULL,
    comptime                       DATE DEFAULT SYSDATE NOT NULL,
    regtime                        DATE DEFAULT SYSDATE NOT NULL,
    owner                          VARCHAR2(50) NOT NULL,
    detailed                       VARCHAR2(200) DEFAULT '��' NOT NULL,
    status                         VARCHAR2(200) DEFAULT '��' NOT NULL,
    remark                         VARCHAR2(200) DEFAULT '��' NOT NULL,
    photo                          VARCHAR2(200) NOT NULL,
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





-- Constraints for ORAHYD.BASE_AREA

ALTER TABLE orahyd.base_area
ADD CONSTRAINT pk_base_area PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_AREA

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_AREA
 BEFORE 
 INSERT
 ON BASE_AREA
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_area.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_AREA

COMMENT ON TABLE orahyd.base_area IS '������Υ����Ϣ��'
/
COMMENT ON COLUMN orahyd.base_area.areaname IS 'Υ������'
/
COMMENT ON COLUMN orahyd.base_area.comptime IS '����ʱ��'
/
COMMENT ON COLUMN orahyd.base_area.deptid IS '���ű��'
/
COMMENT ON COLUMN orahyd.base_area.detailed IS '��ϸ����'
/
COMMENT ON COLUMN orahyd.base_area.id IS '���'
/
COMMENT ON COLUMN orahyd.base_area.linename IS '��·����'
/
COMMENT ON COLUMN orahyd.base_area.owner IS '��������'
/
COMMENT ON COLUMN orahyd.base_area.photo IS '�ֳ���Ƭ'
/
COMMENT ON COLUMN orahyd.base_area.regtime IS '�Ǽ�ʱ��'
/
COMMENT ON COLUMN orahyd.base_area.remark IS '��ϸ��ע'
/
COMMENT ON COLUMN orahyd.base_area.stakek IS '׮�ţ�K��'
/
COMMENT ON COLUMN orahyd.base_area.stakem IS '׮�ţ�M��'
/
COMMENT ON COLUMN orahyd.base_area.status IS '��״����'
/
COMMENT ON COLUMN orahyd.base_area.summary IS 'λ������'
/
COMMENT ON COLUMN orahyd.base_area.typeid IS '������'
/

-- End of DDL Script for Table ORAHYD.BASE_AREA

