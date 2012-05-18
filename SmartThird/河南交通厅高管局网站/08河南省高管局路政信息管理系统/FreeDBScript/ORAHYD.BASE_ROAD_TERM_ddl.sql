-- Start of DDL Script for Table ORAHYD.BASE_ROAD_TERM
-- Generated 18-五月-2012 18:28:37 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_ROAD_TERM
DROP TABLE orahyd.base_road_term CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_road_term
    (id                             NUMBER NOT NULL,
    roadname                       VARCHAR2(50) NOT NULL,
    linename                       VARCHAR2(50) NOT NULL,
    stakek                         NUMBER NOT NULL,
    stakem                         NUMBER NOT NULL,
    summary                        VARCHAR2(50) DEFAULT '无',
    comptime                       DATE DEFAULT SYSDATE NOT NULL,
    regtime                        DATE DEFAULT SYSDATE NOT NULL,
    photo                          VARCHAR2(200) NOT NULL,
    remark                         VARCHAR2(200) DEFAULT '无',
    status                         NUMBER DEFAULT 0 NOT NULL,
    typeid                         NUMBER NOT NULL,
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





-- Constraints for ORAHYD.BASE_ROAD_TERM

ALTER TABLE orahyd.base_road_term
ADD CONSTRAINT pk_base_road_term PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_ROAD_TERM

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_ROAD_TERM
 BEFORE 
 INSERT
 ON BASE_ROAD_TERM
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_ROAD_TERM.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_ROAD_TERM

COMMENT ON TABLE orahyd.base_road_term IS '路产设备信息表'
/
COMMENT ON COLUMN orahyd.base_road_term.comptime IS '竣工时间'
/
COMMENT ON COLUMN orahyd.base_road_term.deptid IS '部门编号'
/
COMMENT ON COLUMN orahyd.base_road_term.id IS '路产设备编号'
/
COMMENT ON COLUMN orahyd.base_road_term.linename IS '高速公路名称'
/
COMMENT ON COLUMN orahyd.base_road_term.photo IS '设备照片'
/
COMMENT ON COLUMN orahyd.base_road_term.regtime IS '登记时间'
/
COMMENT ON COLUMN orahyd.base_road_term.remark IS '备注'
/
COMMENT ON COLUMN orahyd.base_road_term.roadname IS '路产设备名称'
/
COMMENT ON COLUMN orahyd.base_road_term.stakek IS '桩号（K）'
/
COMMENT ON COLUMN orahyd.base_road_term.stakem IS '桩号（M）'
/
COMMENT ON COLUMN orahyd.base_road_term.status IS '状态（0：正常，1删除）'
/
COMMENT ON COLUMN orahyd.base_road_term.summary IS '位置描述'
/
COMMENT ON COLUMN orahyd.base_road_term.typeid IS '路产设备类型编号'
/

-- End of DDL Script for Table ORAHYD.BASE_ROAD_TERM

