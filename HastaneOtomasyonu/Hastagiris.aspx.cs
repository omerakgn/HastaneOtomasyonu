using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hastagiris : System.Web.UI.Page 
{
    public void Page_Load(object sender, EventArgs e)
    {
        
    }
    public void alert(string message)
    {
        Response.Write("<script>alert('" + message + "')</script>");
    }
    public void Datacontrol()
    {
        SqlCommand commandListIl = new SqlCommand("Select * from Hasta", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        SqlDataReader dr = commandListIl.ExecuteReader();
        List<Hasta> hastaListesi = new List<Hasta>();
        while (dr.Read())
        {
            
            Hasta hasta = new Hasta();
            hasta.HastaID = dr["HastaID"].ToString();
            hasta.HastaTC= dr["HastaTC"].ToString();
            hasta.Hastasifre = dr["Hastasifre"].ToString();

            hastaListesi.Add(hasta);
       }

        for(int i = 0; i<hastaListesi.Count ;i++)
        {
            Hasta hasta = hastaListesi[i];
            Session["Tcno"] = Tcno.Text;
            Session["Sifre"] = Sifre.Text;
            
            String tcno = Session["Tcno"]?.ToString();
            String sifre = Session["Sifre"]?.ToString();

            if (tcno==hasta.HastaTC && sifre == hasta.Hastasifre)
            {

                Session["Tcno"] = hasta.HastaTC;
                String hastatc = Session["Tcno"].ToString();


                Response.Redirect("Randevularim.aspx");
            }
            else
            {
                alert("Lütfen bilgilerinizi kontrol ediniz.");
            }
        }
    }
    public class Hasta
    {
        public string HastaID { get; set; }
        public string HastaTC { get; set; }
        public string Hastasifre { get; set; }
    }
    public void button_click()
    {
        Session["Tcno"] = Tcno.Text;
        Session["Sifre"] = Sifre.Text;
        String tcno = Session["Tcno"]?.ToString();
        String sifre = Session["Sifre"]?.ToString();
        if (tcno == "" || sifre == "")
        {
            alert("Lütfen istenilen bilgileri doldurunuz.");
        }

        else
        {
            Datacontrol();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        button_click();            
    }



    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sifredegistir.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Hesapolustur.aspx");
    }

    protected void Tcno_TextChanged(object sender, EventArgs e)
    {

    }
}