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
        string sqlQuery = @"SELECT D.Doktor, P.Polisim, T.Tekniksorun, T.TeknikergorevID 
                        FROM Teknikergorevler AS T
                        INNER JOIN Teknik_Sorun AS TS ON T.TeknikSorunID = TS.TeknikSorunID 
                        INNER JOIN Doktor AS D ON T.DoktorTC = D.DoktorTC
                        INNER JOIN Poliklinik AS P ON D.PolID = P.PolID";
                        
        



        SqlDataAdapter command = new SqlDataAdapter(sqlQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        DataTable dtbl1 = new DataTable();
       

        command.Fill(dtbl1);

        if (dtbl1.Rows.Count > 0)
        {
            GridView2.DataSource = dtbl1;
            GridView2.DataBind();

            
        }
        else
        {
            dtbl1.Rows.Add(dtbl1.NewRow());
            GridView2.DataSource = dtbl1;
            GridView2.DataBind();
            GridView2.Rows[0].Cells.Clear();
            GridView2.Rows[0].Cells.Add(new TableCell());
            GridView2.Rows[0].Cells[0].ColumnSpan = dtbl1.Columns.Count;
            GridView2.Rows[0].Cells[0].Text = "Veri bulunamadı";
            GridView2.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }



    }




    public void DDLTeknikdurum_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        string ddlID = ddl.ID;
        string selectedValue = ddl.SelectedValue;

         ViewState["SelectedDropDownID"] = ddlID;
         ViewState["SelectedDropDownValue"] = selectedValue;
    }
   

    

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Buton")) {
            int rowIndex = ((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex;
            Label lblTeknikSorun = GridView2.Rows[rowIndex].FindControl("LabelTeknikSorun") as Label;
            string teknikSorun = lblTeknikSorun.Text;
            int teknikSorunID = GetTeknikSorunIDFromDatabase(teknikSorun);

            Label labeldoktor = GridView2.Rows[rowIndex].FindControl("labeldoktor") as Label;
            string Doktor = labeldoktor.Text;
            string DoktorTC = GetDoktordata(Doktor);

            string selectedDropDownID = (string)ViewState["SelectedDropDownID"];
            string teknikdurum = (string)ViewState["SelectedDropDownValue"];
            int teknikergorevID = GetTeknikergorevIDFromDatabase(teknikSorun);

            if (teknikergorevID != -1)
            {
                string sqlquery = "INSERT INTO Bitengorevler (TeknikergorevID, DoktorTC, Tekniksorun,Teknikdurum) VALUES(@TeknikergorevID, @DoktorTC , @Tekniksorun, @Teknikdurum)";
                SqlCommand command = new SqlCommand(sqlquery, SqlConnectionClass.connection);
                SqlConnectionClass.CheckConnection();
                command.Parameters.AddWithValue("@TeknikergorevID", teknikergorevID);
                command.Parameters.AddWithValue("@DoktorTC", DoktorTC);
                command.Parameters.AddWithValue("@Tekniksorun", teknikSorun);
                command.Parameters.AddWithValue("@Teknikdurum", teknikdurum);
                command.ExecuteNonQuery();
                Deletedatafromtable(teknikergorevID);

                Datareader();
            }
        }
        


    }
    public int GetTeknikSorunIDFromDatabase(string teknikSorun)
    {
        int teknikSorunID = -1;
        string sqlQuery = "SELECT TeknikSorunID FROM Teknikergorevler WHERE Tekniksorun = @Tekniksorun  ";


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

    public int GetTeknikergorevIDFromDatabase(string teknikdurum)
    {
        int teknikergorevID = -1;
        string sqlQuery = "SELECT TeknikergorevID FROM Teknikergorevler WHERE Tekniksorun = @Teknikdurum  ";


        using (SqlCommand command = new SqlCommand(sqlQuery, SqlConnectionClass.connection))
        {
            command.Parameters.AddWithValue("@Teknikdurum", teknikdurum);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    teknikergorevID = reader.GetInt32(0);
                }
            }
        }

        return teknikergorevID;
    }

    public void Deletedatafromtable(int TeknikergorevID)
    {
        string queryupdate = "UPDATE Teknikergorevler" +
             " SET DoktorTC = NULL ," +
             " Tekniksorun = NULL ," +
            
             " TeknikSorunID = NULL "+
             " WHERE TeknikergorevID = @ID;";
        SqlCommand command = new SqlCommand(queryupdate, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        command.Parameters.AddWithValue("@ID", TeknikergorevID);
        command.ExecuteNonQuery();
    }

    protected void button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bitengorevler.aspx");
    }
}