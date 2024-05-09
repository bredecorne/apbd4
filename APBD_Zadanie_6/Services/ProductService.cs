using APBD_Zadanie_6.Models;
using MySqlConnector;

namespace APBD_Zadanie_6.Services;

public class ProductService : IProductService
{
    private readonly string _connectionString;

    public ProductService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Database") ?? throw new InvalidOperationException();
    }

    public ProductService(string connectionString)
    {
        _connectionString = connectionString;
    }


    public List<Product> ReadProducts()
    {
        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(
            $"SELECT * FROM Product",
            connection);

        var products = new List<Product>();

        connection.Open();
        var data = command.ExecuteReader();

        while (data.Read())
        {
            products.Add(new Product(
                (int)data["IdProduct"], 
                (string)data["Name"], 
                (string)data["Description"], 
                (decimal)data["Price"]));
        }

        return products;
    }

    public HashSet<int> ReadIds()
    {
        var products = ReadProducts();
        var ids = new HashSet<int>();
        
        foreach (var p in products)
        {
            ids.Add(p.IdProduct);
        }

        return ids;
    }
}