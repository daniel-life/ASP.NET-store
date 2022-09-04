using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Salt_Password_Sample;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void Submit_Click(object sender, EventArgs e)
    {
        Session["Password"] = OldPassword.Text;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString);
        SqlDataAdapter sda = new SqlDataAdapter("select Password from REGISTRATION where Password = '" + OldPassword.Text + "' ", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count.ToString() == "1")
        {
            if (NewPassword.Text == CfmPassword.Text)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("update REGISTRATION set Password = '"+ Hash.ComputeHash(CfmPassword.Text, "SHA512", null) + "' where password = '"+ OldPassword.Text + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();
                Label1.Text = "Successfully Updated!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Label1.Text = "New password and Confirm password is not the same!";
            }
        }
        else
        {
            Label1.Text = "Please check your old password!";
        }

    }
}