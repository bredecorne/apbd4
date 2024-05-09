using APBD_Zadanie_6.Models;
using MySqlConnector;

namespace APBD_Zadanie_6.Services;

public class OrderService : IOrderService
{
    private readonly string _connectionString;

    public OrderService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Database") ?? throw new InvalidOperationException();
    }

    public OrderService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public bool FindOrder(int idProduct, int amount, DateTime createdAt)
    {
        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(
            $"SELECT 1 FROM 'Order' " +
            $"WHERE IdProduct = @idProduct AND Amount = @amount AND CreatedAt < @createdAt AND FulfilledAt IS NULL", 
            connection);

        command.Parameters.AddWithValue("@idProduct", idProduct);
        command.Parameters.AddWithValue("@amount", amount);
        command.Parameters.AddWithValue("@createdAt", createdAt);

        connection.Open();
        var result = command.ExecuteScalar();

        return result != null; 
    }

}