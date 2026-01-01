using SistemaEstoque.Application.DTOs.Categoria;
using System;

namespace SistemaEstoque.Application.DTOs.Produto
{
    public class ProdutoResponseDTO
    {
        // Aparece todas as informações do produto
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Sku { get; set; }
        public int QuantidadeAtual { get; set; }
        public int QuantidadeMinima { get; set; }
        public decimal PrecoUnitario { get; set; }
        public CategoriaResponseDTO Categoria { get; set; }
        public Guid CategoriaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
