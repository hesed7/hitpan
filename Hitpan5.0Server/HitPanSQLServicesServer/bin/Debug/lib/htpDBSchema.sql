--
-- PostgreSQL database dump
--

-- Dumped from database version 9.4.5
-- Dumped by pg_dump version 9.4.5
-- Started on 2015-11-06 09:51:51

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 2049 (class 1262 OID 12135)
-- Dependencies: 2048
-- Name: postgres; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE postgres IS 'default administrative connection database';


--
-- TOC entry 181 (class 3079 OID 11855)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2052 (class 0 OID 0)
-- Dependencies: 181
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


--
-- TOC entry 180 (class 3079 OID 16384)
-- Name: adminpack; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;


--
-- TOC entry 2053 (class 0 OID 0)
-- Dependencies: 180
-- Name: EXTENSION adminpack; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 172 (class 1259 OID 32768)
-- Name: COMMONSETTING; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "COMMONSETTING" (
    "JSONMYINFO" text,
    "JSONSETTINGINFODATA" text
);


ALTER TABLE "COMMONSETTING" OWNER TO postgres;

--
-- TOC entry 2054 (class 0 OID 0)
-- Dependencies: 172
-- Name: TABLE "COMMONSETTING"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE "COMMONSETTING" IS '설정정보 및 자신의 회사정보 저장';


--
-- TOC entry 2055 (class 0 OID 0)
-- Dependencies: 172
-- Name: COLUMN "COMMONSETTING"."JSONMYINFO"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN "COMMONSETTING"."JSONMYINFO" IS '나의 회사 정보';


--
-- TOC entry 173 (class 1259 OID 32774)
-- Name: COMPANIES; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "COMPANIES" (
    "COMPANYPK" character varying(20)[] NOT NULL,
    "COMPANYNAME" character varying(150)[]
);


ALTER TABLE "COMPANIES" OWNER TO postgres;

--
-- TOC entry 174 (class 1259 OID 32784)
-- Name: GOODS; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "GOODS" (
    "GoodPK" character varying(20)[] NOT NULL,
    "GOODNAME" character varying(150)[],
    "GOODSUBNAME" character varying(150)[],
    "GOODMAKER" character varying(150)[],
    "GOODNICKNAME" character varying(150)[],
    "GOODUNIT" character varying(150)[],
    "PROPERSTOCK" character varying(15)[],
    "ETCINFO" text,
    "STATUS" character varying(10)[]
);


ALTER TABLE "GOODS" OWNER TO postgres;

--
-- TOC entry 175 (class 1259 OID 32794)
-- Name: GOODSELLER; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "GOODSELLER" (
    "SELLERIDX" character varying(20)[] NOT NULL,
    "GOODIDX" character varying(20)[] NOT NULL
);


ALTER TABLE "GOODSELLER" OWNER TO postgres;

--
-- TOC entry 176 (class 1259 OID 32804)
-- Name: Log; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "Log" (
    "TIMELINE" timestamp with time zone NOT NULL,
    "TYPE" integer,
    "USER" character varying(50)[],
    "LOG" text
);


ALTER TABLE "Log" OWNER TO postgres;

--
-- TOC entry 177 (class 1259 OID 32813)
-- Name: PARTS; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "PARTS" (
    "FINISHEDGOODIDX" character varying(20)[] NOT NULL,
    "PARTIDX" character varying(20)[] NOT NULL,
    "AMOUNT" bigint
);


ALTER TABLE "PARTS" OWNER TO postgres;

--
-- TOC entry 178 (class 1259 OID 32821)
-- Name: UNITCOST; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "UNITCOST" (
    "COSTTYPE" integer NOT NULL,
    "GOODIDX" character varying(20)[] NOT NULL,
    "COMPANYIDX" character varying(20)[] NOT NULL,
    "COST" money,
    "ISFREETAX" boolean,
    "CONTAINVAT" boolean
);


ALTER TABLE "UNITCOST" OWNER TO postgres;

--
-- TOC entry 179 (class 1259 OID 32829)
-- Name: USERS; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "USERS" (
    "USERID" character varying(50)[] NOT NULL,
    "USERPASSWORD" character varying(50)[],
    "USERAUTH" text,
    "USERTYPE" integer
);


ALTER TABLE "USERS" OWNER TO postgres;

--
-- TOC entry 1917 (class 2606 OID 32783)
-- Name: COMPANIES_COMPANYNAME_key; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "COMPANIES"
    ADD CONSTRAINT "COMPANIES_COMPANYNAME_key" UNIQUE ("COMPANYNAME");


--
-- TOC entry 1919 (class 2606 OID 32781)
-- Name: COMPANIES_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "COMPANIES"
    ADD CONSTRAINT "COMPANIES_pkey" PRIMARY KEY ("COMPANYPK");


--
-- TOC entry 1925 (class 2606 OID 32803)
-- Name: pidx_GoodSeller; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "GOODSELLER"
    ADD CONSTRAINT "pidx_GoodSeller" PRIMARY KEY ("SELLERIDX", "GOODIDX");


--
-- TOC entry 1922 (class 2606 OID 32793)
-- Name: pidx_Goods; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "GOODS"
    ADD CONSTRAINT "pidx_Goods" PRIMARY KEY ("GoodPK");


--
-- TOC entry 1930 (class 2606 OID 32820)
-- Name: pidx_Parts; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "PARTS"
    ADD CONSTRAINT "pidx_Parts" PRIMARY KEY ("FINISHEDGOODIDX", "PARTIDX");


--
-- TOC entry 1932 (class 2606 OID 32828)
-- Name: pidx_UnitCost; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "UNITCOST"
    ADD CONSTRAINT "pidx_UnitCost" PRIMARY KEY ("COSTTYPE", "GOODIDX", "COMPANYIDX");


--
-- TOC entry 1934 (class 2606 OID 32836)
-- Name: pidx_Users; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "USERS"
    ADD CONSTRAINT "pidx_Users" PRIMARY KEY ("USERID");


--
-- TOC entry 1928 (class 2606 OID 32811)
-- Name: pidx_log; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "Log"
    ADD CONSTRAINT pidx_log PRIMARY KEY ("TIMELINE");


--
-- TOC entry 1920 (class 1259 OID 32790)
-- Name: idx_GoodName; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE UNIQUE INDEX "idx_GoodName" ON "GOODS" USING btree ("GOODNAME", "GOODSUBNAME", "GOODMAKER");

ALTER TABLE "GOODS" CLUSTER ON "idx_GoodName";


--
-- TOC entry 1926 (class 1259 OID 32812)
-- Name: idx_log; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX idx_log ON "Log" USING btree ("TYPE", "USER");


--
-- TOC entry 1923 (class 1259 OID 32791)
-- Name: uidx_GoodNickName; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE UNIQUE INDEX "uidx_GoodNickName" ON "GOODS" USING btree ("GOODNICKNAME");


--
-- TOC entry 2051 (class 0 OID 0)
-- Dependencies: 5
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2015-11-06 09:51:52

--
-- PostgreSQL database dump complete
--

