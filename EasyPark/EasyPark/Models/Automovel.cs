using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyPark.Models
{
    [Table("Automoveis")]
    public class Automovel
    {
        [Key]
        public int AutomovelID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Tipo { get; set; }

        public Cliente Cliente { get; set; }

    }
}