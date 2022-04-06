using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Pizzas.API.Helpers;

namespace Pizzas.API.Models
{
    public static class BD
    {
        public static SqlConnection GetConfiguration() {
            SqlConnection db;
            string connectionString;
            connectionString = GetConfiguration.GetValue<string>("DatabaseSettings:ConnectionString");
            return new SqlConnection(connectionString);
        }
    }
}
