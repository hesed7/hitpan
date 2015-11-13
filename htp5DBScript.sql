CREATE TABLE users
(
  userid character varying NOT NULL,
  userpassword character varying,
  userauth text,
  usertype character varying,
  CONSTRAINT pk_user PRIMARY KEY (userid)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE users
  OWNER TO postgres;

  CREATE TABLE unitcost
(
  cost money NOT NULL,
  cost_type character varying NOT NULL,
  good_idx bigint NOT NULL,
  company_idx bigint NOT NULL,
  is_free_tax boolean,
  contain_vat boolean,
  unit character varying,
  CONSTRAINT pk_unitcost PRIMARY KEY (cost, cost_type, good_idx, company_idx)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE unitcost
  OWNER TO postgres;

CREATE TABLE goodseller
(
  goods_idx bigint NOT NULL,
  seller_idx bigint NOT NULL,
  CONSTRAINT pk_goodseller PRIMARY KEY (goods_idx, seller_idx)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE goodseller
  OWNER TO postgres;


CREATE TABLE goods
(
  good_pk integer NOT NULL DEFAULT nextval('goods_goodpk_seq'::regclass),
  good_name character varying(150),
  good_subname character varying,
  good_maker character varying,
  good_nickname character varying,
  properstock int8range,
  status character varying,
  good_image text,
  etc_info tsvector,
  CONSTRAINT pk_goods PRIMARY KEY (good_pk)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE goods
  OWNER TO postgres;


CREATE INDEX fidx_etc_info
  ON goods
  USING gin
  (etc_info);


CREATE UNIQUE INDEX idx_good
  ON goods
  USING btree
  (good_name COLLATE pg_catalog."default", good_subname COLLATE pg_catalog."default", good_maker COLLATE pg_catalog."default");


CREATE INDEX idx_good_nickname
  ON goods
  USING btree
  (good_nickname COLLATE pg_catalog."default");


CREATE TABLE goodparts
(
  final_good_idx bigint NOT NULL,
  required_amount bigint,
  required_good bigint NOT NULL,
  CONSTRAINT pk_good_parts PRIMARY KEY (final_good_idx, required_good)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE goodparts
  OWNER TO postgres;

CREATE TABLE good_unit_info
(
  unit character varying NOT NULL,
  flag_unit character varying, -- 이 단위의 가장 기본이 되는 단위
  good_idx bigint NOT NULL,
  amount bigint, -- 기본단위의 상품이 몇개 있어야 지금단위의 하나의 물량이 될수 있는지
  CONSTRAINT pk_good_unit_info PRIMARY KEY (unit, good_idx)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE good_unit_info
  OWNER TO postgres;
COMMENT ON COLUMN good_unit_info.flag_unit IS '이 단위의 가장 기본이 되는 단위';
COMMENT ON COLUMN good_unit_info.amount IS '기본단위의 상품이 몇개 있어야 지금단위의 하나의 물량이 될수 있는지';



CREATE TABLE companies
(
  company_pk integer NOT NULL DEFAULT nextval('"COMPANIES_company_pk_seq"'::regclass),
  company_name character varying,
  "company_Business_Number" character(10),
  company_phone character varying,
  company_fax character varying,
  company_addr tsvector,
  company_worktime integer,
  company_etc tsvector,
  CONSTRAINT pk_companies PRIMARY KEY (company_pk)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE companies
  OWNER TO postgres;

CREATE INDEX fidx_company
  ON companies
  USING gin
  (company_addr, company_etc);

CREATE INDEX idx_company
  ON companies
  USING btree
  (company_name COLLATE pg_catalog."default", "company_Business_Number" COLLATE pg_catalog."default", company_phone COLLATE pg_catalog."default", company_fax COLLATE pg_catalog."default");

CREATE TABLE commonsetting
(
  jsonmyinfo text, -- 나의 회사 정보
  jsonsettinginfodata text
)
WITH (
  OIDS=FALSE
);
ALTER TABLE commonsetting
  OWNER TO postgres;
COMMENT ON TABLE commonsetting
  IS '설정정보 및 자신의 회사정보 저장';
COMMENT ON COLUMN commonsetting.jsonmyinfo IS '나의 회사 정보';

CREATE TABLE log
(
  timeline timestamp with time zone NOT NULL,
  type character varying,
  "user" character varying,
  log text,
  CONSTRAINT pk_log PRIMARY KEY (timeline)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE log
  OWNER TO postgres;


CREATE UNIQUE INDEX idx_log
  ON log
  USING btree
  (timeline, type COLLATE pg_catalog."default", "user" COLLATE pg_catalog."default");