﻿using CareerCloud.Configurations;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Transactions;

namespace CareerCloud.ADODataAccessLayer
{
    public class DbHelper(ICareerCloudConfigResolver configResolver)
    {
        private readonly ICareerCloudConfigResolver _configResolver = configResolver;
        
        public void Update<T>(string query, Action<DbCommand, T> parameterSetterAction, T[] items)
             where T : class
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (DbConnection connection = new SqlConnection(_configResolver.GetConnectionString()))
                {
                    connection.Open();
                    foreach (var item in items)
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = query;
                            parameterSetterAction(cmd, item);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();
                }
            }
        }

        public IList<T> Query<T>(string query, Func<DbDataReader, T> rowMapperFunc)
            where T : class
        {
            IList<T> items = new List<T>();
            using (DbConnection connection = new SqlConnection(_configResolver.GetConnectionString()))
            {
                using (DbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = query;
                    connection.Open();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(rowMapperFunc(reader));
                        }
                    }
                }
            }
            return items;
        }
    }
}
