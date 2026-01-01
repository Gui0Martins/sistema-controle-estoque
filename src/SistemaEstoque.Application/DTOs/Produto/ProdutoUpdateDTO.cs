using System;

namespace SistemaEstoque.Application.DTOs.Produto
{
    public class ProdutoUpdateDTO
    {
        // Note: Incluí o Id aqui para identificar qual produto será atualizado
        public Guid Id { get; set; }
        public Guid CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Sku { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeMinima { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
