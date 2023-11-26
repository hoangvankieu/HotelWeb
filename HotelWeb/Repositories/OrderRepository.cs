using HotelWeb.Data;
using HotelWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly HotelWebDbcontext _context;
        public OrderRepository(HotelWebDbcontext context)
        {
            _context = context;
        }

        public Task<bool> Exist(Order order)
        {
            var result = _context.Orders.AnyAsync(ord=>(
            order.OrderDate>= ord.OrderDate && order.OrderDate<= ord.ExpiredDate)||
            (order.ExpiredDate>=ord.OrderDate && order.ExpiredDate<=ord.ExpiredDate));
            return result;
        }

        public async Task<bool> Insert(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<bool> Update(Order order)
        {
            try
            {
                var _ord = await _context.Orders.FirstOrDefaultAsync(ord => ord.Id == order.Id);
                if( _ord != null )
                {
                    _ord.Accept = order.Accept;
                    _ord.OrderDate = order.OrderDate;
                    _ord.ExpiredDate= order.ExpiredDate;
                    _ord.CustomerId = order.CustomerId;
                    _ord.AdminId = order.AdminId;
                    _ord.MoneyTotal = order.MoneyTotal;
                    _ord.Cancel= order.Cancel;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
