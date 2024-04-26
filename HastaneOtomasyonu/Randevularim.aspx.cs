using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Randevularim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            Datareader();

        }
       
    }

    public void Datareader()
    {

        string sqlQuery = @"SELECT R.Randevutarih, H.Hastaneisim, P.Polisim, D.Doktor, Ha.HastaTC
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

        string hastaTC = Session["Tcno"].ToString();
        bool hasRecord = false;

        int rowCount = 0;

        while (dr.Read())
        {
            string HastaTC = dr["HastaTC"]?.ToString();
            rowCount++;

            if (hastaTC == HastaTC && HastaTC != null)
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

                Button deleteButton = new Button();
                deleteButton.ID = "btnDelete_" + rowCount; // Butonun kimliğini belirtin
                deleteButton.Text = "Sil"; // Buton metnini belirtin
                deleteButton.Click += new EventHandler(DeleteButton_Click); // Butona tıklanınca çağrılacak işlevi belirtin

                TableRow row = new TableRow();

                TableCell buttonCell = new TableCell();
                buttonCell.Controls.Add(deleteButton);
                
                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + randevu.Randevutarih + "</td>");
                htmlTable.Append("<td>" + randevu.Hastaneisim + "</td>");
                htmlTable.Append("<td>" + randevu.Polisim + "</td>");
                htmlTable.Append("<td>" + randevu.Doktor + "</td>");
                htmlTable.Append("<td><input type='button' ID='button' value='İptal Et' onclick='DeleteButton_Click ' style='width:60px;' /></td>");
                htmlTable.Append("</tr>");
               
                
            }
        }

        if (hasRecord)
        {
            htmlTable.Insert(0, "<table border='1'><tr><th>Randevu Tarih</th><th>Hastane İsim</th><th>Poliklinik İsim</th><th>Doktor İsim</th><th> </th></tr>");
            htmlTable.Append("</table>");
            litHtmlTable.Text = htmlTable.ToString();
        }
        else
        {
            Literal1.Text = "<b>RANDEVUNUZ BULUNMAMAKTADIR.RANDEVU ALMAK İÇİN ÜSTTE BULUNAN <u>RANDEVU AL</u> BUTONUNA TIKLAYINIZ. </b>";
        }


    }
    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        

      

        // Satırı silmek için gerekli işlemleri gerçekleştirin
        // Örneğin, listeden ilgili satırı kaldırabilir ve yeniden render edebilirsiniz.
        // Veya bir veritabanı işlemi yapabilirsiniz.
    }



    public class Randevular
    {
        public string Randevutarih { get; set; }
        public string Hastaneisim { get; set; }
        public string Polisim { get; set; }
        public string Doktor { get; set; }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string hastaTC = Session["Tcno"].ToString();

        Response.Redirect("Randevual.aspx");
    }
}
