using Dapper;
using DbFirst.API.Models.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DbFirst.API.Utils
{
    public class MigrationHelper
    {
        public MigrationHelper()
        {
           
        }

        /// <summary>
        /// Execute migration by DB first
        /// </summary>
        public void ExecuteMigration()
        {
            // drop tables for migration test, it will be removed in your code.
            this.DropTablsForTest();

            // create migration record
            CreateTableForMigration();

            FilesHelper filesHelper = new FilesHelper();
            var files = filesHelper.GetFiles("Migrations");

            ArrayList sqls = new ArrayList();
            ArrayList parms = new ArrayList();
            
            // list all migrations files
            foreach (var item in files)
            {
                string migrationId = item.Name;
                if (!IsExistsMigration(migrationId))
                {
                    // it didn't execute migration
                    string sql = filesHelper.GetFileContents(@"Migrations\" + migrationId);
                    sqls.Add(sql);
                    parms.Add(null);

                    sql = "INSERT INTO \"__EFMigrationsHistory\"(\"MigrationId\", \"ProductVersion\") VALUES(@MigrationId, @ProductVersion)";
                    sqls.Add(sql);
                    parms.Add(new { MigrationId = migrationId, ProductVersion = "1.0.0" });
                }
            }

            if (sqls.Count > 0)
            {
                SqlHelper sqlHelper = new SqlHelper(new WZSHRContext());
                sqlHelper.Execute(sqls, parms);
            }

        }

        /// <summary>
        /// Drop tables for migration test
        /// </summary>
        private void DropTablsForTest()
        {
            string sql = "DROP TABLE \"__EFMigrationsHistory\" ; DROP TABLE \"rubin_test\" ; DROP TABLE \"rubin_test1\" ; DROP TABLE \"rubin_test2\" ;";

            SqlHelper sqlHelper = new SqlHelper(new WZSHRContext());
            sqlHelper.Execute(sql, null);
        }

        /// <summary>
        /// Create a table to record all migrations
        /// </summary>
        private void CreateTableForMigration()
        {
            ArrayList sqls = new ArrayList();
            ArrayList parms = new ArrayList();

            string tableSchema = AppSettings.Configuration.GetConnectionString("DbSchema");
            string tableName = "__EFMigrationsHistory";
            
            if (!IsExistsTable(tableSchema, tableName))
            {
                string sql = "CREATE TABLE \"__EFMigrationsHistory\" (\"MigrationId\" VARCHAR(500) NOT NULL, \"ProductVersion\" VARCHAR(100) NULL DEFAULT NULL, cdate timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP, PRIMARY KEY(\"MigrationId\")); ";
                sqls.Add(sql);
                parms.Add(null);

                sql = "INSERT INTO \"__EFMigrationsHistory\"(\"MigrationId\", \"ProductVersion\") VALUES(@MigrationId, @ProductVersion)";
                string migrationId = "19000101120000_initialization.sql";
                sqls.Add(sql);
                parms.Add(new { MigrationId = migrationId, ProductVersion = "1.0.0" });

                SqlHelper sqlHelper = new SqlHelper(new WZSHRContext());
                sqlHelper.Execute(sqls, parms);
            }
        }

        /// <summary>
        /// Insert a record into __EFMigrationsHistory table
        /// </summary>
        /// <param name="migrationId">MigrationId</param>
        /// <param name="productVersion">ProductVersion</param>
        private void InsertMigrations(string migrationId, string productVersion= "1.0.0")
        {
            string sql = "INSERT INTO \"__EFMigrationsHistory\"(\"MigrationId\", \"ProductVersion\") VALUES(@MigrationId, @ProductVersion)";
            object parma = new { MigrationId = migrationId, ProductVersion = productVersion };

            SqlHelper sqlHelper = new SqlHelper(new WZSHRContext());
            sqlHelper.Execute(sql, parma);
        }

        /// <summary>
        /// The migration if it exists.
        /// </summary>
        /// <param name="migrationId">MigrationId</param>
        /// <returns>true or false</returns>
        private bool IsExistsMigration(string migrationId)
        {
            bool isExists = false;
            string sql = "SELECT \"ProductVersion\" from \"__EFMigrationsHistory\" where \"MigrationId\"=@MigrationId";
            object parma = new { MigrationId = migrationId };

            SqlHelper sqlHelper = new SqlHelper(new WZSHRContext());
            isExists = sqlHelper.IsExists(sql, parma);

            return isExists;
        }

        /// <summary>
        /// Check the talbe if it exists.
        /// </summary>
        /// <param name="tableSchema">Table schema name</param>
        /// <param name="tableName">Table name</param>
        /// <returns>true or false</returns>
        private bool IsExistsTable(string tableSchema, string tableName)
        {
            bool isExists = false;
            string sql = @"SELECT table_name from information_schema.tables where table_schema=@table_schema and table_type='BASE TABLE' and table_name=@table_name";
            object parma = new { table_schema = tableSchema, table_name = tableName };

            SqlHelper sqlHelper = new SqlHelper(new WZSHRContext());
            isExists = sqlHelper.IsExists(sql, parma);

            return isExists;
        }
    }
}
