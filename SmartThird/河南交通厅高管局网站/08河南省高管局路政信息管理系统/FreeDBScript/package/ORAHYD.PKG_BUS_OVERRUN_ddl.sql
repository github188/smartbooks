-- Start of DDL Script for Package ORAHYD.PKG_BUS_OVERRUN
-- Generated 29-����-2012 14:31:10 from ORAHYD@ORAHYD

CREATE OR REPLACE 
PACKAGE orahyd.pkg_bus_overrun
IS
/*
----------------------------------------------------------------------------
--���̰�����pkg_bus_overrun
--�������ߣ�����
--ʱ�����䣺2012-5-04
--˵���������˰����ڳ����������ݲ�ѯ
----------------------------------------------------------------------------
*/
   TYPE refcursortype IS REF CURSOR;           --�α����Ͷ��壬���ڷ������ݼ�

   PROCEDURE rpt_busaccount (
      prmbegindate   IN       VARCHAR2,                        --��ѯ��ʼʱ��
      prmenddate     IN       VARCHAR2,                        --��ѯ����ʱ��
      out_cursor     OUT      refcursortype
   );
END pkg_bus_overrun;
/


CREATE OR REPLACE 
PACKAGE BODY orahyd.pkg_bus_overrun
IS
   PROCEDURE rpt_busaccount (
      prmbegindate   IN       VARCHAR2,                        --��ѯ��ʼʱ��
      prmenddate     IN       VARCHAR2,                        --��ѯ����ʱ��
      out_cursor     OUT      refcursortype
   )
   IS
    /*
     ----------------------------------------------------------------------------
     --�洢���̣�rpt_busaccount
     --�������ߣ�����
     --ʱ�����䣺2012-05-04
     --˵�����������ܳ��޳�������
     --���������
     --���������
     --------------------------------------------------------------------------
   */
   BEGIN
      OPEN out_cursor FOR
         SELECT *
           FROM base_action;
   END;
END pkg_bus_overrun;
/


-- End of DDL Script for Package ORAHYD.PKG_BUS_OVERRUN

