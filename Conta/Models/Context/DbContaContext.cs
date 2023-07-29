using Microsoft.EntityFrameworkCore;

namespace Conta.Models.Context
{
    public class DbContaContext : DbContext
    {
        public DbContaContext(DbContextOptions<DbContaContext> options) : base(options)
        {
        }

        public DbSet<ContaBancaria> ContaBancaria { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

    }
}