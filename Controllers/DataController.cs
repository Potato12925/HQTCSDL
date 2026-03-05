using Microsoft.AspNetCore.Mvc;

namespace HQTCSDL.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Query()
        {
            return View();
        }
        public IActionResult Report()
        {
            return View();
        }
    }
}
