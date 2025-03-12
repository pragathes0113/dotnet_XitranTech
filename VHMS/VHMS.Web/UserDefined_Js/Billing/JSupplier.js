$(function () {
    ActionAdd = _CMActionAdd;
    ActionUpdate = _CMActionUpdate;
    ActionDelete = _CMActionDelete;
    ActionView = _CMActionView;

    var ClickCount = 0;

    pLoadingSetup(false);
    $("#divRecords").show();
    $("#tab-modal").hide();
    $("#btnAddNew").show();
    $("#btnList").hide();
    txtDays
    //General Tab
    $("#btnSave").show();
    $("#btnUpdate").hide();

    GetSupplierList("ddlCategoryName");
    GetStateList();
    GetRecord();

    var _Tfunctionality;
    if ($.cookie("Supplier") != undefined) {
        _Tfunctionality = $.cookie("Supplier");

        if (_Tfunctionality == "Add New Supplier") {
            pLoadingSetup(true);
            $("#btnAddNew").click();
        }
        $.cookie("Supplier", null);
    }

    pLoadingSetup(true);


});

$("#txtPhoneNo1").change(function () {
    $("#txtWhatsAppNo").val("");
    if ($("#txtPhoneNo1").val().length == 10)
        $("#txtWhatsAppNo").val($("#txtPhoneNo1").val());
});


function GetSupplierList(ddlname) {
    var sControlName = "#" + ddlname;
    dProgress(true);
    $(sControlName).empty();
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/GetSupplier",
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
                                    $(sControlName).append("<option value='" + obj[index].SupplierID + "'>" + obj[index].SupplierName + "</option>");
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
$("#ddlCategoryName").change(function () {
    GetRecord();
});

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
$("#btnAddNew").click(function () {
    $("#tab-modal").show();

    $('input,select').keydown(function (event) { //event==Keyevent
        if (event.which == 13) {
            $("#btnSave").click();
            event.preventDefault();

        }
    });

    $("#hdnSupplierID").val("");
    $("#btnSave").show();
    $("#btnUpdate").hide();
    $(".modal-title").html("<i class='fa fa-plus-square'></i>&nbsp;&nbsp;Add Supplier");
    $('#compose-modal').modal({ show: true, backdrop: true });
    ClearSupplierTab();
    ClickCount = 0;
    return false;
});
$("#btnList,#btnClose").click(function () {
    $("#divRecords").show();
    $("#tab-modal").hide();
    $("#btnList").hide();
    $("#btnAddNew").show();
    $("#aGeneral").click();
    $.cookie("Supplier", null);
    $('#compose-modal').modal('hide');
    GetRecord();
    return false;
});

function GetRecord() {
    dProgress(true);
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/GetAllSupplier",
        data: JSON.stringify({ iSupplierID: $("#ddlCategoryName").val() }),
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

                                var table = "<tr id='" + obj[index].SupplierID + "'>";
                                table += "<td>" + (index + 1) + "</td>";
                                table += "<td>" + obj[index].SupplierName + "</td>";
                                table += "<td>" + obj[index].PhoneNo1.toUpperCase() + "</td>";
                                table += "<td>" + obj[index].SupplierAddress.toUpperCase() + "</td>";
                                table += "<td class='hidden-xs'>" + obj[index].Email + "</td>";
                                table += "<td class='hidden-xs'>" + TypeStatus + "</td>";
                                if (ActionView == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SupplierID + " class='View' title='Click here to View'><i class='fa fa-lg fa-clone text-yellow'/></a></td>"; }
                                else { table += "<td></td>"; }
                                if (ActionUpdate == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SupplierID + " class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'/></a></td>"; }
                                else { table += "<td></td>"; }

                                if (ActionDelete == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SupplierID + " class='Delete' title='Click here to Delete'><i class='fa fa-lg fa-trash-o text-red'/></a></td>"; }
                                else { table += "<td></td>"; }
                                //  table += "<td style='text-align:center; color: darkviolet;'><a href='#' id=" + obj[index].SalesEntryID + " class='Address' title='Click here to Address Print'><i class='fa fa-address-card' style='color: darkviolet;'></i></a></td>";
                               // table += "<td style='text-align:center; color: darkviolet;'><a href='#' id=hid" + obj[index].SupplierID + " class='Address' style='color:black;' Accountno='" + obj[index].SupplierID + "' title='click here to Customer Ledger'><i class='fa fa-address-card' style='color: darkviolet;'></i></a></td>";


                                table += "</tr>";
                                $("#tblRecord_tbody").append(table);
                            }
                            $(".View").click(function () {
                                if (ActionView == "1") {
                                    EditRecord($(this).parent().parent()[0].id);
                                    $(".modal-title").html("<i class='fa fa-clone'></i>&nbsp;&nbsp;View Supplier");
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
                                    $.jGrowl("Access Denied", { sticky: false, theme: 'danger', life: jGrowlLife });
                                    return false;
                                }
                            });
                            $(".Address").click(function () {
                                SetSessionValue("SalesID", $(this).attr('Accountno'));
                                SetSessionValue("Table", "Supplier");
                                var myWindow = window.open("frmAddressLabel.aspx", "MsgWindow");
                            });
                            $(".Delete").click(function () {
                                if (ActionDelete == "1") {
                                    if (confirm('Are you sure to delete the selected record ?'))
                                    { DeleteRecord($(this).parent().parent()[0].id); }
                                }
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
                            { "sWidth": "5%" },
                            { "sWidth": "30%" },
                            { "sWidth": "10%" },
                            { "sWidth": "50%" },
                            { "sWidth": "8%" },
                            { "sWidth": "2%" },
                            { "sWidth": "2%" },
                            { "sWidth": "2%" },
                            { "sWidth": "2%" },
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
function ClearSupplierTab() {
    $("#txtName").val("");
    $("#txtCode").val("");
    $("#txtAddress").val("");
    $("#ddlState").val(null).change();
    $("#txtCity").val("");
    $("#chkRateUpdate").prop("checked", false);
    $("#txtPincode").val("");
    $("#txtPhoneNo1").val("");
    $("#txtWhatsAppNo").val("");
    $("#txtPhoneNo2").val("");
    $("#txtLandline").val("");
    $("#txtFax").val("");
    $("#txtEmail").val("");
    $("#txtWebSite").val("");
    $("#txtDays").val("0");
    $("#chkStatus").prop("checked", true);
    $("#txtTaluk").val("");
    $("#txtArea").val("");
    $("#txtBranchName").val("");
    $("#txtAccountNo").val("");
    $("#txtBankName").val("");
    $("#txtIFSCCode").val("");
    $("#txtAccountHolderName").val("");
    $("#divName").removeClass('has-error');
    $("#divCode").removeClass('has-error');
    $("#divState").removeClass('has-error');
    $("#divPincode").removeClass('has-error');
    $("#divPhoneNo1").removeClass('has-error');
}
$("#btnLink").click(function () {
    ClickCount = 1;
    var myWindow = window.open("https://services.gst.gov.in/services/searchtp", "MsgWindow");

});

$("#btnSave,#btnUpdate").click(function () {
    var ID = $("#txtFax").val().trim();
    //if ($("#txtFax").val().trim() != "") {
    //    if (ClickCount < 1) {
    //        $.jGrowl("Please click 'Verify GST No' link to verify supplier GST No", { sticky: false, theme: 'warning', life: jGrowlLife });
    //        return;
    //    }
    //}

    if (this.id == "btnSave")
    { if (ActionAdd != "1") { $.jGrowl("Access Denied", { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }
    else
    { if (ActionUpdate != "1") { $.Growl("Access Denied", { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }

    if ($("#txtName").val().trim() == "" || $("#txtName").val().trim() == undefined) {
        $.jGrowl("Please enter Supplier Name", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divName").addClass('has-error'); $("#txtName").focus(); return false;
    } else { $("#divName").removeClass('has-error'); }

    //if ($("#txtCode").val().trim() == "" || $("#txtCode").val().trim() == undefined) {
    //    $.jGrowl("Please enter Supplier Code", { sticky: false, theme: 'warning', life: jGrowlLife });
    //    $("#divCode").addClass('has-error'); $("#txtCode").focus(); return false;
    //} else { $("#divCode").removeClass('has-error'); }

    if ($("#ddlState").val() == "0" || $("#ddlState").val() == undefined) {
        $.jGrowl("Please Select State", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divState").addClass('has-error'); $("#ddlState").focus(); return false;
    } else { $("#divState").removeClass('has-error'); }

    //if ($("#txtCity").val().trim() == "" || $("#txtCity").val().trim() == undefined) {
    //    $.jGrowl("Please enter City", { sticky: false, theme: 'warning', life: jGrowlLife });
    //    $("#divCity").addClass('has-error'); $("#txtCity").focus(); return false;
    //} else { $("#divCity").removeClass('has-error'); }

    //if ($("#txtArea").val().trim() == "" || $("#txtArea").val().trim() == undefined) {
    //    $.jGrowl("Please enter Area", { sticky: false, theme: 'warning', life: jGrowlLife });
    //    $("#divTaluk").addClass('has-error'); $("#txtArea").focus(); return false;
    //} else { $("#divTaluk").removeClass('has-error'); }

    //if ($("#txtTaluk").val().trim() == "" || $("#txtTaluk").val().trim() == undefined) {
    //    $.jGrowl("Please enter Taluk", { sticky: false, theme: 'warning', life: jGrowlLife });
    //    $("#divArea").addClass('has-error'); $("#txtTaluk").focus(); return false;
    //} else { $("#divArea").removeClass('has-error'); }

    //if ($("#txtPincode").val().trim() == "" || $("#txtPincode").val().trim() == undefined) {
    //    $.jGrowl("Please enter Pincode", { sticky: false, theme: 'warning', life: jGrowlLife });
    //    $("#divPincode").addClass('has-error'); $("#txtPincode").focus(); return false;
    //} else { $("#divPincode").removeClass('has-error'); }

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
    Obj.SupplierName = $("#txtName").val().toUpperCase();
    Obj.SupplierCode = $("#txtCode").val().toUpperCase();
    Obj.SupplierAddress = $("#txtAddress").val().trim();
    Obj.City = $("#txtCity").val();
    Obj.Pincode = $("#txtPincode").val();
    Obj.PhoneNo1 = $("#txtPhoneNo1").val().trim();
    Obj.WhatsAppNo = $("#txtWhatsAppNo").val().trim();
    Obj.PhoneNo2 = $("#txtPhoneNo2").val().trim();
    Obj.LandLine = $("#txtLandline").val().trim();
    Obj.Fax = $("#txtFax").val().trim().toUpperCase();
    Obj.Email = $("#txtEmail").val().trim();
    Obj.WebSite = $("#txtWebSite").val().trim();
    Obj.Days = 0;
    Obj.Area = $("#txtArea").val();
    Obj.Taluk = $("#txtTaluk").val();
    Obj.IsActive = $("#chkStatus").is(':checked') ? "1" : "0";
    Obj.IsRateUpdated = $("#chkRateUpdate").is(':checked') ? "1" : "0";
    Obj.LinkClick = ClickCount;
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

    console.log(Obj);
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
                        ClearSupplierTab();
                        GetSupplierList("ddlCategoryName");
                        //GetRecord();
                        if (sMethodName == "AddSupplier") {
                            $.jGrowl("Saved Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
                            $("#hdnSupplierID").val(objResponse.Value);
                           
                        }
                        else if (sMethodName == "UpdateSupplier")
                        { $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }
                        $('#compose-modal').modal('hide');
                        //EditRecord($("#hdnSupplierID").val());
                        $("#btnList").click();
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

$("#txtFax").change(function () {
    ClickCount = 0;
});
function EditRecord(id) {
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
                            $("#btnSave").hide();
                            $("#btnUpdate").show();
                                
                            ClearSupplierTab();

                            $('input,select').keydown(function (event) { //event==Keyevent
                                if (event.which == 13) {
                                    $("#btnUpdate").click();
                                    event.preventDefault();

                                }
                            });

                            $("#hdnSupplierID").val(obj.SupplierID);
                            $("#txtName").val(obj.SupplierName);
                            $("#txtCode").val(obj.SupplierCode);
                            $("#txtAddress").val(obj.SupplierAddress);
                            $("#txtCity").val(obj.City);
                            $("#txtPincode").val(obj.Pincode);
                            $("#txtPhoneNo1").val(obj.PhoneNo1);
                            $("#txtWhatsAppNo").val(obj.WhatsAppNo);
                            $("#txtPhoneNo2").val(obj.PhoneNo2);
                            $("#txtLandline").val(obj.LandLine);
                            $("#txtFax").val(obj.Fax);
                            $("#txtEmail").val(obj.Email);
                            $("#txtWebSite").val(obj.WebSite);
                            $("#txtDays").val(obj.Days);
                            $("#txtArea").val(obj.Area);
                            $("#txtTaluk").val(obj.Taluk);
                            ClickCount = obj.LinkClick;
                            $("#ddlState").val(obj.State.StateID).change();
                            $("#txtBranchName").val(obj.BranchName);
                            $("#txtAccountNo").val(obj.AccountNo);
                            $("#txtBankName").val(obj.BankName);
                            $("#txtIFSCCode").val(obj.IFSCCode);
                            $("#txtAccountHolderName").val(obj.AccountHolderName);
                            $("#chkStatus").prop("checked", obj.IsActive ? true : false);

                            $('#compose-modal').modal({ show: true, backdrop: true });
                            $(".modal-title").html("<i class='fa fa-pencil'></i>&nbsp;&nbsp;Edit Supplier");
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
        url: "WebServices/VHMSService.svc/DeleteSupplier",
        data: JSON.stringify({ ID: id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.d != "") {
                var objResponse = jQuery.parseJSON(data.d);
                if (objResponse.Status == "Success") {
                    if (objResponse.Value > 0) {
                        ClearSupplierTab();
                        GetRecord();
                        $.jGrowl("Deleted Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
                    }
                }
                else if (objResponse.Status == "Error") {
                    if (objResponse.Value == "0") {
                        window.location = "frmLogin.aspx";
                    }
                    else if (objResponse.Value == "Supplier_R_01" || objResponse.Value == "Supplier_D_01") {
                        $.jGrowl("Since this record is referred somewhere else you cannot delete it", { sticky: false, theme: 'danger', life: jGrowlLife });
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