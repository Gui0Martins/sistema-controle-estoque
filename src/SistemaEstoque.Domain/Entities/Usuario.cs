using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaEstoque.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; private set; }

        //==========================================//
        private const int tamanhoMinimoSenha = 8;

        public Usuario(string nome, string email, string senhaHash)
        {
            ValidarEntradas(nome, email, senhaHash);

            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Ativo = true;
            DataCriacao = DateTime.Now;
        }

        public void SetActive(bool ativo)
        {
            Ativo = ativo;
        }

        public void AlterarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("Nome do usuário não pode ser vazio.", nameof(novoNome));
            Nome = novoNome;
        }

        public void AlterarEmail(string novoEmail)
        {
            VerificarEntradaEmail(novoEmail);
            Email = novoEmail;
        }

        public void AlterarSenha(string novaSenhaHash)
        {
            VerificarEntradaSenha(novaSenhaHash);
            SenhaHash = novaSenhaHash;
        }   

        private void ValidarEntradas(string nome, string email, string senhaHash)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do usuário não pode ser vazio.", nameof(nome));

            VerificarEntradaEmail(email);
            VerificarEntradaSenha(senhaHash);
        }

        private void VerificarEntradaSenha(string senhaHash)
        {
            if (string.IsNullOrWhiteSpace(senhaHash))
                throw new ArgumentException("Senha do usuário não pode ser vazia.", nameof(senhaHash));
            if (senhaHash.Length < tamanhoMinimoSenha)
                throw new ArgumentException($"Senha do usuário deve ter no mínimo {tamanhoMinimoSenha} caracteres.", nameof(senhaHash));
        }

        private void VerificarEntradaEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email do usuário não pode ser vazio.", nameof(email));
            // Aqui você pode adicionar mais validações de email, como formato, domínio, etc.
        }
    }
}
