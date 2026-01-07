using System;
using SistemaEstoque.Application.DTOs.Movimentacao;

namespace SistemaEstoque.Application.Interfaces
{
    public interface IMovimentacaoService
    {
        Task<MovimentacaoResponseDTO> Create(MovimentacaoCreateDTO dto);
        Task<MovimentacaoResponseDTO?> GetById(Guid id);
        Task<List<MovimentacaoResponseDTO>> GetAll();
        Task<List<MovimentacaoResponseDTO>> GetByProdutoId(Guid produtoId);
        Task<List<MovimentacaoResponseDTO>> GetByCategoriaId(Guid categoriaId);
        Task<List<MovimentacaoResponseDTO>> GetByDateRange(DateTime startDate, DateTime endDate);
        Task<MovimentacaoResponseDTO> Update(MovimentacaoUpdateDTO dto);
        Task<bool> Delete(Guid id);
    }
}
