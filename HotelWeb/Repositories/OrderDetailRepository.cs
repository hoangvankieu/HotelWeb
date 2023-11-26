using HotelWeb.Data;
using HotelWeb.Models;

namespace HotelWeb.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
		private readonly HotelWebDbcontext _context;
		public OrderDetailRepository(HotelWebDbcontext context)
        {
            _context = context;
        }

        public void Insert(OrderDetail orderDetail)
        {
			try
			{
                _context.AddAsync(orderDetail);
                _context.SaveChanges();
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
