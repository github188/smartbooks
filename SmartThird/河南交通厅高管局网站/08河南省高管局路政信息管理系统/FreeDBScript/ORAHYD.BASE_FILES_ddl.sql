-- Start of DDL Script for Table ORAHYD.BASE_FILES
-- Generated 29-����-2012 14:21:43 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_files
    (cartularyid                    NUMBER DEFAULT 0,
    cartularyname                  VARCHAR2(50),
    cartularytypes                 VARCHAR2(50),
    cartularysrc                   VARCHAR2(100),
    cartularydescription           VARCHAR2(200),
    cartularstate                  NUMBER,
    cartular_numbers               VARCHAR2(50),
    c_dates                        DATE)
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





-- Comments for ORAHYD.BASE_FILES

COMMENT ON TABLE orahyd.base_files IS '�ļ�������Ϣ��'
/
COMMENT ON COLUMN orahyd.base_files.c_dates IS '�鵵ʱ��'
/
COMMENT ON COLUMN orahyd.base_files.cartular_numbers IS '�ĺ�'
/
COMMENT ON COLUMN orahyd.base_files.cartularstate IS '����״̬'
/
COMMENT ON COLUMN orahyd.base_files.cartularydescription IS '��������'
/
COMMENT ON COLUMN orahyd.base_files.cartularyid IS '�������'
/
COMMENT ON COLUMN orahyd.base_files.cartularyname IS '��������'
/
COMMENT ON COLUMN orahyd.base_files.cartularysrc IS '�����洢·��'
/
COMMENT ON COLUMN orahyd.base_files.cartularytypes IS '��������'
/

-- End of DDL Script for Table ORAHYD.BASE_FILES

