# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

WarMadSolution is a multi-tenant SaaS Point-of-Sale (POS) system for small Indonesian retail businesses (warung). It manages sales transactions, product inventory, expense tracking, and daily financial summaries.

## Commands

```bash
# Build entire solution
dotnet build WarMadSolution.sln

# Run Azure Functions backend (requires Azure Functions Core Tools)
cd Warmad.Api && func start

# Run Blazor WebAssembly frontend
cd WarmadWeb && dotnet run

# Run all tests
dotnet test WarMadSolution.sln

# Run tests with coverage
dotnet test WarMadSolution.sln --collect:"XPlat Code Coverage"

# Run a single test project
dotnet test Repositori.Test/Repositori.Test.csproj

# Run a specific test
dotnet test Repositori.Test/Repositori.Test.csproj --filter "FullyQualifiedName~TestClassName"
```

## Architecture

The solution follows a strict layered architecture. Dependencies only flow downward:

```
WarmadWeb (Blazor WASM)        — Frontend, MudBlazor UI, Refit HTTP clients
    ↓ HTTP
Warmad.Api (Azure Functions)   — HTTP endpoints, isolated worker model
    ↓
Services                       — Business logic, validation
    ↓
Repositories                   — Cosmos DB data access (CosmosDbService)
    ↓
Azure Cosmos DB                — NoSQL, partitioned by /tenantId
```

**Shared projects** (no dependencies between them):
- `Models` — Domain entities, all inherit from `BaseEntity`
- `Dtos` — FilterQuery for pagination/filtering
- `Commons` — Enums (units, payment methods, expense categories, etc.) and static config
- `WarmadClassLib` — All actual page components and reusable Razor components

**Frontend separation:** `WarmadWeb` is a thin routing shell. Page files in `WarmadWeb/Pages/` contain only `@page` + `<PageTitle>` + one component reference. All UI logic lives in `WarmadClassLib/Pages/` (e.g., `BerandaPage`, `KasirPage`, etc.). New feature pages should be built in `WarmadClassLib/Pages/`, not in `WarmadWeb/Pages/`.

## Key Patterns

**Multi-tenancy:** Every entity has a `TenantId`. Cosmos DB uses `/tenantId` as partition key for isolation. Subscription plans (Free/Paid) gate features like max store count via `StaticSubcriptionPlan`.

**API responses:** All service methods return `ServiceResponse<T>` with `Success`, `Message`, `Data`, `Total`, and `ValueTransaction` fields.

**Cosmos DB access:** `CosmosDbService` in the `Repositories` project is the single point of database interaction. Containers: `MasterData` (entities), `tenants` (tenant records).

**Frontend HTTP clients:** `WarmadWeb` uses Refit interfaces to call `Warmad.Api` endpoints declaratively.

## Configuration

- `Warmad.Api/local.settings.json` — Local dev config: Cosmos DB connection string, database name (`percetakandb`), container names. Not committed to source control in production.
- `Warmad.Api/host.json` — Azure Functions runtime settings, Application Insights sampling.
- Database name in dev: `percetakandb`, Cosmos DB account: `percetakandb-dev`.

## Tech Stack

- **.NET 10.0**, C# with nullable reference types and implicit usings
- **Azure Functions V4** (isolated worker) for the API
- **Blazor WebAssembly** (.NET 10.0) with **MudBlazor v9** for UI
- **Azure Cosmos DB** (SDK v3) for persistence
- **Refit v10** for typed HTTP clients
- **xUnit** for testing, **Coverlet** for coverage
