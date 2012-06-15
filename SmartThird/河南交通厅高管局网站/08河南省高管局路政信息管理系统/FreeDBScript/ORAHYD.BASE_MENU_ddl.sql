-- Start of DDL Script for Table ORAHYD.BASE_MENU
-- Generated 2012-6-15 ���� 07:07:38 from ORAHYD@ORAHYD

CREATE TABLE base_menu
    (menuid                         NUMBER(*,0) NOT NULL,
    menuname                       VARCHAR2(50),
    menuinfo                       VARCHAR2(200),
    menuurl                        VARCHAR2(200),
    icon                           VARCHAR2(50),
    parentid                       NUMBER(*,0) DEFAULT 0,
    status                         NUMBER(*,0) DEFAULT 0,
    iconcls                        VARCHAR2(50),
    isleaf                         NUMBER,
    sequence                       NUMBER)
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





-- Constraints for BASE_MENU

ALTER TABLE base_menu
ADD CONSTRAINT base_menu_pk PRIMARY KEY (menuid)
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


-- Triggers for BASE_MENU

CREATE OR REPLACE TRIGGER trg_base_menu
 BEFORE
  INSERT
 ON base_menu
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_MENU.NEXTVAL
     INTO :NEW.MENUID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_MENU

COMMENT ON TABLE base_menu IS '�˵���Ϣ��'
/
COMMENT ON COLUMN base_menu.icon IS '�˵�ͼ��'
/
COMMENT ON COLUMN base_menu.iconcls IS 'ģ��ͼ��css����'
/
COMMENT ON COLUMN base_menu.isleaf IS '�Ƿ����ӽڵ�'
/
COMMENT ON COLUMN base_menu.menuid IS '�˵����'
/
COMMENT ON COLUMN base_menu.menuinfo IS '�˵�˵��'
/
COMMENT ON COLUMN base_menu.menuname IS '�˵�����'
/
COMMENT ON COLUMN base_menu.menuurl IS '�˵�URL��ַ'
/
COMMENT ON COLUMN base_menu.parentid IS '���˵���ţ����ڵ�0��'
/
COMMENT ON COLUMN base_menu.sequence IS '����'
/
COMMENT ON COLUMN base_menu.status IS '״̬��0������ 1���رգ�'
/

-- End of DDL Script for Table ORAHYD.BASE_MENU

