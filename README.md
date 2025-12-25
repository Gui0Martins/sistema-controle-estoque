# Sistema de Controle de Estoque

Sistema web para gerenciamento de estoque de produtos, desenvolvido com ASP.NET Core Web API e Entity Framework Core. Projeto acadêmico focado em demonstrar competências em desenvolvimento de APIs RESTful, modelagem de banco de dados e arquitetura em camadas.

## 🎯 Objetivo

Fornecer uma solução simples e eficiente para controle de inventário, permitindo:
- Gestão de produtos, categorias e fornecedores
- Controle de entradas e saídas de estoque
- Alertas de estoque mínimo
- Relatórios de movimentações e valor em estoque

## 🛠️ Tecnologias Utilizadas

- **.NET 8.0** - Framework principal
- **ASP.NET Core Web API** - Desenvolvimento da API RESTful
- **Entity Framework Core** - ORM para acesso a dados
- **SQL Server / PostgreSQL** - Banco de dados relacional
- **AutoMapper** - Mapeamento entre DTOs e entidades
- **FluentValidation** - Validação de dados
- **Swagger/OpenAPI** - Documentação da API
- **Serilog** - Logging estruturado

## 📋 Funcionalidades

### Gestão de Produtos
- ✅ Cadastro, edição e exclusão de produtos
- ✅ Controle de estoque atual
- ✅ Configuração de estoque mínimo e máximo
- ✅ Código SKU único
- ✅ Vinculação com categorias e fornecedores

### Gestão de Categorias e Fornecedores
- ✅ CRUD completo de categorias
- ✅ CRUD completo de fornecedores
- ✅ Validação de CNPJ único

### Controle de Movimentações
- ✅ Registro de entradas (compras, devoluções)
- ✅ Registro de saídas (vendas, perdas)
- ✅ Histórico completo de movimentações
- ✅ Rastreamento de estoque anterior e atual
- ✅ Validação de estoque disponível

### Relatórios
- ✅ Produtos em estoque
- ✅ Produtos abaixo do estoque mínimo
- ✅ Valor total em estoque
- ✅ Histórico de movimentações por período
- ✅ Exportação em JSON/CSV

## 🏗️ Arquitetura

O projeto segue os princípios de **Clean Architecture** com separação em camadas:

```
├── API Layer (Presentation)
│   └── Controllers, Middlewares, Configuration
├── Application Layer
│   └── Services, DTOs, Validators, Mappings
├── Domain Layer
│   └── Entities, Interfaces, Enums, Business Rules
└── Infrastructure Layer
    └── Data Context, Repositories, Migrations
```

## 📦 Estrutura do Projeto

```
src/
├── SistemaEstoque.API/              # Camada de apresentação (Web API)
├── SistemaEstoque.Application/      # Lógica de aplicação e DTOs
├── SistemaEstoque.Domain/           # Entidades e regras de negócio
└── SistemaEstoque.Infrastructure/   # Acesso a dados e repositórios
```

## 🚀 Como Executar

### Pré-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server) ou [PostgreSQL](https://www.postgresql.org/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### Instalação

1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/sistema-controle-estoque.git
cd sistema-controle-estoque
```

2. Configure a connection string em `appsettings.json`
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=EstoqueDB;Trusted_Connection=True;"
}
```

3. Execute as migrations
```bash
cd src/SistemaEstoque.API
dotnet ef database update
```

4. Execute a aplicação
```bash
dotnet run
```

5. Acesse a documentação da API
```
https://localhost:5001/swagger
```

## 📚 Documentação

A documentação técnica completa está disponível em [`/docs/DOCUMENTATION.md`](./docs/DOCUMENTATION.md), incluindo:
- Requisitos funcionais e não-funcionais
- Diagramas de classes e banco de dados
- Casos de uso detalhados
- Endpoints da API
- Regras de negócio

## 🧪 Testes

```bash
# Executar todos os testes
dotnet test

# Executar com coverage
dotnet test /p:CollectCoverage=true
```

## 📝 Endpoints Principais

### Produtos
- `GET /api/produtos` - Lista produtos com paginação
- `POST /api/produtos` - Cadastra novo produto
- `PUT /api/produtos/{id}` - Atualiza produto
- `DELETE /api/produtos/{id}` - Remove produto

### Movimentações
- `POST /api/movimentacoes/entrada` - Registra entrada de estoque
- `POST /api/movimentacoes/saida` - Registra saída de estoque
- `GET /api/movimentacoes/produto/{id}` - Histórico de movimentações

### Relatórios
- `GET /api/relatorios/estoque-atual` - Estoque consolidado
- `GET /api/relatorios/estoque-baixo` - Produtos abaixo do mínimo

> Para a lista completa de endpoints, acesse `/swagger` após executar a aplicação.

## 🤝 Contribuindo

Este é um projeto acadêmico, mas sugestões são bem-vindas! Para contribuir:

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona MinhaFeature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## ✨ Autor

**Guilherme** - Estudante de Análise e Desenvolvimento de Sistemas - FATEC Taubaté

---

⭐ Se este projeto foi útil para você, considere dar uma estrela!
