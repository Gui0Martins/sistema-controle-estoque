using SistemaEstoque.Application.DTOs.Usuario;
using SistemaEstoque.Application.Interfaces;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces;
using System.Linq;
using System;

namespace SistemaEstoque.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<UsuarioResponseDTO> Create(UsuarioCreateDTO dto)
        {
            var usuario = new Usuario(dto.Nome, dto.Email, dto.Senha);

            await _repository.Add(usuario);

            return ConverterParaDTO(usuario);
        }

        public async Task<bool> Delete(Guid id)
        {
            var usuario = await _repository.GetById(id);
            if (usuario == null) return false;

            await _repository.Delete(usuario.Id);

            return true;
        }

        public async Task<List<UsuarioResponseDTO>> GetAll()
        {
            var usuarios = await _repository.FindAll();
            return usuarios.Select(c  => ConverterParaDTO(c)).ToList();
        }

        public async Task<UsuarioResponseDTO?> GetById(Guid id)
        {
            var usuario = await _repository.GetById(id);
            if (usuario == null) return null;

            return ConverterParaDTO(usuario);
        }

        public async Task<UsuarioResponseDTO> Update(UsuarioUpdateDTO dto)
        {
            var usuario = await _repository.GetById(dto.Id);
            if (usuario == null) throw new Exception("Usuário não encontrado.");

            usuario.AlterarNome(dto.Nome);
            usuario.AlterarEmail(dto.Email);

            await _repository.Update(usuario);

            return ConverterParaDTO(usuario);
        }

        public async Task<UsuarioResponseDTO> UpdateSenha(Guid usuarioId, UsuarioUpdateSenhaDTO dto)
        {
            var usuario = await _repository.GetById(usuarioId);
            if (usuario == null) throw new Exception("Usuário não encontrado.");

            if (usuario.SenhaHash != dto.SenhaAtual)
                throw new Exception("Senha atual incorreta.");

            if (dto.NovaSenha != dto.ConfirmacaoSenha)
                throw new Exception("As senhas não coincidem.");

            usuario.AlterarSenha(dto.NovaSenha);

            await _repository.Update(usuario);

            return ConverterParaDTO(usuario);
        }

        private UsuarioResponseDTO ConverterParaDTO(Usuario usuario)
        {
            return new UsuarioResponseDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Ativo = usuario.Ativo,
                DataCriacao = usuario.DataCriacao
            };
        }
    }
}
