using MineralsApp.DataAccessLayer.Entities;
using MineralsApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MineralsApp.Client.ViewModels
{
    public class UpdateMineralViewModel
    {
        public int MineralId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathToImage { get; set; }
        public string Publications { get; set; }
        public string Fields { get; set; }

        public string Researchers { get; set; }
        public string Territories { get; set; }

        
    }
}
