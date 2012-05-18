-- Start of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN_SUBMIT
-- Generated 18-五月-2012 18:26:43 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_BUS_OVERRUN_SUBMIT
DROP TABLE orahyd.base_bus_overrun_submit CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_bus_overrun_submit
    (id                             NUMBER NOT NULL,
    buscode                        VARCHAR2(20) NOT NULL,
    buslong                        NUMBER NOT NULL,
    buswidth                       NUMBER NOT NULL,
    busheight                      NUMBER NOT NULL,
    weight                         NUMBER NOT NULL,
    photo                          VARCHAR2(200) NOT NULL,
    inname                         VARCHAR2(50) NOT NULL,
    outname                        VARCHAR2(50) NOT NULL,
    ticktime                       DATE NOT NULL,
    userid                         NUMBER NOT NULL,
    deptid                         NUMBER NOT NULL,
    location                       VARCHAR2(100) NOT NULL,
    busunit                        VARCHAR2(50) NOT NULL,
    remarks                        VARCHAR2(50) DEFAULT '无')
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





-- Constraints for ORAHYD.BASE_BUS_OVERRUN_SUBMIT

ALTER TABLE orahyd.base_bus_overrun_submit
ADD CONSTRAINT pk_base_bus_overrun_submit PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_BUS_OVERRUN_SUBMIT

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_BUS_OVERRUN_SUBMIT
 BEFORE 
 INSERT
 ON BASE_BUS_OVERRUN_SUBMIT
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_BASE_BUS_OVERRUN_SUBMIT.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_BUS_OVERRUN_SUBMIT

COMMENT ON TABLE orahyd.base_bus_overrun_submit IS '查处非法超限车辆数据'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.buscode IS '车牌号码'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.busheight IS '高度'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.buslong IS '车货总长'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.busunit IS '车辆所属单位'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.buswidth IS '宽度'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.deptid IS '查处单位'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.id IS 'id，主键，自增'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.inname IS '入口站名称'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.location IS '查处地点'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.outname IS '出口站名称'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.photo IS '车货照片'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.remarks IS '备注'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.ticktime IS '查处时间'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.userid IS '查处人'
/
COMMENT ON COLUMN orahyd.base_bus_overrun_submit.weight IS '总重量'
/

-- End of DDL Script for Table ORAHYD.BASE_BUS_OVERRUN_SUBMIT

