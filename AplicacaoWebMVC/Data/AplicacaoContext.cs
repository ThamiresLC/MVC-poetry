using AplicacaoWebMVC.Entities;
using Microsoft.EntityFrameworkCore;
using AplicacaoWebMVC.ViewModels;

namespace AplicacaoWebMVC.Data
{
    public class AplicacaoContext:DbContext
    {
        public AplicacaoContext(DbContextOptions<AplicacaoContext> options): base(options)   
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Poesia> Poesias { get; set; }

        //public DbSet<Autenticacao> Autenticacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Poetry;Data Source=.\\SQLEXPRESS");
        }

    
    }
}
