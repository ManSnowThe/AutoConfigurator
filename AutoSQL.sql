prompt
prompt Creating table CONF_AC_USER
prompt ===========================
prompt
create table STUDENT.CONF_AC_USER
(
  id         NUMBER not null,
  surname    VARCHAR2(25) not null,
  name       VARCHAR2(25) not null,
  patronymic VARCHAR2(25)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_AC_USER
  add constraint ID_USR primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_AC_ACCOUNT
prompt ==============================
prompt
create table STUDENT.CONF_AC_ACCOUNT
(
  id       NUMBER not null,
  login    VARCHAR2(25) not null,
  password VARCHAR2(25),
  id_user  NUMBER not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_AC_ACCOUNT
  add constraint ID_ACCOUNT primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_AC_ACCOUNT
  add constraint ID_USER foreign key (ID_USER)
  references STUDENT.CONF_AC_USER (ID);

prompt
prompt Creating table CONF_AC_ACCOUNT_LOG
prompt ==================================
prompt
create table STUDENT.CONF_AC_ACCOUNT_LOG
(
  who        VARCHAR2(200) not null,
  operation  VARCHAR2(200) not null,
  time_stamp TIMESTAMP(6) not null,
  id         NUMBER,
  login      VARCHAR2(25),
  password   VARCHAR2(25),
  id_user    NUMBER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;

prompt
prompt Creating table CONF_AC_USER_LOG
prompt ===============================
prompt
create table STUDENT.CONF_AC_USER_LOG
(
  who        VARCHAR2(200) not null,
  operation  VARCHAR2(200) not null,
  time_stamp TIMESTAMP(6) not null,
  id         NUMBER,
  surname    VARCHAR2(25),
  name       VARCHAR2(25),
  patronymic VARCHAR2(25)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;

prompt
prompt Creating table CONF_AC_USER_ROLE
prompt ================================
prompt
create table STUDENT.CONF_AC_USER_ROLE
(
  id   NUMBER not null,
  name VARCHAR2(25) not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_AC_USER_ROLE
  add constraint ID_ROLE primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_AC_USER_ROLE_LOG
prompt ====================================
prompt
create table STUDENT.CONF_AC_USER_ROLE_LOG
(
  who        VARCHAR2(200) not null,
  operation  VARCHAR2(200) not null,
  time_stamp TIMESTAMP(6) not null,
  id         NUMBER,
  name       VARCHAR2(25)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;

prompt
prompt Creating table CONF_AC_USER_USROLE_REL
prompt ======================================
prompt
create table STUDENT.CONF_AC_USER_USROLE_REL
(
  id_user NUMBER not null,
  id_role NUMBER not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_AC_USER_USROLE_REL
  add constraint ROLE_ID foreign key (ID_ROLE)
  references STUDENT.CONF_AC_USER_ROLE (ID);
alter table STUDENT.CONF_AC_USER_USROLE_REL
  add constraint USER_ID foreign key (ID_USER)
  references STUDENT.CONF_AC_USER (ID);

prompt
prompt Creating table CONF_AC_USER_USROLE_REL_LOG
prompt ==========================================
prompt
create table STUDENT.CONF_AC_USER_USROLE_REL_LOG
(
  who        VARCHAR2(200) not null,
  operation  VARCHAR2(200) not null,
  time_stamp TIMESTAMP(6) not null,
  id_user    NUMBER,
  id_role    NUMBER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;

prompt
prompt Creating table CONF_TYPE_EXTERIOR
prompt =================================
prompt
create table STUDENT.CONF_TYPE_EXTERIOR
(
  id   NUMBER not null,
  name VARCHAR2(25) not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_TYPE_EXTERIOR
  add constraint ID_EXT primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_EXTERIOR
prompt ============================
prompt
create table STUDENT.CONF_EXTERIOR
(
  id            NUMBER not null,
  name          VARCHAR2(100) not null,
  delivery_date DATE not null,
  id_type       NUMBER not null,
  price         NUMBER(8,2) not null,
  access_open   DATE not null,
  access_close  DATE not null,
  specification VARCHAR2(200),
  image         BLOB
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_EXTERIOR
  add constraint ID_EXTER primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_EXTERIOR
  add constraint ID_TYPE_EXTER foreign key (ID_TYPE)
  references STUDENT.CONF_TYPE_EXTERIOR (ID);

prompt
prompt Creating table CONF_EXTERIOR_LOG
prompt ================================
prompt
create table STUDENT.CONF_EXTERIOR_LOG
(
  who           VARCHAR2(200) not null,
  operation     VARCHAR2(200) not null,
  time_stamp    TIMESTAMP(6) not null,
  id            NUMBER,
  name          VARCHAR2(100),
  delivery_date DATE,
  id_type       NUMBER,
  price         NUMBER(8,2),
  access_open   DATE,
  access_close  DATE,
  specification VARCHAR2(200)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_TYPE_INTERIOR
prompt =================================
prompt
create table STUDENT.CONF_TYPE_INTERIOR
(
  id   NUMBER not null,
  name VARCHAR2(25) not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_TYPE_INTERIOR
  add constraint ID_INT primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_INTERIOR
prompt ============================
prompt
create table STUDENT.CONF_INTERIOR
(
  id            NUMBER not null,
  name          VARCHAR2(100) not null,
  delivery_date DATE not null,
  id_type       NUMBER not null,
  specification VARCHAR2(200),
  price         NUMBER(8,2) not null,
  access_open   DATE not null,
  access_close  DATE not null,
  image         BLOB
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_INTERIOR
  add constraint ID_INTER primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_INTERIOR
  add constraint ID_TYPE_INTER foreign key (ID_TYPE)
  references STUDENT.CONF_TYPE_INTERIOR (ID);

prompt
prompt Creating table CONF_INTERIOR_LOG
prompt ================================
prompt
create table STUDENT.CONF_INTERIOR_LOG
(
  who           VARCHAR2(200) not null,
  operation     VARCHAR2(200) not null,
  time_stamp    TIMESTAMP(6) not null,
  id            NUMBER,
  name          VARCHAR2(100),
  delivery_date DATE,
  id_type       NUMBER,
  specification VARCHAR2(200),
  price         NUMBER(8,2),
  access_open   DATE,
  access_close  DATE
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_SERIES
prompt ==========================
prompt
create table STUDENT.CONF_SERIES
(
  id    NUMBER not null,
  name  VARCHAR2(25) not null,
  image BLOB
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_SERIES
  add constraint ID_SER primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_MODEL
prompt =========================
prompt
create table STUDENT.CONF_MODEL
(
  id            NUMBER not null,
  name          VARCHAR2(75) not null,
  delivery_date DATE not null,
  id_series     NUMBER not null,
  specification VARCHAR2(1500),
  price         NUMBER(12,2) not null,
  access_open   DATE not null,
  access_close  DATE not null,
  image         BLOB
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_MODEL
  add constraint ID_MOD primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_MODEL
  add constraint ID_SERIES foreign key (ID_SERIES)
  references STUDENT.CONF_SERIES (ID);

prompt
prompt Creating table CONF_MODEL_LOG
prompt =============================
prompt
create table STUDENT.CONF_MODEL_LOG
(
  who           VARCHAR2(200) not null,
  operation     VARCHAR2(200) not null,
  time_stamp    TIMESTAMP(6) not null,
  id            NUMBER,
  name          VARCHAR2(75),
  delivery_date DATE,
  id_series     NUMBER,
  specification VARCHAR2(1500),
  price         NUMBER(12,2),
  access_open   DATE,
  access_close  DATE
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_MOD_EXT_REL
prompt ===============================
prompt
create table STUDENT.CONF_MOD_EXT_REL
(
  id_model    NUMBER not null,
  id_exterior NUMBER not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_MOD_EXT_REL
  add constraint ID_EXTERIOR1 foreign key (ID_EXTERIOR)
  references STUDENT.CONF_EXTERIOR (ID);
alter table STUDENT.CONF_MOD_EXT_REL
  add constraint ID_MODEL1 foreign key (ID_MODEL)
  references STUDENT.CONF_MODEL (ID);

prompt
prompt Creating table CONF_MOD_EXT_REL_LOG
prompt ===================================
prompt
create table STUDENT.CONF_MOD_EXT_REL_LOG
(
  who         VARCHAR2(200) not null,
  operation   VARCHAR2(200) not null,
  time_stamp  TIMESTAMP(6) not null,
  id_model    NUMBER,
  id_exterior NUMBER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_MOD_INT_REL
prompt ===============================
prompt
create table STUDENT.CONF_MOD_INT_REL
(
  id_model    NUMBER not null,
  id_interior NUMBER not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_MOD_INT_REL
  add constraint ID_INTERIOR1 foreign key (ID_INTERIOR)
  references STUDENT.CONF_INTERIOR (ID);
alter table STUDENT.CONF_MOD_INT_REL
  add constraint ID_MODEL2 foreign key (ID_MODEL)
  references STUDENT.CONF_MODEL (ID);

prompt
prompt Creating table CONF_MOD_INT_REL_LOG
prompt ===================================
prompt
create table STUDENT.CONF_MOD_INT_REL_LOG
(
  who         VARCHAR2(200) not null,
  operation   VARCHAR2(200) not null,
  time_stamp  TIMESTAMP(6) not null,
  id_model    NUMBER,
  id_interior NUMBER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_TYPE_OPTIONS
prompt ================================
prompt
create table STUDENT.CONF_TYPE_OPTIONS
(
  id   NUMBER not null,
  name VARCHAR2(60) not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_TYPE_OPTIONS
  add constraint ID_OPT primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_OPTIONS
prompt ===========================
prompt
create table STUDENT.CONF_OPTIONS
(
  id            NUMBER not null,
  name          VARCHAR2(100) not null,
  delivery_date DATE not null,
  id_type       NUMBER not null,
  specification VARCHAR2(200),
  price         NUMBER(8,2) not null,
  access_open   DATE not null,
  access_close  DATE not null,
  image         BLOB
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_OPTIONS
  add constraint ID_OPTI primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_OPTIONS
  add constraint ID_TYPE_OPTI foreign key (ID_TYPE)
  references STUDENT.CONF_TYPE_OPTIONS (ID);

prompt
prompt Creating table CONF_MOD_OPT_REL
prompt ===============================
prompt
create table STUDENT.CONF_MOD_OPT_REL
(
  id_model   NUMBER not null,
  id_options NUMBER not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_MOD_OPT_REL
  add constraint ID_MODEL3 foreign key (ID_MODEL)
  references STUDENT.CONF_MODEL (ID);
alter table STUDENT.CONF_MOD_OPT_REL
  add constraint ID_OPTIONS1 foreign key (ID_OPTIONS)
  references STUDENT.CONF_OPTIONS (ID);

prompt
prompt Creating table CONF_MOD_OPT_REL_LOG
prompt ===================================
prompt
create table STUDENT.CONF_MOD_OPT_REL_LOG
(
  who        VARCHAR2(200) not null,
  operation  VARCHAR2(200) not null,
  time_stamp TIMESTAMP(6) not null,
  id_model   NUMBER,
  id_options NUMBER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_OPTIONS_LOG
prompt ===============================
prompt
create table STUDENT.CONF_OPTIONS_LOG
(
  who           VARCHAR2(200) not null,
  operation     VARCHAR2(200) not null,
  time_stamp    TIMESTAMP(6) not null,
  id            NUMBER,
  name          VARCHAR2(100),
  delivery_date DATE,
  id_type       NUMBER,
  specification VARCHAR2(200),
  price         NUMBER(8,2),
  access_open   DATE,
  access_close  DATE
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_ORDER
prompt =========================
prompt
create table STUDENT.CONF_ORDER
(
  id         NUMBER not null,
  id_client  NUMBER not null,
  order_date DATE not null,
  status     VARCHAR2(25)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_ORDER
  add constraint ID_ORD primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_ORDER
  add constraint ID_CLIENT foreign key (ID_CLIENT)
  references STUDENT.CONF_AC_ACCOUNT (ID);

prompt
prompt Creating table CONF_ORDER_AUTO
prompt ==============================
prompt
create table STUDENT.CONF_ORDER_AUTO
(
  id_order_auto NUMBER not null,
  id_order      NUMBER not null,
  id_part_ser   NUMBER,
  specification VARCHAR2(200),
  id_part_mod   NUMBER,
  id_part_ext   NUMBER,
  id_part_int   NUMBER,
  id_part_opt   NUMBER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_ORDER_AUTO
  add constraint ID_ORDER_AUTO primary key (ID_ORDER_AUTO)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.CONF_ORDER_AUTO
  add constraint ID_ORDER foreign key (ID_ORDER)
  references STUDENT.CONF_ORDER (ID);
alter table STUDENT.CONF_ORDER_AUTO
  add constraint ID_PART_EXT foreign key (ID_PART_EXT)
  references STUDENT.CONF_EXTERIOR (ID);
alter table STUDENT.CONF_ORDER_AUTO
  add constraint ID_PART_INT foreign key (ID_PART_INT)
  references STUDENT.CONF_INTERIOR (ID);
alter table STUDENT.CONF_ORDER_AUTO
  add constraint ID_PART_MOD foreign key (ID_PART_MOD)
  references STUDENT.CONF_MODEL (ID);
alter table STUDENT.CONF_ORDER_AUTO
  add constraint ID_PART_OPT foreign key (ID_PART_OPT)
  references STUDENT.CONF_OPTIONS (ID);
alter table STUDENT.CONF_ORDER_AUTO
  add constraint ID_PART_SER foreign key (ID_PART_SER)
  references STUDENT.CONF_SERIES (ID);

prompt
prompt Creating table CONF_ORDER_AUTO_LOG
prompt ==================================
prompt
create table STUDENT.CONF_ORDER_AUTO_LOG
(
  who           VARCHAR2(200) not null,
  operation     VARCHAR2(200) not null,
  time_stamp    TIMESTAMP(6) not null,
  id_order_auto NUMBER,
  id_order      NUMBER,
  id_part_ser   NUMBER,
  specification VARCHAR2(200),
  id_part_mod   NUMBER,
  id_part_ext   NUMBER,
  id_part_int   NUMBER,
  id_part_opt   NUMBER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_ORDER_LOG
prompt =============================
prompt
create table STUDENT.CONF_ORDER_LOG
(
  who        VARCHAR2(200) not null,
  operation  VARCHAR2(200) not null,
  time_stamp TIMESTAMP(6) not null,
  id         NUMBER,
  id_client  NUMBER,
  order_date DATE,
  status     VARCHAR2(25)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_SERIES_LOG
prompt ==============================
prompt
create table STUDENT.CONF_SERIES_LOG
(
  who        VARCHAR2(200) not null,
  operation  VARCHAR2(200) not null,
  time_stamp TIMESTAMP(6) not null,
  id         NUMBER,
  name       VARCHAR2(25)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CONF_TYPE_EXTERIOR_LOG
prompt =====================================
prompt
create table STUDENT.CONF_TYPE_EXTERIOR_LOG
(
  who        VARCHAR2(200) not null,
  operation  VARCHAR2(200) not null,
  time_stamp TIMESTAMP(6) not null,
  id         NUMBER,
  name       VARCHAR2(25)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;

prompt
prompt Creating table CONF_TYPE_INTERIOR_LOG
prompt =====================================
prompt
create table STUDENT.CONF_TYPE_INTERIOR_LOG
(
  who        VARCHAR2(200) not null,
  operation  VARCHAR2(200) not null,
  time_stamp TIMESTAMP(6) not null,
  id         NUMBER,
  name       VARCHAR2(25)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;

prompt
prompt Creating table CONF_TYPE_OPTIONS_LOG
prompt ====================================
prompt
create table STUDENT.CONF_TYPE_OPTIONS_LOG
(
  who        VARCHAR2(200) not null,
  operation  VARCHAR2(200) not null,
  time_stamp TIMESTAMP(6) not null,
  id         NUMBER,
  name       VARCHAR2(60)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;

prompt
prompt Creating table DT_USER_TYPE
prompt ===========================
prompt
create table STUDENT.DT_USER_TYPE
(
  id   NUMBER not null,
  name VARCHAR2(10) not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.DT_USER_TYPE
  add primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.DT_USER_TYPE
  add unique (NAME)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table DT_USER
prompt ======================
prompt
create table STUDENT.DT_USER
(
  id           NUMBER not null,
  user_type_id NUMBER,
  user_fam     VARCHAR2(100) not null,
  user_name    VARCHAR2(100) not null,
  user_otch    VARCHAR2(100)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.DT_USER
  add primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.DT_USER
  add constraint DT_USER_DT_USER_TYPE foreign key (USER_TYPE_ID)
  references STUDENT.DT_USER_TYPE (ID);

prompt
prompt Creating table DT_ACCOUNT
prompt =========================
prompt
create table STUDENT.DT_ACCOUNT
(
  id       NUMBER not null,
  login    VARCHAR2(100),
  password VARCHAR2(100),
  user_id  NUMBER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.DT_ACCOUNT
  add primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table STUDENT.DT_ACCOUNT
  add constraint DT_ACCOUNT_DT_USER foreign key (USER_ID)
  references STUDENT.DT_USER (ID);

prompt
prompt Creating table FILE_
prompt ====================
prompt
create table STUDENT.FILE_
(
  id                     NUMBER(11) not null,
  name                   VARCHAR2(50) not null,
  fsize                  NUMBER(11) not null,
  fdata                  BLOB not null,
  content_type           VARCHAR2(200) not null,
  authorization_required NUMBER(11) not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;
alter table STUDENT.FILE_
  add primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255;

prompt
prompt Creating table RENT
prompt ===================
prompt
create table STUDENT.RENT
(
  id   NUMBER,
  name VARCHAR2(50)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table TEST_CRM
prompt =======================
prompt
create table STUDENT.TEST_CRM
(
  col1 VARCHAR2(50),
  col2 VARCHAR2(50)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating package CONF_PKG_DEV
prompt =============================
prompt
create or replace package student.CONF_PKG_DEV is

procedure table_names
  (
  out_name out sys_refcursor
  );
  
procedure table_names_order
  (
  out_name out sys_refcursor
  );

procedure tables_names_logs
  (
  out_name out sys_refcursor
  );

procedure get_table
  (
  in_name in varchar2,
  out_name out sys_refcursor
  );

procedure delete_row
  (
  in_name in varchar2,
  in_column in varchar2,
  condition in varchar2
  );

procedure update_row
  (
  in_name in varchar2,
  in_column in varchar2,
  in_val in varchar2 default null,
  in_column_1 in varchar2,
  condition in varchar2
  );
  
procedure insert_row
  (
  in_name in varchar2,
  in_val in varchar2 default null
  --condition in varchar2
  );

end CONF_PKG_DEV;
/

prompt
prompt Creating type CONF_USR_SERIES
prompt =============================
prompt
create or replace type student.conf_usr_series as object (id number, name varchar2(25))
/

prompt
prompt Creating type TABLE_OF_CONF_USR_SERIES
prompt ======================================
prompt
create or replace type student.table_of_conf_usr_series as table of conf_usr_series
/

prompt
prompt Creating package CONF_PKG_USR_SELECT
prompt ====================================
prompt
create or replace package student.conf_pkg_usr_select is

function get_series_test
  (
  id in number,
  name in varchar2,
  errcode out varchar2,
  msg out varchar2
  ) return table_of_conf_usr_series;

  function test1
    (
    n1 in number,
    n2 in number,
    n3 out number
    ) return number;

procedure get_series_1
  (
  out_all out sys_refcursor
  );

    procedure get_model
      (
      ser_id in number,
      out_name out sys_refcursor
      );

procedure get_model_1
  (
  ser_id in number,
  out_name out sys_refcursor
  );

procedure get_ext_rel
  (
  model_id in number,
  ext_id in number default null,
  out_name out sys_refcursor
  );

procedure get_int_rel
  (
  model_id in number,
  int_id in number default null,
  out_name out sys_refcursor
  );

procedure get_opt_rel
  (
  model_id in number,
  opt_id in number default null,
  out_name out sys_refcursor
  );

procedure get_opt_type
  (
  out_name out sys_refcursor
  );

procedure insert_order_auto
  (
  id_ord in number,
  id_prt_ser in number default null,
  id_prt_mod in number default null,
  id_prt_ext in number default null,
  id_prt_int in number default null,
  id_prt_opt in number default null
  );

procedure select_order_auto
  (
  in_client in number,
  out_name out sys_refcursor
  );

procedure comm;

procedure svpoint;

procedure delete_order
  (
  id_ord in number,
  cond in number default null
  );

procedure login
  (
  log in varchar2,
  pass in varchar2,
  out_name out sys_refcursor
  );

procedure login2
  (
  log in varchar2,
  pass in varchar2,
  out_name out sys_refcursor
  );

procedure conf_order_add
  (
  in_client in number
  --out_client out number
  );

procedure conf_order_get
  (
  out_name out sys_refcursor
  );




procedure get_order_auto_count
  (
  out_name out sys_refcursor
  );
  
procedure get_model_2
  (
  mod_id in number,
  out_name out sys_refcursor
  );
  
procedure get_order_auto_count_ser
  (
  out_name out sys_refcursor
  );
  
procedure get_series_2
  (
  ser_id in number,
  out_name out sys_refcursor
  );
  
procedure get_order_auto_count_ext
  (
  out_name out sys_refcursor
  );
  
procedure get_exterior_2
  (
  ext_id in number,
  out_name out sys_refcursor
  );
  
procedure get_order_auto_count_int
  (
  out_name out sys_refcursor
  );

procedure get_interior_2
  (
  int_id in number,
  out_name out sys_refcursor
  );

end conf_pkg_usr_select;
/

prompt
prompt Creating package body CONF_PKG_DEV
prompt ==================================
prompt
create or replace package body student.CONF_PKG_DEV is

procedure table_names
  (
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select *
    from user_tables
    where table_name like 'CONF%' AND table_name not like '%_LOG';
    end;
    
procedure table_names_order
  (
  out_name out sys_refcursor
  )
  is 
  begin
    open out_name for
    select *
    from user_tables
    where table_name like 'CONF_ORDER%' OR table_name like 'CONF_AC_USER';
    end;
    
procedure tables_names_logs
  (
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select *
    from user_tables
    where table_name like '%_LOG';
    end;

procedure get_table
  (
  in_name in varchar2,
  out_name out sys_refcursor
  )
  is
  sql_stmt varchar(200);
  begin
    sql_stmt := 'SELECT * FROM '||in_name||' order by 1';
    execute immediate sql_stmt;
    open out_name for
    sql_stmt;
    end;

procedure delete_row
  (
  in_name in varchar2,
  in_column in varchar2,
  condition in varchar2
  )
  is
  sql_stmt varchar(200);
  begin
    sql_stmt := 'DELETE FROM '||in_name||' WHERE '||in_column||' = '||condition||'';
    execute immediate sql_stmt;
    end;

procedure update_row
  (
  in_name in varchar2,
  in_column in varchar2,
  in_val in varchar2 default null,
  in_column_1 in varchar2,
  condition in varchar2
  )
  is
  sql_stmt varchar(200);
  begin
    sql_stmt := 'UPDATE '||in_name||' SET '||in_column||' = '||in_val||' WHERE '||in_column_1||' = '||condition||'';
    execute immediate sql_stmt;
    end;

procedure insert_row
  (
  in_name in varchar2,
  in_val in varchar2 default null
  --condition in varchar2
  )
  is
  sql_stmt varchar(200);
  begin
    sql_stmt := 'INSERT INTO '||in_name||' VALUES '||in_val||'';
    execute immediate sql_stmt;
    end;

end CONF_PKG_DEV;
/

prompt
prompt Creating package body CONF_PKG_USR_SELECT
prompt =========================================
prompt
create or replace package body student.conf_pkg_usr_select is

function get_series_test
  (
  id in number,
  name in varchar2,
  errcode out varchar2,
  msg out varchar2
  ) return table_of_conf_usr_series is
  v_result table_of_conf_usr_series := table_of_conf_usr_series();
  begin
    begin
      select conf_usr_series(id, name)
      bulk collect
      into v_result
      from conf_series;

      exception
        when others then
          errcode := sqlcode;
          msg := sqlerrm;
          return v_result;
          end;
          errcode := '0';
          msg := 'SUCCEED';
          return v_result;
          end;

function test1
      (
      n1 in number,
      n2 in number,
      n3 out number
      ) return number is
      begin
        n3:=n1+n2;
        return n3;
        end;

procedure get_series_1
  (
  out_all out sys_refcursor
  )
  is
  begin
    open out_all for
    select *
    from conf_series;
    end;

procedure get_model
          (
          ser_id in number,
          out_name out sys_refcursor
          )
          is
          begin
            open out_name for
            select name
            from conf_model
            where id_series = ser_id;
            end;

procedure get_model_1
  (
  ser_id in number,
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select id, name, image, specification, price
    from conf_model
    where id_series = ser_id;
    end;

procedure get_ext_rel
  (
  model_id in number,
  ext_id in number default null,
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select conf_exterior.id, conf_exterior.name, conf_exterior.image, conf_exterior.specification, conf_exterior.price
    from conf_mod_ext_rel
    INNER JOIN conf_exterior on conf_exterior.id = conf_mod_ext_rel.id_exterior
    where id_model = model_id AND (ext_id is null or conf_exterior.id_type = ext_id)
    order by conf_exterior.name;
    end;

procedure get_int_rel
  (
  model_id in number,
  int_id in number default null,
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select conf_interior.id, conf_interior.name, conf_interior.image, conf_interior.specification, conf_interior.price
    from conf_mod_int_rel
    INNER JOIN conf_interior on conf_interior.id = conf_mod_int_rel.id_interior
    where id_model = model_id AND (int_id is null or conf_interior.id_type = int_id)
    order by conf_interior.name;
    end;

procedure get_opt_rel
  (
  model_id in number,
  opt_id in number default null,
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select conf_options.id, conf_options.name, conf_options.image, conf_options.specification, conf_options.price
    from conf_mod_opt_rel
    INNER JOIN conf_options on conf_options.id = conf_mod_opt_rel.id_options
    where id_model = model_id AND (opt_id is null or conf_options.id_type = opt_id);
    end;

procedure get_opt_type
  (
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select *
    from conf_type_options;
    end;

procedure insert_order_auto
  (
  id_ord in number,
  id_prt_ser in number default null,
  id_prt_mod in number default null,
  id_prt_ext in number default null,
  id_prt_int in number default null,
  id_prt_opt in number default null
  )
  is
  id_ord_auto conf_order_auto.id_order_auto%type;
  begin
    select count(id_order_auto) into id_ord_auto from conf_order_auto;
    insert INTO conf_order_auto(id_order_auto, id_order, id_part_ser, id_part_mod, id_part_ext, id_part_int, id_part_opt)
    VALUES(id_ord_auto+1, id_ord, id_prt_ser, id_prt_mod, id_prt_ext, id_prt_int, id_prt_opt);
    end;

procedure select_order_auto
  (
  in_client in number,
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select *
    from conf_order_auto
    where id_order = in_client
    order by id_order_auto;
    end;

procedure comm
  is
  begin
    commit;
    end;

procedure svpoint
  is
  begin
    Savepoint drop_order;
    end;

procedure delete_order
  (
  id_ord in number,
  cond in number default null
  )
  is
  begin
  delete
  from conf_order_auto
  where id_order = id_ord;
  if cond = 1 then
  delete
  from conf_order
  where id = id_ord;
  end if;
  end;

procedure login
  (
  log in varchar2,
  pass in varchar2,
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select id_user
    from conf_ac_account
    where conf_ac_account.login = log AND conf_ac_account.password = pass;
    end;

procedure login2
  (
  log in varchar2,
  pass in varchar2,
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select conf_ac_user_usrole_rel.id_role
    from conf_ac_user_usrole_rel
    INNER JOIN conf_ac_user on conf_ac_user.id = conf_ac_user_usrole_rel.id_user
    INNER JOIN conf_ac_account on conf_ac_account.id_user = conf_ac_user.id
    where conf_ac_account.login = log AND conf_ac_account.password = pass;
    end;

procedure conf_order_add
  (
  in_client in number
  --out_client out number
  )
  is
  id_ord conf_order.id%type;
  begin
    select count(id) into id_ord from conf_order;
    --out_client := id_ord+1;
    insert into conf_order(id, id_client, order_date, status)
    values(id_ord+1, in_client, sysdate, 'Considered');
    end;


procedure conf_order_get
  (
  out_name out sys_refcursor
  )
  is
  id_ord conf_order.id%type;
  begin
    open out_name for
    select count(id) into id_ord from conf_order;
    end;
    

    
procedure get_order_auto_count
  (
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select id_part_mod
    from conf_order_auto
    where id_part_mod is not null
    group by id_part_mod
    having count(*) >= ALL(select count(*) from conf_order_auto where id_part_mod is not null group by id_part_mod);
    end;

procedure get_model_2
  (
  mod_id in number,
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select name
    from conf_model
    where id = mod_id;
    end;

procedure get_order_auto_count_ser
  (
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select id_part_ser
    from conf_order_auto
    where id_part_ser is not null
    group by id_part_ser
    having count(*) >= ALL(select count(*) from conf_order_auto where id_part_ser is not null group by id_part_ser);
    end;
    
procedure get_series_2
  (
  ser_id in number,
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select name
    from conf_series
    where id = ser_id;
    end;

procedure get_order_auto_count_ext
  (
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select id_part_ext
    from conf_order_auto
    where id_part_ext is not null
    group by id_part_ext
    having count(*) >= ALL(select count(*) from conf_order_auto where id_part_ext is not null group by id_part_ext);
    end;
    
procedure get_exterior_2
  (
  ext_id in number,
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select name
    from conf_exterior
    where id = ext_id;
    end;

procedure get_order_auto_count_int
  (
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select id_part_int
    from conf_order_auto
    where id_part_int is not null
    group by id_part_int
    having count(*) >= ALL(select count(*) from conf_order_auto where id_part_int is not null group by id_part_int);
    end;

procedure get_interior_2
  (
  int_id in number,
  out_name out sys_refcursor
  )
  is
  begin
    open out_name for
    select name
    from conf_interior
    where id = int_id;
    end;

end conf_pkg_usr_select;
/

prompt
prompt Creating trigger CONF_AC_ACCOUNT_LOG
prompt ====================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_AC_ACCOUNT_LOG
after insert or update or delete on CONF_AC_ACCOUNT
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_AC_ACCOUNT_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  LOGIN,
  PASSWORD,
  ID_USER)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.login,
  :old.password,
  :old.id_user);
  end;
/

prompt
prompt Creating trigger CONF_AC_USER_LOG
prompt =================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_AC_USER_LOG
after insert or update or delete on CONF_AC_USER
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_AC_USER_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  SURNAME,
  NAME,
  PATRONYMIC)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.surname,
  :old.name,
  :old.patronymic);
  end;
/

prompt
prompt Creating trigger CONF_AC_USER_ROLE_LOG
prompt ======================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_AC_USER_ROLE_LOG
after insert or update or delete on CONF_AC_USER_ROLE
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_AC_USER_ROLE_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  NAME)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.name);
  end;
/

prompt
prompt Creating trigger CONF_AC_USER_USROLE_REL_LOG
prompt ============================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_AC_USER_USROLE_REL_LOG
after insert or update or delete on CONF_AC_USER_USROLE_REL
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_AC_USER_USROLE_REL_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID_USER,
  ID_ROLE)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id_user,
  :old.id_role);
  end;
/

prompt
prompt Creating trigger CONF_EXTERIOR_LOG
prompt ==================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_EXTERIOR_LOG
after insert or update or delete on CONF_EXTERIOR
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_EXTERIOR_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  NAME,
  DELIVERY_DATE,
  ID_TYPE,
  PRICE,
  ACCESS_OPEN,
  ACCESS_CLOSE,
  SPECIFICATION)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.name,
  :old.delivery_date,
  :old.id_type,
  :old.price,
  :old.access_open,
  :old.access_close,
  :old.specification);
  end;
/

prompt
prompt Creating trigger CONF_INTERIOR_LOG
prompt ==================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_INTERIOR_LOG
after insert or update or delete on CONF_INTERIOR
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_INTERIOR_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  NAME,
  DELIVERY_DATE,
  ID_TYPE,
  PRICE,
  ACCESS_OPEN,
  ACCESS_CLOSE,
  SPECIFICATION)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.name,
  :old.delivery_date,
  :old.id_type,
  :old.price,
  :old.access_open,
  :old.access_close,
  :old.specification);
  end;
/

prompt
prompt Creating trigger CONF_MODEL_LOG
prompt ===============================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_MODEL_LOG
after insert or update or delete on CONF_MODEL
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_MODEL_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  NAME,
  DELIVERY_DATE,
  ID_SERIES,
  PRICE,
  ACCESS_OPEN,
  ACCESS_CLOSE,
  SPECIFICATION)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.name,
  :old.delivery_date,
  :old.id_series,
  :old.price,
  :old.access_open,
  :old.access_close,
  :old.specification);
  end;
/

prompt
prompt Creating trigger CONF_MOD_EXT_REL_LOG
prompt =====================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_MOD_EXT_REL_LOG
after insert or update or delete on CONF_MOD_EXT_REL
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_MOD_EXT_REL_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID_MODEL,
  ID_EXTERIOR)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id_model,
  :old.id_exterior);
  end;
/

prompt
prompt Creating trigger CONF_MOD_INT_REL_LOG
prompt =====================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_MOD_INT_REL_LOG
after insert or update or delete on CONF_MOD_INT_REL
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_MOD_INT_REL_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID_MODEL,
  ID_INTERIOR)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id_model,
  :old.id_interior);
  end;
/

prompt
prompt Creating trigger CONF_MOD_OPT_REL_LOG
prompt =====================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_MOD_OPT_REL_LOG
after insert or update or delete on CONF_MOD_OPT_REL
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_MOD_OPT_REL_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID_MODEL,
  ID_OPTIONS)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id_model,
  :old.id_options);
  end;
/

prompt
prompt Creating trigger CONF_OPTIONS_LOG
prompt =================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_OPTIONS_LOG
after insert or update or delete on CONF_OPTIONS
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_OPTIONS_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  NAME,
  DELIVERY_DATE,
  ID_TYPE,
  PRICE,
  ACCESS_OPEN,
  ACCESS_CLOSE,
  SPECIFICATION)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.name,
  :old.delivery_date,
  :old.id_type,
  :old.price,
  :old.access_open,
  :old.access_close,
  :old.specification);
  end;
/

prompt
prompt Creating trigger CONF_ORDER_AUTO_LOG
prompt ====================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_ORDER_AUTO_LOG
after insert or update or delete on CONF_ORDER_AUTO
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_ORDER_AUTO_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID_ORDER_AUTO,
  ID_ORDER,
  ID_PART_SER,
  SPECIFICATION,
  ID_PART_MOD,
  ID_PART_EXT,
  ID_PART_INT,
  ID_PART_OPT)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id_order_auto,
  :old.id_order,
  :old.id_part_ser,
  :old.specification,
  :old.id_part_mod,
  :old.id_part_ext,
  :old.id_part_int,
  :old.id_part_opt);
  end;
/

prompt
prompt Creating trigger CONF_ORDER_LOG
prompt ===============================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_ORDER_LOG
after insert or update or delete on CONF_ORDER
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_ORDER_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  ID_CLIENT,
  ORDER_DATE,
  STATUS)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.id_client,
  :old.order_date,
  :old.status);
  end;
/

prompt
prompt Creating trigger CONF_SERIES_LOG
prompt ================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_SERIES_LOG
after insert or update or delete on CONF_SERIES
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_SERIES_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  NAME)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.name);
  end;
/

prompt
prompt Creating trigger CONF_TYPE_EXTERIOR_LOG
prompt =======================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_TYPE_EXTERIOR_LOG
after insert or update or delete on CONF_TYPE_EXTERIOR
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_TYPE_EXTERIOR_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  NAME)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.name);
  end;
/

prompt
prompt Creating trigger CONF_TYPE_INTERIOR_LOG
prompt =======================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_TYPE_INTERIOR_LOG
after insert or update or delete on CONF_TYPE_INTERIOR
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_TYPE_INTERIOR_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  NAME)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.name);
  end;
/

prompt
prompt Creating trigger CONF_TYPE_OPTIONS_LOG
prompt ======================================
prompt
CREATE OR REPLACE TRIGGER STUDENT.CONF_TYPE_OPTIONS_LOG
after insert or update or delete on CONF_TYPE_OPTIONS
for each row

declare
v_machine varchar2(100);
v_module varchar2(100);
v_operation varchar2(100);
begin
  select substr(machine, 0, 100), substr(module, 0, 100)
  into v_machine, v_module
  from v$session
  where audsid = sys_context('userenv', 'sessionid')
  and rownum = 1;

  if inserting then
    v_operation := 'INSERT';
    elsif updating then
      v_operation := 'UPDATE';
      elsif deleting then
        v_operation := 'DELETE';
        end if;

  insert into CONF_TYPE_OPTIONS_LOG
  (WHO,
  OPERATION,
  TIME_STAMP,
  ID,
  NAME)
  values
  (user,
  v_operation,
  systimestamp,
  :old.id,
  :old.name);
  end;
/

