using Microsoft.AspNetCore.Mvc;

namespace MineralsApp.Client.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
