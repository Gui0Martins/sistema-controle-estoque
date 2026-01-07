using System;
using System.Threading.Tasks;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces;
using SistemaEstoque.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaEstoque.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemaEstoqueDbContext _context;

        public UsuarioRepository(SistemaEstoqueDbContext context)
        {
            _context = context;
        }

        public async Task Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Usuario>> FindAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> FindByActive(bool isActive)
        {
            var usuarios = await _context.Usuarios
                .Where(u => u.Ativo == isActive)
                .ToListAsync();

            return usuarios;
        }

        public async Task<IEnumerable<Usuario>> FindByName(string name)
        {
             var usuarios = await _context.Usuarios
                .Where(u => u.Nome.Contains(name))
                .ToListAsync();

            return usuarios;
        }

        public async Task<Usuario?> GetByEmail(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario?> GetById(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            return !await _context.Usuarios.AnyAsync(u => u.Email == email);
            // Se usa ! para retornar true se nenhum usuário com o email existir
            // Essa estrutura retorna um booleano indicando se o email é único
        }

        public async Task Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
