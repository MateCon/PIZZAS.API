using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Pizzas.API.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=A-BTA-22;
            DataBase=DAI-Pizzas;Trusted_Connection=True;";

        public static IEnumerable<Pizza> GetAllPizzas()
        {
            IEnumerable<Pizza> pizzas = null;
            string query = "SELECT * FROM Pizzas";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                pizzas = db.Query<Pizza>(query);
            }
            Console.WriteLine(pizzas);
            return pizzas;
        }
    }
}