using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace VHMS.Entity
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string AlternateNo { get; set; }
        public string Email { get; set; }
        public string GSTNo { get; set; }
        public bool IsActive { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int StateID { get; set; } 
        public string Pincode { get; set; }
        public State State { get; set; }
       
    }
    public class ShippingAddress
    {
        public int ShippingAddressID { get; set; }
        public int CustomerID { get; set; }
        public string Address { get; set; }
        public string BranchName { get; set; }
        public string GSTIN { get; set; }
        public string StatusFlag { get; set; }

    }
}
