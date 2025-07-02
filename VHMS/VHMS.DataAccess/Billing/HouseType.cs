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
    public class HouseType
    {
        public static Collection<Entity.Billing.HouseType> GetHouseType()
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.HouseType> objList = new Collection<Entity.Billing.HouseType>();
            Entity.Billing.HouseType objHouseType = new Entity.Billing.HouseType();

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_HOUSETYPE);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objHouseType = new Entity.Billing.HouseType();

                        objHouseType.HouseTypeID = Convert.ToInt32(drData["PK_HouseTypeID"]);
                        objHouseType.HouseTypeName = Convert.ToString(drData["HouseTypeName"]);
                        objHouseType.IsActive = Convert.ToBoolean(drData["IsActive"]);

                        objList.Add(objHouseType);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Billing.HouseType GetHouseType | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Entity.Billing.HouseType GetHouseTypeByID(int iHouseTypeID)
        {
            string sException = string.Empty;
            Database db;
            Entity.Billing.HouseType objHouseType = new Entity.Billing.HouseType();

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_HOUSETYPE);
                db.AddInParameter(cmd, "@PK_HouseTypeID", DbType.Int32, iHouseTypeID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drData in dsList.Tables[0].Rows)
                    {
                        objHouseType = new Entity.Billing.HouseType();
                        objHouseType.HouseTypeID = Convert.ToInt32(drData["PK_HouseTypeID"]);
                        objHouseType.HouseTypeName = Convert.ToString(drData["HouseTypeName"]);
                        objHouseType.IsActive = Convert.ToBoolean(drData["IsActive"]);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Billing.HouseType GetHouseTypeByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objHouseType;
        }
        public static int AddHouseType(Entity.Billing.HouseType objHouseType)
        {
            int ID = 0;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    ID = AddHouseType(oDb, objHouseType, oTrans);
                    oTrans.Commit();
                    if (ID > 0)
                        Framework.InsertAuditLog("tHouseType", "PK_HouseTypeID", objHouseType.HouseTypeID.ToString(), (char)Entity.Common.DatabaseAction.INSERT, objHouseType.CreatedBy.UserID);
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
        private static int AddHouseType(Database oDb, Entity.Billing.HouseType objHouseType, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_HOUSETYPE);
                oDb.AddOutParameter(cmd, "@PK_HouseTypeID", DbType.Int32, objHouseType.HouseTypeID);
                oDb.AddInParameter(cmd, "@HouseTypeName", DbType.String, objHouseType.HouseTypeName);
                oDb.AddInParameter(cmd, "@IsActive", DbType.Boolean, objHouseType.IsActive);
                oDb.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objHouseType.CreatedBy.UserID);

                iID = oDb.ExecuteNonQuery(cmd, oTrans);
                if (iID != 0)
                {
                    iID = Convert.ToInt32(oDb.GetParameterValue(cmd, "@PK_HouseTypeID"));
                    objHouseType.HouseTypeID = iID;
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Billing.HouseType AddHouseType | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return iID;
        }
        public static bool UpdateHouseType(Entity.Billing.HouseType objHouseType)
        {
            bool IsUpdated = true;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsUpdated = UpdateHouseType(oDb, objHouseType, oTrans);
                    oTrans.Commit();
                    if (IsUpdated) Framework.InsertAuditLog("tHouseType", "PK_HouseTypeID", objHouseType.HouseTypeID.ToString(), (char)Entity.Common.DatabaseAction.UPDATE, objHouseType.ModifiedBy.UserID);
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
        private static bool UpdateHouseType(Database oDb, Entity.Billing.HouseType objHouseType, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iID = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_HOUSETYPE);
                oDb.AddInParameter(cmd, "@PK_HouseTypeID", DbType.Int32, objHouseType.HouseTypeID);
                oDb.AddInParameter(cmd, "@HouseTypeName", DbType.String, objHouseType.HouseTypeName);
                oDb.AddInParameter(cmd, "@IsActive", DbType.Boolean, objHouseType.IsActive);
                oDb.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objHouseType.ModifiedBy.UserID);

                iID = oDb.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Billing.HouseType UpdateHouseType | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
        public static bool DeleteHouseType(int ID, int UserID)
        {
            bool IsDeleted = false;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsDeleted = DeleteHouseType(oDb, ID, UserID, oTrans);
                    oTrans.Commit();

                    if (IsDeleted) Framework.InsertAuditLog("tHouseType", "PK_HouseTypeID", ID.ToString(), (char)Entity.Common.DatabaseAction.DELETE, UserID);
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
        private static bool DeleteHouseType(Database oDb, int ID, int UserID, DbTransaction oTrans)
        {
            string sException = string.Empty;
            int iRemoveId = 0;
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_HOUSETYPE);
                oDb.AddInParameter(cmd, "@PK_HouseTypeID", DbType.Int32, ID);
                iRemoveId = oDb.ExecuteNonQuery(cmd);
                if (iRemoveId != 0) bResult = true;
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Billing.HouseType DeleteHouseType | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return bResult;
        }
    }
}
