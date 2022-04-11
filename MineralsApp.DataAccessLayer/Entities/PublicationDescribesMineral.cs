using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Entities
{
    [Table("publication_describes_mineral")]
    public class PublicationDescribesMineral
    {
        [Column("mineral_id")]
        [Required]
        public int MineralId { get; set; }
        public Mineral Mineral { get; set; }

        [Column("publication_id")]
        [Required]
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }

    }
}
