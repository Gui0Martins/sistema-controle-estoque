using System;

namespace SistemaEstoque.Application.DTOs.Usuario
{
    public class UsuarioResponseDTO
    {
        // Senha é um dado sensível e não deve ser exposta em respostas.
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
