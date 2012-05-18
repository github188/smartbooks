-- Start of DDL Script for Table ORAHYD.BASE_ROAD_CONDITION
-- Generated 18-五月-2012 18:28:31 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_ROAD_CONDITION
DROP TABLE orahyd.base_road_condition CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_road_condition
    (id                             NUMBER NOT NULL)
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





-- Comments for ORAHYD.BASE_ROAD_CONDITION

COMMENT ON TABLE orahyd.base_road_condition IS '路况信息表(未创建完成)'
/
COMMENT ON COLUMN orahyd.base_road_condition.id IS '路况信息编号'
/

-- End of DDL Script for Table ORAHYD.BASE_ROAD_CONDITION

