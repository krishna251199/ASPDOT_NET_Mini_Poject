using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Day2Project
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("host=localhost;username=root;password=new_password;database=exl_project");

            conn.Open();
            string user = TextBox11.Text;
            string password = TextBox12.Text;

            string query = $"SELECT * from donors where user_id = '{user}' and password = '{password}'";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Response.Write("<script> alert('You are Signed In Successfully');</script>");
            }
            else
            {
                Response.Write("<script> alert('No user ID and password matched');</script>");
            }

            reader.Close();
            conn.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("host=localhost;username=root;password=new_password;database=exl_project");

            conn.Open();


            string full_name = TextBox1.Text;
            string blood = BloodReg.Text;
            string mobile = TextBox2.Text;
            //string district = TextBox9.Text;
            string email = TextBox3.Text;
            string userid = TextBox4.Text;
            string password = TextBox5.Text;
            

            string country = TextBox7.Text;
            string state = TextBox10.Text;
            string city = TextBox12.Text;
            string availability = TextBox13.Text;

            string query = $"INSERT INTO  donors values ('{full_name}','{blood}','{mobile}','{country}','{state}', '{city}' ,'{email}','{userid}','{password}','{availability}');";
           
            
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            Response.Write("<script> alert('User Details Saved');</script>");
            conn.Close();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}