﻿<%@ Page Title="HouseType" Language="C#" MasterPageFile="~/VHMSMasterPage.master" AutoEventWireup="true" CodeFile="frmHouseType.aspx.cs" Inherits="frmHouseType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="VHMSWebHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VHMSWebContent" runat="Server">
    <div class="container-wrapper hidden">
        <section class="content-header">
            <h1>HouseType
            </h1>
            <ol class="breadcrumb">
                <li><a href="frmDefault.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a href="#">Master</a></li>
                <li class="active">HouseType</li>
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
                                            <th>HouseType
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
            <div class="modal fade" id="compose-modal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title"></h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group" id="divName">
                                <label>
                                    HouseType</label><span class="text-danger">*</span>
                                <input type="text" class="form-control" id="txtName" placeholder="Please enter HouseType Name"
                                    maxlength="150" tabindex="1" autocomplete="off"/>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" id="chkStatus" checked="checked" tabindex="3" />Active
                                </label>
                            </div>
                        </div>
                        <div class="modal-footer clearfix">
                            <button type="submit" class="btn btn-info pull-right" id="btnSave" tabindex="4">
                                <i class="fa fa-save"></i>&nbsp;&nbsp;
                                Save</button>
                            <button type="submit" class="btn btn-info pull-right" id="btnUpdate" tabindex="5">
                                <i class="fa fa-edit"></i>&nbsp;&nbsp;
                                Update</button>
                            <button type="button" class="btn btn-danger pull-left" id="btnClose" tabindex="6">
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
            $("#btnUpdate").hide();
            $(".modal-title").html("<i class='fa fa-plus-square'></i>&nbsp;&nbsp;Add HouseType");
            $('#compose-modal').modal({ show: true, backdrop: true });
            $("#txtName").focus();
            return false;
        });

        $("#btnSave,#btnUpdate").click(function () {
            if (this.id == "btnSave")
            { if (ActionAdd != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }
            else if (this.id == "btnUpdate")
            { if (ActionUpdate != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }

            if ($("#txtName").val().trim() == "" || $("#txtName").val().trim() == undefined) {
                $.jGrowl("Please enter HouseType", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divName").addClass('has-error'); $("#txtName").focus(); return false;
            } else { $("#divName").removeClass('has-error'); }

            var Obj = new Object();
            Obj.HouseTypeID = 0;
            Obj.HouseTypeName = $("#txtName").val().trim();
            Obj.IsActive = $("#chkStatus").is(':checked') ? "1" : "0";

            var sMethodName;
            if ($("#hdnID").val() > 0) {
                Obj.HouseTypeID = $("#hdnID").val();
                sMethodName = "UpdateHouseType";
            }
            else { sMethodName = "AddHouseType"; }

            SaveandUpdateHouseType(Obj, sMethodName);
        });

        $("#btnClose").click(function () {
            $('#compose-modal').modal('hide');
            return false;
        });

        function ClearFields() {
            $("#txtName").val("");
            $("#txtCode").val("");
            $("#chkStatus").prop("checked", true);

            $("#divName").removeClass('has-error');
            return false;
        }

        function GetRecord() {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetHouseType",
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
                                        if (obj[index].IsActive == "1")
                                        { TypeStatus = "<span class='label label-success'>Active</span>"; }
                                        else
                                        { TypeStatus = "<span class='label label-warning'>Inactive</span>"; }

                                        var table = "<tr id='" + obj[index].HouseTypeID + "'>";
                                        table += "<td>" + (index + 1) + "</td>";
                                        table += "<td>" + obj[index].HouseTypeName + "</td>";
                                        table += "<td class='hidden-xs'>" + TypeStatus + "</td>";

                                        if (ActionView == "1")
                                        { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].HouseTypeID + " class='View' title='Click here to View'><i class='fa fa-lg fa-clone text-yellow'/></a></td>"; }
                                        else { table += "<td></td>"; }

                                        if (ActionUpdate == "1")
                                        { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].HouseTypeID + " class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'/></a></td>"; }
                                        else
                                        { table += "<td></td>"; }

                                        if (ActionDelete == "1")
                                        { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].HouseTypeID + " class='Delete' title='Click here to Delete'><i class='fa fa-lg fa-trash-o text-red'/></a></td>"; }
                                        else
                                        { table += "<td></td>"; }

                                        table += "</tr>";
                                        $("#tblRecord_tbody").append(table);
                                    }
                                    $(".View").click(function () {
                                        if (ActionView == "1") {
                                            EditRecord($(this).parent().parent()[0].id);
                                            $(".modal-title").html("<i class='fa fa-clone'></i>&nbsp;&nbsp;View HouseType");
                                            $("#btnSave").hide();
                                            $("#btnUpdate").hide();
                                        }
                                        else {
                                            $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                                            return false;
                                        }
                                    });
                                    $(".Edit").click(function () {
                                        if (ActionUpdate == "1")
                                        { EditRecord($(this).parent().parent()[0].id); }
                                        else {
                                            $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                                            return false;
                                        }
                                    });
                                    $(".Delete").click(function () {
                                        if (ActionDelete == "1") {
                                            if (confirm('Are you sure to delete the selected record ?'))
                                            { DeleteRecord($(this).parent().parent()[0].id); }
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
                                  { "sWidth": "7%" },
                                  { "sWidth": "60%" },
                                  { "sWidth": "5%" },
                                  { "sWidth": "5%" },
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

        function SaveandUpdateHouseType(Obj, sMethodName) {
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

                                if (sMethodName == "AddHouseType")
                                { $.jGrowl("Added Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }
                                else if (sMethodName == "UpdateHouseType")
                                { $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }

                                $('#compose-modal').modal('hide');
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                window.location = "frmLogin.aspx";
                            }
                            else if (objResponse.Value == "HouseType_A_01" || objResponse.Value == "HouseType_U_01") {
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
                url: "WebServices/VHMSService.svc/GetHouseTypeByID",
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

                                    $("#hdnID").val(obj.HouseTypeID);
                                    $("#txtName").val(obj.HouseTypeName);                                   
                                    $("#chkStatus").prop("checked", obj.IsActive ? true : false);

                                    $('#compose-modal').modal({ show: true, backdrop: true });
                                    $(".modal-title").html("<i class='fa fa-pencil'></i>&nbsp;&nbsp;Edit HouseType");
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
                url: "WebServices/VHMSService.svc/DeleteHouseType",
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
                            else if (objResponse.Value == "HouseType_R_01" || objResponse.Value == "HouseType_D_01") {
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
