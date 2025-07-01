using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using VHMS.Entity;
using System.IO;


public partial interface IVHMSService
{

    #region Unit
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetUnit();

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetUnitByID(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddUnit(VHMS.Entity.Billing.Unit Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdateUnit(VHMS.Entity.Billing.Unit Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeleteUnit(int ID);
    #endregion

    #region Category
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetCategory();

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetCategoryByID(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddCategory(VHMS.Entity.Billing.Category Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdateCategory(VHMS.Entity.Billing.Category Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeleteCategory(int ID);
    #endregion

    #region Tax
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetTax();

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetTaxByID(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddTax(VHMS.Entity.Billing.Tax Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdateTax(VHMS.Entity.Billing.Tax Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeleteTax(int ID);
    #endregion

    #region Supplier
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSupplier();

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetAllSupplier(int iSupplierID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSupplierByID(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddSupplier(VHMS.Entity.Billing.Supplier Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdateSupplier(VHMS.Entity.Billing.Supplier Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeleteSupplier(int ID);
    #endregion

    #region SalesReturn
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesReturn(int PublisherID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetTopSalesReturn(int PublisherID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesReturnID(int PublisherID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string SearchSalesReturn(string ID = null);


    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesReturnByID(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesReturnByInvoice(string InvoiceNo);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddSalesReturn(VHMS.Entity.Billing.SalesReturn Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdateSalesReturn(VHMS.Entity.Billing.SalesReturn Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeleteSalesReturn(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesReturnSummary();

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesReturnReport(VHMS.Entity.Billing.SalesReturnFilter oJobCardFilter);

    #endregion

    #region Purchase
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPurchase(int PublisherID = 0, int BillType = 1);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPurchaseEntryByNo(int PublisherID = 0, int BillType = 1, int iSupplierID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetTopPurchase(int PublisherID = 0, int BillType = 1);
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetTopPurchaseSupplierWise(int iSupplierID = 0, int BillType = 1, int DC = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPurchaseDiscountBillNo(int SupplierID = 0, int BillType = 1, int PurchaseReturnID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPendingPurchaseDiscountBillNo(int SupplierID = 0, int BillType = 1, int PurchaseReturnID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetTopPurchasePending(int PublisherID = 0, int BillType = 1);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPendingPurchase(int PublisherID = 0, int BillType = 1);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string SearchPurchase(string ID = null, int BillType = 1, int DC = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string SearchPurchasePending(string ID = null, int BillType = 1);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetBillNo(int SupplierID = 0, int BillType = 1, int PurchaseReturnID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPurchaseByID(int ID, int BillType = 1);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPurchaseTransByID(int ID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPurchaseTransBarcodeByID(int ID = 0, int ProductId = 0, string Barcode = "");

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddPurchase(VHMS.Entity.Billing.Purchase Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdatePurchase(VHMS.Entity.Billing.Purchase Objdata);


    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdatePurchasePending(VHMS.Entity.Billing.Purchase Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeletePurchase(int ID);

    //[OperationContract]
    //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    //string GetOPBillingSummary();

    //[OperationContract]
    //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    //string GetOPBillingReport(VHMS.Entity.Billing.OPBillingFilter oJobCardFilter);

    #endregion

    #region SalesEntry
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesEntry(int PublisherID = 0, int IsRetail = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetTDSSalesEntry(int PublisherID = 0, int TDSSalesID = 0, int IsRetail = 0);


    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetAdjustTDSSalesEntry(int PublisherID = 0, int TDSSalesID = 0, int IsRetail = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPendingRetailSales();

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetLastInvoiceNo();

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetTopSalesEntry(int PublisherID = 0, int IsRetail = 0, int iCustomerID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetTopSalesEntryDeleteList(int PublisherID = 0, int IsRetail = 0, int iCustomerID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesEntryBookingBill(int PublisherID = 0, int IsRetail = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPendingSalesEntry(int PublisherID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetAmountClearEntry(int PublisherID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPendingRetailBills(int PublisherID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesEntryByInvoice(string InvoiceNo);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesEntryByInvoiceReturn(string InvoiceNo, int SalesReturnID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string SearchSalesEntry(string ID = null, int IsRetail = 0);


    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string SearchSalesEntryDeleteList(string ID = null, int IsRetail = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string SearchSalesEntryBokingBill(string ID = null, int IsRetail = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesEntryByID(int ID, int IsRetail = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetLastSalesEntryByID(int ID, int IsRetail = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddSalesEntry(VHMS.Entity.Billing.SalesEntry Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdateSalesEntry(VHMS.Entity.Billing.SalesEntry Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeleteSalesEntry(int ID, string Reason);

    //[OperationContract]
    //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    //string GetOPBillingSummary();

    //[OperationContract]
    //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    //string GetOPBillingReport(VHMS.Entity.Billing.OPBillingFilter oJobCardFilter);

    #endregion

    #region PurchaseReturn
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPurchaseReturn(int PublisherID = 0, int iSupplierID = 0, int BillType = 1);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string SearchPurchaseReturn(string ID = null, int BillType = 1);


    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPurchaseReturnByID(int ID, int Type);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddPurchaseReturn(VHMS.Entity.Billing.PurchaseReturn Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdatePurchaseReturn(VHMS.Entity.Billing.PurchaseReturn Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeletePurchaseReturn(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetQuantity(int ID = 0, int PurchaseID = 0, int SupplierID = 0);

    #endregion

    #region Payment
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPayment();

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetPaymentByID(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetLastPaymentDetails(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddPayment(VHMS.Entity.Billing.Payment Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdatePayment(VHMS.Entity.Billing.Payment Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeletePayment(int ID);
    #endregion

    #region Receipt
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetReceipt(int IsRetail);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetLastReceiptDetails(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetReceiptByStatus(string Status);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetReceiptByID(int ID, int IsRetail);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetOnAccountAmount(int ID, string Type);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddReceipt(VHMS.Entity.Receipt Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdateReceipt(VHMS.Entity.Receipt Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeleteReceipt(int ID);
    #endregion

    #region Expense
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetExpense(int PublisherID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string SearchExpense(string ID = null);


    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetExpenseByID(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddExpense(VHMS.Entity.Billing.Expense Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdateExpense(VHMS.Entity.Billing.Expense Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeleteExpense(int ID);

    #endregion

    #region SalesOrder
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesOrder(int PublisherID = 0, string Flag = null);


    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesOrderPending(int PublisherID = 0);

    //[OperationContract]
    //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    //string GetSalesOrderToWorkOrder(int iSalesOrderID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesOrderByCustomer(int CustomerID = 0);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string SearchSalesOrder(string ID = null, string Flag = null);


    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetSalesOrderByID(int ID, string iFlag = null);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddSalesOrder(VHMS.Entity.Billing.SalesOrder Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdateSalesOrder(VHMS.Entity.Billing.SalesOrder Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeleteSalesOrder(int ID);


    #endregion


}