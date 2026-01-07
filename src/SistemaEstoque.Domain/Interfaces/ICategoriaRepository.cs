using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces
{
	public interface ICategoriaRepository
	{
		Task<Categoria?> GetById(Guid id);
		Task Add(Categoria categoria);
		Task Update(Categoria categoria);
		Task Delete(Guid id);
		Task<IEnumerable<Categoria>> FindAll();
		Task<IEnumerable<Categoria>> FindByName(string name);
		Task<IEnumerable<Categoria>> FindByActive(bool isActive);
	}
}
