using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace VHMS.Entity
{
    public class ServiceDC
    {
        public int ServiceDCID { get; set; }
        public string ServiceDCNo { get; set; }
        public DateTime ServiceDCDate { get; set; }     
        public string sServiceDCDate { get; set; }
        public Billing.Supplier Supplier { get; set; }
        public string TransportName { get; set; }
        public string VehicleNo { get; set; }
        public string ContactNumber { get; set; }
        public string Narration { get; set; }
        public decimal DeliveryAmount { get; set; }
        public decimal PackageAmount { get; set; }       
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CUserName { get; set; }        
        public Collection<ServiceDCTrans> ServiceDCTrans { get; set; }
    }

    public class ServiceDCTrans
    {
        public int ServiceDCTransID { get; set; }
        public int ServiceDCID { get; set; }
        public Master.Product Product { get; set; }
        public Service Service { get; set; }
        public Customer Customer { get; set; }
        public string Description { get; set; }
        public string SerialNo { get; set; }
        public string StatusFlag { get; set; }

    }
    
}
