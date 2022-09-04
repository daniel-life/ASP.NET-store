using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_InsertCoOp : System.Web.UI.Page
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

        Product prod = new Product(txtCoOpID.Text, txtCoOpName.Text,
            txtCoOpDesc.Text, decimal.Parse(txtCoOpPrice.Text),
            image, txtCoOpPublisher.Text, txtCoOpGenre.Text);
        CoOp item = new CoOp(txtCoOpID.Text, image,
            txtCoOpName.Text, txtCoOpPublisher.Text);
        result = prod.ProductInsert();
        result2 = item.CoOpInsert();

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

        txtCoOpPublisher.Text = "";
        txtCoOpDesc.Text = "";
        txtCoOpGenre.Text = "";
        txtCoOpID.Text = "";
        txtCoOpName.Text = "";
        txtCoOpPrice.Text = "";

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageGames");
    }
}