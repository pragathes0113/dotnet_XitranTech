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

        .question-block {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 1rem;
        }

            .question-block label {
                width: 90%;
                margin-bottom: 0;
            }

        .question-options {
            width: 10%;
            white-space: nowrap;
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
                                                <th>Date</th>
                                                <th>Customer</th>
                                                <th>Mobile Number</th>
                                                <th>Packing Date</th>
                                                <th>Reaching Date</th>
                                                <th>KMS</th>
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
                                        Search Sales records</label><span class="text-danger">*</span>
                                    <input type="text" class="form-control" id="txtSearchName" placeholder="Please enter Details"
                                        maxlength="150" />
                                </div>

                                <div class="table-responsive">
                                    <table id="tblSearchResult" class="table table-striped table-bordered bg-info" width="100%">
                                        <thead>
                                            <tr>
                                                <th>S.No</th>
                                                <th>Date</th>
                                                <th>Customer</th>
                                                <th>Mobile Number</th>
                                                <th>Packing Date</th>
                                                <th>Reaching Date</th>
                                                <th>KMS</th>
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
                    <div class="box-title">Customer Information</div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="form-group col-md-2" id="divEntryDate">
                            <label>Entry Date</label><span class="text-danger">*</span>
                            <div class="input-group date form_date" data-date-format="dd/MM/yyyy HH:ii P" data-link-format="dd/MM/yyyy">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar glyphicon glyphicon-calendar"></i>
                                </div>
                                <input type="text" class="form-control pull-right" tabindex="1" id="txtEntryDate" readonly />
                            </div>
                        </div>

                        <div class="form-group col-md-4" id="divNewCustomer">
                            <label>New Customer</label>
                            <input type="text" class="form-control" id="txtNewCustomer" placeholder="MobileNo" maxlength="10" tabindex="2" />
                        </div>

                        <div class="form-group col-md-2" id="divMobileNo">
                            <label>Mobile No</label>
                            <input type="text" class="form-control" id="txtMobileNo" placeholder="MobileNo" maxlength="10" tabindex="3" />
                        </div>

                        <div class="form-group col-md-2" id="divPackingDate">
                            <label>Packing Date</label><span class="text-danger">*</span>
                            <div class="input-group date form_date" data-date-format="dd/MM/yyyy HH:ii P" data-link-format="dd/MM/yyyy">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar glyphicon glyphicon-calendar"></i>
                                </div>
                                <input type="text" class="form-control pull-right" tabindex="4" id="txtPackingDate" readonly />
                            </div>
                        </div>

                        <div class="form-group col-md-2" id="divShiftingDate">
                            <label>Shifting Date</label><span class="text-danger">*</span>
                            <div class="input-group date form_date" data-date-format="dd/MM/yyyy HH:ii P" data-link-format="dd/MM/yyyy">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar glyphicon glyphicon-calendar"></i>
                                </div>
                                <input type="text" class="form-control pull-right" tabindex="5" id="txtShiftingDate" readonly />
                            </div>
                        </div>

                        <div class="form-group col-md-6 mb-3" id="divCurrentAddress">
                            <label>Current Address <span class="text-danger">*</span></label>
                            <textarea id="txtCurrentAddress" class="form-control" maxlength="250" tabindex="6" rows="3"></textarea>
                        </div>

                        <div class="form-group col-md-6 mb-3" id="divAddress">
                            <label>Shifting Address <span class="text-danger">*</span></label>
                            <textarea id="txtShiftingAddress" class="form-control" maxlength="250" tabindex="7" rows="3"></textarea>
                        </div>

                        <div class="form-group col-md-2" id="divKms">
                            <label>Kms</label>
                            <input type="text" class="form-control" id="txtKms" placeholder="Kms" maxlength="10" tabindex="8" />
                        </div>

                        <div class="form-group col-md-3" id="divHouseType">
                            <label>House Type</label><span class="text-danger">*</span>
                            <select id="ddlHouseType" class="form-control select2" data-placeholder="Select HouseType" tabindex="9"></select>
                        </div>
                    </div>
                    <div class="col-md-12">
                    </div>

                    <div class="box box-primary box-solid">
                        <div class="box-header">
                          <h4 class="fw-bold mb-0" style="color: white;"> Move Type: <span id="moveTypeHeading"></span>  </h4>
                        </div>
                        <div class="box-body">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-7 question-block">
                                        <label>1. Are there any items that should be carried by more than two persons?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q2" value="Yes">
                                            Yes
            <input type="radio" name="q2" value="No" class="ms-3">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>2. Will there be any staircases involved during this move?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q3" value="Yes">
                                            Yes
            <input type="radio" name="q3" value="No" class="ms-3">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>(a). Do you have a service elevator available?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q3a" value="Yes">
                                            Yes
            <input type="radio" name="q3a" value="No" class="ms-3">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>3. Is there proper parking near origin and destination (within 40 yards)?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q4" value="Yes" onclick="$('#q4aRateDiv').hide();">
                                            Yes
            <input type="radio" name="q4" value="No" class="ms-3" onclick="$('#q4aRateDiv').show();">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 mb-3" id="q4aRateDiv" style="display: none;">
                                        <label>(a). Additional charge for long walks</label>
                                        <input type="text" class="form-control" id="q4aRate" placeholder="Enter extra charge">
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>4. Would you like us to help with packing?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q5" value="Yes" onclick="$('#q5bNote').hide();">
                                            Yes
            <input type="radio" name="q5" value="No" class="ms-3" onclick="$('#q5bNote').show();">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 mb-3" id="q5bNote" style="display: none;">
                                        <small class="text-muted">We can provide packing materials if needed.</small>
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>5. Are there any fragile items that require special handling?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q6" value="Yes">
                                            Yes
            <input type="radio" name="q6" value="No" class="ms-3">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>6. Are there any flammable, industrial, or unusual items in this move?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q7" value="Yes">
                                            Yes
            <input type="radio" name="q7" value="No" class="ms-3">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>7. Could you please share your inventory list with us?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q8" value="Yes">
                                            Yes
            <input type="radio" name="q8" value="No" class="ms-3">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>8. Do you have any heavy/bulky items like pianos, appliances, or safes?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q9" value="Yes" onclick="$('#q9aRateDiv').show();">
                                            Yes
            <input type="radio" name="q9" value="No" class="ms-3" onclick="$('#q9aRateDiv').hide();">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 mb-3" id="q9aRateDiv" style="display: none;">
                                        <label>(a). Additional charge for handling pianos</label>
                                        <input type="text" class="form-control" id="q9aRate" placeholder="Enter charge for piano">
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>9. Is there any vehicle to be moved (car/quad bike)?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q10" value="Yes">
                                            Yes
            <input type="radio" name="q10" value="No" class="ms-3">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>10. Would you like help with arranging a tow van or driver?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q11" value="Yes">
                                            Yes
            <input type="radio" name="q11" value="No" class="ms-3">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>11. Does this move involve any junk removal?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q12" value="Yes">
                                            Yes
            <input type="radio" name="q12" value="No" class="ms-3">
                                            No
                                        </div>
                                    </div>

                                    <div class="col-md-7 question-block">
                                        <label>12. Do you prefer an overnight stop for this transit?</label>
                                        <div class="question-options">
                                            <input type="radio" name="q13" value="Yes">
                                            Yes
            <input type="radio" name="q13" value="No" class="ms-3">
                                            No
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer clearfix">
                            <button id="btnSave" type="button" class="btn btn-info margin pull-left" tabindex="27">
                                <i class="fa fa-save"></i>&nbsp;&nbsp;Save
                            </button>
                            <button id="btnUpdate" type="button" class="btn btn-info margin pull-left" tabindex="28">
                                <i class="fa fa-save"></i>&nbsp;&nbsp;Update
                            </button>
                            <button type="button" class="btn btn-danger margin pull-right" id="btnClose" tabindex="29">
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


    <%--<script>
        function updateMoveType() {
            var kms = parseInt(document.getElementById("txtKms").value);
            var heading = document.getElementById("moveTypeHeading");

            if (!isNaN(kms)) {
                if (kms < 300) {
                    heading.innerText = "Local Move";
                } else if (kms > 300) {
                    heading.innerText = "Long Move";
                } else {
                    heading.innerText = "Interstate Move";
                }
            } else {
                heading.innerText = "";
            }
        }

        // Bind on change or keyup
        document.addEventListener("DOMContentLoaded", function () {
            document.getElementById("txtKms").addEventListener("input", updateMoveType);
        });
    </script>--%>

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


</asp:Content>

