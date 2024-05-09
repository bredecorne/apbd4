﻿using APBD_Task_6.Models;
using MySqlConnector;

namespace Zadanie5.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IConfiguration _configuration;

        public WarehouseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddProduct(ProductWarehouse productWarehouse)
        {
            var connectionString = _configuration.GetConnectionString("Database");
            using var connection = new MySqlConnection(connectionString);
            using var cmd = new MySqlCommand();

            cmd.Connection = connection;

           
        }
    }
}
