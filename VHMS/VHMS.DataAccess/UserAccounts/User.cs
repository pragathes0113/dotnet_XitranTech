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
    public class User
    {
        public static DataSet GetMenuList()
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            try
            {
                db = Entity.DBConnection.dbCon;
                dsList = db.ExecuteDataSet(CommandType.Text, "SELECT * FROM tMenuSection Where IsActive=1  ORDER BY MenuName");
            }
            catch (Exception ex)
            {
                sException = "User GetMenuSection() | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return dsList;
        }
        public static DataSet GetModuleList(int MenuID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            string sSql = string.Empty;
            try
            {
                db = Entity.DBConnection.dbCon;
                sSql = "SELECT * FROM tModule WHERE FK_MenuID=" + MenuID + " and OrderNo>0 ORDER BY ModuleName";

                dsList = db.ExecuteDataSet(CommandType.Text, sSql);
            }
            catch (Exception ex)
            {
                sException = "User GetModuleName | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return dsList;
        }
        public static DataSet GetMenuandModule(int MenuID = 0)
        {
            Database db;
            DataSet dsList = null;
            string sException = string.Empty;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_MODULE);
                db.AddInParameter(cmd, "@FK_MenuID", DbType.Int32, MenuID);
                dsList = db.ExecuteDataSet(cmd);
            }
            catch (Exception ex)
            {
                sException = "User GetMenuandModule | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return dsList;
        }
        public static Entity.User GetUserLogin(string sUserName, string sPassword,int CompanyID, string sIPAddress, string clientIp)
        {
            string sException = string.Empty;
            Database db;
            Entity.User ObjUser = new Entity.User();
            Entity.Company ObjCompany = new Entity.Company();
            Entity.Settings ObjSettings;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_USERLOGIN);
                db.AddInParameter(cmd, "@username", DbType.String, sUserName);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                db.AddInParameter(cmd, "@password", DbType.String, CommonMethods.Security.Encrypt(sPassword, true));
                DataSet dsList = db.ExecuteDataSet(cmd);
                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drrow in dsList.Tables[0].Rows)
                    {
                        ObjUser = new Entity.User();
                        ObjCompany = new Entity.Company();
                        ObjSettings = new Entity.Settings();
                        ObjUser.UserID = Convert.ToInt32(drrow["PK_UserID"]);
                        ObjUser.UserName = drrow["UserName"].ToString();
                        ObjUser.Password = CommonMethods.Security.Decrypt(drrow["Password"].ToString(), true);
                        ObjUser.RoleID = Convert.ToInt32(drrow["FK_RoleID"]);
                        ObjUser.RoleName = drrow["RoleName"].ToString();
                        ObjUser.EmployeeName = Convert.ToString(drrow["EmployeeName"]).ToString();
                        ObjSettings.SendSMS = Convert.ToBoolean(drrow["SendSMS"]);
                        ObjSettings.SMSUsername = Convert.ToString(drrow["SMSUsername"]);
                        ObjSettings.SMSPassword = Convert.ToString(drrow["SMSPassword"]);
                        ObjSettings.SenderName = Convert.ToString(drrow["SenderName"]);
                        ObjSettings.APILink = Convert.ToString(drrow["APILink"]);
                        ObjUser.Settings = ObjSettings;
                        ObjCompany.CompanyID = Convert.ToInt32(drrow["FK_CompanyID"]);
                        ObjCompany.CompanyName = Convert.ToString(drrow["CompanyName"]);
                        ObjUser.Company = ObjCompany;
                    }
                    int i = AddLog(sIPAddress, ObjUser.UserID, clientIp);
                }
            }
            catch (Exception ex)
            {
                sException = "User GetUserLogin | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return ObjUser;
        }
        public static Collection<Entity.User> GetUser(int RegionID, int ZoneID)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.User> objList = new Collection<Entity.User>();
            Entity.User objUser = new Entity.User();
            Entity.Company ObjCompany = new Entity.Company();

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_USER);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objUser = new Entity.User();
                        ObjCompany = new Entity.Company();
                        objUser.UserID = Convert.ToInt32(drData["PK_UserID"]);
                        objUser.UserName = Convert.ToString(drData["UserName"]);
                        objUser.Email = Convert.ToString(drData["Email"]);
                        objUser.RoleID = Convert.ToInt32(drData["FK_RoleID"]);
                        objUser.RoleName = Convert.ToString(drData["RoleName"]);
                        objUser.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objUser.Password = CommonMethods.Security.Decrypt(drData["Password"].ToString(), true);
                        objUser.EmployeeName = Convert.ToString(drData["EmployeeName"]);
                        objUser.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objUser.IDProof = Convert.ToString(drData["IDProof"]);
                        objUser.EmployeeCode = Convert.ToString(drData["EmployeeCode"]);
                        objUser.BasicPay = Convert.ToDecimal(drData["BasicPay"]);
                        objUser.DOB = Convert.ToDateTime(drData["DOB"]);
                        objUser.sDOB = objUser.DOB.ToString("dd/MM/yyyy");
                        objUser.DOJ = Convert.ToDateTime(drData["DOJ"]);
                        objUser.sDOJ = objUser.DOJ.ToString("dd/MM/yyyy");
                        objUser.Address = Convert.ToString(drData["Address"]);
                        objUser.ConfirmPassword = CommonMethods.Security.Decrypt(drData["ConfirmPassword"].ToString(), true);
                        ObjCompany.CompanyID = Convert.ToInt32(drData["FK_CompanyID"]);
                        ObjCompany.CompanyName = Convert.ToString(drData["CompanyName"]);
                        objUser.Company = ObjCompany;
                        objList.Add(objUser);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "User GetUser | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Collection<Entity.User> GetBranchUser(int iBranchID=0)
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.User> objList = new Collection<Entity.User>();
            Entity.User objUser = new Entity.User();
             
            
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_USER);
                db.AddInParameter(cmd, "@FK_BranchID", DbType.Int32, iBranchID);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objUser = new Entity.User();
                        objUser.UserID = Convert.ToInt32(drData["PK_UserID"]);
                        objUser.UserName = Convert.ToString(drData["UserName"]);
                        objUser.Email = Convert.ToString(drData["Email"]);
                        objUser.RoleID = Convert.ToInt32(drData["FK_RoleID"]);
                        objUser.RoleName = Convert.ToString(drData["RoleName"]);
                        objUser.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objUser.Password = CommonMethods.Security.Decrypt(drData["Password"].ToString(), true);
                        objUser.EmployeeName = Convert.ToString(drData["EmployeeName"]);
                        objUser.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objUser.IDProof = Convert.ToString(drData["IDProof"]);
                        objUser.EmployeeCode = Convert.ToString(drData["EmployeeCode"]);
                        objUser.BasicPay = Convert.ToDecimal(drData["BasicPay"]);
                        objUser.DOB = Convert.ToDateTime(drData["DOB"]);
                        objUser.sDOB = objUser.DOB.ToString("dd/MM/yyyy");
                        objUser.DOJ = Convert.ToDateTime(drData["DOJ"]);
                        objUser.sDOJ = objUser.DOJ.ToString("dd/MM/yyyy");
                        objUser.Address = Convert.ToString(drData["Address"]);
                        objUser.ConfirmPassword = CommonMethods.Security.Decrypt(drData["ConfirmPassword"].ToString(), true);
                        objList.Add(objUser);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "User GetUser | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Entity.User GetUserByID(int iUserID)
        {
            string sException = string.Empty;
            Database db;
            Entity.User objUser = new Entity.User();
            Entity.Company ObjCompany = new Entity.Company();

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_USER);
                db.AddInParameter(cmd, "@PK_UserID", DbType.Int32, iUserID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objUser = new Entity.User();
                        
                        objUser.UserID = Convert.ToInt32(drData["PK_UserID"]);
                        objUser.UserName = Convert.ToString(drData["UserName"]);
                        objUser.Email = Convert.ToString(drData["Email"]);
                        objUser.RoleID = Convert.ToInt32(drData["FK_RoleID"]);
                        objUser.RoleName = Convert.ToString(drData["RoleName"]);
                        objUser.IsActive = Convert.ToBoolean(drData["IsActive"]);
                        objUser.Password = CommonMethods.Security.Decrypt(drData["Password"].ToString(), true);
                        objUser.EmployeeName = Convert.ToString(drData["EmployeeName"]);
                        objUser.MobileNo = Convert.ToString(drData["MobileNo"]);
                        objUser.IDProof = Convert.ToString(drData["IDProof"]);
                        objUser.EmployeeCode = Convert.ToString(drData["EmployeeCode"]);
                        objUser.BasicPay = Convert.ToDecimal(drData["BasicPay"]);
                        objUser.DOB = Convert.ToDateTime(drData["DOB"]);
                        objUser.sDOB = objUser.DOB.ToString("dd/MM/yyyy");
                        objUser.DOJ = Convert.ToDateTime(drData["DOJ"]);
                        objUser.sDOJ = objUser.DOJ.ToString("dd/MM/yyyy");
                        objUser.Address = Convert.ToString(drData["Address"]);
                        ObjCompany.CompanyID = Convert.ToInt32(drData["FK_CompanyID"]);
                        ObjCompany.CompanyName = Convert.ToString(drData["CompanyName"]);
                        objUser.Company = ObjCompany;
                        objUser.ConfirmPassword = CommonMethods.Security.Decrypt(drData["ConfirmPassword"].ToString(), true);

                    }
                }
            }
            catch (Exception ex)
            {
                sException = "User GetUserByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objUser;
        }
        public static int AddUser(Entity.User objUser)
        {
            int ID = 0;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    ID = AddUser(oDb, objUser, oTrans);
                    oTrans.Commit();
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
        private static int AddUser(Database oDb, Entity.User objUser, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_USER);
                oDb.AddOutParameter(cmd, "@PK_UserID", DbType.Int32, objUser.UserID);
                oDb.AddInParameter(cmd, "@UserName", DbType.String, objUser.UserName);
                oDb.AddInParameter(cmd, "@Password", DbType.String, CommonMethods.Security.Encrypt(objUser.Password, true));
                oDb.AddInParameter(cmd, "@Email", DbType.String, objUser.Email);
                oDb.AddInParameter(cmd, "@IsActive", DbType.Boolean, objUser.IsActive);
                oDb.AddInParameter(cmd, "@FK_RoleID", DbType.Int32, objUser.RoleID);
                oDb.AddInParameter(cmd, "@EmployeeName", DbType.String, objUser.EmployeeName);
                oDb.AddInParameter(cmd, "@EmployeeCode", DbType.String, objUser.EmployeeCode);
               // oDb.AddInParameter(cmd, "@SalesManCode", DbType.String, objUser.SalesManCode);
                oDb.AddInParameter(cmd, "@BasicPay", DbType.Decimal, objUser.BasicPay);
                oDb.AddInParameter(cmd, "@Address", DbType.String, objUser.Address);
                oDb.AddInParameter(cmd, "@ConfirmPassword", DbType.String, CommonMethods.Security.Encrypt(objUser.ConfirmPassword, true));
                oDb.AddInParameter(cmd, "@DOB", DbType.String, objUser.sDOB);
                oDb.AddInParameter(cmd, "@DOJ", DbType.String, objUser.sDOJ);
                oDb.AddInParameter(cmd, "@MobileNo", DbType.String, objUser.MobileNo);
                oDb.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objUser.Company.CompanyID);
                oDb.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objUser.CreatedBy.UserID);
                oDb.AddInParameter(cmd, "@IDProof", DbType.String, objUser.IDProof);


                iID = oDb.ExecuteNonQuery(cmd, oTrans);
                if (iID != 0) iID = Convert.ToInt32(oDb.GetParameterValue(cmd, "@PK_UserID"));
            }
            catch (Exception ex)
            {
                sException = "User AddUser | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateUser(Entity.User objUser)
        {
            bool IsUpdated = true;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsUpdated = UpdateUser(oDb, objUser, oTrans);
                    oTrans.Commit();
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
        private static bool UpdateUser(Database oDb, Entity.User objUser, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_USER);
                oDb.AddInParameter(cmd, "@PK_UserID", DbType.Int32, objUser.UserID);
                oDb.AddInParameter(cmd, "@UserName", DbType.String, objUser.UserName);
                oDb.AddInParameter(cmd, "@Password", DbType.String, CommonMethods.Security.Encrypt(objUser.Password, true));
                oDb.AddInParameter(cmd, "@Email", DbType.String, objUser.Email);
                oDb.AddInParameter(cmd, "@IsActive", DbType.Boolean, objUser.IsActive);
                oDb.AddInParameter(cmd, "@FK_RoleID", DbType.Int32, objUser.RoleID);
                oDb.AddInParameter(cmd, "@EmployeeName", DbType.String, objUser.EmployeeName);
                oDb.AddInParameter(cmd, "@EmployeeCode", DbType.String, objUser.EmployeeCode);
              //  oDb.AddInParameter(cmd, "@SalesManCode", DbType.String, objUser.SalesManCode);
                oDb.AddInParameter(cmd, "@BasicPay", DbType.Decimal, objUser.BasicPay);
                oDb.AddInParameter(cmd, "@Address", DbType.String, objUser.Address);
                oDb.AddInParameter(cmd, "@ConfirmPassword", DbType.String, CommonMethods.Security.Encrypt(objUser.ConfirmPassword, true));
                oDb.AddInParameter(cmd, "@DOB", DbType.String, objUser.sDOB);
                oDb.AddInParameter(cmd, "@DOJ", DbType.String, objUser.sDOJ);
                oDb.AddInParameter(cmd, "@MobileNo", DbType.String, objUser.MobileNo);
                oDb.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, objUser.Company.CompanyID);
                oDb.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objUser.ModifiedBy.UserID);
                oDb.AddInParameter(cmd, "@IDProof", DbType.String, objUser.IDProof);


                iID = oDb.ExecuteNonQuery(cmd, oTrans);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "User UpdateUser| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteUser(int ID)
        {
            bool IsDeleted = false;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsDeleted = DeleteUser(oDb, ID, oTrans);
                    oTrans.Commit();
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
        private static bool DeleteUser(Database oDb, int ID, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_USER);
                oDb.AddInParameter(cmd, "@PK_UserID", DbType.Int32, ID);
                iRemoveId = oDb.ExecuteNonQuery(cmd, oTrans);
                if (iRemoveId != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "User DeleteUser | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool ChangePassword(Entity.User objUser)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_CHANGEPASSWORD);
                db.AddInParameter(cmd, "@PK_UserID", DbType.Int32, objUser.UserID);
                db.AddInParameter(cmd, "@OldPassword", DbType.String, CommonMethods.Security.Encrypt(objUser.OldPassword, true));
                db.AddInParameter(cmd, "@NewPassword", DbType.String, CommonMethods.Security.Encrypt(objUser.Password, true));
                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "User ChangePassword| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static int AddLog(string sIPAddresss, int iUserID, string clientIp)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbLogCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_LOG);
                //db.AddInParameter(cmd, "@LogInDateTime", DbType.String, DateTime.Now.AddHours(5).AddMinutes(30).AddSeconds(DateTime.Now.Second).ToString("dd/MM/yyyy HH:mm:ss"));
                db.AddInParameter(cmd, "@IPAddress", DbType.String, sIPAddresss);
                db.AddInParameter(cmd, "@UserID", DbType.Int32, iUserID);
                db.AddInParameter(cmd, "@LocalIPAddress", DbType.String, clientIp);
                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = 1;
            }
            catch (Exception ex)
            {
                sException = "User AddLog | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static void AddPageVisitLog(string sIPAddresss, int iUserID, string sURL)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbLogCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_VISITLOG);
                //db.AddInParameter(cmd, "@LogInDateTime", DbType.String, DateTime.Now.AddHours(5).AddMinutes(30).AddSeconds(DateTime.Now.Second).ToString("dd/MM/yyyy HH:mm:ss"));
                db.AddInParameter(cmd, "@IPAddress", DbType.String, sIPAddresss);
                db.AddInParameter(cmd, "@FK_UserID", DbType.Int32, iUserID);
                db.AddInParameter(cmd, "@URL", DbType.String, sURL);
                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) iID = 1;
            }
            catch (Exception ex)
            {
                sException = "User AddPageVisitLog | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            //return iID;
        }
        public static DataSet GetHomePageList()
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            try
            {
                db = Entity.DBConnection.dbCon;
                dsList = db.ExecuteDataSet(CommandType.Text, "SELECT * FROM tHomePage ORDER BY PageName");
            }
            catch (Exception ex)
            {
                sException = "User GetHomePageList() | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return dsList;
        }
        public static Collection<Entity.VisitLog> GetVisitLog()
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.VisitLog> objList = new Collection<Entity.VisitLog>();
            Entity.VisitLog objVisitLog;

            try
            {
                db = Entity.DBConnection.dbLogCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_VISITLOG);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objVisitLog = new Entity.VisitLog();

                        objVisitLog.PageLogID = Convert.ToInt32(drData["PK_PageLogID"]);
                        objVisitLog.VisitLogDateTime = Convert.ToDateTime(drData["VisitLogDateTime"]);
                        objVisitLog.sVisitLogDateTime = objVisitLog.VisitLogDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                        objVisitLog.IPAddress = Convert.ToString(drData["IPAddress"]);
                        objVisitLog.UserName = Convert.ToString(drData["UserName"]);
                        objVisitLog.URL = Convert.ToString(drData["URL"]);

                        objList.Add(objVisitLog);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "User GetVisitLog | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        //Added on 25-10-2017
        public static bool ResetPassword(int UserID, string sPassword)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_RESET_PASSWORD);
                db.AddInParameter(cmd, "@PK_UserID", DbType.Int32, UserID);
                db.AddInParameter(cmd, "@UserPassword", DbType.String, CommonMethods.Security.Encrypt(sPassword, true));                
                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "User ResetPassword| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    }
}
