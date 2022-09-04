using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_InsertCallOfDuty : System.Web.UI.Page
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

        GameProduct prod = new GameProduct(txtCallOfDutyID.Text, txtCallOfDutyName.Text,
            txtCallOfDutyDesc.Text, decimal.Parse(txtCallOfDutyPrice.Text),
            image, txtCallOfDutyPublisher.Text, txtCallOfDutyGenre.Text);
        CallOfDuty item = new CallOfDuty(txtCallOfDutyID.Text, image,
            txtCallOfDutyName.Text, txtCallOfDutyPublisher.Text);
        result = prod.ProductInsert();
        result2 = item.CallOfDutyInsert();

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

        txtCallOfDutyPublisher.Text = "";
        txtCallOfDutyDesc.Text = "";
        txtCallOfDutyGenre.Text = "";
        txtCallOfDutyID.Text = "";
        txtCallOfDutyName.Text = "";
        txtCallOfDutyPrice.Text = "";
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin-GameBestseller.aspx");
    }
}
