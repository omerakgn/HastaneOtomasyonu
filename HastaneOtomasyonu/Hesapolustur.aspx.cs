using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hesapolustur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void button_click()
    {
        string insertQuery = "INSERT INTO Hasta (HastaTC, Hasta,Hastaadres,Hastasifre,Hastatelefon,Hastamail) VALUES (@Value1, @Value2, @Value3,@Value4,@Value5,@Value6)";
        SqlCommand command = new SqlCommand(insertQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        Session["isim"] = isimtxt.Text;
        Session["adres"] = adrestxt.Text;
        Session["tcno"] = tcnotxt.Text;
        Session["mail"] = mailtxt.Text;
        Session["sifre"] = sifretxt.Text;
        Session["telno"] = telnotxt.Text;
       
        String isim = Session["isim"].ToString();
        String adres = Session["adres"].ToString();
        String Tcno = Session["tcno"].ToString();
        String mail = Session["mail"].ToString();
        String sifre = Session["sifre"].ToString();
        String telno = Session["telno"].ToString();
        if(isim =="" || adres =="" || Tcno == "" || mail=="" ||sifre=="" || telno == "")
        {
            alert("Lütfen bütün alanları doldurunuz !");
        }
        else
        {
            command.Parameters.AddWithValue("@Value1", Tcno);
            command.Parameters.AddWithValue("@Value2", isim);
            command.Parameters.AddWithValue("@Value3", adres);
            command.Parameters.AddWithValue("@Value4", sifre);
            command.Parameters.AddWithValue("@Value5", telno);
            command.Parameters.AddWithValue("@Value6", mail);

            int rowsAffected = command.ExecuteNonQuery();
            if(rowsAffected > 0) {
                alert("Hesabınız başarıyla oluşturulmuştur. Bilgilerinizi kullanarak giriş yapabilirsiniz");
            }
            
        }
    }
    private void alert(string message) 
    {
        Response.Write("<script>alert('" + message + "')</script>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        button_click();
       
        

    }
}