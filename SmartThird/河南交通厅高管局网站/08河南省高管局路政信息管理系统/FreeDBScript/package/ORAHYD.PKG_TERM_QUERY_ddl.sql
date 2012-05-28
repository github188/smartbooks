-- Start of DDL Script for Package ORAHYD.PKG_TERM_QUERY
-- Generated 28-五月-2012 8:25:13 from ORAHYD@ORAHYD

-- Drop the old instance of PKG_TERM_QUERY
DROP PACKAGE orahyd.pkg_term_query
/

CREATE OR REPLACE 
PACKAGE orahyd.pkg_term_query
IS
/*
----------------------------------------------------------------------------
--过程包名：PKG_TERM_QUERY
--作　　者：王亚
--时　　间：2012-5-11
--说　　明：此包用于人员装备数据查询
----------------------------------------------------------------------------
*/
   TYPE refcursortype IS REF CURSOR;           --游标类型定义，用于返回数据集

   PROCEDURE proc_getterm (
      dpecode      IN       NUMBER,                                --部门编号
      issubdept    IN       NUMBER,                    --0包含子部门，1不包含
      out_cursor   OUT      refcursortype
   );
END;                                                           -- Package spec
/


CREATE OR REPLACE 
PACKAGE BODY orahyd.pkg_term_query
IS
   PROCEDURE proc_getterm (
      dpecode      IN       NUMBER,                                --部门编号
      issubdept    IN       NUMBER,                    --0包含子部门，1不包含
      out_cursor   OUT      refcursortype
   )
   IS
   /*
     ----------------------------------------------------------------------------
     --存储过程：proc_getterm
     --作　　者：王亚
     --时　　间：2012-05-11
     --说　　明：获取部门下人员装备数据
     --输入参数：
     --输出参数：
     --------------------------------------------------------------------------
   */
   BEGIN
      --包含子部门数据
      IF issubdept = 0
      THEN
         OPEN out_cursor FOR
            SELECT     a.termid, a.termcode, a.termname, a.serialcode,
                       a.format, a.brand, a.USE,
                       TO_DATE (a.usetime, 'yyyy-mm-dd') AS usetime,
                       a.SAVEPOINT, a.remark, b.typename, c.dptname,
                       CASE a.status
                          WHEN 0
                             THEN '正常'
                          WHEN 1
                             THEN '删除'
                          ELSE '未知'
                       END AS status
                  FROM base_term a, base_term_type b, base_dept c
                 WHERE a.typeid = b.typeid
                   AND a.deptid = c.deptid
                   AND a.deptid = dpecode
            START WITH a.deptid = c.deptid
            CONNECT BY PRIOR c.deptid = c.parentid;
      ELSE
         --不包含子部门
         OPEN out_cursor FOR
            SELECT a.termid, a.termcode, a.termname, a.serialcode, a.format,
                   a.brand, a.USE,
                   TO_DATE (a.usetime, 'yyyy-mm-dd') AS usetime, a.SAVEPOINT,
                   a.remark, b.typename, c.dptname,
                   CASE a.status
                      WHEN 0
                         THEN '正常'
                      WHEN 1
                         THEN '删除'
                      ELSE '未知'
                   END AS status
              FROM base_term a, base_term_type b, base_dept c
             WHERE a.typeid = b.typeid
               AND a.deptid = c.deptid
               AND a.deptid = dpecode;
      END IF;
   END;
END;
/


-- End of DDL Script for Package ORAHYD.PKG_TERM_QUERY

