using System.ComponentModel.DataAnnotations;

namespace Conta.Models
{
    public class ContaBancaria
    {
        [Key]
        public int NumeroConta { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public decimal Saldo { get; set; }
        public List<Transacao>? Extrato { get; set; }
    }
}