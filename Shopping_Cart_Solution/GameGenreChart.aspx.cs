using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Configuration;

public partial class GameGenreChart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetChartData();
            GetChartTypes();
        }

    }

    private void GetChartTypes()
    {
        foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))
        {
            ListItem li = new ListItem(Enum.GetName(typeof(SeriesChartType),
                chartType), chartType.ToString());
            DropDownList1.Items.Add(li);
        }
    }

    private void GetChartData()
    {
        string cs = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new
                    SqlCommand("Select Genre, NoOfGames from GameGenre", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Series series = Chart1.Series["Series1"];
            while (rdr.Read())
            {
                series.Points.AddXY(rdr["Genre"].ToString(),
                    rdr["NoOfGames"]);
            }
        }

    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetChartData();
        this.Chart1.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(
            typeof(SeriesChartType), DropDownList1.SelectedValue);

    }
}