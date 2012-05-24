-- Start of DDL Script for Package ORAHYD.PKG_USER_QUERY
-- Generated 24-五月-2012 8:38:44 from ORAHYD@ORAHYD

-- Drop the old instance of PKG_USER_QUERY
DROP PACKAGE orahyd.pkg_user_query
/

CREATE OR REPLACE 
PACKAGE orahyd.pkg_user_query
IS
/*
----------------------------------------------------------------------------
--过程包名：PKG_USER_QUERY
--作　　者：王亚
--时　　间：2012-5-04
--说　　明：此包用于查询用户信息
----------------------------------------------------------------------------
*/
   TYPE refcursortype IS REF CURSOR;           --游标类型定义，用于返回数据集

   PROCEDURE proc_getdept (
      username     IN       VARCHAR2,                              --用户名称
      issubdept    IN       NUMBER,          --0:包含子部门,其他:用户所属部门
      out_cursor   OUT      refcursortype
   );

   PROCEDURE proc_getuser (
        dptcode in number,  --部门编号 
        out_cursor OUT refcursortype --游标 
   );
END;
/


CREATE OR REPLACE 
PACKAGE BODY orahyd.pkg_user_query
IS
   PROCEDURE proc_getdept (
      username     IN       VARCHAR2,                              --用户名称
      issubdept    IN       NUMBER,          --0:包含子部门,其他:用户所属部门
      out_cursor   OUT      refcursortype
   )
   IS
    /*
     ----------------------------------------------------------------------------
     --存储过程：proc_getdept
     --作　　者：王亚
     --时　　间：2012-05-07
     --说　　明：
     --输入参数：
     --输出参数：
     --------------------------------------------------------------------------
   */
   BEGIN
      IF issubdept = 0                             --查询用户所属部门及子部门
      THEN
         OPEN out_cursor FOR
            SELECT     a.deptid, a.dptname, a.dptinfo, a.parentid
                  FROM base_dept a, base_user b
                 WHERE a.status = 0
            START WITH a.deptid = b.deptid
            CONNECT BY PRIOR a.deptid = a.parentid
              ORDER BY a.deptid;
      ELSE                                                  --查询用户所属部门
         OPEN out_cursor FOR
            SELECT a.deptid, a.dptname, a.dptinfo, a.parentid
              FROM base_dept a, base_user b
             WHERE a.deptid = b.deptid
               AND a.status = 0
               AND b.username = username;
      END IF;
   END;

   --获取部门下用户
   PROCEDURE proc_getuser (
      dptcode      IN       NUMBER,                                 --部门编号
      out_cursor   OUT      refcursortype                           --返回游标
   )
   IS
   BEGIN
      IF dptcode = -1
      THEN
         OPEN out_cursor FOR
            SELECT b.dptname, a.username,
                   TO_CHAR (a.birthday, 'yyyy-mm-dd') AS birthday, a.DEGREE,
                   a.face, a.idnumber, a.jobnumber, a.photo, a.prof, a.phone,
                   CASE a.sex
                      WHEN 0
                         THEN '男'
                      WHEN 1
                         THEN '女'
                      ELSE '未知'
                   END AS sex,
                   CASE a.ststus
                      WHEN 0
                         THEN '正常'
                      WHEN 1
                         THEN '删除'
                      ELSE '未知'
                   END AS status
              FROM base_user a, base_dept b
             WHERE a.deptid = b.deptid;
      ELSE
         OPEN out_cursor FOR
            SELECT b.dptname, a.username,
                   TO_CHAR (a.birthday, 'yyyy-mm-dd') AS birthday, a.DEGREE,
                   a.face, a.idnumber, a.jobnumber, a.photo, a.prof, a.phone,
                   CASE a.sex
                      WHEN 0
                         THEN '男'
                      WHEN 1
                         THEN '女'
                      ELSE '未知'
                   END AS sex,
                   CASE a.ststus
                      WHEN 0
                         THEN '正常'
                      WHEN 1
                         THEN '删除'
                      ELSE '未知'
                   END AS status
              FROM base_user a, base_dept b
             WHERE a.deptid = b.deptid AND a.deptid = dptcode;
      END IF;
   END;
END;
/


-- End of DDL Script for Package ORAHYD.PKG_USER_QUERY

