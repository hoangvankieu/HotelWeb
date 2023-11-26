using HotelWeb.Models;
using HotelWeb.Repositories;

namespace HotelWeb.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<Order>> GetOrders(int ?date_number)
        {
            var orders = await _orderRepository.GetOrders();
            if (date_number == null)
            {
                return orders;
            }
            DateTime currentDate= DateTime.Now.Date;
            orders= orders.Where(ord=>(currentDate- ord.OrderDate).TotalDays<=date_number).ToList();
            return orders;
        }

        

        public async Task<object> calculateRevenueStatistics()
        {
            var orders=await _orderRepository.GetOrders();
            var monthlyRevenue = orders
            .GroupBy(ord => new { ord.ExpiredDate.Year, ord.ExpiredDate.Month })
            .Select(g => new 
            {
                Year=g.Key.Year,
                Month=g.Key.Month,
                TotalRevenue = g.Sum(ord => ord.MoneyTotal)
            })
            .OrderBy(g => g.Year)
            .ThenBy(g => g.Month);
            return monthlyRevenue.ToList();
        }

        public async Task<List<Order>> CustomerOrders(int idCus)
        {
            var orders = await _orderRepository.GetOrders();
            
            return orders.Where(ord => ord.CustomerId == idCus).ToList();
        }

        public async Task<bool> Exist(Order order)
        {
            return await _orderRepository.Exist(order);
        }

        public async Task<bool> Insert(Order order)
        {
            return await _orderRepository.Insert(order);
        }

        public async Task<bool> Update(Order order)
        {
            return await _orderRepository.Update(order);
        }
    }
}
