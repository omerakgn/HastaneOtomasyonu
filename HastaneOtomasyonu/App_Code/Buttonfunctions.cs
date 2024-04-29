using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
/// <summary>
/// Summary description for Buttonfunctions
/// </summary>
public class Buttonfunctions : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        // İstek verilerini JSON olarak al
        string jsonString = new System.IO.StreamReader(context.Request.InputStream).ReadToEnd();
        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);

        // Silinecek satırın ID'sini al
        int id = data.id;

        // SQL bağlantısı oluştur
        SqlConnectionClass.CheckConnection();
        
            

            // SQL komutunu oluştur
            string sql = "DELETE FROM Teknik_Sorun WHERE TekniksorunID = @ID";
            using (SqlCommand command = new SqlCommand(sql, SqlConnectionClass.connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }
        

        // Başarı durumunu istemciye bildir
        context.Response.ContentType = "application/json";
        context.Response.Write("{\"success\":true}");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}