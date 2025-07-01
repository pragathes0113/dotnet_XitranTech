using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class frmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(IsPostBack))
        {
            Session.Abandon();

            string connstrg = CommonMethods.Security.Encrypt("Database=BCVijayaHMS_Log;Server=NEWSOFTWARE\\SQLEXPRESS;uid=sa;pwd=Vito@123;", true);
            //string connstrg = CommonMethods.Security.Decrypt("i6LBVAgPqn2D3t/hJIN1WC+uCxA1pT/4s4Q6lT22xIcoQabn/ifp2Cp8dybjKdhjC6FKMk+elpq4vEYvzWlTeuvAq8ugIH3/6nzCGmN5I4o=", true);

            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtUserName.Value = Request.Cookies["UserName"].Value;
                txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
            }
        }
        Assembly assembly = Assembly.Load("App_Code");
        string version = assembly.GetName().Version.ToString();
        divTitle.InnerHtml = "Xitran Technologies " + version;
    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        VHMS.Entity.User objUser;
        string sException = string.Empty;

        try
        {
            string sIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            string clientIp = string.Empty;
            int ComID = 0;
            if (System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.Length > 2)
                clientIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[2].ToString();  // (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
            else
                clientIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1].ToString();
            objUser = new VHMS.Entity.User();
            var companyName = Request.Form["ddlname"];
            objUser = VHMS.DataAccess.User.GetUserLogin(txtUserName.Value.ToString(), txtPassword.Value.ToString(), sIPAddress, clientIp);
            if (objUser.UserID > 0)
            {
                Session["UserID"] = objUser.UserID;
                Session["UserName"] = objUser.UserName;
                Session["EmployeeName"] = objUser.EmployeeName;
                Session["RoleID"] = objUser.RoleID;
                Session["RoleName"] = objUser.RoleName;
                Session["LogDateTime"] = DateTime.Now.ToString("");


                Response.Redirect("frmDefault.aspx", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alertKey", "<script type='text/javascript'>alert('Invalid Username Or Password');</script>", false);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "eAlert('Invalid Username Or Password');", true);                
                txtUserName.Value = "";
                txtPassword.Value = "";
                txtUserName.Focus();
            }
        }
        catch (Exception ex)
        {
            Log.Write("frmLogin btnSignIn_Click |" + ex.ToString());
            Response.Redirect("frmLogin.aspx", false);
        }
        finally
        {
            objUser = null;
            txtPassword.Value = "";
            txtUserName.Value = "";
        }
    }
    protected void txtPassword_PreRender(object sender, System.EventArgs e)
    { txtPassword.Attributes["value"] = txtPassword.Value; }
}