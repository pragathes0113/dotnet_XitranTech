using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

public partial class frmSalesReturnDetailedReport : System.Web.UI.Page
{
    DataSet dsData = new DataSet();
    string sException = string.Empty;
    string PaymentMode = "";
    decimal Qty = 0, NetAmount = 0, DiscountAmount = 0,TaxAmount=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            VHMSService.AddPageVisitLog();
            LoadCustomer();
            LoadProduct();
            txtDOB.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtDOR.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
    protected void ddlPayment_SelectedIndexChanged(object sender, EventArgs e)
    {
        // LoadReport();
    }
    //protected void BindData()
    //{
    //    DataTable result = (DataTable)Session["tSales"];
    //    if (result.Rows.Count > 0)
    //    {
    //        gvSales.DataSource = result;
    //        gvSales.DataBind();
    ////    }
    //  }


    protected void btnExcel_Click(object sender, EventArgs e)
    {
        if (gvSalesReturn.Rows.Count < 1)
        {
            string display = "no Records Found.";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
        }
        else
        {
            try
            {
                this.gvSalesReturn.AllowPaging = false;
                this.gvSalesReturn.AllowSorting = false;
                this.gvSalesReturn.EditIndex = -1;

                Response.Clear();
                Response.ContentType = "application/vnd.xls";
                Response.AddHeader("content-disposition", "attachment;filename=SalesReturnDetailedReports.xls");
                Response.Charset = "";
                StringWriter swriter = new StringWriter();
                HtmlTextWriter hwriter = new HtmlTextWriter(swriter);
                gvSalesReturn.RenderControl(hwriter);
                Response.Write(swriter.ToString());
                Response.End();
            }
            catch (Exception exe)
            {
                throw exe;
            }
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
    protected void btnPDF_Click(object sender, EventArgs e)
    {
        if (gvSalesReturn.Rows.Count < 1)
        {
            string display = "no Records Found.";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
        }
        else
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=SalesReturnDetailedReports.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvSalesReturn.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            gvSalesReturn.AllowPaging = true;
            gvSalesReturn.DataBind();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    private void LoadReport()
    {
        DateTime dtFrom = DateTime.MinValue, dtTo = DateTime.MinValue;
        ReportDataSet dsReportData = new ReportDataSet();

        dsData = VHMS.DataAccess.VHMSReports.PrintSalesReturnDetailedReport(0, txtDOB.Text, txtDOR.Text, ddlCustomer.SelectedValue, ddlPaymentMode.SelectedValue,ddlProduct.SelectedValue);
        try
        {
            if (dsData.Tables.Count > 0)
            {
                dsData.Tables[0].TableName = "tSalesReturnTrans";
                foreach (DataRow drow in dsData.Tables[0].Rows)
                    dsReportData.tSalesReturnTrans.ImportRow(drow);

                gvSalesReturn.DataSource = dsData.Tables[0];
                gvSalesReturn.DataBind();
            }

        }
        catch (Exception ex)
        {
            sException = "frmPrintSales | " + ex.ToString();
            Log.Write(sException);
        }
    }
    public void LoadProduct()
    {
        Collection<VHMS.Entity.Master.Product> ObjList = new Collection<VHMS.Entity.Master.Product>();
        ObjList = VHMS.DataAccess.Master.Product.GetProduct(0);

        ddlProduct.DataSource = ObjList;
        ddlProduct.DataTextField = "ProductName";
        ddlProduct.DataValueField = "ProductID";
        ddlProduct.DataBind();
        ddlProduct.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--All--", "0"));
    }
    public void LoadCustomer()
    {
        Collection<VHMS.Entity.Customer> ObjList = new Collection<VHMS.Entity.Customer>();
//        ObjList = VHMS.DataAccess.Customer.GetActiveCustomer();

        ddlCustomer.DataSource = ObjList;
        ddlCustomer.DataTextField = "CustomerName";
        ddlCustomer.DataValueField = "CustomerID";
        ddlCustomer.DataBind();
        ddlCustomer.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--All--", "0"));
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Qty += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Quantity"));
            TaxAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TaxAmount"));
            DiscountAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DiscountAmount"));
            NetAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SubTotal"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].ColumnSpan = 6;
            e.Row.Cells.RemoveAt(1);
            e.Row.Cells.RemoveAt(2);
            e.Row.Cells.RemoveAt(3);
            e.Row.Cells.RemoveAt(4);
            e.Row.Cells.RemoveAt(5);

            e.Row.Cells[2].Text = "Total Amount :";
            e.Row.Cells[3].Text = Convert.ToDecimal(Qty).ToString();
            e.Row.Cells[6].Text = Convert.ToDecimal(TaxAmount).ToString();
            e.Row.Cells[7].Text = Convert.ToDecimal(DiscountAmount).ToString();
            e.Row.Cells[8].Text = Convert.ToDecimal(NetAmount).ToString();
            e.Row.Cells[2].Font.Bold = true;
            e.Row.Cells[3].Font.Bold = true;
            e.Row.Cells[6].Font.Bold = true;
            e.Row.Cells[7].Font.Bold = true;
            e.Row.Cells[8].Font.Bold = true;
            e.Row.Cells[2].Font.Size = 14;
            e.Row.Cells[3].Font.Size = 14;
            e.Row.Cells[6].Font.Size = 14;
            e.Row.Cells[7].Font.Size = 14;
            e.Row.Cells[8].Font.Size = 14;
        }
    }
}

