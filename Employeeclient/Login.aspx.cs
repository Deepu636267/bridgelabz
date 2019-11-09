// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Login.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Employeeclient
{
    using System;
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            EmployeeService.Service1Client client = new EmployeeService.Service1Client();
            EmployeeService.Employee employee = new EmployeeService.Employee();
            employee.Name = txtName.Text;
            employee.Password = txtPassword.Text;
            
            var result= client.M_Login(employee);
            if (result == true)
            {
               lblMessage.Text = "loginsuccesfully";
               Server.Transfer("Operation.aspx");
            }
            else
            { 
               lblMessage.Text = "LoginCredential Not correct";
            }
        }
    }
}