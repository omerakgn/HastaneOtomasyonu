using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yenisifre : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["Yenisifre"] = txtyenisifre.Text;
        Session["Yenisifretekrar"]= txtsifretekrar.Text;

        string yenisifre =Session["Yenisifre"].ToString();
        string sifretekrar = Session["Yenisifretekrar"].ToString();

        if(yenisifre == sifretekrar && yenisifre != null &&  sifretekrar != null)
        {
            Response.Redirect("Hastagiris.aspx");
        }
        else
        {
            Response.Write("<script>alert('" + "Şifreler birbirlerine eşit olmalı ve boş bırakılmamalı" + "')</script>");
        }

        
    }
}