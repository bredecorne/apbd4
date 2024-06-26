namespace APBD_Zadanie_6.Models;

public class Order
{
    public int IdOrder { get; set; }
    public int IdProduct { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }

    public Order(int idOrder, int idProduct, int amount, DateTime createdAt, DateTime? fulfilledAt)
    {
        IdOrder = idOrder;
        IdProduct = idProduct;
        Amount = amount;
        CreatedAt = createdAt;
        FulfilledAt = fulfilledAt;
    }
}