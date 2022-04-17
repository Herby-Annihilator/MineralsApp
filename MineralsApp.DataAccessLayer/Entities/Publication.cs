using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Entities
{
    [Table("publication")]
    public class Publication
    {
        [Column("publication_id")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("creation_date")]
        [Required]
        public DateTime CreationDate { get; set; }

        public ICollection<PublicationDescribesMineral> PublicationDescribesMineral { get; set; }

        public ICollection<ResearcherHasPublication> ResearcherHasPublication { get; set; }

        public override string ToString() => Name;
    }
}
