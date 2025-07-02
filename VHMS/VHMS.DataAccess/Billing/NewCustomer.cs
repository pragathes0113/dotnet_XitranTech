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
    public class NewCustomer
    {
        public static Collection<Entity.Billing.NewCustomer> GetAllCustomer()
        {
            string sException = string.Empty;
            Database db;
            DataSet dsList = null;
            Collection<Entity.Billing.NewCustomer> objList = new Collection<Entity.Billing.NewCustomer>();
            Entity.Billing.HouseType ObjHouseType = new Entity.Billing.HouseType();

            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_NEWCUSTOMER);
                dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsList.Tables[0].Rows)
                    {
                        Entity.Billing.NewCustomer obj = new Entity.Billing.NewCustomer();
                        ObjHouseType = new Entity.Billing.HouseType();


                        obj.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                        obj.CustomerName = Convert.ToString(dr["CustomerName"]);
                        obj.MobileNo = Convert.ToString(dr["MobileNo"]);
                        ObjHouseType.HouseTypeID = Convert.ToInt32(dr["FK_HouseTypeID"]);
                        ObjHouseType.HouseTypeName = Convert.ToString(dr["HouseTypeName"]);
                        obj.HouseType = ObjHouseType;

                        obj.CurrentAddress = Convert.ToString(dr["CurrentAddress"]);
                        obj.ShiftingAddress = Convert.ToString(dr["ShiftingAddress"]);
                        obj.PackingDate = Convert.ToDateTime(dr["PackingDate"]);
                        obj.ReachingDate = Convert.ToDateTime(dr["ReachingDate"]);
                        obj.Kms = Convert.ToString(dr["Kms"]);
                        obj.TypeofMove = Convert.ToString(dr["TypeofMove"]);

                        obj.RequiresMoreThanTwoPersons = Convert.ToBoolean(dr["RequiresMoreThanTwoPersons"]);
                        obj.RequiresMoreThanTwoPersonsRate = Convert.ToDecimal(dr["RequiresMoreThanTwoPersonsRate"]);
                        obj.HasStaircase = Convert.ToBoolean(dr["HasStaircase"]);
                        obj.HasStaircaseRate = Convert.ToDecimal(dr["HasStaircaseRate"]);
                        obj.HasServiceElevator = Convert.ToBoolean(dr["HasServiceElevator"]);
                        obj.HasServiceElevatorRate = Convert.ToDecimal(dr["HasServiceElevatorRate"]);
                        obj.HasProperParking = Convert.ToBoolean(dr["HasProperParking"]);
                        obj.HasProperParkingRate = Convert.ToDecimal(dr["HasProperParkingRate"]);
                        obj.AdditionalChargeForLongWalks = Convert.ToBoolean(dr["AdditionalChargeForLongWalks"]);
                        obj.AdditionalChargeForLongWalksRate = Convert.ToDecimal(dr["AdditionalChargeForLongWalksRate"]);
                        obj.WantsPackingHelp = Convert.ToBoolean(dr["WantsPackingHelp"]);
                        obj.WantsPackingHelpRate = Convert.ToDecimal(dr["WantsPackingHelpRate"]);
                        obj.PackingHandledByTeam = Convert.ToBoolean(dr["PackingHandledByTeam"]);
                        obj.PackingHandledByTeamRate = Convert.ToDecimal(dr["PackingHandledByTeamRate"]);
                        obj.NeedsPackingMaterials = Convert.ToBoolean(dr["NeedsPackingMaterials"]);
                        obj.NeedsPackingMaterialsRate = Convert.ToDecimal(dr["NeedsPackingMaterialsRate"]);
                        obj.HasFragileItems = Convert.ToBoolean(dr["HasFragileItems"]);
                        obj.HasFragileItemsRate = Convert.ToDecimal(dr["HasFragileItemsRate"]);
                        obj.HasHazardousItems = Convert.ToBoolean(dr["HasHazardousItems"]);
                        obj.HasHazardousItemsRate = Convert.ToDecimal(dr["HasHazardousItemsRate"]);
                        obj.HasInventoryList = Convert.ToBoolean(dr["HasInventoryList"]);
                        obj.HasInventoryListRate = Convert.ToDecimal(dr["HasInventoryListRate"]);
                        obj.InventoryListNote = Convert.ToBoolean(dr["InventoryListNote"]);
                        obj.InventoryListNoteRate = Convert.ToDecimal(dr["InventoryListNoteRate"]);
                        obj.HasPiano = Convert.ToBoolean(dr["HasPiano"]);
                        obj.HasPianoRate = Convert.ToDecimal(dr["HasPianoRate"]);
                        obj.AdditionalChargeForPiano = Convert.ToBoolean(dr["AdditionalChargeForPiano"]);
                        obj.AdditionalChargeForPianoRate = Convert.ToDecimal(dr["AdditionalChargeForPianoRate"]);
                        obj.HasVehicleToMove = Convert.ToBoolean(dr["HasVehicleToMove"]);
                        obj.HasVehicleToMoveRate = Convert.ToDecimal(dr["HasVehicleToMoveRate"]);
                        obj.VehicleType = Convert.ToBoolean(dr["VehicleType"]);
                        obj.VehicleTypeRate = Convert.ToDecimal(dr["VehicleTypeRate"]);
                        obj.NeedsTowVanOrDriver = Convert.ToBoolean(dr["NeedsTowVanOrDriver"]);
                        obj.NeedsTowVanOrDriverRate = Convert.ToDecimal(dr["NeedsTowVanOrDriverRate"]);
                        obj.NeedsJunkRemoval = Convert.ToBoolean(dr["NeedsJunkRemoval"]);
                        obj.NeedsJunkRemovalRate = Convert.ToDecimal(dr["NeedsJunkRemovalRate"]);
                        obj.RequiresOvernightStop = Convert.ToBoolean(dr["RequiresOvernightStop"]);
                        obj.RequiresOvernightStopRate = Convert.ToDecimal(dr["RequiresOvernightStopRate"]);

                        objList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Billing.NewCustomer GetAll | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return objList;
        }
        public static Entity.Billing.NewCustomer GetNewCustomerByID(int iNewCustomerID)
        {
            string sException = string.Empty;
            Database db;
            Entity.Billing.NewCustomer obj = new Entity.Billing.NewCustomer();
            Entity.Billing.HouseType ObjHouseType = new Entity.Billing.HouseType();
            try
            {
                db = Entity.DBConnection.dbCon;
                DbCommand cmd = db.GetStoredProcCommand(constants.StoredProcedures.USP_SELECT_HOUSETYPE);
                db.AddInParameter(cmd, "@PK_CustomerNameID", DbType.Int32, iNewCustomerID);
                DataSet dsList = db.ExecuteDataSet(cmd);

                if (dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsList.Tables[0].Rows)
                    {
                        obj = new Entity.Billing.NewCustomer();
                        ObjHouseType = new Entity.Billing.HouseType();


                        obj.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                        obj.CustomerName = Convert.ToString(dr["CustomerName"]);
                        obj.MobileNo = Convert.ToString(dr["MobileNo"]);
                        ObjHouseType.HouseTypeID = Convert.ToInt32(dr["FK_HouseTypeID"]);
                        ObjHouseType.HouseTypeName = Convert.ToString(dr["HouseTypeName"]);
                        obj.HouseType = ObjHouseType;

                        obj.CurrentAddress = Convert.ToString(dr["CurrentAddress"]);
                        obj.ShiftingAddress = Convert.ToString(dr["ShiftingAddress"]);
                        obj.PackingDate = Convert.ToDateTime(dr["PackingDate"]);
                        obj.ReachingDate = Convert.ToDateTime(dr["ReachingDate"]);
                        obj.Kms = Convert.ToString(dr["Kms"]);
                        obj.TypeofMove = Convert.ToString(dr["TypeofMove"]);

                        obj.RequiresMoreThanTwoPersons = Convert.ToBoolean(dr["RequiresMoreThanTwoPersons"]);
                        obj.RequiresMoreThanTwoPersonsRate = Convert.ToDecimal(dr["RequiresMoreThanTwoPersonsRate"]);
                        obj.HasStaircase = Convert.ToBoolean(dr["HasStaircase"]);
                        obj.HasStaircaseRate = Convert.ToDecimal(dr["HasStaircaseRate"]);
                        obj.HasServiceElevator = Convert.ToBoolean(dr["HasServiceElevator"]);
                        obj.HasServiceElevatorRate = Convert.ToDecimal(dr["HasServiceElevatorRate"]);
                        obj.HasProperParking = Convert.ToBoolean(dr["HasProperParking"]);
                        obj.HasProperParkingRate = Convert.ToDecimal(dr["HasProperParkingRate"]);
                        obj.AdditionalChargeForLongWalks = Convert.ToBoolean(dr["AdditionalChargeForLongWalks"]);
                        obj.AdditionalChargeForLongWalksRate = Convert.ToDecimal(dr["AdditionalChargeForLongWalksRate"]);
                        obj.WantsPackingHelp = Convert.ToBoolean(dr["WantsPackingHelp"]);
                        obj.WantsPackingHelpRate = Convert.ToDecimal(dr["WantsPackingHelpRate"]);
                        obj.PackingHandledByTeam = Convert.ToBoolean(dr["PackingHandledByTeam"]);
                        obj.PackingHandledByTeamRate = Convert.ToDecimal(dr["PackingHandledByTeamRate"]);
                        obj.NeedsPackingMaterials = Convert.ToBoolean(dr["NeedsPackingMaterials"]);
                        obj.NeedsPackingMaterialsRate = Convert.ToDecimal(dr["NeedsPackingMaterialsRate"]);
                        obj.HasFragileItems = Convert.ToBoolean(dr["HasFragileItems"]);
                        obj.HasFragileItemsRate = Convert.ToDecimal(dr["HasFragileItemsRate"]);
                        obj.HasHazardousItems = Convert.ToBoolean(dr["HasHazardousItems"]);
                        obj.HasHazardousItemsRate = Convert.ToDecimal(dr["HasHazardousItemsRate"]);
                        obj.HasInventoryList = Convert.ToBoolean(dr["HasInventoryList"]);
                        obj.HasInventoryListRate = Convert.ToDecimal(dr["HasInventoryListRate"]);
                        obj.InventoryListNote = Convert.ToBoolean(dr["InventoryListNote"]);
                        obj.InventoryListNoteRate = Convert.ToDecimal(dr["InventoryListNoteRate"]);
                        obj.HasPiano = Convert.ToBoolean(dr["HasPiano"]);
                        obj.HasPianoRate = Convert.ToDecimal(dr["HasPianoRate"]);
                        obj.AdditionalChargeForPiano = Convert.ToBoolean(dr["AdditionalChargeForPiano"]);
                        obj.AdditionalChargeForPianoRate = Convert.ToDecimal(dr["AdditionalChargeForPianoRate"]);
                        obj.HasVehicleToMove = Convert.ToBoolean(dr["HasVehicleToMove"]);
                        obj.HasVehicleToMoveRate = Convert.ToDecimal(dr["HasVehicleToMoveRate"]);
                        obj.VehicleType = Convert.ToBoolean(dr["VehicleType"]);
                        obj.VehicleTypeRate = Convert.ToDecimal(dr["VehicleTypeRate"]);
                        obj.NeedsTowVanOrDriver = Convert.ToBoolean(dr["NeedsTowVanOrDriver"]);
                        obj.NeedsTowVanOrDriverRate = Convert.ToDecimal(dr["NeedsTowVanOrDriverRate"]);
                        obj.NeedsJunkRemoval = Convert.ToBoolean(dr["NeedsJunkRemoval"]);
                        obj.NeedsJunkRemovalRate = Convert.ToDecimal(dr["NeedsJunkRemovalRate"]);
                        obj.RequiresOvernightStop = Convert.ToBoolean(dr["RequiresOvernightStop"]);
                        obj.RequiresOvernightStopRate = Convert.ToDecimal(dr["RequiresOvernightStopRate"]);
                    }
                }
            }
            catch (Exception ex)
            {
                sException = "VHMS.DataAccess.Billing.HouseType GetHouseTypeByID | " + ex.ToString();
                Log.Write(sException);
                throw;
            }
            return obj;
        }
        public static int AddNewCustomer(Entity.Billing.NewCustomer objCustomer)
        {
            int ID = 0;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    ID = AddNewCustomer(oDb, objCustomer, oTrans);
                    oTrans.Commit();
                    if (ID > 0)
                        Framework.InsertAuditLog("tNewCustomer", "CustomerID", ID.ToString(), (char)Entity.Common.DatabaseAction.INSERT, objCustomer.CreatedBy.UserID);
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

        private static int AddNewCustomer(Database oDb, Entity.Billing.NewCustomer objCustomer, DbTransaction oTrans)
        {
            int iID = 0;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_INSERT_NEWCUSTOMER);
                oDb.AddOutParameter(cmd, "@PK_CustomerNameID", DbType.Int32, objCustomer.CustomerID);
                oDb.AddInParameter(cmd, "@CustomerName", DbType.String, objCustomer.CustomerName);
                oDb.AddInParameter(cmd, "@MobileNo", DbType.String, objCustomer.MobileNo);
                oDb.AddInParameter(cmd, "@FK_HouseTypeID", DbType.Int32, objCustomer.HouseType.HouseTypeID);
                oDb.AddInParameter(cmd, "@CurrentAddress", DbType.String, objCustomer.CurrentAddress);
                oDb.AddInParameter(cmd, "@ShiftingAddress", DbType.String, objCustomer.ShiftingAddress);
                oDb.AddInParameter(cmd, "@PackingDate", DbType.DateTime, objCustomer.PackingDate);
                oDb.AddInParameter(cmd, "@ReachingDate", DbType.DateTime, objCustomer.ReachingDate);
                oDb.AddInParameter(cmd, "@Kms", DbType.String, objCustomer.Kms);
                oDb.AddInParameter(cmd, "@TypeofMove", DbType.String, objCustomer.TypeofMove);
                oDb.AddInParameter(cmd, "@RequiresMoreThanTwoPersons", DbType.Boolean, objCustomer.RequiresMoreThanTwoPersons);
                oDb.AddInParameter(cmd, "@RequiresMoreThanTwoPersonsRate", DbType.Decimal, objCustomer.RequiresMoreThanTwoPersonsRate);
                oDb.AddInParameter(cmd, "@HasStaircase", DbType.Boolean, objCustomer.HasStaircase);
                oDb.AddInParameter(cmd, "@HasStaircaseRate", DbType.Decimal, objCustomer.HasStaircaseRate);
                oDb.AddInParameter(cmd, "@HasServiceElevator", DbType.Boolean, objCustomer.HasServiceElevator);
                oDb.AddInParameter(cmd, "@HasServiceElevatorRate", DbType.Decimal, objCustomer.HasServiceElevatorRate);
                oDb.AddInParameter(cmd, "@HasProperParking", DbType.Boolean, objCustomer.HasProperParking);
                oDb.AddInParameter(cmd, "@HasProperParkingRate", DbType.Decimal, objCustomer.HasProperParkingRate);
                oDb.AddInParameter(cmd, "@AdditionalChargeForLongWalks", DbType.Boolean, objCustomer.AdditionalChargeForLongWalks);
                oDb.AddInParameter(cmd, "@AdditionalChargeForLongWalksRate", DbType.Decimal, objCustomer.AdditionalChargeForLongWalksRate);
                oDb.AddInParameter(cmd, "@WantsPackingHelp", DbType.Boolean, objCustomer.WantsPackingHelp);
                oDb.AddInParameter(cmd, "@WantsPackingHelpRate", DbType.Decimal, objCustomer.WantsPackingHelpRate);
                oDb.AddInParameter(cmd, "@PackingHandledByTeam", DbType.Boolean, objCustomer.PackingHandledByTeam);
                oDb.AddInParameter(cmd, "@PackingHandledByTeamRate", DbType.Decimal, objCustomer.PackingHandledByTeamRate);
                oDb.AddInParameter(cmd, "@NeedsPackingMaterials", DbType.Boolean, objCustomer.NeedsPackingMaterials);
                oDb.AddInParameter(cmd, "@NeedsPackingMaterialsRate", DbType.Decimal, objCustomer.NeedsPackingMaterialsRate);
                oDb.AddInParameter(cmd, "@HasFragileItems", DbType.Boolean, objCustomer.HasFragileItems);
                oDb.AddInParameter(cmd, "@HasFragileItemsRate", DbType.Decimal, objCustomer.HasFragileItemsRate);
                oDb.AddInParameter(cmd, "@HasHazardousItems", DbType.Boolean, objCustomer.HasHazardousItems);
                oDb.AddInParameter(cmd, "@HasHazardousItemsRate", DbType.Decimal, objCustomer.HasHazardousItemsRate);
                oDb.AddInParameter(cmd, "@HasInventoryList", DbType.Boolean, objCustomer.HasInventoryList);
                oDb.AddInParameter(cmd, "@HasInventoryListRate", DbType.Decimal, objCustomer.HasInventoryListRate);
                oDb.AddInParameter(cmd, "@InventoryListNote", DbType.Boolean, objCustomer.InventoryListNote);
                oDb.AddInParameter(cmd, "@InventoryListNoteRate", DbType.Decimal, objCustomer.InventoryListNoteRate);
                oDb.AddInParameter(cmd, "@HasPiano", DbType.Boolean, objCustomer.HasPiano);
                oDb.AddInParameter(cmd, "@HasPianoRate", DbType.Decimal, objCustomer.HasPianoRate);
                oDb.AddInParameter(cmd, "@AdditionalChargeForPiano", DbType.Boolean, objCustomer.AdditionalChargeForPiano);
                oDb.AddInParameter(cmd, "@AdditionalChargeForPianoRate", DbType.Decimal, objCustomer.AdditionalChargeForPianoRate);
                oDb.AddInParameter(cmd, "@HasVehicleToMove", DbType.Boolean, objCustomer.HasVehicleToMove);
                oDb.AddInParameter(cmd, "@HasVehicleToMoveRate", DbType.Decimal, objCustomer.HasVehicleToMoveRate);
                oDb.AddInParameter(cmd, "@VehicleType", DbType.Boolean, objCustomer.VehicleType);
                oDb.AddInParameter(cmd, "@VehicleTypeRate", DbType.Decimal, objCustomer.VehicleTypeRate);
                oDb.AddInParameter(cmd, "@NeedsTowVanOrDriver", DbType.Boolean, objCustomer.NeedsTowVanOrDriver);
                oDb.AddInParameter(cmd, "@NeedsTowVanOrDriverRate", DbType.Decimal, objCustomer.NeedsTowVanOrDriverRate);
                oDb.AddInParameter(cmd, "@NeedsJunkRemoval", DbType.Boolean, objCustomer.NeedsJunkRemoval);
                oDb.AddInParameter(cmd, "@NeedsJunkRemovalRate", DbType.Decimal, objCustomer.NeedsJunkRemovalRate);
                oDb.AddInParameter(cmd, "@RequiresOvernightStop", DbType.Boolean, objCustomer.RequiresOvernightStop);
                oDb.AddInParameter(cmd, "@RequiresOvernightStopRate", DbType.Decimal, objCustomer.RequiresOvernightStopRate);
                oDb.AddInParameter(cmd, "@FK_CreatedBy", DbType.Int32, objCustomer.CreatedBy.UserID);

                iID = oDb.ExecuteNonQuery(cmd, oTrans);
                if (iID != 0)
                {
                    iID = Convert.ToInt32(oDb.GetParameterValue(cmd, "@PK_CustomerNameID"));
                    objCustomer.CustomerID = iID;
                }
            }
            catch (Exception ex)
            {
                Log.Write("VHMS.DataAccess.Billing.NewCustomer AddNewCustomer | " + ex.ToString());
                throw;
            }
            return iID;
        }

        public static bool UpdateNewCustomer(Entity.Billing.NewCustomer objCustomer)
        {
            bool IsUpdated = true;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsUpdated = UpdateNewCustomer(oDb, objCustomer, oTrans);
                    oTrans.Commit();
                    if (IsUpdated)
                        Framework.InsertAuditLog("tNewCustomer", "CustomerID", objCustomer.CustomerID.ToString(), (char)Entity.Common.DatabaseAction.UPDATE, objCustomer.ModifiedBy.UserID);
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

        private static bool UpdateNewCustomer(Database oDb, Entity.Billing.NewCustomer objCustomer, DbTransaction oTrans)
        {
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_UPDATE_NEWCUSTOMER);
                oDb.AddInParameter(cmd, "@PK_CustomerNameID", DbType.Int32, objCustomer.CustomerID);
                oDb.AddInParameter(cmd, "@CustomerName", DbType.String, objCustomer.CustomerName);
                oDb.AddInParameter(cmd, "@MobileNo", DbType.String, objCustomer.MobileNo);
                oDb.AddInParameter(cmd, "@FK_HouseTypeID", DbType.Int32, objCustomer.HouseType.HouseTypeID);
                // Add all other parameters...
                oDb.AddInParameter(cmd, "@FK_ModifiedBy", DbType.Int32, objCustomer.ModifiedBy.UserID);

                int iID = oDb.ExecuteNonQuery(cmd);
                if (iID != 0) bResult = true;
            }
            catch (Exception ex)
            {
                Log.Write("VHMS.DataAccess.Billing.NewCustomer UpdateNewCustomer | " + ex.ToString());
                throw;
            }
            return bResult;
        }

        public static bool DeleteNewCustomer(int ID, int UserID)
        {
            bool IsDeleted = false;
            Database oDb = Entity.DBConnection.dbCon;
            using (DbConnection oDbCon = oDb.CreateConnection())
            {
                oDbCon.Open();
                DbTransaction oTrans = oDbCon.BeginTransaction();
                try
                {
                    IsDeleted = DeleteNewCustomer(oDb, ID, UserID, oTrans);
                    oTrans.Commit();
                    if (IsDeleted)
                        Framework.InsertAuditLog("tNewCustomer", "CustomerID", ID.ToString(), (char)Entity.Common.DatabaseAction.DELETE, UserID);
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

        private static bool DeleteNewCustomer(Database oDb, int ID, int UserID, DbTransaction oTrans)
        {
            bool bResult = false;
            try
            {
                DbCommand cmd = oDb.GetStoredProcCommand(constants.StoredProcedures.USP_DELETE_NEWCUSTOMER);
                oDb.AddInParameter(cmd, "@PK_CustomerNameID", DbType.Int32, ID);
                int iRemoveId = oDb.ExecuteNonQuery(cmd);
                if (iRemoveId != 0) bResult = true;
            }
            catch (Exception ex)
            {
                Log.Write("VHMS.DataAccess.Billing.NewCustomer DeleteNewCustomer | " + ex.ToString());
                throw;
            }
            return bResult;
        }
    }
}
