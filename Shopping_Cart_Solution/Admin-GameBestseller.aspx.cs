using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class GameBestseller : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindRepeater();
        }
    }

    private void BindRepeater()
    {
        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Call Of Duty_CRUD"))
            {
                cmd.Parameters.AddWithValue("@Action", "SELECT");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        CallOfDuty.DataSource = dt;
                        CallOfDuty.DataBind();
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand("Action_CRUD"))
            {
                cmd.Parameters.AddWithValue("@Action", "SELECT");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Action.DataSource = dt;
                        Action.DataBind();
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand("CoOp_CRUD"))
            {
                cmd.Parameters.AddWithValue("@Action", "SELECT");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        CoOp.DataSource = dt;
                        CoOp.DataBind();
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand("Indie_CRUD"))
            {
                cmd.Parameters.AddWithValue("@Action", "SELECT");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Indie.DataSource = dt;
                        Indie.DataBind();
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand("OpenWorld_CRUD"))
            {
                cmd.Parameters.AddWithValue("@Action", "SELECT");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        OpenWorld.DataSource = dt;
                        OpenWorld.DataBind();
                    }
                }
            }
        }
    }

    protected void OnEdit(object sender, EventArgs e)
    {
        //Find the reference of the Repeater Item.
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        this.ToggleElements(item, true);
    }

    protected void OnCancel(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        this.ToggleElements(item, false);
    }

    protected void OnUpdate(object sender, EventArgs e)
    {
        //Find the reference of the Repeater Item.
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

        //Finds the matching BS_ID in the row of data
        int GameId = int.Parse((item.FindControl("lblGameId") as Label).Text);
        //Trim() allows data to be modified
        string name = (item.FindControl("txtTitle") as TextBox).Text.Trim();
        string price = (item.FindControl("txtDeveloper") as TextBox).Text.Trim();
        string image = (item.FindControl("txtImage") as TextBox).Text.Trim();

        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            //using stored procedure
            using (SqlCommand cmd = new SqlCommand("Call Of Duty_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //call the action UPDATE
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                //pass in new values
                cmd.Parameters.AddWithValue("@GameId", GameId);
                cmd.Parameters.AddWithValue("@Title", name);
                cmd.Parameters.AddWithValue("@Publisher", price);
                cmd.Parameters.AddWithValue("@Image", image);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            using (SqlCommand cmd = new SqlCommand("Action_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //call the action UPDATE
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                //pass in new values
                cmd.Parameters.AddWithValue("@GameId", GameId);
                cmd.Parameters.AddWithValue("@Title", name);
                cmd.Parameters.AddWithValue("@Publisher", price);
                cmd.Parameters.AddWithValue("@Image", image);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            using (SqlCommand cmd = new SqlCommand("CoOp_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //call the action UPDATE
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                //pass in new values
                cmd.Parameters.AddWithValue("@GameId", GameId);
                cmd.Parameters.AddWithValue("@Title", name);
                cmd.Parameters.AddWithValue("@Publisher", price);
                cmd.Parameters.AddWithValue("@Image", image);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("Indie_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //call the action UPDATE
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                //pass in new values
                cmd.Parameters.AddWithValue("@GameId", GameId);
                cmd.Parameters.AddWithValue("@Title", name);
                cmd.Parameters.AddWithValue("@Publisher", price);
                cmd.Parameters.AddWithValue("@Image", image);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            using (SqlCommand cmd = new SqlCommand("OpenWorld_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //call the action UPDATE
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                //pass in new values
                cmd.Parameters.AddWithValue("@GameId", GameId);
                cmd.Parameters.AddWithValue("@Title", name);
                cmd.Parameters.AddWithValue("@Publisher", price);
                cmd.Parameters.AddWithValue("@Image", image);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        //display
        this.BindRepeater();
    }

    protected void OnDelete(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        int gameId = int.Parse((item.FindControl("lblGameId") as Label).Text);

        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Call Of Duty_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@GameId", gameId);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            using (SqlCommand cmd = new SqlCommand("Action_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@GameId", gameId);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            using (SqlCommand cmd = new SqlCommand("CoOp_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@GameId", gameId);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            using (SqlCommand cmd = new SqlCommand("Indie_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@GameId", gameId);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            using (SqlCommand cmd = new SqlCommand("OpenWorld_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@GameId", gameId);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        this.BindRepeater();
    }




    private void ToggleElements(RepeaterItem item, bool isEdit)
    {
        //Toggle Buttons.
        item.FindControl("lnkEdit").Visible = !isEdit;
        item.FindControl("lnkUpdate").Visible = isEdit;
        item.FindControl("lnkCancel").Visible = isEdit;


        //Toggle Labels.
        item.FindControl("lblTitle").Visible = !isEdit;
        item.FindControl("lblPublisher").Visible = !isEdit;
        item.FindControl("imgGames").Visible = !isEdit;

        //Toggle TextBoxes.
        item.FindControl("txtTitle").Visible = isEdit;
        item.FindControl("txtDeveloper").Visible = isEdit;
        item.FindControl("txtImage").Visible = isEdit;
    }




    protected void btnCallOfDuty_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCallOfDuty");
    }

    protected void btnAddAction_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddAction");
    }

    protected void btnAddCoOp_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCoOp");
    }

    protected void btnAddIndie_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddIndie");
    }

    protected void btnAddOpenWorld_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddOpenWorld");
    }
}