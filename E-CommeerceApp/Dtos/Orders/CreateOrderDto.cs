using E_CommeerceApp.Dtos.Products;
using System.ComponentModel.DataAnnotations;

namespace E_CommeerceApp.Dtos.Orders
{
    public class CreateOrderDto
    {
        [Key] public int OrdereID { get; set; }
        public string CustomerName { get; set; }
        public CreateProductDto Products { get; set; }
        public DateTime OrderData { get; set; }
    }
}
