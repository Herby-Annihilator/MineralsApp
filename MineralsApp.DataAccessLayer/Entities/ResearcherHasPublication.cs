using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Entities
{
    [Table("researcher_has_publication")]
    public class ResearcherHasPublication
    {
        [Column("researcher_id")]
        [Required]
        public int ResearcherId { get; set; }

        public Researcher Researcher { get; set; }

        [Column("publication_id")]
        [Required]
        public int PublicationId { get; set; }

        public Publication Publication { get; set; }
    }
}
