using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.ObjectModel;
using VHMS;

namespace VHMS.DataAccess.Billing
{
    public class SalesReturn
    {
        public static Collection<Entity.Billing.SalesReturn> GetSalesReturn(int ipatientID = 0,int CompanyID=0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.SalesReturn> objList = new Collection<Entity.Billing.SalesReturn>();
            Entity.Billing.SalesReturn objSalesReturn;
            Entity.Customer objCustomer;  Entity.Billing.Tax objTax;

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESRETURN);
                db.AddInParameter(cmd, "@PK_SalesReturnID", DbType.Int32, ipatientID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesReturn = new Entity.Billing.SalesReturn();
                        objCustomer = new Entity.Customer();
                        
                        objTax = new Entity.Billing.Tax();

                        objSalesReturn.SalesReturnID = Convert.ToInt32(drData["PK_SalesReturnID"]);
                        objSalesReturn.ReturnNo = Convert.ToString(drData["ReturnNo"]);
                        objSalesReturn.ReturnDate = Convert.ToDateTime(drData["ReturnDate"]);
                        objSalesReturn.sReturnDate = objSalesReturn.ReturnDate.ToString("dd/MM/yyyy");
                        objSalesReturn.OldInvoiceNo = Convert.ToString(drData["OldInvoiceNo"]);
                        objSalesReturn.BillNo = Convert.ToString(drData["BillNo"]);
                        objSalesReturn.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSalesReturn.sBillDate = objSalesReturn.BillDate.ToString("dd/MM/yyyy");

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objSalesReturn.Customer = objCustomer;
                      
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objSalesReturn.Tax = objTax;
                        objSalesReturn.SalesEntryID = Convert.ToInt32(drData["FK_SalesEntryID"]);
                        objSalesReturn.InvoiceNo = Convert.ToString(drData["InvoiceNo"]);
                        objSalesReturn.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objSalesReturn.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesReturn.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesReturn.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesReturn.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objSalesReturn.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objSalesReturn.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objSalesReturn.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesReturn.ReturnAmount = Convert.ToDecimal(drData["ReturnAmount"]);
                        objSalesReturn.InvoiceBillType = Convert.ToBoolean(drData["Invoice_BillType"]);
                        objSalesReturn.CustomerBillType = Convert.ToBoolean(drData["Customer_BillType"]);
                        objSalesReturn.Roundoff = Convert.ToDecimal(drData["RoundOff"]);
                        objSalesReturn.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objSalesReturn.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objSalesReturn.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objList.Add(objSalesReturn);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesReturn GetSalesReturn | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Billing.SalesReturn> GetTopSalesReturn(int ipatientID = 0, int iBranchID=0, int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.SalesReturn> objList = new Collection<Entity.Billing.SalesReturn>();
            Entity.Billing.SalesReturn objSalesReturn;
            Entity.Customer objCustomer;  Entity.Billing.Tax objTax;

            try
            {

                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_TOPSALESRETURN);
                db.AddInParameter(cmd, "@PK_SalesReturnID", DbType.Int32, ipatientID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesReturn = new Entity.Billing.SalesReturn();
                        objCustomer = new Entity.Customer();
                        
                        objTax = new Entity.Billing.Tax();

                        objSalesReturn.SalesReturnID = Convert.ToInt32(drData["PK_SalesReturnID"]);
                        objSalesReturn.ReturnNo = Convert.ToString(drData["ReturnNo"]);
                        objSalesReturn.ReturnDate = Convert.ToDateTime(drData["ReturnDate"]);
                        objSalesReturn.sReturnDate = objSalesReturn.ReturnDate.ToString("dd/MM/yyyy");

                        objSalesReturn.BillNo = Convert.ToString(drData["BillNo"]);
                        objSalesReturn.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSalesReturn.sBillDate = objSalesReturn.BillDate.ToString("dd/MM/yyyy");
                        objSalesReturn.OldInvoiceNo = Convert.ToString(drData["OldInvoiceNo"]);

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objSalesReturn.Customer = objCustomer;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objSalesReturn.Tax = objTax;
                        objSalesReturn.SalesEntryID = Convert.ToInt32(drData["FK_SalesEntryID"]);
                        objSalesReturn.InvoiceNo = Convert.ToString(drData["InvoiceNo"]);
                        objSalesReturn.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objSalesReturn.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesReturn.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesReturn.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesReturn.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objSalesReturn.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objSalesReturn.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objSalesReturn.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesReturn.ReturnAmount = Convert.ToDecimal(drData["ReturnAmount"]);
                        objSalesReturn.InvoiceBillType = Convert.ToBoolean(drData["Invoice_BillType"]);
                        objSalesReturn.CustomerBillType = Convert.ToBoolean(drData["Customer_BillType"]);
                        objSalesReturn.Roundoff = Convert.ToDecimal(drData["RoundOff"]);
                        objSalesReturn.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objSalesReturn.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objSalesReturn.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objList.Add(objSalesReturn);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesReturn GetSalesReturn | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Billing.SalesReturn> GetSalesReturnID(int ipatientID = 0, int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.SalesReturn> objList = new Collection<Entity.Billing.SalesReturn>();
            Entity.Billing.SalesReturn objSalesReturn;
            Entity.Customer objCustomer;  Entity.Billing.Tax objTax;

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESRETURN);
                db.AddInParameter(cmd, "@PK_SalesReturnID", DbType.Int32, ipatientID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesReturn = new Entity.Billing.SalesReturn();

                        objCustomer = new Entity.Customer();
                        
                        objTax = new Entity.Billing.Tax();

                        objSalesReturn.SalesReturnID = Convert.ToInt32(drData["PK_SalesReturnID"]);
                        objSalesReturn.ReturnNo = Convert.ToString(drData["ReturnNo"]);
                        objSalesReturn.ReturnDate = Convert.ToDateTime(drData["ReturnDate"]);
                        objSalesReturn.sReturnDate = objSalesReturn.ReturnDate.ToString("dd/MM/yyyy");
                        objSalesReturn.BillNo = Convert.ToString(drData["BillNo"]);
                        objSalesReturn.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSalesReturn.sBillDate = objSalesReturn.BillDate.ToString("dd/MM/yyyy");
                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objSalesReturn.Customer = objCustomer;
                        objSalesReturn.OldInvoiceNo = Convert.ToString(drData["OldInvoiceNo"]);

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objSalesReturn.Tax = objTax;
                        objSalesReturn.SalesEntryID = Convert.ToInt32(drData["FK_SalesEntryID"]);
                        objSalesReturn.InvoiceNo = Convert.ToString(drData["InvoiceNo"]);
                        objSalesReturn.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objSalesReturn.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesReturn.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesReturn.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objSalesReturn.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesReturn.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objSalesReturn.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objSalesReturn.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesReturn.ReturnAmount = Convert.ToDecimal(drData["ReturnAmount"]);
                        objSalesReturn.InvoiceBillType = Convert.ToBoolean(drData["Invoice_BillType"]);
                        objSalesReturn.CustomerBillType = Convert.ToBoolean(drData["Customer_BillType"]);
                        objSalesReturn.Roundoff = Convert.ToDecimal(drData["RoundOff"]);
                        objSalesReturn.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objSalesReturn.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objSalesReturn.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objList.Add(objSalesReturn);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesReturn GetSalesReturn | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Billing.SalesReturn> SearchSalesReturn(string ID, int iBranchID,int CompanyID=0  )
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.SalesReturn> objList = new Collection<Entity.Billing.SalesReturn>();
            Entity.Billing.SalesReturn objSalesReturn;
            Entity.Customer objCustomer;  Entity.Billing.Tax objTax;

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SEARCH_SALESRETURN);
                db.AddInParameter(cmd, "@key", DbType.String, ID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesReturn = new Entity.Billing.SalesReturn();
                        objCustomer = new Entity.Customer();
                        
                        objTax = new Entity.Billing.Tax();

                        objSalesReturn.SalesReturnID = Convert.ToInt32(drData["PK_SalesReturnID"]);
                        objSalesReturn.ReturnNo = Convert.ToString(drData["ReturnNo"]);
                        objSalesReturn.ReturnDate = Convert.ToDateTime(drData["ReturnDate"]);
                        objSalesReturn.sReturnDate = objSalesReturn.ReturnDate.ToString("dd/MM/yyyy");

                        objSalesReturn.BillNo = Convert.ToString(drData["BillNo"]);
                        objSalesReturn.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSalesReturn.sBillDate = objSalesReturn.BillDate.ToString("dd/MM/yyyy");
                        objSalesReturn.OldInvoiceNo = Convert.ToString(drData["OldInvoiceNo"]);

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objSalesReturn.Customer = objCustomer;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objSalesReturn.Tax = objTax;
                        objSalesReturn.SalesEntryID = Convert.ToInt32(drData["FK_SalesEntryID"]);
                        objSalesReturn.InvoiceNo = Convert.ToString(drData["InvoiceNo"]);
                        objSalesReturn.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objSalesReturn.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesReturn.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesReturn.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesReturn.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objSalesReturn.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objSalesReturn.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesReturn.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objSalesReturn.ReturnAmount = Convert.ToDecimal(drData["ReturnAmount"]);
                        objSalesReturn.InvoiceBillType = Convert.ToBoolean(drData["Invoice_BillType"]);
                        objSalesReturn.CustomerBillType = Convert.ToBoolean(drData["Customer_BillType"]);
                        objSalesReturn.Roundoff = Convert.ToDecimal(drData["RoundOff"]);
                        objSalesReturn.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objSalesReturn.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objSalesReturn.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objList.Add(objSalesReturn);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesReturn GetSalesReturn | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        
        public static Entity.Billing.SalesReturn GetSalesReturnByID(int iSalesReturnID, int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            Entity.Billing.SalesReturn objSalesReturn = new Entity.Billing.SalesReturn();
            Entity.Customer objCustomer;  Entity.Billing.Tax objTax;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESRETURN);
                db.AddInParameter(cmd, "@PK_SalesReturnID", DbType.Int32, iSalesReturnID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesReturn = new Entity.Billing.SalesReturn();
                        objCustomer = new Entity.Customer();
                        
                        objTax = new Entity.Billing.Tax();

                        objSalesReturn.SalesReturnID = Convert.ToInt32(drData["PK_SalesReturnID"]);
                        objSalesReturn.ReturnNo = Convert.ToString(drData["ReturnNo"]);
                        objSalesReturn.ReturnDate = Convert.ToDateTime(drData["ReturnDate"]);
                        objSalesReturn.sReturnDate = objSalesReturn.ReturnDate.ToString("dd/MM/yyyy");

                        objSalesReturn.BillNo = Convert.ToString(drData["BillNo"]);
                        objSalesReturn.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSalesReturn.sBillDate = objSalesReturn.BillDate.ToString("dd/MM/yyyy");

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                        objSalesReturn.Customer = objCustomer;
                        objSalesReturn.OldInvoiceNo = Convert.ToString(drData["OldInvoiceNo"]);

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objSalesReturn.Tax = objTax;
                        objSalesReturn.SalesEntryID = Convert.ToInt32(drData["FK_SalesEntryID"]);
                        objSalesReturn.InvoiceNo = Convert.ToString(drData["InvoiceNo"]);
                        objSalesReturn.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objSalesReturn.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesReturn.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesReturn.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objSalesReturn.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesReturn.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objSalesReturn.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objSalesReturn.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesReturn.ReturnAmount = Convert.ToDecimal(drData["ReturnAmount"]);
                        objSalesReturn.InvoiceBillType = Convert.ToBoolean(drData["Invoice_BillType"]);
                        objSalesReturn.CustomerBillType = Convert.ToBoolean(drData["Customer_BillType"]);
                        objSalesReturn.Roundoff = Convert.ToDecimal(drData["RoundOff"]);
                        objSalesReturn.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objSalesReturn.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objSalesReturn.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objSalesReturn.SalesReturnTrans = SalesReturnTrans.GetSalesReturnTransBySalesReturnID(objSalesReturn.SalesReturnID);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesReturn GetSalesReturnByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objSalesReturn;
        }

        public static Entity.Billing.SalesReturn GetSalesReturnByReturn(string ReturnNo)
        {
            string sException = string.Empty;
            Database db;
            Entity.Billing.SalesReturn objSalesReturn = new Entity.Billing.SalesReturn();
            Entity.Customer objCustomer;  Entity.Billing.Tax objTax;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESRETURNINVOICE);
                db.AddInParameter(cmd, "@ReturnNo", DbType.String, ReturnNo);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesReturn = new Entity.Billing.SalesReturn();
                        objCustomer = new Entity.Customer();
                        
                        objTax = new Entity.Billing.Tax();

                        objSalesReturn.SalesReturnID = Convert.ToInt32(drData["PK_SalesReturnID"]);
                        objSalesReturn.ReturnNo = Convert.ToString(drData["ReturnNo"]);
                        objSalesReturn.ReturnDate = Convert.ToDateTime(drData["ReturnDate"]);
                        objSalesReturn.sReturnDate = objSalesReturn.ReturnDate.ToString("dd/MM/yyyy");

                        objSalesReturn.BillNo = Convert.ToString(drData["BillNo"]);
                        objSalesReturn.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSalesReturn.sBillDate = objSalesReturn.BillDate.ToString("dd/MM/yyyy");

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                        objSalesReturn.Customer = objCustomer;
                        objSalesReturn.OldInvoiceNo = Convert.ToString(drData["OldInvoiceNo"]);

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objSalesReturn.Tax = objTax;
                        objSalesReturn.SalesEntryID = Convert.ToInt32(drData["FK_SalesEntryID"]);
                        objSalesReturn.InvoiceNo = Convert.ToString(drData["InvoiceNo"]);
                        objSalesReturn.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objSalesReturn.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesReturn.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesReturn.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesReturn.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objSalesReturn.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objSalesReturn.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesReturn.ReturnAmount = Convert.ToDecimal(drData["ReturnAmount"]);
                        objSalesReturn.Roundoff = Convert.ToDecimal(drData["RoundOff"]);

                        objSalesReturn.SalesReturnTrans = SalesReturnTrans.GetSalesReturnTransBySalesReturnID(objSalesReturn.SalesReturnID);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesReturn GetSalesReturnByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objSalesReturn;
        }
        public static int AddSalesReturn(Entity.Billing.SalesReturn objSalesReturn)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_SALESRETURN);
                db.AddOutParameter(cmd, "@PK_SalesReturnID", DbType.Int32, objSalesReturn.SalesReturnID);
                db.AddInParameter(cmd, "@ReturnNo", DbType.String, objSalesReturn.ReturnNo);
                db.AddInParameter(cmd, "@ReturnDate", DbType.String, objSalesReturn.sReturnDate);
                db.AddInParameter(cmd, "@BillNo", DbType.String, objSalesReturn.BillNo);
                db.AddInParameter(cmd, "@OldInvoiceNo", DbType.String, objSalesReturn.OldInvoiceNo);
                db.AddInParameter(cmd, "@BillDate", DbType.String, objSalesReturn.sBillDate);
                db.AddInParameter(cmd, "@FK_CustomerID", DbType.Int32, objSalesReturn.Customer.CustomerID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objSalesReturn.Company.CompanyID);
                db.AddInParameter(cmd, "@FK_SalesEntryID", DbType.Int32, objSalesReturn.SalesEntryID);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.Int32, objSalesReturn.Tax.TaxID);
                db.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objSalesReturn.TaxPercent);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objSalesReturn.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objSalesReturn.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objSalesReturn.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objSalesReturn.TaxAmount);
                db.AddInParameter(cmd, "@TotalAmount", DbType.Decimal, objSalesReturn.TotalAmount);
                db.AddInParameter(cmd, "@DiscountPercent", DbType.Decimal, objSalesReturn.DiscountPercent);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objSalesReturn.DiscountAmount);
                db.AddInParameter(cmd, "@Invoice_BillType", DbType.Boolean, objSalesReturn.InvoiceBillType);
                db.AddInParameter(cmd, "@Customer_BillType", DbType.Boolean, objSalesReturn.CustomerBillType);
                db.AddInParameter(cmd, "@RoundOff", DbType.Decimal, objSalesReturn.Roundoff);
                db.AddInParameter(cmd, "@ImagePath1", DbType.String, objSalesReturn.ImagePath1);
                db.AddInParameter(cmd, "@ImagePath2", DbType.String, objSalesReturn.ImagePath2);
                db.AddInParameter(cmd, "@ImagePath3", DbType.String, objSalesReturn.ImagePath3);

                db.AddInParameter(cmd, "@ReturnAmount", DbType.Decimal, objSalesReturn.ReturnAmount);               
                db.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objSalesReturn.CreatedBy.UserID);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_SalesReturnID"));

                foreach (Entity.Billing.SalesReturnTrans ObjSalesReturnTrans in objSalesReturn.SalesReturnTrans)
                    ObjSalesReturnTrans.SalesReturnID = iID;

                SalesReturnTrans.SaveSalesReturnTransaction(objSalesReturn.SalesReturnTrans);
            }
            catch (Exception ex)
            {
                sException = "SalesReturn AddSalesReturn | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateSalesReturn(Entity.Billing.SalesReturn objSalesReturn)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_SALESRETURN);
                db.AddInParameter(cmd, "@PK_SalesReturnID", DbType.Int32, objSalesReturn.SalesReturnID);
                db.AddInParameter(cmd, "@ReturnDate", DbType.String, objSalesReturn.sReturnDate);
                db.AddInParameter(cmd, "@BillNo", DbType.String, objSalesReturn.BillNo);
                db.AddInParameter(cmd, "@BillDate", DbType.String, objSalesReturn.sBillDate);
                db.AddInParameter(cmd, "@FK_CustomerID", DbType.Int32, objSalesReturn.Customer.CustomerID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objSalesReturn.Company.CompanyID);
                db.AddInParameter(cmd, "@FK_SalesEntryID", DbType.Int32, objSalesReturn.SalesEntryID);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.Int32, objSalesReturn.Tax.TaxID);
                db.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objSalesReturn.TaxPercent);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objSalesReturn.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objSalesReturn.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objSalesReturn.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objSalesReturn.TaxAmount);
                db.AddInParameter(cmd, "@TotalAmount", DbType.Decimal, objSalesReturn.TotalAmount);
                db.AddInParameter(cmd, "@DiscountPercent", DbType.Decimal, objSalesReturn.DiscountPercent);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objSalesReturn.DiscountAmount);
                db.AddInParameter(cmd, "@ReturnAmount", DbType.Decimal, objSalesReturn.ReturnAmount);                
                db.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objSalesReturn.ModifiedBy.UserID);
                db.AddInParameter(cmd, "@Invoice_BillType", DbType.Boolean, objSalesReturn.InvoiceBillType);
                db.AddInParameter(cmd, "@Customer_BillType", DbType.Boolean, objSalesReturn.CustomerBillType);
                db.AddInParameter(cmd, "@OldInvoiceNo", DbType.String, objSalesReturn.OldInvoiceNo);
                db.AddInParameter(cmd, "@RoundOff", DbType.Decimal, objSalesReturn.Roundoff);
                db.AddInParameter(cmd, "@ImagePath1", DbType.String, objSalesReturn.ImagePath1);
                db.AddInParameter(cmd, "@ImagePath2", DbType.String, objSalesReturn.ImagePath2);
                db.AddInParameter(cmd, "@ImagePath3", DbType.String, objSalesReturn.ImagePath3);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;

                foreach (Entity.Billing.SalesReturnTrans ObjSalesReturnTrans in objSalesReturn.SalesReturnTrans)
                    ObjSalesReturnTrans.SalesReturnID = objSalesReturn.SalesReturnID;

                SalesReturnTrans.SaveSalesReturnTransaction(objSalesReturn.SalesReturnTrans);
            }
            catch (Exception ex)
            {
                sException = "SalesReturn UpdateSalesReturn| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteSalesReturn(int iSalesReturnId)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_SALESRETURN);
                db.AddInParameter(cmd, "@PK_SalesReturnID", DbType.Int32, iSalesReturnId);
               // db.AddInParameter(cmd, "@Reason", DbType.String, Reason);
              //  db.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, iUserId);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "SalesReturn DeleteSalesReturn | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static DataSet GetSalesReturnSummary()
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESRETURNSUMMARY);
                dsList = db.ExecuteDataSet(cmd);
            }
            catch (Exception ex)
            {
                sException = "SalesReturn GetSalesReturnSummary | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return dsList;
        }
    }

    public class SalesReturnTrans
    {
        public static Collection<Entity.Billing.SalesReturnTrans> GetSalesReturnTransBySalesReturnID(int iSalesReturnID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.SalesReturnTrans> objList = new Collection<Entity.Billing.SalesReturnTrans>();
            Entity.Billing.SalesReturnTrans objSalesReturnTrans = new Entity.Billing.SalesReturnTrans();
            Entity.Master.Product ObjProduct; Entity.Billing.Tax objTax;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESRETURNTRANS);
                db.AddInParameter(cmd, "@FK_SalesReturnID", DbType.Int32, iSalesReturnID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesReturnTrans = new Entity.Billing.SalesReturnTrans();
                        ObjProduct = new Entity.Master.Product();
                        objTax = new Entity.Billing.Tax();

                        objSalesReturnTrans.SalesReturnTransID = Convert.ToInt32(drData["PK_SalesReturnTransID"]);
                        objSalesReturnTrans.SalesReturnID = Convert.ToInt32(drData["FK_SalesReturnID"]);
                        ObjProduct.ProductID = Convert.ToInt32(drData["Fk_ProductID"]);
                        ObjProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        ObjProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        
                        objSalesReturnTrans.Product = ObjProduct;
                        objSalesReturnTrans.Barcode = Convert.ToString(drData["Barcode"]);
                        objSalesReturnTrans.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objSalesReturnTrans.DiscountPercentage = Convert.ToDecimal(drData["DiscountPercentage"]);
                        objSalesReturnTrans.SalesEntryTransID = Convert.ToInt32(drData["FK_SalesEntryTransID"]);
                        objSalesReturnTrans.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesReturnTrans.Rate = Convert.ToDecimal(drData["Rate"]);
                        objSalesReturnTrans.SubTotal = Convert.ToDecimal(drData["Subtotal"]);
                        objSalesReturnTrans.Notes = Convert.ToString(drData["Notes"]);

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxPercentage = Convert.ToDecimal(drData["TaxPercent"]);
                        objTax.SGSTPercent = Convert.ToDecimal(drData["SGSTPercent"]);
                        objTax.IGSTPercent = Convert.ToDecimal(drData["IGSTPercent"]);
                        objTax.CGSTPercent = Convert.ToDecimal(drData["CGSTPercent"]);
                        objSalesReturnTrans.Tax = objTax;

                        objSalesReturnTrans.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesReturnTrans.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesReturnTrans.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesReturnTrans.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);

                        objList.Add(objSalesReturnTrans);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesReturnTrans GetSalesReturnTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static void SaveSalesReturnTransaction(Collection<Entity.Billing.SalesReturnTrans> ObjSalesReturnTransList)
        {
            int iID = 0;
            bool bResult = false;

            foreach (Entity.Billing.SalesReturnTrans ObjSalesReturnTransaction in ObjSalesReturnTransList)
            {
                if (ObjSalesReturnTransaction.StatusFlag == "I")
                    iID = AddSalesReturnTrans(ObjSalesReturnTransaction);
                else if (ObjSalesReturnTransaction.StatusFlag == "U")
                    bResult = UpdateSalesReturnTrans(ObjSalesReturnTransaction);
                else if (ObjSalesReturnTransaction.StatusFlag == "D")
                    bResult = DeleteSalesReturnTrans(ObjSalesReturnTransaction.SalesReturnTransID);
            }
        }
        public static int AddSalesReturnTrans(Entity.Billing.SalesReturnTrans objSalesReturnTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_SALESRETURNTRANS);
                db.AddOutParameter(cmd, "@PK_SalesReturnTransID", DbType.Int32, objSalesReturnTrans.SalesReturnTransID);
                db.AddInParameter(cmd, "@FK_SalesReturnID", DbType.Int32, objSalesReturnTrans.SalesReturnID);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.Int32, objSalesReturnTrans.Product.ProductID);
                db.AddInParameter(cmd, "@Barcode", DbType.String, objSalesReturnTrans.Barcode);
                db.AddInParameter(cmd, "@Quantity", DbType.Decimal, objSalesReturnTrans.Quantity);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, objSalesReturnTrans.Rate);
                db.AddInParameter(cmd, "@Subtotal", DbType.Decimal, objSalesReturnTrans.SubTotal);
                db.AddInParameter(cmd, "@DiscountPercentage", DbType.Decimal, objSalesReturnTrans.DiscountPercentage);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objSalesReturnTrans.DiscountAmount);
                db.AddInParameter(cmd, "@FK_SalesEntryTransID", DbType.Int32, objSalesReturnTrans.SalesEntryTransID);
                db.AddInParameter(cmd, "@ProductName", DbType.String, objSalesReturnTrans.Product.ProductName);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.String, objSalesReturnTrans.Tax.TaxID);
                db.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objSalesReturnTrans.Tax.TaxPercentage);
                db.AddInParameter(cmd, "@IGSTPercent", DbType.Decimal, objSalesReturnTrans.Tax.IGSTPercent);
                db.AddInParameter(cmd, "@SGSTPercent", DbType.Decimal, objSalesReturnTrans.Tax.SGSTPercent);
                db.AddInParameter(cmd, "@CGSTPercent", DbType.Decimal, objSalesReturnTrans.Tax.CGSTPercent);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objSalesReturnTrans.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objSalesReturnTrans.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objSalesReturnTrans.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objSalesReturnTrans.TaxAmount);
                db.AddInParameter(cmd, "@Notes", DbType.String, objSalesReturnTrans.Notes);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_SalesReturnTransID"));
            }
            catch (Exception ex)
            {
                sException = "SalesReturnTrans AddSalesReturnTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateSalesReturnTrans(Entity.Billing.SalesReturnTrans objSalesReturnTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_SALESRETURNTRANS);
                db.AddInParameter(cmd, "@PK_SalesReturnTransID", DbType.Int32, objSalesReturnTrans.SalesReturnTransID);
                db.AddInParameter(cmd, "@FK_SalesReturnID", DbType.Int32, objSalesReturnTrans.SalesReturnID);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.Int32, objSalesReturnTrans.Product.ProductID);
                db.AddInParameter(cmd, "@Barcode", DbType.String, objSalesReturnTrans.Barcode);
                db.AddInParameter(cmd, "@Quantity", DbType.Decimal, objSalesReturnTrans.Quantity);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, objSalesReturnTrans.Rate);
                db.AddInParameter(cmd, "@Subtotal", DbType.Decimal, objSalesReturnTrans.SubTotal);
                db.AddInParameter(cmd, "@DiscountPercentage", DbType.Decimal, objSalesReturnTrans.DiscountPercentage);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objSalesReturnTrans.DiscountAmount);
                db.AddInParameter(cmd, "@FK_SalesEntryTransID", DbType.Int32, objSalesReturnTrans.SalesEntryTransID);
                db.AddInParameter(cmd, "@ProductName", DbType.String, objSalesReturnTrans.Product.ProductName);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.String, objSalesReturnTrans.Tax.TaxID);
                db.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objSalesReturnTrans.Tax.TaxPercentage);
                db.AddInParameter(cmd, "@IGSTPercent", DbType.Decimal, objSalesReturnTrans.Tax.IGSTPercent);
                db.AddInParameter(cmd, "@SGSTPercent", DbType.Decimal, objSalesReturnTrans.Tax.SGSTPercent);
                db.AddInParameter(cmd, "@CGSTPercent", DbType.Decimal, objSalesReturnTrans.Tax.CGSTPercent);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objSalesReturnTrans.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objSalesReturnTrans.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objSalesReturnTrans.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objSalesReturnTrans.TaxAmount);
                db.AddInParameter(cmd, "@Notes", DbType.String, objSalesReturnTrans.Notes);
                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "SalesReturnTrans UpdateSalesReturnTrans| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteSalesReturnTrans(int iSalesReturnTransID)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_SALESRETURNTRANS);
                db.AddInParameter(cmd, "@PK_SalesReturnTransID", DbType.Int32, iSalesReturnTransID);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "SalesReturnTrans DeleteSalesReturnTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        
    }
}
