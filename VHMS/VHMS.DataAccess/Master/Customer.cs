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
    public class Customer
    {
        public static Collection<Entity.Customer> GetCustomer()
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Customer> objList = new Collection<Entity.Customer>();
            Entity.Customer objCustomer = new Entity.Customer();
            Entity.User objCreatedUser;
            Entity.User objModifiedUser;
            Entity.State objState = new Entity.State();
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_CUSTOMER);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCustomer = new Entity.Customer();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objCustomer.CustomerID = Convert.ToInt32(drData["PK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                      
                        objCustomer.CustomerCode = Convert.ToString(drData["CustomerCode"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                       
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        
                        objCustomer.AlternateNo = Convert.ToString(drData["AlternateNo"]);
                        objCustomer.Email = Convert.ToString(drData["Email"]);
                        objCustomer.GSTNo = Convert.ToString(drData["GSTNo"]);
                        
                        objCustomer.Pincode = Convert.ToString(drData["Pincode"]);
                      
                        objCustomer.State = new VHMS.Entity.State()
                        {
                            StateID = Convert.ToInt32(drData["FK_StateID"]),
                            StateName = Convert.ToString(drData["StateName"])
                        };
                       
                        objCustomer.IsActive = Convert.ToBoolean(drData["IsActive"]);

                        objList.Add(objCustomer);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Customer GetCustomer | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }


        public static Collection<Entity.Customer> GetTopCustomer(int CustomerID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Customer> objList = new Collection<Entity.Customer>();
            Entity.Customer objCustomer = new Entity.Customer();
            Entity.User objCreatedUser;
            Entity.User objModifiedUser;
            Entity.State objState = new Entity.State();
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_TOPCUSTOMER);
                db.AddInParameter(cmd, "@PK_CustomerID", DbType.Int32,CustomerID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCustomer = new Entity.Customer();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();
                        objCustomer.CustomerID = Convert.ToInt32(drData["PK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                        objCustomer.CustomerCode = Convert.ToString(drData["CustomerCode"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objCustomer.AlternateNo = Convert.ToString(drData["AlternateNo"]);
                        objCustomer.Email = Convert.ToString(drData["Email"]);
                        objCustomer.GSTNo = Convert.ToString(drData["GSTNo"]);
                        objCustomer.Pincode = Convert.ToString(drData["Pincode"]);                      
                        objCustomer.State = new VHMS.Entity.State()
                        {
                            StateID = Convert.ToInt32(drData["FK_StateID"]),
                            StateName = Convert.ToString(drData["StateName"])
                        };
                        objCustomer.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objList.Add(objCustomer);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Customer GetTopCustomer | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Entity.Customer GetCustomerByID(int iCustomerID)
        {
            string sException = string.Empty;
            Database db;
            Entity.Customer objCustomer = new Entity.Customer();
            Entity.State objState = new Entity.State();
            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_CUSTOMER);
                db.AddInParameter(cmd, "@PK_CustomerID", DbType.Int32, iCustomerID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCustomer = new Entity.Customer();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objCustomer.CustomerID = Convert.ToInt32(drData["PK_CustomerID"]);
                        objCustomer.CustomerName = Convert.ToString(drData["CustomerName"]);
                       
                        objCustomer.CustomerCode = Convert.ToString(drData["CustomerCode"]);
                        objCustomer.Address = Convert.ToString(drData["Address"]);
                       
                        objCustomer.MobileNo = Convert.ToString(drData["MobileNo"]);
                       
                        objCustomer.AlternateNo = Convert.ToString(drData["AlternateNo"]);
                        objCustomer.Email = Convert.ToString(drData["Email"]);
                        objCustomer.GSTNo = Convert.ToString(drData["GSTNo"]);
                       
                        objCustomer.Pincode = Convert.ToString(drData["Pincode"]);
                       
                        objCustomer.State = new VHMS.Entity.State()
                        {
                            StateID = Convert.ToInt32(drData["FK_StateID"]),
                            StateName = Convert.ToString(drData["StateName"]),
                              StateCode = Convert.ToString(drData["StateCode"])
                        };
                     
                        objCustomer.IsActive = Convert.ToBoolean(drData["IsActive"]);

                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Customer GetCustomerByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objCustomer;
        }


     
        public static int AddCustomer(Entity.Customer objCustomer)
        {
            string sException = string.Empty;
            int iID = 0;
            Database oDb;
            try
            {
                oDb = Entity.DBConnection.dbCon;
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_CUSTOMER);
                oDb.AddOutParameter(cmd, "@PK_CustomerID", DbType.Int32, objCustomer.CustomerID);
                oDb.AddInParameter(cmd, "@CustomerName", DbType.String, objCustomer.CustomerName);
                oDb.AddInParameter(cmd, "@CustomerCode", DbType.String, objCustomer.CustomerCode);
                oDb.AddInParameter(cmd, "@Address", DbType.String, objCustomer.Address);
                oDb.AddInParameter(cmd, "@MobileNo", DbType.String, objCustomer.MobileNo);
                oDb.AddInParameter(cmd, "@AlternateNo", DbType.String, objCustomer.AlternateNo);
                oDb.AddInParameter(cmd, "@Email", DbType.String, objCustomer.Email);
                oDb.AddInParameter(cmd, "@GSTNo", DbType.String, objCustomer.GSTNo);
                oDb.AddInParameter(cmd, "@IsActive", DbType.Boolean, objCustomer.IsActive);
                oDb.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objCustomer.CreatedBy.UserID);
                oDb.AddInParameter(cmd, "@FK_StateID", DbType.String, objCustomer.State.StateID);
                oDb.AddInParameter(cmd, "@Pincode", DbType.String, objCustomer.Pincode);
                iID = oDb.ExecuteNonQuery(cmd);
                if (iID != 0) iID = Convert.ToInt32(oDb.GetParameterValue(cmd, "@PK_CustomerID"));

            }
            catch (Exception ex)
            {
                sException = "Customer AddCustomer | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateCustomer(Entity.Customer objCustomer)
        {
            string sException = string.Empty;
            int iID = 0; bool bResult = false;
            Database oDb;
            try
            {
                oDb = Entity.DBConnection.dbCon;
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_CUSTOMER);
                oDb.AddInParameter(cmd, "@PK_CustomerID", DbType.Int32, objCustomer.CustomerID);
                oDb.AddInParameter(cmd, "@CustomerName", DbType.String, objCustomer.CustomerName);
                oDb.AddInParameter(cmd, "@CustomerCode", DbType.String, objCustomer.CustomerCode);
                oDb.AddInParameter(cmd, "@Address", DbType.String, objCustomer.Address);
                oDb.AddInParameter(cmd, "@MobileNo", DbType.String, objCustomer.MobileNo);
                oDb.AddInParameter(cmd, "@AlternateNo", DbType.String, objCustomer.AlternateNo);
                oDb.AddInParameter(cmd, "@Email", DbType.String, objCustomer.Email);
                oDb.AddInParameter(cmd, "@GSTNo", DbType.String, objCustomer.GSTNo);
                oDb.AddInParameter(cmd, "@IsActive", DbType.Boolean, objCustomer.IsActive);
                oDb.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objCustomer.ModifiedBy.UserID);
                oDb.AddInParameter(cmd, "@FK_StateID", DbType.String, objCustomer.State.StateID);
                oDb.AddInParameter(cmd, "@Pincode", DbType.String, objCustomer.Pincode);
                iID = oDb.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Customer UpdateCustomer | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteCustomer(int ID, int UserID)
        {
            bool IsDeleted = false;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsDeleted = DeleteCustomer(oDb, ID, UserID, oTrans);
                    oTrans.Commit();

                    if (IsDeleted) Framework.InsertAuditLog("tCustomer", "PK_CustomerID", ID.ToString(), (char)Entity.Common.DatabaseAction.DELETE, UserID);
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
        private static bool DeleteCustomer(Database oDb, int ID, int UserID, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_CUSTOMER);
                oDb.AddInParameter(cmd, "@PK_CustomerID", DbType.Int32, ID);
                iRemoveId = oDb.ExecuteNonQuery(cmd);
                if (iRemoveId != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Customer DeleteCustomer | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    }
}
