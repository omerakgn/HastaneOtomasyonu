using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Doktorgiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Datacontrol()
    {
       
        SqlCommand commandListIl = new SqlCommand("Select * from Doktor", SqlConnectionClass.connection);
        SqlConnectionClass.CheckConnection(); 
        SqlDataReader dr = commandListIl.ExecuteReader();

        List<Doktor> doktorlistesi = new List<Doktor>();
        while (dr.Read())
        {
          
            Doktor doktor = new Doktor();
            doktor.DoktorID = dr["DoktorID"].ToString();
            doktor.DoktorTC = dr["DoktorTC"].ToString();
            doktor.Doktorsifre = dr["Doktorsifre"].ToString();

            doktorlistesi.Add(doktor);
        }

        for (int i = 0; i < doktorlistesi.Count; i++) 
        {
            
            Doktor doktor = doktorlistesi[i];
            Session["Tcno2"] = Tcno1.Text;
            Session["Sifre1"] = Sifre1.Text;

            String tcno = Session["Tcno2"]?.ToString();
            String sifre = Session["Sifre1"]?.ToString();

            if (tcno == doktor.DoktorTC && sifre == doktor.Doktorsifre)
            {
                
                Session["Tcno2"] = doktor.DoktorTC;
                String doktortc = Session["Tcno2"].ToString();

               
                Response.Redirect("Doktorsecim.aspx");
            }
            else
            {
               
                Response.Write("<script>alert('" + "Lütfen bilgilerinizi kontrol ediniz ! " + "')</script>");
            }
        }
        }
    
    public class Doktor 
    {
        public string DoktorID { get; set; }
        public string DoktorTC { get; set; }
        public string Doktorsifre { get; set; }
    }
    public void button_click()
    {
        Session["Tcno2"] = Tcno1.Text;
        Session["Sifre1"] = Sifre1.Text;
        String tcno = Session["Tcno2"]?.ToString();
        String sifre = Session["Sifre1"]?.ToString();
        if (tcno == "" || sifre == "") 
        {
            Response.Write("<script>alert('" + "Lütfen Eksik bilgi bırakmayınız ! " + "')</script>");
        }

        else
        {
            Datacontrol();
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("Sifredegistir.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       
        button_click();
    }

    
}