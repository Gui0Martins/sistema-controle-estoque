# Sistema de Controle de Estoque

API de controle de estoque desenvolvida em ASP.NET Core com arquitetura em camadas. Este projeto foi criado com foco acadêmico e de portfólio, priorizando organização de código, modelagem de domínio e operações básicas de estoque.

> **Status atual:** projeto em desenvolvimento. A base de domínio, aplicação e infraestrutura já existe, e o objetivo desta versão é evoluir o sistema para uma entrega **enxuta, funcional e demonstrável**.

---

## Objetivo do projeto

Este projeto busca demonstrar, de forma prática:

- modelagem de entidades e regras de negócio;
- separação por camadas;
- uso de Entity Framework Core com banco relacional;
- construção de uma API REST para operações básicas de estoque;
- organização suficiente para servir como projeto de portfólio.

A meta desta versão **não** é ser um ERP completo. O foco é entregar um sistema pequeno, coerente e funcional.

---

## Escopo da versão de portfólio

A versão que este repositório pretende entregar como portfólio contempla:

- cadastro de categorias;
- cadastro de produtos;
- cadastro de usuários;
- consulta de produtos e categorias;
- registro de entrada de estoque;
- registro de saída de estoque;
- atualização automática do estoque do produto;
- histórico de movimentações;
- documentação da API via Swagger.

### Regras centrais da versão de portfólio

- cada produto pertence a uma categoria;
- cada movimentação está vinculada a um produto e a um usuário;
- entrada de estoque aumenta a quantidade disponível;
- saída de estoque reduz a quantidade disponível;
- o sistema não deve permitir saída maior do que o estoque disponível;
- SKU deve ser único;
- e-mail de usuário deve ser único.

---

## Funcionalidades já estruturadas no código

O projeto já possui, em diferentes níveis de maturidade:

- entidades de domínio (`Categoria`, `Produto`, `Usuario`, `Movimentacao`);
- DTOs de entrada e saída;
- interfaces de serviços e repositórios;
- implementações iniciais de serviços;
- `DbContext` e repositórios com Entity Framework Core;
- organização da solução em camadas.

---

## Funcionalidades previstas para evolução futura

Os itens abaixo fazem parte de uma visão mais ampla do sistema, mas **não são prioridade para a versão enxuta de portfólio**:

- autenticação e autorização;
- gestão de fornecedores;
- relatórios avançados;
- exportação de dados;
- paginação e filtros mais completos;
- logging estruturado;
- validação formal com FluentValidation;
- AutoMapper;
- testes automatizados;
- deploy e conteinerização.

---

## Tecnologias utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **Swagger / OpenAPI**
- **C#**

> Observação: algumas tecnologias citadas em versões anteriores da documentação, como AutoMapper, FluentValidation e Serilog, foram tratadas como ideias de evolução e não devem ser consideradas como implementadas até estarem presentes no código.

---

## Arquitetura do projeto

A solução foi organizada em camadas:

```text
src/
├── SistemaEstoque.API/              # Camada de apresentação (Web API)
├── SistemaEstoque.Application/      # Serviços de aplicação e DTOs
├── SistemaEstoque.Domain/           # Entidades, enums e regras de negócio
└── SistemaEstoque.Infrastructure/   # DbContext e repositórios
```

### Papel de cada camada

- **Domain**: representa as entidades principais e as regras centrais do sistema.
- **Application**: coordena operações da aplicação usando DTOs, serviços e interfaces.
- **Infrastructure**: faz o acesso a dados com EF Core e implementa os repositórios.
- **API**: expõe os endpoints HTTP e concentra a configuração da aplicação.

---

## Estado atual do projeto

Com base na análise do código atual, o projeto já possui uma boa base estrutural, mas ainda precisa de integração para ficar funcional como API de portfólio.

### O que já existe

- modelagem inicial do domínio;
- camada de aplicação com DTOs, interfaces e serviços;
- camada de infraestrutura com `DbContext` e repositórios;
- documentação técnica inicial.

### O que ainda precisa ser concluído

- criação dos controllers;
- configuração completa da API;
- injeção de dependência;
- configuração da conexão com banco;
- migrations;
- integração consistente entre movimentação e atualização de estoque;
- revisão das referências entre projetos;
- limpeza do repositório e ajuste do `.gitignore`.

---

## Como executar

> **Importante:** este passo a passo descreve a forma esperada de execução da versão funcional do projeto. Se o repositório ainda estiver em fase intermediária, alguns passos podem depender de implementações pendentes.

### Pré-requisitos

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 ou VS Code

### Passos esperados

1. Clonar o repositório.
2. Ajustar a connection string no `appsettings.json` da API.
3. Executar as migrations.
4. Rodar a aplicação.
5. Acessar o Swagger para testar os endpoints.

Exemplo de connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SistemaEstoqueDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Comandos esperados:

```bash
dotnet ef database update
dotnet run
```

---

## Estrutura mínima esperada de endpoints

A versão de portfólio deve expor, pelo menos, endpoints para:

- categorias;
- produtos;
- usuários;
- movimentações.

Fluxo mínimo de demonstração esperado:

1. criar categoria;
2. criar produto vinculado à categoria;
3. cadastrar usuário;
4. registrar entrada de estoque;
5. registrar saída de estoque;
6. consultar produto com estoque atualizado;
7. consultar histórico de movimentações.

---

## Documentação

A documentação técnica principal está em:

- [`docs/Sistema-Controle-Estoque-Documentacao.md`](./docs/Sistema-Controle-Estoque-Documentacao.md)

Também foi criada uma checklist prática para guiar a conclusão da versão de portfólio:

- [`docs/Checklist-Versao-Portfolio.md`](./docs/Checklist-Versao-Portfolio.md)

---

## Observações sobre o repositório

Durante a análise, foi identificado que o projeto contém arquivos de ambiente do Visual Studio e de compilação. Isso provavelmente ocorreu porque o arquivo de ignore está nomeado como `gitignore`, e não como `.gitignore`.

Antes de publicar o projeto como portfólio, é recomendado:

- renomear `gitignore` para `.gitignore`;
- remover `.vs`, `bin` e `obj` do versionamento;
- revisar o README para manter o retrato fiel do estado do projeto.

---

## Autor

**Guilherme Martins**  
Estudante de Análise e Desenvolvimento de Sistemas  
Projeto acadêmico com foco em portfólio backend
