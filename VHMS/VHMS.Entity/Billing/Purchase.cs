using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace VHMS.Entity.Billing
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public string PurchaseNo { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public string sPurchaseDate { get; set; }
        public string sBillDate { get; set; }
        public Supplier Supplier { get; set; }
        public Company Company { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Roundoff { get; set; }
        public decimal NetAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal TotalQty { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Comments { get; set; }
        public Collection<PurchaseTrans> PurchaseTrans { get; set; }
    }

    public class PurchaseTrans
    {
        public int PurchaseTransID { get; set; }
        public int PurchaseID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public string Barcode { get; set; }
        public string StatusFlag { get; set; }
        public decimal SubTotal { get; set; }
        public Master.Product Product { get; set; }
        public DateTime PurchaseBatchDate { get; set; }
        public string sPurchaseBatchDate { get; set; }
        public decimal SellingRate { get; set; }
        public decimal PreviousRate { get; set; }
    }
    public class PurchaseFilter
    {
        public int PatientID { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int DoctorID { get; set; }
        public int UserID { get; set; }
    }


    public class PurchaseTransDetails
    {
        public int PurchaseTransID { get; set; }
        public int PurchaseID { get; set; }
        public decimal Quantity { get; set; }
        public string Barcode { get; set; }
        public decimal Rate { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal SubTotal { get; set; }
        public Master.Product Product { get; set; }
        public string SupplierName { get; set; }
        public string StatusFlag { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public string sBillDate { get; set; }
        public string PurchaseNo { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string sPurchaseDate { get; set; }
        public string BatchNo { get; set; }
        public string SerialNo { get; set; }
        public DateTime PurchaseBatchDate { get; set; }
        public string sPurchaseBatchDate { get; set; }
        public decimal SellingRate { get; set; }
    }
}
