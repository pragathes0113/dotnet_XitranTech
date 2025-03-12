using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.ObjectModel;
using VHMS;

namespace VHMS.DAL
{
    public class Company
    {
        public static Collection<Entity.Company> GetCompany()
        {
            string sException = string.Empty;
            Database db;
            Collection<Entity.Company> objList = new Collection<Entity.Company>();
            Entity.Company objCompany = new Entity.Company();
            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_COMPANY);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCompany = new Entity.Company();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objCompany.CompanyID = Convert.ToInt32(drData["PK_CompanyID"]);
                        objCompany.CompanyName = Convert.ToString(drData["CompanyName"]);
                        objCompany.CompanyCode = Convert.ToString(drData["CompanyCode"]);
                        objCompany.CompanyAddress = Convert.ToString(drData["CompanyAddress"]);
                        objCompany.ContactPerson = Convert.ToString(drData["ContactPerson"]);
                        objCompany.ContactNo = Convert.ToString(drData["ContactNo"]);
                        objCompany.PhoneNo1 = Convert.ToString(drData["PhoneNo1"]);
                        objCompany.PhoneNo2 = Convert.ToString(drData["PhoneNo2"]);
                        objCompany.LandLine = Convert.ToString(drData["Landline"]);
                        objCompany.Fax = Convert.ToString(drData["Fax"]);
                        objCompany.Email = Convert.ToString(drData["Email"]);
                        objCompany.WebSite = Convert.ToString(drData["Website"]);
                        objCompany.TINNo = Convert.ToString(drData["TINNo"]);
                        objCompany.CSTNo = Convert.ToString(drData["CSTNo"]);
                        objCompany.BankName = Convert.ToString(drData["BankName"]);
                        objCompany.BranchName = Convert.ToString(drData["BranchName"]);
                        objCompany.AccountNo = Convert.ToString(drData["AccountNo"]);
                        objCompany.IFSCCode = Convert.ToString(drData["IFSCCode"]);
                        objCompany.FinancialYear = Convert.ToString(drData["Financial_Year"]);
                        objList.Add(objCompany);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Company GetCompanyByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }

        public static Entity.Company GetCompanyByID(int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            Entity.Company objCompany = new Entity.Company();
            Entity.User objCreatedUser;
            Entity.User objModifiedUser;

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_COMPANY);
                db.AddInParameter(cmd, "@PK_CompanyID", DbType.Int32, CompanyID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objCompany = new Entity.Company();
                        objCreatedUser = new Entity.User();
                        objModifiedUser = new Entity.User();

                        objCompany.CompanyID = Convert.ToInt32(drData["PK_CompanyID"]);
                        objCompany.CompanyName = Convert.ToString(drData["CompanyName"]);
                        objCompany.CompanyCode = Convert.ToString(drData["CompanyCode"]);
                        objCompany.CompanyAddress = Convert.ToString(drData["CompanyAddress"]);
                        objCompany.ContactPerson = Convert.ToString(drData["ContactPerson"]);
                        objCompany.ContactNo = Convert.ToString(drData["ContactNo"]);
                        objCompany.PhoneNo1 = Convert.ToString(drData["PhoneNo1"]);
                        objCompany.PhoneNo2 = Convert.ToString(drData["PhoneNo2"]);
                        objCompany.LandLine = Convert.ToString(drData["Landline"]);
                        objCompany.Fax = Convert.ToString(drData["Fax"]);
                        objCompany.Email = Convert.ToString(drData["Email"]);
                        objCompany.WebSite = Convert.ToString(drData["Website"]);
                        objCompany.TINNo = Convert.ToString(drData["TINNo"]);
                        objCompany.CSTNo = Convert.ToString(drData["CSTNo"]);
                        objCompany.BankName = Convert.ToString(drData["BankName"]);
                        objCompany.BranchName = Convert.ToString(drData["BranchName"]);
                        objCompany.AccountNo = Convert.ToString(drData["AccountNo"]);
                        objCompany.IFSCCode = Convert.ToString(drData["IFSCCode"]);
                        objCompany.FinancialYear = Convert.ToString(drData["Financial_Year"]);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Company GetCompanyByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objCompany;
        }

        public static int AddCompany(Entity.Company objCompany)
        {
            string sException = string.Empty;
            int iID = 0;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_COMPANY);
                db.AddOutParameter(cmd, "@PK_CompanyID", DbType.Int32, objCompany.CompanyID);
                db.AddInParameter(cmd, "@CompanyName", DbType.String, objCompany.CompanyName);
                db.AddInParameter(cmd, "@CompanyCode", DbType.String, objCompany.CompanyCode);
                db.AddInParameter(cmd, "@CompanyAddress", DbType.String, objCompany.CompanyAddress);
                db.AddInParameter(cmd, "@ContactPerson", DbType.String, objCompany.ContactPerson);
                db.AddInParameter(cmd, "@ContactNo", DbType.String, objCompany.ContactNo);
                db.AddInParameter(cmd, "@PhoneNo1", DbType.String, objCompany.PhoneNo1);
                db.AddInParameter(cmd, "@PhoneNo2", DbType.String, objCompany.PhoneNo2);
                db.AddInParameter(cmd, "@Landline", DbType.String, objCompany.LandLine);
                db.AddInParameter(cmd, "@Fax", DbType.String, objCompany.Fax);
                db.AddInParameter(cmd, "@Email", DbType.String, objCompany.Email);
                db.AddInParameter(cmd, "@Website", DbType.String, objCompany.WebSite);
                db.AddInParameter(cmd, "@TINNo", DbType.String, objCompany.TINNo);
                db.AddInParameter(cmd, "@CSTNo", DbType.String, objCompany.CSTNo);
                db.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objCompany.CreatedBy.UserID);
                db.AddInParameter(cmd, "@BankName", DbType.String, objCompany.BankName);
                db.AddInParameter(cmd, "@BranchName", DbType.String, objCompany.BranchName);
                db.AddInParameter(cmd, "@AccountNo", DbType.String, objCompany.AccountNo);
                db.AddInParameter(cmd, "@IFSCCode", DbType.String, objCompany.IFSCCode);
                db.AddInParameter(cmd, "@Financial_Year", DbType.String, objCompany.FinancialYear);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0)
                    iID = Convert.ToInt32(db.GetParameterValue(cmd, "@PK_CompanyID"));
            }
            catch (Exception ex)
            {
                sException = "Company AddCompany | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateCompany(Entity.Company objCompany)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_COMPANY);
                db.AddInParameter(cmd, "@PK_CompanyID", DbType.Int32, objCompany.CompanyID);
                db.AddInParameter(cmd, "@CompanyName", DbType.String, objCompany.CompanyName);
                db.AddInParameter(cmd, "@CompanyCode", DbType.String, objCompany.CompanyCode);
                db.AddInParameter(cmd, "@CompanyAddress", DbType.String, objCompany.CompanyAddress);
                db.AddInParameter(cmd, "@ContactPerson", DbType.String, objCompany.ContactPerson);
                db.AddInParameter(cmd, "@ContactNo", DbType.String, objCompany.ContactNo);
                db.AddInParameter(cmd, "@PhoneNo1", DbType.String, objCompany.PhoneNo1);
                db.AddInParameter(cmd, "@PhoneNo2", DbType.String, objCompany.PhoneNo2);
                db.AddInParameter(cmd, "@Landline", DbType.String, objCompany.LandLine);
                db.AddInParameter(cmd, "@Fax", DbType.String, objCompany.Fax);
                db.AddInParameter(cmd, "@Email", DbType.String, objCompany.Email);
                db.AddInParameter(cmd, "@Website", DbType.String, objCompany.WebSite);
                db.AddInParameter(cmd, "@TINNo", DbType.String, objCompany.TINNo);
                db.AddInParameter(cmd, "@CSTNo", DbType.String, objCompany.CSTNo);
                db.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objCompany.ModifiedBy.UserID);
                db.AddInParameter(cmd, "@BankName", DbType.String, objCompany.BankName);
                db.AddInParameter(cmd, "@BranchName", DbType.String, objCompany.BranchName);
                db.AddInParameter(cmd, "@AccountNo", DbType.String, objCompany.AccountNo);
                db.AddInParameter(cmd, "@IFSCCode", DbType.String, objCompany.IFSCCode);
                db.AddInParameter(cmd, "@Financial_Year", DbType.String, objCompany.FinancialYear);

                iID = db.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "Company UpdateCompany| " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    
    }
}
