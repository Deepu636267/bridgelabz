// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Service1.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace EmployeeManagement
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.ServiceModel.Web;
    /// <summary>
    /// Service1 is a class which inherit the IService1 intface
    /// </summary>
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private SqlConnection con = null;
        string constr = null;
        /// <summary>
        /// Connection is a method which is used to get connected with the database
        /// </summary>
        private void Connection()
        {
            try
            {
                constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                con = new SqlConnection(constr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// AddEmployee is a method for adding new Data in to the database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddEmployee(Employee employee)
        {
            Connection();
            SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", employee.Id);
            com.Parameters.AddWithValue("@Name", employee.Name);
            com.Parameters.AddWithValue("@Gender", employee.Gender);
            com.Parameters.AddWithValue("@Address", employee.Address);
            com.Parameters.AddWithValue("@Password", employee.Password);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Delete is method which is used for delete the record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Delete(Employee employee)
        {
            Connection();
            SqlCommand command = new SqlCommand("DeleteEmpById", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", employee.Id);
            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// GetEmployee is method to get all the employee List
        /// </summary>
        /// <returns></returns>
        [WebInvoke]
        public List<Employee> GetEmployee()
        {
            Connection();
            List<Employee> EmpList = new List<Employee>();
            SqlCommand command = new SqlCommand("GetEmployees", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            EmpList = (from DataRow dr in dt.Rows
                       select new Employee()
                       {
                           Id = Convert.ToInt32(dr["Id"]),
                           Name = Convert.ToString(dr["Name"]),
                           Gender = Convert.ToString(dr["Gender"]),
                           Address = Convert.ToString(dr["Address"]),
                           Password = Convert.ToString(dr["Password"])
                         
                       }).ToList();
            return EmpList;
        }
        /// <summary>
        /// M_Login is a method which has for the login to the employee in to our system
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool M_Login(Employee login)
        {
            Connection();
            SqlCommand command = new SqlCommand("Login", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", login.Name);
            command.Parameters.AddWithValue("@Password", login.Password);
            con.Open();
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataSet);
            con.Close();
            bool loginSuccessful = ((dataSet.Tables.Count > 0) && (dataSet.Tables[0].Rows.Count > 0));
            if (loginSuccessful && login.Name != "" && login.Password != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Update is a method which is used for updating the databse record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Update(Employee employee)
        {
            Connection();
            SqlCommand command = new SqlCommand("UpdateEmpDetails", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", employee.Id);
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Gender", employee.Gender);
            command.Parameters.AddWithValue("@Address", employee.Address);
            command.Parameters.AddWithValue("@Password", employee.Password);
            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}