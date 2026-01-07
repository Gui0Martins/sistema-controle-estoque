using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetById(Guid id);
        Task<Usuario?> GetByEmail(string email);
        Task Add(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(Guid id);
        Task<IEnumerable<Usuario>> FindAll();
        Task<IEnumerable<Usuario>> FindByName(string name);
        Task<IEnumerable<Usuario>> FindByActive(bool isActive);
        Task<bool> IsEmailUnique(string email);
    }
}
