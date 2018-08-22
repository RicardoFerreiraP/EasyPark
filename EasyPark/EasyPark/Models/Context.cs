using System.Data.Entity;

namespace EasyPark.Models
{
    public class Context: DbContext
    {
        public Context() : base("DbEasyPark") { }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Funcionario> Funcionarios{ get; set; }

        public DbSet<Automovel> Automoveis { get; set; }

        public DbSet<Vaga> Vagas { get; set; }
    }
}