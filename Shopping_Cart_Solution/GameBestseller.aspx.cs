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
        DataSet dataCallOfDuty = GetDataCallOfDuty();
        DataSet dataAction = GetDataAction();
        DataSet dataCoOp = GetDataCoOp();
        DataSet dataIndie = GetDataIndie();
        DataSet dataOpenWorld = GetDataOpenWorld();


        CallOfDuty.DataSource = dataCallOfDuty;
        Action.DataSource = dataAction;
        CoOp.DataSource = dataCoOp;
        Indie.DataSource = dataIndie;
        OpenWorld.DataSource = dataOpenWorld;

        CallOfDuty.DataBind();
        Action.DataBind();
        CoOp.DataBind();
        Indie.DataBind();
        OpenWorld.DataBind();


    }

    private DataSet GetDataCallOfDuty()
    {
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {
            
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM GS_CallOfDuty", conn);
            DataSet dataCallOfDuty = new DataSet();
            cmd.Fill(dataCallOfDuty);
            return dataCallOfDuty;
        }
    }

    private DataSet GetDataAction()
    {
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {

            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM GS_Action", conn);
            DataSet dataAction = new DataSet();
            cmd.Fill(dataAction);
            return dataAction;
        }
    }

    private DataSet GetDataCoOp()
    {
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {

            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM GS_CoOp", conn);
            DataSet dataCoOp = new DataSet();
            cmd.Fill(dataCoOp);
            return dataCoOp;
        }
    }

    private DataSet GetDataIndie()
    {
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {

            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM GS_Indie", conn);
            DataSet dataIndie = new DataSet();
            cmd.Fill(dataIndie);
            return dataIndie;
        }
    }

    private DataSet GetDataOpenWorld()
    {
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {

            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM GS_OpenWorld", conn);
            DataSet dataOpenWorld = new DataSet();
            cmd.Fill(dataOpenWorld);
            return dataOpenWorld;
        }
    }
}