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
    public class Dashboard
    {
        public static Entity.Dashboard GetDashboardCount(int iCompanyID)
        {
            string sException = string.Empty;
            Database db;
            Entity.Dashboard objDashboard = new Entity.Dashboard();

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_DASHBOARDCOUNT);
                db.AddInParameter(cmd, "@FK_CompanyID", DbType.Int32, iCompanyID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objDashboard = new Entity.Dashboard();
                        objDashboard.CountValue = 1;

                        objDashboard.TotalCustomer = Convert.ToInt32(drData["TotalCustomer"]);
                        objDashboard.TotalSupplier = Convert.ToInt32(drData["TotalSupplier"]);
                        objDashboard.TotalSales = Convert.ToInt32(drData["TotalSales"]);
                        objDashboard.TotalPurchase = Convert.ToInt32(drData["TotalPurchase"]);
                        objDashboard.TotalProducts = Convert.ToInt32(drData["TotalProducts"]);
                        objDashboard.Saleduration = Convert.ToString(drData["Saleduration"]);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Dashboard GetDashboardCount | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objDashboard;
        }
        
    }
}
