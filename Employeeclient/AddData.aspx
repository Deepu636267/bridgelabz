<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddData.aspx.cs" Inherits="Employeeclient.AddData" %>

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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtID" ErrorMessage="ID Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <b>Name</b>
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="Name Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <b>Gender</b>
        </td>
        <td>
            <asp:TextBox ID="txtGender" runat="server">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGender" ErrorMessage="Gender will Be Requried"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <b>Address</b>
        </td>
        <td>
            <asp:TextBox ID="txtaddress" runat="server">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtaddress" ErrorMessage="Address Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <b>Password</b>
        </td>
        <td>
            <asp:TextBox ID="txtpassword" runat="server">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtpassword" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
       <td colspan="2">
            <asp:Button ID="btnSave" runat="server" 
                        Text="Save Employee" 
                        onclick="btnSave_Click" />
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
