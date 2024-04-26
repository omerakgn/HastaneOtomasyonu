using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teknikergiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    public void alert(string message)
    {
        Response.Write("<script>alert('" + message + "')</script>");
    }
    public void Datacontrol()
    {
        SqlCommand commandListIl = new SqlCommand("Select * from Tekniker", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        SqlDataReader dr = commandListIl.ExecuteReader();
        List<Tekniker> teknikerListesi = new List<Tekniker>();
        while (dr.Read())
        {

            Tekniker tekniker = new Tekniker();
            tekniker.TeknikerID = Convert.ToInt32(dr["TeknikerID"]);
            tekniker.TeknikerTC = dr["TeknikerTC"].ToString();
            tekniker.Teknikersifre = dr["Teknikersifre"].ToString();

            teknikerListesi.Add(tekniker);
        }

        for (int i = 0; i < teknikerListesi.Count; i++)
        {
            Tekniker tekniker = teknikerListesi[i];
            Session["Tcno"] = Tcno.Text;
            Session["Sifre"] = Sifre.Text;
            String tcno = Session["Tcno"]?.ToString();
            String sifre = Session["Sifre"]?.ToString();

            if (tcno == tekniker.TeknikerTC && sifre == tekniker.Teknikersifre)
            {
                Response.Redirect("Teknikersecim.aspx");
            }
            else
            {
                alert("Lütfen bilgilerinizi kontrol ediniz.");
            }
        }
    }
    public class Tekniker
    {
        public int TeknikerID { get; set; }
        public string TeknikerTC { get; set; }
        public string Teknikersifre { get; set; }
    }
    private void button_click()
    {
        Session["Tcno"] = Tcno.Text;
        Session["Sifre"] = Sifre.Text;

        String tcno = Session["Tcno"].ToString();
        String sifre = Session["Sifre"].ToString() ;
        if(tcno == "" || sifre == "")
        {
            alert("Lütfen istenilen bilgileri giriniz");
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
}