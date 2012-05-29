-- Start of DDL Script for Package ORAHYD.PKG_ARTICLE_QUERY
-- Generated 29-五月-2012 14:30:40 from ORAHYD@ORAHYD

CREATE OR REPLACE 
PACKAGE orahyd.pkg_article_query
IS
   /*
   ----------------------------------------------------------------------------
   --过程包名：PKG_ARTICLE_QUERY
   --作　　者：王亚
   --时　　间：2012-5-18
   --说　　明：此包用于查询公文信息
   ----------------------------------------------------------------------------
   */
   TYPE refcursortype IS REF CURSOR;            --游标类型定义,用于返回数据集

   /*
   ----------------------------------------------------------------------------
   --过程包名：proc_getarticle
   --作　　者：王亚
   --时　　间：2012-5-18
   --说　　明：此过程用于获取回复列表
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getreplylist (
      sendid       IN       NUMBER,                                --发文编号
      out_cursor   OUT      refcursortype
   );

   /*
   ----------------------------------------------------------------------------
   --过程包名：proc_getreplydetail
   --作　　者：王亚
   --时　　间：2012-5-18
   --说　　明：此过程用于获取单个回文详细信息
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getdetail (
      sendid       IN       NUMBER,                                --发文编号
      out_cursor   OUT      refcursortype
   );

   /*
   ----------------------------------------------------------------------------
   --过程包名：proc_getdeptarticle
   --作　　者：王亚
   --时　　间：2012-5-18
   --说　　明：此过程根据部门编号和分类编号获公文信息
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getpublishlist (
      dptcode      IN       NUMBER,                                --部门编号
      typecode     IN       NUMBER,                                --公文类别
      out_cursor   OUT      refcursortype
   );
END;
/


CREATE OR REPLACE 
PACKAGE BODY orahyd.pkg_article_query
IS
   /*
   ----------------------------------------------------------------------------
   --过程包名：proc_getarticle
   --作　　者：王亚
   --时　　间：2012-5-18
   --说　　明：此过程用于获取回复列表
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getreplylist (
      sendid       IN       NUMBER,                                --发文编号
      out_cursor   OUT      refcursortype
   )
   IS
   BEGIN
      OPEN out_cursor FOR
         /*
         * 部门,查阅状态,查阅时间,标题,发文字号,回复时间
         */
         SELECT   b.dptname,a.articleid,c.id,c.score,
                  CASE a.isread
                     WHEN 0
                        THEN '未查阅'
                     WHEN 1
                        THEN '已查阅'
                     ELSE '异常'
                  END AS isread,
                  TO_CHAR (a.readtime, 'yyyy-mm-dd hh24:mi:ss') AS readtime,
                  c.title, c.sendcode,
                  TO_CHAR (c.TIMESTAMP, 'yyyy-mm-dd hh24:mi:ss')
                                                                AS TIMESTAMP
             FROM base_article_unit a, base_dept b, base_article c
            WHERE a.articleid = sendid
              AND a.dptcode = b.deptid
              AND a.dptcode = c.deptid(+)
         ORDER BY c.TIMESTAMP DESC;
   END;

   /*
   ----------------------------------------------------------------------------
   --过程包名：proc_getreplydetail
   --作　　者：王亚
   --时　　间：2012-5-18
   --说　　明：此过程用于获取单个回文详细信息
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getdetail (
      sendid       IN       NUMBER,                                 --发文编号
      out_cursor   OUT      refcursortype
   )
   IS
   BEGIN
      OPEN out_cursor FOR
         SELECT a.ID, b.dptname, c.username, a.title, a.sendcode,
                a.TIMESTAMP, a.score, a.content, a.annex,c.jobnumber,c.phone,
                CASE a.status
                   WHEN 0
                      THEN '已审核'
                   WHEN 1
                      THEN '未审核'
                   WHEN 2
                      THEN '草稿'
                   WHEN 3
                      THEN '已删除'
                   WHEN 4
                      THEN '隐藏'
                   WHEN 5
                      THEN '结贴'
                   ELSE '异常'
                END AS status
           FROM base_article a, base_dept b, base_user c
          WHERE     a.userid = c.userid
                AND a.deptid = b.deptid
                AND a.ID = sendid
                AND a.status = 0
             OR a.status = 5;
   END;

   /*
   ----------------------------------------------------------------------------
   --过程包名：proc_getdeptarticle
   --作　　者：王亚
   --时　　间：2012-5-18
   --说　　明：此过程用于获取发文列表 
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getpublishlist (
      dptcode      IN       NUMBER,                                 --部门编号
      typecode     IN       NUMBER,                                 --公文类别
      out_cursor   OUT      refcursortype
   )
   IS
   BEGIN
      OPEN out_cursor FOR
         SELECT b.dptname, c.username, a.title, a.content,
                TO_CHAR (a.TIMESTAMP, 'yyyy-mm-dd hh24:mi:ss') AS TIMESTAMP,
                a.score, a.annex, a.sendcode,a.id,
                CASE a.status
                   WHEN 0
                      THEN '已审核'
                   WHEN 1
                      THEN '未审核'
                   WHEN 2
                      THEN '草稿'
                   WHEN 3
                      THEN '已删除'
                   WHEN 4
                      THEN '隐藏'
                   WHEN 5
                      THEN '结贴'
                   ELSE '异常'
                END AS status,
                CASE a.isreply
                   WHEN 0
                      THEN '是'
                   WHEN 1
                      THEN '否'
                   ELSE '异常'
                END AS isreply
           FROM base_article a, base_dept b, base_user c,
                base_article_type d
          WHERE a.deptid = b.deptid
            AND a.userid = c.userid
            AND a.typeid = d.ID
            AND a.deptid = dptcode                                      --部门
            AND a.typeid = typecode                                     --类别            
            AND a.parentid = 0;                                         --发文
   END;
END;
/


-- End of DDL Script for Package ORAHYD.PKG_ARTICLE_QUERY

