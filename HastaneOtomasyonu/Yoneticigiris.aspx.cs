using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yoneticigiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    public void Datacontrol()
    {

        SqlCommand commandListIl = new SqlCommand("Select * from Yonetici", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection();
        SqlDataReader dr = commandListIl.ExecuteReader();

        List<Yonetici> yoneticiliste = new List<Yonetici>();
        while (dr.Read())
        {

            Yonetici yonetici = new Yonetici();
            yonetici.YoneticiID = dr["YoneticiID"].ToString();
            yonetici.YoneticiTC = dr["YoneticiTC"].ToString();
            yonetici.Yoneticisifre = dr["Yoneticisifre"].ToString();

            yoneticiliste.Add(yonetici);
        }

        for (int i = 0; i < yoneticiliste.Count; i++)
        {

            Yonetici yonetici = yoneticiliste[i];
            Session["yoneticitc"] = Yoneticitc.Text;
            Session["yoneticisifre"] = Sifre.Text;

            String tcno = Session["yoneticitc"].ToString();
            String sifre = Session["yoneticisifre"].ToString();

            if (tcno == yonetici.YoneticiTC && sifre == yonetici.Yoneticisifre)
            {

                Session["yoneticitc"] = yonetici.YoneticiTC;
                String yoneticitc = Session["yoneticitc"].ToString();


                Response.Redirect("Yoneticisayfa.aspx");
            }
            else
            {

                Response.Write("<script>alert('" + "Lütfen bilgilerinizi kontrol ediniz ! " + "')</script>");
            }
        }
    }

    public class Yonetici
    {
        public string YoneticiID { get; set; }
        public string YoneticiTC { get; set; }
        public string Yoneticisifre { get; set; }
    }
    public void button_click()
    {
        Session["yoneticitc"] = Yoneticitc.Text;
        Session["yoneticisifre"] = Sifre.Text;
        String tcno = Session["yoneticitc"].ToString();
        String sifre = Session["yoneticisifre"].ToString();
        if (tcno == "" || sifre == "")
        {
            Response.Write("<script>alert('" + "Lütfen Eksik bilgi bırakmayınız ! " + "')</script>");
        }

        else
        {
            Datacontrol();
        }
    }



    protected void Button_Click(object sender, EventArgs e)
    {
        button_click();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sifredegistir.aspx");
    }
}