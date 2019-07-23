# [WebAPI]

### WebAPI  with JWT token auth, DB connection and HTTP client proxy.

Projects description

----

 - Service.Kapi.API project - web api with system configurations (auth, logging, api docs)
 - Service.Kapi.Configuration project - configuration for logic services and repositories
 - Service.Kapi.BLL project - logic services
 - Service.Kapi.DAL.MySql project - repositories
 - Service.Kapi.BLL.Tests project - unit test for BLL logic
 - Service.Kapi.DbUp.MySql project - MySql database migrations

Usings

----
 - .NET Core 2.2
 - Serilog for logging and exception handling
 - AutoMapper for models mappings
 - API versioning
 - Swagger for API documentation
 - Micro-ORM Dapper with MySql repository  
 - DbUp for database migrations
 - .NET Core builtin HttpClientFactory with Polly (https://jsonplaceholder.typicode.com/ as fake mock api)
 - XUnit with Moq and AutoFixture for unit test

# Quick start

## Configuration Strings

+Database migration .\Service.Kapi\Service.Kapi.DbUp.MySql\appsettings.json

  ```bash
  {
  "ConnectionStrings": {
    "MainDB": "server=localhost;database=maindb;uid=root;pwd=root;",
    "ConnectionString": "server=localhost;database=kapi;uid=root;pwd=root;"
    }
  }

  ```

  +Database service .\Service.Kapi\Service.Kapi.API\appsettings.json

  ```bash
  {
  "ConnectionStrings": {
    "MainDB": "server=localhost;database=kapi;uid=root;pwd=root;",
    "ConnectionString": "server=localhost;database=kapi;uid=root;pwd=root;",
    "UsersDbConnectionString": "server=localhost;database=maindb;uid=root;pwd=root;",
    "HomesDbConnectionString": "server=localhost;database=maindb;uid=root;pwd=root;"
  },

  ```

## Database

+Run dotnet restore for install dependences

  ```bash
  > dotnet restore .\Service.Kapi\Service.Kapi.DbUp.MySql\
  ```

+Run dotnet build
  
  ```bash
  > dotnet build -v n .\Service.Kapi\Service.Kapi.DbUp.MySql\
  ```

+Run dotnet run for start

  ```bash
  > cd .\Service.Kapi\Service.Kapi.DbUp.MySql\ && dotnet run -v n  
  ```
## Service API

+ Clone the repo

  ```bash
  > git clone https://github.com/voidp34r/kapi.git
  ```

+ Run dotnet restore for install dependences

  ```bash
  > dotnet restore .\Service.Kapi\Service.Kapi.API\
  ```

+ Run dotnet build
  
  ```bash
  > dotnet build -b n .\Service.Kapi\Service.Kapi.API\
  ```

+ Run dotnet run for start service

  ```bash
  > dotnet run -v n .\Service.Kapi\Service.Kapi.API\
  ```

## Docker 

+ Docker build

  ```bash
  > docker build -t kapi .
  ```

+ Docker compose

  ```bash
  > docker-compose -f "docker-compose.yaml" up
  ```