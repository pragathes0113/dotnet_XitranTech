using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VHMS.Entity
{
    public class Stock
    {
        public int StockID { get; set; }
        public DateTime StockDate { get; set; }
        public string sStockDate { get; set; }
        public DateTime PurchaseBatchDate { get; set; }
        public string sPurchaseBatchDate { get; set; }
        public Master.Product Product { get; set; }
        public string Barcode { get; set; }
        public string BatchNo { get; set; }
        public decimal Quantity { get; set; }
        public decimal PreviousPrice { get; set; }
        public decimal PurchaseRate { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal SalesMargin { get; set; }
        public string Status { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }


}
