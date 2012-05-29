-- Start of DDL Script for Package ORAHYD.PKG_BUS_OVERRUN
-- Generated 29-五月-2012 14:31:10 from ORAHYD@ORAHYD

CREATE OR REPLACE 
PACKAGE orahyd.pkg_bus_overrun
IS
/*
----------------------------------------------------------------------------
--过程包名：pkg_bus_overrun
--作　　者：王亚
--时　　间：2012-5-04
--说　　明：此包用于超车车辆数据查询
----------------------------------------------------------------------------
*/
   TYPE refcursortype IS REF CURSOR;           --游标类型定义，用于返回数据集

   PROCEDURE rpt_busaccount (
      prmbegindate   IN       VARCHAR2,                        --查询开始时间
      prmenddate     IN       VARCHAR2,                        --查询结束时间
      out_cursor     OUT      refcursortype
   );
END pkg_bus_overrun;
/


CREATE OR REPLACE 
PACKAGE BODY orahyd.pkg_bus_overrun
IS
   PROCEDURE rpt_busaccount (
      prmbegindate   IN       VARCHAR2,                        --查询开始时间
      prmenddate     IN       VARCHAR2,                        --查询结束时间
      out_cursor     OUT      refcursortype
   )
   IS
    /*
     ----------------------------------------------------------------------------
     --存储过程：rpt_busaccount
     --作　　者：王亚
     --时　　间：2012-05-04
     --说　　明：汇总超限车辆数据
     --输入参数：
     --输出参数：
     --------------------------------------------------------------------------
   */
   BEGIN
      OPEN out_cursor FOR
         SELECT *
           FROM base_action;
   END;
END pkg_bus_overrun;
/


-- End of DDL Script for Package ORAHYD.PKG_BUS_OVERRUN

