using APBD_Zadanie_6.Models;

namespace APBD_Zadanie_6.Services;

public interface IOrderService
{
    public bool FindOrder(int idProduct, int amount, DateTime createdAt);
}