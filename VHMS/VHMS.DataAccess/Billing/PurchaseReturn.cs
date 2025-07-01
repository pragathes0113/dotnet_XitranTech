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
    public class PurchaseReturn
    {
        public static Collection<Entity.Billing.PurchaseReturn> GetPurchaseReturn(int ipatientID = 0, int iSupplierID = 0, int BillType=1,int CompanyID=0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.PurchaseReturn> objList = new Collection<Entity.Billing.PurchaseReturn>();
            Entity.Billing.PurchaseReturn objPurchaseReturn;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; Entity.Billing.Purchase objPurchase;

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASERETURN);
                db.AddInParameter(cmd, "@PK_PurchaseReturnID", DbType.Int32, ipatientID);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, iSupplierID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchaseReturn = new Entity.Billing.PurchaseReturn();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        objPurchase = new Entity.Billing.Purchase();
                        objPurchaseReturn.PurchaseReturnID = Convert.ToInt32(drData["PK_PurchaseReturnID"]);
                        objPurchaseReturn.ReturnNo = Convert.ToString(drData["ReturnNo"]);
                        objPurchaseReturn.ReturnDate = Convert.ToDateTime(drData["ReturnDate"]);
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objPurchaseReturn.Supplier = objSupplier;
                        objPurchase.PurchaseID = Convert.ToInt32(drData["FK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchaseReturn.Purchase = objPurchase;
                        objPurchaseReturn.Notes = Convert.ToString(drData["Notes"]);
                        objPurchaseReturn.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchaseReturn.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchaseReturn.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchaseReturn.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objPurchaseReturn.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objPurchaseReturn.sReturnDate = objPurchaseReturn.ReturnDate.ToString("dd/MM/yyyy") + " " + objPurchaseReturn.CreatedOn.ToString("h:mm");

                        objList.Add(objPurchaseReturn);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "PurchaseReturn GetPurchaseReturn | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Billing.PurchaseReturn> SearchPurchaseReturn(string ID, int BillType,int CompanyID=0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.PurchaseReturn> objList = new Collection<Entity.Billing.PurchaseReturn>();
            Entity.Billing.PurchaseReturn objPurchaseReturn;
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; Entity.Billing.Purchase objPurchase;

            try
            {
                db = VHMS.Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASERETURNDYNAMIC);
                db.AddInParameter(cmd, "@PK_PurchaseReturnID", DbType.String, ID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                
                dsList = db.ExecuteDataSet(cmd); 

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchaseReturn = new Entity.Billing.PurchaseReturn();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        objPurchase = new Entity.Billing.Purchase();

                        objPurchaseReturn.PurchaseReturnID = Convert.ToInt32(drData["PK_PurchaseReturnID"]);
                        objPurchaseReturn.ReturnNo = Convert.ToString(drData["ReturnNo"]);
                        objPurchaseReturn.ReturnDate = Convert.ToDateTime(drData["ReturnDate"]);
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objPurchaseReturn.Supplier = objSupplier;
                        objPurchase.PurchaseID = Convert.ToInt32(drData["FK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchase.BillNo = Convert.ToString(drData["BillNo"]);
                        objPurchaseReturn.Purchase = objPurchase;
                        objPurchaseReturn.Notes = Convert.ToString(drData["Notes"]);
                        objPurchaseReturn.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchaseReturn.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchaseReturn.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchaseReturn.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objPurchaseReturn.TotalQty = Convert.ToDecimal(drData["TotalQty"]);
                        objPurchaseReturn.sReturnDate = objPurchaseReturn.ReturnDate.ToString("dd/MM/yyyy") + " " + objPurchaseReturn.CreatedOn.ToString("h:mm");
                        objList.Add(objPurchaseReturn);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "PurchaseReturn GetPurchaseReturn | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Entity.Billing.PurchaseReturn GetPurchaseReturnByID(int iPurchaseReturnID, int BillType, int CompanyID = 0)
        {
            string sException = string.Empty;
            Database db;
            Entity.Billing.PurchaseReturn objPurchaseReturn = new Entity.Billing.PurchaseReturn();
            Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax; Entity.Billing.Purchase objPurchase;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASERETURN);
                db.AddInParameter(cmd, "@PK_PurchaseReturnID", DbType.Int32, iPurchaseReturnID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchaseReturn = new Entity.Billing.PurchaseReturn();
                        objSupplier = new Entity.Billing.Supplier();
                        objTax = new Entity.Billing.Tax();
                        objPurchase = new Entity.Billing.Purchase();

                        objPurchaseReturn.PurchaseReturnID = Convert.ToInt32(drData["PK_PurchaseReturnID"]);
                        objPurchaseReturn.ReturnNo = Convert.ToString(drData["ReturnNo"]);
                        objPurchaseReturn.ReturnDate = Convert.ToDateTime(drData["ReturnDate"]);
                        objPurchaseReturn.sReturnDate = objPurchaseReturn.ReturnDate.ToString("dd/MM/yyyy");

                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objPurchaseReturn.Supplier = objSupplier;
                        objPurchase.PurchaseID = Convert.ToInt32(drData["FK_PurchaseID"]);
                        objPurchase.PurchaseNo = Convert.ToString(drData["PurchaseNo"]);
                        objPurchaseReturn.Purchase = objPurchase;
                        objPurchaseReturn.Notes = Convert.ToString(drData["Notes"]);
                        objPurchaseReturn.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objPurchaseReturn.Roundoff = Convert.ToDecimal(drData["Roundoff"]);
                        objPurchaseReturn.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objPurchaseReturn.PurchaseReturnTrans = PurchaseReturnTrans.GetPurchaseReturnTransByPurchaseReturnID(objPurchaseReturn.PurchaseReturnID);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "PurchaseReturn GetPurchaseReturnByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objPurchaseReturn;
        }
        public static int AddPurchaseReturn(Entity.Billing.PurchaseReturn objPurchaseReturn)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_PURCHASERETURN);
                db.AddOutParameter(cmd, "@PK_PurchaseReturnID", DbType.Int32, objPurchaseReturn.PurchaseReturnID);
                db.AddInParameter(cmd, "@ReturnNo", DbType.String, objPurchaseReturn.ReturnNo);
                db.AddInParameter(cmd, "@ReturnDate", DbType.String, objPurchaseReturn.sReturnDate);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, objPurchaseReturn.Supplier.SupplierID);
                db.AddInParameter(cmd, "@FK_PurchaseID", DbType.Int32, objPurchaseReturn.Purchase.PurchaseID);
                db.AddInParameter(cmd, "@TotalAmount", DbType.Decimal, objPurchaseReturn.TotalAmount);
                db.AddInParameter(cmd, "@Roundoff", DbType.Decimal, objPurchaseReturn.Roundoff);
                db.AddInParameter(cmd, "@NetAmount", DbType.Decimal, objPurchaseReturn.NetAmount);
                db.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objPurchaseReturn.CreatedBy.UserID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objPurchaseReturn.Company.CompanyID);
                db.AddInParameter(cmd, "@Notes", DbType.String, objPurchaseReturn.Notes);
                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_PurchaseReturnID"));

                foreach (Entity.Billing.PurchaseReturnTrans ObjPurchaseReturnTrans in objPurchaseReturn.PurchaseReturnTrans)
                    ObjPurchaseReturnTrans.PurchaseReturnID = iID;

                PurchaseReturnTrans.SavePurchaseReturnTransaction(objPurchaseReturn.PurchaseReturnTrans);
            }
            catch (Exception ex)
            {
                sException = "PurchaseReturn AddPurchaseReturn | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdatePurchaseReturn(Entity.Billing.PurchaseReturn objPurchaseReturn)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_PURCHASERETURN);
                db.AddInParameter(cmd, "@PK_PurchaseReturnID", DbType.Int32, objPurchaseReturn.PurchaseReturnID);
                db.AddInParameter(cmd, "@ReturnNo", DbType.String, objPurchaseReturn.ReturnNo);
                db.AddInParameter(cmd, "@ReturnDate", DbType.String, objPurchaseReturn.sReturnDate);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, objPurchaseReturn.Supplier.SupplierID);
                db.AddInParameter(cmd, "@FK_PurchaseID", DbType.Int32, objPurchaseReturn.Purchase.PurchaseID);
                db.AddInParameter(cmd, "@TotalAmount", DbType.Decimal, objPurchaseReturn.TotalAmount);
                db.AddInParameter(cmd, "@Roundoff", DbType.Decimal, objPurchaseReturn.Roundoff);
                db.AddInParameter(cmd, "@NetAmount", DbType.Decimal, objPurchaseReturn.NetAmount);
                db.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objPurchaseReturn.ModifiedBy.UserID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objPurchaseReturn.Company.CompanyID);
                db.AddInParameter(cmd, "@Notes", DbType.String, objPurchaseReturn.Notes);
                foreach (Entity.Billing.PurchaseReturnTrans ObjPurchaseReturnTrans in objPurchaseReturn.PurchaseReturnTrans)
                    ObjPurchaseReturnTrans.PurchaseReturnID = objPurchaseReturn.PurchaseReturnID;
                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;

                PurchaseReturnTrans.SavePurchaseReturnTransaction(objPurchaseReturn.PurchaseReturnTrans);
            }
            catch (Exception ex)
            {
                sException = "PurchaseReturn UpdatePurchaseReturn| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeletePurchaseReturn(int iPurchaseReturnId, int iUserId)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_PURCHASERETURN);
                db.AddInParameter(cmd, "@PK_PurchaseReturnID", DbType.Int32, iPurchaseReturnId);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "PurchaseReturn DeletePurchaseReturn | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    }

    public class PurchaseReturnTrans
    {
        public static Collection<Entity.Billing.PurchaseReturnTrans> GetPurchaseReturnTransByPurchaseReturnID(int iPurchaseReturnID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.PurchaseReturnTrans> objList = new Collection<Entity.Billing.PurchaseReturnTrans>();
            Entity.Billing.PurchaseReturnTrans objPurchaseReturnTrans = new Entity.Billing.PurchaseReturnTrans();
            Entity.Master.Product objProduct; Entity.Billing.Tax objTax;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASERETURNTRANS);
                db.AddInParameter(cmd, "@FK_PurchaseReturnID", DbType.Int32, iPurchaseReturnID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchaseReturnTrans = new Entity.Billing.PurchaseReturnTrans();
                        objProduct = new Entity.Master.Product();
                        objTax = new Entity.Billing.Tax();

                        objPurchaseReturnTrans.PurchaseReturnTransID = Convert.ToInt32(drData["PK_PurchaseReturnTransID"]);
                        objPurchaseReturnTrans.PurchaseReturnID = Convert.ToInt32(drData["FK_PurchaseReturnID"]);
                        objPurchaseReturnTrans.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objPurchaseReturnTrans.Rate = Convert.ToInt32(drData["Rate"]);
                        objPurchaseReturnTrans.SubTotal = Convert.ToDecimal(drData["SubTotal"]);
                        objPurchaseReturnTrans.Barcode = Convert.ToString(drData["Barcode"]);
                        objPurchaseReturnTrans.Notes = Convert.ToString(drData["Notes"]);
                        objPurchaseReturnTrans.PurchaseTransID = Convert.ToInt32(drData["FK_PurchaseTransID"]);
                        objPurchaseReturnTrans.BatchNo = Convert.ToString(drData["BatchNo"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objPurchaseReturnTrans.Product = objProduct;
                        objList.Add(objPurchaseReturnTrans);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "PurchaseReturnTrans GetPurchaseReturnTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Entity.Billing.PurchaseReturnTrans GetQuantity(int ID, int PurchaseID, int SupplierID,int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            Entity.Billing.Tax objTax; 
            Entity.Billing.PurchaseReturnTrans objPurchaseReturnTrans = new Entity.Billing.PurchaseReturnTrans();
            Entity.Master.Product objProduct; 
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PURCHASERETURNTRANSQUANTITY);
                db.AddInParameter(cmd, "@PK_ProductID", DbType.Int32, ID);
                db.AddInParameter(cmd, "@FK_PurchaseID", DbType.Int32, PurchaseID);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, SupplierID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                DataSet dsList = db.ExecuteDataSet(cmd);
                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objPurchaseReturnTrans = new Entity.Billing.PurchaseReturnTrans();
                        objProduct = new Entity.Master.Product();
                        objTax = new Entity.Billing.Tax();
                        objPurchaseReturnTrans.PurchaseReturnTransID = Convert.ToInt32(drData["PK_PurchaseReturnTransID"]);
                        objPurchaseReturnTrans.PurchaseReturnID = Convert.ToInt32(drData["FK_PurchaseReturnID"]);
                      
                        objPurchaseReturnTrans.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objPurchaseReturnTrans.Rate = Convert.ToInt32(drData["Rate"]);
                        objPurchaseReturnTrans.SubTotal = Convert.ToDecimal(drData["SubTotal"]);
                       
                        objPurchaseReturnTrans.Barcode = Convert.ToString(drData["Barcode"]);
                        objPurchaseReturnTrans.Notes = Convert.ToString(drData["Notes"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objPurchaseReturnTrans.Product = objProduct; 
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "PurchaseReturnTrans GetPurchaseReturnTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objPurchaseReturnTrans;
        }



        public static void SavePurchaseReturnTransaction(Collection<Entity.Billing.PurchaseReturnTrans> ObjPurchaseReturnTransList)
        {
            int iID = 0;
            bool bResult = false;

            foreach (Entity.Billing.PurchaseReturnTrans ObjPurchaseReturnTransaction in ObjPurchaseReturnTransList)
            {
                if (ObjPurchaseReturnTransaction.StatusFlag == "I")
                    iID = AddPurchaseReturnTrans(ObjPurchaseReturnTransaction);
                else if (ObjPurchaseReturnTransaction.StatusFlag == "U")
                    bResult = UpdatePurchaseReturnTrans(ObjPurchaseReturnTransaction);
                else if (ObjPurchaseReturnTransaction.StatusFlag == "D")
                    bResult = DeletePurchaseReturnTrans(ObjPurchaseReturnTransaction.PurchaseReturnTransID);
            }
        }
        public static int AddPurchaseReturnTrans(Entity.Billing.PurchaseReturnTrans objPurchaseReturnTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_PURCHASERETURNTRANS);
                db.AddOutParameter(cmd, "@PK_PurchaseReturnTransID", DbType.Int32, objPurchaseReturnTrans.PurchaseReturnTransID);
                db.AddInParameter(cmd, "@FK_PurchaseReturnID", DbType.Int32, objPurchaseReturnTrans.PurchaseReturnID);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.String, objPurchaseReturnTrans.Product.ProductID);
                db.AddInParameter(cmd, "@Quantity", DbType.Decimal, objPurchaseReturnTrans.Quantity);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, objPurchaseReturnTrans.Rate);
                db.AddInParameter(cmd, "@SubTotal", DbType.Decimal, objPurchaseReturnTrans.SubTotal);
                db.AddInParameter(cmd, "@Barcode", DbType.String, objPurchaseReturnTrans.Barcode);
                db.AddInParameter(cmd, "@Notes", DbType.String, objPurchaseReturnTrans.Notes);

                db.AddInParameter(cmd, "@FK_PurchaseTransID", DbType.Int32, objPurchaseReturnTrans.PurchaseTransID);
                db.AddInParameter(cmd, "@BatchNo", DbType.String, objPurchaseReturnTrans.BatchNo);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_PurchaseReturnTransID"));
            }
            catch (Exception ex)
            {
                sException = "PurchaseReturnTrans AddPurchaseReturnTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdatePurchaseReturnTrans(Entity.Billing.PurchaseReturnTrans objPurchaseReturnTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_PURCHASERETURNTRANS);
                db.AddInParameter(cmd, "@PK_PurchaseReturnTransID", DbType.Int32, objPurchaseReturnTrans.PurchaseReturnTransID);
                db.AddInParameter(cmd, "@FK_PurchaseReturnID", DbType.Int32, objPurchaseReturnTrans.PurchaseReturnID);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.String, objPurchaseReturnTrans.Product.ProductID);
                db.AddInParameter(cmd, "@Quantity", DbType.Decimal, objPurchaseReturnTrans.Quantity);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, objPurchaseReturnTrans.Rate);

                db.AddInParameter(cmd, "@SubTotal", DbType.Decimal, objPurchaseReturnTrans.SubTotal);
                db.AddInParameter(cmd, "@Barcode", DbType.String, objPurchaseReturnTrans.Barcode);

                db.AddInParameter(cmd, "@Notes", DbType.String, objPurchaseReturnTrans.Notes);
             
                db.AddInParameter(cmd, "@FK_PurchaseTransID", DbType.Int32, objPurchaseReturnTrans.PurchaseTransID);
                db.AddInParameter(cmd, "@BatchNo", DbType.String, objPurchaseReturnTrans.BatchNo);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "PurchaseReturnTrans UpdatePurchaseReturnTrans| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeletePurchaseReturnTrans(int iPurchaseReturnTransID)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_PURCHASERETURNTRANS);
                db.AddInParameter(cmd, "@PK_PurchaseReturnTransID", DbType.Int32, iPurchaseReturnTransID);
                iRemoveId = db.ExecuteNonQuery(cmd);
                if (iRemoveId != 0)
                    bResult = true;
            }
            catch (Exception ex)
            {
                sException = "PurchaseReturnTrans DeletePurchaseReturnTrans | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }

    }
}
