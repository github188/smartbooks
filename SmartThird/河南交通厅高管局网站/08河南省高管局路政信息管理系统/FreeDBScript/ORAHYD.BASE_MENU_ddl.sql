-- Start of DDL Script for Table ORAHYD.BASE_MENU
-- Generated 18-����-2012 18:27:45 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_MENU
DROP TABLE orahyd.base_menu CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_menu
    (menuid                         NUMBER(*,0) NOT NULL,
    menuname                       VARCHAR2(50) NOT NULL,
    menuinfo                       VARCHAR2(200) NOT NULL,
    menuurl                        VARCHAR2(200) NOT NULL,
    icon                           VARCHAR2(50) NOT NULL,
    parentid                       NUMBER(*,0) DEFAULT 0 NOT NULL,
    status                         NUMBER(*,0) DEFAULT 0 NOT NULL)
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





-- Constraints for ORAHYD.BASE_MENU

ALTER TABLE orahyd.base_menu
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


-- Triggers for ORAHYD.BASE_MENU

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_MENU
 BEFORE 
 INSERT
 ON BASE_MENU
 REFERENCING OLD AS OLD NEW AS NEW
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


-- Comments for ORAHYD.BASE_MENU

COMMENT ON TABLE orahyd.base_menu IS '�˵���Ϣ��'
/
COMMENT ON COLUMN orahyd.base_menu.icon IS '�˵�ͼ��'
/
COMMENT ON COLUMN orahyd.base_menu.menuid IS '�˵����'
/
COMMENT ON COLUMN orahyd.base_menu.menuinfo IS '�˵�˵��'
/
COMMENT ON COLUMN orahyd.base_menu.menuname IS '�˵�����'
/
COMMENT ON COLUMN orahyd.base_menu.menuurl IS '�˵�URL��ַ'
/
COMMENT ON COLUMN orahyd.base_menu.parentid IS '���˵���ţ����ڵ�0��'
/
COMMENT ON COLUMN orahyd.base_menu.status IS '״̬��0������ 1���رգ�'
/

-- End of DDL Script for Table ORAHYD.BASE_MENU

