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
    public class SqlHelper
    {
        DbContext ctx;

        public SqlHelper(DbContext dbContext)
        {
            ctx = dbContext;
        }

        #region Execute

        public void Execute(string sql, object param)
        {
            ArrayList sqls = new ArrayList();
            sqls.Add(sql);

            ArrayList parms = new ArrayList();
            parms.Add(param);

            Execute(sqls, parms);
        }

        public void Execute(ArrayList sqls, ArrayList parms)
        {
            using (IDbConnection connection = ctx.Database.GetDbConnection())
            {
                connection.Open(); 

               IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < sqls.Count; i++)
                    {
                        string sql = sqls[i].ToString();
                        object param = parms[i];
                        connection.Execute(sql, param, transaction);
                    }
                    
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
                finally
                {
                    if(connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void ExecuteAsync(string sql, object param)
        {
            ArrayList sqls = new ArrayList();
            sqls.Add(sql);

            ArrayList parms = new ArrayList();
            parms.Add(param);

            ExecuteAsync(sqls, parms);
        }

        public void ExecuteAsync(ArrayList sqls, ArrayList parms)
        {
            using (IDbConnection connection = ctx.Database.GetDbConnection())
            {
                connection.Open();

                IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < sqls.Count; i++)
                    {
                        string sql = sqls[i].ToString();
                        object param = parms[i];
                        connection.ExecuteAsync(sql, param, transaction);
                    }

                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        #endregion

        #region ExecuteReader

        public bool IsExists(string sql, object param)
        {
            using (IDbConnection connection = ctx.Database.GetDbConnection())
            {
                connection.Open(); 

                try
                {
                    return connection.ExecuteReader(sql, param).Read();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        #endregion
    }
}
