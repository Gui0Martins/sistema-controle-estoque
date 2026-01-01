using System;

namespace SistemaEstoque.Application.DTOs.Categoria
{
    public class CategoriaUpdateDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
