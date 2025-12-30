using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario? GetById(Guid id);
        Usuario? GetByEmail(string email);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Guid id);
        IEnumerable<Usuario> FindAll();
        IEnumerable<Usuario> FindByName(string name);
        IEnumerable<Usuario> FindByActive(bool isActive);
        bool IsEmailUnique(string email);
    }
}
