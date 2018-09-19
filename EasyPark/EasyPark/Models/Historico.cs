using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyPark.Models
{
    [Table("Historicos")]
    public class Historico
    {
        [Key]
        public int HistoricoID { get; set; }

        public Automovel Automovel { get; set; }

        public Vaga Vaga { get; set; }

        [Required (ErrorMessage = "Informe a data e horario de entrada")]
        public DateTime DataEntrada { get; set; }

        public DateTime? DataSaida { get; set; }
    }
}