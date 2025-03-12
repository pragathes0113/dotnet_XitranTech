using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.ObjectModel;
using VHMS;
using System.IO;
using System.Web;

namespace VHMS.DataAccess.Master
{
    public class Product
    {
        public static Collection<Entity.Master.Product> GetProduct(int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            Entity.Billing.Category objCategory; Entity.Billing.Supplier objSupplier;
            Entity.Billing.Tax objTax;
            Entity.Billing.Unit objUnit; 
            
            
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCT);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {

                        objCategory = new Entity.Billing.Category();
                        objSupplier = new Entity.Billing.Supplier();
                        objUnit = new Entity.Billing.Unit();
                        objProduct = new Entity.Master.Product();
                        objTax = new Entity.Billing.Tax();
                        objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.SalesPercent = Convert.ToDecimal(drData["SalesPercent"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objCategory.CategoryID = Convert.ToInt32(drData["FK_CategoryID"]);
                        objCategory.CategoryName = Convert.ToString(drData["CategoryName"]);
                        objProduct.Category = objCategory;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objTax.TaxPercentage = Convert.ToDecimal(drData["TaxPercentage"]);
                        objProduct.Tax = objTax;
                        objUnit.UnitID = Convert.ToInt32(drData["FK_UnitID"]);
                        objUnit.UnitName = Convert.ToString(drData["UnitName"]);
                        objProduct.Unit = objUnit;
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objProduct.Supplier = objSupplier;
                        objProduct.ProductImage1 = Convert.ToString(drData["ProductImage1"]);
                        objProduct.ProductImage2 = Convert.ToString(drData["ProductImage2"]);
                        objProduct.ProductImage3 = Convert.ToString(drData["ProductImage3"]);
                        objProduct.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objProduct.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objProduct.sCreatedOn = objProduct.CreatedOn.ToString("dd/MM/yyyy");
                        objList.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Master.Product> GetReorderStock(int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            Entity.Billing.Category objCategory; Entity.Billing.Supplier objSupplier;
            Entity.Billing.Tax objTax;
            Entity.Billing.Unit objUnit; 
            
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.RPT_SELECT_REORDERPRODUCT);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);
                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCategory = new Entity.Billing.Category();
                        objSupplier = new Entity.Billing.Supplier();
                        objUnit = new Entity.Billing.Unit();
                        objProduct = new Entity.Master.Product();                      
                        objTax = new Entity.Billing.Tax();
                        objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objCategory.CategoryID = Convert.ToInt32(drData["FK_CategoryID"]);
                        objCategory.CategoryName = Convert.ToString(drData["CategoryName"]);
                        objProduct.Category = objCategory;
                        objProduct.AvailableQty = Convert.ToInt32(drData["AvailableQty"]);
                        objProduct.PurchasePrice = Convert.ToDecimal(drData["PurchasePrice"]);
                        objProduct.SalesPrice = Convert.ToDecimal(drData["SalesPrice"]);
                        objProduct.SalesPercent = Convert.ToDecimal(drData["SalesPercent"]);
                        objList.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Master.Product> GetProductList(int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product(); Entity.Billing.Supplier objSupplier;
            try
            { 
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCT);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objProduct = new Entity.Master.Product();
                        objSupplier = new Entity.Billing.Supplier();

                        objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objProduct.Supplier = objSupplier;
                        objProduct.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        //objProduct.PurchasePrice = Convert.ToDecimal(drData["PurchasePrice"]);
                        //objProduct.SalesPrice = Convert.ToDecimal(drData["SalesPrice"]);
                        objProduct.SalesPercent = Convert.ToDecimal(drData["SalesPercent"]);
                        objList.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Master.Product> GetTopProduct(int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            Entity.Billing.Category objCategory; Entity.Billing.Supplier objSupplier;
            Entity.Billing.Tax objTax;
            Entity.Billing.Unit objUnit; 
             
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_TOPPRODUCT);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCategory = new Entity.Billing.Category();
                        objSupplier = new Entity.Billing.Supplier();
                        objUnit = new Entity.Billing.Unit();
                        objProduct = new Entity.Master.Product();
                        objTax = new Entity.Billing.Tax();
                        

                        objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objCategory.CategoryID = Convert.ToInt32(drData["FK_CategoryID"]);
                        objCategory.CategoryName = Convert.ToString(drData["CategoryName"]);
                        objProduct.Category = objCategory;
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objProduct.Supplier = objSupplier;
                        objProduct.SalesPercent = Convert.ToDecimal(drData["SalesPercent"]);
                        objProduct.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objProduct.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objProduct.sCreatedOn = objProduct.CreatedOn.ToString("dd/MM/yyyy");
                        objList.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Master.Product> SearchProduct(string ID, int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            Entity.Billing.Category objCategory; Entity.Billing.Supplier objSupplier;
            Entity.Billing.Tax objTax;
            Entity.Billing.Unit objUnit; 
             
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SEARCH_PRODUCT);
                db.AddInParameter(cmd, "@Key", DbType.String, ID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCategory = new Entity.Billing.Category();
                        objSupplier = new Entity.Billing.Supplier();
                        objUnit = new Entity.Billing.Unit();
                        objProduct = new Entity.Master.Product();
                        objTax = new Entity.Billing.Tax();
                        

                        objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objCategory.CategoryID = Convert.ToInt32(drData["FK_CategoryID"]);
                        objCategory.CategoryName = Convert.ToString(drData["CategoryName"]);
                        objProduct.Category = objCategory;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objTax.TaxPercentage = Convert.ToDecimal(drData["TaxPercentage"]);
                        objProduct.Tax = objTax;
                        objUnit.UnitID = Convert.ToInt32(drData["FK_UnitID"]);
                        objUnit.UnitName = Convert.ToString(drData["UnitName"]);
                        objProduct.Unit = objUnit;
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objProduct.Supplier = objSupplier;
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objProduct.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objProduct.sCreatedOn = objProduct.CreatedOn.ToString("dd/MM/yyyy");
                        objProduct.PurchasePrice = Convert.ToDecimal(drData["PurchasePrice"]);
                        objProduct.SalesPrice = Convert.ToDecimal(drData["SalesPrice"]);
                        objProduct.SalesPercent = Convert.ToDecimal(drData["SalesPercent"]);
                        objList.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static List<string> GetProductList(string prefix)
        {
            List<string> Products = new List<string>();
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCTBYCODE);
                db.AddInParameter(cmd, "@ProductCode", DbType.String, prefix);
                db.AddInParameter(cmd, "@SMSOnly", DbType.Boolean, true);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        Products.Add(string.Format("{0,-15} | {1,-15} | {2,-500}", drData["SMSCode"], drData["ProductCode"], drData["ProductName"]));
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return Products;
        }

        public static List<string> GetBarcodeList(string prefix)
        {
            List<string> Products = new List<string>();
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_BARCODELIST);
                db.AddInParameter(cmd, "@Barcode", DbType.String, prefix);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        Products.Add(string.Format("{0,-200}", drData["Barcode"]));
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return Products;
        }

        public static List<string> GetProductCodeList(string prefix, int SupplierID)
        {
            List<string> Products = new List<string>();
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCTBYCODE);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, SupplierID);
                db.AddInParameter(cmd, "@ProductCode", DbType.String, prefix);
                db.AddInParameter(cmd, "@SMSOnly", DbType.Boolean, false);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        string ItemName = drData["ProductName"].ToString();
                        if (Convert.ToBoolean(drData["PricingA"]) == true)
                            ItemName = ItemName + "( A ";
                        if (Convert.ToBoolean(drData["PricingB"]) == true)
                            ItemName = ItemName + ", B ";
                        if (Convert.ToBoolean(drData["PricingC"]) == true)
                            ItemName = ItemName + ", C ";
                        if (Convert.ToBoolean(drData["PricingA"]) == true || Convert.ToBoolean(drData["PricingB"]) == true || Convert.ToBoolean(drData["PricingC"]) == true)
                            ItemName = ItemName + " )";
                        Products.Add(string.Format("{0,-15} | {1,-15} | {2,-500}", drData["SMSCode"], drData["ProductCode"], ItemName));
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return Products;
        }

        public static List<string> GetProductSMSCodeList(string prefix, int SupplierID)
        {
            List<string> Products = new List<string>();
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCTBYSMSCODE);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, SupplierID);
                db.AddInParameter(cmd, "@ProductCode", DbType.String, prefix);
                db.AddInParameter(cmd, "@SMSOnly", DbType.Boolean, false);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        Products.Add(string.Format("{0,-15} | {1,-15} | {2,-500}", drData["SMSCode"], drData["ProductCode"], drData["ProductName"]));
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return Products;
        }
        public static List<string> GetProductNameList(string prefix)
        {
            List<string> Products = new List<string>();
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCTBYNAME);
                db.AddInParameter(cmd, "@ProductCode", DbType.String, prefix);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        Products.Add(string.Format("{0,-500} | {1,-15} | {2,-200} | {3,-15}", drData["ProductName"], drData["SMSCode"], drData["SupplierName"], drData["ProductCode"]));
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return Products;
        }
        public static Entity.Master.Product GetProductByID(int iProductID, int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            Entity.Master.Product objProduct = new Entity.Master.Product();
            Entity.Billing.Category objCategory; Entity.Billing.Supplier objSupplier;
            Entity.Billing.Unit objUnit; 
            
            Entity.Billing.Tax objTax; 

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCT);
                db.AddInParameter(cmd, "@PK_ProductID", DbType.Int32, iProductID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();
                        objSupplier = new Entity.Billing.Supplier();
                        objUnit = new Entity.Billing.Unit();
                        objTax = new Entity.Billing.Tax();
                        

                        objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objCategory.CategoryID = Convert.ToInt32(drData["FK_CategoryID"]);
                        objCategory.CategoryName = Convert.ToString(drData["CategoryName"]);
                        objProduct.Category = objCategory;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objTax.TaxPercentage = Convert.ToDecimal(drData["TaxPercentage"]);
                        objProduct.Tax = objTax;

                        objUnit.UnitID = Convert.ToInt32(drData["FK_UnitID"]);
                        objUnit.UnitName = Convert.ToString(drData["UnitName"]);
                        objProduct.Unit = objUnit;

                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objProduct.Supplier = objSupplier;

                        objProduct.ProductImage1 = Convert.ToString(drData["ProductImage1"]);
                        objProduct.ProductImage2 = Convert.ToString(drData["ProductImage2"]);
                        objProduct.ProductImage3 = Convert.ToString(drData["ProductImage3"]);
                        
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        //objProduct.PurchasePrice = Convert.ToDecimal(drData["PurchasePrice"]);
                        //objProduct.SalesPrice = Convert.ToDecimal(drData["SalesPrice"]);
                        objProduct.SalesPercent = Convert.ToDecimal(drData["SalesPercent"]);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProductByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objProduct;
        }

        public static Collection<Entity.Master.Product> GetProductSupplierList(int SupplierID, int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            Entity.Billing.Category objCategory; Entity.Billing.Supplier objSupplier;
            Entity.Billing.Tax objTax;
            Entity.Billing.Unit objUnit;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCTSUPPLIERLIST);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, SupplierID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {

                        objCategory = new Entity.Billing.Category();
                        objSupplier = new Entity.Billing.Supplier();
                        objUnit = new Entity.Billing.Unit();
                        objProduct = new Entity.Master.Product();
                        objTax = new Entity.Billing.Tax();
                        objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.SalesPercent = Convert.ToDecimal(drData["SalesPercent"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objCategory.CategoryID = Convert.ToInt32(drData["FK_CategoryID"]);
                        objCategory.CategoryName = Convert.ToString(drData["CategoryName"]);
                        objProduct.Category = objCategory;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objTax.TaxPercentage = Convert.ToDecimal(drData["TaxPercentage"]);
                        objProduct.Tax = objTax;
                        objUnit.UnitID = Convert.ToInt32(drData["FK_UnitID"]);
                        objUnit.UnitName = Convert.ToString(drData["UnitName"]);
                        objProduct.Unit = objUnit;
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objProduct.Supplier = objSupplier;
                        objProduct.ProductImage1 = Convert.ToString(drData["ProductImage1"]);
                        objProduct.ProductImage2 = Convert.ToString(drData["ProductImage2"]);
                        objProduct.ProductImage3 = Convert.ToString(drData["ProductImage3"]);
                        objProduct.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objProduct.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objProduct.sCreatedOn = objProduct.CreatedOn.ToString("dd/MM/yyyy");
                        objList.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
      
        public static Collection<Entity.Master.Product> GetAllProduct(int iProductID, int iCategoryID, int iSupplierID, int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            Entity.Billing.Category objCategory; Entity.Billing.Supplier objSupplier;
            Entity.Billing.Tax objTax;
            Entity.Billing.Unit objUnit; 
             
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_GETALLPRODUCT);
                db.AddInParameter(cmd, "@PK_ProductID", DbType.Int32, iProductID);
                db.AddInParameter(cmd, "@FK_CategoryID", DbType.Int32, iCategoryID);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, iSupplierID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();
                        objSupplier = new Entity.Billing.Supplier();
                        objUnit = new Entity.Billing.Unit();
                        objTax = new Entity.Billing.Tax();

                        objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objCategory.CategoryID = Convert.ToInt32(drData["FK_CategoryID"]);
                        objCategory.CategoryName = Convert.ToString(drData["CategoryName"]);
                        objProduct.Category = objCategory;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objProduct.Tax = objTax;
                        objUnit.UnitID = Convert.ToInt32(drData["FK_UnitID"]);
                        objUnit.UnitName = Convert.ToString(drData["UnitName"]);
                        objProduct.Unit = objUnit;
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objProduct.Supplier = objSupplier;
                        objProduct.ProductImage1 = Convert.ToString(drData["ProductImage1"]);
                        objProduct.ProductImage2 = Convert.ToString(drData["ProductImage2"]);
                        objProduct.ProductImage3 = Convert.ToString(drData["ProductImage3"]);
                        objProduct.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objProduct.CreatedOn = Convert.ToDateTime(drData["CreatedOn"]);
                        objProduct.sCreatedOn = objProduct.CreatedOn.ToString("dd/MM/yyyy");
                        //objProduct.PurchasePrice = Convert.ToDecimal(drData["PurchasePrice"]);
                        //objProduct.SalesPrice = Convert.ToDecimal(drData["SalesPrice"]);
                        objProduct.SalesPercent = Convert.ToDecimal(drData["SalesPercent"]);
                        objList.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Collection<Entity.Master.Product> GetProductID(int iProductID, int iCategoryID,int iSupplierID, int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product(); Entity.Billing.Supplier objSupplier;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCT);
                db.AddInParameter(cmd, "@PK_ProductID", DbType.Int32, iProductID);
                db.AddInParameter(cmd, "@FK_CategoryID", DbType.Int32, iCategoryID);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, iSupplierID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objProduct = new Entity.Master.Product();
                        objSupplier = new Entity.Billing.Supplier();

                        objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                      
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objProduct.Supplier = objSupplier;
                        objProduct.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objList.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Master.Product> GetActiveProductID(int iProductID, int iCategoryID, int iSubCategoryID, int iSupplierID, int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            Entity.Billing.Category objCategory; Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax;
            Entity.Billing.Unit objUnit;   
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCT);
                db.AddInParameter(cmd, "@PK_ProductID", DbType.Int32, iProductID);
                db.AddInParameter(cmd, "@FK_CategoryID", DbType.Int32, iCategoryID);
                db.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, iSupplierID);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        if (Convert.ToBoolean(drData["IsActive"]))
                        {
                            objCategory = new Entity.Billing.Category();
                            objProduct = new Entity.Master.Product();
                            objSupplier = new Entity.Billing.Supplier();
                            objUnit = new Entity.Billing.Unit();
                            objTax = new Entity.Billing.Tax();
                            

                            objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                            objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                           
                            objCategory.CategoryID = Convert.ToInt32(drData["FK_CategoryID"]);
                            objCategory.CategoryName = Convert.ToString(drData["CategoryName"]);
                            objProduct.Category = objCategory;

                            objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                            objTax.TaxName = Convert.ToString(drData["TaxName"]);
                            objTax.TaxPercentage = Convert.ToDecimal(drData["TaxPercentage"]);
                            objProduct.Tax = objTax;

                            objUnit.UnitID = Convert.ToInt32(drData["FK_UnitID"]);
                            objUnit.UnitName = Convert.ToString(drData["UnitName"]);
                            objProduct.Unit = objUnit;

                            objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                            objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                            objProduct.Supplier = objSupplier;

                            objProduct.ProductImage1 = Convert.ToString(drData["ProductImage1"]);
                            objProduct.ProductImage2 = Convert.ToString(drData["ProductImage2"]);
                            objProduct.ProductImage3 = Convert.ToString(drData["ProductImage3"]);
                            objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                            objProduct.IsActive = Convert.ToBoolean(drData["IsActive"]);
                            objProduct.PurchasePrice = Convert.ToDecimal(drData["PurchasePrice"]);
                            objProduct.SalesPrice = Convert.ToDecimal(drData["SalesPrice"]);
                            objProduct.SalesPercent = Convert.ToDecimal(drData["SalesPercent"]);
                            objList.Add(objProduct);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Master.Product> GetProductByCode(string iProductCode, Boolean SMSOnly)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product();
            Entity.Billing.Category objCategory; Entity.Billing.Supplier objSupplier; Entity.Billing.Tax objTax;
            Entity.Billing.Unit objUnit;   
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCTBYCODE);
                db.AddInParameter(cmd, "@ProductCode", DbType.String, iProductCode);
                db.AddInParameter(cmd, "@SMSOnly", DbType.Boolean, SMSOnly);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();
                        objSupplier = new Entity.Billing.Supplier();
                        objUnit = new Entity.Billing.Unit();
                        objTax = new Entity.Billing.Tax();
                        objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objCategory.CategoryID = Convert.ToInt32(drData["FK_CategoryID"]);
                        objCategory.CategoryName = Convert.ToString(drData["CategoryName"]);
                        objProduct.Category = objCategory;
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objTax.TaxPercentage = Convert.ToDecimal(drData["TaxPercentage"]);
                        objProduct.Tax = objTax;
                        objUnit.UnitID = Convert.ToInt32(drData["FK_UnitID"]);
                        objUnit.UnitName = Convert.ToString(drData["UnitName"]);
                        objProduct.Unit = objUnit;
                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objProduct.Supplier = objSupplier;
                        objProduct.ProductImage1 = Convert.ToString(drData["ProductImage1"]);
                        objProduct.ProductImage2 = Convert.ToString(drData["ProductImage2"]);
                        objProduct.ProductImage3 = Convert.ToString(drData["ProductImage3"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objProduct.PurchasePrice = Convert.ToDecimal(drData["PurchasePrice"]);
                        objProduct.SalesPrice = Convert.ToDecimal(drData["SalesPrice"]);
                        objProduct.SalesPercent = Convert.ToDecimal(drData["SalesPercent"]);
                        objList.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Master.Product> GetProductByBarcode(string iProductCode, Boolean SMSOnly)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Master.Product> objList = new Collection<Entity.Master.Product>();
            Entity.Master.Product objProduct = new Entity.Master.Product(); Entity.Billing.Tax objTax;
            Entity.Billing.Category objCategory; Entity.Billing.Supplier objSupplier;
            Entity.Billing.Unit objUnit;  
            
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_PRODUCTBYBARCODE);
                db.AddInParameter(cmd, "@ProductCode", DbType.String, iProductCode);
                db.AddInParameter(cmd, "@SMSOnly", DbType.Boolean, SMSOnly);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCategory = new Entity.Billing.Category();
                        objProduct = new Entity.Master.Product();
                        objSupplier = new Entity.Billing.Supplier();
                        objUnit = new Entity.Billing.Unit();
                        objTax = new Entity.Billing.Tax();

                        objProduct.ProductID = Convert.ToInt32(drData["PK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objCategory.CategoryID = Convert.ToInt32(drData["FK_CategoryID"]);
                        objCategory.CategoryName = Convert.ToString(drData["CategoryName"]);
                        objProduct.Category = objCategory;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objTax.TaxPercentage = Convert.ToDecimal(drData["TaxPercentage"]);
                        objProduct.Tax = objTax;

                        objUnit.UnitID = Convert.ToInt32(drData["FK_UnitID"]);
                        objUnit.UnitName = Convert.ToString(drData["UnitName"]);
                        objProduct.Unit = objUnit;

                        objSupplier.SupplierID = Convert.ToInt32(drData["FK_SupplierID"]);
                        objSupplier.SupplierName = Convert.ToString(drData["SupplierName"]);
                        objProduct.Supplier = objSupplier;

                        objProduct.ProductImage1 = Convert.ToString(drData["ProductImage1"]);
                        objProduct.ProductImage2 = Convert.ToString(drData["ProductImage2"]);
                        objProduct.ProductImage3 = Convert.ToString(drData["ProductImage3"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objProduct.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objProduct.PurchasePrice = Convert.ToDecimal(drData["PurchasePrice"]);
                        objProduct.SalesPrice = Convert.ToDecimal(drData["SalesPrice"]);
                        objProduct.SalesPercent = Convert.ToDecimal(drData["SalesPercent"]);
                        
                        objList.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product GetProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static int AddProduct(Entity.Master.Product objProduct)
        {
            int ID = 0;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    ID = AddProduct(oDb, objProduct, oTrans);
                    oTrans.Commit();
                    if (ID > 0)
                        Framework.InsertAuditLog("tProduct", "PK_ProductID", objProduct.ProductID.ToString(), (char)Entity.Common.DatabaseAction.INSERT, objProduct.CreatedBy.UserID);
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
        private static int AddProduct(Database oDb, Entity.Master.Product objProduct, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_PRODUCT);
                oDb.AddOutParameter(cmd, "@PK_ProductID", DbType.Int32, objProduct.ProductID);
                oDb.AddInParameter(cmd, "@ProductName", DbType.String, objProduct.ProductName);
                oDb.AddInParameter(cmd, "@FK_CategoryID", DbType.Int32, objProduct.Category.CategoryID);
                oDb.AddInParameter(cmd, "@FK_UnitID", DbType.Int32, objProduct.Unit.UnitID);
                oDb.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, objProduct.Supplier.SupplierID);
                oDb.AddInParameter(cmd, "@FK_TaxID", DbType.Int32, objProduct.Tax.TaxID);
                oDb.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objProduct.Company.CompanyID);
                //oDb.AddInParameter(cmd, "@SalesPrice", DbType.Decimal, objProduct.SalesPrice);
                //oDb.AddInParameter(cmd, "@PurchasePrice", DbType.Decimal, objProduct.PurchasePrice);
                oDb.AddInParameter(cmd, "@SalesPercent", DbType.String, objProduct.SalesPercent);
                oDb.AddInParameter(cmd, "@ProductImage1", DbType.String, objProduct.ProductImage1);
                oDb.AddInParameter(cmd, "@ProductImage2", DbType.String, objProduct.ProductImage2);
                oDb.AddInParameter(cmd, "@ProductImage3", DbType.String, objProduct.ProductImage3);
                oDb.AddInParameter(cmd, "@ProductCode", DbType.String, objProduct.ProductCode);
                oDb.AddInParameter(cmd, "@IsActive", DbType.Boolean, objProduct.IsActive);
                oDb.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objProduct.CreatedBy.UserID);
                iID = oDb.ExecuteNonQuery(cmd, oTrans);
                if (iID != 0)
                {
                    iID = Convert.ToInt32(oDb.GetParameterValue(cmd, "@PK_ProductID"));
                    objProduct.ProductID = iID;
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product AddProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }

        public static bool UpdateProduct(Entity.Master.Product objProduct)
        {
            bool IsUpdated = true;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsUpdated = UpdateProduct(oDb, objProduct, oTrans);
                    oTrans.Commit();
                    if (IsUpdated) Framework.InsertAuditLog("tProduct", "PK_ProductID", objProduct.ProductID.ToString(), (char)Entity.Common.DatabaseAction.UPDATE, objProduct.ModifiedBy.UserID);
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
        private static bool UpdateProduct(Database oDb, Entity.Master.Product objProduct, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_PRODUCT);
                oDb.AddInParameter(cmd, "@PK_ProductID", DbType.Int32, objProduct.ProductID);
                oDb.AddInParameter(cmd, "@ProductName", DbType.String, objProduct.ProductName);
                oDb.AddInParameter(cmd, "@FK_CategoryID", DbType.Int32, objProduct.Category.CategoryID);
                oDb.AddInParameter(cmd, "@FK_UnitID", DbType.Int32, objProduct.Unit.UnitID);
                oDb.AddInParameter(cmd, "@FK_SupplierID", DbType.Int32, objProduct.Supplier.SupplierID);
                oDb.AddInParameter(cmd, "@FK_TaxID", DbType.Int32, objProduct.Tax.TaxID);
                oDb.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objProduct.Company.CompanyID);

                oDb.AddInParameter(cmd, "@SalesPercent", DbType.String, objProduct.SalesPercent);
                oDb.AddInParameter(cmd, "@ProductImage1", DbType.String, objProduct.ProductImage1);
                oDb.AddInParameter(cmd, "@ProductImage2", DbType.String, objProduct.ProductImage2);
                oDb.AddInParameter(cmd, "@ProductImage3", DbType.String, objProduct.ProductImage3);
                oDb.AddInParameter(cmd, "@ProductCode", DbType.String, objProduct.ProductCode);
                oDb.AddInParameter(cmd, "@IsActive", DbType.Boolean, objProduct.IsActive);
                oDb.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objProduct.ModifiedBy.UserID);
                iID = oDb.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product UpdateProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteProduct(int ID, int UserID)
        {
            bool IsDeleted = false;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsDeleted = DeleteProduct(oDb, ID, UserID, oTrans);
                    oTrans.Commit();

                    if (IsDeleted) Framework.InsertAuditLog("tProduct", "PK_ProductID", ID.ToString(), (char)Entity.Common.DatabaseAction.DELETE, UserID);
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
        private static bool DeleteProduct(Database oDb, int ID, int UserID, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_PRODUCT);
                oDb.AddInParameter(cmd, "@PK_ProductID", DbType.Int32, ID);
                iRemoveId = oDb.ExecuteNonQuery(cmd);
                if (iRemoveId != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Master.Product DeleteProduct | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    }
}
