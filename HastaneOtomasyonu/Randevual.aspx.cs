using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Randevual : System.Web.UI.Page
{
    public void Page_Load(object sender, EventArgs e) 
    {

        

        if (!IsPostBack) 
        {
            
            SqlCommand commandListIl = new SqlCommand("Select * from IL", SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();
            SqlDataReader dr = commandListIl.ExecuteReader();
            
            while (dr.Read()) 
            {
                ListItem item = new ListItem();
                item.Text = dr["Isim"].ToString();
                item.Value = dr["IlID"].ToString();
                il.Items.Add(item);
            }

           
            il.DataBind();
            dr.Close(); 


            
            il.Items.Insert(0, new ListItem("Seçiniz", ""));
        }
    }

    public void GetIlceDropdowndata(int secilenDeger)
    {

        try
        {
           
            SqlCommand commandListIlce = new SqlCommand("Select * from Ilce", SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();
            commandListIlce.Parameters.AddWithValue("@IlID", secilenDeger); 
            ilce.Items.Clear();
            SqlDataReader dr2 = commandListIlce.ExecuteReader();


            while (dr2.Read()) 
            {

                ListItem item = new ListItem(); 
                item.Text = dr2["Ilceisim"].ToString();
                item.Value = dr2["IlceID"].ToString();
                var baglıid = dr2["ILID"].ToString();
                if (il.SelectedValue == baglıid) 
                {
                    ilce.Items.Add(item);
                }

            }
            ilce.Items.Insert(0, new ListItem("Seçiniz", "")); 
        }
        catch (Exception ex)
        {
            alert(ex.Message);
        }

    }
    public void GetHastaneDropDownData(string secilendeger , string secilendeger2){ 
       

        SqlCommand command = new SqlCommand("Select * from Hastane WHERE Ilcekodu = @Ilcekodu ", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        command.Parameters.AddWithValue("@Ilcekodu", secilendeger);

        hastane.Items.Clear();
        SqlDataReader dr = command.ExecuteReader();
        while (dr.Read()) {
            ListItem item = new ListItem();
            item.Text = dr["Hastaneisim"].ToString();
            item.Value = dr["HastaneID"].ToString();
            var baglıid = dr["Ilcekodu"].ToString();
            if (ilce.SelectedItem.Text == secilendeger2)
            {
                Session["hastaneid"] = dr["HastaneID"].ToString(); ;
                hastane.Items.Add(item);
            }
        }
        hastane.Items.Insert(0, new ListItem("Seçiniz", ""));

    }
    public void GetPoliklinikDropDownData(int secilendeger)
    {
     

        SqlCommand command = new SqlCommand("Select * from Poliklinik", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        command.Parameters.AddWithValue("@HastaneID", secilendeger);

        poliklinik.Items.Clear();
        SqlDataReader dr = command.ExecuteReader();

        while (dr.Read())
        {
            ListItem item = new ListItem();
            item.Text = dr["Polisim"].ToString();
            item.Value = dr["PolID"].ToString();
            var baglıid = dr["HastaneID"].ToString();
            
            if (hastane.SelectedValue == baglıid)
            {
                Session["polid"] = dr["PolID"].ToString();
                poliklinik.Items.Add(item);
            }
        }
        poliklinik.Items.Insert(0, new ListItem("Seçiniz", ""));

    }
    public void GetDoktorDropDownData(int secilendeger)
    {
       
       
            SqlCommand command = new SqlCommand("Select * from Doktor", SqlConnectionClass.connection);
            SqlConnectionClass.CheckConnection();
            command.Parameters.AddWithValue("@PolID", secilendeger);
            doktor.Items.Clear();
            SqlDataReader dr = command.ExecuteReader();
            
        try
        {
            while (dr.Read())
            {
                ListItem item = new ListItem();
                item.Text = dr["Doktor"].ToString();
                item.Value = dr["DoktorID"].ToString();
                var baglıid = dr["PolID"].ToString();
                if (poliklinik.SelectedValue == baglıid)
                {
                    Session["Doktortc"] = dr["DoktorTC"].ToString();                 
                    doktor.Items.Add(item);
                }
            }
        }catch(Exception ex)
        {
            alert("YANLIŞLIK VAR" + ex);
        }
        doktor.Items.Insert(0, new ListItem("Seçiniz", ""));

    }

    public void insertdata()
    {
        string insertQuery = "INSERT INTO Randevu (Randevutarih, HastaTC,DoktorTC,PolID,HastaneID) VALUES (@Value1, @Value2, @Value3,@Value4,@Value5)";
        SqlCommand command = new SqlCommand(insertQuery, SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();

        var Randevutarih =tarih.SelectedDate;
        string HastaTC = Session["Tcno"].ToString();
        string doktorTC = Session["Doktortc"].ToString();
        string polid = Session["poliklinik"].ToString();
        string hasteneid = Session["hastaneid"].ToString();

        command.Parameters.AddWithValue("@Value1", Randevutarih);
        command.Parameters.AddWithValue("@Value2", HastaTC);
        command.Parameters.AddWithValue("@Value3", doktorTC);
        command.Parameters.AddWithValue("@Value4", polid);
        command.Parameters.AddWithValue("@Value5", hasteneid);

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            alert("Başarıyla eklendi");
        }
        else
        {
            alert("Sıkıntı oluştu");
        }
    }

    private void button_click()
    {
     
        Session["il"]= il.Text;
        Session["ilce"] = ilce.Text;
        Session["hastane"] = hastane.Text;
        Session["poliklinik"] = poliklinik.Text;
        Session["doktor"] = doktor.Text;
        Session["tarih"] = tarih.SelectedDate;
        Session["sikayet"] = sikayet.Text;

        String Il = Session["il"].ToString();
        String Ilce = Session["ilce"].ToString();
        String Hastane = Session["hastane"].ToString() ;
        String Poliklinik = Session["poliklinik"].ToString();
        String Doktor = Session["doktor"].ToString();
        var Tarih = Session["tarih"].ToString();
        String Sikayet = Session["sikayet"].ToString();
        if(Il==""|| Ilce == ""|| Hastane==""||Poliklinik == ""|| Doktor==""||Tarih==""|| Sikayet=="")
        {
            alert("Lütfen istenilen bilgileri doldurunuz.");
        }
        else
        {
            insertdata();
            Response.Redirect("Randevularim.aspx");
        }

    }
    private void alert(string message)
    {
        Response.Write("<script>alert('" + message + "')</script>");
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        button_click(); 

    }

    protected void il_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        int secilendeger;
        if (int.TryParse(il.SelectedValue, out secilendeger))
        {
            GetIlceDropdowndata(secilendeger);
        }
    }



    protected void ilce_SelectedIndexChanged(object sender, EventArgs e) 
    {
        string secilendeger;

        secilendeger = ilce.SelectedItem.Text;

        
        

        SqlCommand commandListIlce = new SqlCommand("SELECT Ilcekodu, ILID FROM Ilce WHERE Ilceisim = @Ilceisim", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        commandListIlce.Parameters.AddWithValue("@Ilceisim", secilendeger);
        
        SqlDataReader dr2 = commandListIlce.ExecuteReader();
        if (dr2.Read())
        {
            string ilceKodu = dr2["Ilcekodu"].ToString();
            
            GetHastaneDropDownData(ilceKodu,secilendeger);
        }

       
        
    }

    protected void hastane_SelectedIndexChanged(object sender, EventArgs e) 
    {
        int secilendeger;
        if (int.TryParse(hastane.SelectedValue, out secilendeger))
        {
            GetPoliklinikDropDownData(secilendeger);
        }
    }

    protected void poliklinik_SelectedIndexChanged(object sender, EventArgs e)
    {
        int secilendeger;
        if (int.TryParse(poliklinik.SelectedValue, out secilendeger))
        {
            GetDoktorDropDownData(secilendeger);
        }
    }
}