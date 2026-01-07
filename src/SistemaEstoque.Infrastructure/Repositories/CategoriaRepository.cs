using System;
using System.Threading.Tasks;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces;
using SistemaEstoque.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaEstoque.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SistemaEstoqueDbContext _context;

        public CategoriaRepository(SistemaEstoqueDbContext context)
        {
            _context = context;
        }

        public async Task Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null) 
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Categoria>> FindAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> FindByActive(bool isActive)
        {
            var categorias = await _context.Categorias
                .Where(c => c.Ativa == isActive)
                .ToListAsync();

            return categorias;
        }

        public async Task<IEnumerable<Categoria>> FindByName(string name)
        {
            return await _context.Categorias
                .Where(c => c.Nome.Contains(name))
                .ToListAsync();
        }

        public async Task<Categoria?> GetById(Guid id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }
    }
}
