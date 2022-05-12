CREATE TABLE "__EFMigrationsHistory" (
	"MigrationId" VARCHAR(500) NOT NULL,
	"ProductVersion" VARCHAR(100) NULL DEFAULT NULL,
	cdate timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY ("MigrationId")
);