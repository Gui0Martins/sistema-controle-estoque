using System;
using SistemaEstoque.Application.DTOs.Produto;

namespace SistemaEstoque.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoResponseDTO> Create(ProdutoCreateDTO dto); 
        Task<ProdutoResponseDTO?> GetById(Guid id);
        Task<List<ProdutoResponseDTO>> GetAll();
        Task<ProdutoResponseDTO> Update(ProdutoUpdateDTO dto);
        Task<ProdutoResponseDTO> AdicionarEstoque(Guid produtoId, ProdutoAdicionarEstoqueDTO dto);
        Task<ProdutoResponseDTO> RemoverEstoque(Guid produtoId, ProdutoRemoverEstoqueDTO dto);
        Task<bool> Delete(Guid id);
    }
}
