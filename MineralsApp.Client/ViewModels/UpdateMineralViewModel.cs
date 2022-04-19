using MineralsApp.DataAccessLayer.Entities;
using MineralsApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MineralsApp.Client.ViewModels
{
    public class UpdateMineralViewModel
    {
        [JsonPropertyName("id")]
        public int MineralId { get; set; } = 0;
        [JsonPropertyName("mineralName")]
        public string Name { get; set; } = "";
        [JsonPropertyName("description")]
        public string Description { get; set; } = "";
        [JsonPropertyName("pathToImage")]
        public string PathToImage { get; set; } = "";
        [JsonPropertyName("publish")]
        public string Publications { get; set; } = "";
        [JsonPropertyName("field")]
        public string Fields { get; set; } = "";
        [JsonPropertyName("searchers")]
        public string Researchers { get; set; } = "";
        [JsonPropertyName("territory")]
        public string Territories { get; set; } = "";   
    }
}
