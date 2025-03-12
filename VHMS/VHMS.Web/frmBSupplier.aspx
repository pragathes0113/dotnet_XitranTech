<%@ Page Title="Supplier" Language="C#" MasterPageFile="~/VHMSMasterPage.master" AutoEventWireup="true" CodeFile="frmBSupplier.aspx.cs" Inherits="frmBSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="VHMSWebHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VHMSWebContent" runat="Server">
    <div class="container-wrapper hidden">
        <section class="content-header">
            <h1>Supplier
            </h1>
            <div class="form-group  col-md-4" style="margin-left: 255px; margin-top: -34px;">
                <label>
                    Supplier Name</label>
                <select id="ddlCategoryName" class="form-control select2" data-placeholder="Select Category Name" tabindex="-1"></select>
            </div>
            <ol class="breadcrumb">
                <li><a href="frmDefault.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a href="#">Billing</a></li>
                <li class="active">Supplier</li>
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
                                            <th>Supplier
                                            </th>
                                            <th>Mobile No
                                            </th>
                                            <th>Supplier Address
                                            </th>
                                            <th class='hidden-xs'>Email
                                            </th>
                                            <th class='hidden-xs'>Status
                                            </th>
                                            <th>View
                                            </th>
                                            <th>Edit
                                            </th>
                                            <th>Delete
                                            </th>
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
                                <div class="form-group col-md-4" id="divName">
                                    <label>
                                        Name</label><span class="text-danger">*</span>
                                    <div class="input-group">
                                        <div class="input-group-addon"><i class="fa fa-user"></i></div>
                                        <input type="text" class="form-control" id="txtName" style="text-transform: uppercase" placeholder="Supplier Name"
                                            maxlength="255" tabindex="1" autocomplete="off" />
                                    </div>
                                </div>
                                <div class="form-group col-md-3" id="divCode" style="display: none">
                                    <label>
                                        Code</label>
                                    <input type="text" class="form-control" id="txtCode" placeholder="Supplier Code" style="text-transform: uppercase"
                                        maxlength="5" tabindex="2" autocomplete="off" />
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
                                <div class="form-group col-md-3" id="divPhoneNo2" style="display: none">
                                    <label>
                                        Alt Mobile No</label>
                                    <div class="input-group">
                                        <div class="input-group-addon"><i class="fa fa-phone"></i></div>
                                        <input type="text" class="form-control" id="txtPhoneNo2" placeholder="Phone No" maxlength="10"
                                            tabindex="6" onkeypress="return IsNumeric(event)" autocomplete="off" />
                                    </div>
                                </div>

                                <div class="form-group col-md-3" id="divState">
                                    <label>
                                        State</label><span class="text-danger">*</span>
                                    <select id="ddlState" class="form-control select2" data-placeholder="Select State" tabindex="7">
                                    </select>
                                </div>
                                <div class="form-group col-md-3" id="divCity" style="display: none">
                                    <label>
                                        City</label>
                                    <input type="text" class="form-control" id="txtCity" placeholder="City"
                                        maxlength="100" tabindex="8" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-3" id="divTaluk" style="display: none;">
                                    <label>
                                        Taluk</label>
                                    <input type="text" class="form-control" id="txtTaluk" placeholder="Taluk"
                                        maxlength="100" tabindex="9" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-3" id="divArea" style="display: none">
                                    <label>
                                        Area</label>
                                    <input type="text" class="form-control" id="txtArea" placeholder="Please enter Area"
                                        maxlength="120" tabindex="10" autocomplete="off" />
                                </div>
                                <div class="form-group col-md-3" id="divPincode">
                                    <label>
                                        Pincode</label>
                                    <input type="text" class="form-control" id="txtPincode" placeholder="Pincode"
                                        maxlength="6" tabindex="11" onkeypress="return IsNumeric(event)" autocomplete="off" />
                                </div>

                                <div class="form-group col-md-3" id="divtxtLandline" style="display: none">
                                    <label>
                                        LandLine</label>
                                    <div class="input-group">
                                        <div class="input-group-addon"><i class="fa fa-phone"></i></div>
                                        <input type="text" class="form-control" id="txtLandline" placeholder="Landline" maxlength="13" onkeypress="return IsNumeric(event)"
                                            tabindex="12" autocomplete="off" />
                                    </div>
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
                                <div class="form-group col-md-4" id="divWeb" style="display: none">
                                    <label>
                                        Website</label>
                                    <div class="input-group">
                                        <div class="input-group-addon"><i class="fa fa-internet-explorer"></i></div>
                                        <input type="text" class="form-control" id="txtWebSite" placeholder="Website" maxlength="150" tabindex="15" autocomplete="off" />
                                    </div>
                                </div>
                                <div class="form-group col-md-2" id="divtxtDays" style="display: none;">
                                    <label>
                                        Due Days</label>
                                    <div class="input-group">
                                        <div class="input-group-addon"><i class="fa fa-calendar"></i></div>
                                        <input type="text" class="form-control" id="txtDays" placeholder="Days" maxlength="13" onkeypress="return IsNumeric(event)"
                                            tabindex="-1" autocomplete="off" />
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
                                <div class="form-group col-md-2">
                                    <div class="checkbox" style="margin-top: 30px">
                                        <label>
                                            <input type="checkbox" id="chkStatus" checked="checked" tabindex="21" />Active
                                        </label>
                                    </div>
                                </div>
                                <div class="form-group col-md-2" style="display: none;">
                                    <div class="checkbox" style="margin-top: 30px">
                                        <label>
                                            <input type="checkbox" id="chkRateUpdate" tabindex="22" />Rate review flag
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer clearfix">
                            <button id="btnSave" type="button" class="btn btn-info pull-right" tabindex="23">
                                <i class="fa fa-save"></i>&nbsp;&nbsp;
                                Save</button>
                            <button id="btnUpdate" type="button" class="btn btn-info pull-right" tabindex="24">
                                <i class="fa fa-edit"></i>&nbsp;&nbsp;
                                Update</button>
                            <button type="button" class="btn btn-danger pull-left" id="btnClose" tabindex="25">
                                <i class="fa fa-times"></i>&nbsp;&nbsp;
                                Close</button>
                        </div>
                    </div>
                </div>
        </section>
    </div>
    <input type="hidden" id="hdnSupplierID" />
    <script src="UserDefined_Js/Billing/JSupplier.js?v=<%= BaseConfig.GetFileHash("UserDefined_Js/Billing/JSupplier.js") %>" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
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

        function onlyAlphabets(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }
    </script>
</asp:Content>
