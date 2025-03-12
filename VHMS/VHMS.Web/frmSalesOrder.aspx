<%@ Page Title="Qutations" Language="C#" MasterPageFile="~/VHMSMasterPage.master"
    AutoEventWireup="true" CodeFile="frmSalesOrder.aspx.cs" Inherits="frmSalesOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="VHMSWebHead" runat="Server">
    <style>
        .btnPrint, .btnPrintbill {
            background-color: #ef00bc !important;
            margin-top: 0px !important;
        }

        table.formatHTML5 tr.selected {
            background-color: #e92929 !important;
            color: #fff;
            vertical-align: middle;
            padding: 1.5em;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="VHMSWebContent" runat="Server">
    <div class="container-wrapper hidden">
        <section class="content-header" id="secHeader">
            <div id="divTitle">
                <h3>Qutations
                </h3>
                <ol class="breadcrumb">
                    <li><a href="frmDefault.aspx"><i class="fa fa-home"></i>Home</a></li>
                    <li class="active">Qutations </li>
                </ol>
            </div>
            <div class="breadcrumb">
                <button id="btnAddNew" class="btn btn-info">
                    <i class="fa fa-plus-square"></i>&nbsp;&nbsp;Add New</button>
                <button id="btnList" class="btn btn-info">
                    <i class="fa fa-list"></i>&nbsp;&nbsp;List</button>
            </div>
        </section>
        <section class="content">
            <div class="nav-tabs-custom" id="divTab">
                <ul class="nav nav-tabs">
                    <li class="active"><a id="aGeneral" href="#General" data-toggle="tab">General</a></li>
                    <li style="display: none"><a id="aSearchResult" href="#SearchResult" data-toggle="tab">Search Result</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="General">
                        <div class="box box-warning">
                            <div class="box-body">
                                <div class="table-responsive">
                                    <table id="tblRecord" class="table table-striped table-bordered bg-info" width="100%">
                                        <thead>
                                            <tr>
                                                <th>S.No</th>
                                                <th>Qutations #</th>
                                                <th>Date</th>
                                                <th>Customer</th>
                                                <th>Tax Amount</th>
                                                <th>Net Amount</th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody id="tblRecord_tbody">
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="SearchResult">
                        <div class="box box-warning">
                            <div class="box-body">
                                <div class="form-group" id="divSearchaname">
                                    <label>
                                        Search Whole Sales records</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtSearchName" placeholder="Please enter Details"
                                        maxlength="150" />
                                </div>

                                <div class="table-responsive">
                                    <table id="tblSearchResult" class="table table-striped table-bordered bg-info" width="100%">
                                        <thead>
                                            <tr>
                                                <th>S.No</th>
                                                <th>Qutations #</th>
                                                <th>Date</th>
                                                <th>Customer</th>
                                                <th>Tax Amount</th>
                                                <th>Net Amount</th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody id="tblSearchResult_tbody">
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box box-primary" id="divOPBilling">
                <div class="box-header with-border">
                    <div class="box-title">Qutations</div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="form-group col-md-2" id="divBillNo">
                            <label>
                                Qutations No</label>
                            <input type="text" class="form-control" id="txtBillNo" placeholder="Qutations No"
                                maxlength="15" tabindex="1" />
                        </div>
                        <div class="form-group col-md-2" id="divBillDate">
                            <label>
                                Date</label><span class="text-danger">*</span>
                            <div class="input-group date form_date" data-date-format="dd/MM/yyyy HH:ii P" data-link-field="txtOPBillingDate"
                                data-link-format="dd/MM/yyyy">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar glyphicon glyphicon-calendar"></i>
                                </div>
                                <input type="text" class="form-control pull-right" tabindex="2" id="txtBillDate" readonly="true" />
                            </div>
                        </div>
                        <div class="form-group col-md-3" id="divCustomer">
                            <label>
                                Customer</label><span class="text-danger">*</span>
                            <select id="ddlCustomerName" class="form-control select2" data-placeholder="Select Customer Name" tabindex="3"></select>
                        </div>
                       <%-- <div class="form-group col-md-2" id="divBranchr" style="display: none">
                            <label>
                                Branch</label><span class="text-danger">*</span>
                            <select id="ddlBranchName" class="form-control select2" data-placeholder="Select Branch Name" tabindex="3"></select>
                        </div>
                        <div class="form-group col-md-2" id="divPerson" style="display: none">
                            <label>
                                Contact Person</label>
                            <input type="text" class="form-control" id="txtPerson" placeholder="Contact Person"
                                maxlength="10" tabindex="-1" readonly="true" />
                        </div>--%>
             <%--           <div class="form-group col-md-2" style="display: none">
                            <label>
                                MobileNo</label>
                            <input type="text" class="form-control" id="txtMobileNo" placeholder="MobileNo"
                                maxlength="10" tabindex="-1" readonly="true" />
                        </div>--%>
                        <div class="form-group col-md-2" id="divTaxName">
                            <label>
                                Tax</label><span class="text-danger">*</span>
                            <select id="ddlTaxName" class="form-control select2" data-placeholder="Select Tax Name" tabindex="4"></select>
                        </div>
                  <%--      <div class="form-group col-md-2" id="divCompany" style="display:none">
                            <label>
                                Company</label><span class="text-danger">*</span>
                            <select id="ddlCompany" class="form-control select2" data-placeholder="Select Company" tabindex="5"></select>
                        </div>--%>
                       <%-- <div class="form-group col-md-2" id="divBillingType" style="display: none">
                            <label>
                                Billing Address Type
                            </label>
                            <span class="text-danger">*</span>
                            <select id="ddlBillingType" class="form-control" tabindex="3">
                                <option value="Office Address" selected="selected">Office Address</option>
                                <option value="Client address">Client address</option>
                                <option value="Post address">Post address</option>
                                <option value="Headoffice address">Headoffice address</option>
                            </select>
                        </div>
                        <div class="form-group col-md-4" id="divBillingAddress" style="display: none">
                            <label>
                                Billing Address</label><span class="text-danger">*</span>
                            <input type="text" class="form-control" id="txtBillingAddress" placeholder="Billing Address"
                                maxlength="1000" tabindex="-1" readonly="true" />
                        </div>
                        <div class="form-group col-md-2" id="divShippingType" style="display: none">
                            <label>
                                Shipping Address Type
                            </label>
                            <span class="text-danger">*</span>
                            <select id="ddlType" class="form-control" tabindex="3">
                                <option value="Office Address" selected="selected">Office Address</option>
                                <option value="Client address">Client address</option>
                                <option value="Post address">Post address</option>
                                <option value="Headoffice address">Headoffice address</option>
                            </select>
                        </div>
                        <div class="form-group col-md-4" id="divShippingAddress" style="display: none">
                            <label>
                                Shipping Address</label><span class="text-danger">*</span>
                            <input type="text" class="form-control" id="txtShippingAddress" placeholder="Shipping Address"
                                maxlength="1000" tabindex="-1" readonly="true" />
                        </div>--%>
                    </div>
                </div>
                <div class="box box-primary box-solid">
                    <div class="box-header">
                        Particulars
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="form-group col-md-1" id="divSno" style="width: 6%;">
                                <label>
                                    S.No</label>
                                <input type="text" class="form-control TRSearch" id="txtSNo" placeholder="Sno"
                                    maxlength="12" tabindex="-1" onkeypress="return IsNumeric(event)" readonly="true" />
                            </div>
                            <div class="form-group col-md-3" id="divProductName" style="margin-left: -21px;">
                                <label>
                                    Product</label><span class="text-danger">*</span>
                                <div id="divSelectProductName">
                                    <select id="ddlProductName" class="form-control select2" data-placeholder="Select Product Name" tabindex="5"></select>
                                </div>
                            </div>
                            <div class="form-group col-md-2" id="divDescription" style="margin-left: -21px;display:none">
                                <label>
                                    Description</label><span class="text-danger">*</span>
                                <textarea id="txtDescription" class="form-control" maxlength="1000" tabindex="-1" rows="1" aria-autocomplete="none"></textarea>
                            </div>
                            <div class="form-group col-md-1" id="divHSNCode" style="margin-left: -21px;display:none">
                                <label>
                                    HSNCode</label><span class="text-danger"></span>
                                <input type="text" class="form-control TRSearch" id="txtHSNCode" placeholder="Code"
                                    maxlength="100" tabindex="-1" autocomplete="off" />
                            </div>

                            <div class="form-group col-md-1" id="divQuantity" style="margin-left: -21px;">
                                <label>
                                    Quantity</label><span class="text-danger">*</span>
                                <input type="text" class="form-control TRSearch" id="txtQuantity" placeholder="Quantity"
                                    maxlength="12" tabindex="6" onkeypress="return IsNumeric(event)" autocomplete="off" />
                            </div>
                            <div class="form-group col-md-1" id="divRate" style="margin-left: -21px;">
                                <label>
                                    Rate</label><span class="text-danger">*</span>
                                <input type="text" class="form-control TRSearch" id="txtRate" placeholder="Rate"
                                    maxlength="12" tabindex="7" onkeypress="return IsNumeric(event)" autocomplete="off" />
                            </div>
                            <div class="form-group col-md-1" id="divUnit" style="margin-left: -21px; display: none">
                                <label>
                                    Unit</label><span class="text-danger">*</span>
                                <select id="ddlUnit" class="form-control select2" data-placeholder="Select Unit" tabindex="-1"></select>
                            </div>
                            <div class="form-group col-md-1" id="divTaxTrans" style="margin-left: -21px;">
                                <label>
                                    Tax</label><span class="text-danger">*</span>
                                <select id="ddlTax" class="form-control select2" data-placeholder="Select Tax " tabindex="13"></select>
                            </div>
                            <div class="form-group col-md-1" id="divTaxAmt" style="margin-left: -21px;">
                                <label>
                                    Tax Amt</label>
                                <input type="text" class="form-control TRSearch" id="txtTaxAmt" placeholder="Tax. Amt"
                                    maxlength="12" tabindex="-1" onkeypress="return IsNumeric(event)" readonly="true" />
                            </div>
                            <div class="form-group col-md-1" id="divDisPer" style="margin-left: -21px;">
                                <label>
                                    Disc %</label><span class="text-danger">*</span>
                                <input type="text" class="form-control TRSearch" id="txtDisPer" placeholder="Discount %"
                                    maxlength="12" tabindex="14" onkeypress="return IsNumeric(event)" autocomplete="off" />
                            </div>
                            <div class="form-group col-md-1" id="divDisAmt" style="margin-left: -21px;">
                                <label>
                                    Disc. Amt</label>
                                <input type="text" class="form-control TRSearch" id="txtDisAmt" placeholder="Disc. Amt"
                                    maxlength="12" tabindex="-1" onkeypress="return IsNumeric(event)" readonly="true" />
                            </div>
                            <div class="form-group col-md-1" id="divFrequency" style="margin-left: -21px;">
                                <label>
                                    Subtotal</label>
                                <input type="text" class="form-control TRSearch" id="txtSubTotal" placeholder="Subtotal"
                                    maxlength="12" tabindex="-1" onkeypress="return IsNumeric(event)" readonly="true" />
                            </div>
                            <div class="form-group col-md-2" id="divBarcode" style="display: none">
                                <input type="text" class="form-control TRSearch" id="txtBarcode" placeholder="Subtotal"
                                    maxlength="12" tabindex="-1" onkeypress="return IsNumeric(event)" readonly="true" />
                            </div>

                            <div class="form-group col-md-1 pull-right">
                                <div class="margin">
                                    <button id="btnAddMagazine" type="button" class="btn btn-primary btn-sm margin pull-right" tabindex="13">
                                        <i class="fa fa-plus-square"></i>&nbsp;&nbsp;Add</button>
                                    <button id="btnUpdateMagazine" type="button" class="btn btn-primary btn-sm margin pull-right" tabindex="14">
                                        <i class="fa fa-edit"></i>&nbsp;&nbsp;Update</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive" style="min-height: 400px !Important;">
                        <div id="divOPBillingList">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-8"></div>
                    <div class="form-group col-md-2" style="text-align: right;">
                        <label>
                            Total Amount</label>
                    </div>
                    <div class="form-group col-md-2" id="divAmount">
                        <input type="text" class="form-control" id="txtAmount" placeholder="Total Amount" style="font-size: 104%; font-weight: bold;"
                            maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-6"></div>
                    <div class="form-group col-md-1">
                        <label>
                            Discount %</label>
                        <span class="text-danger">*</span>
                    </div>
                    <div class="form-group col-md-1" id="divDiscountPercent">
                        <input type="text" class="form-control" id="txtDiscountPercent" placeholder="Discount Percent"
                            maxlength="15" tabindex="16" value="0" onkeypress="return IsNumeric(event)" autocomplete="off" />
                    </div>
                    <div class="form-group col-md-2" style="text-align: right;">
                        <label>
                            Discount Amt</label>
                    </div>
                    <div class="form-group col-md-2" id="divDiscountAmount">
                        <input type="text" class="form-control" id="txtDiscountAmount" placeholder="Discount Amount" style="font-size: 104%; font-weight: bold;"
                            maxlength="15" tabindex="17" value="0" onkeypress="return IsNumeric(event)" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-6"></div>
                    <div class="form-group col-md-1">
                        <label>
                            CGST</label>
                    </div>
                    <div class="form-group col-md-1" id="divCGST">
                        <input type="text" class="form-control" id="txtCGST" placeholder="CGST"
                            maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                    </div>
                    <div class="form-group col-md-2" style="text-align: right;">
                        <label>
                            Taxable Amount</label>
                    </div>
                    <div class="form-group col-md-2" id="divTotalAmount">
                        <input type="text" class="form-control" id="txtTotalAmount" placeholder="Total Amount" style="font-size: 104%; font-weight: bold;"
                            maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-6"></div>
                    <div class="form-group col-md-1">
                        <label>
                            SGST</label>
                    </div>
                    <div class="form-group col-md-1" id="divSGST">
                        <input type="text" class="form-control" id="txtSGST" placeholder="SGST"
                            maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                    </div>
                    <div class="form-group col-md-2" style="text-align: right;">
                        <label>
                            Tax Amount</label>
                    </div>
                    <div class="form-group col-md-2" id="divTaxAmount">
                        <input type="text" class="form-control" id="txtTaxAmount" placeholder="Tax Amount" style="font-size: 104%; font-weight: bold;"
                            maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-md-6"></div>
                    <div class="form-group col-md-1">
                        <label>
                            IGST</label>
                    </div>
                    <div class="form-group col-md-1" id="divIGST">
                        <input type="text" class="form-control" id="txtIGST" placeholder="SGST"
                            maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                    </div>
                    <div class="form-group col-md-2" style="text-align: right;">
                        <label>
                            Roundoff</label>
                    </div>
                    <div class="form-group col-md-2" id="divRoundoff">
                        <input type="text" class="form-control" id="txtRoundoff" placeholder="Roundoff" style="font-size: 104%; font-weight: bold;"
                            maxlength="15" tabindex="-1" value="0" autocomplete="off" readonly />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-8"></div>
                    <div class="form-group col-md-2" style="text-align: right">
                        <label style="font-size: 20px;">
                            Net Amount</label>
                    </div>
                    <div class="form-group col-md-2" id="divNetAmount">
                        <input type="text" class="form-control" id="txtNetAmount" placeholder="Net Amount" style="font-weight: bold; font-size: 20px;"
                            maxlength="15" tabindex="-1" readonly="true" style="width: 192px;" value="0" onkeypress="return IsNumeric(event)" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-1" id="divOtherPasswordlbl">
                        <label>
                            Password</label><span class="text-danger">*</span>
                    </div>
                    <div class="form-group col-md-2" id="divOtherPassword">
                        <input type="password" class="form-control" id="txtOtherPassword" placeholder="Special Password" autocomplete="off" maxlength="512"
                            tabindex="26" />
                    </div>
                </div>
                <div class="form-group col-md-12" id="divAddress">
                    <label>
                        Notes</label>
                    <textarea id="txtComments" class="form-control" maxlength="255" tabindex="27" rows="3" aria-autocomplete="none" style="width: 102%"></textarea>
                </div>
                <div class="row" style="display: none">
                    <div class="form-group col-md-4">
                        <label>
                            Image 1</label>
                        <button id="btnClearImage1" type="button" style="margin-top: -11px; color: deeppink;" class="btn btn-link">
                            Clear</button>
                        <input name="imagefile" type="file" id="imagefile2" data-image-src="imgUpload2_view" accept="image/*" onchange="ResizeImage('imagefile2');" />
                        <a href="#" data-fancybox="images">
                            <img src="" id="imgUpload2_view" alt="" class="preview_img" style="width: 280px;" />
                        </a>
                    </div>
                    <div class="form-group col-md-4">
                        <label>
                            Image 2</label>
                        <button id="btnClearImage2" type="button" style="margin-top: -11px; color: deeppink;" class="btn btn-link">
                            Clear</button>
                        <input name="imagefile" type="file" id="imagefile3" data-image-src="imgUpload3_view" accept="image/*" onchange="ResizeImage('imagefile3');" />
                        <a href="#" data-fancybox="images">
                            <img src="" id="imgUpload3_view" alt="" class="preview_img" style="width: 280px;" />
                        </a>
                    </div>
                    <div class="form-group col-md-4">
                        <label>
                            Image 3</label>
                        <button id="btnClearImage3" type="button" style="margin-top: -11px; color: deeppink;" class="btn btn-link">
                            Clear</button>
                        <input name="imagefile" type="file" id="imagefile4" data-image-src="imgUpload4_view" accept="image/*" onchange="ResizeImage('imagefile4');" />
                        <a href="#" data-fancybox="images">
                            <img src="" id="imgUpload4_view" alt="" class="preview_img" style="width: 280px;" />
                        </a>
                    </div>
                </div>



                <div class="modal-footer clearfix">
                    <button id="btnSave" type="button" class="btn btn-info margin pull-right" tabindex="16">
                        <i class="fa fa-save"></i>&nbsp;&nbsp;Save</button>
                    <button id="btnUpdate" type="button" class="btn btn-info margin pull-right" tabindex="17">
                        <i class="fa fa-save"></i>&nbsp;&nbsp;Update</button>
                    <button type="button" class="btn btn-danger margin pull-left" id="btnClose" tabindex="18">
                        <i class="fa fa-close"></i>&nbsp;&nbsp;Close</button>
                    <button id="btnPrintbill" type="button" class="btn btn-info btnPrint pull-right" style="margin-top: 10px !important;" tabindex="18">
                        <i class="fa fa-print"></i>&nbsp;&nbsp; Print</button>
                </div>
            </div>
            <div class="modal fade" id="compose-modal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title"></h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group" id="divReason">
                                <label>
                                    Reason</label><span class="text-danger">*</span>
                                <input type="text" class="form-control" id="txtReason" placeholder="Please enter Reason"
                                    maxlength="150" tabindex="35" />
                            </div>
                            <div class="form-group" id="divPassword">
                                <label>
                                    Password</label><span class="text-danger">*</span>
                                <input type="text" class="form-control" id="txtPassword" placeholder="Please enter Password"
                                    maxlength="150" tabindex="36" autocomplete="off" />
                            </div>
                            <div class="form-group" id="divID">
                                <label>
                                    ID</label><span class="text-danger">*</span>
                                <input type="text" class="form-control" id="txtID"
                                    maxlength="150" tabindex="37" />
                            </div>
                        </div>
                        <div class="modal-footer clearfix">
                            <button type="submit" class="btn btn-info pull-left" id="btnOK" tabindex="38">
                                <i class="fa fa-save"></i>&nbsp;&nbsp;
                                Save</button>
                            <button type="button" class="btn btn-danger pull-right" id="btnCancel" tabindex="39">
                                <i class="fa fa-close"></i>&nbsp;&nbsp;
                                Close</button>

                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <input type="hidden" id="hdnSalesOrderID" />
    <input type="hidden" id="hdnSalesID" />
    <input type="hidden" id="hdnBranchID" />
    <input type="hidden" id="hdnLastQutationsDate" />
    <input type="hidden" id="hdnSalesOrderTransID" />
    <input type="hidden" id="hdnTaxPercent" />
    <input type="hidden" id="hdnCGSTPercent" />
    <input type="hidden" id="hdnSGSTPercent" />
    <input type="hidden" id="hdnSMSCode" />
    <input type="hidden" id="hdnIGSTPercent" />
    <input type="hidden" id="hdRS" />
    <input type="hidden" id="hdnCGSTAmount" />
    <input type="hidden" id="hdnSGSTAmount" />
    <input type="hidden" id="hdnIGSTAmount" />
    <input type="hidden" id="hdnStateCode" />
    <input type="hidden" id="hdnstateID" />
    <input type="hidden" id="hdnSalesLimit" />
    <input type="hidden" id="hdnBranchBalanceAmount" />
    <input type="hidden" id="hdnSalesDiscountPercent" />
    <input type="hidden" id="hdnMaxsalesDiscount" />
    <input type="hidden" id="hdnBranchTypeID" />
    <input type="hidden" id="hdnTransTaxPercent" />
    <input type="hidden" id="hdnTransCGSTPercent" />
    <input type="hidden" id="hdnTransSGSTPercent" />
    <input type="hidden" id="hdnTransIGSTPercent" />
    <input type="hidden" id="hdnTransCGSTAmount" />
    <input type="hidden" id="hdnTransSGSTAmount" />
    <input type="hidden" id="hdnTransIGSTAmount" />
    <input type="hidden" id="hdnBalanceAmt" />
    <input type="hidden" id="hdnPaidAmt" />
    <input type="hidden" id="hdnNetAmt" />
    <input type="hidden" id="hdnStatus" />
    <input type="hidden" id="hdnIsAllProduct" />
    <input type="hidden" id="hdnOriginalRate" />
    <input type="hidden" id="hdnRateChanged" />
    <input type="hidden" id="hdnMagazineID" />
    <input type="hidden" id="hdnOPSNo" />
    <input type="hidden" id="hdnOPOrderID" />
    <script src="UserDefined_Js/jSalesOrder.js?v=<%= BaseConfig.GetFileHash("UserDefined_Js/jSalesOrder.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        var _CMActionAdd = '<%=Session["ActionAdd"]%>';
        var _CMActionUpdate = '<%=Session["ActionUpdate"]%>';
        var _CMActionDelete = '<%=Session["ActionDelete"]%>';
        var _CMActionView = '<%=Session["ActionView"]%>';
        var pageUrl = '<%=ResolveUrl("~/frmSalesOrder.aspx") %>';
        $(document).ready(function () {

            $('input,select').keydown(function (event) { //event==Keyevent
                if (event.which == 13) {
                    var inputs = $(this).closest('form').find(':input:visible');
                    inputs.eq(inputs.index(this) + 1).focus();
                    event.preventDefault(); //Disable standard Enterkey action

                }
            });

            $("[id$=txtCode]").change(function () {
                $("[id$=txtCode]").val(($("[id$=txtCode]").val().split('|')[0].trim()));
            });
            $("[id$=txtCode]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/frmBarcode.aspx/GetBarcodeCode") %>',
                        data: "{ 'prefix': '" + request.term + "','SupplierID':0,'IsAll':'A'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item,
                                    val: item.split('|')[0]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                open: function () {
                    $("[id$=txtCode]").autocomplete("widget").css({
                        "width": ("800px"), "backgroundColor": ("#d7dde2")
                    });
                },
                select: function (e, i) {
                },
                minLength: 1
            });
        });

    </script>
    <script type="text/javascript">
        document.onkeydown = function () {
            if (event.keyCode == 67 && event.altKey) {
                $('#hdnIsAllProduct').val(0);
                if ($("#ddlProductName").val() > 0) {
                    if ($("#txtCode").val() != "")
                        GetSalesProductDetails($("#ddlProductName").val(), $("#txtCode").val(), 0, $("#ddlBranchName").val());
                    else
                        GetSalesProductDetails($("#ddlProductName").val(), $("#hdnSMSCode").val(), 0, $("#ddlBranchName").val());
                    //$(".modal-title").html("&nbsp;&nbsp; Last 10 sales details of this Product to this Branch");

                    //$('#composedetails').modal({ show: true, backdrop: true });
                }
            }

            if (event.keyCode == 86 && event.altKey) {
                $('#hdnIsAllProduct').val(1);
                if ($("#ddlProductName").val() > 0) {
                    if ($("#txtCode").val() != "")
                        GetAllProductDetails($("#ddlProductName").val(), $("#txtCode").val(), 1, $("#ddlBranchName").val());
                    else
                        GetAllProductDetails($("#ddlProductName").val(), $("#hdnSMSCode").val(), 1, $("#ddlBranchName").val());
                }
            }
            if (event.keyCode == 81 && event.altKey) {
                GetRateByProduct();
                $(".modal-title").html("&nbsp;&nbsp; Search Rate");
                $('#composeRate').modal({ show: true, backdrop: true });
                $("#ddlProduct").val($("#ddlProductName").val()).change();
            }
        };



    </script>
    <script type="text/javascript" src="JS/fancybox/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="JS/fancybox/jquery.fancybox.css?v=2.1.4" media="screen" />
    <script type="text/javascript">

        $('img.preview_img').on('load', function () {
            //console.log($(this).attr('src'));
            $(this).parent("a").attr("href", $(this).attr("src"));
        });
        function ResizeImage(img_id) {

            var filesToUpload = document.getElementById(img_id).files;
            var file = filesToUpload[0];

            // Create an image
            var img = document.createElement("img");
            // Create a file reader
            var reader = new FileReader();
            // Set the image once loaded into file reader
            reader.onload = function (e) {
                //img.src = e.target.result;
                var img = new Image();

                img.src = this.result;

                setTimeout(function () {
                    var canvas = document.createElement("canvas");

                    var MAX_WIDTH = 1500;
                    var MAX_HEIGHT = 1000;
                    var width = img.width;
                    var height = img.height;

                    if (width > height) {
                        if (width > MAX_WIDTH) {
                            height *= MAX_WIDTH / width;
                            width = MAX_WIDTH;
                        }
                    } else {
                        if (height > MAX_HEIGHT) {
                            width *= MAX_HEIGHT / height;
                            height = MAX_HEIGHT;
                        }
                    }
                    canvas.width = width;
                    canvas.height = height;
                    var ctx = canvas.getContext("2d");
                    ctx.drawImage(img, 0, 0, width, height);
                    var dataurl = canvas.toDataURL("image/jpeg");
                    var image_view = $("#" + img_id).attr("data-image-src");
                    document.getElementById(image_view).src = dataurl;
                    $("#" + image_view).css({ "visibility": "visible", "display": "block" });
                    saveimage(image_view);

                }, 100);
            }
            // Load files into file reader
            reader.readAsDataURL(file);
        }
    </script>
</asp:Content>

