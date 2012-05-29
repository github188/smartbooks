-- Start of DDL Script for Table ORAHYD.BASE_AREA
-- Generated 29-五月-2012 14:16:19 from ORAHYD@ORAHYD

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
    detailed                       VARCHAR2(200) DEFAULT '无' NOT NULL,
    status                         VARCHAR2(200) DEFAULT '无' NOT NULL,
    remark                         VARCHAR2(200) DEFAULT '无' NOT NULL,
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

COMMENT ON TABLE orahyd.base_area IS '控制区违章信息表'
/
COMMENT ON COLUMN orahyd.base_area.areaname IS '违章名称'
/
COMMENT ON COLUMN orahyd.base_area.comptime IS '竣工时间'
/
COMMENT ON COLUMN orahyd.base_area.deptid IS '部门编号'
/
COMMENT ON COLUMN orahyd.base_area.detailed IS '详细描述'
/
COMMENT ON COLUMN orahyd.base_area.id IS '编号'
/
COMMENT ON COLUMN orahyd.base_area.linename IS '公路名称'
/
COMMENT ON COLUMN orahyd.base_area.owner IS '物主名称'
/
COMMENT ON COLUMN orahyd.base_area.photo IS '现场照片'
/
COMMENT ON COLUMN orahyd.base_area.regtime IS '登记时间'
/
COMMENT ON COLUMN orahyd.base_area.remark IS '详细备注'
/
COMMENT ON COLUMN orahyd.base_area.stakek IS '桩号（K）'
/
COMMENT ON COLUMN orahyd.base_area.stakem IS '桩号（M）'
/
COMMENT ON COLUMN orahyd.base_area.status IS '现状描述'
/
COMMENT ON COLUMN orahyd.base_area.summary IS '位置描述'
/
COMMENT ON COLUMN orahyd.base_area.typeid IS '分类编号'
/

-- End of DDL Script for Table ORAHYD.BASE_AREA

