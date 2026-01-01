using System;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Application.DTOs.Movimentacao
{
    public class MovimentacaoCreateDTO
    {
        // O id do usuario será obtido a partir do contexto da aplicação (usuário autenticado)
        public Guid ProdutoId { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
        public DateTime DataMovimentacao { get; set; }

    }
}
