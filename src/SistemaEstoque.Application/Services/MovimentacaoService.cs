using SistemaEstoque.Application.DTOs.Movimentacao;
using SistemaEstoque.Application.Interfaces;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces;
using System.Linq;
using System;

namespace SistemaEstoque.Application.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoRepository _repository;

        public MovimentacaoService(IMovimentacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovimentacaoResponseDTO> Create(MovimentacaoCreateDTO dto)
        {
            var movimentacao = new Movimentacao(dto.ProdutoId, dto.TipoMovimentacao, dto.Quantidade, dto.UsuarioId,
                dto.Observacao, dto.DataMovimentacao);

            await _repository.Add(movimentacao);

            return ConverterParaDTO(movimentacao);
        }

        public async Task<bool> Delete(Guid id)
        {
            var movimentacao = await _repository.GetById(id);
            if (movimentacao == null) return false;

            await _repository.Delete(movimentacao.Id);

            return true;
        }

        public async Task<List<MovimentacaoResponseDTO>> GetAll()
        {
            var movimentacoes = await _repository.FindAll();
            return movimentacoes.Select(c => ConverterParaDTO(c)).ToList();
        }

        public async Task<List<MovimentacaoResponseDTO>> GetByCategoriaId(Guid categoriaId)
        {
            var movimentacoes = await _repository.FindByCategoriaId(categoriaId);
            return movimentacoes.Select(c => ConverterParaDTO(c)).ToList();
        }

        public async Task<List<MovimentacaoResponseDTO>> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var movimentacoes = await _repository.FindByDateRange(startDate, endDate);
            return movimentacoes.Select(c => ConverterParaDTO(c)).ToList();
        }

        public async Task<MovimentacaoResponseDTO?> GetById(Guid id)
        {
            var movimentacao = await _repository.GetById(id);
            if (movimentacao == null) return null;
            return ConverterParaDTO(movimentacao);
        }

        public async Task<List<MovimentacaoResponseDTO>> GetByProdutoId(Guid produtoId)
        {
            var movimentacoes = await _repository.FindByProdutoId(produtoId);
            return movimentacoes.Select(c => ConverterParaDTO(c)).ToList();
        }

        public async Task<MovimentacaoResponseDTO> Update(MovimentacaoUpdateDTO dto)
        {
            var movimentacao = await _repository.GetById(dto.Id);
            if (movimentacao == null) throw new Exception("Movimentação não encontrada.");

            movimentacao.AtualizarDados(dto.Quantidade, dto.Observacao, dto.DataMovimentacao);

            await _repository.Update(movimentacao);

            return ConverterParaDTO(movimentacao);
        }

        private MovimentacaoResponseDTO ConverterParaDTO(Movimentacao movimentacao)
        {
            return new MovimentacaoResponseDTO
            {
                Id = movimentacao.Id,
                ProdutoId = movimentacao.ProdutoId,
                TipoMovimentacao = movimentacao.TipoMovimentacao,
                Quantidade = movimentacao.Quantidade,
                UsuarioId = movimentacao.UsuarioId,
                Observacao = movimentacao.Observacao,
                DataMovimentacao = movimentacao.DataMovimentacao,
                DataRegistro = movimentacao.DataRegistro
            };
        }
    }
}
