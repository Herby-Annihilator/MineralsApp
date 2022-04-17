using MineralsApp.DataAccessLayer.Entities;
using MineralsApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MineralsApp.Client.ViewModels
{
    public class UpdateMineralViewModel : SaveMineralViewModel
    {
        private Mineral _mineral;
        private IRepository<Mineral> _mineralRepository;
        public UpdateMineralViewModel(Mineral mineral, IRepository<Mineral> repository)
        {
            _mineral = mineral;
            _mineralRepository = repository;
        }

        public override string Name { get => _mineral.Name; set => _mineral.Name = value; }
        public override string Description { get => _mineral.Description; set => _mineral.Description = value; }
        public override string PathToImage { get => _mineral.PathToImage; set => _mineral.PathToImage = value; }

        public override string Fields
        {
            get => CollectionToString(GetFields(_mineral.FieldHasMinerals));
            set
            {
                ICollection<Field> realFields = GetFields(_mineral.FieldHasMinerals);
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
                        _mineral.FieldHasMinerals.Add(new FieldHasMineral() 
                        { 
                            Field = new Field() { Name = item },
                            Mineral = _mineral,
                        });
                    }
                }
            }
        }

        public override string Researchers
        {
            get => CollectionToString(GetResearchers());
            set
            {
                string[] researchers = value.Split(',', System.StringSplitOptions.RemoveEmptyEntries);
                string[] names;
                bool shouldAdd;
                ICollection<Researcher> realResearchers = GetResearchers();
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
                            Name = $"{_mineral.Name} by {researcher}",
                            ResearcherHasPublication = new List<ResearcherHasPublication>()
                        };
                        publication.ResearcherHasPublication.Add(new ResearcherHasPublication() { Publication = publication, Researcher = researcher });
                        _mineral.PublicationDescribesMineral.Add(new PublicationDescribesMineral()
                        {
                            Mineral = _mineral,
                            Publication = publication,
                        });
                    }
                }
            }
        }
        public override string Territories
        {
            get => "Территория 1, Территория 2, Территория 3";
            set
            {
                _mineral.FieldHasMinerals.Add(new FieldHasMineral()
                {
                    Mineral = _mineral,
                    Field = new Field()
                    {
                        Name = $"Месторождение минерала {_mineral.Id}",
                        Territory = new Territory()
                    }
                });
            }
        }

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

        private ICollection<Researcher> GetResearchers()
        {
            ICollection<Publication> publications = GetPublications(_mineral.PublicationDescribesMineral);
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
    }
}
