-- Start of DDL Script for Package ORAHYD.PKG_PATROL_QUERY
-- Generated 18-五月-2012 18:30:06 from ORAHYD@ORAHYD

-- Drop the old instance of PKG_PATROL_QUERY
DROP PACKAGE orahyd.pkg_patrol_query
/

CREATE OR REPLACE 
PACKAGE orahyd.pkg_patrol_query
IS
/*
----------------------------------------------------------------------------
--过程包名：PKG_PATROL_QUERY
--作　　者：王亚
--时　　间：2012-5-07
--说　　明：此包用于巡逻日志数据查询
----------------------------------------------------------------------------
*/
   TYPE refcursortype IS REF CURSOR;           --游标类型定义，用于返回数据集

   PROCEDURE proc_getdeptlog (
      begintime    IN       DATE,                              --查询开始时间
      endtime      IN       DATE,                              --查询结束时间
      dptcode      IN       NUMBER,                                --部门编号
      out_cursor   OUT      refcursortype
   );
END pkg_patrol_query;                                          -- Package spec
/


CREATE OR REPLACE 
PACKAGE BODY orahyd.pkg_patrol_query
IS
   PROCEDURE proc_getdeptlog (
      begintime    IN       DATE,                              --查询开始时间
      endtime      IN       DATE,                              --查询结束时间
      dptcode      IN       NUMBER,                                --部门编号
      out_cursor   OUT      refcursortype
   )
   IS
    /*
     ----------------------------------------------------------------------------
     --存储过程：proc_getdeptlog
     --作　　者：王亚
     --时　　间：2012-05-07
     --说　　明：获取指定ID编号部门下巡逻日志
     --输入参数：
     --输出参数：
     --------------------------------------------------------------------------
   */
   BEGIN
      OPEN out_cursor FOR
         /*部门,巡逻人员,巡查车牌号,巡查里程,天气,交接班时间,接班巡逻车里程表（KM）*/
         SELECT b.dptname, c.username, a.busnumber, a.mileage, a.weather,
                TO_DATE (a.ticktime, 'yyyy-mm-dd') AS ticktime, a.buskm
           FROM base_patrol a, base_dept b, base_user c
          WHERE a.deptid = b.deptid
            AND a.ticktime >= begintime
            AND a.ticktime <= endtime
            AND a.deptid = dptcode
            AND a.patroluser = c.userid;
   END;
END pkg_patrol_query;
/


-- End of DDL Script for Package ORAHYD.PKG_PATROL_QUERY

