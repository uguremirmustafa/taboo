# Taboo

## Backend

```bash
mkdir backend && cd backend
dotnet new sln -n Taboo

# Core (domain entities and interfaces)
dotnet new classlib -n Taboo.Core

# Application (business logic, DTOs, validation)
dotnet new classlib -n Taboo.Application

# Infrastructure (EF Core, OpenAI, repositories)
dotnet new classlib -n Taboo.Infrastructure

# API (ASP.NET Web API)
dotnet new webapi -n Taboo.Api

# Tests -- not yet
dotnet new xunit -n Taboo.Tests

# Project References
dotnet sln add Taboo.Core/Taboo.Core.csproj
dotnet sln add Taboo.Application/Taboo.Application.csproj
dotnet sln add Taboo.Infrastructure/Taboo.Infrastructure.csproj
dotnet sln add Taboo.Api/Taboo.Api.csproj

dotnet add Taboo.Application reference Taboo.Core
dotnet add Taboo.Infrastructure reference Taboo.Application
dotnet add Taboo.Infrastructure reference Taboo.Core
dotnet add Taboo.Api reference Taboo.Application
dotnet add Taboo.Api reference Taboo.Infrastructure

```

```bash
Taboo.Core/
├── Entities/
│   ├── Word.cs
│   ├── ForbiddenWord.cs
│   ├── Category.cs
│   └── Language.cs
├── Interfaces/
│   ├── IWordRepository.cs
│   ├── ICategoryRepository.cs
│   └── IOpenAIService.cs
└── Enums/
    └── LanguageCode.cs

Taboo.Application/
├── DTOs/
│   ├── WordDto.cs
│   └── CategoryDto.cs
├── Services/
│   ├── WordService.cs
│   └── CategoryService.cs
├── Commands/
│   ├── CreateWordCommand.cs
│   └── GenerateForbiddenWordsCommand.cs
├── Queries/
│   ├── GetRandomWordQuery.cs
│   └── GetCategoriesQuery.cs
└── Validators/
    ├── CreateWordValidator.cs
    └── CategoryValidator.cs

Taboo.Infrastructure/
├── Persistence/
│   ├── TabooDbContext.cs
│   ├── Configurations/
│   │   ├── WordConfiguration.cs
│   │   └── CategoryConfiguration.cs
│   ├── Repositories/
│   │   ├── WordRepository.cs
│   │   └── CategoryRepository.cs
│   └── Migrations/
├── OpenAI/
│   ├── OpenAIService.cs
│   └── Models/
│       └── OpenAIResponse.cs
└── Extensions/
    └── ServiceCollectionExtensions.cs

Taboo.Api/
├── Controllers/
│   ├── WordsController.cs
│   └── CategoriesController.cs
├── Program.cs
├── appsettings.json
└── Properties/
    └── launchSettings.json

```

```bash

# Add EF Core + Npgsql to Infra

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.Extensions.Configuration.UserSecrets
```

```bash
# Add DotNetEnv to Api

dotnet add package DotNetEnv
```

```bash
# migrations

# create migration
# -p => project containing your DbContext
# -s => startup project (where Program.cs is)
dotnet ef migrations add InitialCreate -p Taboo.Infrastructure -s Taboo.Api

# push migration to db
dotnet ef database update -p Taboo.Infrastructure -s Taboo.Api

```
