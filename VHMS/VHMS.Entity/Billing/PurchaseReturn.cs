using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace VHMS.Entity.Billing
{
    public class PurchaseReturn
    {
        public int PurchaseReturnID { get; set; }
        public string ReturnNo { get; set; }
        public DateTime ReturnDate { get; set; }
        public string sReturnDate { get; set; }
        public Supplier Supplier { get; set; }
        public Company Company { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Roundoff { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TotalQty { get; set; }
        public Purchase Purchase { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Notes { get; set; }
        public Collection<PurchaseReturnTrans> PurchaseReturnTrans { get; set; }
    }

    public class PurchaseReturnTrans
    {
        public int PurchaseReturnTransID { get; set; }
        public int PurchaseReturnID { get; set; }
        public int PurchaseTransID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public string Barcode { get; set; }
        public decimal SubTotal { get; set; }
        public Master.Product Product { get; set; }
        public string StatusFlag { get; set; }
        public string Notes { get; set; }
        public string BatchNo { get; set; }
     
    }

    public class PurchaseReturnFilter
    {
        public int PatientID { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int DoctorID { get; set; }
        public int UserID { get; set; }
    }
}
