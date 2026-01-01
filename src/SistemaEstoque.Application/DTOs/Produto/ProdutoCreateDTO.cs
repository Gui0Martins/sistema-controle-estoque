using System;

namespace SistemaEstoque.Application.DTOs.Produto
{
    public class ProdutoCreateDTO
    {
        public Guid CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Sku { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeMinima { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
