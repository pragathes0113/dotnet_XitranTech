<%@ Page Title="Internal Ledger" Language="C#" MasterPageFile="~/VHMSMasterPage.master" AutoEventWireup="true" CodeFile="frmLedger.aspx.cs" Inherits="frmLedger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="VHMSWebHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VHMSWebContent" runat="Server">
    <div class="container-wrapper hidden">
        <section class="content-header">
            <h1>Internal Ledger
            </h1>
            <ol class="breadcrumb">
                <li><a href="frmDefault.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a href="#">Master</a></li>
                <li class="active">Internal Ledger</li>
            </ol>
            <div class="pull-right">
                <button id="btnAddNew" class="btn btn-info">
                    <i class="fa fa-plus-square"></i>&nbsp;&nbsp;Add New</button>
            </div>
            <br />
            <br />
        </section>
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box box-warning">
                        <div class="box-body">
                            <div class="table-responsive">
                                <table id="tblRecord" class="table table-striped table-bordered bg-info" width="100%">
                                    <thead>
                                        <tr>
                                            <th>SNo
                                            </th>
                                            <th>Internal Ledger
                                            </th>
                                            <th class="hidden-xs">LedgerType
                                            </th>
                                            <th class="hidden-xs">Opening Balance
                                            </th>
                                            <th class="hidden-xs">Type
                                            </th>
                                            <th class="hidden-xs">Status
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
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title"></h4>
                        </div>
                        <div class="modal-body  col-md-12">
                            <div class="form-group col-md-12" id="divName">
                                <label>
                                    Internal Ledger</label><span class="text-danger">*</span>
                                <input type="text" class="form-control" id="txtName" placeholder="Please enter Ledger Name"
                                    maxlength="150" tabindex="1" autocomplete="off" />
                            </div>
                            <div class="form-group col-md-12" id="divLedgerType">
                                <label>
                                    Ledger Type</label><span class="text-danger">*</span>
                                <select id="ddlLedgerType" class="form-control select2" data-placeholder="Select Ledger type" tabindex="2">
                                </select>
                            </div>
                            <div class="form-group col-md-6" id="divOpeningBalance">
                                <label>
                                    Opening Balance</label>
                                <input type="text" class="form-control" id="txtOpeningBalance" placeholder="Please enter Amount"
                                    maxlength="10" tabindex="3" onkeypress="return IsNumeric(event)" value="0.00" autocomplete="off" />
                            </div>
                            <div class="form-group col-md-6" id="divType">
                                <label>
                                    Type</label><span class="text-danger">*</span>
                                <select id="ddlType" class="form-control" tabindex="4">
                                    <option value="Dr">Dr</option>
                                    <option value="Cr">Cr</option>
                                </select>
                            </div>

                            <div class="form-group col-md-12">
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="chkStatus" checked="checked" tabindex="5" />Active
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer clearfix">
                            <button type="submit" class="btn btn-info pull-left" id="btnSave" tabindex="6">
                                <i class="fa fa-save"></i>&nbsp;&nbsp;
                                Save</button>
                            <button type="submit" class="btn btn-info pull-left" id="btnUpdate" tabindex="7">
                                <i class="fa fa-edit"></i>&nbsp;&nbsp;
                                Update</button>
                            <button type="button" class="btn btn-danger pull-right" id="btnClose" tabindex="8">
                                <i class="fa fa-close"></i>&nbsp;&nbsp;
                                Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <input type="hidden" id="hdnID" />

    <script type="text/javascript">

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

            pLoadingSetup(false);
            pLoadingSetup(true);
            GetLedgerTypeList();
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

            $("#hdnID").val("");
            $("#btnSave").show();
            $('#ddlLedgerType').prop('disabled', false);
            $('#ddlType').prop('disabled', false);
            $("#btnUpdate").hide();
            $(".modal-title").html("<i class='fa fa-plus-square'></i>&nbsp;&nbsp;Add Internal Ledger");
            $('#compose-modal').modal({ show: true, backdrop: true });
            $("#txtName").focus();
            return false;
        });

        function GetLedgerTypeList() {
            dProgress(true);
            $("#ddlLedgerType").empty();
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetLedgerType",
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
                                            $("#ddlLedgerType").append('<option value=' + obj[index].LedgerTypeID + ' >' + obj[index].LedgerTypeName + '</option>');
                                    }
                                }
                                dProgress(false);
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $("#ddlLedgerType").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
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
                        $("#ddlLedgerType").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
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

        $("#btnSave,#btnUpdate").click(function () {
            if ($("#txtName").val().trim() == "" || $("#txtName").val().trim() == undefined) {
                $.jGrowl("Please enter Ledger", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divName").addClass('has-error'); $("#txtName").focus(); return false;
            } else { $("#divName").removeClass('has-error'); }

            if ($("#txtOpeningBalance").val().trim() == "" || $("#txtOpeningBalance").val().trim() == undefined) {
                $.jGrowl("Please enter Opening Balance", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divOpeningBalance").addClass('has-error'); $("#txtOpeningBalance").focus(); return false;
            } else { $("#divOpeningBalance").removeClass('has-error'); }

            if ($("#ddlLedgerType").val() == "0" || $("#ddlLedgerType").val() == undefined || $("#ddlLedgerType").val() == null) {
                $.jGrowl("Please select Type", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divLedgerType").addClass('has-error'); $("#ddlLedgerType").focus(); return false;
            } else { $("#divLedgerType").removeClass('has-error'); }

            if (this.id == "btnSave") {
                if (ActionAdd != "1") {
                    $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                    return false;
                }
            }
            else if (this.id == "btnUpdate") {
                if (ActionUpdate != "1") {
                    $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                    return false;
                }
            }

            var Obj = new Object();

            Obj.LedgerID = 0;
            Obj.LedgerName = $("#txtName").val().trim();
            Obj.OpeningBalanceType = $("#ddlType").val();

            Obj.OpeningBalance = $("#txtOpeningBalance").val().trim();
            ObjLedgerType = new Object();
            ObjLedgerType.LedgerTypeID = $("#ddlLedgerType").val();
            Obj.LedgerType = ObjLedgerType;
            Obj.IsDefaultRecord = 1;
            Obj.IsActive = $("#chkStatus").is(':checked') ? "1" : "0";

            var sMethodName;
            if ($("#hdnID").val() > 0) {
                Obj.LedgerID = $("#hdnID").val();
                sMethodName = "UpdateLedger";
            }
            else { sMethodName = "AddLedger"; }

            SaveandUpdateLedger(Obj, sMethodName);

            return false;
        });

        $("#btnClose").click(function () {
            $('#compose-modal').modal('hide');
            return false;
        });

        function ClearFields() {
            $("#txtName").val("");
            $("#chkStatus").prop("checked", true);
            $("#ddlLedgerType").val(null).change();
            $("#ddlType").val("Dr").change();
            $("#txtOpeningBalance").val("0.00");

            $("#divName").removeClass('has-error');
            return false;
        }

        function GetRecord() {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetLedger",
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

                                        var table = "<tr id='" + obj[index].LedgerID + "'>";
                                        table += "<td>" + (index + 1) + "</td>";
                                        table += "<td>" + obj[index].LedgerName + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].LedgerType.LedgerTypeName + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].OpeningBalance + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].OpeningBalanceType + "</td>";
                                        table += "<td class='hidden-xs'>" + TypeStatus + "</td>";

                                        if (ActionView == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].LedgerID + " class='View' title='Click here to View'><i class='fa fa-lg fa-clone text-yellow'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        if (ActionUpdate == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].LedgerID + " class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        if (ActionDelete == "1" && obj[index].IsDefaultRecord != 1) { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].LedgerID + " class='Delete' title='Click here to Delete'><i class='fa fa-lg fa-trash-o text-red'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        table += "</tr>";
                                        $("#tblRecord_tbody").append(table);
                                    }
                                    $(".View").click(function () {
                                        if (ActionView == "1") {
                                            EditRecord($(this).parent().parent()[0].id);
                                            $(".modal-title").html("<i class='fa fa-clone'></i>&nbsp;&nbsp;View Ledger");
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
                                    { "sWidth": "5%" },
                                    { "sWidth": "40%" },
                                    { "sWidth": "15%" },
                                    { "sWidth": "10%" },
                                    { "sWidth": "10%" },
                                    { "sWidth": "10%" },
                                    { "sWidth": "10%" },
                                    { "sWidth": "5%" },
                                    { "sWidth": "5%" }
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

        function SaveandUpdateLedger(Obj, sMethodName) {
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

                                if (sMethodName == "AddLedger") { $.jGrowl("Added Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }
                                else if (sMethodName == "UpdateLedger") { $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }

                                $('#compose-modal').modal('hide');
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                window.location = "frmLogin.aspx";
                            }
                            else if (objResponse.Value == "Ledger_A_01" || objResponse.Value == "Ledger_U_01") {
                                $.jGrowl(_CMAlreadyExits, { sticky: false, theme: 'danger', life: jGrowlLife });
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
                url: "WebServices/VHMSService.svc/GetLedgerByID",
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

                                    $("#hdnID").val(obj.LedgerID);
                                    $("#txtName").val(obj.LedgerName);
                                    $("#ddlType").val(obj.OpeningBalanceType);
                                    $("#txtOpeningBalance").val(obj.OpeningBalance);
                                    $("#ddlLedgerType").val(obj.LedgerType.LedgerTypeID).change();
                                    $("#chkStatus").prop("checked", obj.IsActive ? true : false);
                                    if (obj.IsDefaultRecord == 1)
                                        $('#ddlLedgerType').prop('disabled', 'disabled');
                                    else
                                        $('#ddlLedgerType').prop('disabled', false);

                                    if (obj.IsDefaultRecord == 1)
                                        $('#ddlType').prop('disabled', 'disabled');
                                    else
                                        $('#ddlType').prop('disabled', false);

                                    $('#compose-modal').modal({ show: true, backdrop: true });
                                    $(".modal-title").html("<i class='fa fa-pencil'></i>&nbsp;&nbsp;Edit Internal Ledger");
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
                url: "WebServices/VHMSService.svc/DeleteLedger",
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
                            else if (objResponse.Value == "Ledger_R_01" || objResponse.Value == "Ledger_D_01") {
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
    </script>
</asp:Content>

