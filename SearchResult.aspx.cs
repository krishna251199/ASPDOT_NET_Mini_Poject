using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Day2Project
{
    public partial class SearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("host=localhost;username=root;password=new_password;database=exl_project");
            
            conn.Open();



            string blood = TextBox13.Text;
            string country = TextBox9.Text;
            string state = TextBox10.Text;
            string city = TextBox12.Text;


            string query = $"SELECT * from donors where blood_group = '{blood}' and country = '{country}' and state='{state}' and city='{city}';";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();

            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}