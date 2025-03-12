<%@ Page Title="Expense" Language="C#" MasterPageFile="~/VHMSMasterPage.master" AutoEventWireup="true" CodeFile="frmExpense.aspx.cs" Inherits="frmExpense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="VHMSWebHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VHMSWebContent" runat="Server">
    <div class="container-wrapper hidden">
        <section class="content-header" id="secHeader">
            <div id="divTitle">
                <h3>Expense
                </h3>
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
                    <li><a id="aSearchResult" href="#SearchResult" data-toggle="tab">Search Result</a></li>
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
                                                <th>Expense #</th>
                                                <th>Date</th>
                                                <th>Party</th>
                                                <th>Tax Amount</th>
                                                <th>Net Amount</th>
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
                                        Search Expense records</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtSearchName" placeholder="Please enter Details"
                                        maxlength="150" />
                                </div>

                                <div class="table-responsive">
                                    <table id="tblSearchResult" class="table table-striped table-bordered bg-info" width="100%">
                                        <thead>
                                            <tr>
                                                <th>S.No</th>
                                                <th>Expense #</th>
                                                <th>Date</th>
                                                <th>Party</th>
                                                <th>Tax Amount</th>
                                                <th>Net Amount</th>
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
                    <div class="box-title">Expense Information</div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="form-group col-md-2" id="divBillNo">
                            <label>
                                Expense No</label>
                            <input type="text" class="form-control" id="txtBillNo" placeholder="Exp. No"
                                maxlength="15" tabindex="1" readonly="true" />
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
                        <div class="form-group col-md-2" id="divParty">
                            <label>
                                Party</label><span class="text-danger">*</span>
                            <select id="ddlPartyName" class="form-control select2" data-placeholder="Select Party Name" tabindex="3"></select>
                        </div>
                        <div class="form-group col-md-2" id="divExpenseNo">
                            <label>
                                Bill No</label>
                            <input type="text" class="form-control" id="txtExpenseNo" placeholder="Bill No"
                                maxlength="15" tabindex="4" autocomplete="off" />
                        </div>
                        <div class="form-group col-md-2" id="divGSTNo"style="display:none">
                            <label>
                                GST No</label>
                            <input type="text" class="form-control" id="txtGSTNo" placeholder="GST No"
                                maxlength="15" tabindex="5" autocomplete="off" />
                        </div>
                    </div>
                    <div class="box box-primary box-solid">
                        <div class="box-header">
                            Particulars
                        </div>
                        <div class="box-body">
                            <div class="row">
                                <div class="form-group col-md-4" id="divLedgerName">
                                    <label>
                                        Ledger</label><span class="text-danger">*</span>
                                    <div id="divSelectLedgerName">
                                        <select id="ddlLedgerName" class="form-control select2" data-placeholder="Select Ledger Name" tabindex="6"></select>
                                    </div>
                                </div>
                                <div class="form-group col-md-2" id="divAmount">
                                    <label>
                                        Amount</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control TRSearch" id="txtAmount" placeholder="Amount"
                                        maxlength="12" tabindex="7" onkeypress="return IsNumeric(event)" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-4" id="divNotes">
                                    <label>
                                        Description</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control TRSearch" id="txtNotes" placeholder="Description"
                                        maxlength="12" tabindex="8" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-2 pull-right">
                                    <div class="margin">
                                        <button id="btnAddMagazine" type="button" class="btn btn-primary btn-sm margin pull-right" tabindex="9">
                                            <i class="fa fa-plus-square"></i>&nbsp;&nbsp;Add</button>
                                        <button id="btnUpdateMagazine" type="button" class="btn btn-primary btn-sm margin pull-right" tabindex="10">
                                            <i class="fa fa-edit"></i>&nbsp;&nbsp;Update</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive" style="min-height: 250px !Important;">
                        <div id="divOPBillingList">
                        </div>
                    </div>
                    <div class="row" style="display: none">
                        <div class="form-group col-md-1">
                            <label>
                                Tax</label><span class="text-danger">*</span>
                        </div>
                        <div class="form-group col-md-2" id="divTaxName">

                            <select id="ddlTaxName" class="form-control select2" data-placeholder="Select Tax Name" tabindex="11"></select>
                        </div>
                        <div class="form-group col-md-1"></div>

                        <div class="form-group col-md-1">
                            <label>
                                SGST</label>
                        </div>
                        <div class="form-group col-md-2" id="divSGST">

                            <input type="text" class="form-control" id="txtSGST" placeholder="SGST"
                                maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                        </div>

                        <div class="form-group col-md-2"></div>
                        <div class="form-group col-md-1">
                            <label>
                                Total Amount</label>
                        </div>
                        <div class="form-group col-md-2" id="divTotalAmount">

                            <input type="text" class="form-control" id="txtTotalAmount" style="font-weight: bold; font-size: 18px;" placeholder="Total Amount"
                                maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                        </div>
                    </div>
                    <div class="row" style="display: none">
                        <div class="form-group col-md-1">
                            <label>
                                CGST</label>
                        </div>
                        <div class="form-group col-md-2" id="divCGST">

                            <input type="text" class="form-control" id="txtCGST" placeholder="CGST"
                                maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                        </div>
                        <div class="form-group col-md-1"></div>
                        <div class="form-group col-md-1">
                            <label>
                                IGST</label>
                        </div>
                        <div class="form-group col-md-2" id="divIGST">

                            <input type="text" class="form-control" id="txtIGST" placeholder="SGST"
                                maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                        </div>
                        <div class="form-group col-md-2"></div>
                        <div class="form-group col-md-1">
                            <label>
                                Tax Amount</label>
                        </div>
                        <div class="form-group col-md-2" id="divTaxAmount">

                            <input type="text" class="form-control" id="txtTaxAmount" placeholder="Tax Amount" style="font-weight: bold; font-size: 18px;"
                                maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                        </div>
                    </div>
                    <div class="row" style="display:none">
                        <div class="form-group col-md-1">
                            <label>
                                Select A/c</label>
                            <span class="text-danger">*</span>
                        </div>
                        <div class="form-group col-md-2" id="divBank">
                            <select id="ddlBank" class="form-control select2" data-placeholder="Select Account" tabindex="12">
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-4"></div>
                        <div class="form-group col-md-1">
                            <label>
                                Receipt Mode</label>
                            <span class="text-danger">*</span>
                        </div>
                        <div class="form-group col-md-2" id="divReceiptMode">
                            <select id="ddlReceiptMode" class="form-control select2" tabindex="13">
                                <option value="0" selected="selected">--Select--</option>
                                <option value="1">Cash</option>
                                <option value="2">Cheque</option>
                                <option value="3">NEFT/RTGS</option>
                                <option value="4">Others</option>
                            </select>
                        </div>
                        <div class="form-group col-md-2"></div>
                        <div class="form-group col-md-1">
                            <label>
                                Net Amount</label>
                        </div>
                        <div class="form-group col-md-2" id="divNetAmount">

                            <input type="text" class="form-control" id="txtNetAmount" placeholder="Net Amount" style="font-weight: bold; font-size: 25px;"
                                maxlength="15" tabindex="-1" readonly="true" value="0" onkeypress="return IsNumeric(event)" />
                        </div>
                    </div>
                <div class="row" id="divChequeDetails">
                    <div class="form-group col-md-1">
                        <label>
                            Cheque/DD #</label><span class="text-danger">*</span>
                        <span class="text-danger">*</span>
                    </div>
                    <div class="form-group col-md-2" id="divChequeNo">
                        <input type="text" class="form-control" id="txtChequeNo" placeholder="Cheque/DD No."
                            maxlength="150" tabindex="14" autocomplete="off" />
                    </div>
                    <div class="form-group col-md-1"></div>
                    <div class="form-group col-md-1">
                        <label>
                            Issued Date</label><span class="text-danger">*</span>
                    </div>
                    <div class="form-group col-md-2" id="divIssueDate">
                        <div class="input-group date form_date" data-date-format="dd/MM/yyyy HH:ii P" data-link-field="txtIssueDate" data-link-format="dd/MM/yyyy">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <input class="form-control pull-right" tabindex="15" id="txtIssueDate" data-link-format="dd/MM/yyyy HH:ii P" type="text" readonly />
                        </div>
                    </div>
                    <div class="form-group col-md-2"></div>
                    <div class="form-group col-md-1">
                        <label>
                            Status</label><span class="text-danger">*</span>
                    </div>
                    <div class="form-group col-md-2" id="divStatus">
                        <select id="ddlPaymentStatus" class="form-control" tabindex="16">
                            <option value="Cleared">Cleared</option>
                            <option value="Pending">Pending</option>
                            <option value="Bounced">Bounced</option>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-1">
                        <label>
                            Description</label>
                    </div>
                    <div class="form-group col-md-3" id="divDescription">
                        <textarea id="txtDescription" class="form-control" maxlength="250" tabindex="17" rows="2" aria-autocomplete="none"></textarea>
                    </div>
                </div>
                <div class="modal-footer clearfix">
                    <button id="btnSave" type="button" class="btn btn-info margin pull-left" tabindex="18">
                        <i class="fa fa-save"></i>&nbsp;&nbsp;Save Changes</button>
                    <button id="btnUpdate" type="button" class="btn btn-info margin pull-left" tabindex="19">
                        <i class="fa fa-save"></i>&nbsp;&nbsp;Update Changes</button>
                    <button type="button" class="btn btn-danger pull-right" id="btnClose" tabindex="20">
                        <i class="fa fa-close"></i>&nbsp;&nbsp;Close</button>
                </div>
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
                            maxlength="150" tabindex="21" autocomplete="off" />
                    </div>
                    <div class="form-group" id="divID">
                        <label>
                            ID</label><span class="text-danger">*</span>
                        <input type="text" class="form-control" id="txtID"
                            maxlength="150" tabindex="22" />
                    </div>
                </div>
                <div class="modal-footer clearfix">
                    <button type="submit" class="btn btn-info pull-left" id="btnOK" tabindex="23">
                        <i class="fa fa-save"></i>&nbsp;&nbsp;Save</button>
                    <button type="button" class="btn btn-danger pull-right" id="btnCancel" tabindex="24">
                        <i class="fa fa-close"></i>&nbsp;&nbsp;Close</button>
                </div>
            </div>
        </div>
    </div>
    </section>
    </div>
    <input type="hidden" id="hdnExpenseID" />
    <input type="hidden" id="hdnExpenseTransID" />
    <input type="hidden" id="hdnTaxPercent" />
    <input type="hidden" id="hdnCGSTPercent" />
    <input type="hidden" id="hdnSGSTPercent" />
    <input type="hidden" id="hdnIGSTPercent" />
    <input type="hidden" id="hdnBalanceAmt" />
    <input type="hidden" id="hdnPaidAmt" />
    <input type="hidden" id="hdnNetAmt" />
    <input type="hidden" id="hdnMagazineID" />
    <input type="hidden" id="hdnOPSNo" />
    <input type="hidden" id="hdnOPOrderID" />
    <script src="UserDefined_Js/jExpense.js?v=<%= BaseConfig.GetFileHash("UserDefined_Js/jExpense.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        var _CMActionAdd = '<%=Session["ActionAdd"]%>';
        var _CMActionUpdate = '<%=Session["ActionUpdate"]%>';
        var _CMActionDelete = '<%=Session["ActionDelete"]%>';
        var _CMActionView = '<%=Session["ActionView"]%>';

        $(document).on('focus', '.select2-selection.select2-selection--single', function (e) {
            $(this).closest(".select2-container").siblings('select:enabled').select2('open');
        });

        // steal focus during close - only capture once and stop propogation
        $('select.select2').on('select2:closing', function (e) {
            $(e.target).data("select2").$selection.one('focus focusin', function (e) {
                e.stopPropagation();
            });
        });

        $(document).ready(function () {

        });
    </script>
</asp:Content>

