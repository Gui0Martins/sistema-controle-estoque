using System;
namespace SistemaEstoque.Application.DTOs.Usuario
{
    public class UsuarioUpdateDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        //Sobre a questão do email, fica a duvida se seria igual ao caso da senha, que possue seu dto de criação separado do de atualização.
    }
}
