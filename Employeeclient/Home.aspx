<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Employeeclient.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            color: #0000CC;
            text-decoration: underline;
            background-color: #FF9933;
        }
        .auto-style2 {
            font-size: larger;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            text-align: center;
            color: #FF0000;
        }
    </style>
</head>
<body style="height: 172px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong><span class="auto-style2">Hello ,Welcome In EmployeeManagementSystem </span></strong>&nbsp;</div>
        <p>
            &nbsp;</p>
        <p class="auto-style3">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SignUp" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="LogIn" />
        </p>
        <p class="auto-style4">
            *if&nbsp; you are new user then first SignUp</p>
    </form>
</body>
</html>
