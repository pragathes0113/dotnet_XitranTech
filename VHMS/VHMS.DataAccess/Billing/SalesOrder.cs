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
    public class SalesOrder
    {
        public static Collection<Entity.Billing.SalesOrder> GetSalesOrder(int ipatientID = 0 ,string Flag = null,int CompanyID=0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.SalesOrder> objList = new Collection<Entity.Billing.SalesOrder>();
            Entity.Billing.SalesOrder objSalesOrder;
            Entity.Customer objCustomer; Entity.Billing.Tax objTax; Entity.Company objCompany;

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESORDER);
                db.AddInParameter(cmd, "@PK_SalesOrderID", DbType.Int32, ipatientID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesOrder = new Entity.Billing.SalesOrder();
                        objCompany = new Entity.Company();
                        objCustomer = new Entity.Customer();
                        objTax = new Entity.Billing.Tax();
                        objSalesOrder.SalesOrderID = Convert.ToInt32(drData["PK_SalesOrderID"]);
                        objSalesOrder.SalesOrderNo = Convert.ToString(drData["SalesOrderNo"]);
                        objSalesOrder.SalesOrderDate = Convert.ToDateTime(drData["SalesOrderDate"]);
                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objSalesOrder.Customer = objCustomer;

                        objCompany.CompanyID = Convert.ToInt32(drData["FK_CompanyID"]);
                        objCompany.CompanyName = Convert.ToString(drData["CompanyName"]);
                        objSalesOrder.Company = objCompany;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objSalesOrder.Tax = objTax;
                        objSalesOrder.DiscountPercentage = Convert.ToDecimal(drData["DiscountPercentage"]);
                        objSalesOrder.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesOrder.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objSalesOrder.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objSalesOrder.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesOrder.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesOrder.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesOrder.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objSalesOrder.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesOrder.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objSalesOrder.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objSalesOrder.Notes = Convert.ToString(drData["Notes"]);
                        objSalesOrder.sSalesOrderDate = objSalesOrder.SalesOrderDate.ToString("dd/MM/yyyy") + " " + objSalesOrder.CreatedOn.ToString("h:mm");

                        objList.Add(objSalesOrder);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesOrder GetSalesOrder | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }


        public static Collection<Entity.Billing.SalesOrder> GetSalesOrderByCustomer(int iCustomerID = 0, int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.SalesOrder> objList = new Collection<Entity.Billing.SalesOrder>();
            Entity.Billing.SalesOrder objSalesOrder;
            Entity.Customer objCustomer;
            Entity.Billing.Tax objTax;
            Entity.Master.Product objProduct;

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESORDERBYCUSTOMER);
                db.AddInParameter(cmd, "@FK_CustomerID", DbType.Int32, iCustomerID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesOrder = new Entity.Billing.SalesOrder();
                        objCustomer = new Entity.Customer();
                        objProduct = new Entity.Master.Product();
                        objSalesOrder.SalesOrderID = Convert.ToInt32(drData["PK_SalesOrderID"]);
                        objSalesOrder.SalesOrderNo = Convert.ToString(drData["SalesOrderNo"]);
                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objSalesOrder.Customer = objCustomer;
                        //objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        //objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        //objSalesOrder.Product = objProduct;
                        objList.Add(objSalesOrder);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesOrder GetSalesOrder | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Billing.SalesOrder> GetSalesOrderPending(int ipatientID = 0, int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.SalesOrder> objList = new Collection<Entity.Billing.SalesOrder>();
            Entity.Billing.SalesOrder objSalesOrder;
            Entity.Customer objCustomer; Entity.Billing.Tax objTax;

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESORDERPENDING);
                db.AddInParameter(cmd, "@FK_CustomerID", DbType.Int32, ipatientID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesOrder = new Entity.Billing.SalesOrder();
                        objCustomer = new Entity.Customer();
                        objTax = new Entity.Billing.Tax();

                        objSalesOrder.SalesOrderID = Convert.ToInt32(drData["PK_SalesOrderID"]);
                        objSalesOrder.SalesOrderNo = Convert.ToString(drData["SalesOrderNo"]);
                        objSalesOrder.SalesOrderDate = Convert.ToDateTime(drData["SalesOrderDate"]);
                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objSalesOrder.Customer = objCustomer;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objSalesOrder.Tax = objTax;
                        objSalesOrder.DiscountPercentage = Convert.ToDecimal(drData["DiscountPercentage"]);
                        objSalesOrder.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesOrder.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objSalesOrder.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objSalesOrder.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesOrder.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesOrder.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesOrder.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objSalesOrder.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesOrder.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objSalesOrder.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objSalesOrder.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objSalesOrder.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objSalesOrder.Notes = Convert.ToString(drData["Notes"]);
                        objSalesOrder.sSalesOrderDate = objSalesOrder.SalesOrderDate.ToString("dd/MM/yyyy") + " " + objSalesOrder.CreatedOn.ToString("h:mm");

                        objList.Add(objSalesOrder);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesOrder GetSalesOrder | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Billing.SalesOrder> SearchSalesOrder(string ID,string Flag= null, int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.SalesOrder> objList = new Collection<Entity.Billing.SalesOrder>();
            Entity.Billing.SalesOrder objSalesOrder;
            Entity.Customer objCustomer; Entity.Billing.Tax objTax; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESORDERDYNAMIC);
                db.AddInParameter(cmd, "@PK_SalesOrderID", DbType.String, ID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                db.AddInParameter(cmd, "@Flag", DbType.String, Flag);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesOrder = new Entity.Billing.SalesOrder();
                        objCustomer = new Entity.Customer();
                        objTax = new Entity.Billing.Tax();

                        objSalesOrder.SalesOrderID = Convert.ToInt32(drData["PK_SalesOrderID"]);
                        objSalesOrder.SalesOrderNo = Convert.ToString(drData["SalesOrderNo"]);
                        objSalesOrder.SalesOrderDate = Convert.ToDateTime(drData["SalesOrderDate"]);
                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objSalesOrder.Customer = objCustomer;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objSalesOrder.Tax = objTax;
                        objSalesOrder.DiscountPercentage = Convert.ToDecimal(drData["DiscountPercentage"]);
                        objSalesOrder.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesOrder.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objSalesOrder.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objSalesOrder.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesOrder.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesOrder.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesOrder.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objSalesOrder.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesOrder.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objSalesOrder.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objSalesOrder.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objSalesOrder.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objSalesOrder.Notes = Convert.ToString(drData["Notes"]);
                        objSalesOrder.sSalesOrderDate = objSalesOrder.SalesOrderDate.ToString("dd/MM/yyyy") + " " + objSalesOrder.CreatedOn.ToString("h:mm");


                        objList.Add(objSalesOrder);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesOrder GetSalesOrder | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
                
        public static Entity.Billing.SalesOrder GetSalesOrderByID(int iSalesOrderID,string iFlag=null)
        {
            string sException = string.Empty;
            Database db;
            Entity.Billing.SalesOrder objSalesOrder = new Entity.Billing.SalesOrder();
            Entity.Customer objCustomer; Entity.Billing.Tax objTax;
            Entity.Company objCompany;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESORDER);
                db.AddInParameter(cmd, "@PK_SalesOrderID", DbType.Int32, iSalesOrderID);
          //      db.AddInParameter(cmd, "@Flag", DbType.String, iFlag);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesOrder = new Entity.Billing.SalesOrder();
                        objCustomer = new Entity.Customer();
                        objCompany = new Entity.Company();
                        objTax = new Entity.Billing.Tax();

                        objSalesOrder.SalesOrderID = Convert.ToInt32(drData["PK_SalesOrderID"]);
                        objSalesOrder.SalesOrderNo = Convert.ToString(drData["SalesOrderNo"]);
                        objSalesOrder.SalesOrderDate = Convert.ToDateTime(drData["SalesOrderDate"]);
                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objSalesOrder.Customer = objCustomer;

                        objCompany.CompanyID = Convert.ToInt32(drData["FK_CompanyID"]);
                        objCompany.CompanyName = Convert.ToString(drData["CompanyName"]);
                        objSalesOrder.Company = objCompany;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        //objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objSalesOrder.Tax = objTax;
                        objSalesOrder.DiscountPercentage = Convert.ToDecimal(drData["DiscountPercentage"]);
                        objSalesOrder.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesOrder.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objSalesOrder.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objSalesOrder.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesOrder.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesOrder.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesOrder.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objSalesOrder.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesOrder.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objSalesOrder.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                    //    objSalesOrder.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
//objSalesOrder.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objSalesOrder.Notes = Convert.ToString(drData["Notes"]);
                        objSalesOrder.sSalesOrderDate = objSalesOrder.SalesOrderDate.ToString("dd/MM/yyyy") + " " + objSalesOrder.CreatedOn.ToString("h:mm");

                        objSalesOrder.SalesOrderTrans = SalesOrderTrans.GetSalesOrderTransBySalesOrderID(objSalesOrder.SalesOrderID);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesOrder GetSalesOrderByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objSalesOrder;
        }
        public static int AddSalesOrder(Entity.Billing.SalesOrder objSalesOrder)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_SALESORDER);
                db.AddOutParameter(cmd, "@PK_SalesOrderID", DbType.Int32, objSalesOrder.SalesOrderID);
                db.AddInParameter(cmd, "@SalesOrderNo", DbType.String, objSalesOrder.SalesOrderNo);
                db.AddInParameter(cmd, "@SalesOrderDate", DbType.String, objSalesOrder.sSalesOrderDate);
                db.AddInParameter(cmd, "@FK_CustomerID", DbType.Int32, objSalesOrder.Customer.CustomerID);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.Int32, objSalesOrder.Tax.TaxID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objSalesOrder.Company.CompanyID);
                db.AddInParameter(cmd, "@DiscountPercentage", DbType.Decimal, objSalesOrder.DiscountPercentage);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objSalesOrder.DiscountAmount);
                db.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objSalesOrder.TaxPercent);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objSalesOrder.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objSalesOrder.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objSalesOrder.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objSalesOrder.TaxAmount);
                db.AddInParameter(cmd, "@TotalAmount", DbType.Decimal, objSalesOrder.TotalAmount);
                db.AddInParameter(cmd, "@Roundoff", DbType.Decimal, objSalesOrder.Roundoff);
                db.AddInParameter(cmd, "@NetAmount", DbType.Decimal, objSalesOrder.NetAmount);
                db.AddInParameter(cmd, "@Notes", DbType.String, objSalesOrder.Notes);
                db.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objSalesOrder.CreatedBy.UserID);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_SalesOrderID"));

                foreach (Entity.Billing.SalesOrderTrans ObjSalesOrderTrans in objSalesOrder.SalesOrderTrans)
                    ObjSalesOrderTrans.SalesOrderID = iID;

                SalesOrderTrans.SaveSalesOrderTransaction(objSalesOrder.SalesOrderTrans);
            }
            catch (Exception ex)
            {
                sException = "SalesOrder AddSalesOrder | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateSalesOrder(Entity.Billing.SalesOrder objSalesOrder)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_SALESORDER);
                db.AddInParameter(cmd, "@PK_SalesOrderID", DbType.Int32, objSalesOrder.SalesOrderID);
                db.AddInParameter(cmd, "@SalesOrderNo", DbType.String, objSalesOrder.SalesOrderNo);
                db.AddInParameter(cmd, "@SalesOrderDate", DbType.String, objSalesOrder.sSalesOrderDate);
                db.AddInParameter(cmd, "@FK_CustomerID", DbType.Int32, objSalesOrder.Customer.CustomerID);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.Int32, objSalesOrder.Tax.TaxID);
                db.AddInParameter(cmd, "@DiscountPercentage", DbType.Decimal, objSalesOrder.DiscountPercentage);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objSalesOrder.DiscountAmount);
                db.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objSalesOrder.TaxPercent);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objSalesOrder.Company.CompanyID);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objSalesOrder.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objSalesOrder.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objSalesOrder.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objSalesOrder.TaxAmount);
                db.AddInParameter(cmd, "@TotalAmount", DbType.Decimal, objSalesOrder.TotalAmount);
                db.AddInParameter(cmd, "@Roundoff", DbType.Decimal, objSalesOrder.Roundoff);
                db.AddInParameter(cmd, "@NetAmount", DbType.Decimal, objSalesOrder.NetAmount);
                db.AddInParameter(cmd, "@Notes", DbType.String, objSalesOrder.Notes);
                db.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objSalesOrder.ModifiedBy.UserID);

                foreach (Entity.Billing.SalesOrderTrans ObjSalesOrderTrans in objSalesOrder.SalesOrderTrans)
                    ObjSalesOrderTrans.SalesOrderID = objSalesOrder.SalesOrderID;

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;

                SalesOrderTrans.SaveSalesOrderTransaction(objSalesOrder.SalesOrderTrans);
            }
            catch (Exception ex)
            {
                sException = "SalesOrder UpdateSalesOrder| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteSalesOrder(int iSalesOrderId, int iUserId)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_SALESORDER);
                db.AddInParameter(cmd, "@PK_SalesOrderID", DbType.Int32, iSalesOrderId);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "SalesOrder DeleteSalesOrder | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    }

    public class SalesOrderTrans
    {
        public static Collection<Entity.Billing.SalesOrderTrans> GetSalesOrderTransBySalesOrderID(int iSalesOrderID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.SalesOrderTrans> objList = new Collection<Entity.Billing.SalesOrderTrans>();
            Entity.Billing.SalesOrderTrans objSalesOrderTrans = new Entity.Billing.SalesOrderTrans();
            Entity.Master.Product objProduct;
            Entity.Billing.Tax objTax;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SALESORDERTRANS);
                db.AddInParameter(cmd, "@FK_SalesOrderID", DbType.Int32, iSalesOrderID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSalesOrderTrans = new Entity.Billing.SalesOrderTrans();
                        objProduct = new Entity.Master.Product();
                        objTax = new Entity.Billing.Tax();

                        objSalesOrderTrans.SalesOrderTransID = Convert.ToInt32(drData["PK_SalesOrderTransID"]);
                        objSalesOrderTrans.SalesOrderID = Convert.ToInt32(drData["FK_SalesOrderID"]);
                        objSalesOrderTrans.Description = Convert.ToString(drData["Description"]);
                        objSalesOrderTrans.HSNCode = Convert.ToString(drData["HSNCode"]);
                        objSalesOrderTrans.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objSalesOrderTrans.Rate = (Decimal)Convert.ToInt32(drData["Rate"]);
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.SGSTPercent = Convert.ToDecimal(drData["SGSTPercent"]);
                        objTax.IGSTPercent = Convert.ToDecimal(drData["IGSTPercent"]);
                        objTax.CGSTPercent = Convert.ToDecimal(drData["CGSTPercent"]);
                        objSalesOrderTrans.Tax = objTax;

                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objSalesOrderTrans.Product = objProduct;

                        objSalesOrderTrans.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objSalesOrderTrans.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objSalesOrderTrans.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objSalesOrderTrans.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesOrderTrans.DiscountPercentage = Convert.ToDecimal(drData["DiscountPercentage"]);
                        objSalesOrderTrans.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objSalesOrderTrans.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objSalesOrderTrans.SubTotal = Convert.ToDecimal(drData["SubTotal"]);

                        objList.Add(objSalesOrderTrans);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "SalesOrderTrans GetSalesOrderTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static void SaveSalesOrderTransaction(Collection<Entity.Billing.SalesOrderTrans> ObjSalesOrderTransList)
        {
            int iID = 0;
            bool bResult = false;

            foreach (Entity.Billing.SalesOrderTrans ObjSalesOrderTransaction in ObjSalesOrderTransList)
            {
                if (ObjSalesOrderTransaction.StatusFlag == "I")
                    iID = AddSalesOrderTrans(ObjSalesOrderTransaction);
                else if (ObjSalesOrderTransaction.StatusFlag == "U")
                    bResult = UpdateSalesOrderTrans(ObjSalesOrderTransaction);
                else if (ObjSalesOrderTransaction.StatusFlag == "D")
                    bResult = DeleteSalesOrderTrans(ObjSalesOrderTransaction.SalesOrderTransID);
            }
        }
        public static int AddSalesOrderTrans(Entity.Billing.SalesOrderTrans objSalesOrderTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_SALESORDERTRANS);
                db.AddOutParameter(cmd, "@PK_SalesOrderTransID", DbType.Int32, objSalesOrderTrans.SalesOrderTransID);
                db.AddInParameter(cmd, "@FK_SalesOrderID", DbType.Int32, objSalesOrderTrans.SalesOrderID);
                db.AddInParameter(cmd, "@HSNCode", DbType.String, objSalesOrderTrans.HSNCode);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.String, objSalesOrderTrans.Product.ProductID);
                db.AddInParameter(cmd, "@Description", DbType.String, objSalesOrderTrans.Description);
                db.AddInParameter(cmd, "@Quantity", DbType.Decimal, objSalesOrderTrans.Quantity);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, objSalesOrderTrans.Rate);
                db.AddInParameter(cmd, "@DiscountPercentage", DbType.Decimal, objSalesOrderTrans.DiscountPercentage);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objSalesOrderTrans.DiscountAmount);
                db.AddInParameter(cmd, "@SubTotal", DbType.Decimal, objSalesOrderTrans.SubTotal);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.String, objSalesOrderTrans.Tax.TaxID);
                db.AddInParameter(cmd, "@TaxPercentage", DbType.Decimal, objSalesOrderTrans.Tax.TaxPercentage);
                db.AddInParameter(cmd, "@IGSTPercent", DbType.Decimal, objSalesOrderTrans.Tax.IGSTPercent);
                db.AddInParameter(cmd, "@SGSTPercent", DbType.Decimal, objSalesOrderTrans.Tax.SGSTPercent);
                db.AddInParameter(cmd, "@CGSTPercent", DbType.Decimal, objSalesOrderTrans.Tax.CGSTPercent);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objSalesOrderTrans.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objSalesOrderTrans.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objSalesOrderTrans.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objSalesOrderTrans.TaxAmount);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_SalesOrderTransID"));
            }
            catch (Exception ex)
            {
                sException = "SalesOrderTrans AddSalesOrderTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateSalesOrderTrans(Entity.Billing.SalesOrderTrans objSalesOrderTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_SALESORDERTRANS);
                db.AddInParameter(cmd, "@PK_SalesOrderTransID", DbType.Int32, objSalesOrderTrans.SalesOrderTransID);
                db.AddInParameter(cmd, "@FK_SalesOrderID", DbType.Int32, objSalesOrderTrans.SalesOrderID);
                db.AddInParameter(cmd, "@HSNCode", DbType.String, objSalesOrderTrans.HSNCode);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.String, objSalesOrderTrans.Product.ProductID);
                db.AddInParameter(cmd, "@Description", DbType.String, objSalesOrderTrans.Description);
                db.AddInParameter(cmd, "@Quantity", DbType.Decimal, objSalesOrderTrans.Quantity);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, objSalesOrderTrans.Rate);
                db.AddInParameter(cmd, "@DiscountPercentage", DbType.Decimal, objSalesOrderTrans.DiscountPercentage);
                db.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objSalesOrderTrans.DiscountAmount);
                db.AddInParameter(cmd, "@SubTotal", DbType.Decimal, objSalesOrderTrans.SubTotal);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.String, objSalesOrderTrans.Tax.TaxID);
                db.AddInParameter(cmd, "@TaxPercentage", DbType.Decimal, objSalesOrderTrans.Tax.TaxPercentage);
                db.AddInParameter(cmd, "@IGSTPercent", DbType.Decimal, objSalesOrderTrans.Tax.IGSTPercent);
                db.AddInParameter(cmd, "@SGSTPercent", DbType.Decimal, objSalesOrderTrans.Tax.SGSTPercent);
                db.AddInParameter(cmd, "@CGSTPercent", DbType.Decimal, objSalesOrderTrans.Tax.CGSTPercent);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objSalesOrderTrans.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objSalesOrderTrans.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objSalesOrderTrans.IGSTAmount);
                db.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objSalesOrderTrans.TaxAmount);
                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "SalesOrderTrans UpdateSalesOrderTrans| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteSalesOrderTrans(int iSalesOrderTransID)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_SALESORDERTRANS);
                db.AddInParameter(cmd, "@PK_SalesOrderTransID", DbType.Int32, iSalesOrderTransID);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "SalesOrderTrans DeleteSalesOrderTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }

    }
}
