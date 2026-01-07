using SistemaEstoque.Domain.Enums;
using System;

namespace SistemaEstoque.Domain.Entities
{
    public class Movimentacao
    {
        public Guid Id { get; private set; }
        public Guid ProdutoId { get; private set; }
        public TipoMovimentacao TipoMovimentacao { get; private set; }
        public int Quantidade { get; private set; }
        public Guid UsuarioId { get; private set; }
        public string Observacao { get; private set; }
        public DateTime DataMovimentacao { get; private set; }
        public DateTime DataRegistro { get; private set; }

        public Movimentacao(Guid produtoId, TipoMovimentacao tipoMovimentacao, int quantidade, Guid usuarioId, string observacao, DateTime dataMovimentacao)
        {
            Validacoes(quantidade, dataMovimentacao);
            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            TipoMovimentacao = tipoMovimentacao;
            Quantidade = quantidade;
            UsuarioId = usuarioId;
            DataRegistro = DateTime.Now;
            DataMovimentacao = dataMovimentacao;

            if (string.IsNullOrWhiteSpace(observacao))
                Observacao = "Sem observação";
            else
                Observacao = observacao;
        }

        private void Validacoes(int quantidade, DateTime dataMovimentacao)
        {
            ValidarEntradaQuantidade(quantidade);
            ValidarDataMovimentacao(dataMovimentacao);
        }

        private void ValidarEntradaQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.", nameof(quantidade));
        }        

        private void ValidarDataMovimentacao(DateTime dataMovimentacao)
        {
            if (dataMovimentacao > DateTime.Now)
                throw new ArgumentException("Data da movimentação não pode ser futura.", nameof(dataMovimentacao));
        }

        public void AtualizarDados(int quantidade, string observacao, DateTime dataMovimentacao)
        {
            Validacoes(quantidade, dataMovimentacao);
            Quantidade = quantidade;
            DataMovimentacao = dataMovimentacao;
            if (string.IsNullOrWhiteSpace(observacao))
                Observacao = "Sem observação";
            else
                Observacao = observacao;
        }
    }
}
