-- Start of DDL Script for Table ORAHYD.BASE_FILES
-- Generated 29-五月-2012 14:21:43 from ORAHYD@ORAHYD

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

COMMENT ON TABLE orahyd.base_files IS '文件档案信息表'
/
COMMENT ON COLUMN orahyd.base_files.c_dates IS '归档时间'
/
COMMENT ON COLUMN orahyd.base_files.cartular_numbers IS '文号'
/
COMMENT ON COLUMN orahyd.base_files.cartularstate IS '档案状态'
/
COMMENT ON COLUMN orahyd.base_files.cartularydescription IS '档案描述'
/
COMMENT ON COLUMN orahyd.base_files.cartularyid IS '档案编号'
/
COMMENT ON COLUMN orahyd.base_files.cartularyname IS '档案名称'
/
COMMENT ON COLUMN orahyd.base_files.cartularysrc IS '档案存储路径'
/
COMMENT ON COLUMN orahyd.base_files.cartularytypes IS '档案类型'
/

-- End of DDL Script for Table ORAHYD.BASE_FILES

