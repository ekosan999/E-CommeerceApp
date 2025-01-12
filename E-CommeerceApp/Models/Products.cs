using System.ComponentModel.DataAnnotations;

namespace E_CommeerceApp.Models
{
    public class Products
    {
        [Key] public int ProductID { get; set; }
        public  string Name { get; set; }
        public string Description { get; set; }
        public  decimal Price { get; set; }
        public  int StockQuantity { get; set; }

        #region Audit Column 
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        #endregion
    }
}
