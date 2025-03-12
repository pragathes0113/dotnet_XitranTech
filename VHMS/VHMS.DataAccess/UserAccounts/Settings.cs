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
    public class Settings
    {
        public static Entity.Settings GetSettings(int CompanyID)
        {
            string sException = string.Empty;
            Database db;
            Entity.Settings objSettings = new Entity.Settings();

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_SETTING_NOTIFICATION);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, CompanyID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objSettings = new Entity.Settings();

                        objSettings.MaxDiscountPercent = Convert.ToDecimal(drData["MaxDiscountPercent"]);
                        objSettings.SendSMS = Convert.ToBoolean(drData["SendSMS"]);
                        objSettings.SenderName = Convert.ToString(drData["SenderName"]);
                        objSettings.APILink = Convert.ToString(drData["APILink"]);
                        objSettings.SMSUsername = Convert.ToString(drData["SMSUsername"]);
                        objSettings.SMSPassword = Convert.ToString(drData["SMSPassword"]);
                        objSettings.MaxSalesDiscount = Convert.ToDecimal(drData["MaxSalesDiscount"]);
                        objSettings.SalesTaxAmount = Convert.ToDecimal(drData["SalesTaxAmount"]);
                        objSettings.WholeSaleMinMargin = Convert.ToDecimal(drData["WholeSale_MinMargin"]);
                        objSettings.RetailMinMargin = Convert.ToDecimal(drData["Retail_MinMargin"]);
                        objSettings.EnableSSL = Convert.ToBoolean(drData["EnableSSL"]);
                        objSettings.DefaultCrendentials = Convert.ToBoolean(drData["DefaultCrendentials"]);
                        objSettings.HostName = Convert.ToString(drData["HostName"]);                        
                        objSettings.UserMailPassword = Convert.ToString(drData["UserMailPassword"]);
                        objSettings.UserMailID = Convert.ToString(drData["UserMailID"]);
                        objSettings.Port = Convert.ToString(drData["Port"]);
                        objSettings.CompanyName = Convert.ToString(drData["CompanyName"]);

                        objSettings.TermsAndConditions = Convert.ToString(drData["TermsAndConditions"]);
                        objSettings.AdditionalNotes = Convert.ToString(drData["AdditionalNotes"]);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "Settings GetSettingsByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objSettings;
        }
        public static bool UpdateSettings(Entity.Settings objSettings)
        {
            bool IsUpdated = true;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsUpdated = UpdateSettings(oDb, objSettings, oTrans);
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
        private static bool UpdateSettings(Database oDb, Entity.Settings objSettings, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            Database db;
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_SETTINGS_NOTIFICATION);
                db.AddInParameter(cmd, "@MaxDiscountPercent", DbType.Decimal, objSettings.MaxDiscountPercent);
                db.AddInParameter(cmd, "@MaxSalesDiscount", DbType.Decimal, objSettings.MaxSalesDiscountPercent);
                db.AddInParameter(cmd, "@SendSMS", DbType.Boolean, objSettings.SendSMS);
                db.AddInParameter(cmd, "@SMSPassword", DbType.String, objSettings.SMSPassword);
                db.AddInParameter(cmd, "@SMSUsername", DbType.String, objSettings.SMSUsername);
                db.AddInParameter(cmd, "@SenderName", DbType.String, objSettings.SenderName);
                db.AddInParameter(cmd, "@APILink", DbType.String, objSettings.APILink);
                db.AddInParameter(cmd, "@SalesTaxAmount", DbType.Decimal, objSettings.SalesTaxAmount);
                db.AddInParameter(cmd, "@WholeSale_MinMargin", DbType.Decimal, objSettings.WholeSaleMinMargin);
                db.AddInParameter(cmd, "@Retail_MinMargin", DbType.Decimal, objSettings.RetailMinMargin);
                db.AddInParameter(cmd, "@EnableSSL", DbType.Boolean, objSettings.EnableSSL);
                db.AddInParameter(cmd, "@DefaultCrendentials", DbType.Boolean, objSettings.DefaultCrendentials);
                db.AddInParameter(cmd, "@HostName", DbType.String, objSettings.HostName);
                db.AddInParameter(cmd, "@Port", DbType.String, objSettings.Port);
                db.AddInParameter(cmd, "@UserMailID", DbType.String, objSettings.UserMailID);
                db.AddInParameter(cmd, "@TermsAndConditions", DbType.String, objSettings.TermsAndConditions);
                db.AddInParameter(cmd, "@AdditionalNotes", DbType.String, objSettings.AdditionalNotes);
                db.AddInParameter(cmd, "@UserMailPassword", DbType.String, objSettings.UserMailPassword);

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
