var gMagazineData = [];
var gOPBillingList = [];
var RecordAvailable = 0;

$(function () {
    pLoadingSetup(false);
    ActionAdd = _CMActionAdd;
    ActionUpdate = _CMActionUpdate;
    ActionDelete = _CMActionDelete;
    ActionView = _CMActionView;
    $("#btnAddNew").show();
    $("#btnList").hide();
    $("#SearchResult").hide();
    $("#divTab").show();
    $("#divOPBilling").hide();
    $("#txtPackingDate,#txtShiftingDate").attr("data-link-format", "dd/MM/yyyy");
    $("#txtPackingDate,#txtShiftingDate").datetimepicker({
        pickTime: false,
        useCurrent: true,
        format: 'DD/MM/YYYY'
    });
    GetHouseType();
    GetRecord();
    pLoadingSetup(true);
});
function GetHouseType() {
    $("#ddlHouseType").empty();
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/GetHouseType",
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
                            $("#ddlHouseType").append('<option value="' + '0' + '">' + '--All--' + '</option>');
                            for (var index = 0; index < obj.length; index++) {
                                $("#ddlHouseType").append('<option value=' + obj[index].HouseTypeID + ' >' + obj[index].HouseTypeName + '</option>');
                            }
                        }
                    }
                    else if (objResponse.Value == "NoRecord") {
                        $("#ddlHouseType").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
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
                $("#ddlHouseType").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
            }
        },
        error: function (e) {
            $.jGrowl("Error  Occured", { sticky: false, theme: 'danger', life: jGrowlLife });
        }
    });
    return false;
}


$("#btnAddNew").click(function () {
    $("#secHeader").addClass('hidden');
    $("#divTab").hide();
    $("#divOPBilling").show();
    $("#btnSave").show();
    $("#btnUpdate").hide();
    ClearFields();
    return false;
});
function ClearFields() {
    $("#txtNewCustomer").val("");
    $("#txtMobileNo").val("");
    $("#txtAltMobileNo").val("");
    $("#ddlHouseType").val(null).change();
    $("#txtKms").val("0");
    $("#txtCurrentAddress").val("");
    $("#txtShiftingAddress").val("");
    $("#txtPackingDate").val("");
    $("#txtShiftingDate").val("");
    $("#ddlCallStatus").val("");
    $("#txtGSTAmount").val("0");
    $("#txtNetAmount").val("0");
    $("#q1_select").val("").change();
    $("#q2_select").val("").change();
    $("#q2a_select").val("").change();
    $("#q3_select").val("").change();
    $("#q3a_select").val("").change();
    $("#q4_select").val("").change();
    $("#q4a_select").val("").change();
    $("#q4b_select").val("").change();
    $("#q5_select").val("").change();
    $("#q6_select").val("").change();
    $("#q7_select").val("").change();
    $("#q7a_select").val("").change();
    $("#q7b_select").val("").change();
    $("#q8_select").val("").change();
    $("#q8a_select").val("").change();
    $("#q9_select").val("").change();
    $("#q10_select").val("").change();
    $("#q11_select").val("").change();
    $("#q12_select").val("").change();
    $("#ddlWeek").val("").change();
    $("#txtNote").val("");
    $("#q1_text").val("0");
    $("#q2_text").val("0");
    $("#q2a_text").val("0");
    $("#q3_text").val("0");
    $("#q3a_text").val("0");
    $("#q4_text").val("0");
    $("#q4a_text").val("0");
    $("#q4b_text").val("0");
    $("#q5_text").val("0");
    $("#q6_text").val("0");
    $("#q7_text").val("0");
    $("#q7a_text").val("0");
    $("#q7b_text").val("0");
    $("#q8_text").val("0");
    $("#q8a_text").val("0");
    $("#q9_text").val("0");
    $("#q10_text").val("0");
    $("#q11_text").val("0");
    $("#q12_text").val("0");
    $("#txtGST").val("10");
    return false;
}

$("#btnList").click(function () {
    $("#btnAddNew").show();
    $("#btnList").hide();
    $("#divTab").show();
    $("#divOPBilling").hide();
    return false;
});

$("#btnClose").click(function () {
    $("#secHeader").removeClass('hidden');
    $("#hdnCustomerID").val("0");
    ClearFields();
    $("#btnList").click();
    return false;
});


$("#btnSave,#btnUpdate").click(function () {
    if (this.id == "btnSave") { if (ActionAdd != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }
    else if (this.id == "btnUpdate") { if (ActionUpdate != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }

    if ($("#txtNewCustomer").val().trim() == "" || $("#txtNewCustomer").val().trim() == undefined) {
        $.jGrowl("Please enter NewCustomer", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divNewCustomer").addClass('has-error'); $("#txtNewCustomer").focus(); return false;
    } else { $("#divNewCustomer").removeClass('has-error'); }

    if ($("#txtMobileNo").val().trim() == "" || $("#txtMobileNo").val().trim() == undefined) {
        $.jGrowl("Please enter Mobile", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divMobileNo").addClass('has-error'); $("#txtMobileNo").focus(); return false;
    } else { $("#divMobileNo").removeClass('has-error'); }

    if ($("#txtPackingDate").val().trim() == "" || $("#txtPackingDate").val().trim() == undefined) {
        $.jGrowl("Please select Packing Date", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divPackingDate").addClass('has-error'); $("#txtPackingDate").focus(); return false;
    }
    else { $("#divPackingDate").removeClass('has-error'); }

    if ($("#txtShiftingDate").val().trim() == "" || $("#txtShiftingDate").val().trim() == undefined) {
        $.jGrowl("Please select Shifting Date", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divShiftingDate").addClass('has-error'); $("#txtShiftingDate").focus(); return false;
    }
    else { $("#divShiftingDate").removeClass('has-error'); }

    if ($("#ddlHouseType").val() == "0" || $("#ddlHouseType").val() == undefined || $("#ddlHouseType").val() == null) {
        $.jGrowl("Please select HouseType", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divHouseType").addClass('has-error'); $("#ddlHouseType").focus(); return false;
    }
    else { $("#divHouseType").removeClass('has-error'); }

    if ($("#txtKms").val().trim() == "" || $("#txtKms").val().trim() == undefined) {
        $.jGrowl("Please enter KMS", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divKms").addClass('has-error'); $("#txtKms").focus(); return false;
    } else { $("#divKms").removeClass('has-error'); }

    if ($("#txtCurrentAddress").val().trim() == "" || $("#txtCurrentAddress").val().trim() == undefined) {
        $.jGrowl("Please enter CurrentAddress", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divCurrentAddress").addClass('has-error'); $("#txtCurrentAddress").focus(); return false;
    } else { $("#divCurrentAddress").removeClass('has-error'); }


    if ($("#txtShiftingAddress").val().trim() == "" || $("#txtShiftingAddress").val().trim() == undefined) {
        $.jGrowl("Please enter ShiftingAddress", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divShiftingAddress").addClass('has-error'); $("#txtShiftingAddress").focus(); return false;
    } else { $("#divShiftingAddress").removeClass('has-error'); }

    if ($("#ddlCallStatus").val() == "" || $("#ddlCallStatus").val() == undefined) {
        $.jGrowl("Please Select Call Status", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divCallStatus").addClass('has-error'); $("#ddlCallStatus").focus(); return false;
    } else { $("#divCallStatus").removeClass('has-error'); }

    if ($("#ddlWeek").val() == "" || $("#ddlWeek").val() == undefined) {
        $.jGrowl("Please Select Week", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divWeek").addClass('has-error'); $("#ddlWeek").focus(); return false;
    } else { $("#divWeek").removeClass('has-error'); }


    let selectFields = [
        "#q1_select", "#q2_select", "#q2a_select", "#q3_select", "#q3a_select",
        "#q4_select", "#q4a_select", "#q4b_select", "#q5_select", "#q6_select",
        "#q7_select", "#q7a_select", "#q7b_select", "#q8_select", "#q8a_select",
        "#q9_select", "#q10_select", "#q11_select", "#q12_select"
    ];

    for (let i = 0; i < selectFields.length; i++) {
        let selectId = selectFields[i];
        if ($(selectId).val() == "" || $(selectId).val() == undefined) {
            $.jGrowl("Please select an option", { sticky: false, theme: 'warning', life: jGrowlLife });
            $(selectId).addClass('has-error').focus();
            return false;
        } else {
            $(selectId).removeClass('has-error');
        }
    }
    var Obj = new Object();
    Obj.CustomerID = 0;
    Obj.CustomerName = $("#txtNewCustomer").val().trim();
    Obj.MobileNo = $("#txtMobileNo").val().trim();
    Obj.AltMobileNo = $("#txtAltMobileNo").val().trim();
    Obj.CurrentAddress = $("#txtCurrentAddress").val().trim();
    Obj.ShiftingAddress = $("#txtShiftingAddress").val().trim();
    Obj.sPackingDate = $("#txtPackingDate").val().trim();
    Obj.sReachingDate = $("#txtShiftingDate").val().trim();
    Obj.TypeofMove = $("#moveTypeHeading").val().trim();
    Obj.Kms = $("#txtKms").val().trim();
    var ObjHouseType = new Object();
    ObjHouseType.HouseTypeID = $("#ddlHouseType").val();
    Obj.HouseType = ObjHouseType;
    Obj.RequiresMoreThanTwoPersons = $("#q1_select").val();
    Obj.RequiresMoreThanTwoPersonsRate = $("#q1_text").val() || "0";

    Obj.HasStaircase = $("#q2_select").val();
    Obj.HasStaircaseRate = $("#q2_text").val() || "0";

    Obj.HasServiceElevator = $("#q2a_select").val();
    Obj.HasServiceElevatorRate = $("#q2a_text").val() || "0";

    Obj.HasProperParking = $("#q3_select").val();
    Obj.HasProperParkingRate = $("#q3_text").val() || "0";

    Obj.AdditionalChargeForLongWalks = $("#q3a_select").val();
    Obj.AdditionalChargeForLongWalksRate = $("#q3a_text").val() || "0";

    Obj.WantsPackingHelp = $("#q4_select").val();
    Obj.WantsPackingHelpRate = $("#q4_text").val() || "0";

    Obj.PackingHandledByTeam = $("#q4a_select").val();
    Obj.PackingHandledByTeamRate = $("#q4a_text").val() || "0";

    Obj.NeedsPackingMaterials = $("#q4b_select").val();
    Obj.NeedsPackingMaterialsRate = $("#q4b_text").val() || "0";

    Obj.HasFragileItems = $("#q5_select").val();
    Obj.HasFragileItemsRate = $("#q5_text").val() || "0";

    Obj.HasHazardousItems = $("#q6_select").val();
    Obj.HasHazardousItemsRate = $("#q6_text").val() || "0";

    Obj.HasInventoryList = $("#q7_select").val();
    Obj.HasInventoryListRate = $("#q7_text").val() || "0";

    Obj.InventoryListNote = $("#q7a_select").val();
    Obj.InventoryListNoteRate = $("#q7a_text").val() || "0";

    Obj.HasPiano = $("#q7b_select").val();
    Obj.HasPianoRate = $("#q7b_text").val() || "0";

    Obj.AdditionalChargeForPiano = $("#q8_select").val();
    Obj.AdditionalChargeForPianoRate = $("#q8_text").val() || "0";

    Obj.HasVehicleToMove = $("#q8a_select").val();
    Obj.HasVehicleToMoveRate = $("#q8a_text").val() || "0";

    Obj.VehicleType = $("#q9_select").val();
    Obj.VehicleTypeRate = $("#q9_text").val() || "0";

    Obj.NeedsTowVanOrDriver = $("#q10_select").val();
    Obj.NeedsTowVanOrDriverRate = $("#q10_text").val() || "0";

    Obj.NeedsJunkRemoval = $("#q11_select").val();
    Obj.NeedsJunkRemovalRate = $("#q11_text").val() || "0";

    Obj.RequiresOvernightStop = $("#q12_select").val();
    Obj.RequiresOvernightStopRate = $("#q12_text").val() || "0";

    Obj.CallStatus = $("#ddlCallStatus").val();
    Obj.WeekType = $("#ddlWeek").val();
    Obj.Note = $("#txtNote").val();
    Obj.GSTAmount = $("#txtGSTAmount").val().trim();
    Obj.NetAmount = $("#txtNetAmount").val().trim();
    var sMethodName;
    if ($("#hdnCustomerID").val() > 0) {
        Obj.CustomerID = $("#hdnCustomerID").val();
        sMethodName = "UpdateNewCustomer";
    }
    else { sMethodName = "AddNewCustomer"; }

    SaveandUpdateNewCustomer(Obj, sMethodName);
});
function SaveandUpdateNewCustomer(Obj, sMethodName) {
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

                        if (sMethodName == "AddNewCustomer") {
                            $.jGrowl("Added Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
                            $("#hdnCustomerID").val(objResponse.Value);
                            EditRecord($("#hdnCustomerID").val());

                        }
                        else if (sMethodName == "UpdateNewCustomer") {
                            $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
                            EditRecord(Obj.CustomerID);
                            $("#btnSave").hide();
                            $("#btnUpdate").hide();
                        }

                        $('#compose-modal').modal('hide');
                    }
                }
                else if (objResponse.Status == "Error") {
                    if (objResponse.Value == "0") {
                        window.location = "frmLogin.aspx";
                    }
                    else if (objResponse.Value == "NewCustomer_A_01" || objResponse.Value == "NewCustomer_U_01") {
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
        url: "WebServices/VHMSService.svc/GetNewCustomerByID",
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
                            $("#btnAddNew").click();
                            $("#btnSave").hide();
                            $("#btnUpdate").show();
                            $("#hdnCustomerID").val(obj.CustomerID)
                            $("#txtNewCustomer").val(obj.CustomerName);
                            $("#txtMobileNo").val(obj.MobileNo);
                            $("#txtAltMobileNo").val(obj.AltMobileNo);
                            $("#txtCurrentAddress").val(obj.CurrentAddress);
                            $("#txtShiftingAddress").val(obj.ShiftingAddress);
                            $("#txtPackingDate").val(obj.sPackingDate);
                            $("#txtShiftingDate").val(obj.sReachingDate);
                            $("#moveTypeHeading").val(obj.TypeofMove);
                            $("#txtKms").val(obj.Kms);
                            $("#ddlHouseType").val(obj.HouseType.HouseTypeID).change();
                            $("#q1_select").val(obj.RequiresMoreThanTwoPersons).change();
                            $("#q1_text").val(obj.RequiresMoreThanTwoPersonsRate);
                            $("#q2_select").val(obj.HasStaircase).change();
                            $("#q2_text").val(obj.HasStaircaseRate);
                            $("#q2a_select").val(obj.HasServiceElevator).change();
                            $("#q2a_text").val(obj.HasServiceElevatorRate);
                            $("#q3_select").val(obj.HasProperParking).change();
                            $("#q3_text").val(obj.HasProperParkingRate);
                            $("#q3a_select").val(obj.AdditionalChargeForLongWalks).change();
                            $("#q3a_text").val(obj.AdditionalChargeForLongWalksRate);
                            $("#q4_select").val(obj.WantsPackingHelp).change();
                            $("#q4_text").val(obj.WantsPackingHelpRate);
                            $("#q4a_select").val(obj.PackingHandledByTeam).change();
                            $("#q4a_text").val(obj.PackingHandledByTeamRate);
                            $("#q4b_select").val(obj.NeedsPackingMaterials).change();
                            $("#q4b_text").val(obj.NeedsPackingMaterialsRate);
                            $("#q5_select").val(obj.HasFragileItems).change();
                            $("#q5_text").val(obj.HasFragileItemsRate);
                            $("#q6_select").val(obj.HasHazardousItems).change();
                            $("#q6_text").val(obj.HasHazardousItemsRate);
                            $("#q7_select").val(obj.HasInventoryList).change();
                            $("#q7_text").val(obj.HasInventoryListRate);
                            $("#q7a_select").val(obj.InventoryListNote).change();
                            $("#q7a_text").val(obj.InventoryListNoteRate);
                            $("#q7b_select").val(obj.HasPiano).change();
                            $("#q7b_text").val(obj.HasPianoRate);
                            $("#q8_select").val(obj.AdditionalChargeForPiano).change();
                            $("#q8_text").val(obj.AdditionalChargeForPianoRate);
                            $("#q8a_select").val(obj.HasVehicleToMove).change();
                            $("#q8a_text").val(obj.HasVehicleToMoveRate);
                            $("#q9_select").val(obj.VehicleType).change();
                            $("#q9_text").val(obj.VehicleTypeRate);
                            $("#q10_select").val(obj.NeedsTowVanOrDriver).change();
                            $("#q10_text").val(obj.NeedsTowVanOrDriverRate);
                            $("#q11_select").val(obj.NeedsJunkRemoval).change();
                            $("#q11_text").val(obj.NeedsJunkRemovalRate);
                            $("#q12_select").val(obj.RequiresOvernightStop).change();
                            $("#ddlWeek").val(obj.WeekType).change();
                            $("#txtNote").val(obj.Note);
                            $("#q12_text").val(obj.RequiresOvernightStopRate);
                            $("#ddlCallStatus").val(obj.CallStatus);
                            $("#txtGSTAmount").val(obj.GSTAmount);
                            $("#txtNetAmount").val(obj.NetAmount);
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

function GetRecord() {
    dProgress(true);
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/GetCancelCustomer",
        data: JSON.stringify({ CallStatus:"Cancel" }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d !== "") {
                var objResponse = jQuery.parseJSON(data.d);
                if (objResponse.Status === "Success") {
                    var notetable = $("#tblRecord").dataTable();
                    notetable.fnDestroy();

                    if (objResponse.Value !== null && objResponse.Value !== "NoRecord") {
                        var obj = $.parseJSON(objResponse.Value);
                        $("#tblRecord_tbody").empty();
                        var TypeStatus = "";
                        for (var index = 0; index < obj.length; index++) {
                            if (obj[index].CallStatus == "Cancel") {
                                TypeStatus = "<span class='label label-danger'>Cancel</span>";
                            } else {
                                TypeStatus = "<span class='label label-warning'>Follow Up</span>"; 
                            }
                            var row = "<tr id='" + obj[index].CustomerID + "'>";
                            row += "<td>" + (index + 1) + "</td>";
                            row += "<td>" + obj[index].CustomerName + "</td>";
                            row += "<td>" + obj[index].MobileNo + "</td>";
                            row += "<td>" + obj[index].HouseType.HouseTypeName + "</td>";
                            row += "<td>" + obj[index].Kms + "</td>";
                            row += "<td>" + obj[index].sPackingDate + "</td>";
                            row += "<td>" + obj[index].sReachingDate + "</td>";
                            row += "<td>" + obj[index].GSTAmount + "</td>";
                            row += "<td>" + obj[index].NetAmount + "</td>";
                            row += "<td class='hidden-xs'>" + TypeStatus + "</td>";
                            // View Button
                            if (ActionView === "1") {
                                row += "<td style='text-align:center;'><a href='#' id='" + obj[index].CustomerID + "' class='View' title='Click here to View'><i class='fa fa-lg fa-clone text-yellow'></i></a></td>";
                            } else {
                                row += "<td></td>";
                            }

                            // Edit Button
                            if (ActionUpdate === "1") {
                                row += "<td style='text-align:center;'><a href='#' id='" + obj[index].CustomerID + "' class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'></i></a></td>";
                            } else {
                                row += "<td></td>";
                            }

                            // Delete Button
                            if (ActionDelete === "1") {
                                row += "<td style='text-align:center;'><a href='#' id='" + obj[index].CustomerID + "' class='Delete' title='Click here to Cancel'><i class='fa fa-lg fa-times-circle text-red'></i></a></td>";
                            } else {
                                row += "<td></td>";
                            }

                            row += "</tr>";
                            $("#tblRecord_tbody").append(row);
                        }

                        // Bind Actions
                        $(".View").click(function () {
                            if (ActionView === "1") {
                                EditRecord($(this).closest("tr").attr("id"));
                                $("#btnSave").hide();
                                $("#btnUpdate").hide();
                            } else {
                                $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                            }
                        });

                        $(".Edit").click(function () {
                            if (ActionUpdate === "1") {
                                EditRecord($(this).closest("tr").attr("id"));
                            } else {
                                $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                            }
                        });

                        $(".Delete").click(function () {
                            if (ActionDelete === "1") {
                                if (confirm('Are you sure to cancel the selected record?')) {
                                    ShowDeleteRecord($(this).closest("tr").attr("id"));
                                }
                            } else {
                                $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                            }
                        });
                    }

                    dProgress(false);
                } else if (objResponse.Value === "NoRecord") {
                    $("#tblRecord_tbody").empty();
                    dProgress(false);
                }

                // Reinitialize DataTable
                $("#tblRecord").dataTable({
                    "bPaginate": true,
                    "bFilter": true,
                    "bSort": true,
                    "iDisplayLength": 25,
                    "aoColumns": [
                        { "sWidth": "5%" },
                        { "sWidth": "30%" },
                        { "sWidth": "20%" },
                        { "sWidth": "10%" },
                        { "sWidth": "10%" },
                        { "sWidth": "10%" },
                        { "sWidth": "10%" },
                        { "sWidth": "20%" },
                        { "sWidth": "20%" },
                        { "sWidth": "5%" },
                        { "sWidth": "5%" },
                        { "sWidth": "5%" },
                        { "sWidth": "5%" }
                    ]
                });

                $("#tblRecord_filter").addClass('pull-right');
                $(".pagination").addClass('pull-right');
            } else {
                $("#tblRecord_tbody").empty();
                dProgress(false);
            }
        },
        error: function (e) {
            $.jGrowl("Error Occurred", { sticky: true, theme: 'danger', life: jGrowlLife });
            dProgress(false);
        }
    });

    return false;
}
$("#txtSearchName").change(function () {
    if ($("#txtSearchName").val().trim() != "" || $("#txtSearchName").val().trim() != undefined) {
        var iDetails = $("#txtSearchName").val();
        GetSearchRecord(iDetails);
    }
    return false;
});
function GetSearchRecord(iDetails) {
    dProgress(true);
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/SearchNewCustomer",
        data: JSON.stringify({ ID: iDetails }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.d !== "") {
                var objResponse = jQuery.parseJSON(data.d);
                if (objResponse.Status === "Success") {
                    var notetable = $("#tblSearchResult").dataTable();
                    notetable.fnDestroy();

                    if (objResponse.Value !== null && objResponse.Value !== "NoRecord") {
                        var obj = $.parseJSON(objResponse.Value);
                        $("#tblSearchResult_tbody").empty();
                        for (var index = 0; index < obj.length; index++) {
                            if (obj[index].CallStatus == "Call Processed") { TypeStatus = "<span class='label label-success'>Call Processed</span>"; }
                            else { TypeStatus = "<span class='label label-warning'>Follow Up</span>"; }
                            var row = "<tr id='" + obj[index].CustomerID + "'>";
                            row += "<td>" + (index + 1) + "</td>";
                            row += "<td>" + obj[index].NewCustomer + "</td>";
                            row += "<td>" + obj[index].MobileNo + "</td>";
                            row += "<td>" + obj[index].HouseType.HouseTypeName + "</td>";
                            row += "<td>" + obj[index].Kms + "</td>";
                            row += "<td>" + obj[index].sPackingDate + "</td>";
                            row += "<td>" + obj[index].sReachingDate + "</td>";
                            row += "<td>" + obj[index].GSTAmount + "</td>";
                            row += "<td>" + obj[index].NetAmount + "</td>";
                            row += "<td class='hidden-xs'>" + TypeStatus + "</td>";

                            // View Button
                            if (ActionView === "1") {
                                row += "<td style='text-align:center;'><a href='#' id='" + obj[index].CustomerID + "' class='View' title='Click here to View'><i class='fa fa-lg fa-clone text-yellow'></i></a></td>";
                            } else {
                                row += "<td></td>";
                            }

                            // Edit Button
                            if (ActionUpdate === "1") {
                                row += "<td style='text-align:center;'><a href='#' id='" + obj[index].CustomerID + "' class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'></i></a></td>";
                            } else {
                                row += "<td></td>";
                            }

                            // Delete Button
                            if (ActionDelete === "1") {
                                row += "<td style='text-align:center;'><a href='#' id='" + obj[index].CustomerID + "' class='Delete' title='Click here to Cancel'><i class='fa fa-lg fa-times-circle text-red'></i></a></td>";
                            } else {
                                row += "<td></td>";
                            }

                            row += "</tr>";
                            $("#tblRecord_tbody").append(row);
                        }
                        // Bind Actions
                        $(".View").click(function () {
                            if (ActionView === "1") {
                                EditRecord($(this).closest("tr").attr("id"));
                                $("#btnSave").hide();
                                $("#btnUpdate").hide();
                            } else {
                                $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                            }
                        });

                        $(".Edit").click(function () {
                            if (ActionUpdate === "1") {
                                EditRecord($(this).closest("tr").attr("id"));
                            } else {
                                $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                            }
                        });

                        $(".Delete").click(function () {
                            if (ActionDelete === "1") {
                                if (confirm('Are you sure to cancel the selected record?')) {
                                    ShowDeleteRecord($(this).closest("tr").attr("id"));
                                }
                            } else {
                                $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                            }
                        });
                    }

                    dProgress(false);
                } else if (objResponse.Value === "NoRecord") {
                    $("#tblSearchResult_tbody").empty();
                    dProgress(false);
                }

                // Reinitialize DataTable
                $("#tblSearchResult").dataTable({
                    "bPaginate": true,
                    "bFilter": true,
                    "bSort": true,
                    "iDisplayLength": 25,
                    "aoColumns": [
                        { "sWidth": "5%" },
                        { "sWidth": "30%" },
                        { "sWidth": "20%" },
                        { "sWidth": "10%" },
                        { "sWidth": "10%" },
                        { "sWidth": "10%" },
                        { "sWidth": "10%" },
                        { "sWidth": "10%" },
                        { "sWidth": "10%" },
                        { "sWidth": "5%" },
                        { "sWidth": "5%" },
                        { "sWidth": "5%" }
                    ]
                });

                $("#tblRecord_filter").addClass('pull-right');
                $(".pagination").addClass('pull-right');
            } else {
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

function DeleteRecord(id) {

    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/DeleteNewCustomer",
        data: JSON.stringify({ ID: id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.d != "") {
                var objResponse = jQuery.parseJSON(data.d);
                if (objResponse.Status == "Success") {
                    if (objResponse.Value > 0) {
                        GetRecord();
                        $.jGrowl("Deleted Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
                    }
                }
                else if (objResponse.Status == "Error") {
                    if (objResponse.Value == "0") {
                        window.location = "frmLogin.aspx";
                    }
                    else if (objResponse.Value == "OPBilling_R_01" || objResponse.Value == "OPBilling_D_01") {
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


$("#q1_text, #q2_text, #q2a_text, #q3_text, #q3a_text, #q4_text, #q4a_text, #q4b_text,#q5_text, #q6_text, #q7_text, #q7a_text, #q7b_text, #q8_text, #q8a_text,#q9_text, #q10_text, #q11_text, #q12_text, #txtDiscountAmount").on("change blur", function () {
    CalculateAmount();
});

function CalculateAmount() {
    var total = 0;
    total += parseFloat($("#q1_text").val()) || 0;
    total += parseFloat($("#q2_text").val()) || 0;
    total += parseFloat($("#q2a_text").val()) || 0;
    total += parseFloat($("#q3_text").val()) || 0;
    total += parseFloat($("#q3a_text").val()) || 0;
    total += parseFloat($("#q4_text").val()) || 0;
    total += parseFloat($("#q4a_text").val()) || 0;
    total += parseFloat($("#q4b_text").val()) || 0;
    total += parseFloat($("#q5_text").val()) || 0;
    total += parseFloat($("#q6_text").val()) || 0;
    total += parseFloat($("#q7_text").val()) || 0;
    total += parseFloat($("#q7a_text").val()) || 0;
    total += parseFloat($("#q7b_text").val()) || 0;
    total += parseFloat($("#q8_text").val()) || 0;
    total += parseFloat($("#q8a_text").val()) || 0;
    total += parseFloat($("#q9_text").val()) || 0;
    total += parseFloat($("#q10_text").val()) || 0;
    total += parseFloat($("#q11_text").val()) || 0;
    total += parseFloat($("#q12_text").val()) || 0;
    var gstAmount = (total * 10) / 100;
    $("#txtNetAmount").val(total.toFixed(""));
    $("#txtGSTAmount").val(gstAmount.toFixed(""));
}
