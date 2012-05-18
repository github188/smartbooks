-- Start of DDL Script for Package ORAHYD.PKG_ARTICLE_QUERY
-- Generated 18-����-2012 18:29:44 from ORAHYD@ORAHYD

-- Drop the old instance of PKG_ARTICLE_QUERY
DROP PACKAGE orahyd.pkg_article_query
/

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
   --˵���������˹����û���ȡ������ϸ��Ϣ�ͻظ���Ϣ
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getarticle (
      articleid    IN       NUMBER,                              --����ID���
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
   PROCEDURE proc_getdeptarticle (
      dptcode       IN       NUMBER,                                  --���ű�� 
      typecode      IN       NUMBER,                                  --������� 
      statecode     IN       NUMBER,  --״̬:0�����1δ���2�ݸ�3��ɾ��4����5����
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
   --˵���������˹����û���ȡ������ϸ��Ϣ�ͻظ���Ϣ
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getarticle (
      articleid    IN       NUMBER,
      --����ID���
      out_cursor   OUT      refcursortype
   )
   IS
   BEGIN
      OPEN out_cursor FOR
         /*�û���,�û�ID,����֤,�绰,��Ƭ,��������,�������,����,����,ʱ��,��ֵ
         * ����,�����ֺ�,����id,״̬,����ظ�,���ĸ�ID
         */
         SELECT   c.username, c.userid, c.jobnumber, c.phone, c.photo,
                  d.dptname, b.typename, a.title, a.content,
                  TO_CHAR (a.TIMESTAMP, 'yyyy-mm-dd hh24:mi:ss') AS TIMESTAMP,
                  a.score, a.annex, a.sendcode, a.ID,
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
   --���̰�����proc_getdeptarticle
   --�������ߣ�����
   --ʱ�����䣺2012-5-18
   --˵���������˹������ڻ�ȡ�����¹����б�
   ----------------------------------------------------------------------------
   */
   PROCEDURE proc_getdeptarticle (
      dptcode      IN       NUMBER,                                 --���ű��
      typecode     IN       NUMBER,                                 --�������
      statecode    IN       NUMBER,--״̬:0�����1δ���2�ݸ�3��ɾ��4����5����
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
            AND a.status = statecode                                    --״̬
            AND a.isreply = 0;                                          --����
   END;
END;
/


-- End of DDL Script for Package ORAHYD.PKG_ARTICLE_QUERY

