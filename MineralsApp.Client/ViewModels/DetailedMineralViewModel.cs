using MineralsApp.DataAccessLayer.Entities;
using MineralsApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MineralsApp.Client.ViewModels
{
    public class DetailedMineralViewModel
    {
        private Mineral _mineral;
        private const int COLLECTION_ITEMS_TO_SHOW = 3;
        public DetailedMineralViewModel(Mineral mineral)
        {
            _mineral = mineral;
        }
        public string MineralName => _mineral.Name;
        public string MineralDescription => _mineral.Description;

        public ICollection<Publication> Publications => GetPublications(_mineral.PublicationDescribesMineral);

        private ICollection<Publication> GetPublications(ICollection<PublicationDescribesMineral> publicationDescribesMinerals)
        {
            List<Publication> publications = new List<Publication>();
            foreach (var publication in publicationDescribesMinerals)
            {
                publications.Add(publication.Publication);
            }
            return publications;
        }

        public IEnumerable<Publication> LimitedPublications()
        {
            ICollection<Publication> publications = Publications;
            return publications.OrderBy(p => p.CreationDate).Take(COLLECTION_ITEMS_TO_SHOW);
        }

        public ICollection<Ore> Ores => GetOres(_mineral.OreHasMinerals);
        private ICollection<Ore> GetOres(ICollection<OreHasMineral> oreHasMinerals)
        {
            List<Ore> ores = new List<Ore>();
            foreach (var item in oreHasMinerals)
            {
                ores.Add(item.Ore);
            }
            return ores;
        }

        public ICollection<Field> Fields => GetFields(_mineral.FieldHasMinerals);
        private ICollection<Field> GetFields(ICollection<FieldHasMineral> fieldHasMinerals)
        {
            List<Field> fields = new List<Field>();
            foreach (var item in fieldHasMinerals)
            {
                fields.Add(item.Field);
            }
            return fields;
        }

        public ICollection<Researcher> Researchers => GetResearchers();
        private ICollection<Researcher> GetResearchers()
        {
            ICollection<Publication> publications = Publications;
            List<Researcher> researchers = new List<Researcher>();
            foreach (var item in publications)
            {
                foreach (var researcherHasPublication in item.ResearcherHasPublication)
                {
                    if (!researchers.Contains(researcherHasPublication.Researcher))
                    {
                        researchers.Add(researcherHasPublication.Researcher);
                        if (researchers.Count == COLLECTION_ITEMS_TO_SHOW)
                            return researchers;
                    }
                        
                }
                if (researchers.Count == COLLECTION_ITEMS_TO_SHOW)
                    return researchers;
            }
            return researchers;
        }
    }
}
