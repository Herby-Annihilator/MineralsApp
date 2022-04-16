using Microsoft.AspNetCore.Mvc;
using MineralsApp.Client.Models;
using MineralsApp.Client.ViewModels;
using MineralsApp.DataAccessLayer.DbContexts;
using MineralsApp.DataAccessLayer.Entities;
using MineralsApp.DataAccessLayer.Repositories;
using MineralsApp.DataAccessLayer.Repositories.Interfaces;
using System.Diagnostics;

namespace MineralsApp.Client.Controllers
{
    public class MineralsController : Controller
    {
        private IRepository<Mineral> _mineralRepository;
        private DetailedMineralViewModel _detailedMineralViewModel;
        public MineralsController(IRepository<Mineral> mineralRepository)
        {
            _mineralRepository = mineralRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Mineral mineral = _mineralRepository.Get(id);
            if (mineral == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            _detailedMineralViewModel = new DetailedMineralViewModel(mineral);
            return View("DetailedMineral", _detailedMineralViewModel);
        }
    }
}
