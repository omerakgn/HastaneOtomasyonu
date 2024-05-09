using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class Doktorsecim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack) 
        {
            Datareader();
        }
        
    }
    public void Datareader()
    {
        string doktortc = Session["Tcno2"].ToString();

        string sqlQuery = @"SELECT R.Randevutarih, D.Doktor, Ha.HastaTC,D.DoktorTC, Ha.Hasta,R.RandevuID
                        FROM Randevu AS R
                        INNER JOIN Doktor AS D ON R.DoktorTC = D.DoktorTC
                        INNER JOIN Hasta AS Ha ON R.HastaTC = Ha.HastaTC
                        WHERE R.DoktorTC = @doktortc";

        SqlCommand command = new SqlCommand(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        command.Parameters.AddWithValue("@doktortc", doktortc);

        SqlDataReader reader = command.ExecuteReader();

        

       

        if (reader.HasRows)
        {
            
            GwDoktor.DataSource = reader;
            GwDoktor.DataBind();

        }
        else
        {
            lblMessage.Text = " <b>HERHANGİ BİR RANDEVUNUZ BULUNMAMAKTADIR. </b>";
        }

    }
    
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        string doktorTC = Session["Tcno2"].ToString();
        Response.Redirect("Receteolustur.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string doktorTC = Session["Tcno2"].ToString();
        Response.Redirect("Ameliyatkayit.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string doktorTC = Session["Tcno2"].ToString();
        Response.Redirect("M_anketgor.aspx");
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        string doktorTC = Session["Tcno2"].ToString();

        Response.Redirect("Sorunbildir.aspx");
    }

    protected void GwDoktor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GwDoktor.EditIndex = e.NewEditIndex;
        Datareader();
    }

    protected void GwDoktor_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string doktortc = Session["Tcno2"].ToString();

        string queryupdate = "UPDATE Randevu" +
           " SET Randevutarih = @Randevutarih " +
           " WHERE DoktorTC = @doktortc AND RandevuID = @RandevuID";

        SqlCommand command = new SqlCommand(queryupdate, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        command.Parameters.AddWithValue("@doktortc",doktortc);
        command.Parameters.AddWithValue("@Randevutarih", (GwDoktor.Rows[e.RowIndex].FindControl("txtTarih") as TextBox).Text.Trim());
        command.Parameters.AddWithValue("@RandevuID", GwDoktor.DataKeys[e.RowIndex].Value);
        GwDoktor.EditIndex = -1;
        command.ExecuteNonQuery();

        Datareader();
    }
}