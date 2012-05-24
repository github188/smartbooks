-- Start of DDL Script for Package ORAHYD.PKG_USER_QUERY
-- Generated 24-����-2012 8:38:44 from ORAHYD@ORAHYD

-- Drop the old instance of PKG_USER_QUERY
DROP PACKAGE orahyd.pkg_user_query
/

CREATE OR REPLACE 
PACKAGE orahyd.pkg_user_query
IS
/*
----------------------------------------------------------------------------
--���̰�����PKG_USER_QUERY
--�������ߣ�����
--ʱ�����䣺2012-5-04
--˵���������˰����ڲ�ѯ�û���Ϣ
----------------------------------------------------------------------------
*/
   TYPE refcursortype IS REF CURSOR;           --�α����Ͷ��壬���ڷ������ݼ�

   PROCEDURE proc_getdept (
      username     IN       VARCHAR2,                              --�û�����
      issubdept    IN       NUMBER,          --0:�����Ӳ���,����:�û���������
      out_cursor   OUT      refcursortype
   );

   PROCEDURE proc_getuser (
        dptcode in number,  --���ű�� 
        out_cursor OUT refcursortype --�α� 
   );
END;
/


CREATE OR REPLACE 
PACKAGE BODY orahyd.pkg_user_query
IS
   PROCEDURE proc_getdept (
      username     IN       VARCHAR2,                              --�û�����
      issubdept    IN       NUMBER,          --0:�����Ӳ���,����:�û���������
      out_cursor   OUT      refcursortype
   )
   IS
    /*
     ----------------------------------------------------------------------------
     --�洢���̣�proc_getdept
     --�������ߣ�����
     --ʱ�����䣺2012-05-07
     --˵��������
     --���������
     --���������
     --------------------------------------------------------------------------
   */
   BEGIN
      IF issubdept = 0                             --��ѯ�û��������ż��Ӳ���
      THEN
         OPEN out_cursor FOR
            SELECT     a.deptid, a.dptname, a.dptinfo, a.parentid
                  FROM base_dept a, base_user b
                 WHERE a.status = 0
            START WITH a.deptid = b.deptid
            CONNECT BY PRIOR a.deptid = a.parentid
              ORDER BY a.deptid;
      ELSE                                                  --��ѯ�û���������
         OPEN out_cursor FOR
            SELECT a.deptid, a.dptname, a.dptinfo, a.parentid
              FROM base_dept a, base_user b
             WHERE a.deptid = b.deptid
               AND a.status = 0
               AND b.username = username;
      END IF;
   END;

   --��ȡ�������û�
   PROCEDURE proc_getuser (
      dptcode      IN       NUMBER,                                 --���ű��
      out_cursor   OUT      refcursortype                           --�����α�
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
                         THEN '��'
                      WHEN 1
                         THEN 'Ů'
                      ELSE 'δ֪'
                   END AS sex,
                   CASE a.ststus
                      WHEN 0
                         THEN '����'
                      WHEN 1
                         THEN 'ɾ��'
                      ELSE 'δ֪'
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
                         THEN '��'
                      WHEN 1
                         THEN 'Ů'
                      ELSE 'δ֪'
                   END AS sex,
                   CASE a.ststus
                      WHEN 0
                         THEN '����'
                      WHEN 1
                         THEN 'ɾ��'
                      ELSE 'δ֪'
                   END AS status
              FROM base_user a, base_dept b
             WHERE a.deptid = b.deptid AND a.deptid = dptcode;
      END IF;
   END;
END;
/


-- End of DDL Script for Package ORAHYD.PKG_USER_QUERY

