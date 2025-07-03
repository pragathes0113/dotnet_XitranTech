<%@ Page Title="New Customer" Language="C#" MasterPageFile="~/VHMSMasterPage.master" AutoEventWireup="true" CodeFile="frmNewCustomer.aspx.cs" Inherits="frmNewCustomer" %>

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

        .question-row {
            display: flex;
            align-items: center;
            margin-bottom: 1rem;
        }

        .question-label {
            flex: 1 1 60%;
            padding-right: 10px;
            font-weight: 500;
            font-weight: bold;
        }

        .question-select {
            flex: 0 0 20%;
        }

        .question-textbox {
            flex: 0 0 20%;
        }

        select, .form-control {
            height: 30px;
            font-size: 14px;
            width: 100%;
        }
    </style>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="VHMSWebContent" runat="Server">
    <div class="container-wrapper hidden">
        <section class="content-header" id="secHeader">
            <div id="divTitle">
                <h3>New Customer
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
                                                <th>New Customer</th>
                                                <th>Mobile Number</th>
                                                <th>House Type</th>
                                                <th>KMS</th>
                                                <th>Packing Date</th>
                                                <th>Reaching Date</th>
                                                <th>GST Amount</th>
                                                <th>Net Amount</th>
                                                <th>Status</th>
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
                                        Search Sales records</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtSearchName" placeholder="Please enter Details"
                                        maxlength="150" />
                                </div>

                                <div class="table-responsive">
                                    <table id="tblSearchResult" class="table table-striped table-bordered bg-info" width="100%">
                                        <thead>
                                            <tr>
                                                <th>S.No</th>
                                                <th>New Customer</th>
                                                <th>Mobile Number</th>
                                                <th>House Type</th>
                                                <th>KMS</th>
                                                <th>Packing Date</th>
                                                <th>Reaching Date</th>
                                                <th>GST Amount</th>
                                                <th>Net Amount</th>
                                                <th>Status</th>
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
                    <div class="box-title">Customer Information</div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="form-group col-md-4" id="divNewCustomer">
                            <label>New Customer</label><span class="text-danger">*</span>
                            <input type="text" class="form-control" id="txtNewCustomer" placeholder="New Customer" maxlength="10" tabindex="2" />
                        </div>
                        <div class="form-group col-md-2" id="divMobileNo">
                            <label>Mobile No</label><span class="text-danger">*</span>
                            <input type="text" class="form-control" id="txtMobileNo" placeholder="Mobile No" maxlength="15" tabindex="3"
                                oninput="this.value = this.value.replace(/[^0-9]/g, '')" />
                        </div>
                        <div class="form-group col-md-2" id="divAltMobileNo">
                            <label>Alt Mobile No</label>
                            <input type="text" class="form-control" id="txtAltMobileNo" placeholder="Alt Mobile No" maxlength="15" tabindex="4"
                                oninput="this.value = this.value.replace(/[^0-9]/g, '')" />
                        </div>
                        <div class="form-group col-md-2" id="divPackingDate">
                            <label>Packing Date</label><span class="text-danger">*</span>
                            <div class="input-group date form_date" data-date-format="dd/MM/yyyy HH:ii P" data-link-format="dd/MM/yyyy">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar glyphicon glyphicon-calendar"></i>
                                </div>
                                <input type="text" class="form-control pull-right" tabindex="5" id="txtPackingDate" readonly />
                            </div>
                        </div>
                        <div class="form-group col-md-2" id="divShiftingDate">
                            <label>Shifting Date</label><span class="text-danger">*</span>
                            <div class="input-group date form_date" data-date-format="dd/MM/yyyy HH:ii P" data-link-format="dd/MM/yyyy">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar glyphicon glyphicon-calendar"></i>
                                </div>
                                <input type="text" class="form-control pull-right" tabindex="6" id="txtShiftingDate" readonly />
                            </div>
                        </div>
                        <div class="form-group col-md-2" id="divGST">
                            <label>GST</label>
                            <input type="text" class="form-control" id="txtGST" placeholder="GST" maxlength="10" tabindex="11" readonly />
                        </div>
                        <div class="form-group col-md-2" id="divHouseType">
                            <label>House Type</label><span class="text-danger">*</span>
                            <select id="ddlHouseType" class="form-control select2" data-placeholder="Select HouseType" tabindex="10"></select>
                        </div>
                        <div class="form-group col-md-2" id="divKms">
                            <label>Kms </label>
                            <span class="text-danger">*</span>
                            <input type="text" class="form-control" id="txtKms" placeholder="Kms" maxlength="10" tabindex="9"
                                oninput="this.value = this.value.replace(/[^0-9]/g, '')" />
                        </div>

                    </div>
                    <div class="row">
                        <div class="form-group col-md-6 mb-3" id="divCurrentAddress">
                            <label>Current Address <span class="text-danger">*</span></label>
                            <textarea id="txtCurrentAddress" class="form-control" maxlength="250" tabindex="7" rows="3"></textarea>
                        </div>
                        <div class="form-group col-md-6 mb-3" id="divAddress">
                            <label>Shifting Address <span class="text-danger">*</span></label>
                            <textarea id="txtShiftingAddress" class="form-control" maxlength="250" tabindex="8" rows="3"></textarea>
                        </div>
                    </div>

                    <div class="box box-primary box-solid">
                        <div class="box-header">
                            <h4 class="fw-bold mb-0" style="color: white;">Move Type: <span id="moveTypeHeading"></span></h4>
                        </div>
                        <div class="box-body">
                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        1. Are there any items that should be carried by more than two persons?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q1_select" name="q1_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q1_text" name="q1_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        2. Will there be any staircases involved during this move?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q2_select" name="q2_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q2_text" name="q2_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        (a). Do you have a service elevator available?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q2a_select" name="q2a_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q2a_text" name="q2a_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        3. Is there a proper parking place near the origin and destination so that our team won't have to walk more than 40 yards?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q3_select" name="q3_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q3_text" name="q3_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        (a). If no: There will be an additional charge for those long walks.<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q3a_select" name="q3a_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q3a_text" name="q3a_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        4. Would you like us to help with packing?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q4_select" name="q4_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q4_text" name="q4_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        (a). If yes: Wonderful, our team will take care of all the packing for you.<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q4a_select" name="q4a_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q4a_text" name="q4a_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        (b). If no: We can provide packing materials if needed.<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q4b_select" name="q4b_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q4b_text" name="q4b_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        5. Are there any fragile items that require special handling?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q5_select" name="q5_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q5_text" name="q5_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        6. Are there any flammable, industrial, or unusual items in this move?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q6_select" name="q6_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q6_text" name="q6_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        7. Could you please share your inventory list with us? This will help us provide a more precise estimate.<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q7_select" name="q7_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q7_text" name="q7_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        (a). (If yes): "Thank you, this will help us give you an accurate quote."<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q7a_select" name="q7a_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q7a_text" name="q7a_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        (b). (If no): "That’s okay. We can proceed with the information we have and make adjustments as needed later."<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q7b_select" name="q7b_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q7b_text" name="q7b_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        8. Do you have any heavy or bulky items, such as appliances, pianos, or safes, that require special handling?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q8_select" name="q8_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q8_text" name="q8_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        (a). There will be additional charge for handling pianos.<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q8a_select" name="q8a_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q8a_text" name="q8a_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        9. Is there any vehicle to be moved, like any cars or quad bikes?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q9_select" name="q9_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q9_text" name="q9_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        10. Would you like help with arranging a tow van or driver to move that vehicle?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q10_select" name="q10_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q10_text" name="q10_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        11. Does this move involve any junk removal?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q11_select" name="q11_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q11_text" name="q11_text">
                                </div>
                            </div>

                            <div class="row question-row align-items-center">
                                <div class="col-md-8">
                                    <label>
                                        12. If you prefer an overnight stop for this transit?<label />
                                </div>
                                <div class="col-md-1">
                                    <select class="form-select" id="q12_select" name="q12_select">
                                        <option value="">Select</option>
                                        <option value="Yes">Yes</option>
                                        <option value="No">No</option>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" class="form-control" id="q12_text" name="q12_text">
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">

                        <div class="form-group col-md-9"></div>
                        <div class="form-group col-md-1">
                            <label>
                                Call Status</label>
                            <span class="text-danger">*</span>
                        </div>
                        <div class="form-group col-md-2" id="divCallStatus">
                            <select class="form-select" id="ddlCallStatus" name="status" tabindex="12">
                                <option value="">Select</option>
                                <option value="Call Processed">Call Processed</option>
                                <option value="Want to Follow Up">Want to Follow Up</option>
                            </select>
                        </div>
                        <div class="form-group col-md-9"></div>
                        <div class="form-group col-md-1">
                            <label>
                                GST Amount</label>
                            <span class="text-danger">*</span>
                        </div>
                        <div class="form-group col-md-2" id="divGSTAmount">
                            <input type="text" class="form-control" id="txtGSTAmount" placeholder="GST Amount"
                                maxlength="15" tabindex="13" value="0" onkeypress="return IsNumeric(event)" autocomplete="off" />
                        </div>
                        <div class="form-group col-md-9"></div>
                        <div class="form-group col-md-1">
                            <label>
                                NetAmount</label>
                            <span class="text-danger">*</span>
                        </div>
                        <div class="form-group col-md-2" id="divNetAmount">
                            <input type="text" class="form-control" id="txtNetAmount" placeholder="NetAmount"
                                maxlength="15" tabindex="14" value="0" onkeypress="return IsNumeric(event)" autocomplete="off" />
                        </div>
                    </div>
                    <div class="modal-footer clearfix">
                        <button id="btnSave" type="button" class="btn btn-info">
                            <i class="fa fa-save"></i>&nbsp;&nbsp;Save
                        </button>
                        <button id="btnUpdate" type="button" class="btn btn-info">
                            <i class="fa fa-save"></i>&nbsp;&nbsp;Update
                        </button>
                        <button type="button" class="btn btn-danger" id="btnClose">
                            <i class="fa fa-close"></i>&nbsp;&nbsp;Close
                        </button>
                    </div>
                </div>
        </section>
    </div>
    <input type="hidden" id="hdnCustomerID" />
    <script src="UserDefined_Js/jNewCustomer.js?v=<%= BaseConfig.GetFileHash("UserDefined_Js/jNewCustomer.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        var _CMActionAdd = '<%=Session["ActionAdd"]%>';
        var _CMActionUpdate = '<%=Session["ActionUpdate"]%>';
        var _CMActionDelete = '<%=Session["ActionDelete"]%>';
        var _CMActionView = '<%=Session["ActionView"]%>';
        var pageUrl = '<%=ResolveUrl("~/frmNewCustomer.aspx") %>';

    </script>
    <script>
        $(document).ready(function () {
            $('#txtKms').on('input', function () {
                var kms = parseInt($(this).val());
                if (kms >= 0 && kms <= 300) {
                    $('#moveTypeHeading').text('Local Move');
                } else if (kms >= 300) {
                    $('#moveTypeHeading').text('Long Move');
                } else {
                    $('#moveTypeHeading').text('Interstate Move');
                }
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $("select[id$='_select']").on("change", function () {
                var selectedValue = $(this).val();
                var selectId = $(this).attr("id");
                var baseId = selectId.replace("_select", "_text");

                if (selectedValue === "Yes") {
                    $("#" + baseId).closest(".col-md-2").show();
                } else {
                    $("#" + baseId).closest(".col-md-2").hide();
                    $("#" + baseId).val(""); // Optional: clear the input when hidden
                }
            });

            // Initially hide all text inputs
            $("input[id$='_text']").closest(".col-md-2").hide();
        });
    </script>

</asp:Content>

