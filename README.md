# EventManagement

Este projeto foi desenvolvido com o objetivo de praticar conceitos de **Arquitetura Limpa**, autenticação/autorização com **Identity** e persistência de dados utilizando o **Entity Framework (EF)**.

## Tecnologias Utilizadas

- .NET 9
- ASP.NET Core
- Entity Framework Core
- ASP.NET Core Identity
- JWT (JSON Web Token)
- SQL Server
- Swagger (OpenAPI)
- Arquitetura Limpa (Clean Architecture)

## Objetivos

- Explorar a implementação de autenticação e autorização com Identity.
- Praticar a separação de responsabilidades utilizando Arquitetura Limpa.
- Utilizar o Entity Framework Core para persistência de dados.

  ## Como Executar

1. **Clone o repositório:** git clone https://github.com/willianmertins/seu-repositorio.git
  
2. **Configure a string de conexão:**
   - No arquivo `appsettings.json`, ajuste a chave `DefaultConnection` para apontar para sua instância do SQL Server.

3. **Configure as chaves JWT:**
   - No mesmo arquivo, configure as seções `Jwt:Issuer`, `Jwt:Audience` e `Jwt:Key` conforme desejado.

4. **Restaure os pacotes e execute as migrações:** dotnet restore dotnet ef database update --project src/Presentation/TaskManagement.Api
  
5. **Execute a aplicação:** dotnet run --project src/Presentation/TaskManagement.Api

6. **Acesse a documentação Swagger:**
   - Acesse `https://localhost:5001/swagger` no navegador para explorar e testar a API.

## Estrutura do Projeto

O projeto está organizado seguindo os princípios da Arquitetura Limpa, separando responsabilidades em diferentes camadas:

- **Domain**: Entidades de negócio e interfaces.
- **Application**: Casos de uso e lógica de aplicação.
- **Infrastructure**: Implementações de repositórios, contexto do EF e integração com Identity.
- **API**: Camada de apresentação (controllers, endpoints).

## Funcionalidades

- Cadastro e autenticação de usuários (Identity)
- Cadastro, listagem e gerenciamento de eventos
- Inscrição de usuários em eventos
- Listagem de eventos por usuário

## Como Executar

1. Clone o repositório: git clone https://github.com/seu-usuario/EventManagement.git
2. Configure a string de conexão no arquivo `appsettings.json`.
3. Execute as migrações do Entity Framework: dotnet ef database update
4. Inicie o projeto: dotnet run --project src/EventManagement.API


## Exemplos de Uso

- **Registrar usuário:** `POST /api/accounts/register`
- **Login:** `POST /api/accounts/login`
- **Criar evento:** `POST /api/events`
- **Inscrever-se em evento:** `POST /api/registration`
- **Listar eventos do usuário:** `GET /api/events/user`

## Padrões e Boas Práticas

- Separação de responsabilidades por camadas
- Injeção de dependência
- Uso de DTOs para comunicação entre camadas
- Validação e tratamento de erros

---

Projeto criado para fins de estudo e aprimoramento de boas práticas em .NET.
