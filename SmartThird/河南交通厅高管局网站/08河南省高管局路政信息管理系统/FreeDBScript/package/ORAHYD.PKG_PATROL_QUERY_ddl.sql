-- Start of DDL Script for Package ORAHYD.PKG_PATROL_QUERY
-- Generated 18-����-2012 18:30:06 from ORAHYD@ORAHYD

-- Drop the old instance of PKG_PATROL_QUERY
DROP PACKAGE orahyd.pkg_patrol_query
/

CREATE OR REPLACE 
PACKAGE orahyd.pkg_patrol_query
IS
/*
----------------------------------------------------------------------------
--���̰�����PKG_PATROL_QUERY
--�������ߣ�����
--ʱ�����䣺2012-5-07
--˵���������˰�����Ѳ����־���ݲ�ѯ
----------------------------------------------------------------------------
*/
   TYPE refcursortype IS REF CURSOR;           --�α����Ͷ��壬���ڷ������ݼ�

   PROCEDURE proc_getdeptlog (
      begintime    IN       DATE,                              --��ѯ��ʼʱ��
      endtime      IN       DATE,                              --��ѯ����ʱ��
      dptcode      IN       NUMBER,                                --���ű��
      out_cursor   OUT      refcursortype
   );
END pkg_patrol_query;                                          -- Package spec
/


CREATE OR REPLACE 
PACKAGE BODY orahyd.pkg_patrol_query
IS
   PROCEDURE proc_getdeptlog (
      begintime    IN       DATE,                              --��ѯ��ʼʱ��
      endtime      IN       DATE,                              --��ѯ����ʱ��
      dptcode      IN       NUMBER,                                --���ű��
      out_cursor   OUT      refcursortype
   )
   IS
    /*
     ----------------------------------------------------------------------------
     --�洢���̣�proc_getdeptlog
     --�������ߣ�����
     --ʱ�����䣺2012-05-07
     --˵����������ȡָ��ID��Ų�����Ѳ����־
     --���������
     --���������
     --------------------------------------------------------------------------
   */
   BEGIN
      OPEN out_cursor FOR
         /*����,Ѳ����Ա,Ѳ�鳵�ƺ�,Ѳ�����,����,���Ӱ�ʱ��,�Ӱ�Ѳ�߳���̱�KM��*/
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

