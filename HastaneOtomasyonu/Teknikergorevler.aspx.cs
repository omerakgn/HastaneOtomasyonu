using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teknikergorevler : System.Web.UI.Page
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
        string sqlQuery = @"SELECT D.Doktor, P.Polisim, Te.Tekniksorun, T.TeknikergorevID 
                        FROM Teknikergorevler AS T
                        INNER JOIN Teknik_Sorun AS Te ON T.TeknikSorunID = Te.TeknikSorunID 
                        INNER JOIN Doktor AS D ON Te.DoktorTC = D.DoktorTC
                        INNER JOIN Poliklinik AS P ON D.PolID = P.PolID";
                        
        



        SqlDataAdapter command = new SqlDataAdapter(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        DataTable dtbl = new DataTable();
        int i = 0;

        command.Fill(dtbl);

        if (dtbl.Rows.Count > 0)
        {
            GridView2.DataSource = dtbl;
            GridView2.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            GridView2.DataSource = dtbl;
            GridView2.DataBind();
            GridView2.Rows[0].Cells.Clear();
            GridView2.Rows[0].Cells.Add(new TableCell());
            GridView2.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            GridView2.Rows[0].Cells[0].Text = "Veri bulunamadı";
            GridView2.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

    }

}