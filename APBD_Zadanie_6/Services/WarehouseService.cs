using APBD_Zadanie_6.Models;
using MySqlConnector;
using Zadanie5.Services;

namespace APBD_Zadanie_6.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly string _connectionString;

        public WarehouseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database") ?? throw new InvalidOperationException();
        }

        public void AddProduct(ProductWarehouse productWarehouse)
        {
            // Verifying if a Product with requested ID exists in the DB.
            var productService = new ProductService(_connectionString);
            if (!productService.ReadIds().Contains(productWarehouse.IdProduct))
            {
                throw new Exception("IdProduct is invalid.");
            }
            
            // Verifying if a Warehouse with requested ID exists in the DB.
            if (!ReadIds().Contains(productWarehouse.IdWarehouse))
            {
                throw new Exception("IdWarehouse is invalid.");
            }

            // using var connection = new MySqlConnection(_connectionString);
            // using var command = new MySqlCommand(
            //     $"INSERT INTO Product_Warehouse(IdProduct, IdWarehouse, Amount, CreatedAt) " +
            //     $"VALUES (@id_product, @id_warehouse, @amount, @created_at)",
            //     connection);
            //
            // command.Parameters.AddWithValue("@id_product", productWarehouse.IdProduct);
            // command.Parameters.AddWithValue("@id_warehouse", productWarehouse.IdWarehouse);
            // command.Parameters.AddWithValue("@amount", productWarehouse.Amount);
            // command.Parameters.AddWithValue("@created_at", productWarehouse.CreatedAt);
            //
            // connection.Open();
            // command.ExecuteNonQuery();
        }

        public List<Warehouse> ReadWarehouses()
        {
            using var connection = new MySqlConnection(_connectionString);
            using var command = new MySqlCommand(
                $"SELECT * FROM Warehouse",
                connection);

            var warehouses = new List<Warehouse>();

            connection.Open();
            var data = command.ExecuteReader();

            while (data.Read())
            {
                warehouses.Add(new Warehouse(
                    (int)data["IdWarehouse"],
                    (string)data["Name"],
                    (string)data["Address"]
                ));
            }

            return warehouses;
        }

        public HashSet<int> ReadIds()
        {
            var warehouses = ReadWarehouses();
            var ids = new HashSet<int>();
        
            foreach (var w in warehouses)
            {
                ids.Add(w.IdWarehouse);
            }

            return ids;
        }
    }
}
