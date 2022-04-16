using Microsoft.AspNetCore.Mvc;
using MineralsApp.DataAccessLayer.DbContexts;
using MineralsApp.DataAccessLayer.Repositories;

namespace MineralsApp.Client.Controllers
{
    public class MineralsController : Controller
    {
        private MineralRepository _mineralRepository;
        public MineralsController(MineralRepository mineralRepository)
        {
            _mineralRepository = mineralRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("detailed")]
        public IActionResult GetDetailedDescription()
        {

            return View("DetailedMineral");
        }
    }
}
