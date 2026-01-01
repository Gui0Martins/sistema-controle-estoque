using System;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Application.DTOs.Movimentacao
{
    public class MovimentacaoResponseDTO
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public string ProdutoSku { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public int Quantidade { get; set; }
        public Guid UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioEmail { get; set; }
        public string Observacao { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
