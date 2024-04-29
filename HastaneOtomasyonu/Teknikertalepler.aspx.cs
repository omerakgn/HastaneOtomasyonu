using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teknikertalepler : System.Web.UI.Page
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
        string sqlQuery = @"SELECT D.Doktor, P.Polisim, T.Tekniksorun, T.TeknikSorunID
                        FROM Teknik_Sorun AS T
                        INNER JOIN Doktor AS D ON T.DoktorTC = D.DoktorTC
                        INNER JOIN Poliklinik AS P ON D.PolID = P.PolID";
                        
                       

        SqlDataAdapter command = new SqlDataAdapter(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        
        DataTable dtbl = new DataTable();
        int i = 0;
      
         command.Fill(dtbl);

        if(dtbl.Rows.Count > 0)
        {
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan= dtbl.Columns.Count;
            GridView1.Rows[0].Cells[0].Text = "Veri bulunamadı";
            GridView1.Rows[0].Cells[0].HorizontalAlign= HorizontalAlign.Center;
        }

    }


    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }
}
public class Talepler
    {
        public string Doktor { get; set; }
        public string Polisim { get; set; }
        public string Tekniksorun { get; set; }
        
    }


  