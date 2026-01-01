using System;

namespace SistemaEstoque.Application.DTOs.Movimentacao
{
    public class MovimentacaoUpdateDTO
    {
        // Qualquer mudanca maior na movimentacao não fará sentido, sendo mais plausivel criar uma nova movimentacao
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}
