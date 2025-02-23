﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ameliyatkayit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Datareader();
        }

    }
    public void Datareader()
    {
        string doktortc = Session["Tcno2"].ToString();

        string sqlQuery = @"SELECT A.AmeliyatTarih, Ha.HastaTC, Ha.Hasta,A.AmeliyatID , A.Ameliyathaneno, A.Ameliyataciklama
                        FROM Ameliyat AS A
                        INNER JOIN Doktor AS D ON A.DoktorTC = D.DoktorTC
                        INNER JOIN Hasta AS Ha ON A.HastaTC = Ha.HastaTC
                        WHERE A.DoktorTC = @doktortc";

        SqlCommand command = new SqlCommand(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        command.Parameters.AddWithValue("@doktortc", doktortc);

        SqlDataReader reader = command.ExecuteReader();

       

        


        if (reader.HasRows)
        {
            kayitbtn.Visible = false;
            GwAmeliyat.DataSource = reader;
            GwAmeliyat.DataBind();
        }
        else
        {
            kayitbtn.Visible = true;
        }

    }


    protected void GwAmeliyat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string doktortc = Session["Tcno2"].ToString();
        if (e.CommandName.Equals("AddNew"))
        {

            string sqlquery = "INSERT INTO Ameliyat (AmeliyatTarih, Ameliyathaneno,Ameliyataciklama,DoktorTC,HastaTC) VALUES(@AmeliyatTarih, @Ameliyathaneno , @Ameliyataciklama, @DoktorTC,@HastaTC)";
            SqlCommand command = new SqlCommand(sqlquery, SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();

           
            

            command.Parameters.AddWithValue("@AmeliyatTarih", (GwAmeliyat.FooterRow.FindControl("AmeliyatTarihtxt") as TextBox).Text.Trim());
            command.Parameters.AddWithValue("@Ameliyathaneno", (GwAmeliyat.FooterRow.FindControl("Ameliyathaneno") as TextBox).Text.Trim());
            command.Parameters.AddWithValue("@Ameliyataciklama", (GwAmeliyat.FooterRow.FindControl("Ameliyataciklamatxt") as TextBox).Text.Trim());
            command.Parameters.AddWithValue("@DoktorTC",doktortc );
            command.Parameters.AddWithValue("@HastaTC", (GwAmeliyat.FooterRow.FindControl("HastaTCtxt") as TextBox).Text.Trim());
            command.ExecuteNonQuery();
           

            Datareader();
        }
    }

    protected void kayitbtn_Click(object sender, EventArgs e)
    {

        Response.Redirect("Ameliyatkayitolustur.aspx");
    }
}