using System;

namespace SistemaEstoque.Application.DTOs.Categoria
{
    public class CategoriaResponseDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativa { get; set; }
    }
}
