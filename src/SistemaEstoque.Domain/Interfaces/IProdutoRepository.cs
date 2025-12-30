using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Produto? GetById(Guid id);
        Produto? GetBySku(string sku);
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(Guid id);
        IEnumerable<Produto> FindAll();
        IEnumerable<Produto> FindByName(string name);
        IEnumerable<Produto> FindByCategory(Guid categoryId);
        IEnumerable<Produto> FindByActive(bool isActive);
    }
}
