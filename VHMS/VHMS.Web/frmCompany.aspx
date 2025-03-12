<%@ Page Title="Company" Language="C#" MasterPageFile="~/VHMSMasterPage.master" AutoEventWireup="true" CodeFile="frmCompany.aspx.cs" Inherits="frmCompany" %>
<asp:Content ID="Content3" ContentPlaceHolderID="VHMSWebHead" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="VHMSWebContent" runat="Server">
    <div class="container-wrapper hidden">
        <section class="content-header">
            <h1>Company
            </h1>
             <ol class="breadcrumb">
                <li><a href="frmDefault.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li class="active">Company</li>
            </ol>
            <div class="pull-right">
                <button id="btnAddNew" class="btn btn-primary">
                    <i class="fa fa-plus-square"></i>&nbsp;&nbsp;Add New</button>
                <button id="btnList" class="btn btn-primary">
                    <i class="fa fa-list"></i>&nbsp;&nbsp;List</button>
            </div>
            <br />
            <br />
        </section>
        <section class="content">
            <div class="row" id="divRecords">
                <div class="col-xs-12">
                    <div class="box box-warning">
                        <div class="box-body">
                            <div class="table-responsive">
                                <table id="tblRecord" class="table table-striped table-bordered table-hover bg-info" width="100%">
                                    <thead>
                                        <tr>
                                            <th>SNo
                                            </th>
                                            <th>Company Name
                                            </th>
                                            <th>Code
                                            </th>
                                            <th class='hidden-xs'>Contact Person
                                            </th>
                                            <th class='hidden-xs'>Email
                                            </th>
                                            <th class='hidden-xs'>GSTIN
                                            </th>
                                            <th class='hidden-xs'>Address</th>
                                            <th class='hidden-xs'>Phone 1</th>
                                            <th class='hidden-xs'>Phone 2</th>
                                            <th>View</th>
                                            <th>Edit</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tblRecord_tbody">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="nav-tabs-custom" id="tab-modal">
                <ul class="nav nav-tabs">
                    <li class="active"><a id="aGeneral" href="#General" data-toggle="tab">General</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="General">
                        <div class="row">
                            <div class="form-group col-md-8 col-sm-8" id="divName">
                                <label>
                                    Name</label><span class="text-danger">*</span>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-user"></i></div>
                                    <input type="text" class="form-control" id="txtName" placeholder="Please enter Company Name"
                                        maxlength="255" tabindex="1" />
                                </div>
                            </div>
                            <div class="form-group col-md-4 col-sm-4" id="divCode">
                                <label>
                                    Code</label><span class="text-danger">*</span>
                                <input type="text" class="form-control" id="txtCode" placeholder="Please enter Company Code"
                                    maxlength="10" tabindex="2" />
                            </div>
                            <div class="form-group col-md-12 col-sm-12" id="divAddress">
                                <label>
                                    Address</label><span class="text-danger">*</span>
                                <textarea id="txtAddress" class="form-control" maxlength="255" tabindex="3" rows="4"></textarea>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divContactPerson">
                                <label>
                                    Contact Person</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-user"></i></div>
                                    <input type="text" class="form-control" id="txtContactPerson" placeholder="Please enter Contact Person"
                                        maxlength="255" tabindex="4" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divContactNo">
                                <label>
                                    Contact No</label>
                                <input type="text" class="form-control" id="txtContactNo" placeholder="Please enter Contact No"
                                    maxlength="13" tabindex="5" />
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divPhoneNo1">
                                <label>
                                    Phone No 1</label><span class="text-danger">*</span>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-phone"></i></div>
                                    <input type="text" class="form-control" id="txtPhoneNo1" placeholder="Phone No" maxlength="13"
                                        tabindex="6" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divPhoneNo2">
                                <label>
                                    Phone No 2</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-phone"></i></div>
                                    <input type="text" class="form-control" id="txtPhoneNo2" placeholder="Phone No" maxlength="13"
                                        tabindex="7" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divLandline">
                                <label>
                                    LandLine</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-phone"></i></div>
                                    <input type="text" class="form-control" id="txtLandline" placeholder="Landline" maxlength="13"
                                        tabindex="8" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divFax">
                                <label>
                                    Fax</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-fax"></i></div>
                                    <input type="text" class="form-control" id="txtFax" placeholder="Fax" maxlength="20"
                                        tabindex="9" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divTINNo" style="display: none">
                                <label>
                                    TIN No</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-sort-numeric-asc"></i></div>
                                    <input type="text" class="form-control" id="txtTINNo" placeholder="TIN No" maxlength="20" tabindex="10" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divCSTNo">
                                <label>
                                    GSTIN No</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-sort-numeric-asc"></i></div>
                                    <input type="text" class="form-control" id="txtCSTNo" style="text-transform: uppercase" placeholder="CST No" maxlength="20" tabindex="11" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divEmail">
                                <label>
                                    Email</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-envelope"></i></div>
                                    <input type="text" class="form-control" id="txtEmail" placeholder="Email" maxlength="50" tabindex="12" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divWebSite">
                                <label>
                                    Website</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-internet-explorer"></i></div>
                                    <input type="text" class="form-control" id="txtWebSite" placeholder="Website" maxlength="150" tabindex="13" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divBankName">
                                <label>
                                    Bank Name</label>
                                <input type="text" class="form-control TRSearch" id="txtBankName" placeholder="Bank Name"
                                    maxlength="500" tabindex="14" />
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divBranch Name">
                                <label>
                                    Branch Name</label>
                                <input type="text" class="form-control" id="txtBranchName" placeholder="Branch Name" maxlength="500"
                                    tabindex="15" />
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divAccountNo">
                                <label>
                                    Account No</label>
                                <input type="text" class="form-control" id="txtAccountNo" placeholder="Account No" maxlength="25"
                                    tabindex="16" />
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divIFSCCode">
                                <label>
                                    IFSC Code</label>
                                <input type="text" class="form-control" id="txtIFSCCode" placeholder="IFSC Code" maxlength="20"
                                    tabindex="17" />
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divFinancialYear">
                                <label>
                                    FinancialYear</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-phone"></i></div>
                                    <input type="text" class="form-control" id="txtFinancialYear" placeholder="Landline" maxlength="5"
                                        tabindex="18" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divCINNo" style="display:none;">
                                <label>
                                    CIN No</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-sort-numeric-asc"></i></div>
                                    <input type="text" class="form-control" id="txtCINNo" style="text-transform: uppercase" placeholder="CIN No" maxlength="50" tabindex="19" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 col-sm-3" id="divIEC " style="display:none;">
                                <label>
                                    IEC No</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><i class="fa fa-sort-numeric-asc"></i></div>
                                    <input type="text" class="form-control" id="txtIEC" style="text-transform: uppercase" placeholder="IEC Number" maxlength="500" tabindex="19" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer clearfix">
                            <button id="btnSave" type="button" class="btn btn-info pull-left" tabindex="17">
                                <i class="fa fa-save"></i>&nbsp;&nbsp;
                                Save</button>
                            <button id="btnUpdate" type="button" class="btn btn-info pull-left" tabindex="18">
                                <i class="fa fa-edit"></i>&nbsp;&nbsp;
                                Update</button>
                            <button type="button" class="btn btn-danger pull-right" id="btnClose" tabindex="19">
                                <i class="fa fa-times"></i>&nbsp;&nbsp;
                                Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <input type="hidden" id="hdnCompanyID" />
    <script type="text/javascript">
        $(document).ready(function () {
            ActionAdd = '<%=Session["ActionAdd"]%>';
            ActionUpdate = '<%=Session["ActionUpdate"]%>';
            ActionDelete = '<%=Session["ActionDelete"]%>';
            ActionView = '<%=Session["ActionView"]%>';

            $("#divRecords").show();
            $("#tab-modal").hide();
            $("#btnAddNew").show();
            $("#btnList").hide();

            pLoadingSetup(false);
            GetRecord();
            pLoadingSetup(true);
        });

        $("#btnAddNew").click(function () {
            $("#divRecords").hide();
            $("#tab-modal").show();
            $("#btnList").show();
            $("#btnAddNew").hide();
            $("#hdnCompanyID").val("");
            $("#btnSave").show();
            $("#btnUpdate").hide();
            $("#aGeneral").click();

            ClearFields();
            ClickCount = 0;
            return false;
        });
        function ClearCompanyData() {

        }

        $("#btnList,#btnClose").click(function () {
            $("#divRecords").show();
            $("#tab-modal").hide();
            $("#btnList").hide();
            $("#btnAddNew").show();
            $("#aGeneral").click();
            GetRecord();
            return false;
        });

        function GetRecord() {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetCompany",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != "") {
                        var objResponse = jQuery.parseJSON(data.d);
                        if (objResponse.Status == "Success") {
                            var notetable = $("#tblRecord").dataTable();
                            notetable.fnDestroy();
                            if (objResponse.Value != null && objResponse.Value != "NoRecord") {
                                var obj = $.parseJSON(objResponse.Value);
                                if (obj.length > 0) {
                                    $("#tblRecord_tbody").empty();
                                    var TypeStatus = "";
                                    for (var index = 0; index < obj.length; index++) {
                                        //if (obj[index].IsActive == "1") { TypeStatus = "<span class='label label-success'>Active</span>"; }
                                        //else { TypeStatus = "<span class='label label-warning'>Inactive</span>"; }

                                        var table = "<tr id='" + obj[index].CompanyID + "'>";
                                        table += "<td>" + (index + 1) + "</td>";
                                        table += "<td>" + obj[index].CompanyName + "</td>";
                                        table += "<td>" + obj[index].CompanyCode + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].ContactPerson + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].Email + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].CSTNo + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].CompanyAddress + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].PhoneNo1 + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].PhoneNo2 + "</td>";
                                        if (ActionView == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].CompanyID + " class='view' title='Click here to view'><i class='fa fa-eye text-yellow'/></a></td>"; }
                                        else { table += "<td></td>"; }
                                        if (ActionUpdate == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].CompanyID + " class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        table += "</tr>";
                                        $("#tblRecord_tbody").append(table);
                                    }
                                    $(".view").click(function () {
                                        if (ActionView == "1") {
                                            GetCompanyInformation($(this).parent().parent()[0].id);
                                            $("#btnSave").hide();
                                            $("#btnUpdate").hide();
                                        }
                                        else {
                                            $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                                            return false;
                                        }
                                    });
                                    $(".Edit").click(function () {
                                        if (ActionUpdate == "1") { GetCompanyInformation($(this).parent().parent()[0].id); }
                                        else {
                                            $.jGrowl("Access Denied", { sticky: false, theme: 'danger', life: jGrowlLife });
                                            return false;
                                        }
                                    });
                                }
                                dProgress(false);
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $("#tblRecord_tbody").empty();
                                dProgress(false);
                            }
                            $("#tblRecord").dataTable({
                                "bPaginate": true,
                                "bFilter": true,
                                "bSort": true,
                                "iDisplayLength": 25,
                                aoColumns: [
                                    { "sWidth": "3%" },
                                    { "sWidth": "20%" },
                                    { "sWidth": "5%" },
                                    { "sWidth": "10%" },
                                    { "sWidth": "10%" },
                                    { "sWidth": "10%" },
                                    { "sWidth": "20%" },
                                    { "sWidth": "8%" },
                                    { "sWidth": "8%" },
                                    { "sWidth": "3%" },
                                    { "sWidth": "3%" }
                                ]
                            });

                            $("#tblRecord_filter").addClass('pull-right');
                            $(".pagination").addClass('pull-right');
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                window.location("frmLogin.aspx");
                            }
                            else if (objResponse.Value == "Error") {
                                window.location = "frmErrorPage.aspx";
                            }
                        }
                    }
                    else {
                        $("#tblRecord_tbody").empty();
                        dProgress(false);
                    }
                },
                error: function (e) {
                    $.jGrowl("Error  Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
                    dProgress(false);
                }
            });
            return false;
        }
        $("#btnSave,#btnUpdate").click(function () {
            if (this.id == "btnSave") { if (ActionAdd != "1") { $.jGrowl("Access Denied", { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }
            else { if (ActionUpdate != "1") { $.Growl("Access Denied", { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }

            if ($("#txtName").val().trim() == "" || $("#txtName").val().trim() == undefined) {
                $.jGrowl("Please enter Company Name", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divName").addClass('has-error'); $("#txtName").focus(); return false;
            } else { $("#divName").removeClass('has-error'); }

            if ($("#txtCode").val().trim() == "" || $("#txtCode").val().trim() == undefined) {
                $.jGrowl("Please enter Code", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divCode").addClass('has-error'); $("#txtCode").focus(); return false;
            } else { $("#divCode").removeClass('has-error'); }

            if ($("#txtAddress").val().trim() == "" || $("#txtAddress").val().trim() == undefined) {
                $.jGrowl("Please enter Address", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divAddress").addClass('has-error'); $("#txtAddress").focus(); return false;
            } else { $("#divAddress").removeClass('has-error'); }

            if ($("#txtPhoneNo1").val().trim() == "" || $("#txtPhoneNo1").val().trim() == undefined) {
                $.jGrowl("Please enter Phone No", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divPhoneNo1").addClass('has-error'); $("#txtPhoneNo1").focus(); return false;
            } else { $("#divPhoneNo1").removeClass('has-error'); }

            if ($("#txtEmail").val().length > 0) {
                var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if (!regex.test($("#txtEmail").val())) {
                    $.jGrowl("Please enter valid email", { sticky: false, theme: 'warning', life: jGrowlLife });
                    return false;
                }
            }

            if ($("#txtFinancialYear").val().trim() == "" || $("#txtFinancialYear").val().trim() == undefined) {
                $.jGrowl("Please enter FinancialYear", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divFinancialYear").addClass('has-error'); $("#txtFinancialYear").focus();
                return false;
            } else { $("#divFinancialYear").removeClass('has-error'); }


            SaveandUpdateCompanyInformation();

            return false;
        });

        function ClearFields() {
            $("#txtName").val("");
            $("#txtCode").val("");
            $("#txtAddress").val("");
            $("#txtContactPerson").val("");
            $("#txtContactNo").val("");
            $("#txtPhoneNo1").val("");
            $("#txtPhoneNo2").val("");
            $("#txtLandline").val("");
            $("#txtFax").val("");
            $("#txtIEC").val("");
            $("#txtCSTNo").val("");
            $("#txtEmail").val("");
            $("#txtWebSite").val("");
            $("#txtFinancialYear").val("");
            $("#txtCINNo").val("");
            $("#txtBankName").val("");
            $("#txtBranchName").val("");
            $("#txtAccountNo").val("");
            $("#txtIFSCCode").val("");
            $("#divName").removeClass('has-error');
            $("#divCode").removeClass('has-error');
            $("#divAddress").removeClass('has-error');
            $("#divPhoneNo1").removeClass('has-error');
            return false;
        }

        function SaveandUpdateCompanyInformation() {
            var Obj = new Object();
            Obj.CompanyID = 0;
            Obj.CompanyName = $("#txtName").val().trim();
            Obj.CompanyCode = $("#txtCode").val().trim();
            Obj.CompanyAddress = $("#txtAddress").val().trim();
            Obj.ContactPerson = $("#txtContactPerson").val().trim();
            Obj.ContactNo = $("#txtContactNo").val().trim();
            Obj.PhoneNo1 = $("#txtPhoneNo1").val().trim();
            Obj.PhoneNo2 = $("#txtPhoneNo2").val().trim();
            Obj.LandLine = $("#txtLandline").val().trim();
            Obj.Fax = $("#txtFax").val().trim();
            Obj.Email = $("#txtEmail").val().trim();
            Obj.WebSite = $("#txtWebSite").val().trim();
            Obj.TINNo = $("#txtTINNo").val().trim();
            Obj.CSTNo = $("#txtCSTNo").val().trim().toUpperCase();
            Obj.FinancialYear = $("#txtFinancialYear").val().trim();
            Obj.BankName = $("#txtBankName").val().trim();
            Obj.BranchName = $("#txtBranchName").val().trim();
            Obj.AccountNo = $("#txtAccountNo").val().trim();
            Obj.IFSCCode = $("#txtIFSCCode").val().trim();

            if ($("#hdnCompanyID").val() > 0) {
                Obj.CompanyID = $("#hdnCompanyID").val();
                sMethodName = "UpdateCompany";
            }
            else { sMethodName = "AddCompany"; }

            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/" + sMethodName,
                data: JSON.stringify({ Objdata: Obj }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != "") {
                        var objResponse = jQuery.parseJSON(data.d);
                        if (objResponse.Status == "Success") {
                            if (objResponse.Value > 0) {
                                ClearFields();
                                if (sMethodName == "AddCompany") {
                                    $.jGrowl("Saved Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
                                    $("#hdnCompanyID").val(objResponse.Value);
                                }
                                else if (sMethodName == "UpdateCompany") { $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }

                                GetCompanyInformation();
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                window.location = "frmLogin.aspx";
                            }
                            else if (objResponse.Value == "Company_A_01") {
                                $.jGrowl("Name Already Exists", { sticky: false, theme: 'danger', life: jGrowlLife });
                            }
                            else if (objResponse.Value == "Error") {
                                window.location = "frmErrorPage.aspx";
                            }
                        }
                    }
                    else {
                        $.jGrowl("Error  Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
                    }
                },
                error: function (e) {
                    $.jGrowl("Error  Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
                }
            });
            return false;
        }

        function GetCompanyInformation(id) {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetCompanyByID",
                data: JSON.stringify({ ID: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != "") {
                        var objResponse = jQuery.parseJSON(data.d);
                        if (objResponse.Status == "Success") {
                            if (objResponse.Value != null && objResponse.Value != "NoRecord" && objResponse.Value != "Error") {
                                var obj = jQuery.parseJSON(objResponse.Value);
                                if (obj != null) {
                                    ClearFields();
                                    $("#btnAddNew").hide();
                                    $("#btnList").show();
                                    $("#btnSave").hide();
                                    $("#btnUpdate").show();
                                    $("#tab-modal").show();
                                    $("#aGeneral").click();
                                    $("#divRecords").hide();
                                    $("#hdnCompanyID").val(obj.CompanyID);
                                    $("#txtName").val(obj.CompanyName);
                                    $("#txtCode").val(obj.CompanyCode);
                                    $("#txtAddress").val(obj.CompanyAddress);
                                    $("#txtContactPerson").val(obj.ContactPerson);
                                    $("#txtContactNo").val(obj.ContactNo);
                                    $("#txtPhoneNo1").val(obj.PhoneNo1);
                                    $("#txtPhoneNo2").val(obj.PhoneNo2);
                                    $("#txtLandline").val(obj.LandLine);
                                    $("#txtFax").val(obj.Fax);
                                    $("#txtEmail").val(obj.Email);
                                    $("#txtWebSite").val(obj.WebSite);
                                    $("#txtTINNo").val(obj.TINNo);
                                    $("#txtCSTNo").val(obj.CSTNo);
                                    $("#txtBankName").val(obj.BankName);
                                    $("#txtBranchName").val(obj.BranchName);
                                    $("#txtAccountNo").val(obj.AccountNo);
                                    $("#txtIFSCCode").val(obj.IFSCCode);
                                    $("#txtFinancialYear").val(obj.FinancialYear);
                                    $("#txtCINNo").val(obj.CINNo);
                                    // $("#txtIEC").val(obj.IEC);
                                    dProgress(false);
                                }
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $.jGrowl("No Record", { sticky: false, theme: 'warning', life: jGrowlLife });
                                dProgress(false);
                            }
                            else if (objResponse.Value == "Error") {
                                $.jGrowl("Error", { sticky: false, theme: 'warning', life: jGrowlLife });
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                window.location("frmLogin.aspx");
                            }
                            else if (objResponse.Value == "Error") {
                                window.location = "frmErrorPage.aspx";
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $.jGrowl("No Record", { sticky: false, theme: 'warning', life: jGrowlLife });
                            }
                        }
                    }
                    else {
                        $.jGrowl("Error  Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
                        dProgress(false);
                    }
                },
                error: function () {
                    $.jGrowl("Error  Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
                }
            });
            return false;
        }
    </script>
</asp:Content>




