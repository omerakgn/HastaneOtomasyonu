using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yenisifre : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void sifreguncelleme()
    {
        string tcno = txtTC.Text;
        
        
        
        string queryString = @"
            DECLARE @SessionTC VARCHAR(50) = @TC;
            
            SELECT 'Hasta' AS TableName, HastaTC AS TCValue
            FROM Hasta
            WHERE HastaTC = @SessionTC
            
            UNION ALL
            
            SELECT 'Doktor' AS TableName, DoktorTC AS TCValue
            FROM Doktor
            WHERE DoktorTC = @SessionTC
            
            UNION ALL
            
            SELECT 'Tekniker' AS TableName, TeknikerTC AS TCValue
            FROM Tekniker
            WHERE TeknikerTC = @SessionTC
            
            UNION ALL
            
            SELECT 'Yonetici' AS TableName, YoneticiTC AS TCValue
            FROM Yonetici
            WHERE YoneticiTC = @SessionTC;";
        
                   /*"SELECT HastaTC, 'Hasta' AS TableName FROM Hasta WHERE HastaTC = @TC " +
                     "UNION ALL " +
                     "SELECT DoktorTC, 'Doktor' AS TableName FROM Doktor WHERE DoktorTC = @TC " +
                     "UNION ALL " +
                     "SELECT TeknikerTC, 'Tekniker' AS TableName FROM Tekniker WHERE TeknikerTC = @TC " +
                     "UNION ALL " +
                     "SELECT YoneticiTC, 'Yonetici' AS TableName FROM Yonetici WHERE YoneticiTC = @TC ";*/

        SqlCommand command = new SqlCommand(queryString, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        command.Parameters.AddWithValue("@TC", tcno);

        try
        {
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string tcValue = dr.GetString(dr.GetOrdinal("TCValue"));
                    string tableName = dr.GetString(dr.GetOrdinal("TableName"));

                    Console.WriteLine("ID: {0}, Tablo Adı: {1}", tcValue, tableName);


                    Sifreguncelle(tableName, tcValue);
                   
                    
                }
                dr.Close();
            }
            else {
                Response.Write("<script>alert('" + "BİR SIKINTI VAR" + "')</script>");
            }
           
        }
        catch (Exception ex) {
            Response.Write("<script>alert('"  + ex.Message+ "')</script>");
        }
        

   }
    public void Sifreguncelle(string tableName, string tcValue)
    {
        
        string newPassword = txtyenisifre.Text;

       


        string updateQuery = "";

        
        if (tableName=="Hasta")
        {
            updateQuery = "UPDATE Hasta SET Hastasifre = @NewPassword WHERE HastaTC = @tcValue";
        }
        else if (tableName == "Doktor")
        {
            updateQuery = "UPDATE Doktor SET Doktorsifre = @NewPassword WHERE DoktorTC = @tcValue";
        }
        else if (tableName == "Tekniker")
        {
            updateQuery = "UPDATE Tekniker SET Teknikersifre = @NewPassword WHERE TeknikerTC =@tcValue";
        }
        else if (tableName == "Yonetici")
        {
            updateQuery = "UPDATE Yonetici SET Yoneticisifre = @NewPassword WHERE YoneticiTC = @tcValue";
        }

       
        
            SqlCommand updateCommand = new SqlCommand(updateQuery, SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();
            updateCommand.Parameters.AddWithValue("@NewPassword", newPassword);
            updateCommand.Parameters.AddWithValue("@tcValue", tcValue);

            try
            {
               
                int rowsAffected = updateCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    
                    Console.WriteLine("Şifre başarıyla güncellendi.");
                }
                else
                {
                    
                    Console.WriteLine("Şifre güncellenemedi.");
                }
            }
            catch (Exception ex)
            {
            Response.Write("<script>alert('" + ex  + "')</script>");

        }
    }
    

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["Yenisifre"] = txtyenisifre.Text;
        Session["Yenisifretekrar"]= txtsifretekrar.Text;

        string yenisifre =Session["Yenisifre"].ToString();
        string sifretekrar = Session["Yenisifretekrar"].ToString();
        if (yenisifre =="" && sifretekrar == "") {
            Response.Write("<script>alert('" + "Bir şifre belirleyiniz !" + "')</script>");
           
        }
        
        else if (yenisifre == sifretekrar)
        {
            sifreguncelleme();
            txtTC.Text = "";
            txtyenisifre.Text = "";
            txtsifretekrar.Text = "";

            Session["sifredegisikligi"] = "sifredegisikligi";
           

        }
        else {
            Response.Write("<script>alert('" + "Şifreler birbirlerine eşit olmalı !" + "')</script>");

        }


    }
}