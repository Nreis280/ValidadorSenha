# Validador de Senha

## Sobre o projeto

Este projeto foi desenvolvido como solução para o desafio técnico de validação de senha.

A API recebe uma senha e retorna um valor booleano indicando se ela atende ou não às regras definidas no desafio.

---

## Tecnologias utilizadas

- .NET 8
- ASP.NET Core
- C#
- xUnit
- Swagger

---

## Estrutura da solução

```text
ValidadorSenha
│
├── ValidadorSenha.Api
│   ├── Application
│   │   ├── DTOs
│   │   └── Services
│   │
│   ├── Controllers
│   │
│   └── Program.cs
│
├── ValidadorSenha.UnitTests
│
└── ValidadorSenha.IntegrationTests
```

---

## Regras de validação

Uma senha é considerada válida quando:

- Possui 9 ou mais caracteres
- Possui pelo menos 1 número
- Possui pelo menos 1 letra minúscula
- Possui pelo menos 1 letra maiúscula
- Possui pelo menos 1 caractere especial
- Não possui caracteres repetidos
- Não possui espaços em branco
- Não possui caracteres inválidos

Caracteres especiais permitidos:

```text
!@#$%^&*()-+
```

---

## Como executar o projeto

### Pré-requisitos

- .NET 8 SDK instalado
- Git instalado

### Como obter o projeto

Clone o repositório:

```bash
git clone https://github.com/Nreis280/ValidadorSenha
```

Acesse a pasta do projeto:

```bash
cd ValidadorSenha
```

---

### Opção 1 - Visual Studio

1. Abra o arquivo `ValidadorSenha.Api.sln`
2. Defina o projeto `ValidadorSenha.Api` como projeto de inicialização
3. Execute utilizando `F5` ou `Ctrl + F5`

---

### Opção 2 - Visual Studio Code

1. Abra a pasta do projeto no VS Code
2. Abra o terminal integrado
3. Execute:

```bash
dotnet run --project ValidadorSenha.Api
```

---

### Opção 3 - Terminal

Execute:

```bash
dotnet run --project ValidadorSenha.Api
```

Após iniciar, a aplicação exibirá a URL da API no terminal.

Exemplo:

```text
Now listening on: http://localhost:5063
```

O Swagger estará disponível em:

```text
http://localhost:5063/swagger
```

---

## Endpoint disponível

### Validar senha

```http
POST /api/senha/validar
```

### Exemplo de requisição

```json
{
  "senha": "AbTp9!fok"
}
```

### Exemplo de resposta

```json
{
  "senhaValida": true
}
```

---

## Executando os testes

### Visual Studio

1. Abra a solução `ValidadorSenha.Api.sln`
2. Acesse:

```text
Test > Test Explorer
```

3. Clique em:

```text
Run All Tests
```

---

### Visual Studio Code

Abra o terminal integrado e execute:

```bash
dotnet test ValidadorSenha.Api.sln
```

---

### Terminal

Execute:

```bash
dotnet test ValidadorSenha.Api.sln
```

Esse comando executará todos os testes da solução:

- Testes unitários
- Testes de integração

---

## Testes

### Testes unitários

Os testes unitários validam as regras de negócio diretamente no serviço responsável pela validação da senha.

### Testes de integração

Os testes de integração validam o comportamento completo da API através do endpoint HTTP, garantindo que Controller, Service e configuração da aplicação estejam funcionando corretamente em conjunto.

---

## Algumas decisões que tomei durante a implementação

### Separação das responsabilidades

Preferi deixar toda a lógica de validação dentro do Service e manter o Controller o mais simples possível. Dessa forma cada parte da aplicação fica responsável apenas pelo que realmente precisa fazer.

### Utilização de interface

Foi criada a interface `IValidadorSenhaService` para diminuir o acoplamento entre as camadas e facilitar futuras alterações.

### Regras separadas em métodos pequenos

Cada validação foi separada em um método específico para deixar o código mais fácil de ler, manter e testar.

### Caracteres permitidos

Uma decisão que tomei foi validar também caracteres que não fazem parte da lista de especiais informada no desafio.

Por exemplo:

```text
AbTp9!fok -> válido
AbTp9!fo_ -> inválido
```

O desafio informa exatamente quais caracteres especiais são aceitos, então interpretei que caracteres fora dessa lista também deveriam invalidar a senha.

### Retorno da validação

Também pensei em retornar mensagens informando exatamente por qual motivo a senha foi considerada inválida, como por exemplo:

- Não possui número
- Não possui letra maiúscula
- Possui caracteres repetidos

Mas preferi não seguir esse caminho.

Como senhas são informações sensíveis, optei por retornar apenas um booleano indicando se a senha é válida ou não, sem expor detalhes adicionais das validações.

---

## Premissas adotadas

- Senhas vazias são consideradas inválidas.
- Espaços em branco tornam a senha inválida.
- Caracteres fora da lista informada no desafio são considerados inválidos.
- A API retorna HTTP 200 tanto para senhas válidas quanto inválidas, utilizando o campo `senhaValida` para informar o resultado da validação.

---

## Princípios utilizados

Durante a implementação procurei seguir algumas boas práticas:

- Separação de responsabilidades entre Controller e Service.
- Baixo acoplamento através do uso de interface.
- Métodos pequenos e com responsabilidade única.
- Testes unitários para as regras de negócio.
- Testes de integração para validar o comportamento completo da API.
