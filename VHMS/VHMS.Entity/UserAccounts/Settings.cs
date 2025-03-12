using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VHMS.Entity
{
    public class Settings
    {
        public decimal MaxDiscountPercent { get; set; }
        public DateTime OpeningDate { get; set; }
        public string sOpeningDate { get; set; }
        public Boolean SendSMS { get; set; }
        public string SenderName { get; set; }
        public string APILink { get; set; }
        public string SMSUsername { get; set; }
        public string SMSPassword { get; set; }
        public int Messagesentcnt { get; set; }
        public int NotificationSentCount { get; set; }
  	    public decimal SalesTaxAmount { get; set; }
        public decimal MaxSalesDiscount { get; set; }
        public decimal MaxSalesDiscountPercent { get; set; }
        public decimal WholeSaleMinMargin { get; set; }
        public decimal RetailMinMargin { get; set; }
        public string HostName { get; set; }
        public string Port { get; set; }
        public string CompanyName { get; set; }
        public string UserMailPassword { get; set; }
        public string TermsAndConditions { get; set; }
        public string AdditionalNotes { get; set; }
        public string UserMailID { get; set; }
        public Boolean DefaultCrendentials { get; set; }
        public Boolean EnableSSL { get; set; }
    }
   
}
