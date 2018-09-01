using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyPark.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "O campo deve ter no máximo 150 caracteres!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(11, ErrorMessage = "O campo deve ter no minimo 11 caracteres!")]
        [MaxLength(11, ErrorMessage = "O campo deve ter no máximo 11 caracteres!")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(8, ErrorMessage = "O campo deve ter no minimo 8 caracteres!")]
        [MaxLength(12, ErrorMessage = "O campo deve ter no máximo 12 caracteres!")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        public string Imagem { get; set; }
    }
}