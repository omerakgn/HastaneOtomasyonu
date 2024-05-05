using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      /*  try 
        {
            if (Session["sifredegisikligi"].ToString() == "sifredegisikligi") 
            {
                Response.Write("<script>alert('" + "Şifreniz başarıyla değiştirilmiştir !" + "')</script>");
            }
        }
        catch(Exception ex)
        {
            
        }*/


    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Hastagiris.aspx"); 
        
       
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("Doktorgiris.aspx");

    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("Teknikergiris.aspx"); 
    }
}