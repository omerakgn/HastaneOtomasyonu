using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sorunbildir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if(Tekniksoruntxt.Text != "")
        {
            string DoktorTC = Session["Tcno2"].ToString();

            string teknikSorun = Tekniksoruntxt.Text;

            string sqlquery = "INSERT INTO Teknik_Sorun (DoktorTC, Tekniksorun) VALUES(@DoktorTC , @Tekniksorun)";

            SqlCommand command = new SqlCommand(sqlquery, SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();
            command.Parameters.AddWithValue("@DoktorTC", DoktorTC);
            command.Parameters.AddWithValue("@Tekniksorun", teknikSorun);
            command.ExecuteNonQuery();
            Tekniksoruntxt.Text = "";
            Response.Write("<script>alert('" + "Teknik sorun ilgili kişilere gönderilmiştir. " + "')</script>");
        }
        else
        {
            Response.Write("<script>alert('" + "Lütfen teknik sorun kısmını boş bırakmayınız ! " + "')</script>");
        }
    }
}