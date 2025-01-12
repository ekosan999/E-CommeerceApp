using E_CommeerceApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_CommeerceApp.Controllers
{
    [ApiController]
    [Route($"api/Order")]
    public class OrderControllers : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderControllers(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsList(int id)
        {
            // Fetch products with pagination and filtering
            var result = await _orderRepository.GetOrdersAsync(id);

            return Ok(result);
        }

    }
}
