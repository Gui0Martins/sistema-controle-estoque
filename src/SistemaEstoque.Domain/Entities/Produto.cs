using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaEstoque.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Sku { get; private set; } // Stock Keeping Unit. É tipo um "código do produto" que as empresas usam. Exemplo: NOTEBOOK-DELL-001
        public int QuantidadeAtual { get; private set; }
        public int QuantidadeMinima { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public Guid CategoriaID { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataAtualizacao { get; private set; }

        public Produto(string nome, string descricao, string sku, int quantidadeMinima, decimal precoUnitario, Categoria categoria)
        {
            ValidarEntradas(nome, sku, precoUnitario, quantidadeMinima);

            Id = Guid.NewGuid();
            Nome = nome;
            Sku = sku;
            QuantidadeAtual = 0;
            QuantidadeMinima = quantidadeMinima;
            PrecoUnitario = precoUnitario;
            CategoriaID = categoria.Id;
            DataCriacao = DateTime.Now;
            Ativo = true;
            DataAtualizacao = DateTime.Now;
            
            if (string.IsNullOrWhiteSpace(descricao))
                Descricao = "Sem descrição";
            else
                Descricao = descricao;
        }

        public void SetActive(bool ativo)
        {
            Ativo = ativo;
            DataAtualizacao = DateTime.Now;
        }

        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade a ser adicionada deve ser maior que zero.", nameof(quantidade));
            QuantidadeAtual += quantidade;
            DataAtualizacao = DateTime.Now;
        }

        public void RemoverEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade a ser removida deve ser maior que zero.", nameof(quantidade));
            if (quantidade > QuantidadeAtual)
                throw new InvalidOperationException("Quantidade a ser removida é maior que o estoque atual.");
            QuantidadeAtual -= quantidade;
            DataAtualizacao = DateTime.Now;
        }

        private void ValidarEntradas(string nome, string sku, decimal precoUnitario, int quantidadeMinima)
        {
            VerificarEntradaNome(nome);
            VerificarEntradaSku(sku);
            VerificarEntradaPrecoUnitario(precoUnitario);
            VerificarEntradaQuantidadeMinima(quantidadeMinima);
        }

        private void VerificarEntradaNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto não pode ser vazio.", nameof(nome));
        }

        private void VerificarEntradaSku(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
                throw new ArgumentException("SKU do produto não pode ser vazio.", nameof(sku));
        }

        private void VerificarEntradaPrecoUnitario(decimal precoUnitario)
        {
            if (precoUnitario <= 0)
                throw new ArgumentException("Preço unitário do produto deve ser maior que zero.", nameof(precoUnitario));
        }

        private void VerificarEntradaQuantidadeMinima(int quantidadeMinima)
        {
            if (quantidadeMinima < 0)
                throw new ArgumentException("Quantidade mínima do produto não pode ser negativa.", nameof(quantidadeMinima));
        }
    }
}
