// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Operation.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Employeeclient
{
    using System;
    public partial class Operation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the btnGetEmployee control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            EmployeeService.Service1Client client = new EmployeeService.Service1Client();
            GridView1.DataSource = client.GetEmployee();
            GridView1.DataBind();
            

        }
        /// <summary>
        /// Handles the Click event of the btnAddEmployee control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Server.Transfer("AddData.aspx");
        }
        /// <summary>
        /// Handles the Click event of the btnDeleteEmployee control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            Server.Transfer("Delete.aspx");
        }
        /// <summary>
        /// Handles the Click event of the btnUpdateEmployee control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            Server.Transfer("Update.aspx");
        }
    }
}