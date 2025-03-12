<%@ Page Title="Product" Language="C#" MasterPageFile="~/VHMSMasterPage.master" AutoEventWireup="true" CodeFile="frmProduct.aspx.cs" Inherits="frmProduct" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="VHMSWebHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VHMSWebContent" runat="Server">
    <div class="container-wrapper hidden">
        <div id="divSearchProduct">
            <section class="content-header">
                <h1>Product
                </h1>
                <div class="form-group  col-md-2" style="margin-left: 200px; margin-top: -34px;">
                    <label>
                        Category Name</label>
                    <select id="ddlCategoryName" class="form-control select2" data-placeholder="Select Category Name" tabindex="-1"></select>
                </div>
                <div class="form-group  col-md-2" style="margin-left: 0%; margin-top: -34px;">
                    <label>
                        Product Name</label>
                    <select id="ddlProductName" class="form-control select2" data-placeholder="Select Product Name" tabindex="-1"></select>
                </div>
                <div class="form-group  col-md-2" style="margin-left: 0%; margin-top: -34px;">
                    <label>
                        Supplier Name</label>
                    <select id="ddlSupplierName" class="form-control select2" data-placeholder="Select Supplier Name" tabindex="-1"></select>
                </div>
                <div class="form-group  col-md-2" style="margin-left: 55%; margin-top: -53px;">
                    <button type="button" style="background-color: #000000 !important;" class="btn btn-danger pull-right" id="btnView" tabindex="19">
                        View</button>
                </div>
                <ol class="breadcrumb">
                    <li><a href="frmDefault.aspx"><i class="fa fa-home"></i>Home</a></li>
                    <li><a href="#">Master</a></li>
                    <li class="active">Product</li>
                </ol>
                <div class="pull-right">
                    <button id="btnAddNew" class="btn btn-info">
                        <i class="fa fa-plus-square"></i>&nbsp;&nbsp;Add New</button>
                </div>
            </section>
        </div>
        <section class="content">
            <div class="nav-tabs-custom" id="divTab">
                <ul class="nav nav-tabs" id="navbars">
                    <li id="iGeneral" class="active"><a id="aGeneral" href="#General" data-toggle="tab">General</a></li>
                    <li id="iSearch"><a id="aSearchResult" href="#SearchResult" data-toggle="tab">Search Result</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="General">
                        <div class="box box-warning">
                            <div class="box-body">
                                <div class="table-responsive">
                                    <table id="tblRecord" class="table table-striped table-bordered bg-info" width="100%">
                                        <thead>
                                            <tr>
                                                <th>SNo</th>
                                                <th>Category</th>
                                                <th>Supplier</th>
                                                <th>Product Name</th>
                                                <th>Sales Margin</th>
                                                <th>Status</th>
                                                <th>View</th>
                                                <th>Edit</th>
                                                <th>Delete</th>
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
                                                    <th>SNo</th>
                                                    <th>Category</th>
                                                    <th>Supplier</th>
                                                    <th>Product Name</th>
                                                    <th>Sales Margin</th>
                                                    <th>Status</th>
                                                    <th>View</th>
                                                    <th>Edit</th>
                                                    <th>Delete</th>
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
            <div id="divproductScreen">
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
                                    <div class="form-group col-md-3" id="divCategory">
                                        <label>
                                            Category</label><span class="text-danger">*</span>
                                        <select id="ddlCategory" class="form-control select2" data-placeholder="Select Category" tabindex="1">
                                        </select>
                                    </div>
                                    <div class="form-group col-md-6" id="divName">
                                        <label>
                                            Product Name</label><span class="text-danger">*</span>
                                        <input type="text" class="form-control" id="txtName" style="text-transform: uppercase" placeholder="Please enter Product Name"
                                            maxlength="150" tabindex="2" autocomplete="off" />
                                    </div>
                                    <div class="form-group col-md-4 " id="divProductCode" style="display:none">
                                        <label>
                                            Product Company Name
                                        </label>
                                        <span class="text-danger">*</span>
                                        <input type="text" class="form-control" id="txtProductCode" placeholder="Please enter HSN Code"
                                            maxlength="10" tabindex="3" autocomplete="off" />
                                    </div>
                                    <div class="form-group col-md-3" id="divSalesMargin">
                                        <label>
                                            Sales Margin</label><span class="text-danger">*</span>
                                        <input type="text" class="form-control" id="txtSalesPercent" placeholder="Please enter Sales Margin"
                                            maxlength="10" tabindex="4" onkeypress="return IsNumeric(event)" autocomplete="off" />
                                    </div>
                                    <div class="form-group col-md-3" id="divTax" style="display: none">
                                        <label>
                                            Tax</label><span class="text-danger">*</span>
                                        <select id="ddlTaxName" class="form-control select2" data-placeholder="Select Tax" tabindex="5">
                                        </select>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label>
                                            Add Supplier</label>
                                        <div>
                                            <button id="btnSupplierAdd" class="btn btn-info">
                                                <i class="fa fa-plus-square"></i>
                                            </button>
                                        </div>
                                    </div>
                                    <div class="form-group  col-md-4" id="divSupplier">
                                        <label>
                                            Supplier</label><span class="text-danger">*</span>
                                        <select id="ddlSupplier" class="form-control select2" data-placeholder="Select Supplier" tabindex="6">
                                        </select>
                                    </div>
                                    <div class="form-group  col-md-3" id="divUnit">
                                        <label>
                                            Unit</label><span class="text-danger">*</span>
                                        <select id="ddlUnit" class="form-control select2" data-placeholder="Select Unit" tabindex="7">
                                        </select>
                                    </div>
                                    <div class="checkbox col-md-1 ">
                                        <label>
                                            <input type="checkbox" id="chkStatus" checked="checked" tabindex="8" />Active
                                        </label>
                                    </div>
                                </div>

                                <div class="row" style="display: none">
                                    <div class="form-group col-md-4">
                                        <label>
                                            Image 1</label>
                                        <button id="btnClearImage1" type="button" style="margin-top: -11px; color: deeppink;" class="btn btn-link">
                                            Clear</button>
                                        <input name="imagefile" type="file" id="imagefile" data-image-src="imgUpload1_view" accept="image/*" onchange="ResizeImage('imagefile');" />
                                        <a href="#" data-fancybox="images">
                                            <img src="" id="imgUpload1_view" alt="" class="preview_img" style="width: 280px;" />
                                        </a>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>
                                            Image 2</label>
                                        <button id="btnClearImage2" type="button" style="margin-top: -11px; color: deeppink;" class="btn btn-link">
                                            Clear</button>
                                        <input name="imagefile" type="file" id="imagefile2" data-image-src="imgUpload2_view" accept="image/*" onchange="ResizeImage('imagefile2');" />
                                        <a href="#" data-fancybox="images">
                                            <img src="" id="imgUpload2_view" alt="" class="preview_img" style="width: 280px;" />
                                        </a>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>
                                            Image 3</label>
                                        <button id="btnClearImage3" type="button" style="margin-top: -11px; color: deeppink;" class="btn btn-link">
                                            Clear</button>
                                        <input name="imagefile" type="file" id="imagefile3" data-image-src="imgUpload3_view" accept="image/*" onchange="ResizeImage('imagefile3');" />
                                        <a href="#" data-fancybox="images">
                                            <img src="" id="imgUpload3_view" alt="" class="preview_img" style="width: 280px;" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer clearfix">
                                <button type="submit" class="btn btn-info pull-right" id="btnSave" tabindex="9">
                                    <i class="fa fa-save"></i>&nbsp;&nbsp;
                                Save</button>
                                <button type="submit" class="btn btn-info pull-right" id="btnUpdate" tabindex="10">
                                    <i class="fa fa-edit"></i>&nbsp;&nbsp;
                                Update</button>
                                <button type="button" class="btn btn-danger pull-left" id="btnClose" tabindex="11">
                                    <i class="fa fa-close"></i>&nbsp;&nbsp;
                                Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box box-solid box-primary" id="divSupplierinfo">
                <div class="box-header with-border">
                    <div class="box-title">
                        <i class="fa fa-user"></i>&nbsp;&nbsp;Supplier
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="form-group col-md-4" id="divSupplierName">
                            <label>
                                Name</label><span class="text-danger">*</span>
                            <div class="input-group">
                                <div class="input-group-addon"><i class="fa fa-user"></i></div>
                                <input type="text" class="form-control" id="txtSupplierName" style="text-transform: uppercase" placeholder="Supplier Name"
                                    maxlength="255" tabindex="1" autocomplete="off" />
                            </div>
                        </div>
                        <div class="form-group col-md-4" id="divPhoneNo1">
                            <label>
                                Mobile No</label><span class="text-danger">*</span>
                            <div class="input-group">
                                <div class="input-group-addon"><i class="fa fa-phone"></i></div>
                                <input type="text" class="form-control" id="txtPhoneNo1" placeholder="Phone No" maxlength="10"
                                    tabindex="3" onkeypress="return IsNumeric(event)" autocomplete="off" />
                            </div>
                        </div>
                        <div class="form-group col-md-4" id="divWhatsAppNo">
                            <label>
                                WhatsApp No</label>
                            <div class="input-group">
                                <div class="input-group-addon"><i class="fa fa-whatsapp"></i></div>
                                <input type="text" class="form-control" id="txtWhatsAppNo" placeholder="Please enter WhatsApp No"
                                    maxlength="10" tabindex="5" onkeypress="return isNumberKey(event)" autocomplete="off" />
                            </div>
                        </div>
                        <div class="form-group col-md-6" id="divAddress">
                            <label>
                                Address</label>
                            <textarea id="txtAddress" class="form-control" maxlength="255" tabindex="4" rows="4" aria-autocomplete="none"></textarea>
                        </div>
                        <div class="form-group col-md-3" id="divState">
                            <label>
                                State</label><span class="text-danger">*</span>
                            <select id="ddlState" class="form-control select2" data-placeholder="Select State" tabindex="7">
                            </select>
                        </div>
                        <div class="form-group col-md-3" id="divPincode">
                            <label>
                                Pincode</label>
                            <input type="text" class="form-control" id="txtPincode" placeholder="Pincode"
                                maxlength="6" tabindex="11" onkeypress="return IsNumeric(event)" autocomplete="off" />
                        </div>
                        <div class="form-group col-md-3" id="divFax">
                            <label>
                                GST No</label>
                            <input type="text" class="form-control" id="txtFax" placeholder="GST No" maxlength="20"
                                tabindex="13" autocomplete="off" />
                            <button id="btnLink" type="button" class="btn btn-link" style="display: none;">
                                <i class="fa fa-link" aria-hidden="true"></i>&nbsp;&nbsp;
                            Verify GSTNO</button>
                        </div>
                        <div class="form-group col-md-3" id="divEmail">
                            <label>
                                Email</label>
                            <div class="input-group">
                                <div class="input-group-addon"><i class="fa fa-envelope"></i></div>
                                <input type="text" class="form-control" id="txtEmail" placeholder="Email" maxlength="50" tabindex="14" autocomplete="off" />
                            </div>
                        </div>
                        <div class="form-group col-md-4" id="divAccountNo">
                            <label>
                                Account No</label>
                            <input type="text" class="form-control" id="txtAccountNo" placeholder="Account No"
                                maxlength="20" tabindex="16" onkeypress="return isNumberKey(event)" autocomplete="off" />
                        </div>
                        <div class="form-group col-md-4" id="divBankName">
                            <label>
                                Bank Name</label>
                            <input type="text" class="form-control" id="txtBankName" placeholder="Please enter BankName"
                                maxlength="100" tabindex="17" autocomplete="off" />
                        </div>
                        <div class="form-group col-md-4" id="divBranchName">
                            <label>
                                Branch Name</label>
                            <input type="text" class="form-control" id="txtBranchName" placeholder="Please enter BranchName"
                                maxlength="50" tabindex="18" autocomplete="off" />
                        </div>
                        <div class="form-group col-md-4" id="divAccountHolderName">
                            <label>
                                Account Holder Name</label>
                            <input type="text" class="form-control" id="txtAccountHolderName" placeholder="Please enter AccountHolderName"
                                maxlength="50" tabindex="19" autocomplete="off" />
                        </div>
                        <div class="form-group col-md-4" id="divIFSCCode">
                            <label>
                                IFSC Code</label>
                            <input type="text" class="form-control" id="txtIFSCCode" placeholder="Please enter IFSCCode"
                                maxlength="20" tabindex="20" autocomplete="off" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer clearfix">
                    <button type="button" class="btn btn-danger pull-left" id="btnSupplierClose" tabindex="63">
                        <i class="fa fa-times"></i>&nbsp;&nbsp;Close</button>
                    <button type="button" class="btn btn-info pull-right" id="btnSupplierSave" tabindex="61">
                        <i class="fa fa-save"></i>&nbsp;&nbsp;Save</button>
                    <button type="button" class="btn btn-info pull-right" id="btnSupplierUpdate" tabindex="62">
                        <i class="fa fa-edit"></i>&nbsp;&nbsp;Update</button>
                </div>
            </div>
        </section>
    </div>
    <input type="hidden" id="hdnID" />

    <script type="text/javascript">
        var pageUrl = '<%=ResolveUrl("~/frmProduct.aspx") %>';

        // on first focus (bubbles up to document), open the menu
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

            if (ActionUpdate != "1") {
                $("#btnUpdate").remove();
            }
            var Sup_Code = "";

            pLoadingSetup(false);
            pLoadingSetup(true);
            GetCategoryName();
            GetSupplierName();
            GetProductList("ddlProductName");
            GetCategoryList();
            GetUnitList();
            GetSupplier("ddlSupplier");
            GetTaxList("ddlTaxName");
            $("#divSupplierinfo").hide();
            GetRecord();
        });
        $("#btnSupplierAdd").click(function () {
            GetStateList();
            $("#btnClose").click();
            $("#divTab").hide();
            $("#btnSupplierAdd").hide();
            $("#btnSupplierSave").show();
            $("#btnSupplierClose").show();
            $("#btnSupplierUpdate").hide();
            $("#divSearchProduct").hide()
            $("#divSupplierinfo").show();
            ClearAddSupplierFields();
            document.title = "Add New Supplier";
            return false;
        });

        $("#btnSupplierClose").click(function () {
            $("#divSupplierinfo").hide();
            $("#btnAddNew").click();
            //$("#divTab").show();
            //$("#divSearchProduct").show();
            return false;
        });
        function ClearAddSupplierFields() {
            $("#txtSupplierName").val("");
            $("#txtAddress").val("");
            $("#ddlState").val(null).change();
            $("#txtPincode").val("");
            $("#txtPhoneNo1").val("");
            $("#txtWhatsAppNo").val("");
            $("#txtPhoneNo2").val("");
            $("#txtFax").val("");
            $("#txtEmail").val("");
            $("#chkStatus").prop("checked", true);
            $("#txtBranchName").val("");
            $("#txtAccountNo").val("");
            $("#txtBankName").val("");
            $("#txtIFSCCode").val("");
            $("#txtAccountHolderName").val("");
            $("#divName").removeClass('has-error');
            $("#divState").removeClass('has-error');
            $("#divPincode").removeClass('has-error');
            $("#divPhoneNo1").removeClass('has-error');
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
        function saveimage(id) {
            pLoadingSetup(false);

            var images = $("#" + id + "").attr('src');
            var ImageSave = images.replace("data:image/jpeg;base64,", "");
            var submitval = JSON.stringify({ data: ImageSave });

            $.ajax({
                type: "POST",
                url: pageUrl + "/saveimage",
                data: submitval,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    $get(id).src = "./" + r.d;
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
            pLoadingSetup(true);
        }

        $("#aGeneral").click(function () {
            $("#SearchResult").hide();
            GetRecord();
        });

        $("#aSearchResult").click(function () {
            $("#SearchResult").show();

        });


        $("#txtSearchName").change(function () {

            if ($("#txtSearchName").val().trim() != "" || $("#txtSearchName").val().trim() != undefined) {
                var iDetails = $("#txtSearchName").val();
                GetSearchRecord(iDetails);
            }
            return false;
        });
        function GetSupplier(ddlname) {
            var sControlName = "#" + ddlname;
            dProgress(true);
            $(sControlName).empty();
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetSupplier",
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
                                    $(sControlName).append('<option value="' + '0' + '">' + '--All--' + '</option>');
                                    for (var index = 0; index < obj.length; index++) {
                                        if (obj[index].IsActive == "1")
                                            $(sControlName).append('<option value=' + obj[index].SupplierID + ' >' + obj[index].SupplierName + '</option>');
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

        function GetTaxList(ddlname) {
            var sControlName = "#" + ddlname;
            dProgress(true);
            $(sControlName).empty();
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetTax",
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

                                    for (var index = 0; index < obj.length; index++) {
                                        if (obj[index].IsActive)
                                            $(sControlName).append("<option value='" + obj[index].TaxID + "'>" + obj[index].TaxName + "</option>");
                                    }
                                }
                                dProgress(false);
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $(sControlName).append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                                dProgress(false);
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                $.jGrowl("Error  Occured", { sticky: false, theme: 'danger', life: jGrowlLife });
                                window.location = "frmLogin.aspx";
                            }
                            else if (objResponse.Value == "Error") {
                                window.location = "frmErrorPage.aspx";
                            }
                            dProgress(false);
                        }
                    }
                    else {
                        $(sControlName).append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                        dProgress(false);
                    }
                },
                error: function (e) {
                    $.jGrowl("Error  Occured", { sticky: false, theme: 'danger', life: jGrowlLife });
                    dProgress(false);
                }
            });
            return false;
        }

        function GetCategoryList() {
            $("#ddlCategory").empty();
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetCategory",
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
                                    $("#ddlCategory").append('<option value="' + '0' + '">' + '--All--' + '</option>');
                                    for (var index = 0; index < obj.length; index++) {
                                        if (obj[index].IsActive == "1")
                                            $("#ddlCategory").append('<option value=' + obj[index].CategoryID + ' >' + obj[index].CategoryName + '</option>');
                                    }
                                }
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $("#ddlCategory").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
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
                        $("#ddlCategory").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                    }
                },
                error: function (e) {
                    $.jGrowl("Error  Occured", { sticky: false, theme: 'danger', life: jGrowlLife });
                }
            });
            return false;
        }

        function GetSupplierName() {
            $("#ddlSupplierName").empty();
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetSupplier",
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
                                    $("#ddlSupplierName").append('<option value="' + '0' + '">' + '--All--' + '</option>');
                                    for (var index = 0; index < obj.length; index++) {
                                        if (obj[index].IsActive == "1")
                                            $("#ddlSupplierName").append('<option value=' + obj[index].SupplierID + ' >' + obj[index].SupplierName + '</option>');
                                    }
                                }
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $("#ddlSupplierName").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
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
                        $("#ddlSupplierName").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                    }
                },
                error: function (e) {
                    $.jGrowl("Error  Occured", { sticky: false, theme: 'danger', life: jGrowlLife });
                }
            });
            return false;
        }

        function GetCategoryName() {
            $("#ddlCategoryName").empty();
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetCategory",
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
                                    $("#ddlCategoryName").append('<option value="' + '0' + '">' + '--All--' + '</option>');
                                    for (var index = 0; index < obj.length; index++) {
                                        if (obj[index].IsActive == "1")
                                            $("#ddlCategoryName").append('<option value=' + obj[index].CategoryID + ' >' + obj[index].CategoryName + '</option>');
                                    }
                                }
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $("#ddlCategoryName").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
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
                        $("#ddlCategoryName").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                    }
                },
                error: function (e) {
                    $.jGrowl("Error  Occured", { sticky: false, theme: 'danger', life: jGrowlLife });
                }
            });
            return false;
        }

        $("#btnClearImage1").click(function () {
            $get("imgUpload1_view").src = "";
            $("#imagefile").val("");
        });

        $("#btnClearImage2").click(function () {
            $get("imgUpload2_view").src = "";
            $("#imagefile2").val("");
        });

        $("#btnClearImage3").click(function () {
            $get("imgUpload3_view").src = "";
            $("#imagefile3").val("");
        });

        function GetProductList(ddlname) {
            var sControlName = "#" + ddlname;
            dProgress(true);
            $(sControlName).empty();
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetProductList",
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
                                        if (obj[index].IsActive)
                                            $(sControlName).append("<option value='" + obj[index].ProductID + "'>" + obj[index].ProductName + "</option>");
                                    }
                                }
                                dProgress(false);
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $(sControlName).append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                                dProgress(false);
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                $.jGrowl("Error  Occured", { sticky: false, theme: 'danger', life: jGrowlLife });
                                window.location = "frmLogin.aspx";
                            }
                            else if (objResponse.Value == "Error") {
                                window.location = "frmErrorPage.aspx";
                            }
                            dProgress(false);
                        }
                    }
                    else {
                        $(sControlName).append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                        dProgress(false);
                    }
                },
                error: function (e) {
                    $.jGrowl("Error  Occured", { sticky: false, theme: 'danger', life: jGrowlLife });
                    dProgress(false);
                }
            });
            return false;
        }
        function GetUnitList() {
            $("#ddlUnit").empty();
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetUnit",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ ID: $("#ddlCategory").val() }),
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != "") {
                        var objResponse = jQuery.parseJSON(data.d);
                        if (objResponse.Status == "Success") {
                            if (objResponse.Value != null && objResponse.Value != "NoRecord") {
                                var obj = $.parseJSON(objResponse.Value);
                                if (obj.length > 0) {
                                    $("#ddlUnit").append('<option value="' + '0' + '">' + '--All--' + '</option>');
                                    for (var index = 0; index < obj.length; index++) {
                                        if (obj[index].IsActive == "1")
                                            $("#ddlUnit").append('<option value=' + obj[index].UnitID + ' >' + obj[index].UnitName + '</option>');
                                    }
                                }
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $("#ddlUnit").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
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
                        $("#ddlUnit").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
                    }
                },
                error: function (e) {
                    $.jGrowl("Error  Occured", { sticky: false, theme: 'danger', life: jGrowlLife });
                }
            });
            return false;
        }

        $("#btnAddNew").click(function () {
            ClearFields();

            $('input,select').keydown(function (event) { //event==Keyevent
                if (event.which == 13) {
                    $("#btnSave").click();
                    event.preventDefault();

                }
            });
            $("#divSupplierinfo").hide();
            $("#btnSupplierAdd").show();
            $("#hdnID").val("");
            $("#btnSave").show();
            $("#btnUpdate").hide();
            $(".modal-title").html("<i class='fa fa-plus-square'></i>&nbsp;&nbsp;Add Product");
            $('#compose-modal').modal({ show: true, backdrop: true });
            $("#ddlCategory").val(4).change();
            $("#ddlTaxName").val(8).change();
            $("#txtName").focus();
            $("#txtProductCode").focus();
            $("#imagefile").val("");
            $("#imagefile2").val("");
            $("#imagefile3").val("");
            return false;
        });

        $("#btnView").click(function () {
            GetRecord();
        });


        $("#btnSave,#btnUpdate").click(function () {
            if (this.id == "btnSave") { if (ActionAdd != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }
            else if (this.id == "btnUpdate") { if (ActionUpdate != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }

            if ($("#ddlCategory").val() == "0" || $("#ddlCategory").val() == undefined) {
                $.jGrowl("Please Select Category", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divCategory").addClass('has-error'); $("#ddlCategory").focus(); return false;
            } else { $("#divCategory").removeClass('has-error'); }

            if ($("#txtName").val().trim() == "" || $("#txtName").val().trim() == undefined) {
                $.jGrowl("Please enter Product", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divName").addClass('has-error'); $("#txtName").focus(); return false;
            } else { $("#divName").removeClass('has-error'); }

            //if ($("#txtProductCode").val().trim() == "" || $("#txtProductCode").val().trim() == undefined) {
            //    $.jGrowl("Please enter HSN Code", { sticky: false, theme: 'warning', life: jGrowlLife });
            //    $("#divProductCode").addClass('has-error'); $("#txtProductCode").focus(); return false;
            //} else { $("#divProductCode").removeClass('has-error'); }

            if ($("#txtSalesPercent").val().trim() == "" || $("#txtSalesPercent").val().trim() == undefined) {
                $.jGrowl("Please enter Sales Margin", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divSalesMargin").addClass('has-error'); $("#txtSalesPercent").focus(); return false;
            } else { $("#divSalesMargin").removeClass('has-error'); }

            if ($("#ddlTaxName").val() == "0" || $("#ddlTaxName").val() == undefined) {
                $.jGrowl("Please Select Tax", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divTax").addClass('has-error'); $("#ddlTaxName").focus(); return false;
            } else { $("#divTax").removeClass('has-error'); }

            if ($("#ddlSupplier").val() == "0" || $("#ddlSupplier").val() == undefined) {
                $.jGrowl("Please Select Supplier", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divSupplier").addClass('has-error'); $("#ddlSupplier").focus(); return false;
            } else { $("#divSupplier").removeClass('has-error'); }

            if ($("#ddlUnit").val() == "0" || $("#ddlUnit").val() == undefined) {
                $.jGrowl("Please Select Unit", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divUnit").addClass('has-error'); $("#ddlUnit").focus(); return false;
            } else { $("#divUnit").removeClass('has-error'); }
            var Obj = new Object();
            Obj.ProductID = 0;
            var ObjCategory = new Object();
            ObjCategory.CategoryID = $("#ddlCategory").val();
            Obj.Category = ObjCategory;
            Obj.ProductName = $("#txtName").val().toUpperCase();
            Obj.ProductCode = $("#txtProductCode").val();
            Obj.SalesPercent = parseFloat($("#txtSalesPercent").val());
            var ObjSupplier = new Object();
            ObjSupplier.SupplierID = $("#ddlSupplier").val();
            Obj.Supplier = ObjSupplier;
            var ObjTax = new Object();
            ObjTax.TaxID = 8;
            Obj.Tax = ObjTax;
            var ObjUnit = new Object();
            ObjUnit.UnitID = $("#ddlUnit").val();
            Obj.Unit = ObjUnit;
            Obj.ProductImage1 = $("[id*=imgUpload1_view]").attr("src");
            Obj.ProductImage2 = $("[id*=imgUpload2_view]").attr("src");
            Obj.ProductImage3 = $("[id*=imgUpload3_view]").attr("src");
            Obj.IsActive = $("#chkStatus").is(':checked') ? "1" : "0";
            var sMethodName;
            if ($("#hdnID").val() > 0) {
                Obj.ProductID = $("#hdnID").val();
                sMethodName = "UpdateProduct";
            }
            else { sMethodName = "AddProduct"; }

            SaveandUpdateProduct(Obj, sMethodName);

            return false;
        });

        $("#btnClose").click(function () {
            $('#compose-modal').modal('hide');
            return false;
        });

        function ClearFields() {
            $("#txtName").val("");
            $("#txtProductCode").val("");
            $("#txtSalesPercent").val("0");
            $("#chkStatus").prop("checked", true);
            $("#ddlCategory").val($("#ddlCategory option:first").val()).change();
            $("#ddlSupplier").val($("#ddlSupplier option:first").val()).change();
            $("#ddlUnit").val($("#ddlUnit option:first").val()).change();
            $("#ddlTaxName").val($("#ddlTaxName option:first").val()).change();
            $("#divName").removeClass('has-error');
            $("#divCategory").removeClass('has-error');
            $("#divUnit").removeClass('has-error');
            $("#divSupplier").removeClass('has-error');
            $get("imgUpload1_view").src = "";
            $get("imgUpload2_view").src = "";
            $get("imgUpload3_view").src = "";
            $("[id*=imgUpload1_view]").css("visibility", "hidden");
            $("[id*=imgUpload2_view]").css("visibility", "hidden");
            $("[id*=imgUpload3_view]").css("visibility", "hidden");
            return false;
        }

        function GetRecord() {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetAllProduct",
                data: JSON.stringify({ ID: $("#ddlProductName").val(), CategoryID: $("#ddlCategoryName").val(), SupplierID: $("#ddlSupplierName").val() }),
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

                                        var table = "<tr id='" + obj[index].ProductID + "'>";
                                        table += "<td>" + (index + 1) + "</td>";
                                        table += "<td>" + obj[index].Category.CategoryName + "</td>";
                                        table += "<td>" + obj[index].Supplier.SupplierName + "</td>";
                                        table += "<td>" + obj[index].ProductName + "</td>";
                                        table += "<td>" + obj[index].SalesPercent + "</td>";
                                        table += "<td>" + TypeStatus + "</td>";
                                        if (ActionView == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].ProductID + " class='View' title='Click here to View'><i class='fa fa-lg fa-clone text-yellow'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        if (ActionUpdate == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].ProductID + " class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        if (ActionDelete == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].ProductID + " class='Delete' title='Click here to Delete'><i class='fa fa-lg fa-trash-o text-red'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        table += "</tr>";
                                        $("#tblRecord_tbody").append(table);
                                    }
                                    $(".View").click(function () {
                                        if (ActionView == "1") {
                                            EditRecord($(this).parent().parent()[0].id);
                                            $(".modal-title").html("<i class='fa fa-clone'></i>&nbsp;&nbsp;View Product");
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
                                    { "sWidth": "6%" },
                                    { "sWidth": "10%" },
                                    { "sWidth": "15%" },
                                    { "sWidth": "30%" },
                                    { "sWidth": "20%" },
                                    { "sWidth": "2%" },
                                    { "sWidth": "2%" },
                                    { "sWidth": "2%" },
                                    { "sWidth": "2%" }
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

        function GetSearchRecord(iDetails) {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/SearchProduct",
                data: JSON.stringify({ ID: iDetails }),
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

                                        var table = "<tr id='" + obj[index].ProductID + "'>";
                                        table += "<td>" + (index + 1) + "</td>";
                                        table += "<td>" + obj[index].Category.CategoryName + "</td>";
                                        table += "<td>" + obj[index].Supplier.SupplierName + "</td>";
                                        table += "<td>" + obj[index].ProductName + "</td>";
                                        table += "<td>" + obj[index].SalesPercent + "</td>";
                                        table += "<td>" + TypeStatus + "</td>";
                                        if (ActionView == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].ProductID + " class='View' title='Click here to View'><i class='fa fa-lg fa-clone text-yellow'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        if (ActionUpdate == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].ProductID + " class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        if (ActionDelete == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].ProductID + " class='Delete' title='Click here to Delete'><i class='fa fa-lg fa-trash-o text-red'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        table += "</tr>";
                                        $("#tblSearchResult_tbody").append(table);
                                    }
                                    $(".View").click(function () {
                                        if (ActionView == "1") {
                                            EditRecord($(this).parent().parent()[0].id);
                                            $(".modal-title").html("<i class='fa fa-clone'></i>&nbsp;&nbsp;View Product");
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
                                    { "sWidth": "6%" },
                                    { "sWidth": "10%" },
                                    { "sWidth": "15%" },
                                    { "sWidth": "30%" },
                                    { "sWidth": "20%" },
                                    { "sWidth": "2%" },
                                    { "sWidth": "2%" },
                                    { "sWidth": "2%" },
                                    { "sWidth": "2%" }
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

        function SaveandUpdateProduct(Obj, sMethodName) {
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
                                GetProductList("ddlProductName");
                                if (sMethodName == "AddProduct") { $.jGrowl("Added Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }
                                else if (sMethodName == "UpdateProduct") { $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }

                                $('#compose-modal').modal('hide');
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                window.location = "frmLogin.aspx";
                            }
                            else if (objResponse.Value == "Product_A_01" || objResponse.Value == "Product_U_01") {
                                $.jGrowl("Product Name Already Exists", { sticky: false, theme: 'danger', life: jGrowlLife });
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
                url: "WebServices/VHMSService.svc/GetProductByID",
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
                                    $("#hdnID").val(obj.ProductID);
                                    $("#txtName").val(obj.ProductName);
                                    $("#txtProductCode").val(obj.ProductCode);
                                    $("#txtSalesPercent").val(obj.SalesPercent);
                                    $("#ddlCategory").val(obj.Category.CategoryID).change();
                                    $("#ddlSupplier").val(obj.Supplier.SupplierID).change();
                                    $("#ddlTaxName").val(obj.Tax.TaxID).change();
                                    $("#ddlUnit").val(obj.Unit.UnitID).change();
                                    $("[id*=imgUpload1_view]").css("visibility", "visible");
                                    $("[id*=imgUpload1_view]").attr("src", obj.ProductImage1);
                                    $("[id*=imgUpload2_view]").css("visibility", "visible");
                                    $("[id*=imgUpload2_view]").attr("src", obj.ProductImage2);
                                    $("[id*=imgUpload3_view]").css("visibility", "visible");
                                    $("[id*=imgUpload3_view]").attr("src", obj.ProductImage3);
                                    $("#chkStatus").prop("checked", obj.IsActive ? true : false);
                                    $("#chkPricingA").prop("checked", obj.PricingA ? true : false);
                                    $("#chkPricingB").prop("checked", obj.PricingB ? true : false);
                                    $("#chkPricingC").prop("checked", obj.PricingC ? true : false);

                                    $('#compose-modal').modal({ show: true, backdrop: true });
                                    $(".modal-title").html("<i class='fa fa-pencil'></i>&nbsp;&nbsp;Edit Product");
                                }
                                dProgress(false);
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

        function DeleteRecord(id) {
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/DeleteProduct",
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
                            else if (objResponse.Value == "Product_R_01" || objResponse.Value == "Product_D_01") {
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

        $("#btnSupplierSave").click(function () {
            if ($("#txtSupplierName").val().trim() == "" || $("#txtSupplierName").val().trim() == undefined) {
                $.jGrowl("Please enter Supplier Name", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divSupplierName").addClass('has-error'); $("#txtSupplierName").focus(); return false;
            } else { $("#divSupplierName").removeClass('has-error'); }
            if ($("#ddlState").val() == "0" || $("#ddlState").val() == undefined) {
                $.jGrowl("Please Select State", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divState").addClass('has-error'); $("#ddlState").focus(); return false;
            } else { $("#divState").removeClass('has-error'); }
            if ($("#txtPhoneNo1").val().trim() == "" || $("#txtPhoneNo1").val().trim() == undefined) {
                $.jGrowl("Please enter Phone No", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divPhoneNo1").addClass('has-error'); $("#txtPhoneNo1").focus(); return false;
            } else { $("#divPhoneNo1").removeClass('has-error'); }
            SaveandUpdateSupplier();
            return false;
        });
        function SaveandUpdateSupplier() {
            var Obj = new Object();
            Obj.SupplierID = 0;
            Obj.SupplierName = $("#txtSupplierName").val().toUpperCase();
            Obj.SupplierAddress = $("#txtAddress").val().trim();
            Obj.Pincode = $("#txtPincode").val();
            Obj.PhoneNo1 = $("#txtPhoneNo1").val().trim();
            Obj.WhatsAppNo = $("#txtWhatsAppNo").val().trim();
            Obj.Email = $("#txtEmail").val().trim();
            Obj.IsActive = $("#chkStatus").is(':checked') ? "1" : "0";
            var ObjState = new Object();
            ObjState.StateID = $("#ddlState").val();
            Obj.State = ObjState;
            Obj.AccountNo = $("#txtAccountNo").val();
            Obj.BankName = $("#txtBankName").val();
            Obj.BranchName = $("#txtBranchName").val();
            Obj.AccountHolderName = $("#txtAccountHolderName").val();
            Obj.IFSCCode = $("#txtIFSCCode").val();
            if ($("#hdnSupplierID").val() > 0) {
                Obj.SupplierID = $("#hdnSupplierID").val();
                sMethodName = "UpdateSupplier";
            }
            else { sMethodName = "AddSupplier"; }
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
                                if (sMethodName == "AddSupplier") {
                                    $("#btnAddNew").click();
                                    $("#divTab").show();
                                    $("#divSearchProduct").show();
                                    GetSupplier("ddlSupplier");
                                    GetSupplierID(objResponse.Value);
                                    $.jGrowl("Saved Successfully", { sticky: false, theme: 'success', life: jGrowlLife });

                                }
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                window.location = "frmLogin.aspx";
                            }
                            else if (objResponse.Value == "Supplier_A_01") {
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
        function GetSupplierID(id) {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetSupplierByID",
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
                                    $("#ddlSupplier").val(obj.SupplierID).change();
                                }
                                dProgress(false);
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


