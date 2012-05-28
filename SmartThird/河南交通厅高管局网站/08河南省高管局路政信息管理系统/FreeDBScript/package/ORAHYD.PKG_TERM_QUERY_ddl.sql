-- Start of DDL Script for Package ORAHYD.PKG_TERM_QUERY
-- Generated 28-����-2012 8:25:13 from ORAHYD@ORAHYD

-- Drop the old instance of PKG_TERM_QUERY
DROP PACKAGE orahyd.pkg_term_query
/

CREATE OR REPLACE 
PACKAGE orahyd.pkg_term_query
IS
/*
----------------------------------------------------------------------------
--���̰�����PKG_TERM_QUERY
--�������ߣ�����
--ʱ�����䣺2012-5-11
--˵���������˰�������Աװ�����ݲ�ѯ
----------------------------------------------------------------------------
*/
   TYPE refcursortype IS REF CURSOR;           --�α����Ͷ��壬���ڷ������ݼ�

   PROCEDURE proc_getterm (
      dpecode      IN       NUMBER,                                --���ű��
      issubdept    IN       NUMBER,                    --0�����Ӳ��ţ�1������
      out_cursor   OUT      refcursortype
   );
END;                                                           -- Package spec
/


CREATE OR REPLACE 
PACKAGE BODY orahyd.pkg_term_query
IS
   PROCEDURE proc_getterm (
      dpecode      IN       NUMBER,                                --���ű��
      issubdept    IN       NUMBER,                    --0�����Ӳ��ţ�1������
      out_cursor   OUT      refcursortype
   )
   IS
   /*
     ----------------------------------------------------------------------------
     --�洢���̣�proc_getterm
     --�������ߣ�����
     --ʱ�����䣺2012-05-11
     --˵����������ȡ��������Աװ������
     --���������
     --���������
     --------------------------------------------------------------------------
   */
   BEGIN
      --�����Ӳ�������
      IF issubdept = 0
      THEN
         OPEN out_cursor FOR
            SELECT     a.termid, a.termcode, a.termname, a.serialcode,
                       a.format, a.brand, a.USE,
                       TO_DATE (a.usetime, 'yyyy-mm-dd') AS usetime,
                       a.SAVEPOINT, a.remark, b.typename, c.dptname,
                       CASE a.status
                          WHEN 0
                             THEN '����'
                          WHEN 1
                             THEN 'ɾ��'
                          ELSE 'δ֪'
                       END AS status
                  FROM base_term a, base_term_type b, base_dept c
                 WHERE a.typeid = b.typeid
                   AND a.deptid = c.deptid
                   AND a.deptid = dpecode
            START WITH a.deptid = c.deptid
            CONNECT BY PRIOR c.deptid = c.parentid;
      ELSE
         --�������Ӳ���
         OPEN out_cursor FOR
            SELECT a.termid, a.termcode, a.termname, a.serialcode, a.format,
                   a.brand, a.USE,
                   TO_DATE (a.usetime, 'yyyy-mm-dd') AS usetime, a.SAVEPOINT,
                   a.remark, b.typename, c.dptname,
                   CASE a.status
                      WHEN 0
                         THEN '����'
                      WHEN 1
                         THEN 'ɾ��'
                      ELSE 'δ֪'
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

