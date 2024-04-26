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

public partial class Doktorsecim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Datareader();
    }
    public void Datareader()
    {
       
        string sqlQuery = @"SELECT R.Randevutarih, H.Hastaneisim, P.Polisim, D.Doktor, Ha.HastaTC,D.DoktorTC
                        FROM Randevu AS R
                        INNER JOIN Hastane AS H ON R.HastaneID = H.HastaneID
                        INNER JOIN Poliklinik AS P ON R.PolID = P.PolID
                        INNER JOIN Doktor AS D ON R.DoktorTC = D.DoktorTC
                        INNER JOIN Hasta AS Ha ON R.HastaTC = Ha.HastaTC";

        SqlCommand commandListIl = new SqlCommand(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        SqlDataReader dr = commandListIl.ExecuteReader();
       
       
        List<Randevular> randevularim = new List<Randevular>();
        StringBuilder htmlTable = new StringBuilder();
       
       
        string doktortc = Session["Tcno2"].ToString();
      
        
        bool hasRecord = false;

       
        while (dr.Read())
        {
           
            string DoktorTC = dr["DoktorTC"]?.ToString();

           
            if (doktortc == DoktorTC && DoktorTC != null)
            {
                hasRecord = true; 

               
                DateTime tarih = Convert.ToDateTime(dr["Randevutarih"]);
                string date = tarih.Date.ToString("dd-MM-yyyy"); 

               
                Randevular randevu = new Randevular();
                randevu.Randevutarih = date;
                randevu.Hastaneisim = dr["Hastaneisim"].ToString();
                randevu.Polisim = dr["Polisim"].ToString();
                randevu.Doktor = dr["Doktor"].ToString();

                randevularim.Add(randevu); 

              
                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + randevu.Randevutarih + "</td>");
                htmlTable.Append("<td>" + randevu.Hastaneisim + "</td>");
                htmlTable.Append("<td>" + randevu.Polisim + "</td>");
                htmlTable.Append("<td>" + randevu.Doktor + "</td>");
                htmlTable.Append("</tr>");
            }
        }

        if (hasRecord) 
        {
            
            htmlTable.Insert(0, "<table border='1'><tr><th>Randevu Tarih</th><th>Hastane İsim</th><th>Poliklinik İsim</th><th>Doktor İsim</th></tr>");
            htmlTable.Append("</table>");
            litHtmlTable2.Text = htmlTable.ToString();
        }
        else 
        {
            Literal2.Text = "<b> HERHANGİ BİR RANDEVUNUZ BULUNMAMAKTADIR. </b>";
        }


    }


    public class Randevular
    {
        public string Randevutarih { get; set; }
        public string Hastaneisim { get; set; }
        public string Polisim { get; set; }
        public string Doktor { get; set; }
    }
}