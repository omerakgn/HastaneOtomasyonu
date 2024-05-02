using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bitengorevler : System.Web.UI.Page
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

        string sqlQuery = @"SELECT D.Doktor, P.Polisim, B.Tekniksorun ,B.Teknikdurum,B.BitengorevID
                        FROM Bitengorevler AS B
                        INNER JOIN Doktor AS D ON B.DoktorTC = D.DoktorTC
                        INNER JOIN Poliklinik AS P ON D.PolID = P.PolID";

        SqlDataAdapter command = new SqlDataAdapter(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        DataTable dtbl = new DataTable();
        int i = 0;

        command.Fill(dtbl);

        if (dtbl.Rows.Count > 0)
        {
            Gridview3.DataSource = dtbl;
            Gridview3.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            Gridview3.DataSource = dtbl;
            Gridview3.DataBind();
            Gridview3.Rows[0].Cells.Clear();
            Gridview3.Rows[0].Cells.Add(new TableCell());
            Gridview3.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            Gridview3.Rows[0].Cells[0].Text = "Veri bulunamadı";
            Gridview3.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

    }
}