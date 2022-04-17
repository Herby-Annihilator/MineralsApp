using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Entities
{
    [Table("researcher")]
    public class Researcher
    {
        [Column("researcher_id")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Column("patronymic")]
        [MaxLength(100)]
        public string Patronymic { get; set; }

        public ICollection<ResearcherHasPublication> ResearcherHasPublication { get; set; }

        public override string ToString() => $"{FirstName} {LastName} {Patronymic}";
    }
}
