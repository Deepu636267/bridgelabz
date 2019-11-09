<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Employeeclient.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
    </style>
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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtID" ErrorMessage="Id will Be required"></asp:RequiredFieldValidator>
        </td>
    </tr>
              <tr>
       <td colspan="2" class="auto-style1">
            <asp:Button ID="btnDelete" runat="server" 
                        Text="Delete Employee" 
                        onclick="btnSave_Click" />
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
