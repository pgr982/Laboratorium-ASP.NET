using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("posts")]
    public class PostEntity
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [MaxLength(2000)]
        [Required]
        public string Content { get; set; }

        [MaxLength(50)]
        [Required]
        public string Autor { get; set; }

        [Column("postdate")]
        public DateTime PostDate { get; set; }

        [MaxLength(100)]
        [Required]
        public string Tags { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }
    }
}
