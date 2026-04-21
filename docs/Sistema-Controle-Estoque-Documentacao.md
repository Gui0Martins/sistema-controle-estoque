# Sistema de Controle de Estoque - Documentação Técnica

## 1. Visão geral

O Sistema de Controle de Estoque é uma API backend desenvolvida com foco acadêmico e de portfólio. O projeto foi pensado para demonstrar uma implementação organizada de uma aplicação de estoque usando ASP.NET Core, Entity Framework Core e separação em camadas.

Esta documentação deve ser entendida em dois níveis:

1. **visão do sistema**: descreve a ideia geral e a direção arquitetural do projeto;
2. **escopo da versão de portfólio**: define o recorte mínimo que deve ficar funcional, demonstrável e coerente.

A prioridade atual é concluir uma versão **enxuta, funcional e apresentável**, sem tentar implementar todos os recursos imaginados originalmente.

---

## 2. Objetivo da versão de portfólio

A versão de portfólio deve entregar uma API capaz de demonstrar um fluxo real de controle de estoque, com foco em clareza estrutural e funcionamento consistente.

### Objetivos principais

- permitir cadastro de categorias, produtos e usuários;
- registrar entradas e saídas de estoque;
- manter o estoque do produto atualizado;
- manter histórico de movimentações;
- expor endpoints documentados via Swagger;
- servir como projeto demonstrável em GitHub/portfólio.

### O que esta versão não precisa priorizar

Os itens abaixo não são obrigatórios para a entrega enxuta de portfólio:

- fornecedores;
- autenticação e autorização;
- relatórios avançados;
- exportação CSV/JSON;
- dashboards;
- logging estruturado;
- FluentValidation;
- AutoMapper;
- testes automatizados;
- deploy.

Esses itens podem permanecer como evolução futura.

---

## 3. Escopo implementável da versão de portfólio

### 3.1 Módulos principais

#### Módulo de categorias
Responsável por cadastrar, listar, consultar, atualizar e remover categorias.

#### Módulo de produtos
Responsável por cadastrar produtos, consultar seus dados e manter a quantidade em estoque.

#### Módulo de usuários
Responsável por cadastrar usuários que serão associados às movimentações.

#### Módulo de movimentações
Responsável por registrar entradas e saídas de estoque, vinculando produto, usuário, quantidade, motivo e data.

---

## 4. Requisitos funcionais da versão de portfólio

### RF01 - Gestão de categorias
- cadastrar categoria;
- listar categorias;
- consultar categoria por id;
- atualizar categoria;
- remover categoria, desde que a regra definida pelo sistema permita.

### RF02 - Gestão de produtos
- cadastrar produto com nome, descrição, SKU, preço, categoria e estoque inicial opcional;
- listar produtos;
- consultar produto por id;
- atualizar dados do produto;
- remover produto;
- validar SKU único.

### RF03 - Gestão de usuários
- cadastrar usuário;
- listar usuários;
- consultar usuário por id;
- atualizar dados básicos;
- remover usuário;
- validar e-mail único.

### RF04 - Movimentações de estoque
- registrar entrada de estoque;
- registrar saída de estoque;
- vincular movimentação a um produto e a um usuário;
- registrar quantidade, motivo e data da movimentação;
- atualizar automaticamente o estoque do produto;
- consultar histórico de movimentações.

### RF05 - Regras de consistência
- não permitir quantidade menor ou igual a zero em movimentações;
- não permitir saída maior do que o estoque disponível;
- não permitir criar produto com categoria inexistente;
- não permitir movimentação com produto inexistente;
- não permitir movimentação com usuário inexistente.

---

## 5. Requisitos não funcionais priorizados

### RNF01 - Tecnologia
- backend em ASP.NET Core 8;
- persistência com Entity Framework Core;
- banco relacional SQL Server;
- documentação via Swagger/OpenAPI.

### RNF02 - Organização
- separação em camadas: API, Application, Domain e Infrastructure;
- uso de DTOs para entrada e saída;
- uso de repositórios e serviços;
- código legível e coerente com o tamanho do projeto.

### RNF03 - Persistência
- uso de migrations para criação/atualização do banco;
- chaves únicas em campos críticos, como SKU e e-mail;
- relacionamento consistente entre entidades principais.

### RNF04 - Apresentação de portfólio
- repositório limpo;
- README honesto e atualizado;
- instruções de execução compreensíveis;
- endpoints testáveis pelo Swagger.

---

## 6. Modelo de domínio da versão enxuta

### Entidades principais

#### Categoria
Representa a classificação do produto.

Campos esperados:
- Id
- Nome
- Descricao
- Ativa
- DataCriacao

#### Produto
Representa o item controlado em estoque.

Campos esperados:
- Id
- Nome
- Descricao
- Sku
- Preco
- QuantidadeEstoque
- CategoriaId
- Ativo
- DataCriacao
- DataAtualizacao

#### Usuario
Representa o responsável pelo registro das movimentações.

Campos esperados:
- Id
- Nome
- Email
- SenhaHash
- Ativo
- DataCriacao

#### Movimentacao
Representa um lançamento de entrada ou saída.

Campos esperados:
- Id
- ProdutoId
- UsuarioId
- TipoMovimentacao
- Quantidade
- Motivo
- DataMovimentacao
- DataCriacao

### Enum
#### TipoMovimentacao
- Entrada
- Saida

---

## 7. Regras de negócio centrais

Estas regras são o núcleo funcional da versão de portfólio e devem estar refletidas no código:

1. todo produto deve estar vinculado a uma categoria válida;
2. toda movimentação deve estar vinculada a um produto válido;
3. toda movimentação deve estar vinculada a um usuário válido;
4. entrada aumenta a quantidade em estoque;
5. saída reduz a quantidade em estoque;
6. saída não pode deixar o estoque negativo;
7. quantidade da movimentação deve ser maior que zero;
8. SKU deve ser único;
9. e-mail de usuário deve ser único.

---

## 8. Arquitetura da solução

### Estrutura desejada

```text
src/
├── SistemaEstoque.API/
├── SistemaEstoque.Application/
├── SistemaEstoque.Domain/
└── SistemaEstoque.Infrastructure/
```

### Papel das camadas

#### API
Responsável por:
- controllers;
- configuração da aplicação;
- injeção de dependência;
- exposição dos endpoints HTTP;
- Swagger.

#### Application
Responsável por:
- DTOs;
- interfaces de serviço;
- serviços de aplicação;
- coordenação das operações do sistema.

#### Domain
Responsável por:
- entidades;
- enums;
- regras de negócio centrais.

#### Infrastructure
Responsável por:
- `DbContext`;
- implementações dos repositórios;
- configurações de persistência;
- migrations.

### Direção de dependências recomendada

Para manter uma arquitetura coerente, a direção de referências entre projetos deve ficar, no mínimo, assim:

- `Domain`: sem depender de outros projetos da solução;
- `Application`: depende de `Domain`;
- `Infrastructure`: depende de `Domain`;
- `API`: depende de `Application` e `Infrastructure`.

> Observação importante: durante a análise do estado atual do projeto, foi identificado que a camada `Application` referencia a camada `API`. Isso deve ser corrigido para a versão de portfólio.

---

## 9. Fluxo funcional mínimo esperado

A demonstração mínima da API deve permitir o seguinte fluxo:

1. criar uma categoria;
2. criar um produto vinculado à categoria;
3. cadastrar um usuário;
4. registrar uma entrada de estoque para o produto;
5. registrar uma saída de estoque para o produto;
6. consultar o produto e confirmar que o estoque foi atualizado;
7. consultar as movimentações registradas.

Se esse fluxo estiver funcionando de ponta a ponta, o projeto já cumpre bem seu objetivo de portfólio.

---

## 10. Endpoints mínimos esperados

A versão de portfólio deve expor pelo menos os seguintes grupos de endpoints:

### Categorias
- `GET /api/categorias`
- `GET /api/categorias/{id}`
- `POST /api/categorias`
- `PUT /api/categorias/{id}`
- `DELETE /api/categorias/{id}`

### Produtos
- `GET /api/produtos`
- `GET /api/produtos/{id}`
- `POST /api/produtos`
- `PUT /api/produtos/{id}`
- `DELETE /api/produtos/{id}`

### Usuários
- `GET /api/usuarios`
- `GET /api/usuarios/{id}`
- `POST /api/usuarios`
- `PUT /api/usuarios/{id}`
- `DELETE /api/usuarios/{id}`

### Movimentações
- `GET /api/movimentacoes`
- `GET /api/movimentacoes/{id}`
- `POST /api/movimentacoes/entrada`
- `POST /api/movimentacoes/saida`

> Esses endpoints representam o recorte mínimo. Filtros, paginação e relatórios podem ser tratados como evolução futura.

---

## 11. Estado atual identificado na análise

Com base na análise estática do projeto enviado, foi identificado o seguinte cenário:

### Pontos já existentes
- estrutura da solução em camadas;
- entidades principais do domínio;
- DTOs e serviços iniciais;
- repositórios e `DbContext`;
- documentação inicial.

### Pontos ainda pendentes
- controllers;
- integração completa da API com Application e Infrastructure;
- configuração de banco na API;
- injeção de dependência;
- migrations;
- integração consistente entre movimentação e estoque;
- ajuste da direção das dependências entre projetos;
- limpeza do repositório.

---

## 12. Decisão de escopo para evitar complexidade excessiva

Como este projeto é secundário em relação a um projeto principal maior, a decisão recomendada é:

- **não expandir demais o escopo agora**;
- **finalizar uma versão simples e funcional**;
- **documentar com honestidade o que está implementado**;
- **deixar recursos avançados como backlog**.

Essa decisão melhora o custo-benefício do projeto como peça de portfólio.

---

## 13. Backlog futuro sugerido

Itens que podem ser adicionados depois, sem comprometer a versão atual:

- autenticação JWT;
- perfis/permissões;
- fornecedores;
- relatórios e consultas agregadas;
- paginação e filtros avançados;
- exportação;
- validação com FluentValidation;
- AutoMapper;
- logging estruturado;
- testes automatizados;
- Docker e deploy.

---

## 14. Observações sobre o repositório

Foi identificado que o projeto contém arquivos de ambiente e compilação, como `.vs`, `bin` e `obj`. A causa provável é a presença de um arquivo `gitignore` sem ponto inicial, o que impede o Git de tratá-lo como `.gitignore`.

Antes da publicação como portfólio, recomenda-se:

- renomear `gitignore` para `.gitignore`;
- remover arquivos já rastreados indevidamente;
- revisar a estrutura final do repositório.

---

## 15. Conclusão

A base do projeto já demonstra uma boa direção técnica, especialmente em organização por camadas e modelagem inicial do domínio. Para transformá-lo em um projeto de portfólio forte, a melhor estratégia é concluir uma versão enxuta, coerente e executável, em vez de tentar implementar todas as ideias originalmente imaginadas.

A prioridade deve ser: **fazer o sistema funcionar bem em um fluxo pequeno, mas completo**.
