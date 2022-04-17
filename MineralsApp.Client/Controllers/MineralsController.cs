using Microsoft.AspNetCore.Mvc;
using MineralsApp.Client.Models;
using MineralsApp.Client.ViewModels;
using MineralsApp.DataAccessLayer.DbContexts;
using MineralsApp.DataAccessLayer.Entities;
using MineralsApp.DataAccessLayer.Repositories;
using MineralsApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace MineralsApp.Client.Controllers
{
    public class MineralsController : Controller
    {
        private IRepository<Mineral> _mineralRepository;
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
            return View("DetailedMineral", new DetailedMineralViewModel(mineral));
        }

        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<Mineral> minerals = _mineralRepository.GetAll();
            if (minerals == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View("ListOfMinerals", new ListOfMineralsViewModel(_mineralRepository));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var mineral = _mineralRepository.Get(id);
            if (mineral == null)
                return NotFound(nameof(mineral));
            return View("EditMineral", new UpdateMineralViewModel(mineral, _mineralRepository));
        }

        [HttpPost]
        public IActionResult Update(Mineral mineral)
        {
            if (mineral == null)
                return NotFound();
            _mineralRepository.Save(mineral);
            return View("ListOfMinerals", new ListOfMineralsViewModel(_mineralRepository));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _mineralRepository.Delete(id);
            return View("ListOfMinerals", new ListOfMineralsViewModel(_mineralRepository));
        }
    }
}
