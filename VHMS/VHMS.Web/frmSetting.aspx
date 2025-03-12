<%@ Page Title="Settings" Language="C#" MasterPageFile="~/VHMSMasterPage.master" AutoEventWireup="true" CodeFile="frmSetting.aspx.cs" Inherits="frmSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="VHMSWebHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VHMSWebContent" runat="Server">
    <div class="container-wrapper hidden">
        <section class="content-header">
            <h1>Settings
            </h1>
        </section>
        <section class="content">
            <div class="nav-tabs-custom" id="tab-modal">
                <ul class="nav nav-tabs">
                    <li class="active"><a id="aGeneral" href="#General" data-toggle="tab">General</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="General">
                        <div class="box box-primary box-solid" style="display: none;">
                            <div class="box-header">
                                Calculation Settings
                            </div>
                            <div class="box-body">
                                <div class="col-md-4">
                                    <div class="box box-info box-solid">
                                        <div class="box-header" style="text-align: center;">
                                            <div class="box-title">&nbsp;&nbsp;Maximum Discount %</div>
                                        </div>
                                        <div class="table-responsive">
                                            <div class="form-group col-md-6 col-sm-3" id="divMaxSalesDiscount" style="text-align: center;">
                                                <label>
                                                    Whole sales                                               
                                                </label>
                                                <span class="text-danger">*</span>
                                                <input type="text" class="form-control TRSearch" id="txtMaxSalesDiscount" placeholder="Maximum Sales Discount"
                                                    maxlength="12" tabindex="2" onkeypress="return IsNumeric(event)" />
                                            </div>
                                            <div class="form-group col-md-6 col-sm-3" id="divMaxDiscount" style="text-align: center;">
                                                <label>
                                                    Retail Sales</label><span class="text-danger">*</span>
                                                <input type="text" class="form-control TRSearch" id="txtMaxDiscount" placeholder="Maximum Discount Percent"
                                                    maxlength="12" tabindex="1" onkeypress="return IsNumeric(event)" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="box box-info box-solid">
                                        <div class="box-header" style="text-align: center;">
                                            <div class="box-title">&nbsp;&nbsp;Minimum Margin %</div>
                                        </div>
                                        <div class="table-responsive">

                                            <div class="form-group col-md-6 col-sm-3" id="divWholeSaleMinMargin" style="text-align: center;">
                                                <label>
                                                    Whole Sales
                                                </label>
                                                <span class="text-danger">*</span>
                                                <input type="text" class="form-control TRSearch" id="txtWholeSaleMinMargin" placeholder="Sales Whole Sales Min Margin"
                                                    maxlength="12" tabindex="3" onkeypress="return IsNumeric(event)" />
                                            </div>
                                            <div class="form-group col-md-6 col-sm-3" id="divRetailsMinMargin" style="text-align: center;">
                                                <label>
                                                    Retail Sales
                                                </label>
                                                <span class="text-danger">*</span>
                                                <input type="text" class="form-control TRSearch" id="txtRetailMinMargin" placeholder="Sales Retails Min Margin"
                                                    maxlength="12" tabindex="4" onkeypress="return IsNumeric(event)" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="box box-info box-solid">
                                        <div class="box-header" style="text-align: center;">
                                            <div class="box-title">&nbsp;&nbsp;Other</div>
                                        </div>
                                        <div class="table-responsive">
                                            <div class="form-group col-md-9 col-sm-2" id="divSalesTaxReturn" style="text-align: center;">
                                                <label>
                                                    Sales Tax Return Amount
                                                </label>
                                                <span class="text-danger">*</span>
                                                <input type="text" class="form-control TRSearch" id="txtSalesTaxReturn" placeholder="Sales Tax Return Amount"
                                                    maxlength="12" tabindex="5" onkeypress="return IsNumeric(event)" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box box-primary box-solid">
                            <div class="box-header">
                                Email Settings
                            </div>
                            <div class="box-body">
                                <div class="form-group col-md-2 col-sm-2" id="divHostName">
                                    <label>
                                        Host Name
                                    </label>
                                    <span class="text-danger">*</span>
                                    <input type="text" class="form-control TRSearch" id="txtHostName" placeholder="Host Name"
                                        maxlength="150" tabindex="6" />
                                </div>
                                <div class="form-group col-md-2 col-sm-2" id="divPort">
                                    <label>
                                        Port
                                    </label>
                                    <span class="text-danger">*</span>
                                    <input type="text" class="form-control TRSearch" id="txtPort" placeholder="Port"
                                        maxlength="50" tabindex="7" />
                                </div>
                                <div class="form-group col-md-2 col-sm-2" id="divEmailID">
                                    <label>
                                        Email ID
                                    </label>
                                    <span class="text-danger">*</span>
                                    <input type="text" class="form-control TRSearch" id="txtEmailID" placeholder="EmailID"
                                        maxlength="150" tabindex="8" />
                                </div>
                                <div class="form-group col-md-2 col-sm-2" id="divEmailPassword">
                                    <label>
                                        Email Password
                                    </label>
                                    <span class="text-danger">*</span>
                                    <input type="text" class="form-control TRSearch" id="txtEmailPassword" placeholder="Password"
                                        maxlength="50" tabindex="6" />
                                </div>
                                <div class="form-group col-md-2  col-sm-2">
                                    <div class="checkbox" style="margin-top: 30px">
                                        <label>
                                            <input type="checkbox" id="chkEnableSSL" tabindex="19" />Enable SSL
                                        </label>
                                    </div>
                                </div>
                                <div class="form-group col-md-2  col-sm-2">
                                    <div class="checkbox" style="margin-top: 30px">
                                        <label>
                                            <input type="checkbox" id="chkDefaultCredentials" tabindex="19" />Default Credential
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box box-primary box-solid">
                            <div class="box-header">
                                Bill Settings
                            </div>
                            <div class="box-body">
                                <div class="form-group col-md-6 col-sm-6" id="divTermsAndConditions">
                                    <label>
                                        Terms And Conditions
                                    </label>
                                    <textarea id="txtTermsandConditions" class="form-control" maxlength="2550" tabindex="20" rows="6" aria-autocomplete="none"></textarea>
                                </div>
                                <div class="form-group col-md-6 col-sm-6" id="divAdditionalNotes">
                                    <label>
                                        Additional Notes
                                    </label>
                                    <textarea id="txtAdditionalNotes" class="form-control" maxlength="2550" tabindex="21" rows="6" aria-autocomplete="none"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="box box-primary box-solid" style="display: none;">
                            <div class="box-header">
                                SMS Settings
                            </div>
                            <div class="box-body">
                                <div class="form-group col-md-12" id="divAPILink">
                                    <label>
                                        API Link</label>
                                    <div class="input-group">
                                        <div class="input-group-addon"><i class="fa fa-link"></i></div>
                                        <input type="text" class="form-control" id="txtAPILink" placeholder="API Link" maxlength="1000" tabindex="-1" />
                                    </div>
                                </div>

                                <div class="form-group col-md-3" id="divUserName">
                                    <label>
                                        User Name</label>
                                    <div class="input-group">
                                        <div class="input-group-addon"><i class="fa fa-user"></i></div>
                                        <input type="text" class="form-control" id="txtUserName" placeholder="User Name" maxlength="50" tabindex="-1" />
                                    </div>
                                </div>
                                <div class="form-group col-md-3" id="divPassword">
                                    <label>
                                        Password</label>
                                    <div class="input-group">
                                        <div class="input-group-addon"><i class="fa fa-openid"></i></div>
                                        <input type="text" class="form-control" id="txtPassword" placeholder="Password" maxlength="50" tabindex="-1" />
                                    </div>
                                </div>
                                <div class="form-group col-md-3" id="divSenderName">
                                    <label>
                                        Sender Name</label>
                                    <div class="input-group">
                                        <div class="input-group-addon"><i class="fa fa-user"></i></div>
                                        <input type="text" class="form-control" id="txtSenderName" placeholder="Sender Name" maxlength="100" tabindex="-1" />
                                    </div>
                                </div>
                                <div class="form-group col-md-3">
                                    <div class="checkbox" style="margin-top: 30px">
                                        <label>
                                            <input type="checkbox" id="chkSMSSend" tabindex="-1" />Send SMS
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer clearfix">
                            <button id="btnSaveChanges" type="button" class="btn btn-primary margin pull-right" tabindex="24">
                                <i class="fa fa-save"></i>&nbsp;&nbsp;
                                Save Changes</button>
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

            pLoadingSetup(false);
            GetCompanyInformation();
            pLoadingSetup(true);
        });


        //$("#txtEmail").change(function(){
        //    if ($("#txtEmail").val().length > 2) {
        //        var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        //        if (!regex.test($("#txtEmail").val)) {
        //            $.jGrowl("Please enter valid Email", { sticky: false, theme: 'warning', life: jGrowlLife });
        //            $("#divEmail").addClass('has-error'); $("#txtEmail").focus(); return false;
        //        } else { $("#divEmail").removeClass('has-error'); }
        //        }
        //})


        $("#btnSaveChanges").click(function () {
            if (ActionAdd != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; }

            if (ActionUpdate != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; }

            if ($("#txtMaxDiscount").val() == "" || $("#txtMaxDiscount").val() == "0" || $("#txtMaxDiscount").val() == undefined || $("#txtMaxDiscount").val() == null) {
                $.jGrowl("Please enter Maximum Retail Discount %", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divMaxDiscount").addClass('has-error'); $("#txtMaxDiscount").focus(); return false;
            } else { $("#divMaxDiscount").removeClass('has-error'); }

            if ($("#txtMaxSalesDiscount").val() == "" || $("#txtMaxSalesDiscount").val() == "0" || $("#txtMaxSalesDiscount").val() == undefined || $("#txtMaxSalesDiscount").val() == null) {
                $.jGrowl("Please enter Maximum WholeSale Discount %", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divMaxSalesDiscount").addClass('has-error'); $("#txtMaxSalesDiscount").focus(); return false;
            } else { $("#divMaxSalesDiscount").removeClass('has-error'); }

            if ($("#txtWholeSaleMinMargin").val() == "" || $("#txtWholeSaleMinMargin").val() == "0" || $("#txtWholeSaleMinMargin").val() == undefined || $("#txtWholeSaleMinMargin").val() == null) {
                $.jGrowl("Please enter Whole Sales Min Margin", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divWholeSaleMinMargin").addClass('has-error'); $("#txtWholeSaleMinMargin").focus(); return false;
            } else { $("#divWholeSaleMinMargin").removeClass('has-error'); }

            if ($("#txtRetailMinMargin").val() == "" || $("#txtRetailMinMargin").val() == "0" || $("#txtRetailMinMargin").val() == undefined || $("#txtRetailMinMargin").val() == null) {
                $.jGrowl("Please enter Retail Min Margin", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divRetailsMinMargin").addClass('has-error'); $("#txtRetailMinMargin").focus(); return false;
            } else { $("#divRetailsMinMargin").removeClass('has-error'); }

            if ($("#txtHostName").val() == "" || $("#txtHostName").val() == undefined || $("#txtHostName").val() == null) {
                $.jGrowl("Please enter Host Name", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divHostName").addClass('has-error'); $("#txtHostName").focus(); return false;
            } else { $("#divHostName").removeClass('has-error'); }

            if ($("#txtPort").val() == "" || $("#txtPort").val() == undefined || $("#txtPort").val() == null) {
                $.jGrowl("Please enter Port", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divPort").addClass('has-error'); $("#txtPort").focus(); return false;
            } else { $("#divPort").removeClass('has-error'); }

            if ($("#txtEmailID").val() == "" || $("#txtEmailID").val() == undefined || $("#txtEmailID").val() == null) {
                $.jGrowl("Please enter Email ID", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divEmailID").addClass('has-error'); $("#txtEmailID").focus(); return false;
            } else { $("#divEmailID").removeClass('has-error'); }

            if ($("#txtEmailPassword").val() == "" || $("#txtEmailPassword").val() == undefined || $("#txtEmailPassword").val() == null) {
                $.jGrowl("Please enter Email Password", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divEmailPassword").addClass('has-error'); $("#txtEmailPassword").focus(); return false;
            } else { $("#divEmailPassword").removeClass('has-error'); }

            if ($("#chkSMSSend").prop("checked") == true) {

                if ($("#txtAPILink").val().trim() == "" || $("#txtAPILink").val().trim() == undefined) {
                    $.jGrowl("Please enter API Link", { sticky: false, theme: 'warning', life: jGrowlLife });
                    $("#divAPILink").addClass('has-error'); $("#txtAPILink").focus();
                    return false;
                } else { $("#divAPILink").removeClass('has-error'); }
                if ($("#txtUserName").val().trim() == "" || $("#txtUserName").val().trim() == undefined) {
                    $.jGrowl("Please enter User Name", { sticky: false, theme: 'warning', life: jGrowlLife });
                    $("#divUserName").addClass('has-error'); $("#txtUserName").focus();
                    return false;
                } else { $("#divUserName").removeClass('has-error'); }
                if ($("#txtPassword").val().trim() == "" || $("#txtPassword").val().trim() == undefined) {
                    $.jGrowl("Please enter Password", { sticky: false, theme: 'warning', life: jGrowlLife });
                    $("#divPassword").addClass('has-error'); $("#txtPassword").focus();
                    return false;
                } else { $("#divPassword").removeClass('has-error'); }
                if ($("#txtSenderName").val().trim() == "" || $("#txtSenderName").val().trim() == undefined) {
                    $.jGrowl("Please enter Sender Name", { sticky: false, theme: 'warning', life: jGrowlLife });
                    $("#divSenderName").addClass('has-error'); $("#txtSenderName").focus();
                    return false;
                } else { $("#divSenderName").removeClass('has-error'); }
            }

            SaveandUpdateCompanyInformation();

            return false;
        });

        function ClearFields() {
            $("#txtMaxDiscount").val(0);
            $("#txtMaxSalesDiscount").val(0);
            $("#chkSMSSend").prop("checked", false);
            $("#txtPassword").val("");
            $("#txtSenderName").val("");
            $("#txtUserName").val("");
            $("#txtAPILink").val("");

            $("#divMaxDiscount").removeClass('has-error');
            $("#divMaxSalesDiscount").removeClass('has-error');
            return false;
        }

        function SaveandUpdateCompanyInformation() {
            var Obj = new Object();
            Obj.MaxDiscountPercent = $("#txtMaxDiscount").val().trim();
            Obj.MaxSalesDiscountPercent = $("#txtMaxSalesDiscount").val().trim();
            Obj.RetailMinMargin = $("#txtRetailMinMargin").val().trim();
            Obj.WholeSaleMinMargin = $("#txtWholeSaleMinMargin").val().trim();
            Obj.SalesTaxAmount = $("#txtSalesTaxReturn").val().trim();
            Obj.SenderName = $("#txtSenderName").val().trim();
            Obj.APILink = $("#txtAPILink").val().trim();
            Obj.SMSUsername = $("#txtUserName").val().trim();
            Obj.SMSPassword = $("#txtPassword").val().trim();
            Obj.SendSMS = $("#chkSMSSend").is(':checked') ? "1" : "0";
            Obj.HostName = $("#txtHostName").val().trim();
            Obj.Port = $("#txtPort").val().trim();
            Obj.UserMailID = $("#txtEmailID").val().trim();
            Obj.TermsAndConditions = $("#txtTermsandConditions").val().trim();
            Obj.AdditionalNotes = $("#txtAdditionalNotes").val().trim();
            Obj.UserMailPassword = $("#txtEmailPassword").val().trim();
            Obj.EnableSSL = $("#chkEnableSSL").is(':checked') ? "1" : "0";
            Obj.DefaultCrendentials = $("#chkDefaultCredentials").is(':checked') ? "1" : "0";

            sMethodName = "UpdateSettings";

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
                                if (sMethodName == "AddSettings") {
                                    $.jGrowl("Saved Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
                                    $("#hdnCompanyID").val(objResponse.Value);
                                }
                                else if (sMethodName == "UpdateSettings") { $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }

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

        function GetCompanyInformation() {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetSettings",
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

                                    $("#txtMaxDiscount").val(obj.MaxDiscountPercent);
                                    $("#txtMaxSalesDiscount").val(obj.MaxSalesDiscount);
                                    $("#txtSalesTaxReturn").val(obj.SalesTaxAmount);
                                    $("#txtUserName").val(obj.SMSUsername);
                                    $("#txtPassword").val(obj.SMSPassword);
                                    $("#txtSenderName").val(obj.SenderName);
                                    $("#txtAPILink").val(obj.APILink);
                                    $("#txtRetailMinMargin").val(obj.RetailMinMargin);
                                    $("#txtWholeSaleMinMargin").val(obj.WholeSaleMinMargin);
                                    $("#chkSMSSend").prop("checked", obj.SendSMS ? true : false);
                                    $("#txtHostName").val(obj.HostName);
                                    $("#txtPort").val(obj.Port);
                                    $("#txtEmailID").val(obj.UserMailID);
                                    $("#txtTermsandConditions").val(obj.TermsAndConditions);
                                    $("#txtAdditionalNotes").val(obj.AdditionalNotes);
                                    $("#txtEmailPassword").val(obj.UserMailPassword);
                                    $("#chkEnableSSL").prop("checked", obj.EnableSSL ? true : false);
                                    $("#chkDefaultCredentials").prop("checked", obj.DefaultCrendentials ? true : false);
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


