using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.Data;
using System.Web;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using VHMS.Entity;

public partial class VHMSService : IVHMSService
{
    #region "NewCustomer"
    public string GetAllCustomer()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.NewCustomer> ObjList = new Collection<VHMS.Entity.Billing.NewCustomer>();
                ObjList = VHMS.DataAccess.Billing.NewCustomer.GetAllCustomer();
                objResponse.Status = "Success";
                objResponse.Value = ObjList.Count > 0 ? jsObject.Serialize(ObjList) : "NoRecord";
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "VHMSService.Billing.NewCustomer GetNewCustomer |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetNewCustomerByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Billing.NewCustomer objNewCustomer = new VHMS.Entity.Billing.NewCustomer();
                objNewCustomer = VHMS.DataAccess.Billing.NewCustomer.GetNewCustomerByID(ID);
                if (objNewCustomer.CustomerID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objNewCustomer);
                }
                else
                {
                    objResponse.Status = "Success";
                    objResponse.Value = "NoRecord";
                }
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "VHMSService.Billing.NewCustomer GetNewCustomerByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddNewCustomer(VHMS.Entity.Billing.NewCustomer Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iNewCustomerId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;
                iNewCustomerId = VHMS.DataAccess.Billing.NewCustomer.AddNewCustomer(Objdata);
                if (iNewCustomerId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iNewCustomerId.ToString();
                }
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "VHMSService.Billing.NewCustomer AddNewCustomer |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "NewCustomer_A_01")
            {
                objResponse.Status = "Error";
                objResponse.Value = ex.Message.ToString();
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "Error";
            }
        }
        return jsonObject.Serialize(objResponse);
    }
    public string UpdateNewCustomer(VHMS.Entity.Billing.NewCustomer Objdata)
    {
        string sNewCustomerId = string.Empty;
        string sException = string.Empty;
        bool bNewCustomer = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = UserID;
                Objdata.ModifiedBy = objUser;
                bNewCustomer = VHMS.DataAccess.Billing.NewCustomer.UpdateNewCustomer(Objdata);
                if (bNewCustomer == true)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = "1";
                }
                else
                {
                    objResponse.Status = "Success";
                    objResponse.Value = "0";
                }
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "VHMSService.Billing.NewCustomer UpdateNewCustomer |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "NewCustomer_U_01")
            {
                objResponse.Status = "Error";
                objResponse.Value = ex.Message.ToString();
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        return jsonObject.Serialize(objResponse);
    }
    public string DeleteNewCustomer(int ID)
    {
        string sNewCustomerId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bNewCustomer = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bNewCustomer = VHMS.DataAccess.Billing.NewCustomer.DeleteNewCustomer(ID, UserID);
                if (bNewCustomer == true)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = "1";
                }
                else
                {
                    objResponse.Status = "Success";
                    objResponse.Value = "0";
                }
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "VHMSService.Billing.NewCustomer DeleteNewCustomer |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "NewCustomer_R_01" || ex.Message.ToString() == "NewCustomer_D_01")
            {
                objResponse.Status = "Error";
                objResponse.Value = ex.Message.ToString();
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        return jsonObject.Serialize(objResponse);
    }
    #endregion

    #region "HouseType"
    public string GetHouseType()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.HouseType> ObjList = new Collection<VHMS.Entity.Billing.HouseType>();
                ObjList = VHMS.DataAccess.Billing.HouseType.GetHouseType();
                objResponse.Status = "Success";
                objResponse.Value = ObjList.Count > 0 ? jsObject.Serialize(ObjList) : "NoRecord";
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "VHMSService.Billing.HouseType GetHouseType |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetHouseTypeByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Billing.HouseType objHouseType = new VHMS.Entity.Billing.HouseType();
                objHouseType = VHMS.DataAccess.Billing.HouseType.GetHouseTypeByID(ID);
                if (objHouseType.HouseTypeID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objHouseType);
                }
                else
                {
                    objResponse.Status = "Success";
                    objResponse.Value = "NoRecord";
                }
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "VHMSService.Billing.HouseType GetHouseTypeByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddHouseType(VHMS.Entity.Billing.HouseType Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iHouseTypeId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;
                iHouseTypeId = VHMS.DataAccess.Billing.HouseType.AddHouseType(Objdata);
                if (iHouseTypeId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iHouseTypeId.ToString();
                }
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "VHMSService.Billing.HouseType AddHouseType |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "HouseType_A_01")
            {
                objResponse.Status = "Error";
                objResponse.Value = ex.Message.ToString();
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "Error";
            }
        }
        return jsonObject.Serialize(objResponse);
    }
    public string UpdateHouseType(VHMS.Entity.Billing.HouseType Objdata)
    {
        string sHouseTypeId = string.Empty;
        string sException = string.Empty;
        bool bHouseType = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = UserID;
                Objdata.ModifiedBy = objUser;
                bHouseType = VHMS.DataAccess.Billing.HouseType.UpdateHouseType(Objdata);
                if (bHouseType == true)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = "1";
                }
                else
                {
                    objResponse.Status = "Success";
                    objResponse.Value = "0";
                }
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "VHMSService.Billing.HouseType UpdateHouseType |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "HouseType_U_01")
            {
                objResponse.Status = "Error";
                objResponse.Value = ex.Message.ToString();
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        return jsonObject.Serialize(objResponse);
    }
    public string DeleteHouseType(int ID)
    {
        string sHouseTypeId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bHouseType = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bHouseType = VHMS.DataAccess.Billing.HouseType.DeleteHouseType(ID, UserID);
                if (bHouseType == true)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = "1";
                }
                else
                {
                    objResponse.Status = "Success";
                    objResponse.Value = "0";
                }
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "VHMSService.Billing.HouseType DeleteHouseType |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "HouseType_R_01" || ex.Message.ToString() == "HouseType_D_01")
            {
                objResponse.Status = "Error";
                objResponse.Value = ex.Message.ToString();
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        return jsonObject.Serialize(objResponse);
    }
    #endregion

}