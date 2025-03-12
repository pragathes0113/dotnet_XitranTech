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
    public class Stock
    {
        public static Collection<Entity.Stock> GetStock()
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Stock> objList = new Collection<Entity.Stock>();
            Entity.Stock objStock = new Entity.Stock();
            Entity.Master.Product objProduct;
            Entity.Billing.Category objCategory;
            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_STOCKBYBATCHNO);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objStock = new Entity.Stock();
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();

                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();
                        objStock.StockID = Convert.ToInt32(drData["PK_StockID"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objStock.Product = objProduct;
                        objStock.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objList.Add(objStock);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock GetStock | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Stock> GetStockByBatchNo(int ID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Stock> objList = new Collection<Entity.Stock>();
            Entity.Stock objStock = new Entity.Stock();
            Entity.Master.Product objProduct;
            Entity.Billing.Category objCategory;

            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_STOCKBYBATCHNO);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.Int32, ID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objStock = new Entity.Stock();
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();
                        objStock.StockID = Convert.ToInt32(drData["PK_StockID"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objStock.Product = objProduct;
                        objStock.Quantity = Convert.ToDecimal(drData["Quantity"]);
                  
                        objStock.PurchaseBatchDate = Convert.ToDateTime(drData["PurchaseBatchDate"]);
                        objStock.sPurchaseBatchDate = objStock.PurchaseBatchDate.ToString("dd/MM/yyyy");
                        objStock.PurchaseRate = Convert.ToDecimal(drData["PurchaseRate"]);
                        objStock.SellingPrice = Convert.ToDecimal(drData["SellingRate"]);
                        objList.Add(objStock);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock GetStock | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Stock> GetStockAvailableQtyByBatchNo(int ID = 0, string iTypeName = "", int iOtherID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Stock> objList = new Collection<Entity.Stock>();
            Entity.Stock objStock = new Entity.Stock();
            Entity.Master.Product objProduct;
            Entity.Billing.Category objCategory;

            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_STOCKAVAILABLEBYBATCHNO);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.Int32, ID);
                db.AddInParameter(cmd, "@Type", DbType.String, iTypeName);
                db.AddInParameter(cmd, "@OtherID", DbType.Int32, iOtherID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objStock = new Entity.Stock();
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objStock.StockID = Convert.ToInt32(drData["PK_StockID"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objStock.Product = objProduct;
                        objStock.PurchaseBatchDate = Convert.ToDateTime(drData["PurchaseBatchDate"]);
                        objStock.sPurchaseBatchDate = objStock.PurchaseBatchDate.ToString("dd/MM/yyyy");
                        objStock.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objStock.BatchNo = Convert.ToString(drData["BatchNo"]) + " - " + objStock.sPurchaseBatchDate;
                        objStock.PurchaseRate = Convert.ToDecimal(drData["PurchaseRate"]);
                        objStock.SellingPrice = Convert.ToDecimal(drData["SellingRate"]);


                        objList.Add(objStock);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock GetStock | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Stock> SearchStock(string ID, int iBranchID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Stock> objList = new Collection<Entity.Stock>();
            Entity.Stock objStock = new Entity.Stock();
            Entity.Master.Product objProduct;
            Entity.Billing.Category objCategory;

            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SEARCH_STOCK);
                db.AddInParameter(cmd, "@key", DbType.String, ID);
                db.AddInParameter(cmd, "@FK_BranchID", DbType.Int32, iBranchID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objStock = new Entity.Stock();
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objStock.StockID = Convert.ToInt32(drData["PK_StockID"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objStock.Product = objProduct;
                        objStock.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objList.Add(objStock);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock GetStock | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Stock> GetTopStock(int iBranchID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Stock> objList = new Collection<Entity.Stock>();
            Entity.Stock objStock = new Entity.Stock();
            Entity.Master.Product objProduct;
            Entity.Billing.Category objCategory;

            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_TOPSTOCK);
                db.AddInParameter(cmd, "@FK_BranchID", DbType.Int32, iBranchID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objStock = new Entity.Stock();
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();

                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objStock.StockID = Convert.ToInt32(drData["PK_StockID"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objStock.Product = objProduct;
                        objStock.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objList.Add(objStock);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock GetStock | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Entity.Stock GetStockByID(int iStockID)
        {
            string sException = string.Empty;
            Database db;
            Entity.Stock objStock = new Entity.Stock();
            Entity.Master.Product objProduct;
            Entity.Billing.Category objCategory;
            Entity.User objCreatedUser;
            Entity.User objModifiedUser;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCTSTOCK);
                db.AddInParameter(cmd, "@PK_StockID", DbType.Int32, iStockID);
                DataSet dsList = db.ExecuteDataSet(cmd);
                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objStock = new Entity.Stock();
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();
                        objStock.StockID = Convert.ToInt32(drData["PK_StockID"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objStock.Product = objProduct;
                        objStock.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objStock.PurchaseBatchDate = Convert.ToDateTime(drData["PurchaseBatchDate"]);
                        objStock.sPurchaseBatchDate = objStock.PurchaseBatchDate.ToString("dd/MM/yyyy");
                        objStock.PurchaseRate = Convert.ToDecimal(drData["PurchaseRate"]);
                        objStock.SellingPrice = Convert.ToDecimal(drData["SellingRate"]);
                        objStock.PreviousPrice = Convert.ToDecimal(drData["PreviousPrice"]);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock GetStockByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objStock;
        }


        public static Entity.Stock GetStockProductByID(int ID)
        {
            string sException = string.Empty;
            Database db;
            Entity.Stock objStock = new Entity.Stock();
            Entity.Master.Product objProduct;
            Entity.Billing.Category objCategory;

            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCTRETURNSTOCK);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.Int32, ID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objStock = new Entity.Stock();
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();
                        objStock.StockID = Convert.ToInt32(drData["PK_StockID"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objStock.Product = objProduct;
                        objStock.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objStock.PurchaseBatchDate = Convert.ToDateTime(drData["PurchaseBatchDate"]);
                        objStock.sPurchaseBatchDate = objStock.PurchaseBatchDate.ToString("dd/MM/yyyy");
                        objStock.PurchaseRate = Convert.ToDecimal(drData["PurchaseRate"]);
                        objStock.SellingPrice = Convert.ToDecimal(drData["SellingRate"]);
                        objStock.PreviousPrice = Convert.ToDecimal(drData["PreviousPrice"]);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock GetStockByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objStock;
        }

        public static Entity.Stock GetStockPreviousRateByID(int iProductID = 0, int iCustomerID = 0)
        {
            string sException = string.Empty;
            Database db;
            Entity.Stock objStock = new Entity.Stock();
            Entity.Master.Product objProduct;
            Entity.Billing.Category objCategory;

            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCTSTOCKBYPREVIOUSRATE);
                db.AddInParameter(cmd, "@FK_ProductID", DbType.Int32, iProductID);
                db.AddInParameter(cmd, "@FK_CustomerID", DbType.Int32, iCustomerID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objStock = new Entity.Stock();
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objStock.StockID = Convert.ToInt32(drData["PK_StockID"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objStock.Product = objProduct;
                        objStock.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objStock.PurchaseBatchDate = Convert.ToDateTime(drData["PurchaseBatchDate"]);
                        objStock.sPurchaseBatchDate = objStock.PurchaseBatchDate.ToString("dd/MM/yyyy");
                        objStock.PurchaseRate = Convert.ToDecimal(drData["PurchaseRate"]);
                        objStock.SellingPrice = Convert.ToDecimal(drData["SellingRate"]);
                        objStock.SalesMargin = Convert.ToDecimal(drData["SalesMargin"]);
                        objStock.PreviousPrice = Convert.ToDecimal(drData["PreviousPrice"]);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock GetStockByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objStock;
        }
        public static Entity.Stock GetStockByBarcode(string iStockID, string Status = null, int iBranchID = 0)
        {
            string sException = string.Empty;
            Database db;
            Entity.Stock objStock = new Entity.Stock();
            Entity.Master.Product objProduct;
            Entity.Billing.Category objCategory;

            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_STOCKBYBARCODE);
                db.AddInParameter(cmd, "@PK_StockID", DbType.String, iStockID);
                db.AddInParameter(cmd, "@Status", DbType.String, Status);
                db.AddInParameter(cmd, "@FK_BranchID", DbType.Int32, iBranchID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objStock = new Entity.Stock();
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();

                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objStock.StockID = Convert.ToInt32(drData["PK_StockID"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objStock.Product = objProduct;
                        objStock.Quantity = Convert.ToDecimal(drData["Quantity"]);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock GetStockByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objStock;
        }
        public static Collection<Entity.Stock> GetMissingBarcode(string StockIDs, int iBranchID = 0, int Quantity = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Stock> objList = new Collection<Entity.Stock>();
            Entity.Stock objStock = new Entity.Stock();
            Entity.Master.Product objProduct;
            Entity.Billing.Category objCategory;

            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_MISSINGSTOCK);
                db.AddInParameter(cmd, "@StockIDs", DbType.String, StockIDs);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, Quantity);
                db.AddInParameter(cmd, "@FK_BranchID", DbType.Int32, 0);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objStock = new Entity.Stock();
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();

                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objStock.StockID = Convert.ToInt32(drData["PK_StockID"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objStock.Product = objProduct;
                        objStock.Quantity = Convert.ToDecimal(drData["Quantity"]);
                        objList.Add(objStock);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock GetStock | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Entity.Stock GetStockByBarcodeQuotation(string iStockID, string Status = null, int iBranchID = 0)
        {
            string sException = string.Empty;
            Database db;
            Entity.Stock objStock = new Entity.Stock();
            Entity.Master.Product objProduct;
            Entity.Billing.Category objCategory;

            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_STOCKBYBARCODEQUOTATION);
                db.AddInParameter(cmd, "@PK_StockID", DbType.String, iStockID);
                db.AddInParameter(cmd, "@Status", DbType.String, Status);
                db.AddInParameter(cmd, "@FK_BranchID", DbType.Int32, iBranchID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objStock = new Entity.Stock();
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();

                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objStock.StockID = Convert.ToInt32(drData["PK_StockID"]);
                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objStock.Product = objProduct;
                        objStock.Quantity = Convert.ToDecimal(drData["Quantity"]);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock GetStockByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objStock;
        }
        public static int AddStock(Entity.Stock objStock)
        {
            int ID = 0;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    ID = AddStock(oDb, objStock, oTrans);
                    oTrans.Commit();
                    if (ID > 0)
                        Framework.InsertAuditLog("tStock", "PK_StockID", objStock.StockID.ToString(), (char)Entity.Common.DatabaseAction.INSERT, 1008);
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
                finally
                {
                    oDbCon.Close();
                }
            }
            return ID;
        }
        private static int AddStock(Database oDb, Entity.Stock objStock, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_STOCK);
                oDb.AddOutParameter(cmd, "@PK_StockID", DbType.Int32, objStock.StockID);
                oDb.AddInParameter(cmd, "@FK_ProductID", DbType.Int32, objStock.Product.ProductID);
                oDb.AddInParameter(cmd, "@Quantity", DbType.Decimal, objStock.Quantity);
                iID = oDb.ExecuteNonQuery(cmd, oTrans);
                if (iID != 0)
                {
                    iID = Convert.ToInt32(oDb.GetParameterValue(cmd, "@PK_StockID"));
                    objStock.StockID = iID;
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock AddStock | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static int UpdateSplitWeight(int stockID, decimal iWeight, int iUserID)
        {
            int ID = 0;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    ID = UpdateSplitWeight(oDb, stockID, iWeight, iUserID, oTrans);
                    oTrans.Commit();
                    if (ID > 0)
                        Framework.InsertAuditLog("tStock", "PK_StockID", stockID.ToString(), (char)Entity.Common.DatabaseAction.INSERT, iUserID);
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
                finally
                {
                    oDbCon.Close();
                }
            }
            return ID;
        }
        private static int UpdateSplitWeight(Database oDb, int stockID, decimal iWeight, int iUserID, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_STOCKSPLIT);
                oDb.AddOutParameter(cmd, "@PK_StockID", DbType.Int32, 0);
                oDb.AddInParameter(cmd, "@PK_StockID1", DbType.Int32, stockID);
                oDb.AddInParameter(cmd, "@NetWeight", DbType.Decimal, iWeight);
                oDb.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, iUserID);

                iID = oDb.ExecuteNonQuery(cmd, oTrans);
                if (iID != 0)
                {
                    iID = Convert.ToInt32(oDb.GetParameterValue(cmd, "@PK_StockID"));
                    //objStock.StockID = iID;
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock AddStock | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateStock(Entity.Stock objStock)
        {
            bool IsUpdated = true;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsUpdated = UpdateStock(oDb, objStock, oTrans);
                    oTrans.Commit();
                    if (IsUpdated) Framework.InsertAuditLog("tStock", "PK_StockID", objStock.StockID.ToString(), (char)Entity.Common.DatabaseAction.UPDATE, 1008);
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
                finally
                {
                    oDbCon.Close();
                }
            }
            return IsUpdated;
        }
        private static bool UpdateStock(Database oDb, Entity.Stock objStock, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_STOCK);
                oDb.AddInParameter(cmd, "@PK_StockID", DbType.Int32, objStock.StockID);
                oDb.AddInParameter(cmd, "@FK_ProductID", DbType.Int32, objStock.Product.ProductID);
                oDb.AddInParameter(cmd, "@Quantity", DbType.Decimal, objStock.Quantity);
                iID = oDb.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock UpdateStock | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteStock(int ID, int UserID)
        {
            bool IsDeleted = false;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsDeleted = DeleteStock(oDb, ID, UserID, oTrans);
                    oTrans.Commit();

                    if (IsDeleted) Framework.InsertAuditLog("tStock", "PK_StockID", ID.ToString(), (char)Entity.Common.DatabaseAction.DELETE, UserID);
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
                finally
                {
                    oDbCon.Close();
                }
            }
            return IsDeleted;
        }
        private static bool DeleteStock(Database oDb, int ID, int UserID, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_STOCK);
                oDb.AddInParameter(cmd, "@PK_StockID", DbType.Int32, ID);
                iRemoveId = oDb.ExecuteNonQuery(cmd);
                if (iRemoveId != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Stock DeleteStock | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    }
}
