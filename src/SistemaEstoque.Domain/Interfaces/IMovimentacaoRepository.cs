using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Interfaces
{
    public interface IMovimentacaoRepository
    {
        Task<Movimentacao?> GetById(Guid id);
        Task Add(Movimentacao movimentacao);
        Task Update(Movimentacao movimentacao);
        Task Delete(Guid id);
        Task<IEnumerable<Movimentacao>> FindAll();
        Task<IEnumerable<Movimentacao>> FindByProdutoId(Guid produtoId);
        Task<IEnumerable<Movimentacao>> FindByCategoriaId(Guid categoriaId);
        Task<IEnumerable<Movimentacao>> FindByUsuarioId(Guid usuarioId);
        Task<IEnumerable<Movimentacao>> FindByTipo(TipoMovimentacao tipo);
        Task<IEnumerable<Movimentacao>> FindByDateRange(DateTime startDate, DateTime endDate);
    }
}
