using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class GameSearch : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //retrieve the session variable
        txtSearch2.Text = Session["Search"].ToString();

        //PostBack allows the search function to run again when another string is entered into the textbox.
        //if PostBack is not true/enabled, the method will only run one time and not run again if a new
        //string is entered.
        if (!IsPostBack)
        {
            //retrieve connection info from web.config
            string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            //open the connection
            myConnect.Open();

            //create search command to retrieve data from table
            string checksearch = "SELECT COUNT(*) FROM [GS_ALL_Products] WHERE Title LIKE @search OR Publisher LIKE @search";
            SqlCommand com = new SqlCommand(checksearch, myConnect);

            //declare @search
            com.Parameters.AddWithValue("@search", txtSearch2.Text);
            com.Parameters["@search"].Value = "%" + txtSearch2.Text + "%";

            //use temp to create a fucntion
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

            //close the connection
            myConnect.Close();

            //if the record exists
            if (temp > 0)
            {
                string strCommandText = "SELECT *";
                strCommandText += " FROM GS_ALL_Products WHERE Title LIKE @title OR Publisher LIKE @publisher";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);

                //declare cmd parameters for title and author to be dispayed
                cmd.Parameters.Add("@title", SqlDbType.NVarChar, 50);
                cmd.Parameters["@title"].Value = "%" + txtSearch2.Text + "%";
                cmd.Parameters.Add("@publisher", SqlDbType.NVarChar, 50);
                cmd.Parameters["@publisher"].Value = "%" + txtSearch2.Text + "%";

                //open the connection
                myConnect.Open();

                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Title");
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                //close the connection
                myConnect.Close();
            }

            //else record does not exist
            else
            {
                lblnoresult2.Visible = true;
            }
        }
    }
}