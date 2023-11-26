using HotelWeb.Models;
using HotelWeb.Repositories;

namespace HotelWeb.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public void Insert(OrderDetail orderDetail)
        {
            _orderDetailRepository.Insert(orderDetail);
        }
    }
}
