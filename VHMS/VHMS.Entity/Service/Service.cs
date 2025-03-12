using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace VHMS.Entity
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceNo { get; set; }
        public DateTime ServiceDate { get; set; }
        public string sServiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string sInvoiceDate { get; set; }
        public Customer Customer { get; set; }
        public Billing.Tax Tax { get; set; }
        public Master.Product Product { get; set; }       
        public string Status { get; set; }
        public string DamageDescription { get; set; }
        public string ServiceDescription { get; set; }
        public decimal ServiceCharges { get; set; }
        public decimal TransportCharges { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal IGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Roundoff { get; set; }
        public ServiceInwardTrans ServiceInwardTrans { get; set; }
        public decimal AdvancePaid { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public Boolean Warranty { get; set; }
        public string SerialNo { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
      
    }
       
}
