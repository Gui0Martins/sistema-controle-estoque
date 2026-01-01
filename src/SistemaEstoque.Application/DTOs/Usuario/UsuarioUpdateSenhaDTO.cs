using System;
namespace SistemaEstoque.Application.DTOs.Usuario
{
    public class UsuarioUpdateSenhaDTO
    {
        public string SenhaAtual { get; set; }
        public string NovaSenha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}
