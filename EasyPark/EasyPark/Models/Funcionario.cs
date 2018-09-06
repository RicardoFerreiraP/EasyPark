using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyPark.Models
{
    [Table("Funcionarios")]
    public class Funcionario : Pessoa
    {
        [Key]
        public int FuncionarioID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(6, ErrorMessage = "O campo deve ter no mínimo 6 caracteres!")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        [Display(Name = "Confirmar senha")]
        [NotMapped]
        public string ConfirmacaoDaSenha { get; set; }
    }
}