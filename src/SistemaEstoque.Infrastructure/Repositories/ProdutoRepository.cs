using System;
using System.Threading.Tasks;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces;
using SistemaEstoque.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaEstoque.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SistemaEstoqueDbContext _context;

        public ProdutoRepository(SistemaEstoqueDbContext context)
        {
            _context = context;
        }
        public async Task Add(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Produto>> FindAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<IEnumerable<Produto>> FindByActive(bool isActive)
        {
            return await _context.Produtos
                .Where(p => p.Ativo == isActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> FindByCategory(Guid categoryId)
        {
            return await _context.Produtos
                .Where(p => p.CategoriaId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> FindByName(string name)
        {
            return await _context.Produtos
                .Where(p => p.Nome.Contains(name))
                .ToListAsync();
        }

        public async Task<Produto?> GetById(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto?> GetBySku(string sku)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Sku == sku);
        }

        public async Task Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
