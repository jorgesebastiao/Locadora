# Projeto de exemplo api Rest Full de uma locadora de filmes utilizando DDD e CQRS

**Demostração**
- [Locadora Web Api ](http://locadora.southcentralus.cloudapp.azure.com/swagger/index.html)

**Tecnologias utilizadas**

**Back-end**
- C#
- Asp Net Core 5.0
- MediatR,
- AutoMapper,
- FluentValidation 
- EF Core
- `swagger` Para gerar a UI da documentação dos serviços Rest

**Banco de dados**
 - sql-server 

**Executando o projeto**

Como executar ambiente Windows:

Utilizando imagen docker: necessário ter instalado Docker

navegar pelo terminal(CMD/powershell) caminho C:\Projetos\Locadora\Docker

executar comando 'docker-compose up -d'

acessar pelo link http://localhost/swagger

Executando localmente:

necessario ter instalado:

Visual studio 2019

navegar ate o local onde for clonado o projeto

abrir a solução LocadoraEnterprise.sln

Banco de dados:

A ConnectionString padrão do banco de dados está configurada para acessar o sql-server publicado em container:

Opção 1: Criar docker-compose sql-server:

```
version: "3.7"

services:
  sql-server:
    image: mcr.microsoft.com/mssql/server:2017-latest-ubuntu
    container_name: locadora-sql-server
    restart: always 
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=L@c@d@r@123
      - MSSQL_PID=Express
    ports:
      - "1433:1433" 
```

Opção 2: Alterar a ConnectionString `Data Source=host.docker.internal;Initial Catalog=LocadoraDbContext;User ID=sa;Password=L@c@d@r@123;MultipleActiveResultSets=true` localizada no arquivo appsettings.json

# Referências 
- [Domain Driven Design](https://martinfowler.com/tags/domain%20driven%20design.html)
- [Lidar com a complexidade dos negócios em um microsserviço com padrões DDD e CQRS](https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/)
- [MediatR](https://github.com/jbogard/MediatR/wiki)
- [FluentValidation](https://fluentvalidation.net/)
- [AutoMapper](https://docs.automapper.org/en/latest/)




 
