using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Territorio> Territorios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Acordo> Acordos { get; set; }
        // public DbSet<Pedido> Pedidos { get; set; }
        // public DbSet<Profile> Profiles { get; set; }
        // public DbSet<Produtor> Produtores { get; set; }
        // public DbSet<Atualizacao> Atualizacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<TerritorioProduto>()
                .HasKey(tp => new { tp.TerritorioId, tp.ProdutoId });
            builder.Entity<TerritorioProduto>()
                .HasOne(tp => tp.Territorio)
                .WithMany(tp => tp.Produtos)
                .HasForeignKey(tp => tp.ProdutoId);
            builder.Entity<TerritorioProduto>()
                .HasOne(tp => tp.Produto)
                .WithMany(tp => tp.Territorios)
                .HasForeignKey(tp => tp.TerritorioId);
            
            // builder.Entity<Atualizacao>()
            //     .HasKey(a => new {a.Versao});
        
        }

    }
}