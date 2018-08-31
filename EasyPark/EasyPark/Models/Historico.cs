using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyPark.Models
{
    [Table("Historicos")]
    public class Historico
    {
        public int HistoricoID { get; set; }
        public Automovel Automovel { get; set; }
        public Vaga Vaga { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
    }
}