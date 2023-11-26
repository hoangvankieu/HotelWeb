using HotelWeb.Models;

namespace HotelWeb.Services
{
    public interface IOrderService
    {
        Task<bool> Insert(Order order);
        Task<bool> Update(Order order);
        Task<bool> Exist(Order order);
        Task<List<Order>> CustomerOrders(int idCus);
        public Task<List<Order>> GetOrders(int? date_number);
        Task<object> calculateRevenueStatistics();

    }
}
