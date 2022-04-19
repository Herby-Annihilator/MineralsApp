using Microsoft.AspNetCore.Mvc;
using MineralsApp.Client.Models;
using MineralsApp.Client.ViewModels;
using MineralsApp.DataAccessLayer.DbContexts;
using MineralsApp.DataAccessLayer.Entities;
using MineralsApp.DataAccessLayer.Repositories;
using MineralsApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

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
        public IActionResult MineralDescription(int id)
        {
            Mineral mineral = _mineralRepository.Get(id);
            if (mineral == null)
                return Content($"<p>Минерал с id={id} не найден в базе</p>");
            
            return Content($"<p>{mineral.Description}</p>");
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
            UpdateMineralViewModel model = new UpdateMineralViewModel()
            {
                MineralId = mineral.Id,
                Description = mineral.Description,
                Name = mineral.Name,
                PathToImage = mineral.PathToImage,
                Fields = GetFieldsProperty(mineral),
                Territories = GetTerritoriesProperty(),
                Researchers = GetResearchersProperty(mineral),
                Publications = GetPublicationsProperty(mineral),
            };
            return View("EditMineral", model);
        }

        [HttpPost]
        public IActionResult Update(UpdateMineralViewModel model)
        {
            if (model == null)
                return NotFound();
            Mineral mineral = _mineralRepository.Get(model.MineralId);
            if (mineral == null)
                return NotFound(nameof(mineral));
            UpdateMineral(mineral, model);
            _mineralRepository.Save(mineral);
            return View("ListOfMinerals", new ListOfMineralsViewModel(_mineralRepository));
        }

        [HttpGet]
        public IActionResult Create() => View("Create", new UpdateMineralViewModel());

        [HttpPost]
        public IActionResult Create([FromBody] UpdateMineralViewModel model)
        {
            try
            {
                Mineral mineral = new Mineral();
                UpdateMineral(mineral, model);
                _mineralRepository.Save(mineral);
                IEnumerable<Mineral> minerals = _mineralRepository.GetAll();
                mineral = minerals.Last();
                return Json(new UpdateMineralViewModel() { MineralId = mineral.Id, Name = mineral.Name});
            }
            catch (Exception)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }


        [HttpGet]
        public void Delete(int id)
        {
            _mineralRepository.Delete(id);
            //return RedirectToAction("list");
        }

        private void UpdateMineral(Mineral mineral, UpdateMineralViewModel model)
        {
            mineral.Id = model.MineralId;
            mineral.Name = model.Name;
            mineral.Description = model.Description;
            SetFields(model.Fields, mineral);
            SetResearchers(model.Researchers, mineral);
            SetTerritories(model.Territories, mineral);
        }

        #region private
        private string CollectionToString<T>(ICollection<T> collection)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in collection)
            {
                builder.Append($"{item}, ");
            }
            string result = builder.ToString();
            return result.Substring(0, result.Length - 2);
        }

        private ICollection<Publication> GetPublications(ICollection<PublicationDescribesMineral> publicationDescribesMinerals)
        {
            List<Publication> publications = new List<Publication>();
            foreach (var publication in publicationDescribesMinerals)
            {
                publications.Add(publication.Publication);
            }
            return publications;
        }

        private string GetPublicationsProperty(Mineral mineral) =>
            CollectionToString(GetPublications(mineral.PublicationDescribesMineral));

        private ICollection<Ore> GetOres(ICollection<OreHasMineral> oreHasMinerals)
        {
            List<Ore> ores = new List<Ore>();
            foreach (var item in oreHasMinerals)
            {
                ores.Add(item.Ore);
            }
            return ores;
        }

        private ICollection<Field> GetFields(ICollection<FieldHasMineral> fieldHasMinerals)
        {
            List<Field> fields = new List<Field>();
            foreach (var item in fieldHasMinerals)
            {
                fields.Add(item.Field);
            }
            return fields;
        }

        private ICollection<Researcher> GetResearchers(Mineral mineral)
        {
            ICollection<Publication> publications = GetPublications(mineral.PublicationDescribesMineral);
            List<Researcher> researchers = new List<Researcher>();
            foreach (var item in publications)
            {
                foreach (var researcherHasPublication in item.ResearcherHasPublication)
                {
                    if (!researchers.Contains(researcherHasPublication.Researcher))
                    {
                        researchers.Add(researcherHasPublication.Researcher);
                    }

                }
            }
            return researchers;
        }

        private void SetFields(string value, Mineral mineral)
        {
            ICollection<Field> realFields = GetFields(mineral.FieldHasMinerals);
            string[] fields = value.Split(',', System.StringSplitOptions.RemoveEmptyEntries);
            bool shouldAdd;
            foreach (var item in fields)
            {
                shouldAdd = true;
                foreach (var field in realFields)
                {
                    if (field.Name == item)
                    {
                        shouldAdd = false;
                        break;
                    }
                }
                if (shouldAdd)
                {
                    mineral.FieldHasMinerals.Add(new FieldHasMineral()
                    {
                        Field = new Field() { Name = item },
                        Mineral = mineral,
                    });
                }
            }
        }

        private void SetResearchers(string value, Mineral mineral)
        {
            string[] researchers = value.Split(',', System.StringSplitOptions.RemoveEmptyEntries);
            string[] names;
            bool shouldAdd;
            ICollection<Researcher> realResearchers = GetResearchers(mineral);
            foreach (var item in researchers)
            {
                shouldAdd = true;
                names = item.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                foreach (var realResearcher in realResearchers)
                {
                    if (names[0] == realResearcher.FirstName
                        && names[1] == realResearcher.LastName
                        && names[2] == realResearcher.Patronymic)
                    {
                        shouldAdd = false;
                        break;
                    }
                }
                if (shouldAdd)
                {
                    Researcher researcher = new Researcher()
                    {
                        FirstName = names[0],
                        LastName = names[1],
                        Patronymic = names[2],
                    };
                    Publication publication = new Publication()
                    {
                        Name = $"{mineral.Name} by {researcher}",
                        ResearcherHasPublication = new List<ResearcherHasPublication>()
                    };
                    publication.ResearcherHasPublication.Add(new ResearcherHasPublication() { Publication = publication, Researcher = researcher });
                    mineral.PublicationDescribesMineral.Add(new PublicationDescribesMineral()
                    {
                        Mineral = mineral,
                        Publication = publication,
                    });
                }
            }
        }

        private void SetTerritories(string value, Mineral mineral)
        {
            mineral.FieldHasMinerals.Add(new FieldHasMineral()
            {
                Mineral = mineral,
                Field = new Field()
                {
                    Name = $"Месторождение минерала {mineral.Id}",
                    Territory = new Territory()
                }
            });
        }

        private string GetFieldsProperty(Mineral mineral) => CollectionToString(GetFields(mineral.FieldHasMinerals));

        private string GetResearchersProperty(Mineral mineral) => CollectionToString(GetResearchers(mineral));

        private string GetTerritoriesProperty() => "Территория 1, Территория 2, Территория 3";
        #endregion
    }
}
