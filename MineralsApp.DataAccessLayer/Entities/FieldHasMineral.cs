using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Entities
{
    [Table("field_has_mineral")]
    public class FieldHasMineral
    {
        [Column("field_id")]
        [Required]
        public int FieldId { get; set; }
        public Field Field { get; set; }

        [Column("mineral_id")]
        [Required]
        public int MineralId { get; set; }
        public Mineral Mineral { get; set; }
    }
}
