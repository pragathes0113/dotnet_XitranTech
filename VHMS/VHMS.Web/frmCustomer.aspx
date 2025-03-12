<%@ Page Title="Customer" Language="C#" MasterPageFile="~/VHMSMasterPage.master" AutoEventWireup="true" CodeFile="frmCustomer.aspx.cs" Inherits="frmCustomer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="VHMSWebHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VHMSWebContent" runat="Server">
    <div class="container-wrapper hidden">
        <section class="content-header">
            <h1>Customer
            </h1>
            <div class="form-group  col-md-4" style="margin-left: 255px; margin-top: -34px;">
                <label>
                    Customer Name</label>
                <select id="ddlCategoryName" class="form-control select2" data-placeholder="Select Category Name" tabindex="-1"></select>
            </div>
            <ol class="breadcrumb">
                <li><a href="frmDefault.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a href="#">Master</a></li>
                <li class="active">Customer</li>
            </ol>
            <div class="pull-right">
                <button id="btnAddNew" class="btn btn-info">
                    <i class="fa fa-plus-square"></i>&nbsp;&nbsp;Add New</button>
            </div>
            <br />
            <br />
        </section>
        <section class="content">
            <div class="nav-tabs-custom" id="divTab">
       <%--         <ul class="nav nav-tabs">
                    <li class="active"><a id="aGeneral" href="#General" data-toggle="tab">General</a></li>
                    <li><a id="aSearchResult" href="#SearchResult" data-toggle="tab">Search Result</a></li>
                </ul>--%>
                <div class="tab-content">
                    <div class="tab-pane active" id="General">
                        <div class="box box-warning">
                            <div class="box-body">
                                <div class="table-responsive">
                                    <table id="tblRecord" class="table table-striped table-bordered bg-info" width="100%">
                                        <thead>
                                            <tr>
                                               <th>SNo
                                                    </th>
                                                    <th>Customer
                                                    </th>
                                                    <th class="hidden-xs">Address
                                                    </th>
                                                    <th class="hidden-xs">MobileNo
                                                    </th>
                                                    <th class="hidden-xs">Status
                                                    </th>
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
                                <div class="form-group col-md-4" id="divSearchaname">
                                    <label>
                                        Search records</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtSearchName" placeholder="Please enter search details"
                                        maxlength="150" />
                                </div>
                                <div class="form-group col-md-8"></div>
                                <div class="form-group col-md-12">
                                    <div class="table-responsive">
                                        <table id="tblSearchResult" class="table table-striped table-bordered bg-info" width="100%">
                                            <thead>
                                                <tr>
                                                    <th>SNo
                                                    </th>
                                                    <th>Customer
                                                    </th>
                                                    <th class="hidden-xs">Address
                                                    </th>
                                                    <th class="hidden-xs">MobileNo
                                                    </th>
                                                    <th class="hidden-xs">Status
                                                    </th>
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
            </div>
            <div class="modal fade" id="compose-modal" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title"></h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="form-group col-md-6" id="divName">
                                    <label>
                                        Customer</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtName" style="text-transform: uppercase" placeholder="Please enter Customer Name"
                                        maxlength="150" tabindex="1" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-2" style="display:none">
                                    <label>
                                        Code</label>
                                    <input type="text" class="form-control" id="txtCode" placeholder="Please enter Code"
                                        maxlength="50" tabindex="-1" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-3" id="divMobileNo">
                                    <label>
                                        Mobile No</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtMobileNo" placeholder="Please enter MobileNo"
                                        maxlength="15" tabindex="2" onkeypress="return isNumberKey(event)" autocomplete="off" />
                                </div>
                                         <div class="form-group col-md-3" id="divGSTNo">
                                    <label>
                                        GSTNo</label>
                                    <input type="text" class="form-control" id="txtGSTNo" style="text-transform: uppercase" placeholder="Please enter GSTNo"
                                        maxlength="15" tabindex="3" autocomplete="off" />
                                    <button id="btnLink" type="button" class="btn btn-link" style="display: none;">
                                        <i class="fa fa-link" aria-hidden="true"></i>&nbsp;&nbsp;
                              Verify GSTNO</button>
                                </div>

                                <div class="form-group col-md-2" id="divCustomerType" style="display: none;">
                                    <label>
                                        Type</label><span class="text-danger">*</span>
                                    <select id="ddlCustomerType" class="form-control select2" data-placeholder="Select Customer Type" tabindex="4">
                                    </select>
                                </div>
                                <div class="form-group col-md-6" id="divAddress">
                                    <label>
                                        Address</label><span class="text-danger">*</span>
                                    <textarea id="txtAddress" class="form-control" maxlength="250" tabindex="4" rows="5" aria-autocomplete="none"></textarea>
                                </div>
                                <div class="form-group col-md-3">
                                    <label>
                                        Alternate No</label>
                                    <input type="text" class="form-control" id="txtAlternateNo" placeholder="Please enter AlternateNo"
                                        maxlength="12" tabindex="6" onkeypress="return isNumberKey(event)" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-3" id="divDate"  style="display:none">
                                    <label>DOB</label>
                                    <div class="input-group date form_date" data-date-format="dd/MM/yyyy HH:ii P" data-link-field="txtDate"
                                        data-link-format="dd/MM/yyyy">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar glyphicon glyphicon-calendar"></i>
                                        </div>
                                        <input type="text" class="form-control pull-right" tabindex="-1" id="txtDate" readonly="true" />
                                    </div>
                                </div>
                                <div class="form-group col-md-3">
                                    <label>
                                        Email</label>
                                    <div class="input-group">
                                        <div class="input-group-addon"><i class="fa fa-envelope"></i></div>
                                        <input type="text" class="form-control" id="txtEmail" placeholder="Please enter Email"
                                            maxlength="50" tabindex="7" autocomplete="off" />
                                    </div>
                                </div>
                       
                                <div class="form-group col-md-6" style="display: none">
                                    <label>
                                        Shipping  Address</label>
                                    <textarea id="txtShippinAddress" class="form-control" maxlength="250" tabindex="10" rows="3" aria-autocomplete="none"></textarea>
                                </div>

                                <div class="form-group col-md-3" id="divState">
                                    <label>
                                        State</label><span class="text-danger">*</span>
                                    <select id="ddlState" class="form-control select2" data-placeholder="Select State" tabindex="11">
                                    </select>
                                </div>
                                <div class="form-group col-md-4" id="divCity"  style="display:none">
                                    <label>
                                        City</label>
                                    <input type="text" class="form-control" id="txtCity" placeholder="Please enter City"
                                        maxlength="12" tabindex="12" autocomplete="off" />
                                </div>

                                <div class="form-group col-md-1" id="divDiscountPercent" style="display: none;">
                                    <label>
                                        Discount %</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtDiscountPercent" placeholder="Please enter Default DiscountPercent"
                                        maxlength="12" tabindex="-1" onkeypress="return isNumberKey(event)" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-2" id="divLimitSales" style="display: none;">
                                    <label>
                                        Credit Limit</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtlimitsalesAmount" placeholder="Credit Limit"
                                        maxlength="12" tabindex="-1" onkeypress="return isNumberKey(event)" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-2" id="divMinDueDays" style="display: none;">
                                    <label>
                                        Min. Due Days</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtMinDueDays" placeholder="Min. Due Days"
                                        maxlength="12" tabindex="-1" onkeypress="return isNumberKey(event)" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-2" id="divMaxDueDays" style="display: none;">
                                    <label>
                                        Max. Due Days</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtMaxDueDays" placeholder="Max. Due Days"
                                        maxlength="12" tabindex="-1" onkeypress="return isNumberKey(event)" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-4" id="divArea"  style="display:none">
                                    <label>
                                        Area</label>
                                    <input type="text" class="form-control" id="txtArea" placeholder="Please enter Area"
                                        maxlength="120" tabindex="13" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-3" id="divPincode">
                                    <label>
                                        Pincode</label>
                                    <input type="text" class="form-control" id="txtPincode" placeholder="Pincode"
                                        maxlength="6" tabindex="14" onkeypress="return isNumberKey(event)" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-4" id="divWhatsAppNo" style="display:none">
                                    <label>
                                        WhatsApp No</label>
                                    <div class="input-group">
                                        <div class="input-group-addon"><i class="fa fa-whatsapp"></i></div>
                                        <input type="text" class="form-control" id="txtWhatsAppNo" placeholder="Please enter WhatsApp No"
                                            maxlength="10" tabindex="-1" onkeypress="return isNumberKey(event)" autocomplete="off" />
                                    </div>
                                </div>
                                <div class="form-group col-md-3" id="divDays" style="display: none;">
                                    <label>
                                        Due Days</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtDays" placeholder="Please enter Days"
                                        maxlength="12" tabindex="-1" onkeypress="return isNumberKey(event)" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-2" style="margin-top: 30px;">
                                    <label>
                                        <input type="checkbox" id="chkStatus" checked="checked" tabindex="17" />&nbsp &nbsp Active
                                    </label>
                                </div>
                            </div>
                            <div class="form-group col-md-12" style="display: none;">
                                <div class="box box-primary box-solid">
                                    <div class="box-header">
                                        Particulars
                                    </div>
                                    <div class="box-body">
                                        <div class="row">
                                            <div class="form-group col-md-3" id="divBranchName">
                                                <label>
                                                    Branch Name</label><span class="text-danger">*</span>
                                                <input type="text" class="form-control" id="txtBranchName" placeholder="Please enter Branch Name"
                                                    maxlength="100" tabindex="-1" autocomplete="off" />
                                            </div>
                                            <div class="form-group col-md-2" id="divGSTIN">
                                                <label>
                                                    GSTIN</label>
                                                <input type="text" class="form-control" id="txtGSTIN" placeholder="Please enter GSTIN"
                                                    maxlength="15" tabindex="-1" autocomplete="off" />
                                            </div>
                                            <div class="form-group col-md-4" id="divShippingAddress">
                                                <label>
                                                    Shipping  Address</label>
                                                <textarea id="txtShippingAddress" class="form-control" maxlength="2500" tabindex="-1" rows="2" aria-autocomplete="none"></textarea>
                                            </div>
                                            <div class="form-group col-md-1 pull-right">
                                                <div class="margin">
                                                    <button id="btnAddMagazine" type="button" class="btn btn-primary btn-sm margin pull-right" tabindex="-1">
                                                        <i class="fa fa-plus-square"></i>&nbsp;&nbsp;Add</button>
                                                    <button id="btnUpdateMagazine" type="button" class="btn btn-primary btn-sm margin pull-right" tabindex="-1">
                                                        <i class="fa fa-edit"></i>&nbsp;&nbsp;Update</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="table-responsive" style="min-height: 20px !important">
                                        <div id="divOPBillingList">
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="modal-footer clearfix">
                            <button type="submit" class="btn btn-info pull-right" id="btnSave" tabindex="15">
                                <i class="fa fa-save"></i>&nbsp;&nbsp;
                                Save</button>
                            <button type="submit" class="btn btn-info pull-right" id="btnUpdate" tabindex="16">
                                <i class="fa fa-edit"></i>&nbsp;&nbsp;
                                Update</button>
                            <button type="button" class="btn btn-danger pull-left" id="btnClose" tabindex="17">
                                <i class="fa fa-close"></i>&nbsp;&nbsp;
                                Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <input type="hidden" id="hdnID" />
    <input type="hidden" id="hdnOPSNo" />

    <script type="text/javascript">
        var gOPBillingList = [];
        var ClickCount = 0;
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
            ActionAdd = '<%=Session["ActionAdd"]%>';
            ActionUpdate = '<%=Session["ActionUpdate"]%>';
            ActionDelete = '<%=Session["ActionDelete"]%>';
            ActionView = '<%=Session["ActionView"]%>';



            if (ActionAdd != "1") {
                $("#btnAddNew").remove();
                $("#btnSave").remove();
            }

            $("#txtDate").attr("data-link-format", "dd/MM/yyyy");

            $("#txtDate").datetimepicker({
                pickTime: false,
                useCurrent: true,
                maxDate: moment(),
                format: 'DD/MM/YYYY'
            });
            if (ActionUpdate != "1") {
                $("#btnUpdate").remove();
            }
            $("#btnAddMagazine").show();
            $("#btnUpdateMagazine").hide();
            pLoadingSetup(false);
            pLoadingSetup(true);
            GetStateList();
            GetCustomerList("ddlCategoryName");
            GetRecord();
        });

        $("#btnAddNew").click(function () {
            ClearFields();

            $('input,select').keydown(function (event) { //event==Keyevent
                if (event.which == 13) {
                    $("#btnSave").click();
                    event.preventDefault();

                }
            });
            ClickCount = 0;
            $("#hdnID").val("");
            $("#btnSave").show();
            $("#btnUpdate").hide();
            $("#btnAddMagazine").show();
            $("#btnUpdateMagazine").hide();
            $(".modal-title").html("<i class='fa fa-plus-square'></i>&nbsp;&nbsp;Add Customer");
            $('#compose-modal').modal({ show: true, backdrop: true });
            $("#txtName").focus();
            return false;
        });

        function IsEmail(email) {
            var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!regex.test(email)) {
                return false;
            } else {
                return true;
            }
        }

        function GetCustomerList(ddlname) {
            var sControlName = "#" + ddlname;
            dProgress(true);
            $(sControlName).empty();
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetCustomer",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != "") {
                        var objResponse = jQuery.parseJSON(data.d);
                        if (objResponse.Status == "Success") {
                            if (objResponse.Value != null && objResponse.Value != "NoRecord") {
                                var obj = $.parseJSON(objResponse.Value);
                                if (obj.length > 0) {

                                    $(sControlName).append('<option value="' + '0' + '">' + '--All--' + '</option>');
                                    for (var index = 0; index < obj.length; index++) {
                                        $(sControlName).append('<option value=' + obj[index].CustomerID + ' >' + obj[index].CustomerName + '</option>');
                                    }
                                }
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $(sControlName).append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                            }
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
                        $(sControlName).append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                    }
                },
                error: function (e) {
                    $.jGrowl("Error  Occured", { sticky: false, theme: 'danger', life: jGrowlLife });
                }
            });
            return false;
        }

        function GetStateList() {
            $("#ddlState").empty();
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetState",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ CountryID: 0 }),
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != "") {
                        var objResponse = jQuery.parseJSON(data.d);
                        if (objResponse.Status == "Success") {
                            if (objResponse.Value != null && objResponse.Value != "NoRecord") {
                                var obj = $.parseJSON(objResponse.Value);
                                if (obj.length > 0) {
                                    //$("#ddlState").append('<option value="' + '0' + '">' + '--Select State--' + '</option>');
                                    for (var index = 0; index < obj.length; index++) {
                                        $("#ddlState").append('<option value=' + obj[index].StateID + ' >' + obj[index].StateName + '</option>');
                                    }
                                }
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $("#ddlState").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                            }
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
                        $("#ddlState").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                    }
                },
                error: function (e) {
                    $.jGrowl("Error  Occured", { sticky: false, theme: 'danger', life: jGrowlLife });
                }
            });
            return false;
        }

  

        $("#btnSave,#btnUpdate").click(function () {
            if (this.id == "btnSave") { if (ActionAdd != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }
            else { if (ActionUpdate != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }

            if ($("#txtName").val().trim() == "" || $("#txtName").val().trim() == undefined) {
                $.jGrowl("Please enter Customer", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divName").addClass('has-error');              
                $("#txtName").focus(); return false;
            } else { $("#divName").removeClass('has-error'); }

            if ($("#txtEmail").val().trim() != "" && $("#txtEmail").val().trim() != undefined) {
                if (IsEmail($("#txtEmail").val()) == false) {
                    $.jGrowl("Please enter Valid Email", { sticky: false, theme: 'warning', life: jGrowlLife });
                    $("#txtEmail").focus(); return false;
                }
            }

            if ($("#txtAddress").val().trim() == "" || $("#txtAddress").val().trim() == undefined) {
                $.jGrowl("Please enter Address", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#txtAddress").addClass('has-error'); $("#txtAddress").focus(); return false;
            } else { $("#txtAddress").removeClass('has-error'); }

            if ($("#ddlState").val() == "0" || $("#ddlState").val() == undefined) {
                $.jGrowl("Please Select State", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divState").addClass('has-error'); $("#ddlState").focus(); return false;
            } else { $("#divState").removeClass('has-error'); }


            var iOPBillingAmount = 0;
            for (var i = 0; i < gOPBillingList.length; i++) {
                if (gOPBillingList[i].StatusFlag != "D")
                    iOPBillingAmount = iOPBillingAmount + 1;
            }
            if (iOPBillingAmount <= 0) {
                var ObjShippingAddress = new Object();
                ObjShippingAddress.CustomerID = 0;
                ObjShippingAddress.Address = $("#txtAddress").val();
                ObjShippingAddress.GSTIN = $("#txtGSTNo").val();
                ObjShippingAddress.BranchName = $("#txtCity").val();
                ObjShippingAddress.StatusFlag = "I";
                gOPBillingList.push(ObjShippingAddress);
            }

            var Obj = new Object();
            Obj.CustomerID = 0;
            Obj.CustomerName = $("#txtName").val().trim().toUpperCase();
            Obj.CustomerCode = $("#txtCode").val();

            Obj.Address = $("#txtAddress").val();
            Obj.AlternateNo = $("#txtAlternateNo").val();
            Obj.Email = $("#txtEmail").val();
            Obj.DOB = $("#txtDate").val();
            Obj.MobileNo = $("#txtMobileNo").val();
            Obj.WhatsAppNo = $("#txtWhatsAppNo").val();
            if ($("#txtDays").val().length > 0)
                Obj.Days = $("#txtDays").val();
            else
                Obj.Days = 0;
            //s Obj.Days = $("#txtDays").val();
            Obj.Pincode = $("#txtPincode").val();
            Obj.City = $("#txtCity").val();
            Obj.Area = $("#txtArea").val();
            Obj.Default_DiscountPercent = 0;
            Obj.Limit_SalesAmount = 0;
            Obj.Shipping_Address = "";
            Obj.GSTNo = $("#txtGSTNo").val();
            if ($("#txtMaxDueDays").val().length > 0)
                Obj.MaxDueDays = $("#txtMaxDueDays").val();
            else
                Obj.MaxDueDays = 0;
            if ($("#txtMinDueDays").val().length > 0)
                Obj.MinDueDays = $("#txtMinDueDays").val();
            else
                Obj.MinDueDays = 0;

            Obj.CustomerType = 0;
            Obj.IsActive = $("#chkStatus").is(':checked') ? "1" : "0";

            var ObjState = new Object();
            ObjState.StateID = $("#ddlState").val();
            Obj.State = ObjState;

            var ObjCustomerType = new Object();
            ObjCustomerType.CustomertypeID = 0;
            Obj.CustomerTypes = ObjCustomerType;
            Obj.ShippingAddress = gOPBillingList;
            var sMethodName;
            if ($("#hdnID").val() > 0) {
                Obj.CustomerID = $("#hdnID").val();
                sMethodName = "UpdateCustomer";
            }
            else { sMethodName = "AddCustomer"; }

            SaveandUpdateCustomer(Obj, sMethodName);

            return false;
        });

        $("#btnClose").click(function () {
            $('#compose-modal').modal('hide');
            return false;
        });

        function ClearFields() {
            $("#divOPBillingList").empty();
            $("#txtName").val("");
            $("#txtCode").val("");
            $("#txtMobileNo").val("");
            $("#txtBranchName").val("");
            $("#txtDays").val("");

            $("#txtWhatsAppNo").val("");
            $("#txtGSTIN").val("");
            $("#txtShippingAddress").val("");
            gOPBillingList = [];
            $("#ddlCustomerType").val(null).change();
            $("#txtAddress").val("");
            $("#txtAlternateNo").val("");
            $("#txtEmail").val("");
            $("#txtGSTNo").val("");
            $("#txtDate").val("");
            $("#txtMinDueDays").val("0");
            $("#txtMaxDueDays").val("0");
            $("#chkStatus").prop("checked", true);
            $("#ddlState").val(null).change();
            $("#txtDate").val("");
            $("#txtCity").val("");
            $("#txtArea").val("");
            $("#txtPincode").val("");
            $("#txtShippinAddress").val("");
            $("#txtDiscountPercent").val("");
            $("#txtlimitsalesAmount").val("");
            $("#divName").removeClass('has-error');
            return false;
        }

        $("#btnAddMagazine,#btnUpdateMagazine").click(function () {

            if ($("#txtBranchName").val() == "" || $("#txtBranchName").val() == undefined || $("#txtBranchName").val() == null) {
                $.jGrowl("Please enter Branch Name", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divBranchName").addClass('has-error'); $("#txtBranchName").focus(); return false;
            } else { $("#divBranchName").removeClass('has-error'); }

            if ($("#txtShippingAddress").val() == "" || $("#txtShippingAddress").val() == undefined || $("#txtShippingAddress").val() == null) {
                $.jGrowl("Please enter Address", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divShippingAddress").addClass('has-error'); $("#txtShippingAddress").focus(); return false;
            } else { $("#divShippingAddress").removeClass('has-error'); }

            var ObjData = new Object();
            ObjData.CustomerID = 0;

            ObjData.Address = $("#txtShippingAddress").val();
            ObjData.GSTIN = $("#txtGSTIN").val();
            ObjData.BranchName = $("#txtBranchName").val();

            if (this.id == "btnAddMagazine") {
                ObjData.sNO = gOPBillingList.max() + 1;
                ObjData.SNo = ObjData.sNO;
                ObjData.CustomerID = 0;
                ObjData.StatusFlag = "I";
                AddOPBillingData(ObjData);
            }
            else if (this.id == "btnUpdateMagazine") {
                ObjData.sNO = $("#hdnOPSNo").val();
                if ($("#hdnID").val() > 0) {
                    ObjData.StatusFlag = "U";
                    ObjData.CustomerID = $("#hdnID").val();
                }
                else {
                    ObjData.StatusFlag = "I";
                    ObjData.PurchaseID = 0;
                }
                Update_OPBilling(ObjData);
            }
            ClearOPBillingFields();
            $("#btnAddMagazine").show();
            $("#btnUpdateMagazine").hide();
        });


        function ClearOPBillingFields() {
            $("#btnAddMagazine").show();
            $("#btnUpdateMagazine").hide();
            $("#txtBranchName").val("");
            $("#txtGSTIN").val("");
            $("#txtShippingAddress").val("");
            $("#hdnOPSNo").val("");
            $("#divBranchName").removeClass('has-error');
            $("#divShippingAddress").removeClass('has-error');
            return false;
        }
        function AddOPBillingData(oData) {
            gOPBillingList.push(oData);
            DisplayOPBillingList(gOPBillingList);
            console.log(gOPBillingList);
            return false;
        }
        function DisplayOPBillingList(gData) {
            var sTable = "";
            var sCount = 1;
            var sColorCode = "bg-info";
            var StockQty = 0;
            if (gData.length >= 5) { $("#divOPBillingList").css({ 'height': '0px', 'min-height': '200px', 'overflow': 'auto' }); }
            else { $("#divOPBillingList").css({ 'height': '', 'min-height': '' }); }

            if (gData.length > 0) {
                sTable = "<table id='tblOPBillingList' class='table no-margin table-condensed table-hover'>";
                sTable += "<thead><tr><th class='" + sColorCode + "' style='width:3px;text-align: center'>S.No</th>";
                sTable += "<th class='" + sColorCode + "'>Branch Name</th>";
                sTable += "<th class='" + sColorCode + "'>GSTIN</th>";
                sTable += "<th class='" + sColorCode + "'>Address</th>";
                sTable += "<th class='" + sColorCode + "' style='width:3px;text-align: center'>Edit</th>";
                sTable += "<th class='" + sColorCode + "' style='width:3px;text-align: center'>Delete</th>";
                sTable += "</tr></thead><tbody id='tblOPBillingList_body'>";
                sTable += "</tbody></table>";
                $("#divOPBillingList").html(sTable);
                for (var i = 0; i < gData.length; i++) {
                    if (gData[i].StatusFlag != "D") {
                        sTable = "<tr><td id='" + gData[i].SNo + "'>" + sCount + "</td>";
                        sTable += "<td>" + gData[i].BranchName + "</td>";
                        sTable += "<td>" + gData[i].GSTIN + "</td>";
                        sTable += "<td>" + gData[i].Address + "</td>";
                        sTable += "<td><a href='#' id=" + gData[i].SNo + " onclick = 'Edit_OPBillingDetail(this.id)'><i class='fa fa-lg fa-edit'/></a></td>";
                        sTable += "<td><a href='#' id=" + gData[i].SNo + " onclick = 'Delete_OPBillingDetail(this.id)'><i class='fa fa-lg fa-trash-o text-red'/></a></td>";
                        sTable += "</tr>";
                        sCount = sCount + 1;
                        $("#tblOPBillingList_body").append(sTable);
                    }
                }
            }
            else { $("#divOPBillingList").empty(); }

            return false;
        }
        function Edit_OPBillingDetail(ID) {
            Bind_OPBillingByID(ID, gOPBillingList);
            return false;
        }
        function Bind_OPBillingByID(ID, data) {
            $("#btnAddMagazine").hide();
            $("#btnUpdateMagazine").show();
            $("#txtBranchName").focus();

            for (var i = 0; i < data.length; i++) {
                if (data[i].sNO == ID) {
                    $("#hdnOPSNo").val(ID);
                    $("#txtBranchName").val(data[i].BranchName);
                    $("#txtShippingAddress").val(data[i].Address);
                    $("#txtGSTIN").val(data[i].GSTIN);
                }
            }
            return false;
        }
        function Update_OPBilling(oData) {
            for (var i = 0; i < gOPBillingList.length; i++) {
                if (gOPBillingList[i].sNO == oData.sNO) {
                    gOPBillingList[i].BranchName = oData.BranchName;
                    gOPBillingList[i].GSTIN = oData.GSTIN;
                    gOPBillingList[i].Address = oData.Address;
                    gOPBillingList[i].CustomerID = oData.CustomerID;
                    gOPBillingList[i].StatusFlag = oData.StatusFlag;
                }
            }
            DisplayOPBillingList(gOPBillingList);
            ClearOPBillingFields();
            return false;
        }
        function Delete_OPBillingDetail(ID) {
            if (ID == 0)
                return false;

            if (confirm('Are you sure to delete the selected record ?')) {
                for (var i = 0; i < gOPBillingList.length; i++) {
                    if (gOPBillingList[i].SNo == ID) {
                        var index = jQuery.inArray(gOPBillingList[i].valueOf("SNo"), gOPBillingList);
                        if (gOPBillingList[i].SNo > 0) {
                            gOPBillingList[i].StatusFlag = "D";
                        } else {
                            gOPBillingList.splice(index, 1);
                        }
                        $("#divOPBillingList").empty();
                        DisplayOPBillingList(gOPBillingList);
                    }
                }
            }
            return false;
        }

        Array.prototype.max = function () {
            var max = this.length > 0 ? this[0]["sNO"] : 0;
            var len = this.length;
            for (var i = 1; i < len; i++) if (this[i]["sNO"] > max) max = this[i]["sNO"];
            return max;
        }

        $("#ddlCategoryName").change(function () {
            GetRecord();
        });
        function GetRecord() {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetTopCustomer",
                data: JSON.stringify({ CustomerID: $("#ddlCategoryName").val()}),
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
                                        if (obj[index].IsActive == "1") { TypeStatus = "<span class='label label-success'>Active</span>"; }
                                        else { TypeStatus = "<span class='label label-warning'>Inactive</span>"; }

                                        var table = "<tr id='" + obj[index].CustomerID + "'>";
                                        table += "<td>" + (index + 1) + "</td>";
                                        table += "<td>" + obj[index].CustomerName + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].Address + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].MobileNo + "</td>";                     
                                        table += "<td class='hidden-xs'>" + TypeStatus + "</td>";
                                        if (ActionView == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].CustomerID + " class='View' title='Click here to View'><i class='fa fa-lg fa-clone text-yellow'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        if (ActionUpdate == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].CustomerID + " class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        if (ActionDelete == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].CustomerID + " class='Delete' title='Click here to Delete'><i class='fa fa-lg fa-trash-o text-red'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        // table += "<td style='text-align:center; color: darkviolet;'><a href='#' id=hid" + obj[index].CustomerID + " class='Address' style='color:black;' Accountno='" + obj[index].CustomerID + "' title='click here to Customer Ledger'><i class='fa fa-address-card' style='color: darkviolet;'></i></a></td>";

                                        table += "</tr>";
                                        $("#tblRecord_tbody").append(table);
                                    }
                                    $(".View").click(function () {
                                        if (ActionView == "1") {
                                            EditRecord($(this).parent().parent()[0].id);
                                            $(".modal-title").html("<i class='fa fa-clone'></i>&nbsp;&nbsp;View Customer");
                                            $("#btnSave").hide();
                                            $("#btnUpdate").hide();
                                        }
                                        else {
                                            $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                                            return false;
                                        }
                                    });
                                    $(".Edit").click(function () {
                                        if (ActionUpdate == "1") { EditRecord($(this).parent().parent()[0].id); }
                                        else {
                                            $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                                            return false;
                                        }
                                    });
                                    $(".Address").click(function () {
                                        SetSessionValue("SalesID", $(this).attr('Accountno'));
                                        SetSessionValue("Table", "Customer");
                                        var myWindow = window.open("frmAddressLabel.aspx", "MsgWindow");
                                    });
                                    $(".Delete").click(function () {
                                        if (ActionDelete == "1") {
                                            if (confirm('Are you sure to delete the selected record ?')) { DeleteRecord($(this).parent().parent()[0].id); }
                                        }
                                        else {
                                            $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
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
                                    { "sWidth": "5%" },
                                    { "sWidth": "15%" },
                                    { "sWidth": "25%" },
                                    { "sWidth": "15%" },
                                    { "sWidth": "5%" },
                                    { "sWidth": "3%" },
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

        function SaveandUpdateCustomer(Obj, sMethodName) {
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
                                GetRecord();

                                if (sMethodName == "AddCustomer") { $.jGrowl("Added Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }
                                else if (sMethodName == "UpdateCustomer") { $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }

                                $('#compose-modal').modal('hide');
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                window.location = "frmLogin.aspx";
                            }
                            else if (objResponse.Value == "Customer_A_01" || objResponse.Value == "Customer_U_01") {
                                $.jGrowl("Mobile No. already Exist", { sticky: false, theme: 'danger', life: jGrowlLife });
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

        function EditRecord(id) {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetCustomerByID",
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
                                    $("#btnSave").hide();
                                    $("#btnUpdate").show();
                                    $('input,select').keydown(function (event) { //event==Keyevent
                                        if (event.which == 13) {
                                            $("#btnUpdate").click();
                                            event.preventDefault();

                                        }
                                    });
                                    $("#hdnID").val(obj.CustomerID);
                                    $("#txtName").val(obj.CustomerName);
                                    $("#txtCode").val(obj.CustomerCode);
                                    $("#txtAddress").val(obj.Address);
                                    $("#txtMobileNo").val(obj.MobileNo);
                                    $("#txtAlternateNo").val(obj.AlternateNo);
                                    $("#txtEmail").val(obj.Email);
                                    $("#txtGSTNo").val(obj.GSTNo);
                                    $("#txtWhatsAppNo").val(obj.WhatsAppNo);
                                    $("#txtDays").val(obj.Days);
                                    $("#txtDate").val(obj.DOB);
                                    $("#txtMinDueDays").val(obj.MinDueDays);
                                    $("#txtMaxDueDays").val(obj.MaxDueDays);
                                    $("#ddlCustomerType").val(obj.CustomerType).change();
                                    $("#chkStatus").prop("checked", obj.IsActive ? true : false);
                                    $("#txtCity").val(obj.City);
                                    $("#txtArea").val(obj.Area);
                                    $("#txtPincode").val(obj.Pincode);
                                    $("#txtShippinAddress").val(obj.Shipping_Address);
                                    $("#txtDiscountPercent").val(obj.Default_DiscountPercent);
                                    $("#txtlimitsalesAmount").val(obj.Limit_SalesAmount);
                                    $("#ddlState").val(obj.State.StateID).change();

                                     ClickCount = 1;
                                     $('#compose-modal').modal({ show: true, backdrop: true });
                                     $(".modal-title").html("<i class='fa fa-pencil'></i>&nbsp;&nbsp;Edit Customer");
                            
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
                    dProgress(false);
                }
            });
            return false;
        }

        $("#btnLink").click(function () {
            ClickCount = 1;
            var myWindow = window.open("https://services.gst.gov.in/services/searchtp", "MsgWindow");

        });

        $("#txtSearchName").change(function () {
            if ($("#txtSearchName").val().trim() != "" || $("#txtSearchName").val().trim() != undefined) {
                var iDetails = $("#txtSearchName").val();
                GetSearchRecord(iDetails);
            }
            return false;
        });
        function DeleteRecord(id) {
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/DeleteCustomer",
                data: JSON.stringify({ ID: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != "") {
                        var objResponse = jQuery.parseJSON(data.d);
                        if (objResponse.Status == "Success") {
                            if (objResponse.Value > 0) {
                                $.jGrowl("Deleted Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
                                ClearFields();
                                GetRecord();
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                window.location = "frmLogin.aspx";
                            }
                            else if (objResponse.Value == "Customer_R_01" || objResponse.Value == "Customer_D_01") {
                                $.jGrowl(_CMDeleteError, { sticky: false, theme: 'danger', life: jGrowlLife });
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

        function GetSearchRecord(iDetails) {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/SearchCustomer",
                data: JSON.stringify({ ID: iDetails, Type: 'Sales' }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != "") {
                        var objResponse = jQuery.parseJSON(data.d);
                        if (objResponse.Status == "Success") {
                            var notetable = $("#tblSearchResult").dataTable();
                            notetable.fnDestroy();
                            if (objResponse.Value != null && objResponse.Value != "NoRecord") {
                                var obj = $.parseJSON(objResponse.Value);
                                if (obj.length > 0) {
                                    $("#tblSearchResult_tbody").empty();
                                    var TypeStatus = "";
                                    for (var index = 0; index < obj.length; index++) {
                                        if (obj[index].IsActive == "1") { TypeStatus = "<span class='label label-success'>Active</span>"; }
                                        else { TypeStatus = "<span class='label label-warning'>Inactive</span>"; }

                                        var table = "<tr id='" + obj[index].CustomerID + "'>";
                                        table += "<td>" + (index + 1) + "</td>";
                                        table += "<td>" + obj[index].CustomerName + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].Address + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].MobileNo + "</td>";
                                        table += "<td class='hidden-xs'>" + TypeStatus + "</td>";

                                        if (ActionView == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].CustomerID + " class='View' title='Click here to View'><i class='fa fa-lg fa-clone text-yellow'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        if (ActionUpdate == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].CustomerID + " class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        if (ActionDelete == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].CustomerID + " class='Delete' title='Click here to Delete'><i class='fa fa-lg fa-trash-o text-red'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        //table += "<td style='text-align:center; color: darkviolet;'><a href='#' id=hid" + obj[index].CustomerID + " class='Address' style='color:black;' Accountno='" + obj[index].CustomerID + "' title='click here to Customer Ledger'><i class='fa fa-address-card' style='color: darkviolet;'></i></a></td>";

                                        table += "</tr>";
                                        $("#tblSearchResult_tbody").append(table);
                                    }
                                    $(".View").click(function () {
                                        if (ActionView == "1") {
                                            EditRecord($(this).parent().parent()[0].id);
                                            $(".modal-title").html("<i class='fa fa-clone'></i>&nbsp;&nbsp;View Customer");
                                            $("#btnSave").hide();
                                            $("#btnUpdate").hide();
                                        }
                                        else {
                                            $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                                            return false;
                                        }
                                    });
                                    $(".Edit").click(function () {
                                        if (ActionUpdate == "1") { EditRecord($(this).parent().parent()[0].id); }
                                        else {
                                            $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                                            return false;
                                        }
                                    });
                                    $(".Address").click(function () {
                                        SetSessionValue("SalesID", $(this).attr('Accountno'));
                                        SetSessionValue("Table", "Customer");
                                        var myWindow = window.open("frmAddressLabel.aspx", "MsgWindow");
                                    });
                                    $(".Delete").click(function () {
                                        if (ActionDelete == "1") {
                                            if (confirm('Are you sure to delete the selected record ?')) { DeleteRecord($(this).parent().parent()[0].id); }
                                        }
                                        else {
                                            $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                                            return false;
                                        }
                                    });
                                }
                                dProgress(false);
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $("#tblSearchResult_tbody").empty();
                                dProgress(false);
                            }
                            $("#tblSearchResult").dataTable({
                                "bPaginate": true,
                                "bFilter": true,
                                "bSort": true,
                                "iDisplayLength": 25,
                                aoColumns: [
                                    { "sWidth": "5%" },
                                    { "sWidth": "15%" },
                                    { "sWidth": "25%" },
                                    { "sWidth": "15%" },
                                    { "sWidth": "5%" },
                                    { "sWidth": "3%" },
                                    { "sWidth": "3%" },
                                    { "sWidth": "3%" }
                                ]
                            });
                            $("#tblSearchResult_filter").addClass('pull-right');
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
                        $("#tblSearchResult_tbody").empty();
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

        $("#aGeneral").click(function () {
            $("#SearchResult").hide();
            GetRecord();
        });

        $("#aSearchResult").click(function () {
            $("#SearchResult").show();
        });
    </script>
</asp:Content>



