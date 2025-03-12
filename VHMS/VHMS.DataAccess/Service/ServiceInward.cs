using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.ObjectModel;
using VHMS;

namespace VHMS.DataAccess
{
    public class ServiceInward
    {
        #region SelectServiceInward
        public static Collection<Entity.ServiceInward> GetServiceInward(int ipatientID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.ServiceInward> objList = new Collection<Entity.ServiceInward>();
            Entity.ServiceInward objServiceInward;
            Entity.Billing.Supplier objSupplier;            

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SERVICEINWARD);
                db.AddInParameter(cmd, "@PK_ServiceInwardID", DbType.Int32, ipatientID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objServiceInward = new Entity.ServiceInward();
                        objSupplier = new Entity.Billing.Supplier();

                        objServiceInward.ServiceInwardID = Convert.ToInt32(drData["PK_ServiceInwardID"]);
                        objServiceInward.ServiceInwardNo = Convert.ToString(drData["ServiceInwardNo"]);
                        objServiceInward.ServiceInwardDate = Convert.ToDateTime(drData["ServiceInwardDate"]);
                        objServiceInward.sServiceInwardDate = objServiceInward.ServiceInwardDate.ToString("dd/MM/yyyy");

                        objServiceInward.BillNo = Convert.ToString(drData["BillNo"]);
                        objServiceInward.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objServiceInward.sBillDate = objServiceInward.BillDate.ToString("dd/MM/yyyy");

                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objSupplier.PhoneNo1 = Convert.ToString(drData["PhoneNo1"]);
                        objServiceInward.Supplier = objSupplier;
                       
                        objServiceInward.DeliveryAmount = Convert.ToDecimal(drData["DeliveryAmount"]);
                        objServiceInward.PackageAmount = Convert.ToDecimal(drData["PackageAmount"]);
                        objServiceInward.Narration = Convert.ToString(drData["Narration"]);

                        objList.Add(objServiceInward);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "ServiceInward GetServiceInward | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
    
        public static Collection<Entity.ServiceInward> GetTopServiceInward(int ipatientID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.ServiceInward> objList = new Collection<Entity.ServiceInward>();
            Entity.ServiceInward objServiceInward;
            Entity.Billing.Supplier objSupplier;            

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_TOPSERVICEINWARD);
                db.AddInParameter(cmd, "@PK_ServiceInwardID", DbType.Int32, ipatientID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objServiceInward = new Entity.ServiceInward();
                        objSupplier = new Entity.Billing.Supplier();
                        objServiceInward.ServiceInwardID = Convert.ToInt32(drData["PK_ServiceInwardID"]);
                        objServiceInward.ServiceInwardNo = Convert.ToString(drData["ServiceInwardNo"]);
                        objServiceInward.ServiceInwardDate = Convert.ToDateTime(drData["ServiceInwardDate"]);
                        objServiceInward.sServiceInwardDate = objServiceInward.ServiceInwardDate.ToString("dd/MM/yyyy");

                        objServiceInward.BillNo = Convert.ToString(drData["BillNo"]);
                        objServiceInward.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objServiceInward.sBillDate = objServiceInward.BillDate.ToString("dd/MM/yyyy");

                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objSupplier.PhoneNo1 = Convert.ToString(drData["PhoneNo1"]);
                        objServiceInward.Supplier = objSupplier;

                        objServiceInward.DeliveryAmount = Convert.ToDecimal(drData["DeliveryAmount"]);
                        objServiceInward.PackageAmount = Convert.ToDecimal(drData["PackageAmount"]);
                        objServiceInward.Narration = Convert.ToString(drData["Narration"]);

                        objList.Add(objServiceInward);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "ServiceInward GetServiceInward | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
      
        public static Collection<Entity.ServiceInward> SearchServiceInward(string ID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.ServiceInward> objList = new Collection<Entity.ServiceInward>();
            Entity.ServiceInward objServiceInward;
            Entity.Billing.Supplier objSupplier; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SEARCH_SERVICEINWARD);
                db.AddInParameter(cmd, "@PK_ServiceInwardID", DbType.String, ID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objServiceInward = new Entity.ServiceInward();
                        objSupplier = new Entity.Billing.Supplier();
                        objServiceInward.ServiceInwardID = Convert.ToInt32(drData["PK_ServiceInwardID"]);
                        objServiceInward.ServiceInwardNo = Convert.ToString(drData["ServiceInwardNo"]);
                        objServiceInward.ServiceInwardDate = Convert.ToDateTime(drData["ServiceInwardDate"]);
                        objServiceInward.sServiceInwardDate = objServiceInward.ServiceInwardDate.ToString("dd/MM/yyyy");

                        objServiceInward.BillNo = Convert.ToString(drData["BillNo"]);
                        objServiceInward.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objServiceInward.sBillDate = objServiceInward.BillDate.ToString("dd/MM/yyyy");

                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objSupplier.PhoneNo1 = Convert.ToString(drData["PhoneNo1"]);
                        objServiceInward.Supplier = objSupplier;

                        objServiceInward.DeliveryAmount = Convert.ToDecimal(drData["DeliveryAmount"]);
                        objServiceInward.PackageAmount = Convert.ToDecimal(drData["PackageAmount"]);
                        objServiceInward.Narration = Convert.ToString(drData["Narration"]);

                        objList.Add(objServiceInward);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "ServiceInward GetServiceInward | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
     
        public static Entity.ServiceInward GetServiceInwardByID(int iServiceInwardID)
        {
            string sException = string.Empty;
            Database db;
            Entity.ServiceInward objServiceInward = new Entity.ServiceInward();
            Entity.Billing.Supplier objSupplier;
            

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SERVICEINWARD);
                db.AddInParameter(cmd, "@PK_ServiceInwardID", DbType.Int32, iServiceInwardID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objServiceInward = new Entity.ServiceInward();
                        objSupplier = new Entity.Billing.Supplier();
                        objServiceInward.ServiceInwardID = Convert.ToInt32(drData["PK_ServiceInwardID"]);
                        objServiceInward.ServiceInwardNo = Convert.ToString(drData["ServiceInwardNo"]);
                        objServiceInward.ServiceInwardDate = Convert.ToDateTime(drData["ServiceInwardDate"]);
                        objServiceInward.sServiceInwardDate = objServiceInward.ServiceInwardDate.ToString("dd/MM/yyyy");

                        objServiceInward.BillNo = Convert.ToString(drData["BillNo"]);
                        objServiceInward.BillDate = Convert.ToDateTime(drData["BillDate"]);
                        objServiceInward.sBillDate = objServiceInward.BillDate.ToString("dd/MM/yyyy");

                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objSupplier.PhoneNo1 = Convert.ToString(drData["PhoneNo1"]);
                        objServiceInward.Supplier = objSupplier;

                        objServiceInward.DeliveryAmount = Convert.ToDecimal(drData["DeliveryAmount"]);
                        objServiceInward.PackageAmount = Convert.ToDecimal(drData["PackageAmount"]);
                        objServiceInward.Narration = Convert.ToString(drData["Narration"]);

                        objServiceInward.ServiceInwardTrans = ServiceInwardTrans.GetServiceInwardTransByServiceInwardID(objServiceInward.ServiceInwardID);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "ServiceInward GetServiceInwardByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objServiceInward;
        }
        #endregion SelectServiceInward
      
        public static int AddServiceInward(Entity.ServiceInward objServiceInward)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_SERVICEINWARD);
                db.AddOutParameter(cmd, "@PK_ServiceInwardID", DbType.Int32, objServiceInward.ServiceInwardID);
                db.AddInParameter(cmd, "@ServiceInwardNo", DbType.String, objServiceInward.ServiceInwardNo);
                db.AddInParameter(cmd, "@ServiceInwardDate", DbType.String, objServiceInward.sServiceInwardDate);
                db.AddInParameter(cmd, "@BillNo", DbType.String, objServiceInward.BillNo);
                db.AddInParameter(cmd, "@BillDate", DbType.String, objServiceInward.sBillDate);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, objServiceInward.Supplier.SupplierID);
                db.AddInParameter(cmd, "@Narration", DbType.String, objServiceInward.Narration);
                db.AddInParameter(cmd, "@PackageAmount", DbType.Decimal, objServiceInward.PackageAmount);
                db.AddInParameter(cmd, "@DeliveryAmount", DbType.Decimal, objServiceInward.DeliveryAmount);
                db.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objServiceInward.CreatedBy.UserID);
              

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_ServiceInwardID"));

                foreach (Entity.ServiceInwardTrans ObjServiceInwardTrans in objServiceInward.ServiceInwardTrans)
                    ObjServiceInwardTrans.ServiceInwardID = iID;

                ServiceInwardTrans.SaveServiceInwardTransaction(objServiceInward.ServiceInwardTrans);
            }
            catch (Exception ex)
            {
                sException = "ServiceInward AddServiceInward | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateServiceInward(Entity.ServiceInward objServiceInward)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_SERVICEINWARD);
                db.AddInParameter(cmd, "@PK_ServiceInwardID", DbType.Int32, objServiceInward.ServiceInwardID);
                db.AddInParameter(cmd, "@ServiceInwardNo", DbType.String, objServiceInward.ServiceInwardNo);
                db.AddInParameter(cmd, "@ServiceInwardDate", DbType.String, objServiceInward.sServiceInwardDate);
                db.AddInParameter(cmd, "@BillNo", DbType.String, objServiceInward.BillNo);
                db.AddInParameter(cmd, "@BillDate", DbType.String, objServiceInward.sBillDate);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, objServiceInward.Supplier.SupplierID);
                db.AddInParameter(cmd, "@Narration", DbType.String, objServiceInward.Narration);
                db.AddInParameter(cmd, "@PackageAmount", DbType.Decimal, objServiceInward.PackageAmount);
                db.AddInParameter(cmd, "@DeliveryAmount", DbType.Decimal, objServiceInward.DeliveryAmount);
                db.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objServiceInward.ModifiedBy.UserID);               

                foreach (Entity.ServiceInwardTrans ObjServiceInwardTrans in objServiceInward.ServiceInwardTrans)
                    ObjServiceInwardTrans.ServiceInwardID = objServiceInward.ServiceInwardID;

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;

                ServiceInwardTrans.SaveServiceInwardTransaction(objServiceInward.ServiceInwardTrans);
            }
            catch (Exception ex)
            {
                sException = "ServiceInward UpdateServiceInward| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteServiceInward(int iServiceInwardId, int iUserId)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_SERVICEINWARD);
                db.AddInParameter(cmd, "@PK_ServiceInwardID", DbType.Int32, iServiceInwardId);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "ServiceInward DeleteServiceInward | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        
    }
    public class ServiceInwardTrans
    {
        public static Collection<Entity.ServiceInwardTrans> GetServiceInwardTransByServiceInwardID(int iServiceInwardID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.ServiceInwardTrans> objList = new Collection<Entity.ServiceInwardTrans>();
            Entity.ServiceInwardTrans objServiceInwardTrans = new Entity.ServiceInwardTrans();
            Entity.Master.Product objProduct; Entity.Service objService; Entity.Customer objCustomer;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SERVICEINWARDTRANS);
                db.AddInParameter(cmd, "@FK_ServiceInwardID", DbType.Int32, iServiceInwardID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objServiceInwardTrans = new Entity.ServiceInwardTrans();
                        objProduct = new Entity.Master.Product();
                        objService = new Entity.Service();
                        objCustomer = new Entity.Customer();

                        objServiceInwardTrans.ServiceInwardTransID = Convert.ToInt32(drData["PK_ServiceInwardTransID"]);
                        objServiceInwardTrans.ServiceInwardID = Convert.ToInt32(drData["FK_ServiceInwardID"]);

                        objService.ServiceID = Convert.ToInt32(drData["FK_ServiceID"]);
                        objService.ServiceNo = Convert.ToString(drData["ServiceNo"]);
                        objService.ServiceDate = Convert.ToDateTime(drData["ServiceDate"]);
                        objService.sServiceDate = objService.ServiceDate.ToString("dd/MM/yyyy");
                        objServiceInwardTrans.Service = objService;

                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objServiceInwardTrans.Product = objProduct;

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objServiceInwardTrans.Customer = objCustomer;

                        objServiceInwardTrans.SerialNo = Convert.ToString(drData["SerialNo"]);
                        objServiceInwardTrans.ServiceDescription = Convert.ToString(drData["ServiceDescription"]);
                        objServiceInwardTrans.ServiceType = Convert.ToString(drData["ServiceType"]);
                        objServiceInwardTrans.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objServiceInwardTrans.ServiceCharges = Convert.ToDecimal(drData["ServiceCharges"]);
                        objServiceInwardTrans.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objServiceInwardTrans.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objServiceInwardTrans.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objServiceInwardTrans.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objServiceInwardTrans.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objServiceInwardTrans.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                       
                        objList.Add(objServiceInwardTrans);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "ServiceInwardTrans GetServiceInwardTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static void SaveServiceInwardTransaction(Collection<Entity.ServiceInwardTrans> ObjServiceInwardTransList)
        {
            int iID = 0;
            bool bResult = false;

            foreach (Entity.ServiceInwardTrans ObjServiceInwardTransaction in ObjServiceInwardTransList)
            {
                if (ObjServiceInwardTransaction.StatusFlag == "I")
                    iID = AddServiceInwardTrans(ObjServiceInwardTransaction);
                else if (ObjServiceInwardTransaction.StatusFlag == "U")
                    bResult = UpdateServiceInwardTrans(ObjServiceInwardTransaction);
                else if (ObjServiceInwardTransaction.StatusFlag == "D")
                    bResult = DeleteServiceInwardTrans(ObjServiceInwardTransaction.ServiceInwardTransID);
            }
        }
        public static int AddServiceInwardTrans(Entity.ServiceInwardTrans objServiceInwardTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_SERVICEINWARDTRANS);
                db.AddOutParameter(cmd, "@PK_ServiceInwardTransID", DbType.Int32, objServiceInwardTrans.ServiceInwardTransID);
                db.AddInParameter(cmd, "@FK_ServiceInwardID", DbType.Int32, objServiceInwardTrans.ServiceInwardID);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.String, objServiceInwardTrans.Product.ProductID);
                db.AddInParameter(cmd, "@FK_ServiceID", DbType.Decimal, objServiceInwardTrans.Service.ServiceID);
                db.AddInParameter(cmd, "@FK_CustomerID", DbType.Decimal, objServiceInwardTrans.Customer.CustomerID);
                db.AddInParameter(cmd, "@SerialNo", DbType.String, objServiceInwardTrans.SerialNo);
                db.AddInParameter(cmd, "@ServiceDescription", DbType.String, objServiceInwardTrans.ServiceDescription);
                db.AddInParameter(cmd, "@ServiceType", DbType.String, objServiceInwardTrans.ServiceType);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.String, objServiceInwardTrans.TaxID);
                db.AddInParameter(cmd, "@TaxPercent", DbType.String, objServiceInwardTrans.TaxPercent);
                db.AddInParameter(cmd, "@TaxAmount", DbType.String, objServiceInwardTrans.TaxAmount);
                db.AddInParameter(cmd, "@ServiceCharges", DbType.String, objServiceInwardTrans.ServiceCharges);
                db.AddInParameter(cmd, "@TotalAmount", DbType.String, objServiceInwardTrans.TotalAmount);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.String, objServiceInwardTrans.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.String, objServiceInwardTrans.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.String, objServiceInwardTrans.IGSTAmount);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_ServiceInwardTransID"));
            }
            catch (Exception ex)
            {
                sException = "ServiceInwardTrans AddServiceInwardTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateServiceInwardTrans(Entity.ServiceInwardTrans objServiceInwardTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_SERVICEINWARDTRANS);
                db.AddInParameter(cmd, "@PK_ServiceInwardTransID", DbType.Int32, objServiceInwardTrans.ServiceInwardTransID);
                db.AddInParameter(cmd, "@FK_ServiceInwardID", DbType.Int32, objServiceInwardTrans.ServiceInwardID);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.String, objServiceInwardTrans.Product.ProductID);
                db.AddInParameter(cmd, "@FK_ServiceID", DbType.Decimal, objServiceInwardTrans.Service.ServiceID);
                db.AddInParameter(cmd, "@FK_CustomerID", DbType.Decimal, objServiceInwardTrans.Customer.CustomerID);
                db.AddInParameter(cmd, "@SerialNo", DbType.String, objServiceInwardTrans.SerialNo);
                db.AddInParameter(cmd, "@ServiceDescription", DbType.String, objServiceInwardTrans.ServiceDescription);
                db.AddInParameter(cmd, "@ServiceType", DbType.String, objServiceInwardTrans.ServiceType);
                db.AddInParameter(cmd, "@FK_TaxID", DbType.String, objServiceInwardTrans.TaxID);
                db.AddInParameter(cmd, "@TaxPercent", DbType.String, objServiceInwardTrans.TaxPercent);
                db.AddInParameter(cmd, "@TaxAmount", DbType.String, objServiceInwardTrans.TaxAmount);
                db.AddInParameter(cmd, "@ServiceCharges", DbType.String, objServiceInwardTrans.ServiceCharges);
                db.AddInParameter(cmd, "@TotalAmount", DbType.String, objServiceInwardTrans.TotalAmount);
                db.AddInParameter(cmd, "@CGSTAmount", DbType.String, objServiceInwardTrans.CGSTAmount);
                db.AddInParameter(cmd, "@SGSTAmount", DbType.String, objServiceInwardTrans.SGSTAmount);
                db.AddInParameter(cmd, "@IGSTAmount", DbType.String, objServiceInwardTrans.IGSTAmount);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "ServiceInwardTrans UpdateServiceInwardTrans| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteServiceInwardTrans(int iServiceInwardTransID)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_SERVICEINWARDTRANS);
                db.AddInParameter(cmd, "@PK_ServiceInwardTransID", DbType.Int32, iServiceInwardTransID);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "ServiceInwardTrans DeleteServiceInwardTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    }
}
