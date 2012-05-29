-- Start of DDL Script for Package ORAHYD.PKG_ARTICLE_QUERY
-- Generated 29-����-2012 14:30:40 from ORAHYD@ORAHYD

CREATE OR REPLACE 
PACKAGE orahyd.pkg_article_query
IS
   /*
   ----------------------------------------------------------------------------
   --���̰�����PKG_ARTICLE_QUERY
   --�������ߣ�����
   --ʱ�����䣺2012-5-18
   --˵���������˰����ڲ�ѯ������Ϣ
   ----------------------------------------------------------------------------
   */
   TYPE refcursortype IS REF CURSOR;            --�α����Ͷ���,���ڷ������ݼ�

   /*
   ----------------------------------------------------------------------------
   --���̰�����proc_getarticle
   --�������ߣ�����
   --ʱ�����䣺2012-5-18
   --˵���������˹������ڻ�ȡ�ظ��б�
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getreplylist (
      sendid       IN       NUMBER,                                --���ı��
      out_cursor   OUT      refcursortype
   );

   /*
   ----------------------------------------------------------------------------
   --���̰�����proc_getreplydetail
   --�������ߣ�����
   --ʱ�����䣺2012-5-18
   --˵���������˹������ڻ�ȡ����������ϸ��Ϣ
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getdetail (
      sendid       IN       NUMBER,                                --���ı��
      out_cursor   OUT      refcursortype
   );

   /*
   ----------------------------------------------------------------------------
   --���̰�����proc_getdeptarticle
   --�������ߣ�����
   --ʱ�����䣺2012-5-18
   --˵���������˹��̸��ݲ��ű�źͷ����Ż�����Ϣ
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getpublishlist (
      dptcode      IN       NUMBER,                                --���ű��
      typecode     IN       NUMBER,                                --�������
      out_cursor   OUT      refcursortype
   );
END;
/


CREATE OR REPLACE 
PACKAGE BODY orahyd.pkg_article_query
IS
   /*
   ----------------------------------------------------------------------------
   --���̰�����proc_getarticle
   --�������ߣ�����
   --ʱ�����䣺2012-5-18
   --˵���������˹������ڻ�ȡ�ظ��б�
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getreplylist (
      sendid       IN       NUMBER,                                --���ı��
      out_cursor   OUT      refcursortype
   )
   IS
   BEGIN
      OPEN out_cursor FOR
         /*
         * ����,����״̬,����ʱ��,����,�����ֺ�,�ظ�ʱ��
         */
         SELECT   b.dptname,a.articleid,c.id,c.score,
                  CASE a.isread
                     WHEN 0
                        THEN 'δ����'
                     WHEN 1
                        THEN '�Ѳ���'
                     ELSE '�쳣'
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
   --���̰�����proc_getreplydetail
   --�������ߣ�����
   --ʱ�����䣺2012-5-18
   --˵���������˹������ڻ�ȡ����������ϸ��Ϣ
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getdetail (
      sendid       IN       NUMBER,                                 --���ı��
      out_cursor   OUT      refcursortype
   )
   IS
   BEGIN
      OPEN out_cursor FOR
         SELECT a.ID, b.dptname, c.username, a.title, a.sendcode,
                a.TIMESTAMP, a.score, a.content, a.annex,c.jobnumber,c.phone,
                CASE a.status
                   WHEN 0
                      THEN '�����'
                   WHEN 1
                      THEN 'δ���'
                   WHEN 2
                      THEN '�ݸ�'
                   WHEN 3
                      THEN '��ɾ��'
                   WHEN 4
                      THEN '����'
                   WHEN 5
                      THEN '����'
                   ELSE '�쳣'
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
   --���̰�����proc_getdeptarticle
   --�������ߣ�����
   --ʱ�����䣺2012-5-18
   --˵���������˹������ڻ�ȡ�����б� 
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getpublishlist (
      dptcode      IN       NUMBER,                                 --���ű��
      typecode     IN       NUMBER,                                 --�������
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
                      THEN '�����'
                   WHEN 1
                      THEN 'δ���'
                   WHEN 2
                      THEN '�ݸ�'
                   WHEN 3
                      THEN '��ɾ��'
                   WHEN 4
                      THEN '����'
                   WHEN 5
                      THEN '����'
                   ELSE '�쳣'
                END AS status,
                CASE a.isreply
                   WHEN 0
                      THEN '��'
                   WHEN 1
                      THEN '��'
                   ELSE '�쳣'
                END AS isreply
           FROM base_article a, base_dept b, base_user c,
                base_article_type d
          WHERE a.deptid = b.deptid
            AND a.userid = c.userid
            AND a.typeid = d.ID
            AND a.deptid = dptcode                                      --����
            AND a.typeid = typecode                                     --���            
            AND a.parentid = 0;                                         --����
   END;
END;
/


-- End of DDL Script for Package ORAHYD.PKG_ARTICLE_QUERY

