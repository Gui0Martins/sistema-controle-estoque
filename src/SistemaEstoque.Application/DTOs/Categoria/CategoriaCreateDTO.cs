using System;

namespace SistemaEstoque.Application.DTOs.Categoria
{
    // Faz referencia a criação de uma nova categoria no sistema de estoque
    public class CategoriaCreateDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
