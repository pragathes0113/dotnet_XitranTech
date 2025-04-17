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
    public class Purchase
    {
        #region SelectPurchase
        public static Collection<Entity.Billing.Purchase> GetPurchase(int ipatientID = 0, int BillType = 1,int CompanyID=0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.Purchase> objList = new Collection<Entity.Billing.Purchase>();
            Entity.Billing.Purchase objPurchase;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASE);
                db.AddInParameter(cmd, "@PK_PurchaseID", DbType.Int32, ipatientID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        

                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);

                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objPurchase.Supplier = objSupplier;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objPurchase.Tax = objTax;
                        objPurchase.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objPurchase.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objPurchase.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objPurchase.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objPurchase.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objPurchase.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchase.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objPurchase.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objPurchase.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objPurchase.CourierCharges = Convert.ToDecimal(drData["CourierCharges"]);
                        objPurchase.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchase.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchase.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objPurchase.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objPurchase.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy") + " " + objPurchase.CreatedOn.ToString("h:mm");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");
                        objPurchase.Comments = Convert.ToString(drData["Comments"]);
                        objPurchase.Status = Convert.ToString(drData["Status"]);
                        objPurchase.DocumentPath = Convert.ToString(drData["DocumentPath"]);
                        objPurchase.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objPurchase.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objPurchase.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objList.Add(objPurchase);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Billing.Purchase> GetPurchaseEntryByNo(int ipatientID = 0, int BillType = 1, int iSupplierID = 0, int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.Purchase> objList = new Collection<Entity.Billing.Purchase>();
            Entity.Billing.Purchase objPurchase;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASE);
                db.AddInParameter(cmd, "@PK_PurchaseID", DbType.Int32, ipatientID);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, iSupplierID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        

                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objPurchase.Supplier = objSupplier;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objPurchase.Tax = objTax;
                        objPurchase.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objPurchase.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objPurchase.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objPurchase.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objPurchase.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objPurchase.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchase.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objPurchase.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objPurchase.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objPurchase.CourierCharges = Convert.ToDecimal(drData["CourierCharges"]);
                        objPurchase.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchase.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchase.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objPurchase.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objPurchase.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy") + " " + objPurchase.CreatedOn.ToString("h:mm");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");
                        objPurchase.Comments = Convert.ToString(drData["Comments"]);
                        objPurchase.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objPurchase.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objPurchase.ImagePath3 = Convert.ToString(drData["ImagePath3"]);
                        objPurchase.PurchaseTrans = PurchaseTrans.GetPurchaseTransByPurchaseID(objPurchase.PurchaseID);
                        objList.Add(objPurchase);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Billing.Purchase> GetTopPurchase(int ipatientID = 0, int BillType = 1,int CompanyID=0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.Purchase> objList = new Collection<Entity.Billing.Purchase>();
            Entity.Billing.Purchase objPurchase;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_TOPPURCHASE);
                db.AddInParameter(cmd, "@PK_PurchaseID", DbType.Int32, ipatientID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        

                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objSupplier.Days = Convert.ToInt32(drData["Days"]);
                        objPurchase.Supplier = objSupplier;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objPurchase.Tax = objTax;
                       
                        objPurchase.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objPurchase.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                       
                        objPurchase.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objPurchase.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objPurchase.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objPurchase.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objPurchase.CourierCharges = Convert.ToDecimal(drData["CourierCharges"]);
                        objPurchase.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchase.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objPurchase.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        
                        objPurchase.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchase.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchase.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objPurchase.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objPurchase.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objPurchase.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy") + " " + objPurchase.CreatedOn.ToString("h:mm");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");
                        
                        objPurchase.Comments = Convert.ToString(drData["Comments"]);
                        objPurchase.Status = Convert.ToString(drData["Status"]);
                        objPurchase.DocumentPath = Convert.ToString(drData["DocumentPath"]);
                        objPurchase.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objPurchase.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objPurchase.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objList.Add(objPurchase);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Billing.Purchase> GetPurchaseDiscountBillNo(int iSupplierID = 0, int BillType = 1, int PurchaseReturnID = 0, int FK_FinancialYearID = 0,int CompanyID=0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.Purchase> objList = new Collection<Entity.Billing.Purchase>();
            Entity.Billing.Purchase objPurchase;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASE_GETBILLNO_DISCOUNT);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, iSupplierID);
                db.AddInParameter(cmd, "@FK_FinancialYearID", DbType.Int32, FK_FinancialYearID);
                db.AddInParameter(cmd, "@FK_PurchaseReturnID", DbType.Int32, PurchaseReturnID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        

                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy") + " " + objPurchase.CreatedOn.ToString("h:mm");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");

                        objList.Add(objPurchase);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Billing.Purchase> GetPendingPurchaseDiscountBillNo(int iSupplierID = 0, int BillType = 1, int PurchaseReturnID = 0, int FK_FinancialYearID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.Purchase> objList = new Collection<Entity.Billing.Purchase>();
            Entity.Billing.Purchase objPurchase;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASE_PENDINGGETBILLNO_DISCOUNT);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, iSupplierID);
                db.AddInParameter(cmd, "@FK_FinancialYearID", DbType.Int32, FK_FinancialYearID);
                db.AddInParameter(cmd, "@FK_PurchaseReturnID", DbType.Int32, PurchaseReturnID);

                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        

                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy") + " " + objPurchase.CreatedOn.ToString("h:mm");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");

                        objList.Add(objPurchase);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Billing.Purchase> GetTopPurchaseSupplierWise(int iSupplierID = 0, int BillType = 1, int DC = 0, int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.Purchase> objList = new Collection<Entity.Billing.Purchase>();
            Entity.Billing.Purchase objPurchase;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_TOPPURCHASESUPPLIERWISE);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, iSupplierID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objSupplier.Days = Convert.ToInt32(drData["Days"]);
                        objPurchase.Supplier = objSupplier;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objPurchase.Tax = objTax;
                        objPurchase.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objPurchase.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objPurchase.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objPurchase.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objPurchase.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objPurchase.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objPurchase.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchase.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objPurchase.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objPurchase.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchase.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchase.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objPurchase.CourierCharges = Convert.ToDecimal(drData["CourierCharges"]);
                        objPurchase.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objPurchase.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objPurchase.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objPurchase.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy") + " " + objPurchase.CreatedOn.ToString("h:mm");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");
                        objPurchase.Comments = Convert.ToString(drData["Comments"]);
                        objPurchase.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objPurchase.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objPurchase.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objList.Add(objPurchase);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Billing.Purchase> GetTopPurchasePending(int ipatientID = 0, int BillType = 1, int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.Purchase> objList = new Collection<Entity.Billing.Purchase>();
            Entity.Billing.Purchase objPurchase;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_TOPPURCHASEPENDING);
                db.AddInParameter(cmd, "@PK_PurchaseID", DbType.Int32, ipatientID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        
                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objPurchase.Supplier = objSupplier;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objPurchase.Tax = objTax;
                        objPurchase.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objPurchase.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objPurchase.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objPurchase.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objPurchase.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objPurchase.CourierCharges = Convert.ToDecimal(drData["CourierCharges"]);
                        objPurchase.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objPurchase.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchase.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objPurchase.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objPurchase.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchase.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchase.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objPurchase.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objPurchase.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objPurchase.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy") + " " + objPurchase.CreatedOn.ToString("h:mm");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");
                        objPurchase.Comments = Convert.ToString(drData["Comments"]);
                        objPurchase.Status = Convert.ToString(drData["Status"]);
                        objPurchase.DocumentPath = Convert.ToString(drData["DocumentPath"]);
                        objPurchase.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objPurchase.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objPurchase.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objList.Add(objPurchase);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Billing.Purchase> GetPendingPurchase(int ipatientID = 0, int BillType = 1, int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.Purchase> objList = new Collection<Entity.Billing.Purchase>();
            Entity.Billing.Purchase objPurchase;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PENDINGPURCHASE);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, ipatientID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        

                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objPurchase.Supplier = objSupplier;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objPurchase.Tax = objTax;

                        
                       
                        
                        objPurchase.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objPurchase.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objPurchase.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objPurchase.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objPurchase.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objPurchase.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchase.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objPurchase.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objPurchase.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchase.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchase.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objPurchase.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objPurchase.CourierCharges = Convert.ToDecimal(drData["CourierCharges"]);
                        objPurchase.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objPurchase.ReturnAmount = Convert.ToDecimal(drData["ReturnAmount"]);
                        objPurchase.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy") + " " + objPurchase.CreatedOn.ToString("h:mm");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");
                        objPurchase.Comments = Convert.ToString(drData["Comments"]);
                        objPurchase.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objPurchase.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objPurchase.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objList.Add(objPurchase);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Billing.Purchase> GetBillNo(int iSupplierID = 0, int BillType = 1, int PurchaseReturnID = 0,int iCompanyID=0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.Purchase> objList = new Collection<Entity.Billing.Purchase>();
            Entity.Billing.Purchase objPurchase;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASE_GETBILLNO);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, iSupplierID);
                db.AddInParameter(cmd, "@FK_PurchaseReturnID", DbType.Int32, PurchaseReturnID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, iCompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy") + " " + objPurchase.CreatedOn.ToString("h:mm");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");

                        objList.Add(objPurchase);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Billing.Purchase> SearchPurchase(string ID, int BillType = 1, int DC = 0,int CompanyID=0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.Purchase> objList = new Collection<Entity.Billing.Purchase>();
            Entity.Billing.Purchase objPurchase;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASEDYNAMIC);
                db.AddInParameter(cmd, "@PK_PurchaseID", DbType.String, ID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objPurchase.Supplier = objSupplier;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objPurchase.Tax = objTax;
                        objPurchase.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objPurchase.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objPurchase.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objPurchase.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objPurchase.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objPurchase.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchase.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objPurchase.CourierCharges = Convert.ToDecimal(drData["CourierCharges"]);
                        objPurchase.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objPurchase.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objPurchase.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchase.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchase.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objPurchase.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objPurchase.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objPurchase.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy") + " " + objPurchase.CreatedOn.ToString("h:mm");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");
                        objPurchase.Comments = Convert.ToString(drData["Comments"]);
                        objPurchase.Status = Convert.ToString(drData["Status"]);
                        objPurchase.DocumentPath = Convert.ToString(drData["DocumentPath"]);
                        objPurchase.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objPurchase.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objPurchase.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objList.Add(objPurchase);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Billing.Purchase> SearchPurchasePending(string ID, int BillType = 1 ,int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.Purchase> objList = new Collection<Entity.Billing.Purchase>();
            Entity.Billing.Purchase objPurchase;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SEARCH_PURCHASEPENDING);
                db.AddInParameter(cmd, "@PK_PurchaseID", DbType.String, ID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        

                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objPurchase.Supplier = objSupplier;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objPurchase.Tax = objTax;
                        objPurchase.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objPurchase.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objPurchase.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objPurchase.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objPurchase.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objPurchase.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchase.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objPurchase.CourierCharges = Convert.ToDecimal(drData["CourierCharges"]);
                        objPurchase.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objPurchase.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objPurchase.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchase.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchase.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objPurchase.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objPurchase.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objPurchase.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy") + " " + objPurchase.CreatedOn.ToString("h:mm");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");
                        objPurchase.Comments = Convert.ToString(drData["Comments"]);
                        objPurchase.Status = Convert.ToString(drData["Status"]);
                        objPurchase.DocumentPath = Convert.ToString(drData["DocumentPath"]);
                        objPurchase.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objPurchase.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objPurchase.ImagePath3 = Convert.ToString(drData["ImagePath3"]);

                        objList.Add(objPurchase);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Entity.Billing.Purchase GetPurchaseByID(int iPurchaseID, int BillType = 1 , int CompanyID=0)
        {
            string sException = string.Empty;
            Database db;
            Entity.Billing.Purchase objPurchase = new Entity.Billing.Purchase();
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; 

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASE);
                db.AddInParameter(cmd, "@PK_PurchaseID", DbType.Int32, iPurchaseID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchase = new Entity.Billing.Purchase();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        

                        objPurchase.PurchaseID = Convert.ToInt32(drData["PK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchase.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objPurchase.sPurchaseDate = objPurchase.PurchaseDate.ToString("dd/MM/yyyy");
                        objPurchase.sBillDate = objPurchase.BillDate.ToString("dd/MM/yyyy");
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objPurchase.Supplier = objSupplier;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objPurchase.Tax = objTax;
                        objPurchase.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objPurchase.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objPurchase.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objPurchase.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objPurchase.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objPurchase.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchase.DiscountPercent = Convert.ToDecimal(drData["DiscountPercent"]);
                        objPurchase.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objPurchase.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchase.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchase.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objPurchase.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objPurchase.CourierCharges = Convert.ToDecimal(drData["CourierCharges"]);
                        objPurchase.Comments = Convert.ToString(drData["Comments"]);
                        objPurchase.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objPurchase.ImagePath1 = Convert.ToString(drData["ImagePath1"]);
                        objPurchase.ImagePath2 = Convert.ToString(drData["ImagePath2"]);
                        objPurchase.ImagePath3 = Convert.ToString(drData["ImagePath3"]);
                        objPurchase.PurchaseTrans = PurchaseTrans.GetPurchaseTransByPurchaseID(objPurchase.PurchaseID);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchaseByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objPurchase;
        }
        #endregion SelectPurchase

        public static int AddPurchase(Entity.Billing.Purchase objPurchase)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_PURCHASE);
                db.AddOutParameter(cmd, "@PK_PurchaseID", DbType.Int32, objPurchase.PurchaseID);
                db.AddInParameter(cmd, "@PurchaseNo", DbType.String, objPurchase.PurchaseNo);
                db.AddInParameter(cmd, "@PurchaseDate", DbType.String, objPurchase.sPurchaseDate);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, objPurchase.Supplier.SupplierID);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.Int32, objPurchase.Tax.TaxID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objPurchase.Company.CompanyID);
                db.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objPurchase.TaxPercent);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objPurchase.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objPurchase.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objPurchase.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objPurchase.TaxAmount);
                db.AddInParameter(cmd, "@TotalAmount", DbType.Decimal, objPurchase.TotalAmount);
                db.AddInParameter(cmd, "@DiscountPercent", DbType.Decimal, objPurchase.DiscountPercent);
                db.AddInParameter(cmd, "@OtherCharges", DbType.Decimal, objPurchase.OtherCharges);
                db.AddInParameter(cmd, "@CourierCharges", DbType.Decimal, objPurchase.CourierCharges);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objPurchase.DiscountAmount);
                db.AddInParameter(cmd, "@Roundoff", DbType.Decimal, objPurchase.Roundoff);
                db.AddInParameter(cmd, "@NetAmount", DbType.Decimal, objPurchase.NetAmount);
                db.AddInParameter(cmd, "@PaidAmount", DbType.Decimal, objPurchase.PaidAmount);
                db.AddInParameter(cmd, "@BalanceAmount", DbType.Decimal, objPurchase.BalanceAmount);
                db.AddInParameter(cmd, "@BillNo", DbType.String, objPurchase.BillNo);
                db.AddInParameter(cmd, "@BillDate", DbType.String, objPurchase.sBillDate);
                db.AddInParameter(cmd, "@Comments", DbType.String, objPurchase.Comments);
                db.AddInParameter(cmd, "@ImagePath1", DbType.String, objPurchase.ImagePath1);
                db.AddInParameter(cmd, "@ImagePath2", DbType.String, objPurchase.ImagePath2);
                db.AddInParameter(cmd, "@ImagePath3", DbType.String, objPurchase.ImagePath3);
                db.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objPurchase.CreatedBy.UserID);
                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_PurchaseID"));

                foreach (Entity.Billing.PurchaseTrans ObjPurchaseTrans in objPurchase.PurchaseTrans)
                    ObjPurchaseTrans.PurchaseID = iID;

                PurchaseTrans.SavePurchaseTransaction(objPurchase.PurchaseTrans);
            }
            catch (Exception ex)
            {
                sException = "Purchase AddPurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdatePurchase(Entity.Billing.Purchase objPurchase)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_PURCHASE);
                db.AddInParameter(cmd, "@PK_PurchaseID", DbType.Int32, objPurchase.PurchaseID);
                db.AddInParameter(cmd, "@PurchaseNo", DbType.String, objPurchase.PurchaseNo);
                db.AddInParameter(cmd, "@PurchaseDate", DbType.String, objPurchase.sPurchaseDate);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, objPurchase.Supplier.SupplierID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objPurchase.Company.CompanyID);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.Int32, objPurchase.Tax.TaxID);
                db.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objPurchase.TaxPercent);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objPurchase.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objPurchase.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objPurchase.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objPurchase.TaxAmount);
                db.AddInParameter(cmd, "@TotalAmount", DbType.Decimal, objPurchase.TotalAmount);
                db.AddInParameter(cmd, "@DiscountPercent", DbType.Decimal, objPurchase.DiscountPercent);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objPurchase.DiscountAmount);
                db.AddInParameter(cmd, "@Roundoff", DbType.Decimal, objPurchase.Roundoff);
                db.AddInParameter(cmd, "@NetAmount", DbType.Decimal, objPurchase.NetAmount);
                db.AddInParameter(cmd, "@PaidAmount", DbType.Decimal, objPurchase.PaidAmount);
                db.AddInParameter(cmd, "@BalanceAmount", DbType.Decimal, objPurchase.BalanceAmount);
                db.AddInParameter(cmd, "@BillNo", DbType.String, objPurchase.BillNo);
                db.AddInParameter(cmd, "@BillDate", DbType.String, objPurchase.sBillDate);
                db.AddInParameter(cmd, "@OtherCharges", DbType.Decimal, objPurchase.OtherCharges);
                db.AddInParameter(cmd, "@CourierCharges", DbType.Decimal, objPurchase.CourierCharges);
                db.AddInParameter(cmd, "@Comments", DbType.String, objPurchase.Comments);
                db.AddInParameter(cmd, "@ImagePath1", DbType.String, objPurchase.ImagePath1);
                db.AddInParameter(cmd, "@ImagePath2", DbType.String, objPurchase.ImagePath2);
                db.AddInParameter(cmd, "@ImagePath3", DbType.String, objPurchase.ImagePath3);
                db.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objPurchase.ModifiedBy.UserID);
                foreach (Entity.Billing.PurchaseTrans ObjPurchaseTrans in objPurchase.PurchaseTrans)
                    ObjPurchaseTrans.PurchaseID = objPurchase.PurchaseID;

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;

                PurchaseTrans.SavePurchaseTransaction(objPurchase.PurchaseTrans);
            }
            catch (Exception ex)
            {
                sException = "Purchase UpdatePurchase| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }

        public static bool UpdatePurchasePending(Entity.Billing.Purchase objPurchase)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_PURCHASEPENIDNG);
                db.AddInParameter(cmd, "@PK_PurchaseID", DbType.Int32, objPurchase.PurchaseID);
                db.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objPurchase.ModifiedBy.UserID);
                db.AddInParameter(cmd, "@Comments", DbType.String, objPurchase.Comments);

                foreach (Entity.Billing.PurchaseTrans ObjPurchaseTrans in objPurchase.PurchaseTrans)
                    ObjPurchaseTrans.PurchaseID = objPurchase.PurchaseID;

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;

                PurchaseTrans.SavePurchaseTransaction(objPurchase.PurchaseTrans);
            }
            catch (Exception ex)
            {
                sException = "Purchase UpdatePurchase| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeletePurchase(int iPurchaseId, int iUserId)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_PURCHASE);
                db.AddInParameter(cmd, "@PK_PurchaseID", DbType.Int32, iPurchaseId);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "Purchase DeletePurchase | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static Collection<Entity.Billing.PurchaseTransDetails> GetPurchaseNewProductDetails(int iID = 0, string code = "", int iValue = 0, int iSupplierID = 0, int iSalesENtryID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.PurchaseTransDetails> objList = new Collection<Entity.Billing.PurchaseTransDetails>();
            Entity.Billing.PurchaseTransDetails objSalesEntryTrans = new Entity.Billing.PurchaseTransDetails();
            Entity.Master.Product objProduct;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_NEWPURCHASEENTRYTRANSDETAILS);
                db.AddInParameter(cmd, "@ID", DbType.Int32, iID);
                db.AddInParameter(cmd, "@Type", DbType.Int32, iValue);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, iSupplierID);
                db.AddInParameter(cmd, "@FK_SalesEntryID", DbType.Int32, iSalesENtryID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesEntryTrans = new Entity.Billing.PurchaseTransDetails();
                        objProduct = new Entity.Master.Product();

                        objSalesEntryTrans.PurchaseTransID = Convert.ToInt32(drData["PK_PurchaseTransID"]);
                        objSalesEntryTrans.PurchaseID = Convert.ToInt32(drData["FK_PurchaseID"]);
                        objSalesEntryTrans.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objSalesEntryTrans.BillNo = Convert.ToString(drData["BillNo"]);
                        objSalesEntryTrans.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objSalesEntryTrans.sBillDate = objSalesEntryTrans.BillDate.ToString("dd/MM/yyyy");
                        objSalesEntryTrans.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objSalesEntryTrans.PurchaseDate = Convert.ToDateTime(drData["PurchaseDate"]);
                        objSalesEntryTrans.sPurchaseDate = objSalesEntryTrans.PurchaseDate.ToString("dd/MM/yyyy");

                        objSalesEntryTrans.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objSalesEntryTrans.Rate = Convert.ToDecimal(drData["Rate"]);
                        objSalesEntryTrans.SubTotal = Convert.ToDecimal(drData["SubTotal"]);
                        objSalesEntryTrans.DiscountPercentage = Convert.ToDecimal(drData["DiscountPercentage"]);
                        objSalesEntryTrans.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objSalesEntryTrans.Product = objProduct;
                        objSalesEntryTrans.Barcode = Convert.ToString(drData["Barcode"]);
                        objSalesEntryTrans.SerialNo = Convert.ToString(drData["SerialNo"]);
                        objSalesEntryTrans.BatchNo = Convert.ToString(drData["BatchNo"]);
                        objSalesEntryTrans.SellingRate = Convert.ToDecimal(drData["SellingRate"]);
                        objSalesEntryTrans.PurchaseBatchDate = Convert.ToDateTime(drData["PurchaseBatchDate"]);
                        objSalesEntryTrans.sPurchaseBatchDate = objSalesEntryTrans.PurchaseBatchDate.ToString("dd/MM/yyyy");

                        objList.Add(objSalesEntryTrans);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesEntryTrans GetSalesEntryTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Billing.PurchaseTransDetails> GetProductDetailsPurchase(int iID = 0, int iValue = 0, int iSupplierID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.PurchaseTransDetails> objList = new Collection<Entity.Billing.PurchaseTransDetails>();
            Entity.Billing.PurchaseTransDetails objSalesEntryTrans = new Entity.Billing.PurchaseTransDetails();
            Entity.Master.Product objProduct;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASETRANSDETAILS);
                db.AddInParameter(cmd, "@ID", DbType.Int32, iID);
                db.AddInParameter(cmd, "@FK_PurchaseID", DbType.Int32, iValue);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, iSupplierID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesEntryTrans = new Entity.Billing.PurchaseTransDetails();
                        objProduct = new Entity.Master.Product();

                        objSalesEntryTrans.PurchaseTransID = Convert.ToInt32(drData["PK_PurchaseTransID"]);
                        objSalesEntryTrans.PurchaseID = Convert.ToInt32(drData["FK_PurchaseID"]);
                        objSalesEntryTrans.SupplierName = Convert.ToString(drData["SupplierName"]);

                        objSalesEntryTrans.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objSalesEntryTrans.Rate = Convert.ToInt32(drData["Rate"]);
                        objSalesEntryTrans.SubTotal = Convert.ToDecimal(drData["SubTotal"]);
                        objSalesEntryTrans.DiscountPercentage = Convert.ToDecimal(drData["DiscountPercentage"]);
                        objSalesEntryTrans.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objSalesEntryTrans.Product = objProduct;
                        objSalesEntryTrans.Barcode = Convert.ToString(drData["Barcode"]);

                        objSalesEntryTrans.SerialNo = Convert.ToString(drData["SerialNo"]);
                        objSalesEntryTrans.BatchNo = Convert.ToString(drData["BatchNo"]);
                        objSalesEntryTrans.SellingRate = Convert.ToDecimal(drData["SellingRate"]);
                        objSalesEntryTrans.PurchaseBatchDate = Convert.ToDateTime(drData["PurchaseBatchDate"]);
                        objSalesEntryTrans.sPurchaseBatchDate = objSalesEntryTrans.PurchaseBatchDate.ToString("dd/MM/yyyy");
                        objList.Add(objSalesEntryTrans);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesEntryTrans GetSalesEntryTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
    }
    public class PurchaseTrans
    {
        public static Collection<Entity.Billing.PurchaseTrans> GetPurchaseTransByPurchaseID(int iPurchaseID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.PurchaseTrans> objList = new Collection<Entity.Billing.PurchaseTrans>();
            Entity.Billing.PurchaseTrans objPurchaseTrans = new Entity.Billing.PurchaseTrans();
            Entity.Master.Product objProduct;
            Entity.Billing.Tax objTax;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASETRANS);
                db.AddInParameter(cmd, "@FK_PurchaseID", DbType.Int32, iPurchaseID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchaseTrans = new Entity.Billing.PurchaseTrans();
                        objProduct = new Entity.Master.Product();
                        objTax = new Entity.Billing.Tax();

                        objPurchaseTrans.PurchaseTransID = Convert.ToInt32(drData["PK_PurchaseTransID"]);
                        objPurchaseTrans.PurchaseID = Convert.ToInt32(drData["FK_PurchaseID"]);

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxPercentage = Convert.ToDecimal(drData["TaxPercent"]);
                        objTax.SGSTPercent = Convert.ToDecimal(drData["SGSTPercent"]);
                        objTax.IGSTPercent = Convert.ToDecimal(drData["IGSTPercent"]);
                        objTax.CGSTPercent = Convert.ToDecimal(drData["CGSTPercent"]);
                        objPurchaseTrans.Tax = objTax;
                        objPurchaseTrans.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objPurchaseTrans.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objPurchaseTrans.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objPurchaseTrans.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objPurchaseTrans.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objPurchaseTrans.Rate = Convert.ToDecimal(drData["Rate"]);
                        objPurchaseTrans.SubTotal = Convert.ToDecimal(drData["SubTotal"]);
                        objPurchaseTrans.Barcode = Convert.ToString(drData["Barcode"]);
                        objPurchaseTrans.DiscountPercentage = Convert.ToDecimal(drData["DiscountPercentage"]);
                        objPurchaseTrans.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objPurchaseTrans.Product = objProduct;
                        objPurchaseTrans.BatchNo = Convert.ToString(drData["BatchNo"]);
                        objPurchaseTrans.SellingRate = Convert.ToDecimal(drData["SellingRate"]);
                        objPurchaseTrans.PreviousRate = Convert.ToDecimal(drData["PreviousRate"]);
                        objPurchaseTrans.PurchaseBatchDate = Convert.ToDateTime(drData["PurchaseBatchDate"]);
                        objPurchaseTrans.sPurchaseBatchDate = objPurchaseTrans.PurchaseBatchDate.ToString("dd/MM/yyyy");
                        objList.Add(objPurchaseTrans);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "PurchaseTrans GetPurchaseTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Entity.Billing.PurchaseTrans GetPurchaseTransByID(int iPurchaseID = 0)
        {
            string sException = string.Empty;
            Database db;
            Entity.Billing.PurchaseTrans objPurchaseTrans = new Entity.Billing.PurchaseTrans();
            Entity.Master.Product objProduct;
            Entity.Billing.Tax objTax; ;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASETRANS);
                db.AddInParameter(cmd, "@PK_PurchaseTransID", DbType.Int32, iPurchaseID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchaseTrans = new Entity.Billing.PurchaseTrans();
                        objProduct = new Entity.Master.Product();
                        objTax = new Entity.Billing.Tax();

                        objPurchaseTrans.PurchaseTransID = Convert.ToInt32(drData["PK_PurchaseTransID"]);
                        objPurchaseTrans.PurchaseID = Convert.ToInt32(drData["FK_PurchaseID"]);

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxPercentage = Convert.ToDecimal(drData["TaxPercent"]);
                        objTax.SGSTPercent = Convert.ToDecimal(drData["SGSTPercent"]);
                        objTax.IGSTPercent = Convert.ToDecimal(drData["IGSTPercent"]);
                        objTax.CGSTPercent = Convert.ToDecimal(drData["CGSTPercent"]);
                        objPurchaseTrans.Tax = objTax;
                        objPurchaseTrans.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objPurchaseTrans.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objPurchaseTrans.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objPurchaseTrans.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objPurchaseTrans.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objPurchaseTrans.Rate = Convert.ToDecimal(drData["Rate"]);
                        objPurchaseTrans.SubTotal = Convert.ToDecimal(drData["SubTotal"]);
                        objPurchaseTrans.Barcode = Convert.ToString(drData["Barcode"]);
                        objPurchaseTrans.DiscountPercentage = Convert.ToDecimal(drData["DiscountPercentage"]);
                        objPurchaseTrans.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objPurchaseTrans.Product = objProduct;
                        objPurchaseTrans.BatchNo = Convert.ToString(drData["BatchNo"]);
                        objPurchaseTrans.SellingRate = Convert.ToDecimal(drData["SellingRate"]);
                        objPurchaseTrans.PreviousRate = Convert.ToDecimal(drData["PreviousRate"]);
                        objPurchaseTrans.PurchaseBatchDate = Convert.ToDateTime(drData["PurchaseBatchDate"]);
                        objPurchaseTrans.sPurchaseBatchDate = objPurchaseTrans.PurchaseBatchDate.ToString("dd/MM/yyyy");

                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Purchase GetPurchaseByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objPurchaseTrans;
        }
        public static void SavePurchaseTransaction(Collection<Entity.Billing.PurchaseTrans> ObjPurchaseTransList)
        {
            int iID = 0;
            bool bResult = false;

            foreach (Entity.Billing.PurchaseTrans ObjPurchaseTransaction in ObjPurchaseTransList)
            {
                if (ObjPurchaseTransaction.StatusFlag == "I")
                    iID = AddPurchaseTrans(ObjPurchaseTransaction);
                else if (ObjPurchaseTransaction.StatusFlag == "U")
                    bResult = UpdatePurchaseTrans(ObjPurchaseTransaction);
                else if (ObjPurchaseTransaction.StatusFlag == "D")
                    bResult = DeletePurchaseTrans(ObjPurchaseTransaction.PurchaseTransID);
            }
        }
        public static int AddPurchaseTrans(Entity.Billing.PurchaseTrans objPurchaseTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_PURCHASETRANS);
                db.AddOutParameter(cmd, "@PK_PurchaseTransID", DbType.Int32, objPurchaseTrans.PurchaseTransID);
                db.AddInParameter(cmd, "@FK_PurchaseID", DbType.Int32, objPurchaseTrans.PurchaseID);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.String, objPurchaseTrans.Product.ProductID);
                db.AddInParameter(cmd, "@Quantity", DbType.Decimal, objPurchaseTrans.Quantity);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, objPurchaseTrans.Rate);
                db.AddInParameter(cmd, "@DiscountPercentage", DbType.Decimal, objPurchaseTrans.DiscountPercentage);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objPurchaseTrans.DiscountAmount);
                db.AddInParameter(cmd, "@SubTotal", DbType.Decimal, objPurchaseTrans.SubTotal);
                db.AddInParameter(cmd, "@Barcode", DbType.String, objPurchaseTrans.Barcode);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.String, objPurchaseTrans.Tax.TaxID);
                db.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objPurchaseTrans.Tax.TaxPercentage);
                db.AddInParameter(cmd, "@IGSTPercent", DbType.Decimal, objPurchaseTrans.Tax.IGSTPercent);
                db.AddInParameter(cmd, "@SGSTPercent", DbType.Decimal, objPurchaseTrans.Tax.SGSTPercent);
                db.AddInParameter(cmd, "@CGSTPercent", DbType.Decimal, objPurchaseTrans.Tax.CGSTPercent);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objPurchaseTrans.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objPurchaseTrans.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objPurchaseTrans.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objPurchaseTrans.TaxAmount);
                db.AddInParameter(cmd, "@BatchNo", DbType.String, objPurchaseTrans.BatchNo);
                db.AddInParameter(cmd, "@SellingRate", DbType.Decimal, objPurchaseTrans.SellingRate);


                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_PurchaseTransID"));
            }
            catch (Exception ex)
            {
                sException = "PurchaseTrans AddPurchaseTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdatePurchaseTrans(Entity.Billing.PurchaseTrans objPurchaseTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_PURCHASETRANS);
                db.AddInParameter(cmd, "@PK_PurchaseTransID", DbType.Int32, objPurchaseTrans.PurchaseTransID);
                db.AddInParameter(cmd, "@FK_PurchaseID", DbType.Int32, objPurchaseTrans.PurchaseID);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.String, objPurchaseTrans.Product.ProductID);
                db.AddInParameter(cmd, "@Quantity", DbType.Decimal, objPurchaseTrans.Quantity);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, objPurchaseTrans.Rate);
                db.AddInParameter(cmd, "@DiscountPercentage", DbType.Decimal, objPurchaseTrans.DiscountPercentage);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objPurchaseTrans.DiscountAmount);
                db.AddInParameter(cmd, "@SubTotal", DbType.Decimal, objPurchaseTrans.SubTotal);
                db.AddInParameter(cmd, "@Barcode", DbType.String, objPurchaseTrans.Barcode);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.String, objPurchaseTrans.Tax.TaxID);
                db.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objPurchaseTrans.Tax.TaxPercentage);
                db.AddInParameter(cmd, "@IGSTPercent", DbType.Decimal, objPurchaseTrans.Tax.IGSTPercent);
                db.AddInParameter(cmd, "@SGSTPercent", DbType.Decimal, objPurchaseTrans.Tax.SGSTPercent);
                db.AddInParameter(cmd, "@CGSTPercent", DbType.Decimal, objPurchaseTrans.Tax.CGSTPercent);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objPurchaseTrans.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objPurchaseTrans.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objPurchaseTrans.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objPurchaseTrans.TaxAmount);
                db.AddInParameter(cmd, "@BatchNo", DbType.String, objPurchaseTrans.BatchNo);
                db.AddInParameter(cmd, "@SellingRate", DbType.Decimal, objPurchaseTrans.SellingRate);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "PurchaseTrans UpdatePurchaseTrans| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeletePurchaseTrans(int iPurchaseTransID)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_PURCHASETRANS);
                db.AddInParameter(cmd, "@PK_PurchaseTransID", DbType.Int32, iPurchaseTransID);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "PurchaseTrans DeletePurchaseTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    }
}
