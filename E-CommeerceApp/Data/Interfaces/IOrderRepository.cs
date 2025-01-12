using E_CommeerceApp.Models;

namespace E_CommeerceApp.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task PleaceOrder(Orders orders);
        Task <Orders> GetOrdersAsync(int orderId);
            
    }
}
