-- Start of DDL Script for Table ORAHYD.BASE_PATROL_GOODS
-- Generated 29-����-2012 14:24:54 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_patrol_goods
    (patrolgoodsid                  NUMBER NOT NULL,
    patrolid                       NUMBER NOT NULL,
    amount                         NUMBER DEFAULT 0 NOT NULL,
    toolname                       VARCHAR2(50) DEFAULT '��' NOT NULL)
  PCTFREE     10
  INITRANS    1
  MAXTRANS    255
  TABLESPACE  users
  STORAGE   (
    INITIAL     65536
    MINEXTENTS  1
    MAXEXTENTS  2147483645
  )
/





-- Constraints for ORAHYD.BASE_PATROL_GOODS

ALTER TABLE orahyd.base_patrol_goods
ADD CONSTRAINT pk_base_patrol_goods PRIMARY KEY (patrolgoodsid)
USING INDEX
  PCTFREE     10
  INITRANS    2
  MAXTRANS    255
  TABLESPACE  users
  STORAGE   (
    INITIAL     65536
    MINEXTENTS  1
    MAXEXTENTS  2147483645
  )
/


-- Triggers for ORAHYD.BASE_PATROL_GOODS

CREATE OR REPLACE TRIGGER TRG_BASE_PATROL_GOODS
 BEFORE 
 INSERT
 ON BASE_PATROL_GOODS
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_PATROL_GOODS.NEXTVAL
     INTO :NEW.PATROLGOODSID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_PATROL_GOODS

COMMENT ON TABLE orahyd.base_patrol_goods IS '�ƽ����ı�'
/
COMMENT ON COLUMN orahyd.base_patrol_goods.amount IS '��������'
/
COMMENT ON COLUMN orahyd.base_patrol_goods.patrolgoodsid IS '���'
/
COMMENT ON COLUMN orahyd.base_patrol_goods.patrolid IS 'Ѳ����־���'
/
COMMENT ON COLUMN orahyd.base_patrol_goods.toolname IS '��������'
/

-- End of DDL Script for Table ORAHYD.BASE_PATROL_GOODS

