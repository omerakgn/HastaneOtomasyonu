using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Güvenlikkodu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    private void koddogrulama() 
    {
        String Num = Session["kod"].ToString(); 
        Session["Kod"] = Kod.Text; 
        
        var kod2 = Session["Kod"].ToString();
        if(kod2==Num) 
        {
            

            Response.Redirect("Yenisifre.aspx");
        }
        else
        {
            Response.Write("<script>alert('" + "Lütfen kodu doğru girdiğinizden emin olun !" + "')</script>");
            
        }
     
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        koddogrulama();
    }
}