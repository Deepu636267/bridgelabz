<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Employeeclient.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 365px;
        }
        .auto-style3 {
            text-align: justify;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style2">
      
        <table style="font-family:Arial; border:1px solid black;">
     <tr>
        <td>
            <b>UserName</b>
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="118px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="UserName Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <b>Password</b>
        </td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" Width="118px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password Required " ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr >
        <td colspan="2" class="auto-style3">
            <asp:Button ID="btnLogin" runat="server" 
                                 Text="Login" 
                                 onclick="btnLogin_Click" Height="32px" Width="83px" BackColor="#990000" Font-Bold="True" Font-Italic="False" ForeColor="#FF6600" />                                    
        </td>
      
    </tr>
    <tr>
        <td colspan="2" class="auto-style1">
            <asp:Label ID="lblMessage" runat="server" 
                        ForeColor="Green" Font-Bold="true">
            </asp:Label>
        </td>
    </tr>
</table>
    </form>
</body>
</html>
