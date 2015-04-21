<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AutoInventory.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/main.css" rel="stylesheet" />
</head>
<body>
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="/default.aspx">Andrew's Car Lot</a>
            </div>
        </div>
    </nav>

    <div class="container" style="margin-top:150px;">
        <form method="post">
            <div class="row">
                <div class="col-lg-1"><strong>username</strong></div>
                <div class="col-lg-4"><input type="text" id="txtUsername" name="txtUsername" /></div>
            </div>

            <div class="row">
                <div class="col-lg-1"><strong>password</strong></div>
                <div class="col-lg-4"><input type="password" id="txtPassword" name="txtPassword" /><br /></div>
            </div>

            <div class="row">
                <br /><br />
                <div class="col-lg-5 text-center">
                    <input type="submit" id="btnLogin" value="Login" />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-5 text-center">
                    <span id="errorMsg" runat="server" clientIDMode="static" class="alert-warning"></span>
                </div>
            </div>

            <div class="row">
                    <br />
                    <span class="alert-warning">Username: apallant / Password: test123</span>
            </div>
        </form>
    </div>

    <section id="footer">
        <div class="row">
            <div class="col-lg-12">
                &copy;<%=DateTime.Now.Year %> @LDNDeveloper
            </div>
        </div>
    </section>
</body>
</html>
