using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using teste.Models;

namespace teste.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<UF> UF { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
    }
}
