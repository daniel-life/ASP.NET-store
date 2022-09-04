using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_InsertAction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnInsertItems_Click(object sender, EventArgs e)
    {
        int result = 0;
        int result2 = 0;
        string image = "";

        if (FileUpload1.HasFile == true)
        {
            image = "images/" + FileUpload1.FileName;
        }

        Product prod = new Product(txtActionID.Text, txtActionName.Text,
            txtActionDesc.Text, decimal.Parse(txtActionPrice.Text),
            image, txtActionPublisher.Text, txtActionGenre.Text);
        Action item = new Action(txtActionID.Text, image,
            txtActionName.Text, txtActionPublisher.Text);
        result = prod.ProductInsert();
        result2 = item.ActionInsert();

        if (result > 0)
        {
            string saveimg = Server.MapPath(" ") + "\\" + image;
            FileUpload1.SaveAs(saveimg);
            //loadProductInfo();
            //loadProduct();
            //clear1();
        }

        if (result2 > 0)
        {
            string saveimg = Server.MapPath(" ") + "\\" + image;
            FileUpload1.SaveAs(saveimg);
            //loadProductInfo();
            //loadProduct();
            //clear1();
            Response.Write("<script>alert('Insert Successful');</script>");
        }
        else { Response.Write("<script>alert('Failed to Insert');</script>"); }

        txtActionPublisher.Text = "";
        txtActionDesc.Text = "";
        txtActionGenre.Text = "";
        txtActionID.Text = "";
        txtActionName.Text = "";
        txtActionPrice.Text = "";

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageGames");
    }
}