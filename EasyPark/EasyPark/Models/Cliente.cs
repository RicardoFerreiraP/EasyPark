using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyPark.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]        
        public int ClienteID { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}