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

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public partial class VHMSService : IVHMSService
{
    #region "STATIC METHODS"
    public bool ValidateSession()
    {
        bool status = false;
        //  int test = Convert.ToInt32(HttpContext.Current.Session["UserID"]);

        if ((HttpContext.Current.Session["UserID"] != null && Convert.ToInt32(HttpContext.Current.Session["UserID"]) > 0) || (HttpContext.Current.Request.QueryString["mobileview"] != null && HttpContext.Current.Request.QueryString["id"] != null))
        {
            status = true;

            if (HttpContext.Current.Request.QueryString["mobileview"] != null && HttpContext.Current.Request.QueryString["id"] != null)
            {
                HttpContext.Current.Session["UserID"] = HttpContext.Current.Request.QueryString["id"];
                HttpContext.Current.Session["UserName"] = "Mobile";
                HttpContext.Current.Session["EmployeeName"] = "Mobile";
                HttpContext.Current.Session["BranchID"] = "0";
                HttpContext.Current.Session["RoleID"] = "0";
                HttpContext.Current.Session["RoleName"] = "Mobile";
                HttpContext.Current.Session["LogDateTime"] = DateTime.Now.ToString("");
                HttpContext.Current.Session["SMSUsername"] = "Mobile";
                HttpContext.Current.Session["SMSPassword"] = "Mobile";
                HttpContext.Current.Session["SenderName"] = "Mobile";
                HttpContext.Current.Session["SendSMS"] = "Mobile";
                HttpContext.Current.Session["APILink"] = "Mobile";
            }
        }
        else
            Log.Write("ValidateSession | UserID Session Expired");

        return status;
    }
    public static string GetDtJson(DataTable dt)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        serializer.MaxJsonLength = int.MaxValue;
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        return serializer.Serialize(rows);
    }
    public string GetSessionName(string sSessionName)
    {
        return HttpContext.Current.Session[sSessionName].ToString();
    }
    public string SetSessionValue(string sSessionName, Object ObjValue)
    {
        HttpContext.Current.Session[sSessionName] = ObjValue;
        return "true";
    }
    public static void ExporttoExcel(DataTable table, string sFileName)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + sFileName);

        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
        HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
          "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
          "style='font-size:12.0pt; font-family:Calibri; background:white;'> <TR>");
        //am getting my grid's column headers
        int columnscount = table.Columns.Count;

        for (int j = 0; j < columnscount; j++)
        {      //write in new column
            HttpContext.Current.Response.Write("<Th style='background:#E9F2Ed;'>");
            //Get column headers  and make it as bold in excel columns
            HttpContext.Current.Response.Write("<B>");
            HttpContext.Current.Response.Write(table.Columns[j].ToString());
            HttpContext.Current.Response.Write("</B>");
            HttpContext.Current.Response.Write("</Th>");
        }
        HttpContext.Current.Response.Write("</TR>");
        foreach (DataRow row in table.Rows)
        {//write in new row
            HttpContext.Current.Response.Write("<TR style='font-size:14.0pt; font-family:Calibri; background:white;'>");
            for (int i = 0; i < table.Columns.Count; i++)
            {
                HttpContext.Current.Response.Write("<Td>");
                HttpContext.Current.Response.Write(row[i].ToString());
                HttpContext.Current.Response.Write("</Td>");
            }

            HttpContext.Current.Response.Write("</TR>");
        }
        HttpContext.Current.Response.Write("</Table>");
        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }
    public static void AddPageVisitLog()
    {
        int iUserId = 0;

        if (HttpContext.Current.Request.QueryString["mobileview"] != null && HttpContext.Current.Request.QueryString["id"] != null)
        {
            HttpContext.Current.Session["UserID"] = HttpContext.Current.Request.QueryString["id"];
            HttpContext.Current.Session["UserName"] = "Mobile";
            HttpContext.Current.Session["EmployeeName"] = "Mobile";
            HttpContext.Current.Session["BranchID"] = "0";
            HttpContext.Current.Session["RoleID"] = "0";
            HttpContext.Current.Session["RoleName"] = "Mobile";
            HttpContext.Current.Session["LogDateTime"] = DateTime.Now.ToString("");
            HttpContext.Current.Session["SMSUsername"] = "Mobile";
            HttpContext.Current.Session["SMSPassword"] = "Mobile";
            HttpContext.Current.Session["SenderName"] = "Mobile";
            HttpContext.Current.Session["SendSMS"] = "Mobile";
            HttpContext.Current.Session["APILink"] = "Mobile";
        }


        if (Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
        {
            var url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            string sIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            VHMS.DataAccess.User.AddPageVisitLog(sIPAddress, iUserId, url.ToString());
        }
    }

    #endregion

    #region "Accounts"

    #region "Settings"
    public string GetSettings()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.Settings objUser = new VHMS.Entity.Settings();
                objUser = VHMS.DataAccess.Settings.GetSettings(iCompanyID);
                if (objUser.MaxDiscountPercent >= 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objUser);
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
            sException = "User GetSettings |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string UpdateSettings(VHMS.Entity.Settings Objdata)
    {
        string sUserId = string.Empty;
        string sException = string.Empty;
        bool bUser = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int UserId = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserId))
            {

                bUser = VHMS.DataAccess.Settings.UpdateSettings(Objdata);
                if (bUser == true)
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
            sException = "User UpdateSettings |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Settings_U_01")
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

    #region "SMSLog"
    public string AddSMSLog(VHMS.Entity.SMSLog Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;
                iUserId = VHMS.DataAccess.SMSLog.AddSMSLog(Objdata);
                if (iUserId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iUserId.ToString();
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
            sException = "SMSLog AddSMSLog |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "SMSLog_A_01")
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


    #endregion

    #region "User"


    public string GetMenu()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                DataSet dsList = VHMS.DataAccess.User.GetMenuList();
                objResponse.Status = "Success";
                objResponse.Value = dsList.Tables[0].Rows.Count > 0 ? GetDtJson(dsList.Tables[0]) : "NoRecord";
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "User GetMenu |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetModule(int iMenuID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                DataSet dsList = VHMS.DataAccess.User.GetModuleList(iMenuID);
                objResponse.Status = "Success";
                objResponse.Value = dsList.Tables[0].Rows.Count > 0 ? GetDtJson(dsList.Tables[0]) : "NoRecord";
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "User GetModule |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetUserLogin(string sUserName, string sPassword,int CompanyID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            string sIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            string clientIp = string.Empty;
            if (System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.Length > 2)
                clientIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[2].ToString();  // (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
            else
                clientIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1].ToString();

            VHMS.Entity.User ObjUser = new User();
            ObjUser = VHMS.DataAccess.User.GetUserLogin(sUserName, sPassword,CompanyID, sIPAddress, clientIp);
            if (ObjUser.UserID > 0)
            {
                objResponse.Status = "Success";
                objResponse.Value = jsObject.Serialize(ObjUser);
            }
            else
            {
                objResponse.Status = "Success";
                objResponse.Value = "NoRecord";
            }
        }
        catch (Exception ex)
        {
            sException = "User GetUserLogin |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetUser()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int RegionID = 0;
        int ZoneID = 0;
        try
        {
            if (ValidateSession())
            {
                int RoleID = Convert.ToInt32(HttpContext.Current.Session["RoleID"]);
                if (RoleID == 7)
                    RegionID = Convert.ToInt32(HttpContext.Current.Session["RegionID"]);
                else if (RoleID == 9)
                    ZoneID = Convert.ToInt32(HttpContext.Current.Session["ZoneID"]);
                Collection<VHMS.Entity.User> ObjList = new Collection<VHMS.Entity.User>();
                ObjList = VHMS.DataAccess.User.GetUser(RegionID, ZoneID);
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
            sException = "User GetUser |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetUserByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser = VHMS.DataAccess.User.GetUserByID(ID);
                if (objUser.UserID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objUser);
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
            sException = "User GetUserByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetUserPassword(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser = VHMS.DataAccess.User.GetUserByID(iUserId);
                if (objUser.UserID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objUser);
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
            sException = "User GetUserByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddUser(VHMS.Entity.User Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;
                iUserId = VHMS.DataAccess.User.AddUser(Objdata);
                if (iUserId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iUserId.ToString();
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
            sException = "User AddUser |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "User_A_01")
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
    public string UpdateUser(VHMS.Entity.User Objdata)
    {
        string sUserId = string.Empty;
        string sException = string.Empty;
        bool bUser = false;
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
                bUser = VHMS.DataAccess.User.UpdateUser(Objdata);
                if (bUser == true)
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
            sException = "User UpdateUser |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "User_U_01")
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
    public string DeleteUser(int ID)
    {
        string sUserId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bUser = false;
        try
        {
            if (ValidateSession())
            {
                bUser = VHMS.DataAccess.User.DeleteUser(ID);
                if (bUser == true)
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
            sException = "User DeleteUser |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "User_R_01" || ex.Message.ToString() == "User_D_01")
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
    public string ChangePassword(VHMS.Entity.User Objdata)
    {
        string sUserId = string.Empty;
        string sException = string.Empty;
        bool bUser = false;
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
                Objdata.UserID = UserId;
                bUser = VHMS.DataAccess.User.ChangePassword(Objdata);
                if (bUser == true)
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
            sException = "User ChanagePassword |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "ChangePassword_U_01")
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
    public string GetVisitLog()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.VisitLog> ObjList = new Collection<VHMS.Entity.VisitLog>();
                ObjList = VHMS.DataAccess.User.GetVisitLog();
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
            sException = "VisitLog GetVisitLog |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    //Added on 25-10-2017
    public string ResetPassword(int UserID, string sPassword)
    {
        string sUserId = string.Empty;
        string sException = string.Empty;
        bool bUser = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int UserId = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserId))
            {
                bUser = VHMS.DataAccess.User.ResetPassword(UserID, sPassword);
                if (bUser == true)
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
            sException = "User ResetPassword |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "0";
        }
        return jsonObject.Serialize(objResponse);
    }
    #endregion

    #region "Role"
    public string GetRole()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Role> ObjList = new Collection<VHMS.Entity.Role>();
                ObjList = VHMS.DataAccess.Role.GetRole();
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
            sException = "Role GetRole |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetRoleByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Role objRole = new VHMS.Entity.Role();
                objRole = VHMS.DataAccess.Role.GetRoleByID(ID);
                if (objRole.RoleID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objRole);
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
            sException = "Role GetRoleByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddRole(VHMS.Entity.Role Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iRoleId = 0;
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;
                iRoleId = VHMS.DataAccess.Role.AddRole(Objdata);
                if (iRoleId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iRoleId.ToString();
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
            sException = "Role AddRole |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Role_A_01")
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
    public string UpdateRole(VHMS.Entity.Role Objdata)
    {
        string sRoleId = string.Empty;
        string sException = string.Empty;
        bool bRole = false;
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
                bRole = VHMS.DataAccess.Role.UpdateRole(Objdata);
                if (bRole == true)
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
            sException = "Role UpdateRole |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Role_U_01")
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
    public string DeleteRole(int ID)
    {
        string sRoleId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bRole = false;
        try
        {
            if (ValidateSession())
            {
                bRole = VHMS.DataAccess.Role.DeleteRole(ID);
                if (bRole == true)
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
            sException = "Role DeleteRole |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Role_R_01" || ex.Message.ToString() == "Role_D_01")
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

    #region "Role Configuration"
    public string GetMenuList()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                DataSet dsList = VHMS.DataAccess.User.GetMenuList();
                jsObject.MaxJsonLength = Int32.MaxValue;
                objResponse.Status = "Success";
                objResponse.Value = dsList.Tables.Count > 0 ? GetDtJson(dsList.Tables[0]) : "NoRecord";
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "GetMenuList |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetModuleList(int MenuID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                DataSet dsList = VHMS.DataAccess.User.GetModuleList(MenuID);
                jsObject.MaxJsonLength = Int32.MaxValue;
                objResponse.Status = "Success";
                objResponse.Value = dsList.Tables.Count > 0 ? GetDtJson(dsList.Tables[0]) : "NoRecord";
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "GetModuleList |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetMenuandModule(int MenuID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                DataSet dsList = VHMS.DataAccess.User.GetMenuandModule(MenuID);
                jsObject.MaxJsonLength = Int32.MaxValue;
                objResponse.Status = "Success";
                objResponse.Value = dsList.Tables.Count > 0 ? GetDtJson(dsList.Tables[0]) : "NoRecord";
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "GetMenuandModule |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetRoleConfiguration(int iRoleID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.RoleConfiguration> ObjList = new Collection<VHMS.Entity.RoleConfiguration>();
                ObjList = VHMS.DataAccess.RoleConfiguration.GetRoleConfiguration(iRoleID);
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
            sException = "RoleConfiguration GetRoleConfiguration |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string SaveRoleConfiguration(Collection<VHMS.Entity.RoleConfiguration> objList)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.DataAccess.RoleConfiguration.SaveRoleConfiguration(objList);
                objResponse.Status = "Success";
                objResponse.Value = "1";
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "RoleConfiguration SaveRoleConfiguration |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsonObject.Serialize(objResponse);
    }
    #endregion
    #endregion

    #region "Company"
    public string GetCompany()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            //if (ValidateSession())
            //{
            Collection<VHMS.Entity.Company> ObjList = new Collection<VHMS.Entity.Company>();
            ObjList = VHMS.DAL.Company.GetCompany();
            objResponse.Status = "Success";
            objResponse.Value = jsObject.Serialize(ObjList);
            //}
            //else
            //{
            //    objResponse.Status = "Error";
            //    objResponse.Value = "0";
            //}
        }
        catch (Exception ex)
        {
            sException = "Company GetCompany |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetCompanyByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Company ObjList = new Company();
                ObjList = VHMS.DAL.Company.GetCompanyByID(ID);
                objResponse.Status = "Success";
                objResponse.Value = jsObject.Serialize(ObjList);
            }
            else
            {
                objResponse.Status = "Error";
                objResponse.Value = "0";
            }
        }
        catch (Exception ex)
        {
            sException = "Company GetCompany |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddCompany(VHMS.Entity.Company Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iCompanyId = 0;
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;
                iCompanyId = VHMS.DAL.Company.AddCompany(Objdata);
                if (iCompanyId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iCompanyId.ToString();
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
            sException = "Company AddCompany |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Company_A_01")
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
    public string UpdateCompany(VHMS.Entity.Company Objdata)
    {
        string sCompanyId = string.Empty;
        string sException = string.Empty;
        bool bCompany = false;
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
                bCompany = VHMS.DAL.Company.UpdateCompany(Objdata);
                if (bCompany == true)
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
            sException = "Company UpdateCompany |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Company_U_01")
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

    #region "Master"

    #region "Dashboard"
    public string GetDashboardCount()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.Dashboard objState = new VHMS.Entity.Dashboard();
                objState = VHMS.DataAccess.Dashboard.GetDashboardCount(iCompanyID);
                if (objState.CountValue > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objState);
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
            sException = "VHMSService.State GetStateByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    #endregion

    #region "State"
    public string GetState()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.State> ObjList = new Collection<VHMS.Entity.State>();
                ObjList = VHMS.DataAccess.State.GetState();
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
            sException = "VHMSService.State GetState |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetStateByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.State objState = new VHMS.Entity.State();
                objState = VHMS.DataAccess.State.GetStateByID(ID);
                if (objState.StateID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objState);
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
            sException = "VHMSService.State GetStateByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddState(VHMS.Entity.State Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iStateId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;
                iStateId = VHMS.DataAccess.State.AddState(Objdata);
                if (iStateId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iStateId.ToString();
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
            sException = "VHMSService.State AddState |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "State_A_01")
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
    public string UpdateState(VHMS.Entity.State Objdata)
    {
        string sStateId = string.Empty;
        string sException = string.Empty;
        bool bState = false;
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
                bState = VHMS.DataAccess.State.UpdateState(Objdata);
                if (bState == true)
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
            sException = "VHMSService.State UpdateState |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "State_U_01")
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
    public string DeleteState(int ID)
    {
        string sStateId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bState = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bState = VHMS.DataAccess.State.DeleteState(ID, UserID);
                if (bState == true)
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
            sException = "VHMSService.State DeleteState |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "State_R_01" || ex.Message.ToString() == "State_D_01")
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

    #region "Country"
    public string GetCountry()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Country> ObjList = new Collection<VHMS.Entity.Country>();
                ObjList = VHMS.DataAccess.Country.GetCountry();
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
            sException = "VHMSService.Country GetCountry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetCountryByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Country objCountry = new VHMS.Entity.Country();
                objCountry = VHMS.DataAccess.Country.GetCountryByID(ID);
                if (objCountry.CountryID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objCountry);
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
            sException = "VHMSService.Country GetCountryByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddCountry(VHMS.Entity.Country Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iCountryId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;
                iCountryId = VHMS.DataAccess.Country.AddCountry(Objdata);
                if (iCountryId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iCountryId.ToString();
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
            sException = "VHMSService.Country AddCountry |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Country_A_01")
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
    public string UpdateCountry(VHMS.Entity.Country Objdata)
    {
        string sCountryId = string.Empty;
        string sException = string.Empty;
        bool bCountry = false;
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
                bCountry = VHMS.DataAccess.Country.UpdateCountry(Objdata);
                if (bCountry == true)
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
            sException = "VHMSService.Country UpdateCountry |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Country_U_01")
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
    public string DeleteCountry(int ID)
    {
        string sCountryId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bCountry = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bCountry = VHMS.DataAccess.Country.DeleteCountry(ID, UserID);
                if (bCountry == true)
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
            sException = "VHMSService.Country DeleteCountry |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Country_R_01" || ex.Message.ToString() == "Country_D_01")
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

    #region "Employee"
    public string GetEmployee(int CountryID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Employee> ObjList = new Collection<VHMS.Entity.Employee>();
                ObjList = VHMS.DataAccess.Employee.GetEmployee(CountryID);
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
            sException = "VHMSService.Employee GetEmployee |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetEmployeeByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Employee objState = new VHMS.Entity.Employee();
                objState = VHMS.DataAccess.Employee.GetEmployeeByID(ID);
                if (objState.EmployeeID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objState);
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
            sException = "VHMSService.Employee GetEmployeeByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddEmployee(VHMS.Entity.Employee Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iStateId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;
                iStateId = VHMS.DataAccess.Employee.AddEmployee(Objdata);
                if (iStateId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iStateId.ToString();
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
            sException = "VHMSService.Employee AddEmployee |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Employee_A_01")
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
    public string UpdateEmployee(VHMS.Entity.Employee Objdata)
    {
        string sStateId = string.Empty;
        string sException = string.Empty;
        bool bState = false;
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
                bState = VHMS.DataAccess.Employee.UpdateEmployee(Objdata);
                if (bState == true)
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
            sException = "VHMSService.Employee UpdateEmployee |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Employee_U_01")
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

    public string UpdateEmployeeAmount(VHMS.Entity.Employee Objdata)
    {
        string sStateId = string.Empty;
        string sException = string.Empty;
        bool bState = false;
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
                bState = VHMS.DataAccess.Employee.UpdateEmployeeAmount(Objdata);
                if (bState == true)
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
            sException = "VHMSService.Employee UpdateEmployee |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Employee_U_01")
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
    public string DeleteEmployee(int ID)
    {
        string sStateId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bState = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bState = VHMS.DataAccess.Employee.DeleteEmployee(ID, UserID);
                if (bState == true)
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
            sException = "VHMSService.Employee DeleteEmployee |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Employee_R_01" || ex.Message.ToString() == "Employee_D_01")
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

    #region "Product"
    public string GetProduct()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
                ObjList = VHMS.DataAccess.Master.Product.GetProduct(iCompanyID);
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
            sException = "VHMSService.Master.Product GetProduct |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetReorderStock()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
                ObjList = VHMS.DataAccess.Master.Product.GetReorderStock(iCompanyID);
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
            sException = "VHMSService.Master.Product GetProduct |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetProductList()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
                ObjList = VHMS.DataAccess.Master.Product.GetProductList(iCompanyID);
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
            sException = "VHMSService.Master.Product GetProduct |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetTopProduct()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
                ObjList = VHMS.DataAccess.Master.Product.GetTopProduct(iCompanyID);
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
            sException = "VHMSService.Master.Product GetProduct |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string SearchProduct(string ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
                ObjList = VHMS.DataAccess.Master.Product.SearchProduct(ID, iCompanyID);
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
            sException = "VHMSService.Master.Product GetProduct |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetProductByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.Master.Product objProduct = new VHMS.Entity.Master.Product();
                objProduct = VHMS.DataAccess.Master.Product.GetProductByID(ID, iCompanyID);
                if (objProduct.ProductID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objProduct);
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
            sException = "VHMSService.Master.Product GetProductByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }



    public string GetProductSupplierList(int SupplierID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
                ObjList = VHMS.DataAccess.Master.Product.GetProductSupplierList(SupplierID, iCompanyID);
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
            sException = "VHMSService.Master.Product GetProduct |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetAllProduct(int ID, int CategoryID, int SupplierID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
                ObjList = VHMS.DataAccess.Master.Product.GetAllProduct(ID, CategoryID, SupplierID, iCompanyID);
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
            sException = "VHMSService.Master.Product GetProduct |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetProductID(int ID, int CategoryID, int SubCategoryID, int SupplierID, int TypeID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
                ObjList = VHMS.DataAccess.Master.Product.GetProductID(ID, CategoryID, SupplierID, iCompanyID);
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
            sException = "VHMSService.Master.Product GetProduct |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetProductByCode(string ProductCode, Boolean SMSOnly)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
                ObjList = VHMS.DataAccess.Master.Product.GetProductByCode(ProductCode, SMSOnly);
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
            sException = "VHMSService.Master.Product GetProduct |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }


    public string GetProductByBarcode(string ProductCode, Boolean SMSOnly)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
                ObjList = VHMS.DataAccess.Master.Product.GetProductByBarcode(ProductCode, SMSOnly);
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
            sException = "VHMSService.Master.Product GetProduct |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddProduct(VHMS.Entity.Master.Product Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iProductId = 0;
        int iUserID = 0;
        int iCompanyID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                iProductId = VHMS.DataAccess.Master.Product.AddProduct(Objdata);
                if (iProductId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iProductId.ToString();
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
            sException = "VHMSService.Master.Product AddProduct |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Product_A_01")
            {
                objResponse.Status = "Error";
                objResponse.Value = ex.Message.ToString();
            }
            else if (ex.Message.ToString() == "ProductC_A_01")
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
    public string UpdateProduct(VHMS.Entity.Master.Product Objdata)
    {
        string sProductId = string.Empty;
        string sException = string.Empty;
        bool bProduct = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserID = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.ModifiedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                bProduct = VHMS.DataAccess.Master.Product.UpdateProduct(Objdata);
                if (bProduct == true)
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
            sException = "VHMSService.Master.Product UpdateProduct |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Product_U_01")
            {
                objResponse.Status = "Error";
                objResponse.Value = ex.Message.ToString();
            }
            else if (ex.Message.ToString() == "ProductC_U_01")
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
    public string DeleteProduct(int ID)
    {
        string sProductId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bProduct = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bProduct = VHMS.DataAccess.Master.Product.DeleteProduct(ID, UserID);
                if (bProduct == true)
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
            sException = "VHMSService.Master.Product DeleteProduct |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Product_R_01" || ex.Message.ToString() == "Product_D_01")
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

    #region "Customer"
    public string GetCustomer()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Customer> ObjList = new Collection<VHMS.Entity.Customer>();
                ObjList = VHMS.DataAccess.Customer.GetCustomer();
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
            sException = "VHMSService.Customer GetCustomer |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetTopCustomer(int CustomerID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Customer> ObjList = new Collection<VHMS.Entity.Customer>();
                ObjList = VHMS.DataAccess.Customer.GetTopCustomer(CustomerID);
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
            sException = "VHMSService.Customer GetCustomer |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetCustomerByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Customer objCustomer = new VHMS.Entity.Customer();
                objCustomer = VHMS.DataAccess.Customer.GetCustomerByID(ID);
                if (objCustomer.CustomerID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objCustomer);
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
            sException = "VHMSService.Customer GetCustomerByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddCustomer(VHMS.Entity.Customer Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iCustomerId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;
                iCustomerId = VHMS.DataAccess.Customer.AddCustomer(Objdata);
                if (iCustomerId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iCustomerId.ToString();
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
            sException = "VHMSService.Customer AddCustomer |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Customer_A_01")
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
    public string UpdateCustomer(VHMS.Entity.Customer Objdata)
    {
        string sCustomerId = string.Empty;
        string sException = string.Empty;
        bool bCustomer = false;
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
                bCustomer = VHMS.DataAccess.Customer.UpdateCustomer(Objdata);
                if (bCustomer == true)
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
            sException = "VHMSService.Customer UpdateCustomer |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Customer_U_01")
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
    public string DeleteCustomer(int ID)
    {
        string sCustomerId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bCustomer = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bCustomer = VHMS.DataAccess.Customer.DeleteCustomer(ID, UserID);
                if (bCustomer == true)
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
            sException = "VHMSService.Customer DeleteCustomer |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Customer_R_01" || ex.Message.ToString() == "Customer_D_01")
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

    #region "Ledger"
    public string GetLedger()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Ledger> ObjList = new Collection<VHMS.Entity.Ledger>();
                ObjList = VHMS.DataAccess.Ledger.GetLedger();
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
            sException = "VHMSService.Ledger GetLedger |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetLedgerBank()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Ledger> ObjList = new Collection<VHMS.Entity.Ledger>();
                ObjList = VHMS.DataAccess.Ledger.GetLedgerBank();
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
            sException = "VHMSService.Ledger GetLedger |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetLedgerByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Ledger objLedger = new VHMS.Entity.Ledger();
                objLedger = VHMS.DataAccess.Ledger.GetLedgerByID(ID);
                if (objLedger.LedgerID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objLedger);
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
            sException = "VHMSService.Ledger GetLedgerByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetLedgerByCategoryID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Ledger> ObjList = new Collection<VHMS.Entity.Ledger>();
                ObjList = VHMS.DataAccess.Ledger.GetLedgerByCategoryID(ID);
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
            sException = "VHMSService.Ledger GetLedgerByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddLedger(VHMS.Entity.Ledger Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iLedgerId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;
                iLedgerId = VHMS.DataAccess.Ledger.AddLedger(Objdata);
                if (iLedgerId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iLedgerId.ToString();
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
            sException = "VHMSService.Ledger AddLedger |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Ledger_A_01")
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
    public string UpdateLedger(VHMS.Entity.Ledger Objdata)
    {
        string sLedgerId = string.Empty;
        string sException = string.Empty;
        bool bLedger = false;
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
                bLedger = VHMS.DataAccess.Ledger.UpdateLedger(Objdata);
                if (bLedger == true)
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
            sException = "VHMSService.Ledger UpdateLedger |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Ledger_U_01")
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
    public string DeleteLedger(int ID)
    {
        string sLedgerId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bLedger = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bLedger = VHMS.DataAccess.Ledger.DeleteLedger(ID, UserID);
                if (bLedger == true)
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
            sException = "VHMSService.Ledger DeleteLedger |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Ledger_R_01" || ex.Message.ToString() == "Ledger_D_01")
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

    #region "LedgerType"
    public string GetLedgerType()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.LedgerType> ObjList = new Collection<VHMS.Entity.LedgerType>();
                ObjList = VHMS.DataAccess.LedgerType.GetLedgerType();
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
            sException = "VHMSService.LedgerType GetLedgerType |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetLedgerTypeByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.LedgerType objLedgerType = new VHMS.Entity.LedgerType();
                objLedgerType = VHMS.DataAccess.LedgerType.GetLedgerTypeByID(ID);
                if (objLedgerType.LedgerTypeID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objLedgerType);
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
            sException = "VHMSService.LedgerType GetLedgerTypeByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetLedgerTypeByCategoryID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.LedgerType> ObjList = new Collection<VHMS.Entity.LedgerType>();
                ObjList = VHMS.DataAccess.LedgerType.GetLedgerTypeByCategoryID(ID);
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
            sException = "VHMSService.LedgerType GetLedgerTypeByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddLedgerType(VHMS.Entity.LedgerType Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iLedgerTypeId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;
                iLedgerTypeId = VHMS.DataAccess.LedgerType.AddLedgerType(Objdata);
                if (iLedgerTypeId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iLedgerTypeId.ToString();
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
            sException = "VHMSService.LedgerType AddLedgerType |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "LedgerType_A_01")
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
    public string UpdateLedgerType(VHMS.Entity.LedgerType Objdata)
    {
        string sLedgerTypeId = string.Empty;
        string sException = string.Empty;
        bool bLedgerType = false;
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
                bLedgerType = VHMS.DataAccess.LedgerType.UpdateLedgerType(Objdata);
                if (bLedgerType == true)
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
            sException = "VHMSService.LedgerType UpdateLedgerType |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "LedgerType_U_01")
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
    public string DeleteLedgerType(int ID)
    {
        string sLedgerTypeId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bLedgerType = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bLedgerType = VHMS.DataAccess.LedgerType.DeleteLedgerType(ID, UserID);
                if (bLedgerType == true)
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
            sException = "VHMSService.LedgerType DeleteLedgerType |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "LedgerType_R_01" || ex.Message.ToString() == "LedgerType_D_01")
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

    #region "Stock"
    public string GetStock()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        //int iBranchID = 0;
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Stock> ObjList = new Collection<VHMS.Entity.Stock>();
                ObjList = VHMS.DataAccess.Stock.GetStock();
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
            sException = "VHMSService.Stock GetStock |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetStockByBatchNo(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        //int iBranchID = 0;
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Stock> ObjList = new Collection<VHMS.Entity.Stock>();
                ObjList = VHMS.DataAccess.Stock.GetStockByBatchNo(ID);
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
            sException = "VHMSService.Stock GetStock |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetStockAvailableQtyByBatchNo(int ID = 0, string iTypeName = "", int iOtherID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        //int iBranchID = 0;
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Stock> ObjList = new Collection<VHMS.Entity.Stock>();
                ObjList = VHMS.DataAccess.Stock.GetStockAvailableQtyByBatchNo(ID, iTypeName, iOtherID);
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
            sException = "VHMSService.Stock GetStock |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetTopStock()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iBranchID = 0; int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID) && Int32.TryParse(HttpContext.Current.Session["BranchID"].ToString(), out iBranchID))
            {
                if (iUserID <= 1)
                    iBranchID = 0;
                Collection<VHMS.Entity.Stock> ObjList = new Collection<VHMS.Entity.Stock>();
                ObjList = VHMS.DataAccess.Stock.GetTopStock(iBranchID);
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
            sException = "VHMSService.Stock GetStock |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string SearchStock(string ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iBranchID = 0; int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID) && Int32.TryParse(HttpContext.Current.Session["BranchID"].ToString(), out iBranchID))
            {
                if (iUserID <= 1)
                    iBranchID = 0;
                Collection<VHMS.Entity.Stock> ObjList = new Collection<VHMS.Entity.Stock>();
                ObjList = VHMS.DataAccess.Stock.SearchStock(ID, iBranchID);
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
            sException = "VHMSService.Stock GetStock |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetStockByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Stock objStock = new VHMS.Entity.Stock();
                objStock = VHMS.DataAccess.Stock.GetStockByID(ID);
                if (objStock.StockID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objStock);
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
            sException = "VHMSService.Stock GetStockByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }


    public string GetStockProductByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Stock objStock = new VHMS.Entity.Stock();
                objStock = VHMS.DataAccess.Stock.GetStockProductByID(ID);
                if (objStock.StockID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objStock);
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
            sException = "VHMSService.Stock GetStockByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetStockPreviousRateByID(int iProductID = 0, int iCustomerID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Stock objStock = new VHMS.Entity.Stock();
                objStock = VHMS.DataAccess.Stock.GetStockPreviousRateByID(iProductID, iCustomerID);
                if (objStock.StockID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objStock);
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
            sException = "VHMSService.Stock GetStockByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetStockByBarcode(string ID = null, string Status = null)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iBranchID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["BranchID"].ToString(), out iBranchID))
            {
                VHMS.Entity.Stock objStock = new VHMS.Entity.Stock();
                objStock = VHMS.DataAccess.Stock.GetStockByBarcode(ID, Status, iBranchID);
                if (objStock.StockID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objStock);
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
            sException = "VHMSService.Stock GetStockByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetStockByBarcodeQuotation(string ID = null, string Status = null)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iBranchID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["BranchID"].ToString(), out iBranchID))
            {
                VHMS.Entity.Stock objStock = new VHMS.Entity.Stock();
                objStock = VHMS.DataAccess.Stock.GetStockByBarcodeQuotation(ID, Status, iBranchID);
                if (objStock.StockID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objStock);
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
            sException = "VHMSService.Stock GetStockByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetMissingBarcode(string StockIDs, int Quantity)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iBranchID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["BranchID"].ToString(), out iBranchID))
            {
                Collection<VHMS.Entity.Stock> ObjList = new Collection<VHMS.Entity.Stock>();
                ObjList = VHMS.DataAccess.Stock.GetMissingBarcode(StockIDs, iBranchID, Quantity);
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
            sException = "VHMSService.Stock GetStock |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddStock(VHMS.Entity.Stock Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iStockId = 0;
        int iUserID = 0;
        int iBranchID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID) && Int32.TryParse(HttpContext.Current.Session["BranchID"].ToString(), out iBranchID))
            {


                // VHMS.Entity.Branch objBranch = new VHMS.Entity.Branch();
                // objBranch.BranchID = iBranchID;
                // Objdata.Branch = objBranch;
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                // objUser.UserID = iUserID;
                //Objdata.CreatedBy = objUser;
                iStockId = VHMS.DataAccess.Stock.AddStock(Objdata);
                if (iStockId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iStockId.ToString();
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
            sException = "VHMSService.Stock AddStock |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Stock_A_01")
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
    public string UpdateStock(VHMS.Entity.Stock Objdata)
    {
        string sStockId = string.Empty;
        string sException = string.Empty;
        bool bStock = false;
        int iBranchID = 0;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID) && Int32.TryParse(HttpContext.Current.Session["BranchID"].ToString(), out iBranchID))
            {
                //  VHMS.Entity.Branch objBranch = new VHMS.Entity.Branch();
                //  objBranch.BranchID = iBranchID;
                //Objdata.Branch = objBranch;
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                //objUser.UserID = UserID;
                //Objdata.ModifiedBy = objUser;
                bStock = VHMS.DataAccess.Stock.UpdateStock(Objdata);
                if (bStock == true)
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
            sException = "VHMSService.Stock UpdateStock |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Stock_U_01")
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

    public string UpdateSplitWeight(int ID, decimal iWeight)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iStockId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                iStockId = VHMS.DataAccess.Stock.UpdateSplitWeight(ID, iWeight, iUserID);
                if (iStockId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iStockId.ToString();
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
            sException = "VHMSService.Stock AddStock |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Stock_A_01")
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
    public string DeleteStock(int ID)
    {
        string sStockId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bStock = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bStock = VHMS.DataAccess.Stock.DeleteStock(ID, UserID);
                if (bStock == true)
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
            sException = "VHMSService.Stock DeleteStock |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Stock_R_01" || ex.Message.ToString() == "Stock_D_01")
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

    #endregion
}
