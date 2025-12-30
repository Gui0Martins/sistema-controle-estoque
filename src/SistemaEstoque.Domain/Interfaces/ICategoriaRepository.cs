using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces
{
	public interface ICategoriaRepository
	{
		Categoria? GetById(Guid id);
		void Add(Categoria categoria);
		void Update(Categoria categoria);
		void Delete(Guid id);
		IEnumerable<Categoria> FindAll();
		IEnumerable<Categoria> FindByName(string name);
		IEnumerable<Categoria> FindByActive(bool isActive);
	}
}
