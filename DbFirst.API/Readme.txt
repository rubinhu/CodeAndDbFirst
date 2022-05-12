1.手動在DB上創建 tables，并生成 sql script; 
2.把sql script放入Migrations文件夾下，文件名以年月日+時分秒為前綴，這樣讓其順序執行；
3.設置Migrations下的文件 始終複製到輸出目錄。
PS：19000101120000_initialization.sql 是創建表 "__EFMigrationsHistory"。