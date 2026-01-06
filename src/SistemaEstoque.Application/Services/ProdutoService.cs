using SistemaEstoque.Application.DTOs.Produto;
using SistemaEstoque.Application.Interfaces;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces;
using System;

namespace SistemaEstoque.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProdutoResponseDTO> Create(ProdutoCreateDTO dto)
        {
            var produto = new Produto(dto.Nome, dto.Descricao, dto.Sku, dto.QuantidadeMinima, dto.PrecoUnitario, dto.CategoriaId);

            await _repository.Add(produto);

            return ConvertParaDTO(produto);
        }

        public async Task<bool> Delete(Guid id)
        {
            var produto = await _repository.GetById(id);

            if (produto == null) return false;

            await _repository.Delete(produto.Id);

            return true;
        }

        public async Task<List<ProdutoResponseDTO>> GetAll()
        {
            var produtos = await _repository.FindAll();

            return produtos.Select(p => ConvertParaDTO(p)).ToList();
        }

        public async Task<ProdutoResponseDTO?> GetById(Guid id)
        {
            var produto = await _repository.GetById(id);

            if (produto == null) return null;

            return ConvertParaDTO(produto);
        }

        public async Task<ProdutoResponseDTO> AdicionarEstoque(Guid produtoId, ProdutoAdicionarEstoqueDTO dto)
        {
            var produto = await _repository.GetById(produtoId);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.AdicionarEstoque(dto.Quantidade);

            await _repository.Update(produto);

            return ConvertParaDTO(produto);
        }

        public async Task<ProdutoResponseDTO> RemoverEstoque(Guid produtoId, ProdutoRemoverEstoqueDTO dto)
        {
            var produto = await _repository.GetById(produtoId);   
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.RemoverEstoque(dto.Quantidade);

            await _repository.Update(produto);

            return ConvertParaDTO(produto);
        }

        public async Task<ProdutoResponseDTO> Update(ProdutoUpdateDTO dto)
        {
            var produto = await _repository.GetById(dto.Id);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.AtualizarDados(dto.Nome, dto.Descricao, dto.Sku, dto.QuantidadeMinima, dto.CategoriaId,  dto.PrecoUnitario);

            await _repository.Update(produto);

            return ConvertParaDTO(produto);
        }

        private ProdutoResponseDTO ConvertParaDTO(Produto produto)
        {
            return new ProdutoResponseDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Sku = produto.Sku,
                QuantidadeAtual = produto.QuantidadeAtual,
                QuantidadeMinima = produto.QuantidadeMinima,
                PrecoUnitario = produto.PrecoUnitario,
                CategoriaId = produto.CategoriaId,
                DataCriacao = produto.DataCriacao,
                Ativo = produto.Ativo,
                DataAtualizacao = produto.DataAtualizacao
            };
        }
    }
}
