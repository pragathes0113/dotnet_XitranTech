using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VHMS.Entity.Master
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Billing.Category Category { get; set; }
        public Billing.Supplier Supplier { get; set; }
        public Billing.Unit Unit { get; set; }
        public Billing.Tax Tax { get; set; }
        public string ProductCode { get; set; }
        public string ProductImage1 { get; set; }
        public string ProductImage2 { get; set; }
        public string ProductImage3 { get; set; }
        public Decimal SalesPercent { get; set; }
        public Boolean IsActive { get; set; }
        public Company Company { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string sCreatedOn { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Decimal AvailableQty { get; set; }
        public Decimal PurchaseRate { get; set; }
        public Decimal SellingRate { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal PerviousRate { get; set; }
    }
}
