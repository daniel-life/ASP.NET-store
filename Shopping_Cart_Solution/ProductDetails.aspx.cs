﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ProductDetails : BasePage
{
    //declare a new Product class
    Product prod = null;
    DataTable dt = new DataTable();

    //retrieve connection info from web.config
    string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        Product aProd = new Product();

        //request ProdID from QueryString (PostBackURL)
        string prodID = Request.QueryString["ProdID"].ToString();
        prod = aProd.getProduct(prodID);

        lblTitle.Text = prod.Product_Name;
        lblDescription.Text = prod.Product_Desc;
        lblPrice.Text = prod.Unit_Price.ToString("C");
        lblPrice2.Text = prod.Unit_Price.ToString("C");
        imgProductDetails.ImageUrl = prod.Product_Image;
        lblAuthor.Text = prod.Book_Author;
        lblGenre.Text = prod.Book_Genre;

        if (!IsPostBack)
        {
            DataTable dt = this.GetData("SELECT ISNULL(AVG(Rating), 0) AverageRating, COUNT(Rating) " +
                "RatingCount FROM [BS_RATINGS] WHERE Title = @booktitle");

            //display rating
            Rating1.CurrentRating = Convert.ToInt32(dt.Rows[0]["AverageRating"]);
            lblresult.Text = string.Format("{0} Ratings ", dt.Rows[0]["RatingCount"]);
            lblavgrating.Text = string.Format("{0}", dt.Rows[0]["AverageRating"]);
        }
    }

    public void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(constr);

        //insert rating into database
        SqlCommand cmd = new SqlCommand("INSERT INTO [BS_RATINGS] VALUES (@ratingvalue,@review,@title)");
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ratingvalue", Rating1.CurrentRating.ToString());
        cmd.Parameters.AddWithValue("@review", txtreview.Text);
        cmd.Parameters.AddWithValue("@title", lblTitle.Text);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.Url.AbsoluteUri);
    }

    //extract table data
    private DataTable GetData(string query)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(query);
        cmd.Parameters.AddWithValue("@booktitle", lblTitle.Text);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        sda.SelectCommand = cmd;
        sda.Fill(dt);
        return dt;

        

    }


}