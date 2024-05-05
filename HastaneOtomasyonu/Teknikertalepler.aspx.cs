using System;
using System.Activities.Statements;
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

        if (!IsPostBack)
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
      

        command.Fill(dtbl);

        if (dtbl.Rows.Count > 0)
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
            GridView1.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            GridView1.Rows[0].Cells[0].Text = "Veri bulunamadı";
            GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

    }





    public class Talepler
    {
        public string Doktor { get; set; }
        public string Polisim { get; set; }
        public string Tekniksorun { get; set; }

    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string queryupdate = "UPDATE Teknik_Sorun" +
            " SET DoktorTC = NULL ," +
            " Tekniksorun = NULL " +
            " WHERE TeknikSorunID = @ID;";
      

        

        SqlCommand command = new SqlCommand(queryupdate , SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        command.Parameters.AddWithValue("@ID", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
        command.ExecuteNonQuery();
       
        Datareader();

        
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if(e.CommandName.Equals("Onaylabuton"))
        {
            int rowIndex = ((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex;
            Label lblTeknikSorun = GridView1.Rows[rowIndex].FindControl("LabelTeknikSorun") as Label;
            string teknikSorun = lblTeknikSorun.Text;
            int teknikSorunID = GetTeknikSorunIDFromDatabase(teknikSorun);

            
            Label labeldoktor = GridView1.Rows[rowIndex].FindControl("labeldoktor") as Label;
            string Doktor = labeldoktor.Text;
            string DoktorTC = GetDoktordata(Doktor);

            
            
           
            
            if (teknikSorunID != -1 )
            {
                string sqlQuery = "INSERT INTO Teknikergorevler (TeknikSorunID, DoktorTC, Tekniksorun) VALUES(@TeknikSorunID, @DoktorTC , @Tekniksorun)";
                SqlCommand command = new SqlCommand(sqlQuery, SqlConnectionClass.connection);
                SqlConnectionClass.CheckConnection();
                command.Parameters.AddWithValue("@TeknikSorunID", teknikSorunID);
                command.Parameters.AddWithValue("@DoktorTC", DoktorTC);
                command.Parameters.AddWithValue("@Tekniksorun", teknikSorun);
                command.ExecuteNonQuery();
               
                Deletedatafromtable(teknikSorunID);
                Datareader();
            }
        }
    }
    public int GetTeknikSorunIDFromDatabase(string teknikSorun)
    {
        int teknikSorunID = -1; 
        string sqlQuery = "SELECT TeknikSorunID FROM Teknik_Sorun WHERE Tekniksorun = @Tekniksorun  ";
           
       
            using (SqlCommand command = new SqlCommand(sqlQuery, SqlConnectionClass.connection))
            {
                command.Parameters.AddWithValue("@Tekniksorun", teknikSorun);
               
            using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        teknikSorunID = reader.GetInt32(0);
                    }
                }
            }
        
        return teknikSorunID;
    }
    public string GetDoktordata(string Doktor)
    {
        string DoktorTC = ""; 
        string sqlQuery = "SELECT DoktorTC FROM Doktor WHERE Doktor = @Doktor  ";


        using (SqlCommand command = new SqlCommand(sqlQuery, SqlConnectionClass.connection))
        {
            command.Parameters.AddWithValue("@Doktor", Doktor);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    DoktorTC = reader.GetString(0);
                }
            }
        }


        return DoktorTC;

    }
    public void Deletedatafromtable(int teknikSorunID)
    {
        string queryupdate = "UPDATE Teknik_Sorun" +
             " SET DoktorTC = NULL ," +
             " Tekniksorun = NULL " +
             " WHERE TeknikSorunID = @ID;";
        SqlCommand command = new SqlCommand(queryupdate, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        command.Parameters.AddWithValue("@ID", teknikSorunID);
        command.ExecuteNonQuery();
    }

}
  