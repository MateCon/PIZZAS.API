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
        public static SqlConnection GetConnection() {
            // string ConnectionString = ConfigurationHelper.GetConfiguration().GetValue<string>("DatabaseSettings:ConnectionString");
            string connectionString = "Server=A-CREA-40;DataBase=DAI-Pizzas;Trusted_Connection=True;";
            return new SqlConnection(connectionString);
        }
    }
}
