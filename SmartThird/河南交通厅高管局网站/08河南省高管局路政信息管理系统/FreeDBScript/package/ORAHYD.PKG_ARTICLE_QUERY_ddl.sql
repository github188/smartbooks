-- Start of DDL Script for Package ORAHYD.PKG_ARTICLE_QUERY
-- Generated 18-五月-2012 18:29:44 from ORAHYD@ORAHYD

-- Drop the old instance of PKG_ARTICLE_QUERY
DROP PACKAGE orahyd.pkg_article_query
/

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
   --说　　明：此过程用户获取公文详细信息和回复信息
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getarticle (
      articleid    IN       NUMBER,                              --公文ID编号
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
   PROCEDURE proc_getdeptarticle (
      dptcode       IN       NUMBER,                                  --部门编号 
      typecode      IN       NUMBER,                                  --公文类别 
      statecode     IN       NUMBER,  --状态:0已审核1未审核2草稿3已删除4隐藏5结贴
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
   --说　　明：此过程用户获取公文详细信息和回复信息
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getarticle (
      articleid    IN       NUMBER,
      --公文ID编号
      out_cursor   OUT      refcursortype
   )
   IS
   BEGIN
      OPEN out_cursor FOR
         /*用户名,用户ID,工作证,电话,照片,部门名称,公文类别,标题,内容,时间,分值
         * 附件,发文字号,公文id,状态,允许回复,公文父ID
         */
         SELECT   c.username, c.userid, c.jobnumber, c.phone, c.photo,
                  d.dptname, b.typename, a.title, a.content,
                  TO_CHAR (a.TIMESTAMP, 'yyyy-mm-dd hh24:mi:ss') AS TIMESTAMP,
                  a.score, a.annex, a.sendcode, a.ID,
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
                  END AS isreply,
                  a.parentid
             FROM base_article a,
                  base_article_type b,
                  base_user c,
                  base_dept d
            WHERE a.userid = c.userid
              AND a.typeid = b.ID
              AND a.deptid = d.deptid
              AND a.ID = articleid
              AND a.parentid = a.ID
         ORDER BY a.TIMESTAMP;
   END;

   /*
   ----------------------------------------------------------------------------
   --过程包名：proc_getdeptarticle
   --作　　者：王亚
   --时　　间：2012-5-18
   --说　　明：此过程用于获取部门下公文列表
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getdeptarticle (
      dptcode      IN       NUMBER,                                 --部门编号
      typecode     IN       NUMBER,                                 --公文类别
      statecode    IN       NUMBER,--状态:0已审核1未审核2草稿3已删除4隐藏5结贴
      out_cursor   OUT      refcursortype
   )
   IS
   BEGIN
      OPEN out_cursor FOR
         SELECT b.dptname, c.username, d.typename, a.title, a.content,
                TO_CHAR (a.TIMESTAMP, 'yyyy-mm-dd hh24:mi:ss') AS TIMESTAMP,
                a.score, a.annex, a.sendcode,
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
            AND a.status = statecode                                    --状态
            AND a.isreply = 0;                                          --发文
   END;
END;
/


-- End of DDL Script for Package ORAHYD.PKG_ARTICLE_QUERY

