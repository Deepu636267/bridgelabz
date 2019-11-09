// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Update.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Employeeclient
{
    using System;
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            EmployeeService.Service1Client client = new EmployeeService.Service1Client();
            EmployeeService.Employee employee = new EmployeeService.Employee();
            employee.Id = Convert.ToInt32(txtID.Text);
            employee.Name = txtName.Text;
            employee.Gender = txtGender.Text;
            employee.Address = txtaddress.Text;
            employee.Password = txtpassword.Text;
            var result=client.Update(employee);
            if(result==true)
                Server.Transfer("Operation.aspx");
            else
                lblMessage.Text ="ID Will Not Match";
        }
    }
}