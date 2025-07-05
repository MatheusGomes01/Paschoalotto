# Paschoalotto

# CadastroPessoas API

## Descrição

Este projeto é uma API RESTful para cadastro e consulta de Pessoas Físicas e Jurídicas, implementada em .NET 8 com Clean Architecture e boas práticas.  
Ela inclui funcionalidades como:

- Autenticação JWT para segurança dos endpoints
- Auditoria automática das operações no banco de dados
- Upload e armazenamento de imagens (básico)
- Uso do PostgreSQL como banco de dados
- Documentação e testes via Swagger

---

## Tecnologias utilizadas

- .NET 8
- Entity Framework Core
- PostgreSQL
- JWT (JSON Web Tokens)
- Swagger/OpenAPI
- Newtonsoft.Json
- Clean Architecture (Domain, Application, Infrastructure, API)

---

## Como rodar localmente

### Pré-requisitos

- .NET 8 SDK instalado ([link](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))
- PostgreSQL instalado e rodando localmente ([link](https://www.postgresql.org/download/))
- Ferramenta para gerenciamento do banco (ex: pgAdmin, DBeaver)

### Passos

1. Clone este repositório:

git clone https://github.com/SEU_USUARIO/CadastroPessoasApi.git
cd CadastroPessoasApi

2. Configure a string de conexão no arquivo Api/appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=CadastroPessoasDb;Username=seu_usuario;Password=sua_senha"
}

3. Crie o banco de dados no PostgreSQL (exemplo via psql):

CREATE DATABASE "CadastroPessoasDb";

4. Aplique as migrations para criar as tabelas:

dotnet ef database update --project Infrastructure --startup-project Api

5. Execute a API:

6. Acesse a documentação Swagger no navegador:

https://localhost:7192/swagger

Testando a API
Use o endpoint /api/v1/auth/login para obter o token JWT:

{
  "username": "admin",
  "password": "123456"
}

Utilize o token para acessar os endpoints protegidos pelo cabeçalho:

Bearer SEU_TOKEN_AQUI

Teste os endpoints de cadastro e consulta de Pessoas Físicas e Jurídicas pelo Swagger UI.

Logs de auditoria
Todas as operações de inserção, atualização e remoção geram logs de auditoria registrados na tabela AuditLogs com informações de usuário, timestamp, ação e dados alterados.

Estrutura do projeto
Api: Camada de apresentação e controllers
Application: Serviços e interfaces de negócio
Domain: Entidades e regras de domínio
Infrastructure: Persistência e implementação técnica




