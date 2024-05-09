using System.ComponentModel.DataAnnotations;

namespace APBD_Zadanie_6.Models;

public class Warehouse
{
    public int IdWarehouse { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string Address { get; set; }

    public Warehouse(int idWarehouse, string name, string address)
    {
        IdWarehouse = idWarehouse;
        Name = name;
        Address = address;
    }
}