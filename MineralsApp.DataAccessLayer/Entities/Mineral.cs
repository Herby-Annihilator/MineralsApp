using MineralsApp.DataAccessLayer.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Entities
{
    [Table("mineral")]
    public class Mineral : IEntity
    {
        [Column("mineral_id")]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("description")]
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        
        [Column("path_to_image")]
        [MaxLength(500)]
        public string PathToImage { get; set; }

        public ICollection<PublicationDescribesMineral> PublicationDescribesMineral { get; set; }

        public ICollection<OreHasMineral> OreHasMinerals { get; set; }

        public ICollection<FieldHasMineral> FieldHasMinerals { get; set; }
    }
}
