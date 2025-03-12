var gMagazineData = [];
var gOPBillingList = [];
var RecordAvailable = 0;
var viewflag = 0;

$(function () {
    pLoadingSetup(false);
    ActionAdd = _CMActionAdd;
    ActionUpdate = _CMActionUpdate;
    ActionDelete = _CMActionDelete;
    ActionView = _CMActionView;
    $("#btnAddNew").show();
    $("#btnList").hide();
    $("#divID").hide();
    $("#btnAddMagazine").show();
    $("#btnUpdateMagazine").hide();
    $("#SearchResult").hide();
    $("#divTab").show();
    $("#divOPBilling").hide();
    GetTaxList("ddlTaxName");
    GetPassword();
    GetProductList("ddlProductName");
    GetCustomerList("ddlCustomerName");
    GetCompany("ddlCompany");
    GetTaxList("ddlTax");
    $("#ddlTaxName").change();
    $("#txtBillDate,#txtLRDate").attr("data-link-format", "dd/MM/yyyy");
    $("#txtBillDate,#txtLRDate").datetimepicker({
        pickTime: false,
        useCurrent: true,
        maxDate: moment(),
        format: 'DD/MM/YYYY'
    });
    pLoadingSetup(true);
    GetRecord();
});



$("#btnLink").click(function () {
    var myWindow = window.open("https://docs.ewaybillgst.gov.in/", "MsgWindow");
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
                            for (var index = 0; index < obj.length; index++) {
                                if (obj[index].IsActive)
                                    $(sControlName).append("<option value='" + obj[index].ProductID + "'>" + obj[index].ProductName + "</option>");
                            }
                            $("#ddlProductName").val($("#ddlProductName option:first").val()).change();
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

function GetPassword() {
    dProgress(true);
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/GetUserPassword",
        data: JSON.stringify({ ID: 0 }),
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
                            $("#hdRS").val(obj.ConfirmPassword);
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

function GetCompany(ddlname) {
    var sControlName = "#" + ddlname;
    dProgress(true);
    $(sControlName).empty();
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/GetCompany",
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
                            $("#ddlCompany").append('<option value="' + '0' + '">' + 'Select Company' + '</option>');
                            for (var index = 0; index < obj.length; index++) {
                                $(sControlName).append("<option value='" + obj[index].CompanyID + "'>" + obj[index].CompanyName + "</option>");
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
                            $("#ddlCustomerName").append('<option value="' + '0' + '">' + 'Select Customer Name' + '</option>');
                            for (var index = 0; index < obj.length; index++) {
                                if (obj[index].IsActive)
                                    $(sControlName).append("<option value='" + obj[index].CustomerID + "'>" + obj[index].CustomerName + "</option>");
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

function Edit_OPBillingDetail(ID) {
    Bind_OPBillingByID(ID, gOPBillingList);
    return false;
}

$("#btnAddNew").click(function () {
    $("#secHeader").addClass('hidden');
    $("#btnAddNew").hide();
    $("#btnList").show();
    $("#hdnSalesOrderID").val("0");
    $("#hdnSalesID").val("0");
    $("#btnAddMagazine").show();
    $("#btnUpdateMagazine").hide();

    $("#txtSNo").val("1");
    $("#divTab").hide();
    $("#divOPBilling").show();

    $("#btnSave").show();
    $("#btnUpdate").hide();
    $("#btnPrintbill").hide();
    $("#ddlTaxName").change();
    $("#ddlTax").change();
    gOPBillingList = [];
    ClearOPBillingTab();
    $("#divOPBillingList").empty();
    $("#ddlTaxName").val(8).change();
    $("#ddlTax").val(8).change();
    $("#ddlCompany").val(0).change();
    $("#ddlTax").val(2).change();
    $("#divOtherPasswordlbl").hide();
    $("#divOtherPassword").hide();
    $("#txtBillDate").focus();
    $("#txtBillNo").focus();
    $("#imagefile2").val("");
    $("#imagefile3").val("");
    $("#imagefile4").val("");
    return false;
});

$("#btnClearImage1").click(function () {
    $get("imgUpload2_view").src = "";
    $("#imagefile2").val("");
});

$("#btnClearImage2").click(function () {
    $get("imgUpload3_view").src = "";
    $("#imagefile3").val("");
});

$("#btnClearImage3").click(function () {
    $get("imgUpload4_view").src = "";
    $("#imagefile4").val("");
});
$("#btndetailsCancel").click(function () {
    $('#composedetails').modal('hide');
});


$("#btnList").click(function () {
    $("#btnAddNew").show();
    $("#btnList").hide();

    $("#btnAddMagazine").show();
    $("#btnUpdateMagazine").hide();

    $("#divTab").show();
    $("#divOPBilling").hide();

    GetRecord();
    return false;
});

$("#btnClose").click(function () {
    $("#secHeader").removeClass('hidden');
    $("#hdnSalesOrderID").val("0");
    $("#hdnSalesID").val("0");
    gOPBillingList = [];
    ClearOPBillingTab();
    $("#btnList").click();
    return false;
});

function ClearOPBillingTab() {
    ClearOPBillingFields();
    $("#txtBillNo").val("");
    $("#txtBillDate").val("");
    $("#txtComments").val("");
    $("#ddlTax").val($("#ddlTax option:first").val());
    gOPBillingList = [];
    $("#btnSave").show();
    $("#btnUpdate").hide();
    $get("imgUpload2_view").src = "";
    $get("imgUpload3_view").src = "";
    $get("imgUpload4_view").src = "";
    $("[id*=imgUpload2_view]").css("visibility", "hidden");
    $("[id*=imgUpload3_view]").css("visibility", "hidden");
    $("[id*=imgUpload4_view]").css("visibility", "hidden");
    $("#ddlProductName").val(null).change();
    $("#txtBillNo").attr("disabled", false);
    return false;
}


//$("#txtSearchCode").change(function () {
//    if ($("#txtSearchCode").val().length > 2) {
//        GetProductByCode("ddlProduct");
//        if ($("#ddlProduct").val() > 0) {
//            GetRateByProduct();
//            GetProductTax();
//        }
//    }
//    else if ($("#txtSearchCode").val().length == 0) {
//        GetProductList("ddlProduct");
//        if ($("#ddlProduct").val() > 0) {
//            GetRateByProduct();
//            GetProductTax();
//        }
//    }
//});

function TaxCalculate() {
    for (var i = 0; i < gOPBillingList.length; i++) {
        if (gOPBillingList[i].StatusFlag != "D") {
            gOPBillingList[i].DiscountAmount = parseFloat(gOPBillingList[i].Rate) * parseFloat(gOPBillingList[i].Quantity) * parseFloat(gOPBillingList[i].DiscountPercentage) / 100;
            gOPBillingList[i].SubTotal = (parseFloat(gOPBillingList[i].Rate) * parseFloat(gOPBillingList[i].Quantity)) - parseFloat(gOPBillingList[i].DiscountAmount);
            iSubtotal = gOPBillingList[i].SubTotal;
            iTaxID = gOPBillingList[i].Tax.TaxID;
            GetTaxByID(iTaxID);

            gOPBillingList[i].Tax.TaxPercentage = parseFloat($("#hdnTaxPercent").val());
            if ($("#hdnStateCode").val() == 33) {
                gOPBillingList[i].Tax.CGSTPercent = parseFloat($("#hdnCGSTPercent").val());
                gOPBillingList[i].Tax.SGSTPercent = parseFloat($("#hdnSGSTPercent").val());
                gOPBillingList[i].Tax.IGSTPercent = 0;
                gOPBillingList[i].CGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.CGSTPercent) / 100).toFixed(2);
                gOPBillingList[i].SGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.SGSTPercent) / 100).toFixed(2);
                gOPBillingList[i].IGSTAmount = 0;
            }
            else {
                gOPBillingList[i].Tax.CGSTPercent = 0;
                gOPBillingList[i].Tax.SGSTPercent = 0;
                gOPBillingList[i].Tax.IGSTPercent = parseFloat($("#hdnIGSTPercent").val());
                gOPBillingList[i].CGSTAmount = 0;
                gOPBillingList[i].SGSTAmount = 0;
                gOPBillingList[i].IGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.IGSTPercent) / 100).toFixed(2);
            }
            gOPBillingList[i].TaxAmount = (parseFloat(gOPBillingList[i].CGSTAmount) + parseFloat(gOPBillingList[i].SGSTAmount) + parseFloat(gOPBillingList[i].IGSTAmount)).toFixed(2);
        }
        CalculateAmount();
    }
}
function GetUnitList(ddlname) {
    var sControlName = "#" + ddlname;
    dProgress(true);
    $(sControlName).empty();
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/GetUnit",
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
                                    $(sControlName).append("<option value='" + obj[index].UnitID + "'>" + obj[index].UnitName + "</option>");
                            }
                            $("#ddlUnit").val($("#ddlUnit option:first").val());
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
                            $("#ddlTax").val($("#ddlTax option:first").val());
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


Array.prototype.max = function () {
    var max = this.length > 0 ? this[0]["sNO"] : 0;
    var len = this.length;
    for (var i = 1; i < len; i++) if (this[i]["sNO"] > max) max = this[i]["sNO"];
    return max;
}

$("#txtRate,#txtQuantity, #txtDisAmt, #txtDisPer").change(function () {
    CalculateAmountTrans();
});
function CalculateTrans() {
    var iTax = parseFloat($("#hdnTransTaxPercent").val());
    var iRate = parseFloat($("#txtRate").val());
    var iqty = parseFloat($("#txtQuantity").val());
    var iCGST = parseFloat($("#hdnTransCGSTPercent").val());
    var iSGST = parseFloat($("#hdnTransSGSTPercent").val());
    var iIGST = parseFloat($("#hdnTransIGSTPercent").val());
    var iDisAmt = parseFloat($("#txtDisAmt").val());

    if (isNaN(iRate)) iRate = 0;
    if (isNaN(iqty)) iqty = 0;
    if (isNaN(iDisAmt)) iDisAmt = 0;
    if (isNaN(iTax)) iTax = 0;
    var iSubTotal = (parseFloat(iRate) * parseFloat(iqty)) - iDisAmt;

    if ($("#hdnStateCode").val() == 33) {
        var iCGSTPercent = parseFloat(iSubTotal) * parseFloat(iCGST) / 100;
        var iSGSTPercent = parseFloat(iSubTotal) * parseFloat(iSGST) / 100;
        $("#hdnTransSGSTAmount").val(parseFloat(iSGSTPercent).toFixed(2));
        $("#hdnTransCGSTAmount").val(parseFloat(iCGSTPercent).toFixed(2));
        $("#hdnTransIGSTAmount").val(0)
    }
    else {
        var iIGSTPercent = parseFloat(iSubTotal) * parseFloat(iIGST) / 100;
        $("#hdnTransSGSTAmount").val(0);
        $("#hdnTransCGSTAmount").val(0);
        $("#hdnTransIGSTAmount").val(parseFloat(iIGSTPercent).toFixed(2))
    }
    var iTaxPercent = parseFloat($("#hdnTransCGSTAmount").val()) + parseFloat($("#hdnTransSGSTAmount").val()) + parseFloat($("#hdnTransIGSTAmount").val());
    $("#txtTaxAmt").val(parseFloat(iTaxPercent).toFixed(2));
    $("#txtSubTotal").val(parseFloat(iSubTotal).toFixed(2));
}

$("#txtDisAmt").change(function () {
    var iDisAmt = parseFloat($("#txtDisAmt").val());
    var iRate = parseFloat($("#txtRate").val());
    var iqty = parseFloat($("#txtQuantity").val());
    if (isNaN(iRate)) iRate = 0;
    if (isNaN(iqty)) iqty = 0;
    if (isNaN(iDisAmt)) iDisAmt = 0;
    var iSubTotal = (parseFloat(iDisAmt) * 100) / (parseFloat(iRate) * parseFloat(iqty));
    $("#txtDisPer").val(parseFloat(iSubTotal).toFixed(2));
    CalculateSubtotal();
});
$("#txtTenderAmount").change(function () {
    CalculateBalance();
});
$("#txtNetAmount").change(function () {
    CalculateBalance();
});

function CalculateBalance() {
    var iNet = parseFloat($("#txtNetAmount").val());
    if (isNaN(iNet)) iNet = 0;
    var iTender = parseFloat($("#txtTenderAmount").val());
    if (isNaN(iTender)) iTender = 0;
    if (iTender > 0)
        $("#txtBalanceGiven").val((parseFloat(iNet) - parseFloat(iTender)).toFixed(2));
    else
        $("#txtBalanceGiven").val("0");
}

$("#txtDisPer,#txtRate,#txtQuantity").change(function () {
    var iDisAmt = parseFloat($("#txtDisPer").val());
    var iRate = parseFloat($("#txtRate").val());
    var iqty = parseFloat($("#txtQuantity").val());
    if (isNaN(iRate)) iRate = 0;
    if (isNaN(iqty)) iqty = 0;
    if (isNaN(iDisAmt)) iDisAmt = 0;
    var iSubTotal = parseFloat(iRate) * parseFloat(iqty) * parseFloat(iDisAmt) / 100;
    $("#txtDisAmt").val(parseFloat(iSubTotal).toFixed(2));
    CalculateSubtotal();
});

function CalculateSubtotal() {

    var iTax = parseFloat($("#hdnTransTaxPercent").val());
    var iRate = parseFloat($("#txtRate").val());
    var iqty = parseFloat($("#txtQuantity").val());
    var iCGST = parseFloat($("#hdnTransCGSTPercent").val());
    var iSGST = parseFloat($("#hdnTransSGSTPercent").val());
    var iIGST = parseFloat($("#hdnTransIGSTPercent").val());
    var iDisAmt = parseFloat($("#txtDisAmt").val());

    if (isNaN(iRate)) iRate = 0;
    if (isNaN(iqty)) iqty = 0;
    if (isNaN(iDisAmt)) iDisAmt = 0;
    if (isNaN(iTax)) iTax = 0;
    var iSubTotal = (parseFloat(iRate) * parseFloat(iqty)) - iDisAmt;

    if ($("#hdnStateCode").val() == 33) {
        var iCGSTPercent = parseFloat(iSubTotal) * parseFloat(iCGST) / 100;
        var iSGSTPercent = parseFloat(iSubTotal) * parseFloat(iSGST) / 100;
        $("#hdnTransSGSTAmount").val(parseFloat(iSGSTPercent).toFixed(2));
        $("#hdnTransCGSTAmount").val(parseFloat(iCGSTPercent).toFixed(2));
        $("#hdnTransIGSTAmount").val(0)
    }
    else {
        var iIGSTPercent = parseFloat(iSubTotal) * parseFloat(iIGST) / 100;
        $("#hdnTransSGSTAmount").val(0);
        $("#hdnTransCGSTAmount").val(0);
        $("#hdnTransIGSTAmount").val(parseFloat(iIGSTPercent).toFixed(2))
    }
    var iTaxPercent = parseFloat($("#hdnTransCGSTAmount").val()) + parseFloat($("#hdnTransSGSTAmount").val()) + parseFloat($("#hdnTransIGSTAmount").val());
    $("#txtTaxAmt").val(parseFloat(iTaxPercent).toFixed(2));
    $("#txtSubTotal").val(parseFloat(iSubTotal).toFixed(2));
}


$("#btnAddMagazine,#btnUpdateMagazine").click(function () {
    TaxCalculate();

    if ($("#ddlCustomerName").val() == "0" || $("#ddlCustomerName").val() == undefined || $("#ddlCustomerName").val() == null) {
        $.jGrowl("Please select Customer", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divCustomer").addClass('has-error'); $("#ddlCustomerName").focus(); return false;
    }
    else { $("#divCustomer").removeClass('has-error'); }

    if ($("#txtQuantity").val() == "" || $("#txtQuantity").val() == undefined || $("#txtQuantity").val() == null || $("#txtQuantity").val() <= 0) {
        $.jGrowl("Please enter Quantity", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divQuantity").addClass('has-error'); $("#txtQuantity").focus(); return false;
    } else { $("#divQuantity").removeClass('has-error'); }

    if ($("#txtRate").val() == "" || $("#txtRate").val() == undefined || $("#txtRate").val() == null) {
        $.jGrowl("Please enter Rate", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divRate").addClass('has-error'); $("#txtRate").focus(); return false;
    } else { $("#divRate").removeClass('has-error'); }

    if ($("#ddlTax").val() == "0" || $("#ddlTax").val() == undefined || $("#ddlTax").val() == null) {
        $.jGrowl("Please select Tax", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divTaxTrans").addClass('has-error'); $("#ddlTax").focus(); return false;
    }
    else { $("#divTaxTrans").removeClass('has-error'); }

    if ($("#txtDisPer").val() == "" || $("#txtDisPer").val() == undefined || $("#txtDisPer").val() == null) {
        $.jGrowl("Please enter Disc. Percent", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divDisPer").addClass('has-error'); $("#txtDisPer").focus(); return false;
    } else { $("#divDisPer").removeClass('has-error'); }

    if ($("#txtDisAmt").val() == "" || $("#txtDisAmt").val() == undefined || $("#txtDisAmt").val() == null) {
        $.jGrowl("Please enter Disc. Amount", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divDisAmt").addClass('has-error'); $("#txtDisAmt").focus(); return false;
    } else { $("#divDisAmt").removeClass('has-error'); }

    if ($("#ddlProductName").val() == "0" || $("#ddlProductName").val() == undefined || $("#ddlProductName").val() == null) {
        $.jGrowl("Please select Product", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divSelectProductName").addClass('has-error'); $("#ddlProductName").focus(); return false;
    }
    else { $("#divSelectProductName").removeClass('has-error'); }



    var iStockCount = 0; var StockValue = 0; var StockQty = 0; var WholesaleMinPrice = 0; var previousQty = 0;
    for (var i = 0; i < gOPBillingList.length; i++) {
        if (gOPBillingList[i].Product.ProductID == $("#ddlProductName").val() && gOPBillingList[i].sNO != $("#hdnOPSNo").val() && gOPBillingList[i].StatusFlag != "D") {
            iStockCount = iStockCount + 1;
            StockQty += gOPBillingList[i].Quantity;
        }
    }
    var ObjData = new Object();
    ObjData.SalesOrderID = 0;

    var oTaxTrans = new Object();
    oTaxTrans.TaxID = $("#ddlTax").val();
    oTaxTrans.TaxName = $("#ddlTax option:selected").text();
    oTaxTrans.TaxPercentage = $("#hdnTransTaxPercent").val().trim();
    if ($("#hdnStateCode").val() == 33) {
        oTaxTrans.CGSTPercent = $("#hdnTransCGSTPercent").val().trim();
        oTaxTrans.SGSTPercent = $("#hdnTransSGSTPercent").val().trim();
        oTaxTrans.IGSTPercent = 0;
    }
    else {
        oTaxTrans.CGSTPercent = 0;
        oTaxTrans.SGSTPercent = 0;
        oTaxTrans.IGSTPercent = $("#hdnTransIGSTPercent").val().trim();
    }
    ObjData.Tax = oTaxTrans;

    var oProduct = new Object();
    oProduct.ProductID = $("#ddlProductName").val();
    oProduct.ProductName = $("#ddlProductName option:selected").text();
    ObjData.Product = oProduct;

    var oUnitTrans = new Object();
    oUnitTrans.UnitID = $("#ddlUnit").val();
    oUnitTrans.UnitName = $("#ddlUnit option:selected").text();
    ObjData.Unit = oUnitTrans;

    ObjData.SGSTAmount = $("#hdnTransSGSTAmount").val().trim();
    ObjData.CGSTAmount = $("#hdnTransCGSTAmount").val().trim();
    ObjData.IGSTAmount = $("#hdnTransIGSTAmount").val().trim();
    ObjData.TaxAmount = parseFloat($("#txtTaxAmt").val());
    ObjData.Description = $("#txtDescription").val();
    ObjData.HSNCode = $("#txtHSNCode").val();
    ObjData.Quantity = parseFloat($("#txtQuantity").val());
    ObjData.Rate = parseFloat($("#txtRate").val());
    ObjData.DiscountPercentage = parseFloat($("#txtDisPer").val());
    ObjData.DiscountAmount = parseFloat($("#txtDisAmt").val());
    ObjData.SubTotal = parseFloat($("#txtSubTotal").val());
    ObjData.Barcode = $("#txtBarcode").val();


    if (this.id == "btnAddMagazine") {
        ObjData.sNO = gOPBillingList.max() + 1;
        ObjData.SNo = ObjData.sNO;
        ObjData.SalesOrderID = 0;

        ObjData.StatusFlag = "I";
        var Count = 0;
        if (Count == 0)
            AddOPBillingData(ObjData);
        else
            DisplayOPBillingList(gOPBillingList);
    }
    else if (this.id == "btnUpdateMagazine") {
        ObjData.sNO = $("#hdnOPSNo").val();
        if ($("#hdnSalesOrderID").val() > 0) {
            ObjData.StatusFlag = "U";
            ObjData.SalesOrderID = $("#hdnSalesOrderID").val();
        }
        else {
            ObjData.StatusFlag = "I";
            ObjData.SalesOrderID = 0;
        }
        Update_OPBilling(ObjData);
    }
    CalculateAmount();
    ClearOPBillingFields();
    var scrollBottom = Math.max($('#tblOPBillingList').height());
    $('#divOPBillingList').scrollTop(scrollBottom);
    $("#ddlProductName").focus();
    $("#btnAddMagazine").show();
    $("#btnUpdateMagazine").hide();
    $("#txtCode").focus();
});

$("#txtRoundoff").keypress(function (e) {
    if (e.which != 46 && e.which != 45 && e.which != 46 &&
        !(e.which >= 48 && e.which <= 57)) {
        return false;
    }
});

$("#ddlCustomerName").change(function () {
    if ($("#ddlCustomerName").val() > 0) {
        GetCustomerByID($("#ddlCustomerName").val());
    }
});
function GetCustomerByID(id) {
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
                            $("#hdnStateCode").val(obj.State.StateCode);
                            for (var i = 0; i < gOPBillingList.length; i++) {
                                if (gOPBillingList[i].StatusFlag != "D") {
                                    iSubtotal = gOPBillingList[i].SubTotal;
                                    iTaxID = gOPBillingList[i].Tax.TaxID;
                                    GetTaxByID(iTaxID);

                                    gOPBillingList[i].Tax.TaxPercentage = parseFloat($("#hdnTaxPercent").val());
                                    if ($("#hdnStateCode").val() == 33) {
                                        gOPBillingList[i].Tax.CGSTPercent = parseFloat($("#hdnCGSTPercent").val());
                                        gOPBillingList[i].Tax.SGSTPercent = parseFloat($("#hdnSGSTPercent").val());
                                        gOPBillingList[i].Tax.IGSTPercent = 0;
                                        gOPBillingList[i].CGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.CGSTPercent) / 100).toFixed(2);
                                        gOPBillingList[i].SGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.SGSTPercent) / 100).toFixed(2);
                                        gOPBillingList[i].IGSTAmount = 0;
                                    }
                                    else {
                                        gOPBillingList[i].Tax.CGSTPercent = 0;
                                        gOPBillingList[i].Tax.SGSTPercent = 0;
                                        gOPBillingList[i].Tax.IGSTPercent = parseFloat($("#hdnIGSTPercent").val());
                                        gOPBillingList[i].CGSTAmount = 0;
                                        gOPBillingList[i].SGSTAmount = 0;
                                        gOPBillingList[i].IGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.IGSTPercent) / 100).toFixed(2);
                                    }
                                    gOPBillingList[i].TaxAmount = (parseFloat(gOPBillingList[i].CGSTAmount) + parseFloat(gOPBillingList[i].SGSTAmount) + parseFloat(gOPBillingList[i].IGSTAmount)).toFixed(2);
                                }
                                CalculateAmount();
                            }
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
        error: function (e) {
            $.jGrowl("Error  Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
            dProgress(false);
        }
    });
    return false;
}

function ClearOPBillingFields() {
    $("#btnAddOPBilling").show();
    $("#btnUpdateOPBilling").hide();
    $("#ddlProductName").val("0").change();
    $("#ddlTax").val("0").change();
    $("#txtDescription").val("");
    $("#txtHSNCode").val("");
    $("#txtQuantity").val("0");
    $("#txtRate").val("0");
    $("#txtTaxAmt").val("0");
    $("#hdnOriginalRate").val("0");
    $("#txtDisPer").val("0");
    $("#txtDisAmt").val("0");
    $("#txtSubTotal").val("0.00");
    $("#txtBarcode").val("");
    $("#hdnOPSNo").val("");

    //$("#hdnSalesOrderID").val("");
    if (parseFloat($("#txtDiscountPercent").val()) > 0) {
        $("#txtDisPer").val($("#txtDiscountPercent").val());
    }
    $("#divQuantity").removeClass('has-error');
    $("#divRate").removeClass('has-error');
    return false;

    $("#ddlTax").val($("#ddlTaxName").val()).change();

}

function AddOPBillingData(oData) {
    gOPBillingList.push(oData);
    DisplayOPBillingList(gOPBillingList);
    return false;
}


$("#txtNetAmount").change(function () {
    CalculateBalance();
});

function CalculateBalance() {
    var iNet = parseFloat($("#txtNetAmount").val());
    if (isNaN(iNet)) iNet = 0;
}


$("#txtDiscountAmount").change(function () {
    calculateDiscount();
});


function calculateDiscount() {
    var iOPBillingAmount = 0, iBillingDiscount = 0;
    for (var i = 0; i < gOPBillingList.length; i++) {
        if (gOPBillingList[i].StatusFlag != "D") {
            iOPBillingAmount = iOPBillingAmount + (parseFloat(gOPBillingList[i].Quantity) * parseFloat(gOPBillingList[i].Rate));
        }
    }

    var iBillingDiscount = parseFloat($("#txtDiscountAmount").val());
    if (isNaN(iBillingDiscount)) iBillingDiscount = 0;
    $("#txtDiscountPercent").val(parseFloat(iBillingDiscount) * 100 / parseFloat(iOPBillingAmount).toFixed(2)).change();
}


function DisplayOPBillingList(gData) {
    var sTable = "";
    var sCount = 1;
    var sColorCode = "bg-info";

    if (gData.length >= 12) { $("#divOPBillingList").css({ 'height': '0px', 'min-height': '400px', 'overflow': 'auto' }); }
    else { $("#divOPBillingList").css({ 'height': '', 'min-height': '' }); }

    if (gData.length > 0) {
        sTable = "<table id='tblOPBillingList' class='table no-margin table-condensed table-hover'>";
        sTable += "<thead><tr><th class='" + sColorCode + "' style='width:3px;text-align: center'>S.No</th>";
        sTable += "<th class='" + sColorCode + "'>Product</th>";
        sTable += "<th class='" + sColorCode + "'>Qty</th>";
        sTable += "<th class='" + sColorCode + "'>Rate</th>";
        sTable += "<th class='" + sColorCode + "'>Tax</th>";
        sTable += "<th class='" + sColorCode + "'>Tax Amount</th>";
        sTable += "<th class='" + sColorCode + "'>Dis%</th>";
        sTable += "<th class='" + sColorCode + "'>Discount</th>";
        sTable += "<th class='" + sColorCode + "'>Subtotal</th>";
       
        sTable += "<th class='" + sColorCode + "' style='width:3px;text-align: center'>Edit</th>";
        sTable += "<th class='" + sColorCode + "' style='width:3px;text-align: center'>Delete</th>";
        sTable += "</tr></thead><tbody id='tblOPBillingList_body'>";
        sTable += "</tbody></table>";
        $("#divOPBillingList").html(sTable);
        for (var i = 0; i < gData.length; i++) {
            if (gData[i].StatusFlag != "D") {
                if (gData[i].NewProductFlag == 0)
                    sTable = "<tr><td id='" + gData[i].SNo + "'>" + sCount + "</td>";
                else
                    sTable = "<tr style='background-color:#f3c8c8;'><td id='" + gData[i].SNo + "'>" + sCount + "</td>";
                $("#txtSNo").val(sCount + 1);
                sTable += "<td>" + gData[i].Product.ProductName + "</td>";
                sTable += "<td>" + gData[i].Quantity + "</td>";
                sTable += "<td>" + gData[i].Rate + "</td>";
                sTable += "<td>" + gData[i].Tax.TaxPercentage + " %</td>";
                sTable += "<td>" + gData[i].TaxAmount + "</td>";
                sTable += "<td>" + gData[i].DiscountPercentage.toFixed(2) + " %</td>";
                sTable += "<td>" + gData[i].DiscountAmount.toFixed(2) + "</td>";
                sTable += "<td>" + gData[i].SubTotal + "</td>";
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

function Edit_Magazine(ID) {
    Bind_MagazineByID(ID, gOPBillingList);
    return false;
}

function Bind_OPBillingByID(ID, data) {
    if (viewflag == 0) {
        $("#btnAddMagazine").hide();
        $("#btnUpdateMagazine").show();
    }
    else {
        $("#btnAddMagazine").hide();
        $("#btnUpdateMagazine").hide();
    }
    $("#ddlProductName").focus();
    var sCount = 0;
    for (var i = 0; i < data.length; i++) {
        if (data[i].sNO == ID) {
            if (data[i].StatusFlag != "D") {
                $("#txtSNo").val(ID);
                $("#hdnOPSNo").val(ID);
                $("#ddlProductName").val(data[i].Product.ProductID).change();
                $("#txtDescription").val(data[i].Description);
                $("#ddlTax").val(data[i].Tax.TaxID).change();
                $("#txtTaxAmt").val(data[i].TaxAmount);
                $("#txtQuantity").val(data[i].Quantity);
                $("#txtRate").val(data[i].Rate);
                $("#txtDisPer").val(data[i].DiscountPercentage);
                $("#txtDisAmt").val(data[i].DiscountAmount);
                $("#txtSubTotal").val(data[i].SubTotal);
                $("#txtBarcode").val(data[i].Barcode);
            }
        }
    }
    return false;
}

function Update_OPBilling(oData) {
    for (var i = 0; i < gOPBillingList.length; i++) {
        if (gOPBillingList[i].sNO == oData.sNO) {
            gOPBillingList[i].SalesOrderID = oData.SalesOrderID;


            var oProduct = new Object();
            oProduct.ProductID = oData.Product.ProductID;
            oProduct.ProductName = oData.Product.ProductName;
            gOPBillingList[i].Product = oProduct;

            var oTransTax = new Object();
            oTransTax.TaxID = oData.Tax.TaxID;
            oTransTax.TaxPercentage = oData.Tax.TaxPercentage;
            oTransTax.IGSTPercent = oData.Tax.IGSTPercent;
            oTransTax.SGSTPercent = oData.Tax.SGSTPercent;
            oTransTax.CGSTPercent = oData.Tax.CGSTPercent;
            gOPBillingList[i].Tax = oTransTax;

            gOPBillingList[i].TaxAmount = oData.TaxAmount;
            gOPBillingList[i].CGSTAmount = oData.CGSTAmount;
            gOPBillingList[i].SGSTAmount = oData.SGSTAmount;
            gOPBillingList[i].IGSTAmount = oData.IGSTAmount;
            gOPBillingList[i].Quantity = oData.Quantity;
            gOPBillingList[i].Description = oData.Description;
            gOPBillingList[i].Rate = oData.Rate;
            gOPBillingList[i].DiscountPercentage = oData.DiscountPercentage;
            gOPBillingList[i].DiscountAmount = oData.DiscountAmount;
            gOPBillingList[i].SubTotal = oData.SubTotal;
            gOPBillingList[i].Barcode = oData.Barcode;
            gOPBillingList[i].StatusFlag = oData.StatusFlag;
            gOPBillingList[i].NewProductFlag = oData.NewProductFlag;
        }
    }
    DisplayOPBillingList(gOPBillingList);
    $("#btnAddOPBilling").show();
    $("#btnUpdateOPBilling").hide();
    ClearOPBillingFields();
    $("#ddlProductName").focus();
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
                CalculateAmount();
            }
        }
        for (var i = 0; i < gMagazineData.length; i++) {
            if (gMagazineData[i].SNo == ID) {
                var index = jQuery.inArray(gMagazineData[i].valueOf("SNo"), gMagazineData);
                if (gMagazineData[i].SNo > 0) {
                    gMagazineData[i].StatusFlag = "D";
                } else {
                    gMagazineData.splice(index, 1);
                }
            }
        }
    }
    return false;
}

function CalculateNetPrice() {
    var iAmountPrice = parseFloat($("#txtQuantity").val());


    if (isNaN(iAmountPrice)) iNoofCopies = 0;

    return false;
}

$("#txtSearchName").change(function () {

    if ($("#txtSearchName").val().trim() != "" || $("#txtSearchName").val().trim() != undefined) {
        var iDetails = $("#txtSearchName").val();
        GetSearchRecord(iDetails);
    }
    return false;
});

function GetRecord() {
    dProgress(true);
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/GetSalesOrder",
        data: JSON.stringify({ PublisherID: 0 }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
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
                                //if (obj[index].IsActive == "1") {
                                var table = "";
                                table += "<tr style='background-color:#ebe2dd;' id='" + obj[index].SalesOrderID + "'>";
                                table += "<td>" + (index + 1) + "</td>";
                                table += "<td>" + obj[index].SalesOrderNo + "</td>";
                                table += "<td>" + obj[index].sSalesOrderDate + "</td>";
                                table += "<td>" + obj[index].Customer.CustomerName + "</td>";
                                table += "<td>" + obj[index].TaxAmount + "</td>";
                                table += "<td>" + obj[index].NetAmount + "</td>";

                                if (ActionView == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SalesOrderID + " class='View' title='Click here to View'><i class='fa fa-lg fa-clone text-yellow'/></a></td>"; }
                                else { table += "<td></td>"; }

                                if (ActionUpdate == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SalesOrderID + " class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'/></a></td>"; }
                                else { table += "<td></td>"; }

                                if (ActionDelete == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SalesOrderID + " class='Delete' title='Click here to Cancel'><i class='fa fa-lg fa-times-circle text-red'/></a></td>"; }
                                else { table += "<td></td>"; }

                                table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SalesOrderID + " class='PrintSales' title='Click here to Print SalesOrder'></i><i class='fa fa-print text-green'/></a></td>";
                                table += "</tr>";
                                $("#tblRecord_tbody").append(table);
                                //}
                            }
                            $(".View").click(function () {
                                if (ActionView == "1") {
                                    EditRecord($(this).parent().parent()[0].id);
                                    $("#btnSave").hide();
                                    $("#btnUpdate").hide();
                                    $("#btnPrintbill").show();
                                    viewflag = 1;
                                    $("#btnAddMagazine").hide();
                                    $("#btnUpdateMagazine").hide();
                                }
                                else {
                                    $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                                    return false;
                                }
                            });
                            $(".Edit").click(function () {
                                if (ActionUpdate == "1") {
                                    EditRecord($(this).parent().parent()[0].id);
                                    $("#divOtherPasswordlbl").show();
                                    $("#divOtherPassword").show();
                                    viewflag = 0;
                                }
                                else {
                                    $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                                    return false;
                                }
                            });
                            $(".PrintSales").click(function () {
                                SetSessionValue("SalesOrderID", parseInt($(this).parent().parent()[0].id));
                                var myWindow = window.open("PrintSalesOrder.aspx", "MsgWindow");
                            });
                            $(".Address").click(function () {
                                SetSessionValue("SalesID", $(this).attr('Accountno'));
                                SetSessionValue("Table", "Customer");
                                var myWindow = window.open("frmAddressLabel.aspx", "MsgWindow");
                            });
                            $(".LR").click(function () {
                                SetSessionValue("SalesOrderID", parseInt($(this).parent().parent()[0].id));
                                var myWindow = window.open("frmLREntry.aspx", "MsgWindow");
                            });
                            $(".eSalesOrder").click(function () {

                                ESalesOrder_Export($(this).parent().parent()[0].id, $(this).attr('SalesOrder'));
                            });
                            $(".Delete").click(function () {
                                if (ActionDelete == "1") {
                                    if (confirm('Are you sure to cancel the selected record ?')) { ShowDeleteRecord($(this).parent().parent()[0].id); }
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
                            { "sWidth": "10%" },
                            { "sWidth": "13%" },
                            { "sWidth": "38%" },
                            { "sWidth": "5%" },
                            { "sWidth": "5%" },
                            { "sWidth": "8%" },
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

//function GetSearchRecord(iDetails) {
//    dProgress(true);
//    $.ajax({
//        type: "POST",
//        url: "WebServices/VHMSService.svc/SearchSalesOrder",
//        data: JSON.stringify({ ID: iDetails, IsRetail: 0, IsYarnBill: 0 }),
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        async: false,
//        success: function (data) {
//            if (data.d != "") {
//                var objResponse = jQuery.parseJSON(data.d);
//                if (objResponse.Status == "Success") {
//                    var notetable = $("#tblSearchResult").dataTable();
//                    notetable.fnDestroy();
//                    if (objResponse.Value != null && objResponse.Value != "NoRecord") {
//                        var obj = $.parseJSON(objResponse.Value);
//                        if (obj.length > 0) {
//                            $("#tblSearchResult_tbody").empty();
//                            var TypeStatus = "";
//                            for (var index = 0; index < obj.length; index++) {
//                                var table = "";
//                                table += "<tr style='background-color:#ebe2dd;' id='" + obj[index].SalesOrderID + "'>";
//                                table += "<td>" + (index + 1) + "</td>";
//                                table += "<td>" + obj[index].SalesOrderNo + "</td>";
//                                table += "<td>" + obj[index].sSalesOrderDate + "</td>";
//                                table += "<td>" + obj[index].Customer.CustomerName + "</td>";
//                                table += "<td>" + obj[index].TaxAmount + "</td>";
//                                table += "<td>" + obj[index].NetAmount + "</td>";

//                                if (ActionView == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SalesOrderID + " class='View' title='Click here to View'><i class='fa fa-lg fa-clone text-yellow'/></a></td>"; }
//                                else { table += "<td></td>"; }

//                                if (ActionUpdate == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SalesOrderID + " class='Edit' title='Click here to Edit'><i class='fa fa-lg fa-edit'/></a></td>"; }
//                                else { table += "<td></td>"; }

//                                if (ActionDelete == "1") { table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SalesOrderID + " class='Delete' title='Click here to Cancel'><i class='fa fa-lg fa-times-circle text-red'/></a></td>"; }
//                                else { table += "<td></td>"; }

//                                table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SalesOrderID + " class='PrintSales' title='Click here to Print SalesOrder'></i><i class='fa fa-print text-green'/></a></td>";
//                                table += "</tr>";
//                                    $("#tblSearchResult_tbody").append(table);
//                                }
//                            }
//                            $(".View").click(function () {
//                                if (ActionView == "1") {
//                                    EditRecord($(this).parent().parent()[0].id);
//                                    $("#btnSave").hide();
//                                    $("#btnUpdate").hide();
//                                    viewflag = 1;
//                                    $("#btnPrintbill").show();
//                                    $("#btnAddMagazine").hide();
//                                    $("#btnUpdateMagazine").hide();
//                                }
//                                else {
//                                    $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
//                                    return false;
//                                }
//                            });
//                            $(".Edit").click(function () {
//                                if (ActionUpdate == "1") {
//                                    EditRecord($(this).parent().parent()[0].id);
//                                    $("#divOtherPasswordlbl").show();
//                                    $("#divOtherPassword").show();
//                                    viewflag = 0;
//                                }
//                                else {
//                                    $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
//                                    return false;
//                                }
//                            });
//                            $(".Address").click(function () {
//                                SetSessionValue("SalesID", $(this).attr('Accountno'));
//                                SetSessionValue("Table", "Customer");
//                                var myWindow = window.open("frmAddressLabel.aspx", "MsgWindow");
//                            });
//                            $(".LR").click(function () {
//                                SetSessionValue("SalesOrderID", parseInt($(this).parent().parent()[0].id));
//                                var myWindow = window.open("frmLREntry.aspx", "MsgWindow");
//                            });
//                            $(".PrintSales").click(function () {
//                                SetSessionValue("SalesOrderID", parseInt($(this).parent().parent()[0].id));
//                                var myWindow = window.open("PrintSalesOrder.aspx", "MsgWindow");
//                            });
//                            $(".eSalesOrder").click(function () {
//                                ESalesOrder_Export($(this).parent().parent()[0].id, $(this).attr('SalesOrder'));
//                            });
//                            $(".Delete").click(function () {
//                                if (ActionDelete == "1") {
//                                    if (confirm('Are you sure to cancel the selected record ?')) { ShowDeleteRecord($(this).parent().parent()[0].id); }
//                                }
//                                else {
//                                    $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
//                                    return false;
//                                }
//                            });
//                        }
//                        dProgress(false);
//                    }
//                    else if (objResponse.Value == "NoRecord") {
//                        $("#tblSearchResult_tbody").empty();
//                        dProgress(false);
//                    }
//                    $("#tblSearchResult").dataTable({
//                        "bPaginate": true,
//                        "bFilter": true,
//                        "bSort": true,
//                        "iDisplayLength": 25,
//                        aoColumns: [
//                            { "sWidth": "5%" },
//                            { "sWidth": "10%" },
//                            { "sWidth": "13%" },
//                            { "sWidth": "38%" },
//                            { "sWidth": "5%" },
//                            { "sWidth": "5%" },
//                            { "sWidth": "8%" },
//                            { "sWidth": "2%" },
//                            { "sWidth": "2%" },
//                            { "sWidth": "2%" }
//                        ]
//                    });
//                    $("#tblSearchResult_filter").addClass('pull-right');
//                    $(".pagination").addClass('pull-right');
//                }
//                else if (objResponse.Status == "Error") {
//                    if (objResponse.Value == "0") {
//                        window.location("frmLogin.aspx");
//                    }
//                    else if (objResponse.Value == "Error") {
//                        window.location = "frmErrorPage.aspx";
//                    }
//                }
//            }
//            else {
//                $("#tblSearchResult_tbody").empty();
//                dProgress(false);
//            }
//        },
//        error: function (e) {
//            $.jGrowl("Error  Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
//            dProgress(false);
//        }
//    });
//    return false;
//}

$("#ddlTaxName").change(function () {
    var iTaxID = $("#ddlTaxName").val();
    $("#ddlTax").val($("#ddlTaxName").val()).change();
    if (iTaxID != undefined && iTaxID > 0) {
        GetTaxByID(iTaxID);
        var iSubtotal = 0;
        for (var i = 0; i < gOPBillingList.length; i++) {
            if (gOPBillingList[i].StatusFlag != "D") {
                iSubtotal = gOPBillingList[i].SubTotal;
                gOPBillingList[i].Tax.TaxID = iTaxID;
                gOPBillingList[i].Tax.TaxPercentage = parseFloat($("#hdnTaxPercent").val());
                if ($("#hdnStateCode").val() == 33) {
                    gOPBillingList[i].Tax.CGSTPercent = parseFloat($("#hdnCGSTPercent").val());
                    gOPBillingList[i].Tax.SGSTPercent = parseFloat($("#hdnSGSTPercent").val());
                    gOPBillingList[i].Tax.IGSTPercent = 0;
                    gOPBillingList[i].CGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.CGSTPercent) / 100).toFixed(2);
                    gOPBillingList[i].SGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.SGSTPercent) / 100).toFixed(2);
                    gOPBillingList[i].IGSTAmount = 0;
                }
                else {
                    gOPBillingList[i].Tax.CGSTPercent = 0;
                    gOPBillingList[i].Tax.SGSTPercent = 0;
                    gOPBillingList[i].Tax.IGSTPercent = parseFloat($("#hdnIGSTPercent").val());
                    gOPBillingList[i].CGSTAmount = 0;
                    gOPBillingList[i].SGSTAmount = 0;

                    gOPBillingList[i].IGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.IGSTPercent) / 100).toFixed(2);
                }
                gOPBillingList[i].TaxAmount = (parseFloat(gOPBillingList[i].CGSTAmount) + parseFloat(gOPBillingList[i].SGSTAmount) + parseFloat(gOPBillingList[i].IGSTAmount)).toFixed(2);
            }
        }
        DisplayOPBillingList(gOPBillingList);
        CalculateAmount();
    }
});

$("#ddlTax").change(function () {
    var iTax = $("#ddlTax").val();
    if (iTax != undefined && iTax > 0) {
        GetTaxTransByID(iTax);
        CalculateAmountTrans();
    }
});

function GetTaxTransByID(id) {
    dProgress(true);
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/GetTaxByID",
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
                            $("#hdnTransTaxPercent").val(obj.TaxPercentage);
                            $("#hdnTransCGSTPercent").val(obj.CGSTPercent);
                            $("#hdnTransSGSTPercent").val(obj.SGSTPercent);
                            $("#hdnTransIGSTPercent").val(obj.IGSTPercent);
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

function CalculateAmountTrans() {
    var iTax = parseFloat($("#hdnTransTaxPercent").val());
    var iRate = parseFloat($("#txtRate").val());
    var iqty = parseFloat($("#txtQuantity").val());
    var iCGST = parseFloat($("#hdnTransCGSTPercent").val());
    var iSGST = parseFloat($("#hdnTransSGSTPercent").val());
    var iIGST = parseFloat($("#hdnTransIGSTPercent").val());

    if (isNaN(iRate)) iRate = 0;
    if (isNaN(iqty)) iqty = 0;
    if (isNaN(iTax)) iTax = 0;
    var iTaxPercent = parseFloat(iRate) * parseFloat(iqty) * parseFloat(iTax) / 100;
    $("#txtTaxAmt").val(parseFloat(iTaxPercent).toFixed(2));

    if ($("#hdnStateCode").val() == 33) {
        var iCGSTPercent = parseFloat(iRate) * parseFloat(iqty) * parseFloat(iCGST) / 100;
        var iSGSTPercent = parseFloat(iRate) * parseFloat(iqty) * parseFloat(iSGST) / 100;
        $("#hdnTransSGSTAmount").val(parseFloat(iSGSTPercent).toFixed(2));
        $("#hdnTransCGSTAmount").val(parseFloat(iCGSTPercent).toFixed(2));
        $("#hdnTransIGSTAmount").val(0)
    }
    else {
        var iIGSTPercent = parseFloat(iRate) * parseFloat(iqty) * parseFloat(iIGST) / 100;
        $("#hdnTransSGSTAmount").val(0);
        $("#hdnTransCGSTAmount").val(0);
        $("#hdnTransIGSTAmount").val(parseFloat(iIGSTPercent).toFixed(2))
    }
    var iSubTotal = (parseFloat(iRate) * parseFloat(iqty));
    $("#txtSubTotal").val(parseFloat(iSubTotal).toFixed(2));
    CalculateAmount();
}

//$("#txtDiscountAmount").change(function () {
//    CalculateAmount();
//});

$("#txtRoundoff,#txtOtherCharges").change(function () {
    CalculateAmount();
});

$("#txtTransportCharge").change(function () {
    var iqty = parseFloat($("#txtTransportCharge").val());
    if (isNaN(iqty)) iqty = 0;
    $("#txtOtherCharges").val(iqty).change();
});

function GetTaxByID(id) {
    dProgress(true);
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/GetTaxByID",
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
                            $("#hdnTaxPercent").val(obj.TaxPercentage);
                            $("#hdnCGSTPercent").val(obj.CGSTPercent);
                            $("#hdnSGSTPercent").val(obj.SGSTPercent);
                            $("#hdnIGSTPercent").val(obj.IGSTPercent);
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

function CalculateAmount() {
    var iOPBillingAmount = 0, TotalAmount = 0, iBillingQty = 0, RoundOff = 0, Amount = 0, iBillingCGST = 0, iBillingSGST = 0, iBillingIGST = 0, iBillingDiscount = 0, iBillingTaxAmt = 0;
    for (var i = 0; i < gOPBillingList.length; i++) {
        if (gOPBillingList[i].StatusFlag != "D") {
            iOPBillingAmount = iOPBillingAmount + parseFloat(gOPBillingList[i].SubTotal);
            iBillingTaxAmt = iBillingTaxAmt + parseFloat(gOPBillingList[i].TaxAmount);
            iBillingCGST = iBillingCGST + parseFloat(gOPBillingList[i].CGSTAmount);
            iBillingSGST = iBillingSGST + parseFloat(gOPBillingList[i].SGSTAmount);
            iBillingIGST = iBillingIGST + parseFloat(gOPBillingList[i].IGSTAmount);
            iBillingDiscount = iBillingDiscount + parseFloat(gOPBillingList[i].DiscountAmount);
            iBillingQty = iBillingQty + parseFloat(gOPBillingList[i].Quantity);
            TotalAmount = TotalAmount + (parseFloat(gOPBillingList[i].Rate) * parseFloat(gOPBillingList[i].Quantity));
        }
    }

    $("#txtAmount").val(parseFloat(TotalAmount).toFixed(2));
    $("#txtTotalAmount").val(parseFloat(iOPBillingAmount).toFixed(2));

    $("#txtTotalTaxAmount").val((parseFloat(iBillingTaxAmt) + parseFloat(iOPBillingAmount)).toFixed(2));

    $("#txtTaxAmount").val(parseFloat(iBillingTaxAmt).toFixed(2));
    $("#txtCGST").val(parseFloat(iBillingCGST).toFixed(2));
    $("#txtSGST").val(parseFloat(iBillingSGST).toFixed(2));
    $("#txtIGST").val(parseFloat(iBillingIGST).toFixed(2));
    $("#txtDiscountAmount").val(parseFloat(iBillingDiscount).toFixed(2));

    $("#txtTotalQty").val((parseFloat(iBillingQty)).toFixed(0));
    Amount = (parseFloat(iOPBillingAmount) + parseFloat($("#txtTaxAmount").val())).toFixed(2);

    RoundOff = Math.round(Amount);
    $("#txtRoundoff").val((RoundOff - Amount).toFixed(2));
    var iround = parseFloat($("#txtRoundoff").val());
    if (isNaN(iround)) iround = 0;
    $("#txtNetAmount").val((parseFloat(iOPBillingAmount) + parseFloat($("#txtTaxAmount").val()) + parseFloat(iround)).toFixed(2));
    var iNet = parseFloat($("#txtNetAmount").val());
    if (isNaN(iNet)) iNet = 0;

}

$("#btnPrint").click(function () {
    SetSessionValue("SalesOrderID", $("#hdnSalesOrderID").val());
    var myWindow = window.open("PrintSalesOrder.aspx", "MsgWindow");
});

$("#btnSave,#btnUpdate").click(function () {
    //CalculateAmountTrans();  
    TaxCalculate();
    $("#ddlTaxName").change();
    if (this.id == "btnSave") {
        if (ActionAdd != "1") { $.jGrowl("Access Denied", { sticky: false, theme: 'danger', life: jGrowlLife }); return false; }
    }
    else if (this.id == "btnUpdate") {
        if (ActionUpdate != "1") { $.jGrowl("Access Denied", { sticky: false, theme: 'danger', life: jGrowlLife }); return false; }
    }

    if ($("#txtBillDate").val().trim() == "" || $("#txtBillDate").val().trim() == undefined) {
        $.jGrowl("Please select Bill Date", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divBillDate").addClass('has-error'); $("#txtBillDate").focus(); return false;
    }
    else { $("#divBillDate").removeClass('has-error'); }

    if ($("#txtBillNo").val().trim() == "" || $("#txtBillNo").val().trim() == undefined) {
        $.jGrowl("Please enter Bill No", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divBillNo").addClass('has-error'); $("#txtBillNo").focus(); return false;
    }
    else { $("#divBillNo").removeClass('has-error'); }


    if ($("#ddlTaxName").val() == "0" || $("#ddlTaxName").val() == undefined || $("#ddlTaxName").val() == null) {
        $.jGrowl("Please select Tax", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divTaxName").addClass('has-error'); $("#ddlTaxName").focus(); return false;
    }
    else { $("#divTaxName").removeClass('has-error'); }



    var ObjOPBilling = new Object();

    ObjOPBilling.SalesOrderID = 0;
    ObjOPBilling.SalesOrderNo = $("#txtBillNo").val().trim();
    ObjOPBilling.sSalesOrderDate = $("#txtBillDate").val().trim();
    ObjOPBilling.SalesOrderTrans = gOPBillingList;
    var ObjCustomer = new Object();
    ObjCustomer.CustomerID = $("#ddlCustomerName").val();
    ObjOPBilling.Customer = ObjCustomer;

    var ObjCompany = new Object();
    ObjCompany.CompanyID = $("#ddlCompany").val();
    ObjOPBilling.Company = ObjCompany;

    var ObjTax = new Object();
    ObjTax.TaxID = $("#ddlTaxName").val();
    ObjOPBilling.Tax = ObjTax;
    ObjOPBilling.TaxPercent = $("#hdnTaxPercent").val().trim();
    ObjOPBilling.DiscountPercent = $("#txtDiscountPercent").val();
    ObjOPBilling.DiscountAmount = $("#txtDiscountAmount").val();
    ObjOPBilling.DiscountPercent = $("#txtDiscountPercent").val();
    ObjOPBilling.CGSTAmount = $("#txtCGST").val().trim();
    ObjOPBilling.SGSTAmount = $("#txtSGST").val().trim();
    ObjOPBilling.IGSTAmount = $("#txtIGST").val().trim();
    ObjOPBilling.TaxAmount = $("#txtTaxAmount").val().trim();
    ObjOPBilling.TotalAmount = $("#txtTotalAmount").val().trim();
    var Roundoff = parseFloat($("#txtRoundoff").val());
    if (isNaN(Roundoff))
        ObjOPBilling.Roundoff = 0;
    else
        ObjOPBilling.Roundoff = $("#txtRoundoff").val().trim();
    ObjOPBilling.NetAmount = $("#txtNetAmount").val().trim();
    ObjOPBilling.IsActive = 1;
    ObjOPBilling.RetailPaymentMode = [];

    if ($("#hdnSalesID").val() > 0) {
        ObjOPBilling.SalesOrderID = $("#hdnSalesID").val();
        gOPBillingList.SalesOrderID = ObjOPBilling.SalesOrderID;
        sMethodName = "UpdateSalesOrder";
    }
    else {
        sMethodName = "AddSalesOrder";
        ObjOPBilling.SalesOrderID = 0;
    }

    SaveandUpdateOPBilling(ObjOPBilling, sMethodName);

});

function SaveandUpdateOPBilling(ObjOPBilling, sMethodName) {
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/" + sMethodName,
        data: JSON.stringify({ Objdata: ObjOPBilling }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.d != "") {
                var objResponse = jQuery.parseJSON(data.d);
                if (objResponse.Status == "Success") {
                    if (objResponse.Value > 0) {
                        ClearOPBillingTab();
                        GetRecord();
                        $("#btnAddNew").show();
                        $("#btnList").hide();
                        $("#divTab").show();
                        $("#secHeader").removeClass('hidden');
                        $("#divOPBilling").hide();
                        if (sMethodName == "AddSalesOrder") {
                            $.jGrowl("Added Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
                            $("#hdnSalesOrderID").val(objResponse.Value);
                            EditRecord($("#hdnSalesOrderID").val());
                            $("#btnSave").hide();
                            $("#btnUpdate").hide();
                            $("#btnPrintbill").show();
                            $("#btnAddMagazine").hide();
                            $("#btnUpdateMagazine").hide();
                        }
                        else if (sMethodName == "UpdateSalesOrder") {
                            $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
                            EditRecord(ObjOPBilling.SalesOrderID);
                            $("#btnSave").hide();
                            $("#btnUpdate").hide();
                            $("#btnPrintbill").show();
                            $("#btnAddMagazine").hide();
                            $("#btnUpdateMagazine").hide();
                        }
                    }
                }
                else if (objResponse.Status == "Error") {
                    if (objResponse.Value == "0") {
                        window.location = "frmLogin.aspx";
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


$("#btnPrintbill").click(function () {
    SetSessionValue("SalesOrderID", $("#hdnSalesOrderID").val());
    var myWindow = window.open("PrintSalesOrder.aspx", "MsgWindow");
});

function EditRecord(id) {
    dProgress(true);
    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/GetSalesOrderByID",
        data: JSON.stringify({ ID: id, IsRetail: 0, IsYarnBill: 0 }),
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
                            $("#btnPrintbill").show();
                            $("#txtOtherPassword").val("");
                            $("#txtBillNo").attr("disabled", true);
                            $("#hdnSalesID").val(obj.SalesOrderID)
                            $("#hdnSalesOrderID").val(obj.SalesOrderID)
                            $("#txtBillNo").val(obj.SalesOrderNo);
                            $("#txtBillDate").val(obj.sSalesOrderDate);
                            ;
                            $("#txtRoundoff").val(obj.Roundoff);
                            $("#txtNetAmount").val(obj.NetAmount);
                            $("#ddlCustomerName").val(obj.Customer.CustomerID).change();
                            $("#ddlTaxName").val(obj.Tax.TaxID).change();
                            $("#ddlCompany").val(obj.Company.CompanyID).change();
                            $("#txtCGST").val(obj.CGSTAmount);
                            $("#txtSGST").val(obj.SGSTAmount);
                            $("#txtIGST").val(obj.IGSTAmount);
                            $("#txtDiscountPercent").val(obj.DiscountPercentage);
                            $("#txtDiscountAmount").val(obj.DiscountAmount);
                            $("#hdnNetAmt").val(obj.NetAmount);

                            gOPBillingList = [];
                            var ObjProduct = obj.SalesOrderTrans;
                            for (var index = 0; index < ObjProduct.length; index++) {
                                var objTemp = new Object();
                                objTemp.sNO = index + 1;
                                objTemp.SNo = objTemp.sNO;
                                objTemp.StatusFlag = "U";

                                var objMagazine = new Object();
                                objMagazine.ProductID = ObjProduct[index].Product.ProductID;
                                objMagazine.ProductName = ObjProduct[index].Product.ProductName;
                                objTemp.Product = objMagazine;

                                var objTransTax = new Object();
                                objTransTax.TaxID = ObjProduct[index].Tax.TaxID;
                                objTransTax.TaxPercentage = ObjProduct[index].Tax.TaxPercentage;
                                objTransTax.CGSTPercent = ObjProduct[index].Tax.CGSTPercent;
                                objTransTax.SGSTPercent = ObjProduct[index].Tax.SGSTPercent;
                                objTransTax.IGSTPercent = ObjProduct[index].Tax.IGSTPercent;
                                objTemp.Tax = objTransTax;


                                objTemp.SalesOrderTransID = ObjProduct[index].SalesOrderTransID;
                                objTemp.SalesOrderID = ObjProduct[index].SalesOrderID;
                                objTemp.Quantity = ObjProduct[index].Quantity;
                                objTemp.Description = ObjProduct[index].Description;
                                objTemp.HSNCode = ObjProduct[index].HSNCode;
                                objTemp.TaxAmount = ObjProduct[index].TaxAmount;
                                objTemp.SGSTAmount = ObjProduct[index].SGSTAmount;
                                objTemp.IGSTAmount = ObjProduct[index].IGSTAmount;
                                objTemp.CGSTAmount = ObjProduct[index].CGSTAmount;
                                objTemp.Rate = ObjProduct[index].Rate;
                                objTemp.SubTotal = ObjProduct[index].SubTotal;
                                objTemp.DiscountPercentage = ObjProduct[index].DiscountPercentage;
                                objTemp.DiscountAmount = ObjProduct[index].DiscountAmount;
                                AddOPBillingData(objTemp);
                                gMagazineData.push(objTemp);
                            }

                            CalculateAmount();
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

function ShowDeleteRecord(id) {
    $(".modal-title").html("<i class='fa fa-plus-square'></i>&nbsp;&nbsp; Cancel Bill");
    $('#compose-modal').modal({ show: true, backdrop: true });
    $("#txtID").val(id);
    $("#txtReason").focus();
    return false;
}

$("#btnOK").click(function () {

    if ($("#txtPassword").val().trim() == "" || $("#txtPassword").val().trim() == undefined || $("#txtPassword").val().trim() != $("#hdRS").val()) {
        $.jGrowl("Please enter Valid Password", { sticky: false, theme: 'warning', life: jGrowlLife });
        $("#divPassword").addClass('has-error'); $("#txtPassword").focus(); return false;
    } else { $("#divPassword").removeClass('has-error'); }

    DeleteRecord($("#txtID").val(), '');

});

function ClearCancelData() {
    $("#txtID").val("");
    $("#txtReason").val("");
    $('#compose-modal').modal('hide');
}

$("#txtDiscountPercent").change(function () {
    if ($("#hdnMaxsalesDiscount").val() > 0) {
        if (parseFloat($("#hdnMaxsalesDiscount").val()) < parseFloat($("#txtDiscountPercent").val())) {
            $.jGrowl(" Discount Percentage Exceeding Maximum discount", { sticky: false, theme: 'warning', life: jGrowlLife });
            $("#txtDiscountPercent").focus(); return false;
        }
    }

    var iDisPercent = parseFloat($("#txtDiscountPercent").val());
    $("#txtDisPer").val($("#txtDiscountPercent").val()).change();
    if (isNaN(iDisPercent)) iDisPercent = 0;
    var iSubtotal = 0; var iDiscAmt = 0;
    for (var i = 0; i < gOPBillingList.length; i++) {
        if (gOPBillingList[i].StatusFlag != "D") {
            gOPBillingList[i].DiscountPercentage = iDisPercent;
            gOPBillingList[i].DiscountAmount = parseFloat(gOPBillingList[i].Quantity) * parseFloat(gOPBillingList[i].Rate) * iDisPercent / 100;
            iSubtotal = (parseFloat(gOPBillingList[i].Quantity) * parseFloat(gOPBillingList[i].Rate)) - parseFloat(gOPBillingList[i].DiscountAmount);
            gOPBillingList[i].SubTotal = parseFloat(iSubtotal).toFixed(2);
            if ($("#hdnStateCode").val() == 33) {
                gOPBillingList[i].CGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.CGSTPercent) / 100).toFixed(2);
                gOPBillingList[i].SGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.SGSTPercent) / 100).toFixed(2);
                gOPBillingList[i].IGSTAmount = 0;
            }
            else {
                gOPBillingList[i].CGSTAmount = 0;
                gOPBillingList[i].SGSTAmount = 0;
                gOPBillingList[i].IGSTAmount = (parseFloat(iSubtotal) * parseFloat(gOPBillingList[i].Tax.IGSTPercent) / 100).toFixed(2);
            }
            gOPBillingList[i].TaxAmount = (parseFloat(gOPBillingList[i].CGSTAmount) + parseFloat(gOPBillingList[i].SGSTAmount) + parseFloat(gOPBillingList[i].IGSTAmount)).toFixed(2);
        }
    }
    DisplayOPBillingList(gOPBillingList);
    CalculateAmount();
});


function DeleteRecord(id, Reason) {

    $.ajax({
        type: "POST",
        url: "WebServices/VHMSService.svc/DeleteSalesOrder",
        data: JSON.stringify({ ID: id, Reason: Reason }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.d != "") {
                var objResponse = jQuery.parseJSON(data.d);
                if (objResponse.Status == "Success") {
                    if (objResponse.Value > 0) {
                        ClearCancelData();
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

$("#aGeneral").click(function () {
    $("#SearchResult").hide();
    GetRecord();
});

$("#aSearchResult").click(function () {
    $("#SearchResult").show();

});

$("#btnCancel").click(function () {
    $('#compose-modal').modal('hide');
    return false;
});

$("#btnRateCancel").click(function () {
    $('#composeRate').modal('hide');
    return false;
});

$("#btndetailsCancel").click(function () {
    $('#composedetails').modal('hide');
    return false;
});

$("#btnImageCancel").click(function () {
    $('#composeImage').modal('hide');
    return false;
});


$("#btnProductImageCancel").click(function () {
    $('#composeProductImage').modal('hide');
    return false;
});

