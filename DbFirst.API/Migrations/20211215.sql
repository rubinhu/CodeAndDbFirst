CREATE TABLE "rubin_test" (
	"url" VARCHAR(200) NOT NULL,
	"icon" VARCHAR(100) NULL DEFAULT NULL,
	"name" VARCHAR(100) NOT NULL,
	"site" VARCHAR(100) NOT NULL,
	"type" VARCHAR(20) NULL DEFAULT 'webview',
	"apid" VARCHAR(100) NOT NULL DEFAULT 'NULL::character varying',
	"seq" INTEGER NULL DEFAULT NULL,
	PRIMARY KEY ("apid")
)
;
COMMENT ON COLUMN "rubin_test"."url" IS 'web url';
COMMENT ON COLUMN "rubin_test"."icon" IS '图标路径';
COMMENT ON COLUMN "rubin_test"."name" IS '应用名称';
COMMENT ON COLUMN "rubin_test"."site" IS 'site(以,分割) or ActiveEmp.在職員工登錄；InActiveEmp.離職員工登錄；Guest.訪客登錄';
COMMENT ON COLUMN "rubin_test"."type" IS 'type: webview or miniprogram';
COMMENT ON COLUMN "rubin_test"."apid" IS 'apid of WeChat''s miniprogram';
COMMENT ON COLUMN "rubin_test"."seq" IS 'sequence';

INSERT INTO rubin_test
(url, icon, name, site, "type", apid, seq)
VALUES('1', '2', '3', '4', '5', '2', 6);
