// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Delete.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Employeeclient
{
    using System;

    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeService.Service1Client client = new EmployeeService.Service1Client();
            EmployeeService.Employee employee = new EmployeeService.Employee();
            employee.Id = Convert.ToInt32(txtID.Text);
            var result=client.Delete(employee);
            if (result == true)
                Server.Transfer("Operation.aspx");
            else
                lblMessage.Text = "Id will not be correct";
                
        }
    }
}