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

        int i = 0;

       

        if (reader.HasRows)
        {
            GwDoktor.DataSource = reader;
            GwDoktor.DataBind();
        }
        else
        {
            DataTable dtbl = new DataTable();
            dtbl.Rows.Add(dtbl.NewRow());
            GwDoktor.DataSource = dtbl;
            GwDoktor.DataBind();
            GwDoktor.Rows[0].Cells.Clear();
            GwDoktor.Rows[0].Cells.Add(new TableCell());
            GwDoktor.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            GwDoktor.Rows[0].Cells[0].Text = "Veri bulunamadı";
            GwDoktor.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

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
}