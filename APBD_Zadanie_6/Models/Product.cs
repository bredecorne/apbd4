using System.ComponentModel.DataAnnotations;

namespace APBD_Zadanie_6.Models;

public class Product
{
    public int IdProduct { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }

    public Product(int idProduct, string name, string description, decimal price)
    {
        IdProduct = idProduct;
        Name = name;
        Description = description;
        Price = price;
    }
}