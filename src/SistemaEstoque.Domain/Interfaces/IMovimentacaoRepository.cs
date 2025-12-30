using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces
{
    public interface IMovimentacaoRepository
    {
        Movimentacao? GetById(Guid id);
        void Add(Movimentacao movimentacao);
        void Update(Movimentacao movimentacao);
        void Delete(Guid id);
        IEnumerable<Movimentacao> FindAll();
        IEnumerable<Movimentacao> FindByProdutoId(Guid produtoId);
        IEnumerable<Movimentacao> FindByUsuarioId(Guid usuarioId);
        IEnumerable<Movimentacao> FindByTipo(TipoMovimentacao tipo);
        IEnumerable<Movimentacao> FindByDateRange(DateTime startDate, DateTime endDate);
    }
}
