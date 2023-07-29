using Conta.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Conta.Models
{
    public class Transacao
    {
        [Key]
        public int Id { get; set; }

        public DateTime Data { get; set; }
        public TipoTransacao Tipo { get; set; }
        public decimal Valor { get; set; }
        public int ContaDestino { get; set; }
    }
}