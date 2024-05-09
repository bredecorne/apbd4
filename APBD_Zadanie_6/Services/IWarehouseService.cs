using APBD_Zadanie_6.Models;

namespace Zadanie5.Services
{
    public interface IWarehouseService
    {
        public void AddProduct(ProductWarehouse productWarehouse);
        
        public List<Warehouse> ReadWarehouses();

        public HashSet<int> ReadIds();
    }
}
