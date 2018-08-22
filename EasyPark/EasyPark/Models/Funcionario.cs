using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyPark.Models
{
    [Table("Funcionarios")]
    public class Funcionario 
    {
        [Key]
        public int FuncionarioID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(6, ErrorMessage = "O campo deve ter no mínimo 6 caracteres!")]
        [Display(Name = "Senha")]
    }
}