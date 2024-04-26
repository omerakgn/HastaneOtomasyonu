using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IdentityModel.Protocols.WSTrust;
using System.Xml.Linq;
using System.ServiceModel.MsmqIntegration;
using System.Text;

public partial class Sifredegistir : System.Web.UI.Page
{
    
    

    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    public void alert(string message) 
    {
        Response.Write("<script>alert('" + message + "')</script>");
    }

    public void send_click()
    {
        Session["tcnosifredegistir"] = tcno.Text; 
        Session["mail"] = mail.Text;
        String TC = Session["tcnosifredegistir"]?.ToString();


        Random r = new Random(); 
        int num = r.Next(1000, 9999);
        Session["kod"]  =num; 

        string to = Session["mail"]?.ToString(); 
        string from = "hastanerandevu00@gmail.com"; 

        //hastanerandevu00@gmail.com   şifre: hastanerandevu159357
        if (to == "" || TC == "")
        { 
           
            alert("Mail adresi veya TC no boş bırakılamaz !");
        }
        
        else
        {
            MailMessage message = null; 
            try
            {
               
                message = new MailMessage(from, to);
                string mailbody = "Bu kodu kullanarak şifrenizi yenileyebilirsiniz : " + num.ToString();
                message.Subject = "ŞİFRE YENİLEME";
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta oluşturulurken bir hata oluştu: " + ex.Message);
            }

            if (message != null) 
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential(from, "bmfa incc ymft zrzv");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;

                try
                {
                    client.Send(message);
                    Console.WriteLine("E-posta başarıyla gönderildi.");
                    Response.Redirect("Güvenlikkodu.aspx?num=" + num);

                }
                catch (Exception ex)
                {
                    
                }
            }
        }


    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        send_click();      
    }
}