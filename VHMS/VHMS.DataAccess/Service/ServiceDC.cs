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
    public class ServiceDC
    {
        #region SelectServiceDC
        public static Collection<Entity.ServiceDC> GetServiceDC(int ipatientID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.ServiceDC> objList = new Collection<Entity.ServiceDC>();
            Entity.ServiceDC objServiceDC;
            Entity.Billing.Supplier objSupplier;            

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SERVICEDC);
                db.AddInParameter(cmd, "@PK_ServiceDCID", DbType.Int32, ipatientID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objServiceDC = new Entity.ServiceDC();
                        objSupplier = new Entity.Billing.Supplier();

                        objServiceDC.ServiceDCID = Convert.ToInt32(drData["PK_ServiceDCID"]);
                        objServiceDC.ServiceDCNo = Convert.ToString(drData["ServiceDCNo"]);
                        objServiceDC.ServiceDCDate = Convert.ToDateTime(drData["ServiceDCDate"]);
                        objServiceDC.sServiceDCDate = objServiceDC.ServiceDCDate.ToString("dd/MM/yyyy");
                                               
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objSupplier.PhoneNo1 = Convert.ToString(drData["PhoneNo1"]);
                        objServiceDC.Supplier = objSupplier;
                       
                        objServiceDC.DeliveryAmount = Convert.ToDecimal(drData["DeliveryAmount"]);
                        objServiceDC.PackageAmount = Convert.ToDecimal(drData["PackageAmount"]);
                        objServiceDC.Narration = Convert.ToString(drData["Narration"]);
                        objServiceDC.ContactNumber = Convert.ToString(drData["ContactNumber"]);
                        objServiceDC.TransportName = Convert.ToString(drData["TransportName"]);
                        objServiceDC.VehicleNo = Convert.ToString(drData["VehicleNo"]);

                        objList.Add(objServiceDC);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "ServiceDC GetServiceDC | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
    
        public static Collection<Entity.ServiceDC> GetTopServiceDC(int ipatientID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.ServiceDC> objList = new Collection<Entity.ServiceDC>();
            Entity.ServiceDC objServiceDC;
            Entity.Billing.Supplier objSupplier;            

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_TOPSERVICEDC);
                db.AddInParameter(cmd, "@PK_ServiceDCID", DbType.Int32, ipatientID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objServiceDC = new Entity.ServiceDC();
                        objSupplier = new Entity.Billing.Supplier();
                        objServiceDC.ServiceDCID = Convert.ToInt32(drData["PK_ServiceDCID"]);
                        objServiceDC.ServiceDCNo = Convert.ToString(drData["ServiceDCNo"]);
                        objServiceDC.ServiceDCDate = Convert.ToDateTime(drData["ServiceDCDate"]);
                        objServiceDC.sServiceDCDate = objServiceDC.ServiceDCDate.ToString("dd/MM/yyyy");

                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objSupplier.PhoneNo1 = Convert.ToString(drData["PhoneNo1"]);
                        objServiceDC.Supplier = objSupplier;

                        objServiceDC.DeliveryAmount = Convert.ToDecimal(drData["DeliveryAmount"]);
                        objServiceDC.PackageAmount = Convert.ToDecimal(drData["PackageAmount"]);
                        objServiceDC.Narration = Convert.ToString(drData["Narration"]);
                        objServiceDC.ContactNumber = Convert.ToString(drData["ContactNumber"]);
                        objServiceDC.TransportName = Convert.ToString(drData["TransportName"]);
                        objServiceDC.VehicleNo = Convert.ToString(drData["VehicleNo"]);

                        objList.Add(objServiceDC);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "ServiceDC GetServiceDC | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
      
        public static Collection<Entity.ServiceDC> SearchServiceDC(string ID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.ServiceDC> objList = new Collection<Entity.ServiceDC>();
            Entity.ServiceDC objServiceDC;
            Entity.Billing.Supplier objSupplier; 

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SEARCH_SERVICEDC);
                db.AddInParameter(cmd, "@PK_ServiceDCID", DbType.String, ID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objServiceDC = new Entity.ServiceDC();
                        objSupplier = new Entity.Billing.Supplier();
                        objServiceDC.ServiceDCID = Convert.ToInt32(drData["PK_ServiceDCID"]);
                        objServiceDC.ServiceDCNo = Convert.ToString(drData["ServiceDCNo"]);
                        objServiceDC.ServiceDCDate = Convert.ToDateTime(drData["ServiceDCDate"]);
                        objServiceDC.sServiceDCDate = objServiceDC.ServiceDCDate.ToString("dd/MM/yyyy");

                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objSupplier.PhoneNo1 = Convert.ToString(drData["PhoneNo1"]);
                        objServiceDC.Supplier = objSupplier;

                        objServiceDC.DeliveryAmount = Convert.ToDecimal(drData["DeliveryAmount"]);
                        objServiceDC.PackageAmount = Convert.ToDecimal(drData["PackageAmount"]);
                        objServiceDC.Narration = Convert.ToString(drData["Narration"]);
                        objServiceDC.ContactNumber = Convert.ToString(drData["ContactNumber"]);
                        objServiceDC.TransportName = Convert.ToString(drData["TransportName"]);
                        objServiceDC.VehicleNo = Convert.ToString(drData["VehicleNo"]);

                        objList.Add(objServiceDC);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "ServiceDC GetServiceDC | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
     
        public static Entity.ServiceDC GetServiceDCByID(int iServiceDCID)
        {
            string sException = string.Empty;
            Database db;
            Entity.ServiceDC objServiceDC = new Entity.ServiceDC();
            Entity.Billing.Supplier objSupplier;
            

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SERVICEDC);
                db.AddInParameter(cmd, "@PK_ServiceDCID", DbType.Int32, iServiceDCID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objServiceDC = new Entity.ServiceDC();
                        objSupplier = new Entity.Billing.Supplier();
                        objServiceDC.ServiceDCID = Convert.ToInt32(drData["PK_ServiceDCID"]);
                        objServiceDC.ServiceDCNo = Convert.ToString(drData["ServiceDCNo"]);
                        objServiceDC.ServiceDCDate = Convert.ToDateTime(drData["ServiceDCDate"]);
                        objServiceDC.sServiceDCDate = objServiceDC.ServiceDCDate.ToString("dd/MM/yyyy");

                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objSupplier.PhoneNo1 = Convert.ToString(drData["PhoneNo1"]);
                        objServiceDC.Supplier = objSupplier;

                        objServiceDC.DeliveryAmount = Convert.ToDecimal(drData["DeliveryAmount"]);
                        objServiceDC.PackageAmount = Convert.ToDecimal(drData["PackageAmount"]);
                        objServiceDC.Narration = Convert.ToString(drData["Narration"]);
                        objServiceDC.ContactNumber = Convert.ToString(drData["ContactNumber"]);
                        objServiceDC.TransportName = Convert.ToString(drData["TransportName"]);
                        objServiceDC.VehicleNo = Convert.ToString(drData["VehicleNo"]);

                        objServiceDC.ServiceDCTrans = ServiceDCTrans.GetServiceDCTransByServiceDCID(objServiceDC.ServiceDCID);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "ServiceDC GetServiceDCByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objServiceDC;
        }
        #endregion SelectServiceDC
      
        public static int AddServiceDC(Entity.ServiceDC objServiceDC)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_SERVICEDC);
                db.AddOutParameter(cmd, "@PK_ServiceDCID", DbType.Int32, objServiceDC.ServiceDCID);
                db.AddInParameter(cmd, "@ServiceDCNo", DbType.String, objServiceDC.ServiceDCNo);
                db.AddInParameter(cmd, "@ServiceDCDate", DbType.String, objServiceDC.sServiceDCDate);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, objServiceDC.Supplier.SupplierID);
                db.AddInParameter(cmd, "@TransportName", DbType.String, objServiceDC.TransportName);
                db.AddInParameter(cmd, "@VehicleNo", DbType.String, objServiceDC.VehicleNo);
                db.AddInParameter(cmd, "@ContactNumber", DbType.String, objServiceDC.ContactNumber);
                db.AddInParameter(cmd, "@Narration", DbType.String, objServiceDC.Narration);
                db.AddInParameter(cmd, "@PackageAmount", DbType.Decimal, objServiceDC.PackageAmount);
                db.AddInParameter(cmd, "@DeliveryAmount", DbType.Decimal, objServiceDC.DeliveryAmount);
                db.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objServiceDC.CreatedBy.UserID);
              

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_ServiceDCID"));

                foreach (Entity.ServiceDCTrans ObjServiceDCTrans in objServiceDC.ServiceDCTrans)
                    ObjServiceDCTrans.ServiceDCID = iID;

                ServiceDCTrans.SaveServiceDCTransaction(objServiceDC.ServiceDCTrans);
            }
            catch (Exception ex)
            {
                sException = "ServiceDC AddServiceDC | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateServiceDC(Entity.ServiceDC objServiceDC)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_SERVICEDC);
                db.AddInParameter(cmd, "@PK_ServiceDCID", DbType.Int32, objServiceDC.ServiceDCID);
                db.AddInParameter(cmd, "@ServiceDCNo", DbType.String, objServiceDC.ServiceDCNo);
                db.AddInParameter(cmd, "@ServiceDCDate", DbType.String, objServiceDC.sServiceDCDate);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, objServiceDC.Supplier.SupplierID);
                db.AddInParameter(cmd, "@TransportName", DbType.String, objServiceDC.TransportName);
                db.AddInParameter(cmd, "@VehicleNo", DbType.String, objServiceDC.VehicleNo);
                db.AddInParameter(cmd, "@ContactNumber", DbType.String, objServiceDC.ContactNumber);
                db.AddInParameter(cmd, "@Narration", DbType.String, objServiceDC.Narration);
                db.AddInParameter(cmd, "@PackageAmount", DbType.Decimal, objServiceDC.PackageAmount);
                db.AddInParameter(cmd, "@DeliveryAmount", DbType.Decimal, objServiceDC.DeliveryAmount);
                db.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objServiceDC.ModifiedBy.UserID);               

                foreach (Entity.ServiceDCTrans ObjServiceDCTrans in objServiceDC.ServiceDCTrans)
                    ObjServiceDCTrans.ServiceDCID = objServiceDC.ServiceDCID;

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;

                ServiceDCTrans.SaveServiceDCTransaction(objServiceDC.ServiceDCTrans);
            }
            catch (Exception ex)
            {
                sException = "ServiceDC UpdateServiceDC| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteServiceDC(int iServiceDCId, int iUserId)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_SERVICEDC);
                db.AddInParameter(cmd, "@PK_ServiceDCID", DbType.Int32, iServiceDCId);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "ServiceDC DeleteServiceDC | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        
    }
    public class ServiceDCTrans
    {
        public static Collection<Entity.ServiceDCTrans> GetServiceDCTransByServiceDCID(int iServiceDCID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.ServiceDCTrans> objList = new Collection<Entity.ServiceDCTrans>();
            Entity.ServiceDCTrans objServiceDCTrans = new Entity.ServiceDCTrans();
            Entity.Master.Product objProduct; Entity.Service objService; Entity.Customer objCustomer;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SERVICEDCTRANS);
                db.AddInParameter(cmd, "@FK_ServiceDCID", DbType.Int32, iServiceDCID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objServiceDCTrans = new Entity.ServiceDCTrans();
                        objProduct = new Entity.Master.Product();
                        objService = new Entity.Service();
                        objCustomer = new Entity.Customer();

                        objServiceDCTrans.ServiceDCTransID = Convert.ToInt32(drData["PK_ServiceDCTransID"]);
                        objServiceDCTrans.ServiceDCID = Convert.ToInt32(drData["FK_ServiceDCID"]);

                        objService.ServiceID = Convert.ToInt32(drData["FK_ServiceID"]);
                        objService.ServiceNo = Convert.ToString(drData["ServiceNo"]);
                        objService.ServiceDate = Convert.ToDateTime(drData["ServiceDate"]);
                        objService.sServiceDate = objService.ServiceDate.ToString("dd/MM/yyyy");
                        objServiceDCTrans.Service = objService;

                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objServiceDCTrans.Product = objProduct;

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objServiceDCTrans.Customer = objCustomer;

                        objServiceDCTrans.SerialNo = Convert.ToString(drData["SerialNo"]);
                        objServiceDCTrans.Description = Convert.ToString(drData["Description"]);
                       
                        objList.Add(objServiceDCTrans);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "ServiceDCTrans GetServiceDCTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static void SaveServiceDCTransaction(Collection<Entity.ServiceDCTrans> ObjServiceDCTransList)
        {
            int iID = 0;
            bool bResult = false;

            foreach (Entity.ServiceDCTrans ObjServiceDCTransaction in ObjServiceDCTransList)
            {
                if (ObjServiceDCTransaction.StatusFlag == "I")
                    iID = AddServiceDCTrans(ObjServiceDCTransaction);
                else if (ObjServiceDCTransaction.StatusFlag == "U")
                    bResult = UpdateServiceDCTrans(ObjServiceDCTransaction);
                else if (ObjServiceDCTransaction.StatusFlag == "D")
                    bResult = DeleteServiceDCTrans(ObjServiceDCTransaction.ServiceDCTransID);
            }
        }
        public static int AddServiceDCTrans(Entity.ServiceDCTrans objServiceDCTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_SERVICEDCTRANS);
                db.AddOutParameter(cmd, "@PK_ServiceDCTransID", DbType.Int32, objServiceDCTrans.ServiceDCTransID);
                db.AddInParameter(cmd, "@FK_ServiceDCID", DbType.Int32, objServiceDCTrans.ServiceDCID);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.String, objServiceDCTrans.Product.ProductID);
                db.AddInParameter(cmd, "@FK_ServiceID", DbType.Decimal, objServiceDCTrans.Service.ServiceID);
                db.AddInParameter(cmd, "@FK_CustomerID", DbType.Decimal, objServiceDCTrans.Customer.CustomerID);
                db.AddInParameter(cmd, "@SerialNo", DbType.String, objServiceDCTrans.SerialNo);
                db.AddInParameter(cmd, "@Description", DbType.String, objServiceDCTrans.Description);                

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_ServiceDCTransID"));
            }
            catch (Exception ex)
            {
                sException = "ServiceDCTrans AddServiceDCTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateServiceDCTrans(Entity.ServiceDCTrans objServiceDCTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_SERVICEDCTRANS);
                db.AddInParameter(cmd, "@PK_ServiceDCTransID", DbType.Int32, objServiceDCTrans.ServiceDCTransID);
                db.AddInParameter(cmd, "@FK_ServiceDCID", DbType.Int32, objServiceDCTrans.ServiceDCID);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.String, objServiceDCTrans.Product.ProductID);
                db.AddInParameter(cmd, "@FK_ServiceID", DbType.Decimal, objServiceDCTrans.Service.ServiceID);
                db.AddInParameter(cmd, "@FK_CustomerID", DbType.Decimal, objServiceDCTrans.Customer.CustomerID);
                db.AddInParameter(cmd, "@SerialNo", DbType.String, objServiceDCTrans.SerialNo);
                db.AddInParameter(cmd, "@Description", DbType.String, objServiceDCTrans.Description);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "ServiceDCTrans UpdateServiceDCTrans| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteServiceDCTrans(int iServiceDCTransID)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_SERVICEDCTRANS);
                db.AddInParameter(cmd, "@PK_ServiceDCTransID", DbType.Int32, iServiceDCTransID);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "ServiceDCTrans DeleteServiceDCTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    }
}
