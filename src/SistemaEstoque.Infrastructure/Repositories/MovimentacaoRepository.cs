using System;
using System.Threading.Tasks;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces;
using SistemaEstoque.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Infrastructure.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly SistemaEstoqueDbContext _context;

        public MovimentacaoRepository(SistemaEstoqueDbContext context)
        {
            _context = context;
        }

        public async Task Add(Movimentacao movimentacao)
        {
            _context.Movimentacoes.Add(movimentacao);   
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var movimentacao = await _context.Movimentacoes.FindAsync(id);
            if (movimentacao != null)
            {
                _context.Movimentacoes.Remove(movimentacao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Movimentacao>> FindAll()
        {
            return await _context.Movimentacoes.ToListAsync();
        }

        public async Task<IEnumerable<Movimentacao>> FindByCategoriaId(Guid categoriaId)
        {
            return await _context.Movimentacoes
                .Where(m => _context.Produtos.Any(p => p.Id == m.ProdutoId 
                && p.CategoriaId == categoriaId)).ToListAsync();
        }

        public async Task<IEnumerable<Movimentacao>> FindByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _context.Movimentacoes
                .Where(m => m.DataMovimentacao >= startDate && m.DataMovimentacao <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movimentacao>> FindByProdutoId(Guid produtoId)
        {
            return await _context.Movimentacoes
                .Where(m => m.ProdutoId == produtoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movimentacao>> FindByTipo(TipoMovimentacao tipo)
        {
            return await _context.Movimentacoes
                .Where(m => m.TipoMovimentacao == tipo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movimentacao>> FindByUsuarioId(Guid usuarioId)
        {
            return await _context.Movimentacoes
                .Where(m => m.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<Movimentacao?> GetById(Guid id)
        {
            return await _context.Movimentacoes.FindAsync(id);
        }

        public async Task Update(Movimentacao movimentacao)
        {
            _context.Movimentacoes.Update(movimentacao);
            await _context.SaveChangesAsync();
        }
    }
}
