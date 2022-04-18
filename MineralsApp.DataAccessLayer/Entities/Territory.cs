using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Entities
{
    [Table("territory")]
    public class Territory
    {
        [Required]
        [Key]
        [Column("territory_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = nameof(Territory);

        [ForeignKey("country_id")]
        [Column("country_id")]
        public int? CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Field> Fields { get; set; }
    }
}
