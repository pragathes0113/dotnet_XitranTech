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
    #region "Unit"
    public string GetUnit()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.Unit> ObjList = new Collection<VHMS.Entity.Billing.Unit>();
                ObjList = VHMS.DataAccess.Billing.Unit.GetUnit();
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
            sException = "VHMSService.Billing.Unit GetUnit |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetUnitByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Billing.Unit objUnit = new VHMS.Entity.Billing.Unit();
                objUnit = VHMS.DataAccess.Billing.Unit.GetUnitByID(ID);
                if (objUnit.UnitID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objUnit);
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
            sException = "VHMSService.Billing.Unit GetUnitByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddUnit(VHMS.Entity.Billing.Unit Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iUnitId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;
                iUnitId = VHMS.DataAccess.Billing.Unit.AddUnit(Objdata);
                if (iUnitId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iUnitId.ToString();
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
            sException = "VHMSService.Billing.Unit AddUnit |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Unit_A_01")
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
    public string UpdateUnit(VHMS.Entity.Billing.Unit Objdata)
    {
        string sUnitId = string.Empty;
        string sException = string.Empty;
        bool bUnit = false;
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
                bUnit = VHMS.DataAccess.Billing.Unit.UpdateUnit(Objdata);
                if (bUnit == true)
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
            sException = "VHMSService.Billing.Unit UpdateUnit |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Unit_U_01")
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
    public string DeleteUnit(int ID)
    {
        string sUnitId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bUnit = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bUnit = VHMS.DataAccess.Billing.Unit.DeleteUnit(ID, UserID);
                if (bUnit == true)
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
            sException = "VHMSService.Billing.Unit DeleteUnit |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Unit_R_01" || ex.Message.ToString() == "Unit_D_01")
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

    #region "Category"
    public string GetCategory()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.Category> ObjList = new Collection<VHMS.Entity.Billing.Category>();
                ObjList = VHMS.DataAccess.Billing.Category.GetCategory();
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
            sException = "VHMSService.Billing.Category GetCategory |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetCategoryByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Billing.Category objCategory = new VHMS.Entity.Billing.Category();
                objCategory = VHMS.DataAccess.Billing.Category.GetCategoryByID(ID);
                if (objCategory.CategoryID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objCategory);
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
            sException = "VHMSService.Billing.Category GetCategoryByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddCategory(VHMS.Entity.Billing.Category Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iCategoryId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;
                iCategoryId = VHMS.DataAccess.Billing.Category.AddCategory(Objdata);
                if (iCategoryId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iCategoryId.ToString();
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
            sException = "VHMSService.Billing.Category AddCategory |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Category_A_01")
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
    public string UpdateCategory(VHMS.Entity.Billing.Category Objdata)
    {
        string sCategoryId = string.Empty;
        string sException = string.Empty;
        bool bCategory = false;
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
                bCategory = VHMS.DataAccess.Billing.Category.UpdateCategory(Objdata);
                if (bCategory == true)
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
            sException = "VHMSService.Billing.Category UpdateCategory |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Category_U_01")
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
    public string DeleteCategory(int ID)
    {
        string sCategoryId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bCategory = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bCategory = VHMS.DataAccess.Billing.Category.DeleteCategory(ID, UserID);
                if (bCategory == true)
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
            sException = "VHMSService.Billing.Category DeleteCategory |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Category_R_01" || ex.Message.ToString() == "Category_D_01")
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

    #region "Tax"
    public string GetTax()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.Tax> ObjList = new Collection<VHMS.Entity.Billing.Tax>();
                ObjList = VHMS.DataAccess.Billing.Tax.GetTax();
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
            sException = "VHMSService.Billing.Tax GetTax |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetTaxByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Billing.Tax objTax = new VHMS.Entity.Billing.Tax();
                objTax = VHMS.DataAccess.Billing.Tax.GetTaxByID(ID);
                if (objTax.TaxID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objTax);
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
            sException = "VHMSService.Billing.Tax GetTaxByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddTax(VHMS.Entity.Billing.Tax Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iTaxId = 0;
        int iUserID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;
                iTaxId = VHMS.DataAccess.Billing.Tax.AddTax(Objdata);
                if (iTaxId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iTaxId.ToString();
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
            sException = "VHMSService.Billing.Tax AddTax |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Tax_A_01")
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
    public string UpdateTax(VHMS.Entity.Billing.Tax Objdata)
    {
        string sTaxId = string.Empty;
        string sException = string.Empty;
        bool bTax = false;
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
                bTax = VHMS.DataAccess.Billing.Tax.UpdateTax(Objdata);
                if (bTax == true)
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
            sException = "VHMSService.Billing.Tax UpdateTax |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Tax_U_01")
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
    public string DeleteTax(int ID)
    {
        string sTaxId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bTax = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bTax = VHMS.DataAccess.Billing.Tax.DeleteTax(ID, UserID);
                if (bTax == true)
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
            sException = "VHMSService.Billing.Tax DeleteTax |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Tax_R_01" || ex.Message.ToString() == "Tax_D_01")
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

    #region "Supplier"
    public string GetSupplier()
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
                Collection<VHMS.Entity.Billing.Supplier> ObjList = new Collection<VHMS.Entity.Billing.Supplier>();
                ObjList = VHMS.DataAccess.Billing.Supplier.GetSupplier(iCompanyID);
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
            sException = "VHMSService.Billing.Supplier GetSupplier |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetAllSupplier(int iSupplierID)
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
                Collection<VHMS.Entity.Billing.Supplier> ObjList = new Collection<VHMS.Entity.Billing.Supplier>();
                ObjList = VHMS.DataAccess.Billing.Supplier.GetAllSupplier(iSupplierID, iCompanyID);
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
            sException = "VHMSService.Billing.Supplier GetSupplier |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetSupplierByID(int ID)
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
                VHMS.Entity.Billing.Supplier objSupplier = new VHMS.Entity.Billing.Supplier();
                objSupplier = VHMS.DataAccess.Billing.Supplier.GetSupplierByID(ID, iCompanyID);
                if (objSupplier.SupplierID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objSupplier);
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
            sException = "VHMSService.Billing.Supplier GetSupplierByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddSupplier(VHMS.Entity.Billing.Supplier Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iSupplierId = 0;
        try
        {
            int iUserID = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserID) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserID;
                Objdata.CreatedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                iSupplierId = VHMS.DataAccess.Billing.Supplier.AddSupplier(Objdata);
                if (iSupplierId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iSupplierId.ToString();
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
            sException = "VHMSService.Billing.Supplier AddSupplier |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Supplier_A_01")
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
    public string UpdateSupplier(VHMS.Entity.Billing.Supplier Objdata)
    {
        string sSupplierId = string.Empty;
        string sException = string.Empty;
        bool bSupplier = false;
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
                Objdata.CreatedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;
                bSupplier = VHMS.DataAccess.Billing.Supplier.UpdateSupplier(Objdata);
                if (bSupplier == true)
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
            sException = "VHMSService.Billing.Supplier UpdateSupplier |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Supplier_U_01")
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
    public string DeleteSupplier(int ID)
    {
        string sSupplierId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bSupplier = false;
        try
        {
            int UserID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out UserID))
            {
                bSupplier = VHMS.DataAccess.Billing.Supplier.DeleteSupplier(ID, UserID);
                if (bSupplier == true)
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
            sException = "VHMSService.Billing.Supplier DeleteSupplier |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Supplier_R_01" || ex.Message.ToString() == "Supplier_D_01")
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

    #region "SalesReturn"
    public string GetSalesReturn(int PublisherID = 0)
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
                Collection<VHMS.Entity.Billing.SalesReturn> ObjList = new Collection<VHMS.Entity.Billing.SalesReturn>();
                ObjList = VHMS.DataAccess.Billing.SalesReturn.GetSalesReturn(PublisherID, iCompanyID);
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
            sException = "SalesReturn GetSalesReturn |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetTopSalesReturn(int PublisherID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iUserId = 0;
        int iBranchID = 0;
        int iCompanyID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                if (iUserId <= 1)
                    iBranchID = 0;
                Collection<VHMS.Entity.Billing.SalesReturn> ObjList = new Collection<VHMS.Entity.Billing.SalesReturn>();
                ObjList = VHMS.DataAccess.Billing.SalesReturn.GetTopSalesReturn(PublisherID, iBranchID, iCompanyID);
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
            sException = "SalesReturn GetSalesReturn |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetSalesReturnID(int PublisherID = 0)
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
                Collection<VHMS.Entity.Billing.SalesReturn> ObjList = new Collection<VHMS.Entity.Billing.SalesReturn>();
                ObjList = VHMS.DataAccess.Billing.SalesReturn.GetSalesReturnID(PublisherID, iCompanyID);
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
            sException = "SalesReturn GetSalesReturn |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string SearchSalesReturn(string ID = null)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iUserId = 0;
        int iCompanyID = 0;
        int iBranchID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                if (iUserId <= 1)
                    iBranchID = 0;
                Collection<VHMS.Entity.Billing.SalesReturn> ObjList = new Collection<VHMS.Entity.Billing.SalesReturn>();
                ObjList = VHMS.DataAccess.Billing.SalesReturn.SearchSalesReturn(ID, iBranchID, iCompanyID);
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
            sException = "SalesReturn GetSalesReturn |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetSalesReturnByID(int ID)
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
                VHMS.Entity.Billing.SalesReturn objSalesReturn = new VHMS.Entity.Billing.SalesReturn();
                objSalesReturn = VHMS.DataAccess.Billing.SalesReturn.GetSalesReturnByID(ID, iCompanyID);
                if (objSalesReturn.SalesReturnID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objSalesReturn);
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
            sException = "SalesReturn GetSalesReturnByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetSalesReturnByInvoice(string InvoiceNo)
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
                VHMS.Entity.Billing.SalesReturn objSalesReturn = new VHMS.Entity.Billing.SalesReturn();
                //  objSalesReturn = VHMS.DataAccess.Billing.SalesReturn.GetSalesReturnByInvoice(InvoiceNo);
                if (objSalesReturn.SalesReturnID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objSalesReturn);
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
            sException = "SalesReturn GetSalesReturnByInvoice |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddSalesReturn(VHMS.Entity.Billing.SalesReturn Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iSalesReturnId = 0;
        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                iSalesReturnId = VHMS.DataAccess.Billing.SalesReturn.AddSalesReturn(Objdata);
                if (iSalesReturnId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iSalesReturnId.ToString();
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
            sException = "SalesReturn AddSalesReturn |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "SalesReturn_A_01")
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
    public string UpdateSalesReturn(VHMS.Entity.Billing.SalesReturn Objdata)
    {
        string sSalesReturnId = string.Empty;
        string sException = string.Empty;
        bool bSalesReturn = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.ModifiedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                bSalesReturn = VHMS.DataAccess.Billing.SalesReturn.UpdateSalesReturn(Objdata);
                if (bSalesReturn == true)
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
            sException = "SalesReturn UpdateSalesReturn |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "SalesReturn_U_01")
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
    public string DeleteSalesReturn(int ID)
    {
        string sSalesReturnId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bSalesReturn = false;
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                bSalesReturn = VHMS.DataAccess.Billing.SalesReturn.DeleteSalesReturn(ID);
                if (bSalesReturn == true)
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
            sException = "SalesReturn DeleteSalesReturn |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "SalesReturn_R_01" || ex.Message.ToString() == "SalesReturn_D_01")
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

    public string GetSalesReturnReport(VHMS.Entity.Billing.SalesReturnFilter oJobCardFilter)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            //int BranchID = 0;
            if (ValidateSession())
            {
                //Collection<VHMS.Entity.patient> ObjList = new Collection<VHMS.Entity.patient>();
                //ObjList = VHMS.DataAccess.patient.GetpatientDetails(oJobCardFilter);
                Collection<VHMS.Entity.Billing.SalesReturn> ObjList = new Collection<VHMS.Entity.Billing.SalesReturn>();
                //ObjList = VHMS.DataAccess.Billing.SalesReturn.GetSalesReturnReport(oJobCardFilter);
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
            sException = "JobCard GetJobCard |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetSalesReturnSummary()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                DataSet dsResult = new DataSet();
                dsResult = VHMS.DataAccess.Billing.SalesReturn.GetSalesReturnSummary();

                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = GetDtJson(dsResult.Tables[0]);
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
            sException = "SalesReturn GetSalesReturnSummary |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    #endregion

    #region "Purchase"
    public string GetPurchase(int PublisherID = 0, int BillType = 0)
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
                Collection<VHMS.Entity.Billing.Purchase> ObjList = new Collection<VHMS.Entity.Billing.Purchase>();
                ObjList = VHMS.DataAccess.Billing.Purchase.GetPurchase(PublisherID, BillType, iCompanyID);
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
            sException = "Purchase GetPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetPurchaseEntryByNo(int PublisherID = 0, int BillType = 0, int iSupplierID = 0)
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
                Collection<VHMS.Entity.Billing.Purchase> ObjList = new Collection<VHMS.Entity.Billing.Purchase>();
                ObjList = VHMS.DataAccess.Billing.Purchase.GetPurchaseEntryByNo(PublisherID, BillType, iSupplierID, iCompanyID);
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
            sException = "Purchase GetPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetTopPurchase(int PublisherID = 0, int BillType = 0)
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
                Collection<VHMS.Entity.Billing.Purchase> ObjList = new Collection<VHMS.Entity.Billing.Purchase>();
                ObjList = VHMS.DataAccess.Billing.Purchase.GetTopPurchase(PublisherID, BillType, iCompanyID);
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
            sException = "Purchase GetPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetTopPurchaseSupplierWise(int iSupplierID = 0, int BillType = 0, int DC = 0)
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
                Collection<VHMS.Entity.Billing.Purchase> ObjList = new Collection<VHMS.Entity.Billing.Purchase>();
                ObjList = VHMS.DataAccess.Billing.Purchase.GetTopPurchaseSupplierWise(iSupplierID, BillType, DC, iCompanyID);
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
            sException = "Purchase GetPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetTopPurchasePending(int PublisherID = 0, int BillType = 0)
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
                Collection<VHMS.Entity.Billing.Purchase> ObjList = new Collection<VHMS.Entity.Billing.Purchase>();
                ObjList = VHMS.DataAccess.Billing.Purchase.GetTopPurchasePending(PublisherID, BillType, iCompanyID);
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
            sException = "Purchase GetPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetPendingPurchase(int PublisherID = 0, int BillType = 1)
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
                Collection<VHMS.Entity.Billing.Purchase> ObjList = new Collection<VHMS.Entity.Billing.Purchase>();
                ObjList = VHMS.DataAccess.Billing.Purchase.GetPendingPurchase(PublisherID, BillType, iCompanyID);
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
            sException = "Purchase GetPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetPurchaseDiscountBillNo(int SupplierID = 0, int BillType = 1, int PurchaseReturnID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int FK_FinancialYearID = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                Collection<VHMS.Entity.Billing.Purchase> ObjList = new Collection<VHMS.Entity.Billing.Purchase>();
                ObjList = VHMS.DataAccess.Billing.Purchase.GetPurchaseDiscountBillNo(SupplierID, BillType, PurchaseReturnID, FK_FinancialYearID, iCompanyID);
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
            sException = "Purchase GetPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetPendingPurchaseDiscountBillNo(int SupplierID = 0, int BillType = 1, int PurchaseReturnID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int FK_FinancialYearID = 0;
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.Purchase> ObjList = new Collection<VHMS.Entity.Billing.Purchase>();
                ObjList = VHMS.DataAccess.Billing.Purchase.GetPendingPurchaseDiscountBillNo(SupplierID, BillType, PurchaseReturnID, FK_FinancialYearID);
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
            sException = "Purchase GetPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetBillNo(int SupplierID = 0, int BillType = 1, int PurchaseReturnID = 0)
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
                Collection<VHMS.Entity.Billing.Purchase> ObjList = new Collection<VHMS.Entity.Billing.Purchase>();
                ObjList = VHMS.DataAccess.Billing.Purchase.GetBillNo(SupplierID, BillType, PurchaseReturnID, iCompanyID);
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
            sException = "Purchase GetPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string SearchPurchase(string ID = null, int BillType = 1, int DC = 0)
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
                Collection<VHMS.Entity.Billing.Purchase> ObjList = new Collection<VHMS.Entity.Billing.Purchase>();
                ObjList = VHMS.DataAccess.Billing.Purchase.SearchPurchase(ID, BillType, DC);
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
            sException = "Purchase GetPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string SearchPurchasePending(string ID = null, int BillType = 1)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.Purchase> ObjList = new Collection<VHMS.Entity.Billing.Purchase>();
                ObjList = VHMS.DataAccess.Billing.Purchase.SearchPurchasePending(ID, BillType);
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
            sException = "Purchase GetPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetPurchaseByID(int ID, int BillType = 1)
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
                VHMS.Entity.Billing.Purchase objPurchase = new VHMS.Entity.Billing.Purchase();
                objPurchase = VHMS.DataAccess.Billing.Purchase.GetPurchaseByID(ID, BillType, iCompanyID);
                if (objPurchase.PurchaseID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objPurchase);
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
            sException = "Purchase GetPurchaseByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetPurchasTranseByID(int ID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                VHMS.Entity.Billing.PurchaseTrans objPurchase = new VHMS.Entity.Billing.PurchaseTrans();
                objPurchase = VHMS.DataAccess.Billing.PurchaseTrans.GetPurchaseTransByID(ID);
                if (objPurchase.PurchaseID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objPurchase);
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
            sException = "Purchase GetPurchaseByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddPurchase(VHMS.Entity.Billing.Purchase Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iPurchaseId = 0;

        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                iPurchaseId = VHMS.DataAccess.Billing.Purchase.AddPurchase(Objdata);
                if (iPurchaseId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iPurchaseId.ToString();
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
            sException = "Purchase AddPurchase |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Purchase_A_01")
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
    public string UpdatePurchase(VHMS.Entity.Billing.Purchase Objdata)
    {
        string sPurchaseId = string.Empty;
        string sException = string.Empty;
        bool bPurchase = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.ModifiedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;
                bPurchase = VHMS.DataAccess.Billing.Purchase.UpdatePurchase(Objdata);
                if (bPurchase == true)
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
            sException = "Purchase UpdatePurchase |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Purchase_U_01")
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
    public string UpdatePurchasePending(VHMS.Entity.Billing.Purchase Objdata)
    {
        string sPurchaseId = string.Empty;
        string sException = string.Empty;
        bool bPurchase = false;
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
                bPurchase = VHMS.DataAccess.Billing.Purchase.UpdatePurchasePending(Objdata);
                if (bPurchase == true)
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
            sException = "Purchase UpdatePurchasePending |" + ex.Message.ToString();
            Log.Write(sException);
        }
        return jsonObject.Serialize(objResponse);
    }
    public string DeletePurchase(int ID)
    {
        string sPurchaseId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bPurchase = false;
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                bPurchase = VHMS.DataAccess.Billing.Purchase.DeletePurchase(ID, iUserId);
                if (bPurchase == true)
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
            sException = "Purchase DeletePurchase |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Purchase_R_01" || ex.Message.ToString() == "Purchase_D_01")
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

    #region "SalesEntry"
    public string GetSalesEntry(int PublisherID = 0, int IsRetail = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.GetSalesEntry(PublisherID, IsRetail);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetTDSSalesEntry(int PublisherID = 0, int TDSSalesID = 0, int IsRetail = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.GetTDSSalesEntry(PublisherID, TDSSalesID, IsRetail);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetAdjustTDSSalesEntry(int PublisherID = 0, int TDSSalesID = 0, int IsRetail = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.GetAdjustTDSSalesEntry(PublisherID, TDSSalesID, IsRetail);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetLastInvoiceNo()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int iCompanyId = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyId))
            {
                VHMS.Entity.Billing.SalesEntry objUser = new VHMS.Entity.Billing.SalesEntry();
                objUser = VHMS.DataAccess.Billing.SalesEntry.GetLastInvoiceNo(iCompanyId);
                if (objUser.InvoiceNo.Length > 0)
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
    public string GetPendingRetailSales()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.GetPendingRetailSales();
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetTopSalesEntry(int PublisherID = 0, int IsRetail = 0, int iCustomerID = 0)
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
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.GetTopSalesEntry(PublisherID, IsRetail, iCustomerID, iCompanyID);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetTopSalesEntryDeleteList(int PublisherID = 0, int IsRetail = 0, int iCustomerID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.GetTopSalesEntryDeleteList(PublisherID, IsRetail, iCustomerID);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetSalesEntryBookingBill(int PublisherID = 0, int IsRetail = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.GetSalesEntryBookingBill(PublisherID, IsRetail);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string SearchSalesEntryBokingBill(string ID = null, int IsRetail = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.SearchSalesEntryBokingBill(ID, IsRetail);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetPendingSalesEntry(int PublisherID = 0)
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
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.GetPendingSalesEntry(PublisherID, iCompanyID);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetAmountClearEntry(int PublisherID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.RetailPaymentMode> ObjList = new Collection<VHMS.Entity.Billing.RetailPaymentMode>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.GetAmountClearEntry(PublisherID);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetPendingRetailBills(int PublisherID = 0)
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
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.GetPendingRetailBills(PublisherID, iCompanyID);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string SearchSalesEntry(string ID = null, int IsRetail = 0)
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
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.SearchSalesEntry(ID, IsRetail, iCompanyID);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string SearchSalesEntryDeleteList(string ID = null, int IsRetail = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            if (ValidateSession())
            {
                Collection<VHMS.Entity.Billing.SalesEntry> ObjList = new Collection<VHMS.Entity.Billing.SalesEntry>();
                ObjList = VHMS.DataAccess.Billing.SalesEntry.SearchSalesEntryDeleteList(ID, IsRetail);
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
            sException = "SalesEntry GetSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetSalesEntryByInvoice(string InvoiceNo)
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
                VHMS.Entity.Billing.SalesEntry objSales = new VHMS.Entity.Billing.SalesEntry();
                objSales = VHMS.DataAccess.Billing.SalesEntry.GetSalesEntryByInvoice(InvoiceNo, iCompanyID);
                if (objSales.SalesEntryID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objSales);
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
            sException = "Sales GetSalesByInvoice |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetSalesEntryByInvoiceReturn(string InvoiceNo, int SalesReturnID)
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
                VHMS.Entity.Billing.SalesEntry objSales = new VHMS.Entity.Billing.SalesEntry();
                objSales = VHMS.DataAccess.Billing.SalesEntry.GetSalesEntryByInvoiceReturn(InvoiceNo, SalesReturnID, iCompanyID);
                if (objSales.SalesEntryID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objSales);
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
            sException = "Sales GetSalesByInvoice |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetSalesEntryByID(int ID, int IsRetail = 0)
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
                VHMS.Entity.Billing.SalesEntry objSalesEntry = new VHMS.Entity.Billing.SalesEntry();
                objSalesEntry = VHMS.DataAccess.Billing.SalesEntry.GetSalesEntryByID(ID, IsRetail, iCompanyID);
                if (objSalesEntry.SalesEntryID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objSalesEntry);
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
            sException = "SalesEntry GetSalesEntryByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetLastSalesEntryByID(int ID, int IsRetail = 0)
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
                VHMS.Entity.Billing.SalesEntry objSalesEntry = new VHMS.Entity.Billing.SalesEntry();
                objSalesEntry = VHMS.DataAccess.Billing.SalesEntry.GetLastSalesEntryByID(ID, IsRetail, iCompanyID);
                if (objSalesEntry.SalesEntryID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objSalesEntry);
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
            sException = "SalesEntry GetSalesEntryByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddSalesEntry(VHMS.Entity.Billing.SalesEntry Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iSalesEntryId = 0;
        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                iSalesEntryId = VHMS.DataAccess.Billing.SalesEntry.AddSalesEntry(Objdata);
                if (iSalesEntryId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iSalesEntryId.ToString();
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
            sException = "SalesEntry AddSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "SalesEntry_A_01")
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
    public string UpdateSalesEntry(VHMS.Entity.Billing.SalesEntry Objdata)
    {
        string sSalesEntryId = string.Empty;
        string sException = string.Empty;
        bool bSalesEntry = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.ModifiedBy = objUser;
                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                bSalesEntry = VHMS.DataAccess.Billing.SalesEntry.UpdateSalesEntry(Objdata);
                if (bSalesEntry == true)
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
            sException = "SalesEntry UpdateSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "SalesEntry_U_01")
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
    public string DeleteSalesEntry(int ID, string Reason)
    {
        string sSalesEntryId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bSalesEntry = false;
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                bSalesEntry = VHMS.DataAccess.Billing.SalesEntry.DeleteSalesEntry(ID, Reason, iUserId);
                if (bSalesEntry == true)
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
            sException = "SalesEntry DeleteSalesEntry |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "SalesEntry_R_01" || ex.Message.ToString() == "SalesEntry_D_01")
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

    #region "PurchaseReturn"
    public string GetPurchaseReturn(int PublisherID = 0, int iSupplierID = 0, int BillType = 1)
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
                Collection<VHMS.Entity.Billing.PurchaseReturn> ObjList = new Collection<VHMS.Entity.Billing.PurchaseReturn>();
                ObjList = VHMS.DataAccess.Billing.PurchaseReturn.GetPurchaseReturn(PublisherID, iSupplierID, BillType, iCompanyID);
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
            sException = "PurchaseReturn GetPurchaseReturn |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    //public string GetPurchaseReturnID(int PublisherID = 0)
    //{
    //    string sException = string.Empty;
    //    string sFileNames = string.Empty;
    //    JavaScriptSerializer jsObject = new JavaScriptSerializer();
    //    VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
    //    try
    //    {
    //        if (ValidateSession())
    //        {
    //            Collection<VHMS.Entity.Billing.PurchaseReturn> ObjList = new Collection<VHMS.Entity.Billing.PurchaseReturn>();
    //            ObjList = VHMS.DataAccess.Billing.PurchaseReturn.GetPurchaseReturnID(PublisherID);
    //            objResponse.Status = "Success";
    //            objResponse.Value = ObjList.Count > 0 ? jsObject.Serialize(ObjList) : "NoRecord";
    //        }
    //        else
    //        {
    //            objResponse.Status = "Error";
    //            objResponse.Value = "0";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        sException = "PurchaseReturn GetPurchaseReturn |" + ex.Message.ToString();
    //        Log.Write(sException);
    //        objResponse.Status = "Error";
    //        objResponse.Value = "Error";
    //    }
    //    return jsObject.Serialize(objResponse);
    //}

    public string SearchPurchaseReturn(string ID = null, int BillType = 1)
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
                Collection<VHMS.Entity.Billing.PurchaseReturn> ObjList = new Collection<VHMS.Entity.Billing.PurchaseReturn>();
                ObjList = VHMS.DataAccess.Billing.PurchaseReturn.SearchPurchaseReturn(ID, BillType, iCompanyID);
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
            sException = "PurchaseReturn GetPurchaseReturn |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetPurchaseReturnByID(int ID, int Type)
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
                VHMS.Entity.Billing.PurchaseReturn objPurchaseReturn = new VHMS.Entity.Billing.PurchaseReturn();
                objPurchaseReturn = VHMS.DataAccess.Billing.PurchaseReturn.GetPurchaseReturnByID(ID, Type, iCompanyID);
                if (objPurchaseReturn.PurchaseReturnID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objPurchaseReturn);
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
            sException = "PurchaseReturn GetPurchaseReturnByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetQuantity(int ID, int PurchaseID, int SupplierID)
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
                VHMS.Entity.Billing.PurchaseReturnTrans objPurchaseReturn = new VHMS.Entity.Billing.PurchaseReturnTrans();
                objPurchaseReturn = VHMS.DataAccess.Billing.PurchaseReturnTrans.GetQuantity(ID, PurchaseID, SupplierID, iCompanyID);
                if (objPurchaseReturn.PurchaseReturnID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objPurchaseReturn);
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
            sException = "PurchaseReturn GetPurchaseReturnByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddPurchaseReturn(VHMS.Entity.Billing.PurchaseReturn Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iPurchaseReturnId = 0;
        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                iPurchaseReturnId = VHMS.DataAccess.Billing.PurchaseReturn.AddPurchaseReturn(Objdata);
                if (iPurchaseReturnId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iPurchaseReturnId.ToString();
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
            sException = "PurchaseReturn AddPurchaseReturn |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "PurchaseReturn_A_01")
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
    public string UpdatePurchaseReturn(VHMS.Entity.Billing.PurchaseReturn Objdata)
    {
        string sPurchaseReturnId = string.Empty;
        string sException = string.Empty;
        bool bPurchaseReturn = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.ModifiedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;
                bPurchaseReturn = VHMS.DataAccess.Billing.PurchaseReturn.UpdatePurchaseReturn(Objdata);
                if (bPurchaseReturn == true)
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
            sException = "PurchaseReturn UpdatePurchaseReturn |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "PurchaseReturn_U_01")
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
    public string DeletePurchaseReturn(int ID)
    {
        string sPurchaseReturnId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bPurchaseReturn = false;
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                bPurchaseReturn = VHMS.DataAccess.Billing.PurchaseReturn.DeletePurchaseReturn(ID, iUserId);
                if (bPurchaseReturn == true)
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
            sException = "PurchaseReturn DeletePurchaseReturn |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "PurchaseReturn_R_01" || ex.Message.ToString() == "PurchaseReturn_D_01")
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

    #region "Payment"
    public string GetPayment()
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int iCompanyId = 0;
            int FK_FinancialYearID = 0;

            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyId))
            {
                Collection<VHMS.Entity.Billing.Payment> ObjList = new Collection<VHMS.Entity.Billing.Payment>();
                ObjList = VHMS.DataAccess.Billing.Payment.GetPayment(iCompanyId);
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
            sException = "Payment GetPayment |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetLastPaymentDetails(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int iCompanyId = 0;
            int FK_FinancialYearID = 0;

            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyId))
            {
                Collection<VHMS.Entity.Billing.Payment> ObjList = new Collection<VHMS.Entity.Billing.Payment>();
                ObjList = VHMS.DataAccess.Billing.Payment.GetLastPaymentDetails(ID, iCompanyId);
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
            sException = "Payment GetPayment |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetPaymentByID(int ID)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int iCompanyId = 0;
            int FK_FinancialYearID = 0;

            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyId))
            {
                VHMS.Entity.Billing.Payment objPayment = new VHMS.Entity.Billing.Payment();
                objPayment = VHMS.DataAccess.Billing.Payment.GetPaymentByID(ID, iCompanyId);
                if (objPayment.PaymentID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objPayment);
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
            sException = "Payment GetPaymentByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddPayment(VHMS.Entity.Billing.Payment Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iPaymentId = 0;

        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;
                iPaymentId = VHMS.DataAccess.Billing.Payment.AddPayment(Objdata);
                if (iPaymentId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iPaymentId.ToString();
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
            sException = "Payment AddPayment |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Payment_A_01")
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
    public string UpdatePayment(VHMS.Entity.Billing.Payment Objdata)
    {
        string sPaymentId = string.Empty;
        string sException = string.Empty;
        bool bPayment = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int FK_FinancialYearID = 0;

        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.ModifiedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                bPayment = VHMS.DataAccess.Billing.Payment.UpdatePayment(Objdata);
                if (bPayment == true)
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
            sException = "Payment UpdatePayment |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Payment_U_01")
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
    public string DeletePayment(int ID)
    {
        string sPaymentId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bPayment = false;
        try
        {
            if (ValidateSession())
            {
                bPayment = VHMS.DataAccess.Billing.Payment.DeletePayment(ID);
                if (bPayment == true)
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
            sException = "Payment DeletePayment |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Payment_R_01" || ex.Message.ToString() == "Payment_D_01")
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

    #region "Receipt"
    public string GetReceipt(int IsRetail)
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
                Collection<VHMS.Entity.Receipt> ObjList = new Collection<VHMS.Entity.Receipt>();
                ObjList = VHMS.DataAccess.Billing.Receipt.GetReceipt(IsRetail, iCompanyID);
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
            sException = "Receipt GetReceipt |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetLastReceiptDetails(int ID)
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
                Collection<VHMS.Entity.Receipt> ObjList = new Collection<VHMS.Entity.Receipt>();
                ObjList = VHMS.DataAccess.Billing.Receipt.GetLastReceiptDetails(ID, iCompanyID);
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
            sException = "Receipt GetReceipt |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetReceiptByStatus(string Status)
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
                Collection<VHMS.Entity.Receipt> ObjList = new Collection<VHMS.Entity.Receipt>();
                ObjList = VHMS.DataAccess.Billing.Receipt.GetReceiptByStatus(Status, iCompanyID);
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
            sException = "Receipt GetReceipt |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetReceiptByID(int ID, int IsRetail)
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
                VHMS.Entity.Receipt objReceipt = new VHMS.Entity.Receipt();
                objReceipt = VHMS.DataAccess.Billing.Receipt.GetReceiptByID(ID, IsRetail, iCompanyID);
                if (objReceipt.ReceiptID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objReceipt);
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
            sException = "Receipt GetReceiptByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetOnAccountAmount(int ID, string Type)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iCompanyID = 0;
            if (ValidateSession())
            {
                VHMS.Entity.Receipt objReceipt = new VHMS.Entity.Receipt();
                objReceipt = VHMS.DataAccess.Billing.Receipt.GetOnAccountAmount(ID, Type);
                if (objReceipt.OnAccount >= 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objReceipt);
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
            sException = "Receipt GetReceiptByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddReceipt(VHMS.Entity.Receipt Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iReceiptId = 0;
        int iUserId = 0;
        int iCompanyID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID) && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                iReceiptId = VHMS.DataAccess.Billing.Receipt.AddReceipt(Objdata);
                if (iReceiptId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iReceiptId.ToString();
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
            sException = "Receipt AddReceipt |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Receipt_A_01")
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
    public string UpdateReceipt(VHMS.Entity.Receipt Objdata)
    {
        string sReceiptId = string.Empty;
        string sException = string.Empty;
        bool bReceipt = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iUserId = 0;
        int iCompanyID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID) && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.ModifiedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;
                bReceipt = VHMS.DataAccess.Billing.Receipt.UpdateReceipt(Objdata);
                if (bReceipt == true)
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
            sException = "Receipt UpdateReceipt |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Receipt_U_01")
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
    public string DeleteReceipt(int ID)
    {
        string sReceiptId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bReceipt = false;
        try
        {
            if (ValidateSession())
            {
                bReceipt = VHMS.DataAccess.Billing.Receipt.DeleteReceipt(ID);
                if (bReceipt == true)
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
            sException = "Receipt DeleteReceipt |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Receipt_R_01" || ex.Message.ToString() == "Receipt_D_01")
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

    #region "Expense"
    public string GetExpense(int PublisherID = 0)
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
                Collection<VHMS.Entity.Billing.Expense> ObjList = new Collection<VHMS.Entity.Billing.Expense>();
                ObjList = VHMS.DataAccess.Billing.Expense.GetExpense(PublisherID, iCompanyID);
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
            sException = "Expense GetExpense |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string SearchExpense(string ID = null)
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
                Collection<VHMS.Entity.Billing.Expense> ObjList = new Collection<VHMS.Entity.Billing.Expense>();
                ObjList = VHMS.DataAccess.Billing.Expense.SearchExpense(ID, iCompanyID);
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
            sException = "Expense GetExpense |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetExpenseByID(int ID)
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
                VHMS.Entity.Billing.Expense objExpense = new VHMS.Entity.Billing.Expense();
                objExpense = VHMS.DataAccess.Billing.Expense.GetExpenseByID(ID, iCompanyID);
                if (objExpense.ExpenseID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objExpense);
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
            sException = "Expense GetExpenseByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddExpense(VHMS.Entity.Billing.Expense Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iExpenseId = 0;
        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;
                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                iExpenseId = VHMS.DataAccess.Billing.Expense.AddExpense(Objdata);
                if (iExpenseId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iExpenseId.ToString();
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
            sException = "Expense AddExpense |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Expense_A_01")
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
    public string UpdateExpense(VHMS.Entity.Billing.Expense Objdata)
    {
        string sExpenseId = string.Empty;
        string sException = string.Empty;
        bool bExpense = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int iCompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId) && Int32.TryParse(HttpContext.Current.Session["CompanyID"].ToString(), out iCompanyID))
            {
                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.ModifiedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = iCompanyID;
                Objdata.Company = objCompany;

                bExpense = VHMS.DataAccess.Billing.Expense.UpdateExpense(Objdata);
                if (bExpense == true)
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
            sException = "Expense UpdateExpense |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Expense_U_01")
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
    public string DeleteExpense(int ID)
    {
        string sExpenseId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bExpense = false;
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                bExpense = VHMS.DataAccess.Billing.Expense.DeleteExpense(ID, iUserId);
                if (bExpense == true)
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
            sException = "Expense DeleteExpense |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "Expense_R_01" || ex.Message.ToString() == "Expense_D_01")
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

    #region "SalesOrder"
    public string GetSalesOrder(int PublisherID = 0, string Flag = null)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int FK_FinancialYearID = 0;
            int CompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                Collection<VHMS.Entity.Billing.SalesOrder> ObjList = new Collection<VHMS.Entity.Billing.SalesOrder>();
                ObjList = VHMS.DataAccess.Billing.SalesOrder.GetSalesOrder(PublisherID, Flag, CompanyID);
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
            sException = "SalesOrder GetSalesOrder |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }


    public string GetSalesOrderPending(int PublisherID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int FK_FinancialYearID = 0;
            int CompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                Collection<VHMS.Entity.Billing.SalesOrder> ObjList = new Collection<VHMS.Entity.Billing.SalesOrder>();
                ObjList = VHMS.DataAccess.Billing.SalesOrder.GetSalesOrderPending(PublisherID, CompanyID);
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
            sException = "SalesOrder GetSalesOrderPending |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string GetSalesOrderByCustomer(int CustomerID = 0)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int FK_FinancialYearID = 0;
            int CompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                Collection<VHMS.Entity.Billing.SalesOrder> ObjList = new Collection<VHMS.Entity.Billing.SalesOrder>();
                ObjList = VHMS.DataAccess.Billing.SalesOrder.GetSalesOrderByCustomer(CustomerID, CompanyID);
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
            sException = "SalesOrder GetSalesOrderByCustomer |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }

    public string SearchSalesOrder(string ID = null, string Flag = null)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int FK_FinancialYearID = 0;
            int CompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                Collection<VHMS.Entity.Billing.SalesOrder> ObjList = new Collection<VHMS.Entity.Billing.SalesOrder>();
                ObjList = VHMS.DataAccess.Billing.SalesOrder.SearchSalesOrder(ID, Flag, CompanyID);
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
            sException = "SalesOrder GetSalesOrder |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string GetSalesOrderByID(int ID, string iFlag = null)
    {
        string sException = string.Empty;
        string sFileNames = string.Empty;
        JavaScriptSerializer jsObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        try
        {
            int iUserId = 0;
            int FK_FinancialYearID = 0;
            int CompanyID = 0;
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                VHMS.Entity.Billing.SalesOrder objSalesOrder = new VHMS.Entity.Billing.SalesOrder();
                objSalesOrder = VHMS.DataAccess.Billing.SalesOrder.GetSalesOrderByID(ID, iFlag);
                if (objSalesOrder.SalesOrderID > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = jsObject.Serialize(objSalesOrder);
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
            sException = "SalesOrder GetSalesOrderByID |" + ex.Message.ToString();
            Log.Write(sException);
            objResponse.Status = "Error";
            objResponse.Value = "Error";
        }
        return jsObject.Serialize(objResponse);
    }
    public string AddSalesOrder(VHMS.Entity.Billing.SalesOrder Objdata)
    {
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iSalesOrderId = 0;
        int iUserId = 0;
        int FK_FinancialYearID = 0;
        int CompanyID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {

                //VHMS.Entity.FinancialYear objFinancialYear = new VHMS.Entity.FinancialYear();
                //objFinancialYear.FinancialYearID = FK_FinancialYearID;
                //Objdata.FinancialYear = objFinancialYear;

                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.CreatedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = CompanyID;
                Objdata.Company = objCompany;

                iSalesOrderId = VHMS.DataAccess.Billing.SalesOrder.AddSalesOrder(Objdata);
                if (iSalesOrderId > 0)
                {
                    objResponse.Status = "Success";
                    objResponse.Value = iSalesOrderId.ToString();
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
            sException = "SalesOrder AddSalesOrder |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "SalesOrder_A_01")
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
    public string UpdateSalesOrder(VHMS.Entity.Billing.SalesOrder Objdata)
    {
        string sSalesOrderId = string.Empty;
        string sException = string.Empty;
        bool bSalesOrder = false;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        int iUserId = 0;
        int FK_FinancialYearID = 0;
        int CompanyID = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {

                //VHMS.Entity.FinancialYear objFinancialYear = new VHMS.Entity.FinancialYear();
                //objFinancialYear.FinancialYearID = FK_FinancialYearID;
                //Objdata.FinancialYear = objFinancialYear;

                VHMS.Entity.User objUser = new VHMS.Entity.User();
                objUser.UserID = iUserId;
                Objdata.ModifiedBy = objUser;

                VHMS.Entity.Company objCompany = new VHMS.Entity.Company();
                objCompany.CompanyID = CompanyID;
                Objdata.Company = objCompany;
                bSalesOrder = VHMS.DataAccess.Billing.SalesOrder.UpdateSalesOrder(Objdata);
                if (bSalesOrder == true)
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
            sException = "SalesOrder UpdateSalesOrder |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "SalesOrder_U_01")
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
    public string DeleteSalesOrder(int ID)
    {
        string sSalesOrderId = string.Empty;
        string sException = string.Empty;
        JavaScriptSerializer jsonObject = new JavaScriptSerializer();
        VHMS.Entity.Response objResponse = new VHMS.Entity.Response();
        bool bSalesOrder = false;
        int iUserId = 0;
        try
        {
            if (ValidateSession() && Int32.TryParse(HttpContext.Current.Session["UserID"].ToString(), out iUserId))
            {
                bSalesOrder = VHMS.DataAccess.Billing.SalesOrder.DeleteSalesOrder(ID, iUserId);
                if (bSalesOrder == true)
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
            sException = "SalesOrder DeleteSalesOrder |" + ex.Message.ToString();
            Log.Write(sException);
            if (ex.Message.ToString() == "SalesOrder_R_01" || ex.Message.ToString() == "SalesOrder_D_01")
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