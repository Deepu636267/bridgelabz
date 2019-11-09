<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Operation.aspx.cs" Inherits="Employeeclient.Operation" %>

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
            <asp:Button ID="btnGetEmployee" runat="server" 
                                 Text="Get Employee" 
                                 onclick="btnGetEmployee_Click" />                                    
        </td>
        <td>
            <asp:Button ID="btnSave" runat="server" 
                        Text="Add Employee" 
                        onclick="btnAddEmployee_Click" />
        </td>
         <td>
            <asp:Button ID="btnDelete" runat="server" 
                        Text="Delete Employee" 
                        onclick="btnDeleteEmployee_Click"/>
        </td>
               <td>
            <asp:Button ID="btnUpdate" runat="server" 
                        Text="Update Employee" 
                        onclick="btnUpdateEmployee_Click" />
        </td>
    </tr>
          </table>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
