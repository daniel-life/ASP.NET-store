using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for GameProduct
/// </summary>
public class GameProduct
{
    //system.Configuration.ConnectionStringSettings _connStr;
    string _connStr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
    private string _prodID = null;
    private string _prodName = string.Empty;
    private string _prodDesc = "";
    private decimal _unitPrice = 0;
    private string _prodImage = "";
    private string _gamePublisher = "";
    private string _gameGenre = "";

    public GameProduct()
    {
    }

    public GameProduct(string prodID, string prodName, string prodDesc,
                   decimal unitPrice, string prodImage, string gamePublisher, string gameGenre)
    {
        //
        // TODO: Add constructor logic here
        //
        _prodID = prodID;
        _prodName = prodName;
        _prodDesc = prodDesc;
        _unitPrice = unitPrice;
        _prodImage = prodImage;
        _gamePublisher = gamePublisher;
        _gameGenre = gameGenre;
    }

    //get/set the attributes of the Product object.
    //note the attribute name (e.g. Product_ID) is same as the actual database field name.
    //this is for ease of referencing.

    public string Product_ID
    {
        get { return _prodID; }
        set { _prodID = value; }
    }
    public string Product_Name
    {
        get { return _prodName; }
        set { _prodName = value; }
    }
    public string Product_Desc
    {
        get { return _prodDesc; }
        set { _prodDesc = value; }
    }
    public decimal Unit_Price
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }
    public string Product_Image
    {
        get { return _prodImage; }
        set { _prodImage = value; }
    }

    public string Game_Publisher
    {
        get { return _gamePublisher; }
        set { _gamePublisher = value; }
    }
    public string Game_Genre
    {
        get { return _gameGenre; }
        set { _gameGenre = value; }
    }

    //below as the Class methods for some DB operations. 
    public GameProduct getGameProduct(string prodID)
    {
        GameProduct prodDetail = null;

        string prod_Name, prod_Desc, Prod_Image, Game_Publisher, Game_Genre;
        decimal unit_Price;

        string queryStr = "SELECT * FROM GS_ALL_Products WHERE ID = @ProdID";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ProdID", prodID);

        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            prod_Name = dr["Title"].ToString();
            prod_Desc = dr["Description"].ToString();
            Prod_Image = dr["Image"].ToString();
            unit_Price = decimal.Parse(dr["Price"].ToString());
            Game_Publisher = dr["Publisher"].ToString();
            Game_Genre = dr["Genre"].ToString();

            prodDetail = new GameProduct(prodID, prod_Name, prod_Desc, unit_Price, Prod_Image, Game_Publisher, Game_Genre);
        }
        else
        {
            prodDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();

        return prodDetail;
    }

    public int UserDelete(string ID)
    {
        string queryStr = "DELETE FROM Registration WHERE ID=@ID";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int ProductInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO GS_ALL_Products(ID, Title, Description, Price, Image, Publisher, Genre)" + "values (@Product_ID, @Product_Name, @Product_Desc, @Unit_Price, @Product_Image, @Game_Publisher, @Game_Genre)";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
        cmd.Parameters.AddWithValue("@Product_Name", this.Product_Name);
        cmd.Parameters.AddWithValue("@Product_Desc", this.Product_Desc);
        cmd.Parameters.AddWithValue("@Unit_Price", this.Unit_Price);
        cmd.Parameters.AddWithValue("@Product_Image", this.Product_Image);
        cmd.Parameters.AddWithValue("@Game_Publisher", this.Game_Publisher);
        cmd.Parameters.AddWithValue("@Game_Genre", this.Game_Genre);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }//end Insert
}

public class CallOfDuty
{
    //System.Configuration.ConnectionStringSettings _connStr;
    string _connStr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
    private string _prodID = null;
    private string _prodName = string.Empty;
    private string _prodImage = "";
    private string _gamePublisher;


    // Default constructor
    public CallOfDuty()
    {
    }

    // PRODUCTS
    public CallOfDuty(string prodID, string prodName, string prodImage, string gamePublisher)
    {
        _prodID = prodID;
        _prodName = prodName;
        _prodImage = prodImage;
        _gamePublisher = gamePublisher;
    }

    // Constructor that take in all except product ID
    public CallOfDuty(string prodName, string prodImage, string gamePublisher)
        : this(null, prodName, prodImage, gamePublisher)
    {
    }

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
    public CallOfDuty(string prodID)
        : this(prodID, "", "", "")
    {
    }

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public string Product_ID
    {
        get { return _prodID; }
        set { _prodID = value; }
    }
    public string Product_Name
    {
        get { return _prodName; }
        set { _prodName = value; }
    }

    public string Product_Image
    {
        get { return _prodImage; }
        set { _prodImage = value; }
    }

    public string Game_Publisher
    {
        get { return _gamePublisher; }
        set { _gamePublisher = value; }
    }

    public int CallOfDutyInsert()
    {
        int result = 0;
        string queryStrThriller = "INSERT INTO GS_CallOfDuty(GS_ID, GS_Image, GS_Title, GS_Publisher)" + "values (@Product_ID, @Product_Name, @Product_Image, @Game_Publisher)";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStrThriller, conn);
        cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);		
        cmd.Parameters.AddWithValue("@Product_Image", this.Product_Image);
        cmd.Parameters.AddWithValue("@Product_Name", this.Product_Name);
        cmd.Parameters.AddWithValue("@Game_Publisher", this.Game_Publisher);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }//end Insert
}

public class Action
{
    //System.Configuration.ConnectionStringSettings _connStr;
    string _connStr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
    private string _prodID = null;
    private string _prodName = string.Empty;
    private string _prodImage = "";
    private string _gamePublisher;


    // Default constructor
    public Action()
    {
    }

    // PRODUCTS
    public Action(string prodID, string prodName, string prodImage, string gamePublisher)
    {
        _prodID = prodID;
        _prodName = prodName;
        _prodImage = prodImage;
        _gamePublisher = gamePublisher;
    }

    // Constructor that take in all except product ID
    public Action(string prodName, string prodImage, string gamePublisher)
        : this(null, prodName, prodImage, gamePublisher)
    {
    }

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
    public Action(string prodID)
        : this(prodID, "", "", "")
    {
    }

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public string Product_ID
    {
        get { return _prodID; }
        set { _prodID = value; }
    }
    public string Product_Name
    {
        get { return _prodName; }
        set { _prodName = value; }
    }

    public string Product_Image
    {
        get { return _prodImage; }
        set { _prodImage = value; }
    }

    public string Game_Publisher
    {
        get { return _gamePublisher; }
        set { _gamePublisher = value; }
    }

    public int ActionInsert()
    {
        int result = 0;
        string queryStrThriller = "INSERT INTO GS_Action(GS_ID, GS_Image, GS_Title, GS_Publisher)" + "values (@Product_ID, @Product_Name, @Product_Image, @Game_Publisher)";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStrThriller, conn);
        cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
        cmd.Parameters.AddWithValue("@Product_Image", this.Product_Image);
        cmd.Parameters.AddWithValue("@Product_Name", this.Product_Name);
        cmd.Parameters.AddWithValue("@Game_Publisher", this.Game_Publisher);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }//end Insert
}

public class CoOp
{
    //System.Configuration.ConnectionStringSettings _connStr;
    string _connStr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
    private string _prodID = null;
    private string _prodName = string.Empty;
    private string _prodImage = "";
    private string _gamePublisher;


    // Default constructor
    public CoOp()
    {
    }

    // PRODUCTS
    public CoOp(string prodID, string prodName, string prodImage, string gamePublisher)
    {
        _prodID = prodID;
        _prodName = prodName;
        _prodImage = prodImage;
        _gamePublisher = gamePublisher;
    }

    // Constructor that take in all except product ID
    public CoOp(string prodName, string prodImage, string gamePublisher)
        : this(null, prodName, prodImage, gamePublisher)
    {
    }

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
    public CoOp(string prodID)
        : this(prodID, "", "", "")
    {
    }

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public string Product_ID
    {
        get { return _prodID; }
        set { _prodID = value; }
    }
    public string Product_Name
    {
        get { return _prodName; }
        set { _prodName = value; }
    }

    public string Product_Image
    {
        get { return _prodImage; }
        set { _prodImage = value; }
    }

    public string Game_Publisher
    {
        get { return _gamePublisher; }
        set { _gamePublisher = value; }
    }

    public int CoOpInsert()
    {
        int result = 0;
        string queryStrThriller = "INSERT INTO GS_CoOp(GS_ID, GS_Image, GS_Title, GS_Publisher)" + "values (@Product_ID, @Product_Name, @Product_Image, @Game_Publisher)";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStrThriller, conn);
        cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
        cmd.Parameters.AddWithValue("@Product_Image", this.Product_Image);
        cmd.Parameters.AddWithValue("@Product_Name", this.Product_Name);
        cmd.Parameters.AddWithValue("@Game_Publisher", this.Game_Publisher);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }//end Insert
}

public class Indie
{
    //System.Configuration.ConnectionStringSettings _connStr;
    string _connStr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
    private string _prodID = null;
    private string _prodName = string.Empty;
    private string _prodImage = "";
    private string _gamePublisher;


    // Default constructor
    public Indie()
    {
    }

    // PRODUCTS
    public Indie(string prodID, string prodName, string prodImage, string gamePublisher)
    {
        _prodID = prodID;
        _prodName = prodName;
        _prodImage = prodImage;
        _gamePublisher = gamePublisher;
    }

    // Constructor that take in all except product ID
    public Indie(string prodName, string prodImage, string gamePublisher)
        : this(null, prodName, prodImage, gamePublisher)
    {
    }

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
    public Indie(string prodID)
        : this(prodID, "", "", "")
    {
    }

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public string Product_ID
    {
        get { return _prodID; }
        set { _prodID = value; }
    }
    public string Product_Name
    {
        get { return _prodName; }
        set { _prodName = value; }
    }

    public string Product_Image
    {
        get { return _prodImage; }
        set { _prodImage = value; }
    }

    public string Game_Publisher
    {
        get { return _gamePublisher; }
        set { _gamePublisher = value; }
    }

    public int IndieInsert()
    {
        int result = 0;
        string queryStrThriller = "INSERT INTO GS_Indie(GS_ID, GS_Image, GS_Title, GS_Publisher)" + "values (@Product_ID, @Product_Name, @Product_Image, @Game_Publisher)";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStrThriller, conn);
        cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
        cmd.Parameters.AddWithValue("@Product_Image", this.Product_Image);
        cmd.Parameters.AddWithValue("@Product_Name", this.Product_Name);
        cmd.Parameters.AddWithValue("@Game_Publisher", this.Game_Publisher);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }//end Insert
}

public class OpenWorld
{
    //System.Configuration.ConnectionStringSettings _connStr;
    string _connStr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
    private string _prodID = null;
    private string _prodName = string.Empty;
    private string _prodImage = "";
    private string _gamePublisher;


    // Default constructor
    public OpenWorld()
    {
    }

    // PRODUCTS
    public OpenWorld(string prodID, string prodName, string prodImage, string gamePublisher)
    {
        _prodID = prodID;
        _prodName = prodName;
        _prodImage = prodImage;
        _gamePublisher = gamePublisher;
    }

    // Constructor that take in all except product ID
    public OpenWorld(string prodName, string prodImage, string gamePublisher)
        : this(null, prodName, prodImage, gamePublisher)
    {
    }

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
    public OpenWorld(string prodID)
        : this(prodID, "", "", "")
    {
    }

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public string Product_ID
    {
        get { return _prodID; }
        set { _prodID = value; }
    }
    public string Product_Name
    {
        get { return _prodName; }
        set { _prodName = value; }
    }

    public string Product_Image
    {
        get { return _prodImage; }
        set { _prodImage = value; }
    }

    public string Game_Publisher
    {
        get { return _gamePublisher; }
        set { _gamePublisher = value; }
    }

    public int OpenWorldInsert()
    {
        int result = 0;
        string queryStrThriller = "INSERT INTO GS_OpenWorld(GS_ID, GS_Image, GS_Title, GS_Publisher)" + "values (@Product_ID, @Product_Name, @Product_Image, @Game_Publisher)";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStrThriller, conn);
        cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
        cmd.Parameters.AddWithValue("@Product_Image", this.Product_Image);
        cmd.Parameters.AddWithValue("@Product_Name", this.Product_Name);
        cmd.Parameters.AddWithValue("@Game_Publisher", this.Game_Publisher);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }//end Insert
}
