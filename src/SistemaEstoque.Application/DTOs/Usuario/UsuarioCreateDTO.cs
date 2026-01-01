using System;

namespace SistemaEstoque.Application.DTOs.Usuario
{
    public class UsuarioCreateDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
