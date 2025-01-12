using E_CommeerceApp.Data.Interfaces;
using E_CommeerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommeerceApp.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Orders> GetOrdersAsync(int orderId)
        {
            var model = await _context.Orders
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.OrdereID == orderId);
            return model;
        }

        public async Task PleaceOrder(Orders orders)
        {
           await _context.Orders.AddAsync(orders);
            await _context.SaveChangesAsync();
        }
    }
}
