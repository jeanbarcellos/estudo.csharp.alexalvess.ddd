Repositório apenas para estudo

# Uma arquitetura, em .Net Core, baseada nos princípios do DDD

By Alex Alves

Referencias:

- https://alexalvess.medium.com/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686

- https://github.com/alexalvess/aurora-api-project

- https://github.com/jeanbarcellos/estudo.csharp.marcosRosaSage.ddd

## Criação do Projeto

**Criar solução**

```bash
dotnet new sln --name Api
```

**Criar camada de Aplicação**

```bash
dotnet new webapi -n Application -o Api.Application
dotnet sln add Api.Application
```

**Criar camada de Dominio**

```bash
dotnet new classlib -n Domain -o Api.Domain
dotnet sln add Api.Domain
```

**Criar camada de Serviço**

```bash
dotnet new classlib -n Service -o Api.Service
dotnet sln add Api.Data
```

**Criar camada de Infraestrutura**

```bash
mkdir Api.Infra
cd Api.Infra
dotnet new classlib -n Data -o Data
dotnet new classlib -n CrossCuting -o CrossCuting
cd ..
```

**Criar as Referências**

```
dotnet add Api.Application reference Api.Domain
dotnet add Api.Application reference Api.Service

dotnet add Api.Service reference Api.Domain
dotnet add Api.Service reference Api.Infra/Data
dotnet add Api.Service reference Api.Infra/CrossCutting

dotnet add Api.Infra/CrossCutting reference Api.Domain
dotnet add Api.Infra/Data/ reference Api.Domain/
```

## Implementação das camadas

### Camada Domain

Este pacote serve para realizar a validação das entidades. No caso, utilizar-se-á a declaração AbstractValidator na declaração da interface para os serviços.

Instalação de pacotes:

```bash
dotnet add package FluentValidation.AspNetCore
```

Criação dos diretórios:

- Entities
- Interfaces

### Camada Infra/Data

Essa camada será responsável por conectar ao banco de dados

Instalação de pacotes:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

Criação dos diretórios:

- Context
  - ficará a classe de contexto, responsável por conectar no banco de dados e, também, por fazer o mapeamento das tabelas do banco de dados nas entidades
- Mapping
  - ficará as classes referente ao mapeamento de cada entidade. Nela realiza-se algumas configurações referente a própria entidade, como, por exemplo, o nome da tabela que vai para o banco de dados, o nome das colunas e qual será a chave primária.
- Repository
  - ficará as classes responsáveis por realizar o CRUD no banco de dados.

No diretório `Repositories`, desenvolve-se uma classe chamada `BaseRepository`

- A intenção é de ter uma única classe, genérica, para realizar o CRUD, onde pode-se passar uma entidade T para ela, e essa classe irá trabalhar em cima dessa entidade. Herda-se a interface IRepository, onde obriga-se a classe a implementar os métodos que definiu-se anteriormente na camada de domínio.

### Camada Infra/CrossCutting

Essa camada não será implementada nesse projeto, mas pode-se desenvolver nela, por exemplo, a validação de CPF e o consumo uma API de terceiro, além de outras funcionalidades que considera-se ser utilitária.

### Camada Service

É nesta camada que disponibiliza-se todas as regras de negócio e validações necessárias.

O pacote instalado servirá como framework para efetuar validações de objetos referentes às entidades.

Instalação de pacotes:

```bash
dotnet add package FluentValidation.AspNetCore
```

Criação dos diretórios:

- Services
- Validators

No diretório `Services`, desenvolve-se uma classe chamada `BaseService`

- Classe genérica utilizada para centralizar o `CRUD`, onde passa-se uma entidade como parâmetro, a qual irá trabalhar os serviços em cima da mesma, igualmente feito com o repositório.
- Além do mais, nos métodos de inserção e alteração, passa-se a classe responsável por validar a entidade, assim será obrigado efetuar a validação da mesma, através do método privado Validate.

Na pasta `Validators`, cria-se uma classe chamada `UsuarioValidator`, a qual será utilizada para validar toda a entidade de usuário.

### Camada Application

Esta camada é a “porta de entrada” do sistema, pois é nela que conterá os controladores e serviços para efetuar as chamadas na API.
