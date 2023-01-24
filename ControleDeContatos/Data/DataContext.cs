using System.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ControleDeContatos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
            public DbSet<ContatoModel> Contato { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=XPS13PLUS_CIRO\SQLEXPRESS; Initial Catalog=DB_SistemaContatos; User Id=sa; password=123456; TrustServerCertificate= True");
        }
        
        
    }
    
}
