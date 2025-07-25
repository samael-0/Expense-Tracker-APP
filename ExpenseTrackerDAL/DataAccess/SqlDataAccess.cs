﻿using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ExpenseTrackerDAL.DataAccess
{
    public class SqlDataAccess:ISqlDataAccess
    {

        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }



        public async Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters,
            string connectionId = "conn")
        {
            using IDbConnection connection = new SqlConnection
                (_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(spName, parameters);


        }



        public async Task SaveData<T>(string spName, T parameters,
            string connectionId = "conn")
        {
            using IDbConnection connection = new SqlConnection
                (_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(spName, parameters);
        }



    }
}
