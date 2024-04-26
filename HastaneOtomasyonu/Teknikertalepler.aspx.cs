using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teknikertalepler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack) {
            Datareader();
            
        }
       
    }

    public void Datareader()
    {
        string sqlQuery = @"SELECT D.Doktor, P.Polisim, T.Tekniksorun
                        FROM Teknik_Sorun AS T
                        INNER JOIN Doktor AS D ON T.DoktorTC = D.DoktorTC
                        INNER JOIN Poliklinik AS P ON D.PolID = P.PolID";
                        
                       

        SqlCommand commandListIl = new SqlCommand(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        SqlDataReader dr = commandListIl.ExecuteReader();
        List<Talepler> talepler = new List<Talepler>();
        StringBuilder htmlTable = new StringBuilder();
        
        
        while (dr.Read()) {
            Talepler talep = new Talepler();
            talep.Doktor = dr["Doktor"].ToString();
            talep.Polisim = dr["Polisim"].ToString();
            talep.Tekniksorun = dr["Tekniksorun"].ToString();

            string buttonID = "onaybutton_" + Guid.NewGuid().ToString();

            talepler.Add(talep);

            htmlTable.Append("<tr>");
            htmlTable.Append("<td>" +talep.Doktor + "</td>");
            htmlTable.Append("<td>" + talep.Polisim + "</td>");
            htmlTable.Append("<td>" + talep.Tekniksorun + "</td>");
           
            htmlTable.Append("<td><input type='button' ID='"+ buttonID +"' value='İptal Et' runat='server' OnClick='Onaybutton_Click' style='width:60px;' /></td>");
            htmlTable.Append("<td><input type='button' ID='"+ buttonID +"' value='İptal Et' runat='server' OnClick='Redbutton_Click' style='width:60px;' /></td>");
            htmlTable.Append("</tr>");

           
           

        }
        htmlTable.Insert(0, "<table border='1'><tr><th>Doktor </th><th>Poliklinik İsim</th><th>Teknik Sorun</th><th>Onayla</th><th>Reddet</th></tr>");
        htmlTable.Append("</table>");
        litHtmlTable2.Text = htmlTable.ToString();
    }
    protected void Onaybutton_Click(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        string buttonID = clickedButton.ID;

        // Buton ID'sinden hangi satıra tıklandığını alalım
        string rowID = buttonID.Replace("onaybutton_", "");

        // Bu bilgiyi kullanarak işlemlerinizi yapabilirsiniz
        // Örneğin, satırın adını yazdırabilirsiniz
        Response.Write("<script>alert('Satır ID: " + rowID + "');</script>");

    }
    protected void Redbutton_Click(object sender, EventArgs e)
    {

        
    }
    public class Talepler
    {
        public string Doktor { get; set; }
        public string Polisim { get; set; }
        public string Tekniksorun { get; set; }
        
    }

}