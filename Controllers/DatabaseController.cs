using HQTCSDL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
public class DatabaseController : Controller
{
    [HttpPost]
    public IActionResult Connect(DbConnectionModel model)
    {
        string connectionString =$"Server={model.Server};Database={model.Database};User Id={model.Username};Password={model.Password};TrustServerCertificate=True;";

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
            }
            HttpContext.Session.SetString("Server", model.Server);
            HttpContext.Session.SetString("Database", model.Database);
            HttpContext.Session.SetString("Username", model.Username);  
            TempData["Message"] = "Kết nối thành công!";
        }
        catch (Exception ex)
        {
            TempData["Message"] = ex.ToString();
        }

        return RedirectToAction("Query", "Data");
    }
}