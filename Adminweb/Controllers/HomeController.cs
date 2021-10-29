﻿using Adminweb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adminweb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult City()
        {
            return View();
        }
        public ActionResult Employee()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Department()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmp(Employee Data)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoundPay"].ConnectionString);
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_Employee values(@Name, @Email, @PhoneNo, @Gender, @Department, @Skill, @State, @City)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", Data.Name);
                cmd.Parameters.AddWithValue("@Email", Data.Email);
                cmd.Parameters.AddWithValue("@PhoneNo", Data.PhoneNo);
                cmd.Parameters.AddWithValue("@Gender", Data.Gender);
                cmd.Parameters.AddWithValue("@Department", Data.Department);
                cmd.Parameters.AddWithValue("@Skill", Data.Skill);
                cmd.Parameters.AddWithValue("@State", Data.State);
                cmd.Parameters.AddWithValue("@City", Data.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Json(i);
        }

        [HttpGet]
        public ActionResult getEmp()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoundPay"].ConnectionString);
            List<Employee> empp = new List<Employee>();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from tbl_Employee", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                con.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                ;

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Employee Emp = new Employee();
                        Emp.ID = Convert.ToInt32(dr["_Id"]);

                        Emp.Name = Convert.ToString(dr["_Name"]);
                        Emp.Email = Convert.ToString(dr["_Email"]);
                        Emp.PhoneNo = Convert.ToString(dr["_PhoneNo"]);
                        Emp.Gender = Convert.ToString(dr["_Gender"]);
                        Emp.Department = Convert.ToString(dr["_Department"]);
                        Emp.Skill = Convert.ToString(dr["_Skill"]);
                        Emp.State = Convert.ToString(dr["_State"]);
                        Emp.City = Convert.ToString(dr["_City"]);

                        empp.Add(Emp);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Json(empp, JsonRequestBehavior.AllowGet);
        }
        public ActionResult State()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult UpdateEmp(Employee Data)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoundPay"].ConnectionString);
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("update tbl_Employee  set  _Name=@Name,	_Email=@Email, _PhoneNo=@PhoneNo, _Gender=@Gender, _Department=@Department,	_Skill=@Skill,	_State=@State,	_City=@City where _Id=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", Data.ID);
                cmd.Parameters.AddWithValue("@Name", Data.Name);
                cmd.Parameters.AddWithValue("@Email", Data.Email);
                cmd.Parameters.AddWithValue("@PhoneNo", Data.PhoneNo);
                cmd.Parameters.AddWithValue("@Gender", Data.Gender);
                cmd.Parameters.AddWithValue("@Department", Data.Department);
                cmd.Parameters.AddWithValue("@Skill", Data.Skill);
                cmd.Parameters.AddWithValue("@State", Data.State);
                cmd.Parameters.AddWithValue("@City", Data.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Json(i);

        }

        [HttpPost]
        public ActionResult DeleteEmp(Employee Data)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoundPay"].ConnectionString);
            int i = 0;
            try
            {
                //SqlCommand cmd = new SqlCommand("delete from tbl_Employee where Id='"+ Data.ID+ "'", con);
                SqlCommand cmd = new SqlCommand("delete from tbl_Employee where _Id=@ID", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", Data.ID);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Json(i);
        }
        [HttpPost]
        public ActionResult AddState(string State)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoundPay"].ConnectionString);
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_States values(@State)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@State", State);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Json(i);
        }

        [HttpGet]
        public ActionResult getState()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoundPay"].ConnectionString);
            List<States> state = new List<States>();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from tbl_States", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                con.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                ;

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        States sta = new States();
                        sta.Id = Convert.ToInt32(dr["Id"]);

                        sta.StateName = Convert.ToString(dr["State"]);


                        state.Add(sta);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Json(state, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Del_State(States obj)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoundPay"].ConnectionString);
            int i = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("delete from tbl_States where Id=@Id", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", obj.Id);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Json(i);
        }
        [HttpGet]
        public ActionResult getCity()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoundPay"].ConnectionString);
            List<City> city = new List<City>();
            try
            {


                // SqlCommand cmd = new SqlCommand("select * from tbl_City", con);
                SqlCommand cmd = new SqlCommand("select c.*,s.State from tbl_City c join tbl_States s on c.StateId = s.Id", con);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                con.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                ;

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        City cty = new City();
                        cty.Id = Convert.ToInt32(dr["Id"]);

                        cty.CityName = Convert.ToString(dr["City"]);
                        cty.State = Convert.ToString(dr["State"]);

                        city.Add(cty);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Json(city, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddCity(City obj)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoundPay"].ConnectionString);
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_City (City,StateId) values(@City, @StateId)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@City",obj.CityName);
                cmd.Parameters.AddWithValue("@StateId", obj.StateId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Json(i);
        }
        [HttpPost]
        public ActionResult Del_City(City obj)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoundPay"].ConnectionString);
            int i = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("delete from tbl_City where Id=@Id", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", obj.Id);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Json(i);
        }

    }
}




 
