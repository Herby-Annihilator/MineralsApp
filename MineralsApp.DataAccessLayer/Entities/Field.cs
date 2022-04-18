using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Entities
{
    [Table("field")]
    public class Field
    {
        [Column("field_id")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = nameof(Name);

        [Column("territory_id")]
        [ForeignKey("territory_id")]
        public int? TerritoryId { get; set; }

        public Territory? Territory { get; set; }

        public ICollection<FieldHasMineral> FieldHasMinerals { get; set; }
        public override string ToString() => Name;
    }
}
