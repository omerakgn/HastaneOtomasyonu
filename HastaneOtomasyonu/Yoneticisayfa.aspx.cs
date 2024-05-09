using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yoneticisayfa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DDLdata();
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Yoneticitekniksorun.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Yoneticianketgor.aspx");
    }

    public void DDLdata()
    {
        SqlCommand command = new SqlCommand("Select * from Hastane", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        SqlDataReader dr = command.ExecuteReader();

        while (dr.Read())
        {
            ListItem item = new ListItem();
            item.Text = dr["Hastaneisim"].ToString();
            item.Value = dr["HastaneID"].ToString();
            DropDownList1.Items.Add(item);
        }


        DropDownList1.DataBind();
        dr.Close();



        DropDownList1.Items.Insert(0, new ListItem(" Hastane Seçiniz", ""));

    }
        
    private void Doktorinsert()
    {
        string insertQuery = "INSERT INTO Doktor (DoktorTC, Doktor,Doktorsifre,Doktormail,Doktorunvan,PolID) VALUES (@Value1, @Value2, @Value3,@Value4,@Value5,@Value6)";
        SqlCommand command = new SqlCommand(insertQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        Session["Isim"] = txtIsim.Text;
        Session["Unvan"] = txtunvan.Text;
        Session["TCNO"] = txtTCNO.Text;
        Session["Dmail"] = txtMAIL.Text;
        Session["DSifre"] = txtboxsifre.Text;
       

        String isim = Session["Isim"].ToString();
        String unvan = Session["Unvan"].ToString();
        String Tcno = Session["TCNO"].ToString();
        String mail = Session["Dmail"].ToString();
        String sifre = Session["DSifre"].ToString();
        String POLID = Session["POLID"].ToString();
        if (isim == "" || unvan == "" || Tcno == "" || mail == "" || sifre == "" )
        {
            alert("Lütfen bütün alanları doldurunuz !");
        }
        else
        {
            command.Parameters.AddWithValue("@Value1", Tcno);
            command.Parameters.AddWithValue("@Value2", isim);
            command.Parameters.AddWithValue("@Value3", sifre);
            command.Parameters.AddWithValue("@Value4", mail);
            command.Parameters.AddWithValue("@Value5", unvan);
            command.Parameters.AddWithValue("@Value6", POLID);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                alert("Bilgiler başarıyla kaydedilmiştir.");
                txtbolum.Text = "";
                txtunvan.Text = "";
                txtIsim.Text = "";
                txtTCNO.Text = "";
                txtMAIL.Text = "";
                txtboxsifre.Text = "";

            }

        }
    }

    public void buttonclick()
    {
        string hastaneid = Session["DDL1data"].ToString();
        string Polisim = txtbolum.Text;
        string insertQuery = "INSERT INTO Poliklinik (Polisim, HastaneID) VALUES (@Value1, @Value2)";
        SqlCommand command = new SqlCommand(insertQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        command.Parameters.AddWithValue("@Value1", Polisim);
        command.Parameters.AddWithValue("@Value2", hastaneid);

        command.ExecuteNonQuery();
        GetPolID(Polisim);
        Doktorinsert();
    }
    public void GetPolID(string Polisim)
    {
        string Hastaneid2 = Session["DDL1data"].ToString();

        string query = "Select PolID from Poliklinik  WHERE Polisim = @Polisim AND HastaneID = @hastaneid" ;
        SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
       

        command.Parameters.AddWithValue("@Polisim", Polisim);
        command.Parameters.AddWithValue("@hastaneid", Hastaneid2);

        SqlDataReader dr = command.ExecuteReader();
       
        while(dr.Read())
        {
            string polid = dr["PolID"].ToString();
            Session["POLID"] = polid;
        }
            
        
       
    }


    private void alert(string message)
    {
        Response.Write("<script>alert('" + message + "')</script>");
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int secilendeger;
        if (int.TryParse(DropDownList1.SelectedValue, out secilendeger))
        {
            Session["DDL1data"] = secilendeger;
        }
    }

    protected void btnekle_Click(object sender, EventArgs e)
    {
        buttonclick();
    }

    protected void btnsil_Click(object sender, EventArgs e)
    {
        string unvan = txtunvan.Text;
        string isim = txtIsim.Text;      
        string tcno = txtTCNO.Text;
        string mail = txtMAIL.Text;
        string sifre = txtboxsifre.Text;
        
        if(tcno!= "" || sifre != "")
        {
           string queryupdate = "UPDATE Doktor" +
          " SET Doktor = NULL ," +
          " Doktorsifre = NULL ," +
          " Doktormail = NULL ," +
          " Doktorunvan = NULL ," +
          " POLID = NULL" +
          " WHERE DoktorTC = @doktortc;";

            
            SqlCommand command = new SqlCommand(queryupdate, SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();
            command.Parameters.AddWithValue("@doktortc", tcno);
            command.ExecuteNonQuery();

            alert("Silme işlemi başarıyla gerçekleşmiştir.");

            txtbolum.Text = "";
            txtunvan.Text = "";
            txtIsim.Text = "";
            txtTCNO.Text = "";
            txtMAIL.Text = "";
            txtboxsifre.Text = "";

        }
        else
        {
            alert("Lütfen Doktor ismini ve TC kimlik numarasını boş bırakmayınız !");
        }




    }
}