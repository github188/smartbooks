-- Start of DDL Script for Table ORAHYD.BASE_ARTICLE
-- Generated 29-����-2012 14:17:07 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_article
    (id                             NUMBER NOT NULL,
    userid                         NUMBER NOT NULL,
    deptid                         NUMBER NOT NULL,
    parentid                       NUMBER DEFAULT 0 NOT NULL,
    title                          VARCHAR2(200) NOT NULL,
    content                        VARCHAR2(4000) NOT NULL,
    timestamp                      DATE DEFAULT sysdate NOT NULL,
    score                          NUMBER DEFAULT 0 NOT NULL,
    annex                          VARCHAR2(200) NOT NULL,
    status                         NUMBER DEFAULT 0 NOT NULL,
    isreply                        NUMBER DEFAULT 0 NOT NULL,
    typeid                         NUMBER NOT NULL,
    sendcode                       VARCHAR2(80) NOT NULL)
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





-- Constraints for ORAHYD.BASE_ARTICLE

ALTER TABLE orahyd.base_article
ADD CONSTRAINT pk_base_article PRIMARY KEY (id)
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


-- Triggers for ORAHYD.BASE_ARTICLE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_ARTICLE
 BEFORE 
 INSERT
 ON BASE_ARTICLE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_article.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_ARTICLE

COMMENT ON TABLE orahyd.base_article IS '������Ϣ��'
/
COMMENT ON COLUMN orahyd.base_article.annex IS '����(���������·��)'
/
COMMENT ON COLUMN orahyd.base_article.content IS '��������'
/
COMMENT ON COLUMN orahyd.base_article.deptid IS '���ű��'
/
COMMENT ON COLUMN orahyd.base_article.id IS '����,����'
/
COMMENT ON COLUMN orahyd.base_article.isreply IS '����ظ���0����ظ�,1������ظ�'
/
COMMENT ON COLUMN orahyd.base_article.parentid IS '0�����ı�ţ�1�ظ����ı��'
/
COMMENT ON COLUMN orahyd.base_article.score IS '��ֵ'
/
COMMENT ON COLUMN orahyd.base_article.sendcode IS '�����ֺ�,����ָ�����ֺ�'
/
COMMENT ON COLUMN orahyd.base_article.status IS '״̬��0����ˣ�1δ��ˣ�2�ݸ壬3��ɾ����4���أ�5����'
/
COMMENT ON COLUMN orahyd.base_article.timestamp IS 'ʱ���'
/
COMMENT ON COLUMN orahyd.base_article.title IS '���ı���'
/
COMMENT ON COLUMN orahyd.base_article.typeid IS '��������������'
/
COMMENT ON COLUMN orahyd.base_article.userid IS '�û����'
/

-- End of DDL Script for Table ORAHYD.BASE_ARTICLE

