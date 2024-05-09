using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Receteolustur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Datareader();
        }

    }

    public void Datainsert()
    {
        string insertQuery = "INSERT INTO Recete (Ilac, HastaTC,Ilacadet,Kullanimtalimat,DoktorTC) VALUES (@Value1, @Value2, @Value3,@Value4,@Value5)";
        SqlCommand command = new SqlCommand(insertQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        string doktortc =  Session["Tcno2"].ToString();
        string hastatc = Session["Hastatc"].ToString();
        string ilac = Session["hastailac"].ToString();
        string ilacadet = Session["ilacadet"].ToString();
        string kullanimtalimat = Session["kullanimtalimat"].ToString();


        command.Parameters.AddWithValue("@Value1", ilac);
        command.Parameters.AddWithValue("@Value2", hastatc);
        command.Parameters.AddWithValue("@Value3", ilacadet);
        command.Parameters.AddWithValue("@Value4", kullanimtalimat);
        command.Parameters.AddWithValue("@Value5", doktortc);

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            Response.Write("<script>alert('" + "Başarıyla kaydedildi." + "')</script>");
            TxtHasta.Text = "";
            TxtHastatc.Text = "";
            TxtHastamail.Text = "";
            Txtilac.Text = "";
            Txtadet.Text = "";
            TxtTalimat.Text = "";
            Datareader();
        }
        else
        {
            Response.Write("<script>alert('" + "Bir sıkıntı oluştu lütfen tekrar deneyiniz." + "')</script>");
        }
    }

    
    private void button_click()
    {


        Session["Hasta"] = TxtHasta.Text;
        Session["Hastatc"] = TxtHastatc.Text;
        Session["hastamail"] = TxtHastamail.Text;
        Session["hastailac"] = Txtilac.Text;
        Session["ilacadet"] = Txtadet.Text;
        Session["kullanimtalimat"] = TxtTalimat.Text;
       

        String hasta = Session["Hasta"].ToString();
        String hastatc = Session["Hastatc"].ToString();
        String hastamail = Session["hastamail"].ToString();
        String ilac = Session["hastailac"].ToString();
        String ilacadet = Session["ilacadet"].ToString();
        String kullanimtalimat = Session["kullanimtalimat"].ToString();

        string query = "SELECT COUNT(*) FROM Hasta WHERE HastaTC = @TC AND Hasta = @Ad";
        SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        command.Parameters.AddWithValue("@TC", hastatc);
        command.Parameters.AddWithValue("@Ad", hasta);

        int count = (int)command.ExecuteScalar();


        if (hasta == "" || hastatc == "" || hastamail == "" || ilac == "" || ilacadet == "" || kullanimtalimat == "" )
        {
            Response.Write("<script>alert('" + "Lütfen istenilen bilgileri doldurunuz." + "')</script>");
        }
        else if (count>0)
        {
            Datainsert();
        }
        else
        {

            Response.Write("<script>alert('" + "Lütfen hasta bilgilerini doğru giriniz." + "')</script>");
        }

    }

    protected void Kaydetbtn_Click(object sender, EventArgs e)
    {
        button_click();

    }

    public void Datareader()
    {
        string doktortc =  Session["Tcno2"].ToString();


        string sqlQuery = @"SELECT R.Ilac, R.Ilacadet, Ha.HastaTC, R.Kullanimtalimat ,Ha.Hasta, R.ReceteID
                        FROM Recete AS R
                        INNER JOIN Doktor AS D ON R.DoktorTC = D.DoktorTC
                        INNER JOIN Hasta AS Ha ON R.HastaTC = Ha.HastaTC
                        WHERE R.DoktorTC = @doktortc ";


        SqlCommand command = new SqlCommand(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        command.Parameters.AddWithValue("@doktortc", doktortc);


        
        SqlDataReader reader = command.ExecuteReader();


        if (reader.HasRows)
        {
            GwRecete.DataSource = reader;
            GwRecete.DataBind();
        }
        else
        {
           
        }

    }
}