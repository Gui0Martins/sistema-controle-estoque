using System;
using SistemaEstoque.Application.DTOs.Usuario;

namespace SistemaEstoque.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponseDTO> Create(UsuarioCreateDTO dto); 
        Task<UsuarioResponseDTO?> GetById(Guid id);
        Task<List<UsuarioResponseDTO>> GetAll();
        Task<UsuarioResponseDTO> Update(UsuarioUpdateDTO dto);
        Task<UsuarioResponseDTO> UpdateSenha(Guid usuarioId, UsuarioUpdateSenhaDTO dto);
        Task<bool> Delete(Guid id);
    }
}
