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
    public class Service
    {
        public static Collection<Entity.Service> GetService(int CountryID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Service> objList = new Collection<Entity.Service>();
            Entity.Service objService = new Entity.Service();
            Entity.User objCreatedUser; Entity.Master.Product objProduct;
            Entity.Billing.Tax objTax; Entity.Customer objCustomer;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SERVICE);
                db.AddInParameter(cmd, "@PK_ServiceID", DbType.Int32, CountryID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objService = new Entity.Service();
                        objProduct = new Entity.Master.Product();
                        objCustomer = new Entity.Customer();
                        objTax = new Entity.Billing.Tax();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objService.Product = objProduct;

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                        objService.Customer = objCustomer;
                        
                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objService.Tax = objTax;

                        objService.ServiceID = Convert.ToInt32(drData["PK_ServiceID"]);
                        objService.ServiceNo = Convert.ToString(drData["ServiceNo"]);
                        objService.ServiceDate = Convert.ToDateTime(drData["ServiceDate"]);
                        objService.sServiceDate = objService.ServiceDate.ToString("dd/MM/yyyy");
                        objService.Status = Convert.ToString(drData["Status"]);
                        objService.DamageDescription = Convert.ToString(drData["DamageDescription"]);
                        objService.ServiceDescription = Convert.ToString(drData["ServiceDescription"]);
                        objService.ServiceCharges = Convert.ToDecimal(drData["ServiceCharges"]);
                        objService.TransportCharges = Convert.ToDecimal(drData["TransportCharges"]);
                        objService.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objService.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objService.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objService.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objService.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objService.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objService.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objService.AdvancePaid = Convert.ToDecimal(drData["AdvancePaid"]);
                        objService.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objService.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objService.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objService.Warranty = Convert.ToBoolean(drData["Warranty"]);
                        objService.SerialNo = Convert.ToString(drData["SerialNo"]);
                       
                        objList.Add(objService);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service GetService | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Service> GetServiceInvoice(int CountryID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Service> objList = new Collection<Entity.Service>();
            Entity.Service objService = new Entity.Service();
            Entity.User objCreatedUser; Entity.Master.Product objProduct;
            Entity.Billing.Tax objTax; Entity.Customer objCustomer;
            Entity.User objModifiedUser;
            Entity.ServiceInwardTrans objServiceInwardTrans;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SERVICEINVOICE);
                db.AddInParameter(cmd, "@PK_ServiceID", DbType.Int32, CountryID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objService = new Entity.Service();
                        objProduct = new Entity.Master.Product();
                        objCustomer = new Entity.Customer();
                        objTax = new Entity.Billing.Tax();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();
                        objServiceInwardTrans = new Entity.ServiceInwardTrans();

                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objService.Product = objProduct;

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                        objService.Customer = objCustomer;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objService.Tax = objTax;

                        objService.ServiceID = Convert.ToInt32(drData["PK_ServiceID"]);
                        objService.ServiceNo = Convert.ToString(drData["ServiceNo"]);
                        objService.ServiceDate = Convert.ToDateTime(drData["ServiceDate"]);
                        objService.sServiceDate = objService.ServiceDate.ToString("dd/MM/yyyy");

                        //objService.InvoiceNo = Convert.ToString(drData["InvoiceNo"]);
                        //objService.InvoiceDate = Convert.ToDateTime(drData["InvoiceDate"]);
                        //objService.sInvoiceDate = objService.InvoiceDate.ToString("dd/MM/yyyy");

                        objService.Status = Convert.ToString(drData["Status"]);
                        objServiceInwardTrans.SerialNo  = Convert.ToString(drData["ReceivedSerialNo"]);
                        objServiceInwardTrans.ServiceDescription = Convert.ToString(drData["ServiceDescription"]);
                        objServiceInwardTrans.ServiceCharges = Convert.ToDecimal(drData["ServiceCharges"]);
                        objServiceInwardTrans.ServiceType = Convert.ToString(drData["ServiceType"]);
                        objServiceInwardTrans.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objServiceInwardTrans.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objServiceInwardTrans.IGSTAmount = Convert.ToDecimal(drData["ServiceCharges"]);
                        objServiceInwardTrans.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objServiceInwardTrans.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objServiceInwardTrans.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objServiceInwardTrans.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objService.ServiceInwardTrans = objServiceInwardTrans;

                        objServiceInwardTrans.SerialNo = Convert.ToString(drData["ReceivedSerialNo"]);
                        objService.DamageDescription = Convert.ToString(drData["DamageDescription"]);
                        objService.ServiceDescription = Convert.ToString(drData["ServiceDescription"]);
                        objService.ServiceCharges = Convert.ToDecimal(drData["ServiceCharges"]);
                        objService.TransportCharges = Convert.ToDecimal(drData["TransportCharges"]);
                        objService.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objService.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objService.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objService.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objService.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objService.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objService.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objService.AdvancePaid = Convert.ToDecimal(drData["AdvancePaid"]);
                        objService.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objService.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objService.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objService.Warranty = Convert.ToBoolean(drData["Warranty"]);
                        objService.SerialNo = Convert.ToString(drData["SerialNo"]);

                        objList.Add(objService);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service GetService | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Service> GetTopService(int CountryID = 0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Service> objList = new Collection<Entity.Service>();
            Entity.Service objService = new Entity.Service();
            Entity.User objCreatedUser; Entity.Master.Product objProduct;
            Entity.Billing.Tax objTax; Entity.Customer objCustomer;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_TOPSERVICE);
                db.AddInParameter(cmd, "@PK_ServiceID", DbType.Int32, CountryID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objService = new Entity.Service();
                        objProduct = new Entity.Master.Product();
                        objCustomer = new Entity.Customer();
                        objTax = new Entity.Billing.Tax();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objService.Product = objProduct;

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                        objService.Customer = objCustomer;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objService.Tax = objTax;

                        objService.ServiceID = Convert.ToInt32(drData["PK_ServiceID"]);
                        objService.ServiceNo = Convert.ToString(drData["ServiceNo"]);
                        objService.ServiceDate = Convert.ToDateTime(drData["ServiceDate"]);
                        objService.sServiceDate = objService.ServiceDate.ToString("dd/MM/yyyy");
                        objService.Status = Convert.ToString(drData["Status"]);
                        objService.DamageDescription = Convert.ToString(drData["DamageDescription"]);
                        objService.ServiceDescription = Convert.ToString(drData["ServiceDescription"]);
                        objService.ServiceCharges = Convert.ToDecimal(drData["ServiceCharges"]);
                        objService.TransportCharges = Convert.ToDecimal(drData["TransportCharges"]);
                        objService.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objService.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objService.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objService.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objService.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objService.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objService.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objService.AdvancePaid = Convert.ToDecimal(drData["AdvancePaid"]);
                        objService.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objService.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objService.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objService.Warranty = Convert.ToBoolean(drData["Warranty"]);
                        objService.SerialNo = Convert.ToString(drData["SerialNo"]);

                        objList.Add(objService);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service GetService | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Service> GetServiceByStatus(string CountryID = "")
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Service> objList = new Collection<Entity.Service>();
            Entity.Service objService = new Entity.Service();
            Entity.User objCreatedUser; Entity.Master.Product objProduct;
            Entity.Billing.Tax objTax; Entity.Customer objCustomer;
            Entity.User objModifiedUser;
            Entity.ServiceInwardTrans objServiceInwardTrans;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SERVICEBYSTATUS);
                db.AddInParameter(cmd, "@Status", DbType.String, CountryID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objService = new Entity.Service();
                        objProduct = new Entity.Master.Product();
                        objCustomer = new Entity.Customer();
                        objTax = new Entity.Billing.Tax();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();
                        objServiceInwardTrans = new Entity.ServiceInwardTrans();

                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objService.Product = objProduct;

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                        objService.Customer = objCustomer;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objService.Tax = objTax;

                        objService.ServiceID = Convert.ToInt32(drData["PK_ServiceID"]);
                        objService.ServiceNo = Convert.ToString(drData["ServiceNo"]);
                        objService.ServiceDate = Convert.ToDateTime(drData["ServiceDate"]);
                        objService.sServiceDate = objService.ServiceDate.ToString("dd/MM/yyyy");

                        //objService.InvoiceNo = Convert.ToString(drData["InvoiceNo"]);
                        //objService.InvoiceDate = Convert.ToDateTime(drData["InvoiceDate"]);
                        //objService.sInvoiceDate = objService.InvoiceDate.ToString("dd/MM/yyyy");

                        objService.Status = Convert.ToString(drData["Status"]);
                        objServiceInwardTrans.SerialNo = Convert.ToString(drData["ReceivedSerialNo"]);
                        objServiceInwardTrans.ServiceDescription = Convert.ToString(drData["ServiceDescription"]);
                        objServiceInwardTrans.ServiceCharges = Convert.ToDecimal(drData["ServiceCharges"]);
                        objServiceInwardTrans.ServiceType = Convert.ToString(drData["ServiceType"]);
                        objServiceInwardTrans.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objServiceInwardTrans.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objServiceInwardTrans.IGSTAmount = Convert.ToDecimal(drData["ServiceCharges"]);
                        objServiceInwardTrans.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objServiceInwardTrans.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objServiceInwardTrans.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objServiceInwardTrans.TotalAmount = Convert.ToDecimal(drData["TotalAmount"]);
                        objService.ServiceInwardTrans = objServiceInwardTrans;

                        objServiceInwardTrans.SerialNo = Convert.ToString(drData["ReceivedSerialNo"]);
                        objService.DamageDescription = Convert.ToString(drData["DamageDescription"]);
                        objService.ServiceDescription = Convert.ToString(drData["ServiceDescription"]);
                        objService.ServiceCharges = Convert.ToDecimal(drData["ServiceCharges"]);
                        objService.TransportCharges = Convert.ToDecimal(drData["TransportCharges"]);
                        objService.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objService.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objService.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objService.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objService.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objService.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objService.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objService.AdvancePaid = Convert.ToDecimal(drData["AdvancePaid"]);
                        objService.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objService.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objService.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objService.Warranty = Convert.ToBoolean(drData["Warranty"]);
                        objService.SerialNo = Convert.ToString(drData["SerialNo"]);

                        objList.Add(objService);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service GetService | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Service> GetSearchService(string CountryID = "")
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Service> objList = new Collection<Entity.Service>();
            Entity.Service objService = new Entity.Service();
            Entity.User objCreatedUser; Entity.Master.Product objProduct;
            Entity.Billing.Tax objTax; Entity.Customer objCustomer;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SEARCH_SERVICE);
                db.AddInParameter(cmd, "@PK_ServiceID", DbType.String, CountryID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objService = new Entity.Service();
                        objProduct = new Entity.Master.Product();
                        objCustomer = new Entity.Customer();
                        objTax = new Entity.Billing.Tax();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objService.Product = objProduct;

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                        objService.Customer = objCustomer;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objService.Tax = objTax;

                        objService.ServiceID = Convert.ToInt32(drData["PK_ServiceID"]);
                        objService.ServiceNo = Convert.ToString(drData["ServiceNo"]);
                        objService.ServiceDate = Convert.ToDateTime(drData["ServiceDate"]);
                        objService.sServiceDate = objService.ServiceDate.ToString("dd/MM/yyyy");
                        objService.Status = Convert.ToString(drData["Status"]);
                        objService.DamageDescription = Convert.ToString(drData["DamageDescription"]);
                        objService.ServiceDescription = Convert.ToString(drData["ServiceDescription"]);
                        objService.ServiceCharges = Convert.ToDecimal(drData["ServiceCharges"]);
                        objService.TransportCharges = Convert.ToDecimal(drData["TransportCharges"]);
                        objService.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objService.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objService.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objService.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objService.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objService.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objService.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objService.AdvancePaid = Convert.ToDecimal(drData["AdvancePaid"]);
                        objService.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objService.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objService.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objService.Warranty = Convert.ToBoolean(drData["Warranty"]);
                        objService.SerialNo = Convert.ToString(drData["SerialNo"]);

                        objList.Add(objService);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service GetService | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Service> GetSearchServiceByStatus(string CountryID = "", int ServiceDCID=0, string Status="")
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Service> objList = new Collection<Entity.Service>();
            Entity.Service objService = new Entity.Service();
            Entity.User objCreatedUser; Entity.Master.Product objProduct;
            Entity.Billing.Tax objTax; Entity.Customer objCustomer;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SEARCH_SERVICEBYSTATUS);
                db.AddInParameter(cmd, "@PK_ServiceID", DbType.String, CountryID);
                db.AddInParameter(cmd, "@FK_ServiceDCID", DbType.String, ServiceDCID);
                db.AddInParameter(cmd, "@Status", DbType.String, Status);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objService = new Entity.Service();
                        objProduct = new Entity.Master.Product();
                        objCustomer = new Entity.Customer();
                        objTax = new Entity.Billing.Tax();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objService.Product = objProduct;

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                        objService.Customer = objCustomer;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objService.Tax = objTax;

                        objService.ServiceID = Convert.ToInt32(drData["PK_ServiceID"]);
                        objService.ServiceNo = Convert.ToString(drData["ServiceNo"]);
                        objService.ServiceDate = Convert.ToDateTime(drData["ServiceDate"]);
                        objService.sServiceDate = objService.ServiceDate.ToString("dd/MM/yyyy");
                        objService.Status = Convert.ToString(drData["Status"]);
                        objService.DamageDescription = Convert.ToString(drData["DamageDescription"]);
                        objService.ServiceDescription = Convert.ToString(drData["ServiceDescription"]);
                        objService.ServiceCharges = Convert.ToDecimal(drData["ServiceCharges"]);
                        objService.TransportCharges = Convert.ToDecimal(drData["TransportCharges"]);
                        objService.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objService.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objService.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objService.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objService.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objService.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objService.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objService.AdvancePaid = Convert.ToDecimal(drData["AdvancePaid"]);
                        objService.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objService.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objService.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objService.Warranty = Convert.ToBoolean(drData["Warranty"]);
                        objService.SerialNo = Convert.ToString(drData["SerialNo"]);

                        objList.Add(objService);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service GetService | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.Service> GetSearchServiceInwardByStatus(string CountryID = "", int ServiceDCID = 0, string Status = "")
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Service> objList = new Collection<Entity.Service>();
            Entity.Service objService = new Entity.Service();
            Entity.User objCreatedUser; Entity.Master.Product objProduct;
            Entity.Billing.Tax objTax; Entity.Customer objCustomer;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SEARCH_SERVICEBYSTATUS);
                db.AddInParameter(cmd, "@PK_ServiceID", DbType.String, CountryID);
                db.AddInParameter(cmd, "@FK_ServiceDCID", DbType.String, ServiceDCID);
                db.AddInParameter(cmd, "@Status", DbType.String, Status);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objService = new Entity.Service();
                        objProduct = new Entity.Master.Product();
                        objCustomer = new Entity.Customer();
                        objTax = new Entity.Billing.Tax();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objService.Product = objProduct;

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                        objService.Customer = objCustomer;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objService.Tax = objTax;

                        objService.ServiceID = Convert.ToInt32(drData["PK_ServiceID"]);
                        objService.ServiceNo = Convert.ToString(drData["ServiceNo"]);
                        objService.ServiceDate = Convert.ToDateTime(drData["ServiceDate"]);
                        objService.sServiceDate = objService.ServiceDate.ToString("dd/MM/yyyy");
                        objService.Status = Convert.ToString(drData["Status"]);
                        objService.DamageDescription = Convert.ToString(drData["DamageDescription"]);
                        objService.ServiceDescription = Convert.ToString(drData["ServiceDescription"]);
                        objService.ServiceCharges = Convert.ToDecimal(drData["ServiceCharges"]);
                        objService.TransportCharges = Convert.ToDecimal(drData["TransportCharges"]);
                        objService.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objService.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objService.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objService.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objService.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objService.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objService.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objService.AdvancePaid = Convert.ToDecimal(drData["AdvancePaid"]);
                        objService.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objService.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objService.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objService.Warranty = Convert.ToBoolean(drData["Warranty"]);
                        objService.SerialNo = Convert.ToString(drData["SerialNo"]);

                        objList.Add(objService);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service GetService | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Entity.Service GetServiceByID(int iServiceID)
        {
            string sException = string.Empty;
            Database db;
            Entity.Service objService = new Entity.Service();
            Entity.User objCreatedUser; Entity.Master.Product objProduct;
            Entity.Billing.Tax objTax; Entity.Customer objCustomer;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SERVICE);
                db.AddInParameter(cmd, "@PK_ServiceID", DbType.Int32, iServiceID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objService = new Entity.Service();
                        objProduct = new Entity.Master.Product();
                        objCustomer = new Entity.Customer();
                        objTax = new Entity.Billing.Tax();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objProduct.ProductID = Convert.ToInt32(drData["FK_ProductID"]);
                        objProduct.ProductName = Convert.ToString(drData["ProductName"]);
                        objProduct.ProductCode = Convert.ToString(drData["ProductCode"]);
                        objService.Product = objProduct;

                        objCustomer.CustomerID = Convert.ToInt32(drData["FK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                        objService.Customer = objCustomer;

                        objTax.TaxID = Convert.ToInt32(drData["FK_TaxID"]);
                        objTax.TaxName = Convert.ToString(drData["TaxName"]);
                        objService.Tax = objTax;

                        objService.ServiceID = Convert.ToInt32(drData["PK_ServiceID"]);
                        objService.ServiceNo = Convert.ToString(drData["ServiceNo"]);
                        objService.ServiceDate = Convert.ToDateTime(drData["ServiceDate"]);
                        objService.sServiceDate = objService.ServiceDate.ToString("dd/MM/yyyy");
                        objService.Status = Convert.ToString(drData["Status"]);
                        objService.DamageDescription = Convert.ToString(drData["DamageDescription"]);
                        objService.ServiceDescription = Convert.ToString(drData["ServiceDescription"]);
                        objService.ServiceCharges = Convert.ToDecimal(drData["ServiceCharges"]);
                        objService.TransportCharges = Convert.ToDecimal(drData["TransportCharges"]);
                        objService.OtherCharges = Convert.ToDecimal(drData["OtherCharges"]);
                        objService.DiscountAmount = Convert.ToDecimal(drData["DiscountAmount"]);
                        objService.TaxPercent = Convert.ToDecimal(drData["TaxPercent"]);
                        objService.IGSTAmount = Convert.ToDecimal(drData["IGSTAmount"]);
                        objService.SGSTAmount = Convert.ToDecimal(drData["SGSTAmount"]);
                        objService.CGSTAmount = Convert.ToDecimal(drData["CGSTAmount"]);
                        objService.TaxAmount = Convert.ToDecimal(drData["TaxAmount"]);
                        objService.AdvancePaid = Convert.ToDecimal(drData["AdvancePaid"]);
                        objService.NetAmount = Convert.ToDecimal(drData["NetAmount"]);
                        objService.PaidAmount = Convert.ToDecimal(drData["PaidAmount"]);
                        objService.BalanceAmount = Convert.ToDecimal(drData["BalanceAmount"]);
                        objService.Warranty = Convert.ToBoolean(drData["Warranty"]);
                        objService.SerialNo = Convert.ToString(drData["SerialNo"]);

                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service GetServiceByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objService;
        }
        public static int AddService(Entity.Service objService)
        {
            int ID = 0;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    ID = AddService(oDb, objService, oTrans);
                    oTrans.Commit();
                    if (ID > 0)
                        Framework.InsertAuditLog("tService", "PK_ServiceID", objService.ServiceID.ToString(), (char)Entity.Common.DatabaseAction.INSERT, objService.CreatedBy.UserID);
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
        private static int AddService(Database oDb, Entity.Service objService, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_SERVICE);
                oDb.AddOutParameter(cmd, "@PK_ServiceID", DbType.Int32, objService.ServiceID);
                oDb.AddInParameter(cmd, "@ServiceNo", DbType.String, objService.ServiceNo);
                oDb.AddInParameter(cmd, "@ServiceDate", DbType.String, objService.sServiceDate);
                oDb.AddInParameter(cmd, "@FK_CustomerID", DbType.Int32, objService.Customer.CustomerID);
                oDb.AddInParameter(cmd, "@FK_TaxID", DbType.Int32, objService.Tax.TaxID);
                oDb.AddInParameter(cmd, "@FK_ProductID", DbType.Int32, objService.Product.ProductID);
                oDb.AddInParameter(cmd, "@SerialNo", DbType.String, objService.SerialNo);
                oDb.AddInParameter(cmd, "@DamageDescription", DbType.String, objService.DamageDescription);
                oDb.AddInParameter(cmd, "@ServiceDescription", DbType.String, objService.ServiceDescription);
                oDb.AddInParameter(cmd, "@Status", DbType.String, objService.Status);                
                oDb.AddInParameter(cmd, "@ServiceCharges", DbType.Decimal, objService.ServiceCharges);
                oDb.AddInParameter(cmd, "@TransportCharges", DbType.Decimal, objService.TransportCharges);
                oDb.AddInParameter(cmd, "@OtherCharges", DbType.Decimal, objService.OtherCharges);
                oDb.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objService.DiscountAmount);
                oDb.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objService.TaxPercent);
                oDb.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objService.IGSTAmount);
                oDb.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objService.CGSTAmount);
                oDb.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objService.SGSTAmount);
                oDb.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objService.TaxAmount);
                oDb.AddInParameter(cmd, "@NetAmount", DbType.Decimal, objService.NetAmount);
                oDb.AddInParameter(cmd, "@Roundoff", DbType.Decimal, objService.Roundoff);
                
                oDb.AddInParameter(cmd, "@AdvancePaid", DbType.Decimal, objService.AdvancePaid);
                oDb.AddInParameter(cmd, "@PaidAmount", DbType.Decimal, objService.PaidAmount);
                oDb.AddInParameter(cmd, "@BalanceAmount", DbType.Decimal, objService.BalanceAmount); 
                oDb.AddInParameter(cmd, "@Warranty", DbType.Boolean, objService.Warranty);
                oDb.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objService.CreatedBy.UserID);

                iID = oDb.ExecuteNonQuery(cmd, oTrans);
                if (iID != 0)
                {
                    iID = Convert.ToInt32(oDb.GetParameterValue(cmd, "@PK_ServiceID"));
                    objService.ServiceID = iID;
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service AddService | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateService(Entity.Service objService)
        {
            bool IsUpdated = true;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsUpdated = UpdateService(oDb, objService, oTrans);
                    oTrans.Commit();
                    if (IsUpdated) Framework.InsertAuditLog("tService", "PK_ServiceID", objService.ServiceID.ToString(), (char)Entity.Common.DatabaseAction.UPDATE, objService.ModifiedBy.UserID);
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
        public static bool UpdateServiceAmount(Entity.Service objService)
        {
            bool IsUpdated = true;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    //IsUpdated = UpdateServiceAmount(oDb, objService, oTrans);
                    //oTrans.Commit();
                    //if (IsUpdated) Framework.InsertAuditLog("tService", "PK_ServiceID", objService.ServiceID.ToString(), (char)Entity.Common.DatabaseAction.UPDATE, objService.ModifiedBy.UserID);
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

        private static bool UpdateService(Database oDb, Entity.Service objService, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_SERVICE);
                oDb.AddInParameter(cmd, "@PK_ServiceID", DbType.Int32, objService.ServiceID);
                oDb.AddInParameter(cmd, "@ServiceNo", DbType.String, objService.ServiceNo);
                oDb.AddInParameter(cmd, "@ServiceDate", DbType.String, objService.sServiceDate);
                oDb.AddInParameter(cmd, "@FK_CustomerID", DbType.Int32, objService.Customer.CustomerID);
                oDb.AddInParameter(cmd, "@FK_TaxID", DbType.Int32, objService.Tax.TaxID);
                oDb.AddInParameter(cmd, "@FK_ProductID", DbType.Int32, objService.Product.ProductID);
                oDb.AddInParameter(cmd, "@SerialNo", DbType.String, objService.SerialNo);
                oDb.AddInParameter(cmd, "@DamageDescription", DbType.String, objService.DamageDescription);
                oDb.AddInParameter(cmd, "@ServiceDescription", DbType.String, objService.ServiceDescription);
                oDb.AddInParameter(cmd, "@Status", DbType.String, objService.Status);
                oDb.AddInParameter(cmd, "@ServiceCharges", DbType.Decimal, objService.ServiceCharges);
                oDb.AddInParameter(cmd, "@TransportCharges", DbType.Decimal, objService.TransportCharges);
                oDb.AddInParameter(cmd, "@OtherCharges", DbType.Decimal, objService.OtherCharges);
                oDb.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objService.DiscountAmount);
                oDb.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objService.TaxPercent);
                oDb.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objService.IGSTAmount);
                oDb.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objService.CGSTAmount);
                oDb.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objService.SGSTAmount);
                oDb.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objService.TaxAmount);
                oDb.AddInParameter(cmd, "@NetAmount", DbType.Decimal, objService.NetAmount);
                oDb.AddInParameter(cmd, "@Roundoff", DbType.Decimal, objService.Roundoff);

                oDb.AddInParameter(cmd, "@AdvancePaid", DbType.Decimal, objService.AdvancePaid);
                oDb.AddInParameter(cmd, "@PaidAmount", DbType.Decimal, objService.PaidAmount);
                oDb.AddInParameter(cmd, "@BalanceAmount", DbType.Decimal, objService.BalanceAmount);
                oDb.AddInParameter(cmd, "@Warranty", DbType.Boolean, objService.Warranty);
                oDb.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objService.ModifiedBy.UserID);

                iID = oDb.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service UpdateService | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }

        public static bool AddServiceInvoice(Entity.Service objService)
        {
            bool IsUpdated = true;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsUpdated = AddServiceInvoice(oDb, objService, oTrans);
                    oTrans.Commit();
                    if (IsUpdated) Framework.InsertAuditLog("tService", "PK_ServiceID", objService.ServiceID.ToString(), (char)Entity.Common.DatabaseAction.UPDATE, objService.ModifiedBy.UserID);
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

        private static bool AddServiceInvoice(Database oDb, Entity.Service objService, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_SERVICEINVOICE);
                oDb.AddInParameter(cmd, "@PK_ServiceID", DbType.Int32, objService.ServiceID);
                oDb.AddInParameter(cmd, "@InvoiceDate", DbType.String, objService.sInvoiceDate);
                oDb.AddInParameter(cmd, "@FK_TaxID", DbType.Int32, objService.Tax.TaxID);
                oDb.AddInParameter(cmd, "@SerialNo", DbType.String, objService.SerialNo);
                oDb.AddInParameter(cmd, "@ServiceDescription", DbType.String, objService.ServiceDescription);
                oDb.AddInParameter(cmd, "@ServiceCharges", DbType.Decimal, objService.ServiceCharges);
                oDb.AddInParameter(cmd, "@TransportCharges", DbType.Decimal, objService.TransportCharges);
                oDb.AddInParameter(cmd, "@OtherCharges", DbType.Decimal, objService.OtherCharges);
                oDb.AddInParameter(cmd, "@DiscountAmount", DbType.Decimal, objService.DiscountAmount);
                oDb.AddInParameter(cmd, "@TaxPercent", DbType.Decimal, objService.TaxPercent);
                oDb.AddInParameter(cmd, "@IGSTAmount", DbType.Decimal, objService.IGSTAmount);
                oDb.AddInParameter(cmd, "@CGSTAmount", DbType.Decimal, objService.CGSTAmount);
                oDb.AddInParameter(cmd, "@SGSTAmount", DbType.Decimal, objService.SGSTAmount);
                oDb.AddInParameter(cmd, "@TaxAmount", DbType.Decimal, objService.TaxAmount);
                oDb.AddInParameter(cmd, "@NetAmount", DbType.Decimal, objService.NetAmount);
                oDb.AddInParameter(cmd, "@Roundoff", DbType.Decimal, objService.Roundoff);

                oDb.AddInParameter(cmd, "@AdvancePaid", DbType.Decimal, objService.AdvancePaid);
                oDb.AddInParameter(cmd, "@PaidAmount", DbType.Decimal, objService.PaidAmount);
                oDb.AddInParameter(cmd, "@BalanceAmount", DbType.Decimal, objService.BalanceAmount);
                oDb.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objService.ModifiedBy.UserID);

                iID = oDb.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service UpdateService | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }

        //private static bool UpdateServiceAmount(Database oDb, Entity.Service objService, DbTransaction oTrans)
        //{
        //    string sException = string.Empty;
        //    int iID = 0;
        //    bool bResult = false;
        //    try
        //    {
        //        DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_Service_AMOUNT);
        //        oDb.AddInParameter(cmd, "@PK_ServiceID", DbType.Int32, objService.ServiceID);
        //        oDb.AddInParameter(cmd, "@Conveyance", DbType.Decimal, objService.Conveyance);
        //        oDb.AddInParameter(cmd, "@BasicPay", DbType.Decimal, objService.BasicPay);
        //        oDb.AddInParameter(cmd, "@SpecialAllowance", DbType.Decimal, objService.SpecialAllowance);
        //        oDb.AddInParameter(cmd, "@MedicalAllowance", DbType.Decimal, objService.MedicalAllowance);
        //        oDb.AddInParameter(cmd, "@PF", DbType.Decimal, objService.PF);
        //        oDb.AddInParameter(cmd, "@HRA", DbType.Decimal, objService.HRA);
        //        oDb.AddInParameter(cmd, "@ESI", DbType.Decimal, objService.ESI);
        //        oDb.AddInParameter(cmd, "@OvertimeAllowance", DbType.Decimal, objService.OvertimeAllowance);
        //        oDb.AddInParameter(cmd, "@FoodAllowance", DbType.Decimal, objService.FoodAllowance);
        //        oDb.AddInParameter(cmd, "@NetSalary", DbType.Decimal, objService.NetSalary);
        //        oDb.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objService.ModifiedBy.UserID);
        //        oDb.AddInParameter(cmd, "@AdvanceDeduction", DbType.Decimal, objService.AdvanceDeduction);
        //        oDb.AddInParameter(cmd, "@FK_ShiftID", DbType.Int32, objService.Shift.ShiftID);
        //        oDb.AddInParameter(cmd, "@ServiceInTime", DbType.String, objService.ServiceInTime);
        //        oDb.AddInParameter(cmd, "@ServiceOutTime", DbType.String, objService.ServiceOutTime);
        //        oDb.AddInParameter(cmd, "@PaidLeaves", DbType.Int32, objService.PaidLeaves);

        //        iID = oDb.ExecuteNonQuery(cmd);
        //        if (iID != 0) bResult = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        sException = "VHMS.DataAccess.Service UpdateService | " + ex.ToString();
        //        Log.Write(sException);
        //        throw;
        //    }
        //    return bResult;
        //}
        public static bool DeleteService(int ID, int UserID)
        {
            bool IsDeleted = false;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsDeleted = DeleteService(oDb, ID, oTrans);
                    oTrans.Commit();

                    if (IsDeleted) Framework.InsertAuditLog("tService", "PK_ServiceID", ID.ToString(), (char)Entity.Common.DatabaseAction.DELETE, UserID);
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
        private static bool DeleteService(Database oDb, int ID, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_SERVICE);
                oDb.AddInParameter(cmd, "@PK_ServiceID", DbType.Int32, ID);
                iRemoveId = oDb.ExecuteNonQuery(cmd);
                if (iRemoveId != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Service DeleteService | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    }
}
