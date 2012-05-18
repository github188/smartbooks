-- Start of DDL Script for Table ORAHYD.BASE_AFFICHE
-- Generated 18-五月-2012 18:25:56 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_AFFICHE
DROP TABLE orahyd.base_affiche CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_affiche
    (afficheid                      NUMBER NOT NULL,
    affichetitle                   VARCHAR2(60) NOT NULL,
    affichecontents                VARCHAR2(1000),
    afficher                       VARCHAR2(20),
    affichedate                    DATE DEFAULT sysdate,
    states                         NUMBER DEFAULT 0)
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





-- Constraints for ORAHYD.BASE_AFFICHE

ALTER TABLE orahyd.base_affiche
ADD CONSTRAINT pk_base_affiche PRIMARY KEY (afficheid)
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


-- Triggers for ORAHYD.BASE_AFFICHE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_AFFICHE
 BEFORE 
 INSERT
 ON BASE_AFFICHE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_affiche.NEXTVAL
     INTO :NEW.AFFICHEID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_AFFICHE

COMMENT ON TABLE orahyd.base_affiche IS '公告信息表'
/
COMMENT ON COLUMN orahyd.base_affiche.affichecontents IS '公告内容'
/
COMMENT ON COLUMN orahyd.base_affiche.affichedate IS '公告发布时间'
/
COMMENT ON COLUMN orahyd.base_affiche.afficheid IS '公告编号'
/
COMMENT ON COLUMN orahyd.base_affiche.afficher IS '公告发布人'
/
COMMENT ON COLUMN orahyd.base_affiche.affichetitle IS '公告标题'
/
COMMENT ON COLUMN orahyd.base_affiche.states IS '公告状态(0:已保存；1：已发布；2：已删除)'
/

-- End of DDL Script for Table ORAHYD.BASE_AFFICHE

