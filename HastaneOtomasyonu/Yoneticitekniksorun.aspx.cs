using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yoneticitekniksorun : System.Web.UI.Page
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
        string sqlQuery = @"SELECT D.Doktor, P.Polisim, T.Tekniksorun, T.TeknikSorunID ,T.TeknikergorevID,T.Teknikdurum
                        FROM Teknikergorevler AS T
                        INNER JOIN Teknik_Sorun TS ON T.TeknikSorunID=TS.TeknikSorunID
                        INNER JOIN Doktor AS D ON T.DoktorTC = D.DoktorTC
                        INNER JOIN Poliklinik AS P ON D.PolID = P.PolID";


        SqlDataAdapter command = new SqlDataAdapter(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        DataTable dtbl1 = new DataTable();


        command.Fill(dtbl1);

        if (dtbl1.Rows.Count > 0)
        {
            GridView3.DataSource = dtbl1;
            GridView3.DataBind();


        }
        else
        {
            dtbl1.Rows.Add(dtbl1.NewRow());
            GridView3.DataSource = dtbl1;
            GridView3.DataBind();
            GridView3.Rows[0].Cells.Clear();
            GridView3.Rows[0].Cells.Add(new TableCell());
            GridView3.Rows[0].Cells[0].ColumnSpan = dtbl1.Columns.Count;
            GridView3.Rows[0].Cells[0].Text = "Veri bulunamadı";
            GridView3.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }
    }
}