using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Globalization;
using KeepDynamic.Barcode.Generator;
using BarcodeLib.Barcode.ASP.NET;
using BarcodeLib.Barcode.CrystalReports;
using BarcodeLib.Barcode;
using Zen.Barcode;
using TarCode.Barcode.Control;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System.Web.Services;

public partial class frmBarcode : BaseConfig
{
    string iBarcode = "";
    string formName = "StockAdjuest";
    DataSet dsData = new DataSet();
    DataSet dsPurchase = new DataSet();
    ReportDocument rprt = new ReportDocument();
    string sException = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            VHMSService.AddPageVisitLog();
            if (HttpContext.Current.Session["Barcode"] != null)
                txtBarcode.Text = HttpContext.Current.Session["Barcode"].ToString();
            else
                txtBarcode.Text = "";
            if (HttpContext.Current.Session["BarcodeQty"] != null)
                txtCount.Text = HttpContext.Current.Session["BarcodeQty"].ToString();
            else
                txtCount.Text = "1";
            if (HttpContext.Current.Session["ScreenName"] != null)
                formName = HttpContext.Current.Session["ScreenName"].ToString();


            if (HttpContext.Current.Session["BarcodePurchaseID"] != null)
            {
                if (formName == "Purchase")
                {
                    GetPurchaseDetails(HttpContext.Current.Session["BarcodePurchaseID"].ToString());
                    btnPrintAll.Visible = true;
                }
                else
                    btnPrintAll.Visible = false;
            }
            else
            {
                btnPrintAll.Visible = false;
                txtCount.Text = "1";
            }

            Session["Barcode"] = null;
            Session["BarcodePurchaseID"] = null;
            Session["BarcodeQty"] = null;
            Session["ScreenName"] = "";
            btnPrint.BackColor = Color.LightBlue;
            btnPrintAll.BackColor = Color.LightBlue;
        }

    }

    public void GetPurchaseDetails(string ID)
    {
        dsPurchase = VHMS.DataAccess.VHMSReports.PrintPurchaseByID(Convert.ToInt32(ID));
        if (dsPurchase.Tables.Count > 0 && dsPurchase.Tables[1].Rows.Count > 0)
        {
            GridView1.DataSource = dsPurchase.Tables[1];
            GridView1.DataBind();
        }
    }


    [WebMethod]
    public static string[] GetBarcode(string prefix)
    {
        Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
        List<string> customers = new List<string>();
        //customers = VHMS.DataAccess.Master.Product.GetProductList(prefix);
        return customers.ToArray();
    }

    [WebMethod]
    public static string[] GetBarcodeList(string prefix)
    {
        Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
        List<string> customers = new List<string>();
       // customers = VHMS.DataAccess.Master.Product.GetBarcodeList(prefix);
        return customers.ToArray();
    }


    [WebMethod]
    public static string[] GetBarcodeCode(string prefix, int SupplierID, string IsAll)
    {
        Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
        List<string> customers = new List<string>();
        if (IsAll == "A")
            SupplierID = 0;
     //   customers = VHMS.DataAccess.Master.Product.GetProductCodeList(prefix, SupplierID);
        return customers.ToArray();
    }

    [WebMethod]
    public static string[] GetSMSCode(string prefix, int SupplierID, string IsAll)
    {
        Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
        List<string> customers = new List<string>();
        if (IsAll == "A")
            SupplierID = 0;
   //     customers = VHMS.DataAccess.Master.Product.GetProductSMSCodeList(prefix, SupplierID);
        return customers.ToArray();
    }

    public void bindReport()
    {
        if (txtBarcode.Text.Length > 0)
        {

            if (txtCount.Text.Length > 0)
            {
                string barCode = txtBarcode.Text;
                var drawObject = BarcodeDrawFactory.GetSymbology(Zen.Barcode.BarcodeSymbology.Code128);
                var metrics = drawObject.GetDefaultMetrics(30);
                metrics.Scale = 2;
                System.Drawing.Image BackgroundImage = drawObject.Draw(Convert.ToString(txtBarcode.Text.Trim()), metrics);

                ImageConverter converter = new ImageConverter();
                byte[] byteImage;
                byteImage = (byte[])converter.ConvertTo(BackgroundImage, typeof(byte[]));

                try
                {
                    ReportDataSet dsReportData = new ReportDataSet();
                    dsData = VHMS.DataAccess.VHMSReports.PrintBarcode(txtBarcode.Text.Trim());

                    if (dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                    {
                        dsData.Tables[0].TableName = "tProduct";
                        ReportDataSet.tBarcodeRow drTb_BarcodeRow = null;
                        int BarcodeCount = Convert.ToInt32(txtCount.Text);
                        foreach (DataRow drow in dsData.Tables[0].Rows)
                        {
                            for (int i = 0; i < BarcodeCount; i++)
                            {
                                drTb_BarcodeRow = dsReportData.tBarcode.NewtBarcodeRow();
                                drTb_BarcodeRow.SellingPrice = Convert.ToDecimal(drow["SellingPrice"]);
                                drTb_BarcodeRow.PurchaseDate = Convert.ToDateTime(drow["PurchaseDate"]);
                                drTb_BarcodeRow.ProductName = Convert.ToString(drow["ProductName"]);
                                drTb_BarcodeRow.Barcode = byteImage;
                                drTb_BarcodeRow.Barcodelabel = barCode;

                                if (drTb_BarcodeRow.RowState == System.Data.DataRowState.Detached)
                                    dsReportData.tBarcode.Rows.Add(drTb_BarcodeRow);
                            }
                        }
                    }

                    rprt = new ReportDocument();
                    rprt.Load(Server.MapPath("~/Reports/rptSMSreaderBarcode.rpt"));
                    rprt.SetDataSource(dsReportData);
                    this.CRDischargeSummaryReport.ReportSource = rprt;
                    CRDischargeSummaryReport.AllowedExportFormats = (int)(CrystalDecisions.Shared.ViewerExportFormats.AllFormats ^ CrystalDecisions.Shared.ViewerExportFormats.RptFormat);
                    CRDischargeSummaryReport.Zoom(100);
                    this.CRDischargeSummaryReport.DataBind();

                }

                catch (Exception ex)
                {
                    sException = "frmPrintJobCard | " + ex.ToString();
                    Log.Write(sException);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter Print Count');", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter Barcode or SMS Code');", true);
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        btnGenrate_Click(sender, e);
        //ExportReport();
    }
    private void ExportReport()
    {
        ExportOptions exopt = default(ExportOptions);
        DiskFileDestinationOptions dfdopt = new DiskFileDestinationOptions();
        string fname = "barcode.pdf";
        dfdopt.DiskFileName = Server.MapPath(fname);

        exopt = rprt.ExportOptions;
        exopt.ExportDestinationType = ExportDestinationType.DiskFile;

        exopt.ExportFormatType = ExportFormatType.PortableDocFormat;
        exopt.DestinationOptions = dfdopt;

        rprt.Export();

        string Path = Server.MapPath(fname);
        Session["myFilePath"] = Path;
        Response.Write("<script>window.open ('ViewPDF.aspx?reportFile=" + Path + "','_blank');</script>");
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) { }
    }
    protected void btnPrintAll_Click(object sender, EventArgs e)
    {
        try
        {
            ReportDataSet dsReportData = new ReportDataSet();
            foreach (GridViewRow row in GridView1.Rows)
            {

                txtBarcode.Text = (row.FindControl("txtBarcode") as TextBox).Text.Trim();
                txtCount.Text = (row.FindControl("txtQuantity") as TextBox).Text;
                dsData = VHMS.DataAccess.VHMSReports.PrintBarcode(txtBarcode.Text);

                if (dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    dsData.Tables[0].TableName = "tProduct";
                    ReportDataSet.tBarcodeRow drTb_BarcodeRow = null;
                    decimal Count = Convert.ToDecimal(txtCount.Text);
                    int BarcodeCount = Convert.ToInt32(Count);
                    foreach (DataRow drow in dsData.Tables[0].Rows)
                    {
                        string barCode;
                        barCode = drow["Barcode"].ToString();
                        var drawObject = BarcodeDrawFactory.GetSymbology(Zen.Barcode.BarcodeSymbology.Code128);
                        var metrics = drawObject.GetDefaultMetrics(30);
                        metrics.Scale = 2;
                        System.Drawing.Image BackgroundImage = drawObject.Draw(Convert.ToString(barCode), metrics);

                        ImageConverter converter = new ImageConverter();
                        byte[] byteImage;
                        byteImage = (byte[])converter.ConvertTo(BackgroundImage, typeof(byte[]));

                        for (int i = 0; i < BarcodeCount; i++)
                        {
                            drTb_BarcodeRow = dsReportData.tBarcode.NewtBarcodeRow();
                            drTb_BarcodeRow.SellingPrice = Convert.ToDecimal(drow["SellingPrice"]);
                            drTb_BarcodeRow.PurchaseDate = Convert.ToDateTime(drow["PurchaseDate"]);
                            drTb_BarcodeRow.ProductName = Convert.ToString(drow["ProductName"]);
                            drTb_BarcodeRow.Barcode = byteImage;
                            drTb_BarcodeRow.Barcodelabel = barCode;

                            if (drTb_BarcodeRow.RowState == System.Data.DataRowState.Detached)
                                dsReportData.tBarcode.Rows.Add(drTb_BarcodeRow);
                        }
                    }
                }
            }
            rprt = new ReportDocument();
            rprt.Load(Server.MapPath("~/Reports/rptBarcode.rpt"));

            rprt.SetDataSource(dsReportData);
            this.CRDischargeSummaryReport.ReportSource = rprt;
            CRDischargeSummaryReport.AllowedExportFormats = (int)(CrystalDecisions.Shared.ViewerExportFormats.AllFormats ^ CrystalDecisions.Shared.ViewerExportFormats.RptFormat);
            CRDischargeSummaryReport.Zoom(100);
            this.CRDischargeSummaryReport.DataBind();
            //ExportReport();
        }
        catch (Exception ex)
        {
            sException = "frmPrintJobCard | " + ex.ToString();
            Log.Write(sException);
        }
    }
    protected void RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
        txtBarcode.Text = (row.FindControl("txtBarcode") as TextBox).Text;
        txtCount.Text = (row.FindControl("txtQuantity") as TextBox).Text;
        btnGenrate_Click(sender, e);
        //ExportReport();
    }

    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        if (txtBarcode.Text.Length > 0)
        {
            if (txtCount.Text.Length > 0)
            {
                try
                {
                    ReportDataSet dsReportData = new ReportDataSet();
                    if (txtBarcode.Text.Length > 0)
                        dsData = VHMS.DataAccess.VHMSReports.PrintBarcode(txtBarcode.Text.Trim());
                    if (dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                    {
                        dsData.Tables[0].TableName = "tProduct";
                        ReportDataSet.tBarcodeRow drTb_BarcodeRow = null;
                        decimal Count = Convert.ToDecimal(txtCount.Text);
                        int BarcodeCount = Convert.ToInt32(Count);
                        foreach (DataRow drow in dsData.Tables[0].Rows)
                        {
                            if (txtBarcode.Text.Length <= 0)
                                txtBarcode.Text = drow["TextCode"].ToString();
                            string barCode = "";
                            if (txtBarcode.Text.Length > 0)
                            {
                                barCode = txtBarcode.Text.Trim();
                            }
                            var drawObject = BarcodeDrawFactory.GetSymbology(Zen.Barcode.BarcodeSymbology.Code128);
                            var metrics = drawObject.GetDefaultMetrics(30);
                            metrics.Scale = 2;
                            System.Drawing.Image BackgroundImage = drawObject.Draw(Convert.ToString(barCode), metrics);

                            ImageConverter converter = new ImageConverter();
                            byte[] byteImage;
                            byteImage = (byte[])converter.ConvertTo(BackgroundImage, typeof(byte[]));

                            for (int i = 0; i < BarcodeCount; i++)
                            {
                                drTb_BarcodeRow = dsReportData.tBarcode.NewtBarcodeRow();
                                drTb_BarcodeRow.SellingPrice = Convert.ToDecimal(drow["SellingPrice"]);
                                drTb_BarcodeRow.PurchaseDate = Convert.ToDateTime(drow["PurchaseDate"]);
                                drTb_BarcodeRow.ProductName = Convert.ToString(drow["ProductName"]);
                                drTb_BarcodeRow.Barcode = byteImage;
                                drTb_BarcodeRow.Barcodelabel = barCode;

                                if (drTb_BarcodeRow.RowState == System.Data.DataRowState.Detached)
                                    dsReportData.tBarcode.Rows.Add(drTb_BarcodeRow);
                            }
                        }
                    }

                    rprt = new ReportDocument();
                    rprt.Load(Server.MapPath("~/Reports/rptBarcode.rpt"));
                    rprt.SetDataSource(dsReportData);
                    this.CRDischargeSummaryReport.ReportSource = rprt;
                    CRDischargeSummaryReport.AllowedExportFormats = (int)(CrystalDecisions.Shared.ViewerExportFormats.AllFormats ^ CrystalDecisions.Shared.ViewerExportFormats.RptFormat);
                    CRDischargeSummaryReport.Zoom(100);
                    this.CRDischargeSummaryReport.DataBind();

                }

                catch (Exception ex)
                {
                    sException = "frmPrintJobCard | " + ex.ToString();
                    Log.Write(sException);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter Print Count');", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter Barcode or SMS Code');", true);
        }

    }

}