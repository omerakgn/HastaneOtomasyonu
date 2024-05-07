using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Memnuniyetanketi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void GetDoktorData(string randevuno)
    {
   
        SqlCommand command = new SqlCommand("SELECT DoktorTC FROM Randevu WHERE RandevuID = @RandevuID", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        command.Parameters.AddWithValue("@RandevuID", randevuno);

        
        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            string doktortc = reader["DoktorTC"].ToString();

            Session["DoktorTC"] = doktortc;
            

        }
       

       
    }
    public void gethastatcdata(string randevuıd)
    {
        string hastatc = Session["Tcno"].ToString();

        SqlCommand command = new SqlCommand("SELECT HastaTC FROM Randevu WHERE RandevuID = @randevuıd", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        command.Parameters.AddWithValue("@randevuıd", randevuıd);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            string hastaTC = reader["HastaTC"].ToString();

            Session["HastaTC"] = hastaTC;
            

        }
    }
    public void getTarihdata(string randevuno)
    {
        SqlCommand command = new SqlCommand("SELECT Randevutarih FROM Randevu WHERE RandevuID = @RandevuID", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        command.Parameters.AddWithValue("@RandevuID", randevuno);


        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            string randevutarih = reader["Randevutarih"].ToString();

            Session["randevutarih"] = randevutarih;


        }

    }

    public void Datainsert()
    {
        string insertQuery = "INSERT INTO MemnuniyetAnket (M_Anket, HastaTC,DoktorTC,RandevuID) VALUES (@Value1, @Value2, @Value3,@Value4)";
        SqlCommand command = new SqlCommand(insertQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        string hastatc = Session["HastaTC"].ToString();
        string doktortc = Session["DoktorTC"].ToString();
        string randevuıd = txtRandevuNo.Text;
        string randevutarih = TxtRandevutarih.Text;
        string metin = txtMetin.Text;
        


        command.Parameters.AddWithValue("@Value1", metin);
        command.Parameters.AddWithValue("@Value2", hastatc);
        command.Parameters.AddWithValue("@Value3", doktortc);
        command.Parameters.AddWithValue("@Value4", randevuıd);
       

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            Response.Write("<script>alert('" + "Başarıyla kaydedildi." + "')</script>");
            txtRandevuNo.Text = "";
            TxtRandevutarih.Text = "";
            txtMetin.Text = "";
            
        }
        else
        {
            Response.Write("<script>alert('" + "Bir sıkıntı oluştu lütfen tekrar deneyiniz." + "')</script>");
        }
    }

    protected void btngonder_Click(object sender, EventArgs e)
    {
       
        string randevuıd = txtRandevuNo.Text;
        string randevutarih = TxtRandevutarih.Text;
        string metin = txtMetin.Text;
        

        string query = "SELECT COUNT(*) FROM Randevu WHERE RandevuID = @ID ";
        SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        command.Parameters.AddWithValue("@ID", randevuıd);
        

        int count = (int)command.ExecuteScalar();

        if (randevuıd ==""|| randevutarih==""|| metin=="")
        {
            Response.Write("<script>alert('" + "Lütfen istenilen bilgileri doldurunuz." + "')</script>");
        }
        else if(count> 0) 
        {
            GetDoktorData(randevuıd);
            gethastatcdata(randevuıd);
            getTarihdata(randevuıd);

            string Tarih1 = Session["randevutarih"].ToString();
            DateTime tarih = DateTime.Parse(randevutarih);
            string RandevuTarih = tarih.ToString("dd/mm/yyyy");
            DateTime tarihsession = DateTime.Parse(Tarih1);
            string Tarihsesson = tarihsession.ToString("dd/mm/yyyy");
            

            if (Session["HastaTC"].ToString() == Session["Tcno"].ToString() && RandevuTarih == Tarihsesson)
            {
                Datainsert();
            }
            else
            {
                Response.Write("<script>alert('" + "Kendi randevunuz dışındaki randevular için memnuniyet anketini dolduramazsınız." + "')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('" + "Lütfen geçerli bir Randevu numarası giriniz." + "')</script>");
        }

    }
}