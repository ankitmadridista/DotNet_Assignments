using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using SecWebApp.Models;

namespace SecWebApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Home(string id)
        {

            HttpCookie objCookie = Request.Cookies["Laxu"];
            if (Session["user"] != null)
            {
                return View();
            }
            else if (objCookie != null)
            {
                User user = new User
                {
                    UserName = objCookie.Values["UserName"],
                    Password = objCookie.Values["Password"]
                };
                if (IsCookieAlive(user))
                {
                    return View();
                }
                else
                    return RedirectToAction("Login");
            }           
            else {
                return RedirectToAction("Login");
            }
          
        }

        // GET: User/Create
        public ActionResult Create()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Cities";

            SqlDataReader dr = cmd.ExecuteReader();

            User o = new User();

            List<SelectListItem> objCities = new List<SelectListItem>();

            while (dr.Read()) {

                objCities.Add( new SelectListItem {Text= dr["CityName"].ToString(), Value= dr["CityId"].ToString() } );
                
            }
            o.Cities = objCities;

            dr.Close();
            cn.Close();
            
            return View(o);

        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Users values(@UserName,@Password,@FullName,@EmailId,@CityId,@Phone)";

            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@FullName", user.FullName);
            cmd.Parameters.AddWithValue("@EmailId", user.EmailId);
            cmd.Parameters.AddWithValue("@CityId", user.CityId);
            cmd.Parameters.AddWithValue("@Phone", user.Phone);
            try
            {
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {

                return View();
            }
            finally {

                cn.Close();
            }
        }

        // GET: User/Login
        public ActionResult Login()
        {
            HttpCookie objCookie = Request.Cookies["Laxu"];
            if (Session["user"] != null)
            {

                return RedirectToAction("Home");
            }
            else if (objCookie != null)
            {
                User user = new User{
                    UserName = objCookie.Values["UserName"],
                    Password = objCookie.Values["Password"]
                };
                if (IsCookieAlive(user)){
                    return RedirectToAction("Home");
                }
                else{
                    User u = new User();
                    return View(u);
                }
            }
            else
            {
                User u = new User();
                return View(u);
            }
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Login(User user)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Users where UserName=@UserName and Password = @Password";

            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                User u = new User
                {
                    UserName = dr["UserName"].ToString(),
                    Password = dr["Password"].ToString(),
                    FullName = dr["FullName"].ToString(),
                    EmailId = dr["EmailId"].ToString(),
                    CityId = Convert.ToInt32(dr["CityId"].ToString()),
                    Phone = dr["Phone"].ToString()
                };

                Session["user"] = u;
                Session["name"] = u.UserName;
                Session["fullname"] = u.FullName;

                if (user.IsActive) {
                    HttpCookie objCookie = new HttpCookie("Laxu");

                    objCookie.Expires = DateTime.Now.AddDays(2);
                    objCookie.Values["UserName"] = user.UserName;
                    objCookie.Values["Password"] = user.Password;

                    Response.Cookies.Add(objCookie);
                }

                cn.Close();

                return RedirectToAction("Home");
            }
            else {
                cn.Close();
                return RedirectToAction("Login");
            }
            
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            HttpCookie objCookie = Request.Cookies["Laxu"];
            if (objCookie != null) {
                objCookie.Expires = DateTime.Now.AddDays(-1);

                Response.Cookies.Add(objCookie);
            }
           
            return RedirectToAction("Index");

        }

        // GET: User/Edit/5
        public ActionResult Edit()
        {
            HttpCookie objCookie = Request.Cookies["Laxu"];
            if (Session["user"] != null)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
                cn.Open();

                User u = (User)Session["user"];

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cities";

                SqlDataReader dr = cmd.ExecuteReader();

                List<SelectListItem> objCities = new List<SelectListItem>();

                while (dr.Read())
                {
                    objCities.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["CityId"].ToString() });
                }
                u.Cities = objCities;

                dr.Close();
                cn.Close();

                return View(u);
            }
            else if (objCookie != null)
            {
                User user = new User
                {
                    UserName = objCookie.Values["UserName"],
                    Password = objCookie.Values["Password"]
                };
                if (IsCookieAlive(user))
                {
                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
                    cn.Open();

                    User u = (User)Session["username"];

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Cities";

                    SqlDataReader dr = cmd.ExecuteReader();

                    List<SelectListItem> objCities = new List<SelectListItem>();

                    while (dr.Read())
                    {
                        objCities.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["CityId"].ToString() });
                    }
                    u.Cities = objCities;

                    dr.Close();
                    cn.Close();

                    return View(u);
                }
                else
                    return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }


            
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();

            //User u = (User)Session["user"];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Users set Password = @Password, EmailId=@EmailId, FullName=@FullName, CityId=@CityId, Phone=@Phone where UserName=@UserName";
            cmd.Parameters.AddWithValue("@UserName",user.UserName); 
            cmd.Parameters.AddWithValue("@Password", user.Password); 
            cmd.Parameters.AddWithValue("@EmailId", user.EmailId);
            cmd.Parameters.AddWithValue("@FullName", user.FullName); 
            cmd.Parameters.AddWithValue("@CityId", user.CityId);
            cmd.Parameters.AddWithValue("@Phone", user.Phone);

            try
            {
                cmd.ExecuteNonQuery();

                Session["user"] = user;
                Session["name"] = user.UserName;
                Session["fullname"] = user.FullName;

                return RedirectToAction("Home");
            }
            catch
            {
                return View();
            }
            finally {
                cn.Close();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public bool IsCookieAlive(User user) {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Users where UserName=@UserName and Password = @Password";

            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                User u = new User
                {
                    UserName = dr["UserName"].ToString(),
                    Password = dr["Password"].ToString(),
                    FullName = dr["FullName"].ToString(),
                    EmailId = dr["EmailId"].ToString(),
                    CityId = Convert.ToInt32(dr["CityId"].ToString()),
                    Phone = dr["Phone"].ToString()
                };

                Session["username"] = u;
                Session["name"] = u.UserName;
                Session["fullname"] = u.FullName;

                return true;
            }
            return false;
               
        }
    }
}
