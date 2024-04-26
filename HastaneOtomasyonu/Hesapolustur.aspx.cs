using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hesapolustur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void button_click()
    {
        
        Session["isim"] = isimtxt.Text;
        Session["soyisim"] = soyisimtxt.Text;
        Session["tcno"] = tcnotxt.Text;
        Session["mail"] = mailtxt.Text;
        Session["sifre"] = sifretxt.Text;
        Session["telno"] = telnotxt.Text;
       
        String isim = Session["isim"]?.ToString();
        String soyisim = Session["soyisim"]?.ToString();
        String Tcno = Session["tcno"]?.ToString();
        String mail = Session["mail"]?.ToString();
        String sifre = Session["sifre"]?.ToString();
        String telno = Session["telno"]?.ToString();
        if(isim =="" || soyisim =="" || Tcno == "" || mail=="" ||sifre=="" || telno == "")
        {
            alert("Lütfen bütün alanları doldurunuz !");
        }
        else
        {
            alert("Hesabınız başarıyla oluşturulmuştur. Bilgilerinizi kullanarak giriş yapabilirsiniz");
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
}