using E_CommeerceApp.Dtos.Products;
using System.ComponentModel.DataAnnotations;

namespace E_CommeerceApp.Dtos.Orders
{
    public class OrderDto
    {
        [Key] public int OrdereID { get; set; }
        public string CustomerName { get; set; }
        public ProductDto Products { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderData { get; set; }
    }
}
