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
            Verificacoes(nome);

            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = string.IsNullOrWhiteSpace(descricao) ? "Sem descrição" : descricao;
            DataCriacao = DateTime.Now;
            Ativa = true;
        }

        public void SetActive(bool ativa) { Ativa = ativa; }

        private void Verificacoes(string nome)
        {
            VerifiarEntradaNome(nome);
        }

        private void VerifiarEntradaNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da categoria não pode ser vazio.", nameof(nome));
        }
        public void AlterarNome(string novoNome)
        {
            // não posso usar a verificação do construtor pq lá lança exceção e aqui quero apenas ignorar
            if (string.IsNullOrWhiteSpace(novoNome)) return;
            Nome = novoNome;
        }

        public void AlterarDescricao(string novaDescricao)
        {
            if (string.IsNullOrWhiteSpace(novaDescricao)) return;
            Descricao = novaDescricao;
        }

        override public string ToString()
        {
            return $"Categoria: {Nome}, \nDescrição: {Descricao}, \nAtiva: {Ativa}, \nCriada em: {DataCriacao}";
        }
    }
}


