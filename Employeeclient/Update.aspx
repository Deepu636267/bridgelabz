<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Employeeclient.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <table style="font-family:Arial; border:1px solid black;">
    <tr>
        <td>
            <b>ID</b>
        </td>
        <td>
            <asp:TextBox ID="txtID" runat="server">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtID" ErrorMessage="Id Reuired"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <b>Name</b>
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>Gender</b>
        </td>
        <td>
            <asp:TextBox ID="txtGender" runat="server">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>Address</b>
        </td>
        <td>
            <asp:TextBox ID="txtaddress" runat="server">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>Password</b>
        </td>
        <td>
            <asp:TextBox ID="txtpassword" runat="server">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
       <td colspan="2">
            <asp:Button ID="btnupdate" runat="server" 
                        Text="Update Employee" 
                        onclick="btnUpdate_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblMessage" runat="server" 
                        ForeColor="Green" Font-Bold="true">
            </asp:Label>
        </td>
    </tr>
</table>
    </form>
</body>
</html>
