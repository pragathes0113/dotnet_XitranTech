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
            ObjUser = VHMS.DataAccess.User.GetUserLogin(sUserName, sPassword, sIPAddress, clientIp);
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

 

}
