using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto?> GetById(Guid id);
        Task<Produto?> GetBySku(string sku);
        Task Add(Produto produto);
        Task Update(Produto produto);
        Task Delete(Guid id);
        Task<IEnumerable<Produto>> FindAll();
        Task<IEnumerable<Produto>> FindByName(string name);
        Task<IEnumerable<Produto>> FindByCategory(Guid categoryId);
        Task<IEnumerable<Produto>> FindByActive(bool isActive);
    }
}
