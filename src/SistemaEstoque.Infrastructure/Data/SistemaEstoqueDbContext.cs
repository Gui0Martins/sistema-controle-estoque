using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using System;

namespace SistemaEstoque.Infrastructure.Data
{
    public class SistemaEstoqueDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; } // Diz ao EF Core "crie uma tabela chamada Categorias baseada na classe Categoria". Cada DbSet vira uma tabela no banco.
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        public SistemaEstoqueDbContext(DbContextOptions<SistemaEstoqueDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(entity =>
            {
                // chave primaria
                entity.HasKey(c => c.Id);
                // campo nome obrigatorio e tamanho maximo
                entity.Property(c => c.Nome).IsRequired().HasMaxLength(100);
                // campo descricao
                entity.Property(c => c.Descricao).HasMaxLength(500);

                // indice unico no nome
                entity.HasIndex(c => c.Nome).IsUnique();
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nome).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Descricao).HasMaxLength(1000);

                entity.Property(p => p.Sku).IsRequired().HasMaxLength(50);
                entity.HasIndex(p => p.Sku).IsUnique();

                entity.Property(p => p.PrecoUnitario).IsRequired().HasColumnType("decimal(18,2)");

                // relacionamento com categoria
                entity.HasOne<Categoria>()
                      .WithMany()
                      .HasForeignKey(p => p.CategoriaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Nome).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(200);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.SenhaHash).IsRequired();
            });

            modelBuilder.Entity<Movimentacao>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Observacao).HasMaxLength(500);
                
                // relacionamento com produto
                entity.HasOne<Produto>()
                      .WithMany()
                      .HasForeignKey(m => m.ProdutoId)
                      .OnDelete(DeleteBehavior.Restrict);

                // relacionamento com usuario
                entity.HasOne<Usuario>()
                      .WithMany()
                      .HasForeignKey(m => m.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
