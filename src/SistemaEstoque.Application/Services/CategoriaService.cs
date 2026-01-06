using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaEstoque.Application.DTOs.Categoria;
using SistemaEstoque.Application.Interfaces;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces;

namespace SistemaEstoque.Application.Services
{
    public class CategoriaService : Interfaces.ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoriaResponseDTO> Create(CategoriaCreateDTO dto)
        {
            var categoria = new Categoria(dto.Nome, dto.Descricao);

            await _repository.Add(categoria);

            return ConverterParaDTO(categoria);
        }
        public async Task<CategoriaResponseDTO> Update(CategoriaUpdateDTO dto)
        {
            var categoria = await _repository.GetById(dto.Id);

            if (categoria == null) throw new Exception($"Categoria com ID {dto.Id} não encontrada");

            categoria.AlterarNome(dto.Nome);
            categoria.AlterarDescricao(dto.Descricao);

            await _repository.Update(categoria);

            return ConverterParaDTO(categoria);
        }
        
        public async Task<bool> Delete(Guid id)
        {
            var categoria = await _repository.GetById(id);
            
            if (categoria == null) return false;

            await _repository.Delete(id);

            return true;
        }

        public async Task<List<CategoriaResponseDTO>> GetAll()
        {
            var categorias = await _repository.FindAll();

            return categorias.Select(c => ConverterParaDTO(c)).ToList();

            /*
             * // Equivale a:
                var lista = new List<CategoriaResponseDTO>();
                foreach (var c in categorias)
                {
                    lista.Add(ConverterParaDTO(c));
                }
                return lista;
            */
        }

        public async Task<CategoriaResponseDTO?> GetById(Guid id)
        {
            var categoria = await _repository.GetById(id);

            if (categoria == null) return null;

            return ConverterParaDTO(categoria);
        }

        private CategoriaResponseDTO ConverterParaDTO(Categoria categoria)
        {
            return new CategoriaResponseDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Descricao = categoria.Descricao,
                DataCriacao = categoria.DataCriacao,
                Ativa = categoria.Ativa
            };
        }
    }
}
