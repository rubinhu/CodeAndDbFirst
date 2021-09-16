1.手動創建TABLE： __EFMigrationsHistory
CREATE TABLE "__EFMigrationsHistory" (
	"MigrationId" VARCHAR(500) NOT NULL,
	"ProductVersion" VARCHAR(100) NULL DEFAULT NULL,
	PRIMARY KEY ("MigrationId")
);

2. 產生migration
EntityFrameworkCore\Add-Migration initialization

3.未在DB上執行，撤銷migration
EntityFrameworkCore\Remove-Migration