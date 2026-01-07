using SistemaEstoque.Application.DTOs.Categoria;
using System;

namespace SistemaEstoque.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaResponseDTO> Create(CategoriaCreateDTO dto); // Retorna um Response como uma confirmação de criação, mais voltado para o usuario
        Task<CategoriaResponseDTO?> GetById(Guid id);
        Task<List<CategoriaResponseDTO>> GetAll();
        Task<CategoriaResponseDTO> Update(CategoriaUpdateDTO dto);
        Task<bool> Delete(Guid id);
    }
}
