using HotelWeb.Models;

namespace HotelWeb.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> Insert(Order order);
        Task<bool> Update(Order order);
        Task<bool> Exist(Order order);
        Task<List<Order>> GetOrders();
        
       
    }
}
