using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestApplication.Models;

namespace TestApplication.Services
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        public bool Add_Employee(Employee _emp)
        {
            SqlCommand cmd = new SqlCommand("Create_Entry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", _emp.Name);
            cmd.Parameters.AddWithValue("@Email", _emp.Email);
            cmd.Parameters.AddWithValue("@Gender", _emp.Gender);
            cmd.Parameters.AddWithValue("@Contact_Number", _emp.Contact_Number);
            cmd.Parameters.AddWithValue("@Joining_Date", Convert.ToDateTime( _emp.ProJoining_Date));
            //cmd.Parameters.AddWithValue("@Status", _emp.Status);
            cmd.Parameters.AddWithValue("@Action", "Create");
            con.Open();
            var count = cmd.ExecuteNonQuery();
            con.Close();
            if (count > 0) return true;
            else return false;
        }
        public bool Update_Employee(Employee _emp)
        {
            SqlCommand cmd = new SqlCommand("Create_Entry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Update");
            cmd.Parameters.AddWithValue("@Name", _emp.Name);
            cmd.Parameters.AddWithValue("@Email", _emp.Email);
            cmd.Parameters.AddWithValue("@Gender", _emp.Gender);
            cmd.Parameters.AddWithValue("@Id", _emp.Id);
            cmd.Parameters.AddWithValue("@Joining_Date", Convert.ToDateTime(_emp.ProJoining_Date));
            //cmd.Parameters.AddWithValue("@Status", _emp.Status);
            cmd.Parameters.AddWithValue("@Contact_Number", _emp.Contact_Number);
            con.Open();
            var count = cmd.ExecuteNonQuery();
            con.Close();
            if (count > 0) return true;
            else return false;
        }
        public Employee GetEmployeeById(int Id)
        {
            Employee _emp = new Employee();
            try
            {
                SqlCommand cmd = new SqlCommand("Create_Entry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "GetById");
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    _emp.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    _emp.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    _emp.Contact_Number = ds.Tables[0].Rows[i]["Contact_Number"].ToString();
                    _emp.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                    _emp.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                    _emp.Joining_Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Joining_Date"].ToString());
                    _emp.ProJoining_Date = _emp.Joining_Date.ToString("dd-MM-yyyy");
                    //_emp.Joining_Date = Convert.ToDateTime( ds.Tables[0].Rows[i]["Joining_Date"].ToString());
                    // _emp.Status = Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"].ToString());
                }
                return _emp;
            }
            catch (Exception)
            {

                return _emp;
            }
            finally
            {
                con.Close();
            }
        }
        public bool Delete_Employee(int Id)
        {
            SqlCommand cmd = new SqlCommand("Create_Entry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            var count = cmd.ExecuteNonQuery();
            con.Close();
            if (count > 0) return true;
            else return false;
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> _emplist = new List<Employee>();
            try
            {
                SqlCommand cmd = new SqlCommand("Create_Entry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
               
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Employee _emp = new Employee();
                    _emp.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    _emp.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    _emp.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                    _emp.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                    _emp.Contact_Number = ds.Tables[0].Rows[i]["Contact_Number"].ToString();
                    _emp.Joining_Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Joining_Date"].ToString());
                    _emp.ProJoining_Date = _emp.Joining_Date.ToString("dd-MM-yyyy");
                    //_emp.Joining_Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Joining_Date"].ToString());
                    //_emp.Status = Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"].ToString());
                    _emplist.Add(_emp);
                }
                return _emplist;
            }
            catch (Exception)
            {
                return _emplist;
            }
            finally
            {
                con.Close();
            }
            
        }
    }
}