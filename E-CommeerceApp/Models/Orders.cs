using System.ComponentModel.DataAnnotations;

namespace E_CommeerceApp.Models
{
    public class Orders
    {
        [Key] public int OrdereID { get; set; }
        public string CustomerName { get; set; }
        public int ProductId  { get; set; }
        public Products Products { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderData { get; set; }


    }
}
