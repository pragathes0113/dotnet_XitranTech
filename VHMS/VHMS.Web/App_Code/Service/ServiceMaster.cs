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

    #region "Service"
    public string GetService(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Service> ObjList = new Collection<VHMS.Entity.Service>();
                ObjList = VHMS.DataAccess.Service.GetService(ID);
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
            sException = "Service GetService |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetServiceInvoice(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Service> ObjList = new Collection<VHMS.Entity.Service>();
                ObjList = VHMS.DataAccess.Service.GetServiceInvoice(ID);
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
            sException = "Service GetService |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetTopService(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Service> ObjList = new Collection<VHMS.Entity.Service>();
                ObjList = VHMS.DataAccess.Service.GetTopService(ID);
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
            sException = "Service GetService |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetServiceByStatus(string ID = "")
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Service> ObjList = new Collection<VHMS.Entity.Service>();
                ObjList = VHMS.DataAccess.Service.GetServiceByStatus(ID);
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
            sException = "Service GetService |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetSearchService(string ID = "")
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Service> ObjList = new Collection<VHMS.Entity.Service>();
                ObjList = VHMS.DataAccess.Service.GetSearchService(ID);
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
            sException = "Service GetService |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetSearchServiceByStatus(string ID = "", int serviceDCID=0, string Status="")
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Service> ObjList = new Collection<VHMS.Entity.Service>();
                ObjList = VHMS.DataAccess.Service.GetSearchServiceByStatus(ID, serviceDCID, Status);
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
            sException = "Service GetService |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetSearchServiceInwardByStatus(string ID = "", int serviceDCID = 0, string Status = "")
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Service> ObjList = new Collection<VHMS.Entity.Service>();
                ObjList = VHMS.DataAccess.Service.GetSearchServiceInwardByStatus(ID, serviceDCID, Status);
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
            sException = "Service GetService |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetServiceByID(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Service ObjList = new VHMS.Entity.Service();
                ObjList = VHMS.DataAccess.Service.GetServiceByID(ID);
                objResponse.Status = "Success";
                if (ObjList.ServiceID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(ObjList);
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
            sException = "Service GetService |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string AddService(VHMS.Entity.Service Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iServiceId = 0;
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;

                iServiceId = VHMS.DataAccess.Service.AddService(Objdata);
                if (iServiceId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iServiceId.ToString();
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
            sException = "Service AddService |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Service_A_01")
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
    public string UpdateService(VHMS.Entity.Service Objdata)
    {
        string sServiceId = string.Empty;
        string sException = string.Empty;
        bool bService = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int UserId = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = UserId;
                Objdata.ModifiedBy = objUser;
                bService = VHMS.DataAccess.Service.UpdateService(Objdata);
                if (bService == true)
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
            sException = "Service UpdateService |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Service_U_01")
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

    public string AddServiceInvoice(VHMS.Entity.Service Objdata)
    {
        string sServiceId = string.Empty;
        string sException = string.Empty;
        bool bService = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int UserId = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = UserId;
                Objdata.ModifiedBy = objUser;
                bService = VHMS.DataAccess.Service.AddServiceInvoice(Objdata);
                if (bService == true)
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
            sException = "Service UpdateService |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Service_U_01")
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
    public string DeleteService(int ID)
    {
        string sServiceId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bService = false;
        try
        {
            int UserId = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserId))
            {
                bService = VHMS.DataAccess.Service.DeleteService(ID, UserId);
                if (bService == true)
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
            sException = "Service DeleteService |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Service_R_01" || ex.Message.ToString() == "Service_D_01")
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

    #region "ServiceDC"
    public string GetServiceDC(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.ServiceDC> ObjList = new Collection<VHMS.Entity.ServiceDC>();
                ObjList = VHMS.DataAccess.ServiceDC.GetServiceDC(ID);
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
            sException = "ServiceDC GetServiceDC |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetTopServiceDC(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.ServiceDC> ObjList = new Collection<VHMS.Entity.ServiceDC>();
                ObjList = VHMS.DataAccess.ServiceDC.GetTopServiceDC(ID);
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
            sException = "ServiceDC GetServiceDC |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string SearchServiceDC(string ID = "")
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.ServiceDC> ObjList = new Collection<VHMS.Entity.ServiceDC>();
                ObjList = VHMS.DataAccess.ServiceDC.SearchServiceDC(ID);
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
            sException = "ServiceDC GetServiceDC |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }


    public string GetServiceDCByID(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.ServiceDC ObjList = new VHMS.Entity.ServiceDC();
                ObjList = VHMS.DataAccess.ServiceDC.GetServiceDCByID(ID);
                objResponse.Status = "Success";
                if (ObjList.ServiceDCID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(ObjList);
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
            sException = "ServiceDC GetServiceDC |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string AddServiceDC(VHMS.Entity.ServiceDC Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iServiceDCId = 0;
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;

                iServiceDCId = VHMS.DataAccess.ServiceDC.AddServiceDC(Objdata);
                if (iServiceDCId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iServiceDCId.ToString();
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
            sException = "ServiceDC AddServiceDC |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "ServiceDC_A_01")
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
    public string UpdateServiceDC(VHMS.Entity.ServiceDC Objdata)
    {
        string sServiceDCId = string.Empty;
        string sException = string.Empty;
        bool bServiceDC = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int UserId = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = UserId;
                Objdata.ModifiedBy = objUser;
                bServiceDC = VHMS.DataAccess.ServiceDC.UpdateServiceDC(Objdata);
                if (bServiceDC == true)
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
            sException = "ServiceDC UpdateServiceDC |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "ServiceDC_U_01")
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
    public string DeleteServiceDC(int ID)
    {
        string sServiceDCId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bServiceDC = false;
        try
        {
            int UserId = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserId))
            {
                bServiceDC = VHMS.DataAccess.ServiceDC.DeleteServiceDC(ID, UserId);
                if (bServiceDC == true)
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
            sException = "ServiceDC DeleteServiceDC |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "ServiceDC_R_01" || ex.Message.ToString() == "ServiceDC_D_01")
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

    #region "ServiceInward"
    public string GetServiceInward(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.ServiceInward> ObjList = new Collection<VHMS.Entity.ServiceInward>();
                ObjList = VHMS.DataAccess.ServiceInward.GetServiceInward(ID);
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
            sException = "ServiceInward GetServiceInward |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetTopServiceInward(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.ServiceInward> ObjList = new Collection<VHMS.Entity.ServiceInward>();
                ObjList = VHMS.DataAccess.ServiceInward.GetTopServiceInward(ID);
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
            sException = "ServiceInward GetServiceInward |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string SearchServiceInward(string ID = "")
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.ServiceInward> ObjList = new Collection<VHMS.Entity.ServiceInward>();
                ObjList = VHMS.DataAccess.ServiceInward.SearchServiceInward(ID);
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
            sException = "ServiceInward GetServiceInward |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }


    public string GetServiceInwardByID(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.ServiceInward ObjList = new VHMS.Entity.ServiceInward();
                ObjList = VHMS.DataAccess.ServiceInward.GetServiceInwardByID(ID);
                objResponse.Status = "Success";
                if (ObjList.ServiceInwardID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(ObjList);
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
            sException = "ServiceInward GetServiceInward |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string AddServiceInward(VHMS.Entity.ServiceInward Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iServiceInwardId = 0;
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;

                iServiceInwardId = VHMS.DataAccess.ServiceInward.AddServiceInward(Objdata);
                if (iServiceInwardId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iServiceInwardId.ToString();
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
            sException = "ServiceInward AddServiceInward |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "ServiceInward_A_01")
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
    public string UpdateServiceInward(VHMS.Entity.ServiceInward Objdata)
    {
        string sServiceInwardId = string.Empty;
        string sException = string.Empty;
        bool bServiceInward = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int UserId = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = UserId;
                Objdata.ModifiedBy = objUser;
                bServiceInward = VHMS.DataAccess.ServiceInward.UpdateServiceInward(Objdata);
                if (bServiceInward == true)
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
            sException = "ServiceInward UpdateServiceInward |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "ServiceInward_U_01")
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
    public string DeleteServiceInward(int ID)
    {
        string sServiceInwardId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bServiceInward = false;
        try
        {
            int UserId = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserId))
            {
                bServiceInward = VHMS.DataAccess.ServiceInward.DeleteServiceInward(ID, UserId);
                if (bServiceInward == true)
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
            sException = "ServiceInward DeleteServiceInward |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "ServiceInward_R_01" || ex.Message.ToString() == "ServiceInward_D_01")
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