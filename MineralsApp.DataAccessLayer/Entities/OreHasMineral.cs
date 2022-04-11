using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Entities
{
    [Table("ore_has_mineral")]
    public class OreHasMineral
    {
        [Column("ore_id")]
        [Required]
        public int OreId { get; set; }
        public Ore Ore { get; set; }

        [Column("mineral_id")]
        [Required]
        public int MineralId { get; set; }
        public Mineral Mineral { get; set; }
    }
}
