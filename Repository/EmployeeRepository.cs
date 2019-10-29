using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployementManagementSystem.Model;
using Microsoft.Extensions.Configuration;

using System.Data;
using Microsoft.IdentityModel.Protocols;
//using System.Configuration;

namespace EmployementManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration configuration;
        private SqlConnection con=null;
        string constr = null;
        public EmployeeRepository(IConfiguration configurations)
        {
            configuration = configurations;
        }
        private void Connection()
        {
            constr = configuration.GetSection("ConnectionStrings").GetSection("EmployeeContext").Value;
            con = new SqlConnection(constr);
        }
        public bool Create(string EmpName,string Designation,string Gender,string Email,string EmpPassword,string Address)
        {
            Connection();
            SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
            Model.EmployeeModel employee = new Model.EmployeeModel();
            employee.EmpName = EmpName;
            employee.Designation = Designation;
            employee.Gender = Gender;
            employee.Email = Email;
            employee.EmpPassword = EmpPassword;
            employee.Address = Address;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpName", employee.EmpName);
            com.Parameters.AddWithValue("@Designation", employee.Designation);
            com.Parameters.AddWithValue("@Gender", employee.Gender);
            com.Parameters.AddWithValue("@Email", employee.Email);
            com.Parameters.AddWithValue("@EmpPassword", employee.EmpPassword);
            com.Parameters.AddWithValue("@Address", employee.Address);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Update(EmployeeModel employee)
        {
            Connection();
            SqlCommand command = new SqlCommand("UpdateEmpDetails", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmpId", employee.EmpId);
            command.Parameters.AddWithValue("@EmpName", employee.EmpName);
            command.Parameters.AddWithValue("@Designation", employee.Designation);
            command.Parameters.AddWithValue("@Gender", employee.Gender);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@EmpPassword", employee.EmpPassword);
            command.Parameters.AddWithValue("@Address", employee.Address);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(EmployeeModel employee)
        {
            Connection();
            SqlCommand command = new SqlCommand("DeleteEmpById", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmpId", employee.EmpId);
            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public List<EmployeeModel> Retrieve()
        {
            Connection();
            List<EmployeeModel> EmpList = new List<EmployeeModel>();
            SqlCommand command = new SqlCommand("GetEmployees", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            EmpList = (from DataRow dr in dt.Rows

                       select new EmployeeModel()
                       {
                           EmpId = Convert.ToInt32(dr["EmpId"]),
                           EmpName = Convert.ToString(dr["EmpName"]),
                           Designation = Convert.ToString(dr["Designation"]),
                           Gender = Convert.ToString(dr["Gender"]),
                           Email = Convert.ToString(dr["Email"]),
                           EmpPassword = Convert.ToString(dr["EmpPassword"]),
                           Address = Convert.ToString(dr["Address"])
                       }).ToList();


            return EmpList;

        }

        public bool M_Login(EmployeeModel login)
        {
            Connection();
            SqlCommand command = new SqlCommand("M_Login", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", login.EmpName);
            command.Parameters.AddWithValue("@EmpPassword", login.EmpPassword);
            con.Open();
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataSet);
            con.Close();
            bool loginSuccessful = ((dataSet.Tables.Count > 0) && (dataSet.Tables[0].Rows.Count > 0));
            if (loginSuccessful && login.EmpName != "" && login.EmpPassword != null)
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