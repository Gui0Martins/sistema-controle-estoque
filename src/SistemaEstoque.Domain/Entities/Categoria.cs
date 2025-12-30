using System;
using System.Collections;

namespace SistemaEstoque.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Ativa { get; private set; }

        public Categoria(string nome, string descricao)
        {
            VerifiarEntradaNome(nome);

            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            DataCriacao = DateTime.Now;
            Ativa = true;
        }

        public void SetActive(bool ativa) { Ativa = ativa; }

        private void VerifiarEntradaNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da categoria não pode ser vazio.", nameof(nome));
        }

        override public string ToString()
        {
            return $"Categoria: {Nome}, \nDescrição: {Descricao}, \nAtiva: {Ativa}, \nCriada em: {DataCriacao}";
        }
    }
}


