using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class M_anketgor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack) {
            Datareader();
        }
    }

    public void Datareader()
    {
        string doktortc = Session["Tcno2"].ToString();

        string sqlQuery = @"SELECT R.Randevutarih, D.Doktor, Ha.Hasta, M.M_Anket , M.M_anketID
                        FROM MemnuniyetAnket AS M
                        INNER JOIN Randevu AS R ON M.RandevuID = R.RandevuID
                        INNER JOIN Doktor AS D ON M.DoktorTC = D.DoktorTC
                        INNER JOIN Hasta AS Ha ON M.HastaTC = Ha.HastaTC
                        WHERE M.DoktorTC = @doktortc";

        SqlCommand command = new SqlCommand(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        command.Parameters.AddWithValue("@doktortc", doktortc);
        
        

        SqlDataReader reader = command.ExecuteReader();


        if (reader.HasRows)
        {
            Gwanket1.DataSource = reader;
            Gwanket1.DataBind();
        }
        else
        {
            DataTable dtbl = new DataTable();
            dtbl.Rows.Add(dtbl.NewRow());
            Gwanket1.DataSource = dtbl;
            Gwanket1.DataBind();
            Gwanket1.Rows[0].Cells.Clear();
            Gwanket1.Rows[0].Cells.Add(new TableCell());
            Gwanket1.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            Gwanket1.Rows[0].Cells[0].Text = "Veri bulunamadı";
            Gwanket1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

    }

}