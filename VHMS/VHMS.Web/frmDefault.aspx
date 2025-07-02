<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/VHMSMasterPage.master" AutoEventWireup="true" CodeFile="frmDefault.aspx.cs" Inherits="frmDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="VHMSWebHead" runat="Server">
    <style>
        .mt-custom {
            margin-top: 10px; /* Or any value you prefer */
        }

        .table td, .table th {
            padding: 0.7rem 1rem;
        }
    </style>
    <style>
        .blink-heading {
            animation: blink 1s infinite;
            font-weight: bold;
        }

        @keyframes blink {
            0%, 100% {
                opacity: 1;
            }

            50% {
                opacity: 0;
            }
        }
    </style>

    <style>
        .small-box {
            border-radius: 1rem;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            position: relative;
            overflow: hidden;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
            color: #fff;
        }

            .small-box:hover {
                transform: translateY(-5px);
                box-shadow: 0 6px 20px rgba(0, 0, 0, 0.2);
            }

            .small-box .inner h4 {
                font-size: 2rem;
                font-weight: bold;
            }

            .small-box .inner p {
                margin: 0;
                font-size: 1rem;
                font-weight: 500;
            }

            .small-box .icon {
                position: absolute;
                top: -10px;
                right: 10px;
                font-size: 4rem;
                opacity: 0.15;
            }

        .small-box-footer {
            display: block;
            padding: 0.5rem;
            background-color: rgba(0, 0, 0, 0.15);
            text-align: center;
            font-weight: 500;
            text-decoration: none;
            color: #fff;
            border-top: 1px solid rgba(255, 255, 255, 0.15);
            transition: background 0.3s ease;
        }

            .small-box-footer:hover {
                background-color: rgba(0, 0, 0, 0.3);
            }
    </style>




    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css" />
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <link rel="stylesheet" href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css" />
    <%--<link rel="stylesheet" href="plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" />--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />

    <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <link rel="stylesheet" href="plugins/jqvmap/jqvmap.min.css" />
    <link rel="stylesheet" href="css/adminlte.min.css" />
    <link rel="stylesheet" href="plugins/summernote/summernote-bs4.css" />
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet" />
    <script src="plugins/jquery/jquery.min.js"></script>
    <script src="plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
    <script src="JS/adminlte.js"></script>
    <script src="JS/demo.js"></script>
    <script src="plugins/jquery-mousewheel/jquery.mousewheel.js"></script>
    <%--<script src="plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>--%>
    <script src="plugins/summernote/summernote-bs4.min.js"></script>
    <script src="plugins/raphael/raphael.min.js"></script>
    <script src="plugins/jquery-mapael/jquery.mapael.min.js"></script>
    <script src="plugins/jquery-mapael/maps/usa_states.min.js"></script>
    <script src="plugins/chart.js/Chart.min.js"></script>
    <script src="plugins/jqvmap/jquery.vmap.min.js"></script>
    <script src="plugins/jqvmap/maps/jquery.vmap.usa.js"></script>
    <script src="plugins/jquery-knob/jquery.knob.min.js"></script>
    <script src="plugins/jquery-ui/jquery-ui.min.js"></script>
    <script src="plugins/sparklines/sparkline.js"></script>
    <script src="plugins/moment/moment.min.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>
        $.widget.bridge('uibutton', $.ui.button)
    </script>

    <div class="container-fluid mt-4 position-relative">
        <div style="position: absolute; left: -30px; top: 10px;">
            <i class="fas fa-bell fa-2x text-warning swing-animation"></i>
        </div>
        <div style="position: absolute; right: -30px; top: 10px;">
            <i class="fas fa-bell fa-2x text-warning swing-animation"></i>
        </div>
        <div class="row g-3">
        </div>
    </div>


</asp:Content>

<asp:Content ID="Cokntent2" ContentPlaceHolderID="VHMSWebContent" runat="Server">
    <div class="container-fluid mt-4">
        <section class="content-header" id="secHeader">
        </section>
        
        <div class="row g-4">
    <div class="col-lg-3 col-md-6">
        <div class="small-box" style="background: linear-gradient(90deg, #11998e, #38ef7d);">
            <div class="inner">
                <h4 id="lblTotalProduct">0</h4>
                <p style="color: #fff;">Total Number of Leads</p>
            </div>
            <div class="icon"><i class="fas fa-praying-hands"></i></div>
            <a href="frmProduct.aspx" class="small-box-footer" style="color: #fff;">More info <i class="fas fa-arrow-circle-right"></i></a>
        </div>
    </div>

    <div class="col-lg-3 col-md-6">
        <div class="small-box" style="background: linear-gradient(90deg, #00c6ff, #0072ff); color: #fff;">
            <div class="inner">
                <h4 id="lblTotalCustomer">0</h4>
                <p style="color: #fff;">Total Number of Call</p>
            </div>
            <div class="icon"><i class="fas fa-users"></i></div>
            <a href="frmCustomer.aspx" class="small-box-footer" style="color: #fff;">More info <i class="fas fa-arrow-circle-right"></i></a>
        </div>
    </div>

    <div class="col-lg-3 col-md-6">
        <div class="small-box" style="background: linear-gradient(90deg, #f7971e, #ffd200); color: #000;">
            <div class="inner">
                <h4 id="lblTotalSupplier">0</h4>
                <p style="color: #000;">Total Follow Up</p>
            </div>
            <div class="icon"><i class="fas fa-truck-loading"></i></div>
            <a href="frmBSupplier.aspx" class="small-box-footer" style="color: #000;">More info <i class="fas fa-arrow-circle-right"></i></a>
        </div>
    </div>

    <div class="col-lg-3 col-md-6">
        <div class="small-box" style="background: linear-gradient(90deg, #8e2de2, #4a00e0); color: #fff;">
            <div class="inner">
                <h4 id="lblTotalSales">0</h4>
                <p style="color: #fff;">Wrong Lead</p>
            </div>
            <div class="icon"><i class="fas fa-cash-register"></i></div>
            <a href="frmSalesEntry.aspx" class="small-box-footer" style="color: #fff;">More info <i class="fas fa-arrow-circle-right"></i></a>
        </div>
    </div>
</div>


        <section class="content">
            <div class="row text-center mb-3">
                <div class="col-12">
                    <div class="d-flex justify-content-center flex-wrap gap-2" id="monthButtonsContainer">
                    </div>
                </div>
            </div>
            <div class="row g-3 mt-3" style="margin-top: 1%;">
                <div class="col-md-6">
                    <div class="card shadow-sm p-2">
                        <canvas id="financialChart" style="height: 300px;"></canvas>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card shadow-sm p-2">
                        <canvas id="topSellingChart" style="height: 300px;"></canvas>
                    </div>
                </div>
            </div>
        </section>
        <section class="content">
            <div class="row g-4">
                <div class="col-md-12">
                    <div class="card shadow border-0 rounded-4 overflow-hidden h-100">
                        <div class="card-header bg-white border-bottom text-center py-4">
                            <h4 class="text-danger fw-bold mb-0">
                                <i class="fas fa-boxes me-2"></i>FollOw Up
                            </h4>
                            <p class="text-muted mb-0 small">Check real-time ollOw Up</p>
                        </div>
                        <div class="card-body px-0">
                            <div class="table-responsive px-3" style="max-height: 320px; overflow-y: auto;">
                                <table id="tblstock" class="table table-hover align-middle mb-0">
                                    <thead class="bg-gradient text-white" style="background: linear-gradient(90deg, #ff416c, #ff4b2b);">
                                        <tr>
                                            <th class="text-center">#</th>
                                            <th>Customer Name</th>
                                            <th>Mobile No</th>
                                            <th>Address</th>
                                            <th class="text-center">Status</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tblstock_tbody" class="table-light">
                                        <!-- rows here -->
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <input type="hidden" id="hdnID" />
    <input type="hidden" id="RoleID" />
    <script type="text/javascript">
        $(document).ready(function () {
            ActionAdd = '<%=Session["ActionAdd"]%>';
            ActionUpdate = '<%=Session["ActionUpdate"]%>';
            ActionDelete = '<%=Session["ActionDelete"]%>';
            ActionView = '<%=Session["ActionView"]%>';
            var _RoleID = '<%=Session["RoleID"]%>';
            $("#RoleID").val(_RoleID);
            $("#divMobileNo").hide();
            $("#txtVoucherDate,#txtIssueDate,#txtCollectionDate").attr("data-link-format", "dd/MM/yyyy");
            $("#txtVoucherDate,#txtIssueDate,#txtCollectionDate").datetimepicker({
                pickTime: false,
                useCurrent: true,
                format: 'DD/MM/YYYY'
            });
            pLoadingSetup(false);
            pLoadingSetup(true);
            $("#divTab").hide();
            $("#btnSend").hide();
            $("#divTabNotification").hide();
            $("#btnSendNotification").hide();
            $("#ContainerID1").hide();
        });


        $("#btnClear").click(function () {
            // ClearFields();
            $("#btnSave").show();
            // $("#divPendingBill").hide();
            // gOPBillingList = [];





            // DisplayPendingBillList(gOPBillingList);
            // DisplayOPBillingList(gOPBillingList);
            $("#btnUpdate").hide();
            $(".modal-title").html("<i class='fa fa-plus-square'></i>&nbsp;&nbsp;Clear Amount");
            $('#compose-modal1').modal({ show: true, backdrop: true });

            return false;
        });

        function GetPendingBill() {
            gOPBillingList = [];
            DisplayPendingBillList(gOPBillingList);
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetAmountClearEntry",
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
                                    DisplayPendingBillList(obj);
                                }
                                dProgress(false);
                            }
                            else if (objResponse.Value == "NoRecord") {
                                dProgress(false);
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

        function DisplayPendingBillList(gData) {
            var sTable = "";
            var sCount = 1;
            var sColorCode = "bg-info";
            gvalue = [];
            $("#txtBalanceAmount").val(0);
            if (gData.length >= 20) { $("#divPendingBillList").css({ 'height': '10px', 'min-height': '690px', 'overflow': 'auto' }); }
            else { $("#divPendingBillList").css({ 'height': '', 'min-height': '' }); }

            if (gData.length > 0) {
                $("#divPendingBill").show();
                sTable = "<table id='tblPendingBillList' class='table no-margin table-condensed table-hover'>";
                sTable += "<thead><tr><th class='" + sColorCode + "' style='width:3px;text-align: center'>S.No</th>";
                sTable += "<th class='" + sColorCode + "'>Invoice No</th>";
                sTable += "<th class='" + sColorCode + "'>Date</th>";
                sTable += "<th class='" + sColorCode + "'>Payment Mode</th>";
                sTable += "<th class='" + sColorCode + "'>Amount</th>";
                sTable += "</tr></thead><tbody id='tblPendingBillList_body'>";
                sTable += "</tbody></table>";
                var sPaymentMode = ""; var BalanceValue = 0;
                $("#divPendingBillList").html(sTable);
                for (var i = 0; i < gData.length; i++) {

                    sTable = "<tr><td id='" + gData[i].SNo + "'>" + sCount + "</td>";
                    if ($("#hdnID").val() > 0) {
                        sTable += "<td style='line-height:0.5;'><label><input id='chk_" + gData[i].SalesEntry.SalesEntryID + "' type='checkbox' value='" + gData[i].SalesEntry.SalesEntryID + "'  name='PurchaseName'  disabled='disabled'/>&nbsp;" + gData[i].SalesEntry.InvoiceNo + "</label></td>";
                    }
                    else {
                        sTable += "<td style='line-height:0.5;'><label><input id='chk_" + gData[i].SalesEntry.SalesEntryID + "' type='checkbox' value='" + gData[i].SalesEntry.SalesEntryID + "'  name='PurchaseName'/>&nbsp;" + gData[i].SalesEntry.InvoiceNo + "</label></td>";
                    }
                    sTable += "<td style='line-height:0.5;'>" + gData[i].SalesEntry.sInvoiceDate + "</td>";
                    sTable += "<td style='line-height:0.5;'>" + gData[i].PaymentMode + "</td>";
                    sTable += "<td style='line-height:0.5;'>" + gData[i].Amount + "</td>";
                    sTable += "</tr>";
                    sCount = sCount + 1;
                    $("#tblPendingBillList_body").append(sTable);
                    BalanceValue += gData[i].Amount;
                    var objAgent = new Object();
                    objAgent.SalesEntryID = gData[i].SalesEntryID;
                    objAgent.Amount = gData[i].Amount;
                    gvalue.push(objAgent);
                }
                $("#txtBalanceAmount").val(BalanceValue);
            }
            else {
                $("#divPendingBillList").empty();
                $("#divPendingBill").hide();
            }
            return false;
        }

        function GetDashboardCount() {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetDashboardCount",
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



                                    //$("#lblTotalInvestments").text(obj.TotalInvestments);
                                    //$("#lblTotalCash-In-Hand").text(obj.TotalCashInHand);
                                    //$("#lblTotalBankAccounts").text(obj.TotalBankAccounts);
                                    $("#lblTotalProduct").text(obj.TotalProducts);
                                    $("#lblTotalPurchase").text(obj.TotalPurchase);
                                    $("#lblTotalSales").text(obj.TotalSales);
                                    $("#lblTotalCustomer").text(obj.TotalCustomer);
                                    $("#lblTotalSupplier").text(obj.TotalSupplier);
                                    //$("#WholeSaleCustomer").val(obj.WholeSaleCustomer);
                                    //$("#RetailCustomer").val(obj.RetailCustomer);
                                    //$("#NewCustomer").val(obj.NewCustomer);
                                    //$("#Day1OldValue").val(obj.Day1OldValue);
                                    //$("#Day2OldValue").val(obj.Day2OldValue);
                                    //$("#Day3OldValue").val(obj.Day3OldValue);
                                    //$("#Day4OldValue").val(obj.Day4OldValue);
                                    //$("#Day5OldValue").val(obj.Day5OldValue);
                                    //$("#Day6OldValue").val(obj.Day6OldValue);
                                    //$("#Day7OldValue").val(obj.Day7OldValue);
                                    //$("#Day1Value").val(obj.Day1Value);
                                    //$("#Day2Value").val(obj.Day2Value);
                                    //$("#Day3Value").val(obj.Day3Value);
                                    //$("#Day4Value").val(obj.Day4Value);
                                    //$("#Day5Value").val(obj.Day5Value);
                                    //$("#Day6Value").val(obj.Day6Value);
                                    //$("#Day7Value").val(obj.Day7Value);
                                    //$("#Day1").val(obj.Day1);
                                    //$("#Day2").val(obj.Day2);
                                    //$("#Day3").val(obj.Day3);
                                    //$("#Day4").val(obj.Day4);
                                    //$("#Day5").val(obj.Day5);
                                    //$("#Day6").val(obj.Day6);
                                    //$("#Day7").val(obj.Day7);
                                    //$("#Q1Value").val(obj.Q1Value);
                                    //$("#Q2Value").val(obj.Q2Value);
                                    //$("#Q3Value").val(obj.Q3Value);
                                    //$("#Q4Value").val(obj.Q4Value);
                                    //$("#Q5Value").val(obj.Q5Value);
                                    //$("#Q6Value").val(obj.Q6Value);
                                    //$("#Q7Value").val(obj.Q7Value);
                                    //$("#Q8Value").val(obj.Q8Value);
                                    //$("#Q9Value").val(obj.Q9Value);
                                    //$("#Q10Value").val(obj.Q10Value);
                                    //$("#Q11Value").val(obj.Q11Value);
                                    //$("#Q12Value").val(obj.Q12Value);
                                    //$("#Q1").val(obj.Q1);
                                    //$("#Q2").val(obj.Q2);
                                    //$("#Q3").val(obj.Q3);
                                    //$("#Q4").val(obj.Q4);
                                    //$("#Q5").val(obj.Q5);
                                    //$("#Q6").val(obj.Q6);
                                    //$("#Q7").val(obj.Q7);
                                    //$("#Q8").val(obj.Q8);
                                    //$("#Q9").val(obj.Q9);
                                    //$("#Q10").val(obj.Q10);
                                    //$("#Q11").val(obj.Q11);
                                    //$("#Q12").val(obj.Q12);
                                    //$("#Month1").val(obj.Month1);
                                    //$("#Month2").val(obj.Month2);
                                    //$("#Month3").val(obj.Month3);
                                    //$("#Month4").val(obj.Month4);
                                    //$("#Month5").val(obj.Month5);
                                    //$("#Month6").val(obj.Month6);
                                    //$("#Month7").val(obj.Month7);
                                    //$("#Month8").val(obj.Month8);
                                    //$("#Month9").val(obj.Month9);
                                    //$("#Month10").val(obj.Month10);
                                    //$("#Month11").val(obj.Month11);
                                    //$("#Month12").val(obj.Month12);
                                    //$("#Cotton1Value").val(obj.Cotton1Value);
                                    //$("#Cotton2Value").val(obj.Cotton2Value);
                                    //$("#Cotton3Value").val(obj.Cotton3Value);
                                    //$("#Cotton4Value").val(obj.Cotton4Value);
                                    //$("#Cotton5Value").val(obj.Cotton5Value);
                                    //$("#Cotton6Value").val(obj.Cotton6Value);
                                    //$("#Cotton7Value").val(obj.Cotton7Value);
                                    //$("#Cotton8Value").val(obj.Cotton8Value);
                                    //$("#Cotton9Value").val(obj.Cotton9Value);
                                    //$("#Cotton10Value").val(obj.Cotton10Value);
                                    //$("#Cotton11Value").val(obj.Cotton11Value);
                                    //$("#Cotton12Value").val(obj.Cotton12Value);
                                    //$("#Silk1Value").val(obj.Silk1Value);
                                    //$("#Silk2Value").val(obj.Silk2Value);
                                    //$("#Silk3Value").val(obj.Silk3Value);
                                    //$("#Silk4Value").val(obj.Silk4Value);
                                    //$("#Silk5Value").val(obj.Silk5Value);
                                    //$("#Silk6Value").val(obj.Silk6Value);
                                    //$("#Silk7Value").val(obj.Silk7Value);
                                    //$("#Silk8Value").val(obj.Silk8Value);
                                    //$("#Silk9Value").val(obj.Silk9Value);
                                    //$("#Silk10Value").val(obj.Silk10Value);
                                    //$("#Silk11Value").val(obj.Silk11Value);
                                    //$("#Silk12Value").val(obj.Silk12Value);

                                    var OldTotal = parseFloat(obj.Day1OldValue) + parseFloat(obj.Day2OldValue) + parseFloat(obj.Day4OldValue) + parseFloat(obj.Day5OldValue) + parseFloat(obj.Day6OldValue) + parseFloat(obj.Day7OldValue);
                                    var NewTotal = parseFloat(obj.Day1Value) + parseFloat(obj.Day2Value) + parseFloat(obj.Day3Value) + parseFloat(obj.Day4Value) + parseFloat(obj.Day5Value) + parseFloat(obj.Day6Value) + parseFloat(obj.Day7Value);
                                    var DiffereceValue = parseFloat(NewTotal) - parseFloat(OldTotal);

                                    if (DiffereceValue < 0) {
                                        $("#PercentageImage").addClass('fa-arrow-down text-red');
                                        $("#PercentageImage").removeClass('fa-arrow-up');
                                        DiffereceValue = DiffereceValue * -1;
                                    }
                                    else {
                                        $("#PercentageImage").addClass('fa-arrow-up');
                                        $("#PercentageImage").removeClass('fa-arrow-down text-red');
                                    }


                                    DiffereceValue = ((DiffereceValue * 100) / OldTotal).toFixed(2);
                                    $("#lblPercentage").html(DiffereceValue);
                                    $("#lblSaleDuration").html(obj.Saleduration);

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
                url: "WebServices/VHMSService.svc/GetReorderStock",
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
                                    var sReceiptMode = "";
                                    for (var index = 0; index < obj.length; index++) {

                                        var table = "<tr id='" + obj[index].ProductID + "'>";
                                        table += "<td>" + (index + 1) + "</td>";
                                        table += "<td>" + obj[index].HouseType.HouseTypeName + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].ProductName + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].ProductCode + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].MinimumStock + "</td>";
                                        table += "<td class='hidden-xs'>" + obj[index].AvailableQty + "</td>";


                                        table += "</tr>";
                                        $("#tblRecord_tbody").append(table);
                                    }
                                    $(".View").click(function () {
                                        EditRecord($(this).parent().parent()[0].id);
                                        $(".modal-title").html("<i class='fa fa-clone'></i>&nbsp;&nbsp;View Receipt");
                                        $("#btnSave").hide();
                                        $("#btnUpdate").hide();

                                    });
                                    $(".Edit").click(function () {
                                        EditRecord($(this).parent().parent()[0].id);
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
                                    { "sWidth": "20%" },
                                    { "sWidth": "40%" },
                                    { "sWidth": "15%" },
                                    { "sWidth": "10%" },
                                    { "sWidth": "10%" }
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

        function GetLRRecord(iDetails) {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/SearchLREntry",
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
                                        if (obj[index].Status == "Pending") { TypeStatus = "<span class='label label-danger'>Pending</span>"; }
                                        else { TypeStatus = "<span class='label label-danger'>Delivered</span>"; }

                                        var table = "<tr id='" + obj[index].LREntryID + "'>";
                                        table += "<td>" + (index + 1) + "</td>";
                                        table += "<td>" + obj[index].LREntryNo + "</td>";
                                        table += "<td>" + obj[index].sLREntryDate + "</td>";
                                        table += "<td>" + obj[index].Customer.CustomerName + "</td>";
                                        table += "<td>" + obj[index].InvoiceNo + "</td>";
                                        table += "<td>" + TypeStatus + "</td>";
                                        table += "<td style='text-align:center;'><a href='#' id=" + obj[index].LREntryID + " class='Edit' title='Click here to update Status'><i class='fa fa-save'></a></td>";
                                        table += "</tr>";
                                        $("#tblSearchResult_tbody").append(table);
                                    }
                                    $(".Edit").click(function () {
                                        if (ActionView == "1") {
                                            UpdateLRStatus($(this).parent().parent()[0].id);
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
                                    { "sWidth": "5%" },
                                    { "sWidth": "0%" },
                                    { "sWidth": "0%" },
                                    { "sWidth": "0%" },
                                    { "sWidth": "0%" },
                                    { "sWidth": "0%" },
                                    { "sWidth": "0%" }
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

        function GetSalesEntryBookingBill() {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetSalesEntryBookingBill",
                data: JSON.stringify({ PublisherID: 0, IsRetail: 1 }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != "") {
                        var objResponse = jQuery.parseJSON(data.d);
                        if (objResponse.Status == "Success") {
                            var notetable = $("#tblBookingBill").dataTable();
                            notetable.fnDestroy();
                            if (objResponse.Value != null && objResponse.Value != "NoRecord") {
                                var obj = $.parseJSON(objResponse.Value);
                                if (obj.length > 0) {
                                    $("#tblBookingBill_tbody").empty();
                                    var TypeStatus = "";
                                    for (var index = 0; index < obj.length; index++) {
                                        var table = "<tr id='" + obj[index].SalesEntryID + "'>";
                                        table += "<td>" + (index + 1) + "</td>";
                                        table += "<td>" + obj[index].InvoiceNo + "</td>";
                                        table += "<td>" + obj[index].sInvoiceDate + "</td>";
                                        table += "<td>" + obj[index].Customer.CustomerName + "</td>";
                                        table += "<td>" + obj[index].Customer.MobileNo + "</td>";
                                        table += "<td>" + obj[index].TotalQty + "</td>";
                                        table += "<td>" + obj[index].NetAmount + "</td>";
                                        table += "<td>" + obj[index].sDeliveryDate + "</td>";
                                        //table += "<td style='text-align:center;'><a href='#' id=" + obj[index].SalesEntryID + " class='Edit' title='Click here to update Status'><i class='fa fa-save'></a></td>";
                                        table += "</tr>";
                                        $("#tblBookingBill_tbody").append(table);
                                    }
                                    //$(".Edit").click(function () {
                                    //    if (ActionView == "1") {
                                    //        UpdateBookingBill($(this).parent().parent()[0].id);
                                    //    }
                                    //    else {
                                    //        $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife });
                                    //        return false;
                                    //    }
                                    //});
                                }
                                dProgress(false);
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $("#tblBookingBill_tbody").empty();
                                dProgress(false);
                            }
                            $("#tblBookingBill").dataTable({
                                "bPaginate": true,
                                "bFilter": true,
                                "bSort": true,
                                "iDisplayLength": 25,
                                aoColumns: [
                                    { "sWidth": "5%" },
                                    { "sWidth": "0%" },
                                    { "sWidth": "0%" },
                                    { "sWidth": "0%" },
                                    { "sWidth": "0%" },
                                    { "sWidth": "0%" },
                                    { "sWidth": "0%" },
                                    { "sWidth": "0%" }
                                ]
                            });
                            $("#tblBookingBill_filter").addClass('pull-right');
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
                        $("#tblBookingBill_tbody").empty();
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

        function ClearFields() {
            $("#txtVoucherNo").val("");
            $("#txtVoucherDate").val("");
            $("#ddlCustomer").val(null).change();
            $("#ddlBank").val(null).change();
            $("#ddlReceiptMode").val(0);
            $("#txtAmount").val("0");
            $("#txtChequeNo").val("");
            $("#txtIssueDate").val("");
            $("#txtCollectionDate").val("");
            $("#txtIssuedBy").val("");
            $("#ddlPaymentStatus").val("Cleared");
            $("#txtBankName").val("");
            $("#txtDescription").val("");

            $("#divChequeDetails").hide();
            return false;
        }
        function GetBankList() {
            dProgress(true);
            $("#ddlBank").empty();
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
                            if (objResponse.Value != null && objResponse.Value != "NoRecord") {
                                var obj = $.parseJSON(objResponse.Value);
                                if (obj.length > 0) {
                                    for (var index = 0; index < obj.length; index++) {
                                        if (obj[index].IsActive) {
                                            $("#ddlBank").append('<option value=' + obj[index].LedgerID + ' >' + obj[index].LedgerName + '</option>');
                                        }
                                    }
                                }
                                dProgress(false);
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $("#ddlBank").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
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
                        $("#ddlBank").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
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
        function GetCustomerList() {
            dProgress(true);
            $("#ddlCustomer").empty();
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
                                    for (var index = 0; index < obj.length; index++) {
                                        if (obj[index].IsActive) {
                                            $("#ddlCustomer").append('<option value=' + obj[index].CustomerID + ' >' + obj[index].CustomerName + '</option>');
                                        }
                                    }
                                }
                                dProgress(false);
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $("#ddlCustomer").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
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
                        $("#ddlCustomer").append('<option value="' + '0' + '">' + '--No Records--' + '</option>');
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

        function UpdateLRStatus(id) {
            var ObjOPBilling = new Object();
            ObjOPBilling.Status = "Delivered";
            ObjOPBilling.LREntryID = id;
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/UpdateLREntryStatus",
                data: JSON.stringify({ Objdata: ObjOPBilling }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != "") {
                        var objResponse = jQuery.parseJSON(data.d);
                        if (objResponse.Status == "Success") {
                            if (objResponse.Value > 0) {
                                $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
                                GetLRRecord("Pending");
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

        //function UpdateBookingBill(id) {

        //    $.ajax({
        //        type: "POST",
        //        url: "WebServices/VHMSService.svc/UpdateLREntryStatus",
        //        data: JSON.stringify({ Objdata: ObjOPBilling }),
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        async: false,
        //        success: function (data) {
        //            if (data.d != "") {
        //                var objResponse = jQuery.parseJSON(data.d);
        //                if (objResponse.Status == "Success") {
        //                    if (objResponse.Value > 0) {
        //                        $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife });
        //                        GetSalesEntryBookingBill();
        //                    }
        //                }
        //                else if (objResponse.Status == "Error") {
        //                    if (objResponse.Value == "0") {
        //                        window.location = "frmLogin.aspx";
        //                    }
        //                    else if (objResponse.Value == "Error") {
        //                        window.location = "frmErrorPage.aspx";
        //                    }
        //                }
        //            }
        //            else {
        //                $.jGrowl("Error  Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
        //            }
        //        },
        //        error: function (e) {
        //            $.jGrowl("Error  Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
        //        }
        //    });
        //    return false;
        //}

        function EditRecord(id) {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetReceiptByID",
                data: JSON.stringify({ ID: id, IsRetail: 0 }),
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
                                    ClearFields();

                                    $("#hdnID").val(obj.ReceiptID);
                                    $("#txtVoucherNo").val(obj.VoucherNo);
                                    $("#txtVoucherDate").val(obj.sVoucherDate);
                                    $("#ddlCustomer").val(obj.Customer.CustomerID).change();
                                    $("#ddlBank").val(obj.Bank.LedgerID).change();
                                    $("#ddlReceiptMode").val(obj.ReceiptModeID).change();
                                    $("#txtAmount").val(obj.Amount);
                                    $("#ddlPaymentStatus").val(obj.Status);
                                    if (obj.Status == 'Cleared')
                                        $("#ddlPaymentStatus").attr("disabled", true);
                                    else {
                                        $("#ddlPaymentStatus").attr("disabled", false);
                                        $("#ddlPaymentStatus").val("Cleared");
                                    }
                                    $("#txtDiscountAmount").val(obj.DiscountAmount).change();
                                    $("[id*=imgUpload1]").attr("src", obj.DocumentPath);
                                    $("#txtCollectionDate").val(obj.sCollectionDate);
                                    if (obj.ReceiptModeID == 2 || obj.ReceiptModeID == 3 || obj.ReceiptModeID == 5) {
                                        $("#divChequeDetails").show();
                                        $("#txtChequeNo").val(obj.ChequeNo);
                                        $("#txtIssueDate").val(obj.sIssueDate);
                                        $("#txtIssuedBy").val(obj.IssuedBy);
                                        $("#txtBankName").val(obj.BankName);
                                        $("#txtCharges").val(obj.Charges);
                                    }
                                    $("#txtDescription").val(obj.Description);

                                    $('#compose-modal').modal({ show: true, backdrop: true });
                                    $(".modal-title").html("<i class='fa fa-pencil'></i>&nbsp;&nbsp;Edit Receipt");
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
        function GetSettings() {
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
                                    //$("#txtDate").val(obj.sOpeningDate);
                                    if (obj.Messagesentcnt <= 0 && ($("#RoleID").val() == 12 || $("#RoleID").val() == 7)) {

                                        $("#divTab").show();
                                        $("#btnSend").show();
                                        $("#ContainerID1").show();
                                    }
                                    if (obj.NotificationSentCount <= 0 && ($("#RoleID").val() == 12 || $("#RoleID").val() == 7)) {
                                        $("#divTabNotification").show();
                                        $("#btnSendNotification").show();
                                        $("#ContainerID").show();
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
                        $.jGrowl("Error Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
                        dProgress(false);
                    }
                },
                error: function () {
                    $.jGrowl("Error Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
                    dProgress(false);
                }
            });
            return false;
        }

        function GetPassword(id) {
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

        $("#btnSave,#btnUpdate").click(function () {

            //if (this.id == "btnSave")
            //{ if (ActionAdd != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }
            //else if (this.id == "btnUpdate")
            //{ if (ActionUpdate != "1") { $.jGrowl(_CMAccessDeined, { sticky: false, theme: 'danger', life: jGrowlLife }); return false; } }

            //if ($("#ddlPaymentStatus").val() == "" || $("#ddlPaymentStatus").val() == undefined || $("#ddlPaymentStatus").val() == null) {
            //    $.jGrowl("Please select Voucher Type", { sticky: false, theme: 'warning', life: jGrowlLife });
            //    $("#divStatus").addClass('has-error'); $("#ddlPaymentStatus").focus(); return false;
            //} else { $("#divStatus").removeClass('has-error'); }

            if ($("#ddlBank").val() == "0" || $("#ddlBank").val() == undefined || $("#ddlBank").val() == null) {
                $.jGrowl("Please select Account", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divBank").addClass('has-error'); $("#ddlBank").focus(); return false;
            } else { $("#divBank").removeClass('has-error'); }

            if ($("#ddlReceiptMode").val() == "0" || $("#ddlReceiptMode").val() == undefined || $("#ddlReceiptMode").val() == null) {
                $.jGrowl("Please select Receipt Mode", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divReceiptMode").addClass('has-error'); $("#ddlReceiptMode").focus(); return false;
            } else { $("#divReceiptMode").removeClass('has-error'); }

            if ($("#txtAmount").val().trim() == "" || $("#txtAmount").val().trim() == undefined) {
                $.jGrowl("Please enter Amount", { sticky: false, theme: 'warning', life: jGrowlLife });
                $("#divAmount").addClass('has-error'); $("#txtAmount").focus(); return false;
            } else { $("#divAmount").removeClass('has-error'); }

            if (!isNaN($("#txtAmount").val())) {
                if ($("#txtAmount").val() == 0) {
                    $.jGrowl("Please enter Amount", { sticky: false, theme: 'warning', life: jGrowlLife });
                    $("#divAmount").addClass('has-error'); $("#txtAmount").focus(); return false;
                }
            }
            if ($("#ddlReceiptMode").val() == 2 || $("#ddlReceiptMode").val() == 3) {
                if ($("#txtChequeNo").val().trim() == "" || $("#txtChequeNo").val().trim() == undefined) {
                    $.jGrowl("Please enter Cheque/DD No.", { sticky: false, theme: 'warning', life: jGrowlLife });
                    $("#divChequeNo").addClass('has-error'); $("#txtChequeNo").focus(); return false;
                } else { $("#divChequeNo").removeClass('has-error'); }

                if ($("#txtIssueDate").val().trim() == "" || $("#txtIssueDate").val().trim() == undefined) {
                    $.jGrowl("Please select Issue Date", { sticky: false, theme: 'warning', life: jGrowlLife });
                    $("#divIssueDate").addClass('has-error'); $("#txtIssueDate").focus(); return false;
                } else { $("#divIssueDate").removeClass('has-error'); }

                if ($("#txtCollectionDate").val().trim() == "" || $("#txtCollectionDate").val().trim() == undefined) {
                    $.jGrowl("Please select Collection Date", { sticky: false, theme: 'warning', life: jGrowlLife });
                    $("#divCollectionDate").addClass('has-error'); $("#txtCollectionDate").focus(); return false;
                } else { $("#divCollectionDate").removeClass('has-error'); }
            }


            var Obj = new Object();
            Obj.ReceiptID = $("#hdnID").val();
            Obj.VoucherNo = $("#txtVoucherNo").val().trim();
            Obj.sVoucherDate = $("#txtVoucherDate").val();

            var objCustomer = new Object();
            objCustomer.CustomerID = $("#ddlCustomer").val();
            Obj.Customer = objCustomer;

            var objBank = new Object();
            objBank.LedgerID = $("#ddlBank").val();
            Obj.Bank = objBank;

            Obj.ReceiptModeID = $("#ddlReceiptMode").val();
            Obj.Amount = parseFloat($("#txtAmount").val().trim());
            Obj.Status = "Cleared";
            if ($("#ddlReceiptMode").val() == 2 || $("#ddlReceiptMode").val() == 3) {
                Obj.ChequeNo = $("#txtChequeNo").val().trim();
                Obj.sIssueDate = $("#txtIssueDate").val().trim();
                Obj.sCollectionDate = $("#txtCollectionDate").val().trim();
                Obj.IssuedBy = $("#txtIssuedBy").val().trim();
                Obj.BankName = $("#txtBankName").val().trim();

            }
            Obj.Description = $("#txtDescription").val().trim();

            var sMethodName;
            if ($("#hdnID").val() > 0) {
                Obj.ReceiptID = $("#hdnID").val();
                sMethodName = "UpdateReceipt";
            }
            else { sMethodName = "AddReceipt"; }

            SaveandUpdateReceipt(Obj, sMethodName);

            return false;
        });

        function SaveandUpdateReceipt(Obj, sMethodName) {
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

                                if (sMethodName == "AddReceipt") { $.jGrowl("Added Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }
                                else if (sMethodName == "UpdateReceipt") { $.jGrowl("Updated Successfully", { sticky: false, theme: 'success', life: jGrowlLife }); }

                                $('#compose-modal').modal('hide');
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "0") {
                                window.location = "frmLogin.aspx";
                            }
                            else if (objResponse.Value == "Receipt_A_01" || objResponse.Value == "Receipt_U_01") {
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

        function LoadCustomer(ddlname) {
            dProgress(true);
            $.ajax({
                type: "POST",
                url: "WebServices/VHMSService.svc/GetCustomerByDate",
                data: JSON.stringify({ ID: ddlname }),
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
                                        if (ddlname == "DOB")
                                            GetSMSRecord(obj[index].MobileNo, "On this special day we would like to extend our heartiest wishes to you. Wish you a very happy birthday. - SVS Jewellery");
                                        else
                                            GetSMSRecord(obj[index].MobileNo, "On this special day we would like to extend our heartiest wishes to you. Wish you a very happy anniversary. - SVS Jewellery");
                                    }
                                }
                                dProgress(false);
                            }
                            else if (objResponse.Value == "NoRecord") {
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

        $("#btnClose").click(function () {
            $('#compose-modal').modal('hide');
            return false;
        });

    </script>

    <canvas id="purchaseSalesStockChart" style="height: 300px;"></canvas>
    <script>
        const doughnutCtx = document.getElementById('purchaseSalesStockChart').getContext('2d');
        const purchaseSalesStockChart = new Chart(doughnutCtx, {
            type: 'doughnut',
            data: {
                labels: ['Purchase', 'Sales', 'Stock'],
                datasets: [{
                    label: 'Store Summary',
                    data: [40, 30, 30],
                    backgroundColor: ['#4e73df', '#1cc88a', '#f6c23e'],
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                animation: {
                    animateScale: true,
                    animateRotate: true,
                    duration: 1500,
                    easing: 'easeOutBounce'
                },
                plugins: {
                    legend: {
                        position: 'bottom'
                    },
                    title: {
                        display: true,
                        text: 'Purchase vs Sales vs Stock'
                    }
                }
            }
        });
    </script>
    <canvas id="financialChart" style="height: 300px;"></canvas>
    <script>
        const barCtx = document.getElementById('financialChart').getContext('2d');
        const financialChart = new Chart(barCtx, {
            type: 'bar',
            data: {
                labels: ['Success', 'Processing', 'Not Success', 'Wrong Lead', 'Rate of Call'],
                datasets: [{
                    label: 'Number of Calls',
                    data: [120, 90, 30, 15, 200], // <-- Update these values as needed
                    backgroundColor: [
                        '#28a745',  // Success - green
                        '#ffc107',  // Processing - yellow
                        '#dc3545',  // Not Success - red
                        '#6f42c1',  // Wrong Lead - purple
                        '#17a2b8'   // Rate of Call - teal
                    ],
                    borderRadius: 5,
                    barThickness: 40
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                animation: {
                    duration: 1000,
                    easing: 'easeOutQuart'
                },
                plugins: {
                    legend: {
                        display: false
                    },
                    title: {
                        display: true,
                        text: 'Lead Call Status Overview',
                        font: {
                            size: 18,
                            weight: 'bold'
                        }
                    },
                    tooltip: {
                        callbacks: {
                            label: function (context) {
                                return `${context.dataset.label}: ${context.parsed.y}`;
                            }
                        }
                    }
                },
                scales: {
                    y: {
                        beginAtZero: true,
                        title: {
                            display: true,
                            text: 'Number of Calls'
                        }
                    },
                    x: {
                        title: {
                            display: true,
                            text: 'Status'
                        }
                    }
                }
            }
        });
    </script>

    <canvas id="topSellingChart" style="height: 300px;"></canvas>
    <script>
        const ctx = document.getElementById('topSellingChart').getContext('2d');
        const topSellingChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: [
                    'Day 1', 'Day 2', 'Day 3', 'Day 4', 'Day 5', 'Day 6', 'Day 7',
                    'Day 8', 'Day 9', 'Day 10', 'Day 11', 'Day 12', 'Day 13', 'Day 14',
                    'Day 15', 'Day 16', 'Day 17', 'Day 18', 'Day 19', 'Day 20',
                    'Day 21', 'Day 22', 'Day 23', 'Day 24', 'Day 25', 'Day 26',
                    'Day 27', 'Day 28', 'Day 29', 'Day 30'
                ],
                datasets: [{
                    label: 'Calls per Day',
                    data: [
                        25, 30, 20, 28, 35, 40, 38,
                        45, 48, 50, 42, 39, 41, 46,
                        50, 52, 48, 53, 56, 60,
                        58, 55, 54, 59, 63, 65,
                        67, 66, 70, 72
                    ],
                    borderColor: '#4caf50',
                    backgroundColor: '#c8e6c9',
                    borderWidth: 2,
                    fill: true,
                    pointBackgroundColor: '#4caf50',
                    pointRadius: 4,
                    tension: 0.4
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                animation: {
                    duration: 1000,
                    easing: 'easeOutCubic'
                },
                plugins: {
                    legend: {
                        display: true
                    },
                    title: {
                        display: true,
                        text: 'Number of Call Recordings (30 Days)',
                        font: {
                            size: 18,
                            weight: 'bold'
                        }
                    }
                },
                scales: {
                    y: {
                        beginAtZero: true,
                        title: {
                            display: true,
                            text: 'Number of Calls'
                        }
                    },
                    x: {
                        title: {
                            display: true,
                            text: 'Days'
                        }
                    }
                }
            }
        });
    </script>

    <script>
        const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
            "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        const currentMonth = new Date().getMonth();
        let selectedMonth = currentMonth;

        function renderMonthButtons() {
            const container = document.getElementById('monthButtonsContainer');
            container.innerHTML = monthNames.map((month, index) => `
        <button type="button" 
            class="btn ${index === selectedMonth ? 'btn-primary text-white' : 'btn-light text-dark border'} fw-semibold rounded-pill px-4 py-2 shadow-sm"
            style="border: 1px solid #ccc;" 
            onclick="selectMonth(${index})">
            ${month}
        </button>
    `).join('');
        }


        function selectMonth(index) {
            selectedMonth = index;
            renderMonthButtons();
            console.log("Selected Month:", monthNames[selectedMonth]);
        }
        renderMonthButtons();
    </script>

</asp:Content>
