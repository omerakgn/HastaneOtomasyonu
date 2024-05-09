using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ameliyatkayitolustur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void insertdata()
    {

        string doktortc = Session["Tcno2"].ToString();

        string hastatc = txthastaTC.Text;
        string hasta = txtHastaisim.Text;
        string A_haneno = txtAhaneno.Text;
        string aciklama = txtAciklama.Text;
        string tarih = txtAmeliyatTarih.Text;

       
        if (hastatc == "" || hasta == "" || A_haneno == "" || aciklama == "" || tarih == "")
        {

            Response.Write("<script>alert('" + "Lütfen tüm bilgileri giriniz." + "')</script>");

        }
        else
        {
            
            string sqlquery = "INSERT INTO Ameliyat (AmeliyatTarih, Ameliyathaneno,Ameliyataciklama,DoktorTC,HastaTC) VALUES(@AmeliyatTarih, @Ameliyathaneno , @Ameliyataciklama, @DoktorTC,@HastaTC)";
            SqlCommand command = new SqlCommand(sqlquery, SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();


            

            

            if(Datacontrol(hastatc))
            {
                Response.Write("<script>alert('" + "Hasta TC kimlik bilgisini kontrol ediniz." + "')</script>");

            }
            else
            {
                command.Parameters.AddWithValue("@AmeliyatTarih", tarih);
                command.Parameters.AddWithValue("@Ameliyathaneno", A_haneno);
                command.Parameters.AddWithValue("@Ameliyataciklama", aciklama);
                command.Parameters.AddWithValue("@DoktorTC", doktortc);
                command.Parameters.AddWithValue("@HastaTC", hastatc);
                command.ExecuteNonQuery();

                txthastaTC.Text = "";
                txtHastaisim.Text = "";
                txtAhaneno.Text = "";
                txtAciklama.Text = "";
                txtAmeliyatTarih.Text = "";

                Response.Redirect("Ameliyatkayit.aspx");

            }
            

        }
        
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        insertdata();
    }


    public bool Datacontrol(string tcno)
    {
        bool control = false;
        SqlCommand commandListIl = new SqlCommand("Select * from Hasta", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        SqlDataReader dr = commandListIl.ExecuteReader();
        List<Hasta> hastaListesi = new List<Hasta>();
        while (dr.Read())
        {

            Hasta hasta = new Hasta();
           
            hasta.HastaTC = dr["HastaTC"].ToString();
           

            hastaListesi.Add(hasta);
        }

        for (int i = 0; i < hastaListesi.Count; i++)
        {
            Hasta hasta = hastaListesi[i];         
            
            if (tcno != hasta.HastaTC )
            {
                control = true;
            }
            else
            {
                control = false;
                return control;
            }
           
        }
        return control;
    }
    public class Hasta
    {
        public string HastaID { get; set; }
        public string HastaTC { get; set; }
        public string Hastasifre { get; set; }
    }
}