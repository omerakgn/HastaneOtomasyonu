using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        string hastatc = Session["Tcno"].ToString();

        string sqlQuery = @"SELECT R.Randevutarih, H.Hastaneisim, P.Polisim, D.Doktor, Ha.HastaTC, R.RandevuID
                        FROM Randevu AS R
                        INNER JOIN Hastane AS H ON R.HastaneID = H.HastaneID
                        INNER JOIN Poliklinik AS P ON R.PolID = P.PolID
                        INNER JOIN Doktor AS D ON R.DoktorTC = D.DoktorTC
                        INNER JOIN Hasta AS Ha ON R.HastaTC = Ha.HastaTC
                        WHERE R.HastaTC = @hastatc ";


        SqlCommand command = new SqlCommand(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        command.Parameters.AddWithValue("@hastatc", hastatc);

        
        int i = 0;
        SqlDataReader reader = command.ExecuteReader();
        

        if (reader.HasRows)
        {
            GwRandevu.DataSource = reader;
            GwRandevu.DataBind();
        }
        else
        {
            DataTable dtbl = new DataTable();
            dtbl.Rows.Add(dtbl.NewRow());
            GwRandevu.DataSource = dtbl;
            GwRandevu.DataBind();
            GwRandevu.Rows[0].Cells.Clear();
            GwRandevu.Rows[0].Cells.Add(new TableCell());
            GwRandevu.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            GwRandevu.Rows[0].Cells[0].Text = "Veri bulunamadı";
            GwRandevu.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
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
        string hastaTC = Session["Tcno"].ToString();

        Response.Redirect("Randevual.aspx");
    }

    protected void GwRandevu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string queryupdate = "UPDATE Randevu" +
            " SET Randevutarih = NULL ," +
            " HastaTC = NULL ," +
            " DoktorTC = NULL ,"+
            " PolID = NULL ,"+
            " HastaneID = NULL "+
            " WHERE RandevuID = @ID;";
        
        SqlCommand command = new SqlCommand(queryupdate, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        command.Parameters.AddWithValue("@ID", Convert.ToInt32(GwRandevu.DataKeys[e.RowIndex].Value.ToString()));
        command.ExecuteNonQuery();

        Datareader();
    }
}
