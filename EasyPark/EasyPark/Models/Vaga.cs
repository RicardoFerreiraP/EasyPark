using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyPark.Models
{
    [Table("Vagas")]
    public class Vaga
    {
        [Key]
        public int VagaID { get; set; }

        [Required]
        public bool Disponivel { get; set; }
       
       
    }
}