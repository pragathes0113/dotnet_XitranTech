<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLogin.aspx.cs" Inherits="frmLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no'
        name='viewport' />
    <title>VRS Tools And Equipments | Sign in</title>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/sLoginStyle.css" rel="stylesheet" />
    <link href="plugins/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <%-- <form id="form1" runat="server" >
        <div class="container">
            <div class="col-lg-4 col-md-3 col-sm-2"></div>
            <div class="col-lg-4 col-md-6 col-sm-8">
                <div class="logo">
                    <img src="images/default_user.png" alt="Logo" />
                </div>
                <div class="row loginbox">
                    <div id="divTitle" runat="server"> VRS Tools v 1.0.0.0</div>
                    <br />
                    <div class="col-lg-12">
                        <span class="singtext">Sign in </span>
                    </div>

                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <input type="text" class="form-control" id="txtUserName" runat="server" tabindex="1" placeholder="Please enter your user name" />
                    </div>
                    <div class="col-lg-12  col-md-12 col-sm-12">
                        <input type="password" class="form-control" id="txtPassword" runat="server" tabindex="2" placeholder="Please enter password" />
                    </div>
                    <div class="col-lg-12  col-md-12 col-sm-12">                     
                        <asp:Button ID="btnSignIn" runat="server" Text="Login" class="btn submitButton"
                            OnClick="btnSignIn_Click" />
                    </div>
                </div>
                <br/>
                <br/>
                <footer class="footer">                                   
                    <p>Copyrights ©2019 All rights reserved </p>
                </footer>

            </div>
            <div class="col-lg-4 col-md-3 col-sm-2"></div>
        </div>
    </form>--%>
    <form id="form1" runat="server">
        <div class="container" style="width: 100%; display: flex; height: 100vh; padding: 0px;">

            <div class="col-sm-6">
                <img src="images/VRS.jpg" style="margin: auto; display: block; transform: translate(-50%, -50%); position: absolute; left: 50%; top: 45%; width: 500px;" alt="Logo" />
            </div>
            <div class="col-sm-1"></div>
            <div class="col-sm-3" style="margin-top: 10%">
                <div class="logo" style="display: none;">
                    <img src="images/default_user.png" alt="Logo" />
                </div>
                <div class="row loginbox">
                    <div id="divTitle" runat="server">VRS Tools </div>
                    <br />
                    <div class="col-lg-12">
                        <span class="singtext">Sign in </span>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <select id="ddlCompany" name="ddlCompany" class="form-control select2" runat="server" data-placeholder="Select Company" tabindex="1"></select>
                        <input type="Hidden" name="ddlname" id="ddlname" runat="server">
                    </div>

                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <input type="text" class="form-control" id="txtUserName" runat="server" tabindex="1" placeholder="Please enter your user name" />
                    </div>
                    <div class="col-lg-12  col-md-12 col-sm-12">
                        <input type="password" class="form-control" id="txtPassword" runat="server" tabindex="2" placeholder="Please enter password" />
                    </div>
                    <div class="col-lg-12  col-md-12 col-sm-12">
                        <asp:Button ID="btnSignIn" runat="server" Text="Login" class="btn submitButton"
                            OnClick="btnSignIn_Click" />
                    </div>
                </div>
                <br>
                <br>
                <footer class="footer">
                    <p>Copyrights ©2024 All rights reserved </p>
                </footer>
            </div>
            <div class="col-sm-2"></div>
        </div>
    </form>
    <footer>
    </footer>
    <script src="js/jQuery-2.1.4.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="plugins/cookie/jquery.enhanced.cookie.js" type="text/javascript"></script>
    <script src="plugins/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
    <script src="UserDefined_Js/Validation.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //$("#btnLogin").hide();

            //var _Tfunctionality;
            //if ($.cookie("UserName") != undefined && $.cookie("UserName") != null) {
            //    _Tfunctionality = $.cookie("UserName");
            //    alert(_Tfunctionality);
            //    $("#txtUserName").val(_Tfunctionality);               
            //}

            //if ($.cookie("Password") != undefined && $.cookie("Password") != null) {
            //    _Tfunctionality = $.cookie("Password");
            //    $("#txtPassword").val(_Tfunctionality);
            //}
            GetCompany();
            $("#txtUserName").focus();
            $("#btnSignIn").click(function () {
                if ($("#txtUserName").val().trim() == "" || $("#txtUserName").val().trim() == undefined) {
                    $.jGrowl("Please enter User Name", { sticky: false, theme: 'danger', life: jGrowlLife });
                    $("#txtUserName").focus(); return false;
                }
                if ($("#txtPassword").val().trim() == "" || $("#txtPassword").val().trim() == undefined) {
                    $.jGrowl("Please enter Password", { sticky: false, theme: 'danger', life: jGrowlLife });
                    $("#txtPassword").focus(); return false;
                }
            });
        });

        function GetCompany() {
            dProgress(true);
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
                                    for (var index = 0; index < obj.length; index++) {
                                        $('#ddlCompany').append("<option value='" + obj[index].CompanyID + "'>" + obj[index].CompanyName + "</option>");
                                    }
                                }
                                dProgress(false);
                            }
                            else if (objResponse.Value == "NoRecord") {
                                dProgress(false);
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

        function eAlert(msg) {
            $.jGrowl(msg, { sticky: false, theme: 'warning', life: jGrowlLife });
        }

        $("#btnLogin").click(function () {
            if ($("#txtUserName").val().trim() == "" || $("#txtUserName").val().trim() == undefined) {
                $.jGrowl("Please enter User Name", { sticky: false, theme: 'danger', life: jGrowlLife });
                $("#txtUserName").focus(); return false;
            }
            if ($("#txtPassword").val().trim() == "" || $("#txtPassword").val().trim() == undefined) {
                $.jGrowl("Please enter Password", { sticky: false, theme: 'danger', life: jGrowlLife });
                $("#txtPassword").focus(); return false;
            }
            ValidateUserLogin();
            return false;
        });

        function ClearFields() {
            $("#txtUserName").val("");
            $("#txtPassword").val("");
            $("#txtUserName").focus();
        }

        function ValidateUserLogin() {
            var UserName = $("#txtUserName").val().trim();
            var Password = $("#txtPassword").val().trim();

            $.ajax({
                type: "POST",
                url: "WebServices/KudilMSService.svc/GetUserLogin",
                data: JSON.stringify({ sUserName: UserName, sPassword: Password }),
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
                                    SetSessionValue("UserID", obj.UserID);
                                    SetSessionValue("UserName", obj.UserName);
                                    SetSessionValue("RoleID", obj.RoleID);
                                    //iRoleID = obj.RoleID;
                                    SetSessionValue("RoleName", obj.RoleName);
                                    var sdate = new Date();
                                    SetSessionValue("LogDateTime", sdate.getDate() + "-" + (sdate.getMonth() + 1) + "-" + sdate.getFullYear() + " " + sdate.getHours() + ":" + sdate.getMinutes() + ":" + sdate.getSeconds());
                                    window.location.href = obj.FileName;

                                    $.cookie("UserName", obj.UserName, { expires: 30 });
                                    $.cookie("Password", obj.Password, { expires: 30 });

                                    alert($.cookie("UserName"));
                                }
                            }
                            else if (objResponse.Value == "NoRecord") {
                                $.jGrowl("Invalid UserName/Password", { sticky: false, theme: 'warning', life: jGrowlLife });
                                ClearFields();
                            }
                        }
                        else if (objResponse.Status == "Error") {
                            if (objResponse.Value == "Error") {
                                $.jGrowl("Invalid UserName/Password", { sticky: false, theme: 'warning', life: jGrowlLife });
                                ClearFields();
                            }
                        }
                    }
                    else {
                        $.jGrowl("Error  Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
                    }
                },
                error: function () {
                    $.jGrowl("Error  Occured", { sticky: true, theme: 'danger', life: jGrowlLife });
                }
            });
            return false;
        }
    </script>
</body>
</html>
