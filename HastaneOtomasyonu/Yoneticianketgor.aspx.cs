using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yoneticianketgor : System.Web.UI.Page
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
       

        string sqlQuery = @"SELECT R.Randevutarih, D.Doktor, Ha.Hasta, M.M_Anket , M.M_anketID, D.Doktor
                        FROM MemnuniyetAnket AS M
                        INNER JOIN Randevu AS R ON M.RandevuID = R.RandevuID
                        INNER JOIN Doktor AS D ON M.DoktorTC = D.DoktorTC
                        INNER JOIN Hasta AS Ha ON M.HastaTC = Ha.HastaTC";

        SqlCommand command = new SqlCommand(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        SqlDataReader reader = command.ExecuteReader();


        if (reader.HasRows)
        {
            Gwanket2.DataSource = reader;
            Gwanket2.DataBind();
        }
        else
        {
            DataTable dtbl = new DataTable();
            dtbl.Rows.Add(dtbl.NewRow());
            Gwanket2.DataSource = dtbl;
            Gwanket2.DataBind();
            Gwanket2.Rows[0].Cells.Clear();
            Gwanket2.Rows[0].Cells.Add(new TableCell());
            Gwanket2.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            Gwanket2.Rows[0].Cells[0].Text = "Veri bulunamadı";
            Gwanket2.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

    }
}