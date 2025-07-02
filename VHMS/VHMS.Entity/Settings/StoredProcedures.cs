using VHMS.Entity.Billing;

namespace constants
{
    public class StoredProcedures
    {
        //Dashboard Count
        public const string USP_SELECT_DASHBOARD = "usp_Select_Dashboard";
        public const string USP_SELECT_DASHBOARDCOUNT = "usp_Select_DashboardCount";
        public const string USP_SELECT_RECENTADMISSION = "usp_Select_RecentAdmission";
        //User
        public const string USP_SELECT_USERLOGIN = "usp_Select_UserLogin";
        public const string USP_SELECT_MODULE = "usp_Select_Module";
        public const string USP_RESET_PASSWORD = "usp_Rest_Password";
        public const string USP_CHANGEPASSWORD = "usp_ChangePassword";
        public const string USP_INSERT_USER = "usp_Insert_User";
        public const string USP_UPDATE_USER = "usp_Update_User";
        public const string USP_DELETE_USER = "usp_Delete_User";
        public const string USP_SELECT_USER = "usp_Select_User";
        public const string USP_INSERT_LOG = "usp_Insert_Log";
        public const string USP_INSERT_VISITLOG = "usp_Insert_VisitLog";
        public const string USP_SELECT_VISITLOG = "usp_Select_VisitLog";


        //Roles
        public const string USP_INSERT_ROLE = "usp_Insert_Role";
        public const string USP_UPDATE_ROLE = "usp_Update_Role";
        public const string USP_DELETE_ROLE = "usp_Delete_Role";
        public const string USP_SELECT_ROLE = "usp_Select_Role";


        //RoleConfigurtaion
        public const string USP_SELECT_ROLECONFIGURATION = "usp_Select_RoleConfiguration";
        public const string USP_INSERT_ROLECONFIGURATION = "usp_Insert_RoleConfiguration";
        public const string USP_UPDATE_ROLECONFIGURATION = "usp_Update_RoleConfiguration";
        public const string USP_DELETE_ROLECONFIGURATION = "usp_Delete_RoleConfiguration";
        public const string USP_INSERT_AUDITALL = "usp_Insert_AuditAll"; //Log Database
        //HouseType
        public const string USP_INSERT_HOUSETYPE = "usp_Insert_HouseType";
        public const string USP_UPDATE_HOUSETYPE = "usp_Update_HouseType";
        public const string USP_DELETE_HOUSETYPE = "usp_Delete_HouseType";
        public const string USP_SELECT_HOUSETYPE = "usp_Select_HouseType";
        //NewCustomer
        public const string USP_INSERT_NEWCUSTOMER = "usp_Insert_NewCustomer";
        public const string USP_UPDATE_NEWCUSTOMER = "usp_Update_NewCustomer";
        public const string USP_DELETE_NEWCUSTOMER = "usp_Delete_NewCustomer";
        public const string USP_SELECT_NEWCUSTOMER = "usp_Select_NewCustomer";


    }
}