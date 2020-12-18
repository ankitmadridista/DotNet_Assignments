using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstApplication.Models;
using System.Data.SqlClient;
using System.Data;

namespace FirstApplication.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            //List<Employee> lstEmp = new List<Employee>();

            //lstEmp.Add( new Employee {  EmpNo = 1, Name = "abhi", Basic = 10000, DeptNo = 10});
            //lstEmp.Add( new Employee {  EmpNo = 2, Name = "dada", Basic = 10000, DeptNo = 20});
            //lstEmp.Add( new Employee {  EmpNo = 3, Name = "yash", Basic = 10000, DeptNo = 10});
            //lstEmp.Add( new Employee {  EmpNo = 4, Name = "laxu", Basic = 10000, DeptNo = 30});

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees";

            SqlDataReader dr = cmd.ExecuteReader();
            List<Employee> lstEmp = new List<Employee>();
            while (dr.Read())
            {
                lstEmp.Add(new Employee { EmpNo = Convert.ToInt32(dr["EmpNo"]), Name = dr["Name"].ToString(), Basic = Convert.ToDecimal( dr["Basic"]) , DeptNo = Convert.ToInt32(dr["DeptNo"]) });
            }
            cn.Close();
            return View(lstEmp);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id = 0)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees where EmpNo = @EmpNo";
            cmd.Parameters.AddWithValue("@EmpNo", id);

            SqlDataReader dr = cmd.ExecuteReader();
            Employee emp = new Employee();
           
            if (dr.Read()) {
               
                emp.EmpNo = Convert.ToInt32( dr["EmpNo"]);
                emp.Name = dr["Name"].ToString();
                emp.Basic = Convert.ToDecimal(dr["Basic"]);
                emp.DeptNo = Convert.ToInt32( dr["DeptNo"]);
            }

            cn.Close();
            return View(emp);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {          
                // TODO: Add insert logic here
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertEmployee";
                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
            try
            {
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally {
                cn.Close();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees where EmpNo = @EmpNo";
            cmd.Parameters.AddWithValue("@EmpNo", id);

            SqlDataReader dr = cmd.ExecuteReader();
            Employee emp = new Employee();

            if (dr.Read())
            {
                emp.EmpNo = Convert.ToInt32(dr["EmpNo"]);
                emp.Name = dr["Name"].ToString();
                emp.Basic = Convert.ToDecimal(dr["Basic"]);
                emp.DeptNo = Convert.ToInt32(dr["DeptNo"]);
            }

            cn.Close();
            return View(emp);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updateEmployee";
            cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Basic", emp.Basic);
            cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
            try
            {
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees where EmpNo = @EmpNo";
            cmd.Parameters.AddWithValue("@EmpNo", id);

            SqlDataReader dr = cmd.ExecuteReader();
            Employee emp = new Employee();

            if (dr.Read())
            {
                emp.EmpNo = Convert.ToInt32(dr["EmpNo"]);
                emp.Name = dr["Name"].ToString();
                emp.Basic = Convert.ToDecimal(dr["Basic"]);
                emp.DeptNo = Convert.ToInt32(dr["DeptNo"]);
            }

            cn.Close();
            return View(emp);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deleteEmployee";
            cmd.Parameters.AddWithValue("@EmpNo", id);
            
            try
            {
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
