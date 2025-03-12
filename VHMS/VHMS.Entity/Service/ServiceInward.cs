using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace VHMS.Entity
{
    public class ServiceInward
    {
        public int ServiceInwardID { get; set; }
        public string ServiceInwardNo { get; set; }
        public DateTime ServiceInwardDate { get; set; }     
        public string sServiceInwardDate { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public string sBillDate { get; set; }
        public Billing.Supplier Supplier { get; set; }
        public string Narration { get; set; }
        public decimal DeliveryAmount { get; set; }
        public decimal PackageAmount { get; set; }       
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CUserName { get; set; }        
        public Collection<ServiceInwardTrans> ServiceInwardTrans { get; set; }
    }

    public class ServiceInwardTrans
    {
        public int ServiceInwardTransID { get; set; }
        public int ServiceInwardID { get; set; }
        public Master.Product Product { get; set; }
        public Service Service { get; set; }
        public Customer Customer { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceType { get; set; }
        public int TaxID { get; set; }
        public string SerialNo { get; set; }
        public decimal ServiceCharges { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal IGSTAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string StatusFlag { get; set; }

    }
    
}
