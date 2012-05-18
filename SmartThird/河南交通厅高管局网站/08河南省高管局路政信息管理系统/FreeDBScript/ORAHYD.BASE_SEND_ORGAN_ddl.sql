-- Start of DDL Script for Table ORAHYD.BASE_SEND_ORGAN
-- Generated 18-����-2012 18:28:56 from ORAHYD@ORAHYD

-- Drop the old instance of BASE_SEND_ORGAN
DROP TABLE orahyd.base_send_organ CASCADE CONSTRAINTS
/

CREATE TABLE orahyd.base_send_organ
    (sid                            NUMBER NOT NULL,
    f_organid                      NUMBER,
    s_organid                      NUMBER,
    state                          VARCHAR2(20),
    remark                         VARCHAR2(200))
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





-- Constraints for ORAHYD.BASE_SEND_ORGAN

ALTER TABLE orahyd.base_send_organ
ADD CONSTRAINT pk_base_send_organ PRIMARY KEY (sid)
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


-- Comments for ORAHYD.BASE_SEND_ORGAN

COMMENT ON TABLE orahyd.base_send_organ IS '���ĵ�λ��'
/
COMMENT ON COLUMN orahyd.base_send_organ.f_organid IS '���ĵ�λ���'
/
COMMENT ON COLUMN orahyd.base_send_organ.remark IS '��ע'
/
COMMENT ON COLUMN orahyd.base_send_organ.s_organid IS '���ĵ�λ���'
/
COMMENT ON COLUMN orahyd.base_send_organ.sid IS '���'
/
COMMENT ON COLUMN orahyd.base_send_organ.state IS '״̬'
/

-- End of DDL Script for Table ORAHYD.BASE_SEND_ORGAN

