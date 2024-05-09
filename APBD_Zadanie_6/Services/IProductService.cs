using APBD_Zadanie_6.Models;

namespace APBD_Zadanie_6.Services;

public interface IProductService
{
    public List<Product> ReadProducts();

    public HashSet<int> ReadIds();
}