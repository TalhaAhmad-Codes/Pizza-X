# ADR-0004: Setting up Backend Project Structure and Required Packages

## Status: `Accepted`

## Context
Pizza X follows a **backend-first development approach** to ensure that all
business logic, validation, and data access are centralized.

The backend must support:
- Multiple frontend clients (WPF and React)
- Long-term maintainability
- Clear separation of concerns using Clean Architecture

To achieve this, the backend is divided into multiple projects (layers), each with clearly defined responsibilities. Selecting appropriate NuGet packages per layer is critical to enforce architectural boundaries and prevent unintended dependencies.

## Decision
The backend will be structured using **Clean Architecture**, with each layer having its own project and a curated set of NuGet packages.

Package selection is intentionally minimal and aligned with the responsibility of each layer.

---

### Domain Layer
**Purpose:**  
Encapsulate core business rules and entities without external dependencies.

**Selected Package:**
- `BCrypt`

**Rationale:**
- Used for secure password hashing within domain logic
- Does not require infrastructure or framework-specific dependencies
- Keeps security-related business rules close to the domain model

---

### Application Layer
**Purpose:**  
Define use cases, business workflows, and validation logic.

**Selected Packages:**
- `FluentValidation`
- `MediatR`
- `Microsoft.Extensions.DependencyInjection.Abstractions`

**Rationale:**
- `FluentValidation` is used to validate commands and queries before execution
- `MediatR` enables the CQRS-style request/response pattern and decouples
  business logic from controllers
- `Microsoft.Extensions.DependencyInjection.Abstractions` allows defining
  service contracts without binding to a concrete DI container

---

### Infrastructure Layer
**Purpose:**  
Handle external concerns such as database access and configuration.

**Selected Packages:**
- `MediatR`
- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microsoft.Extensions.Configuration`
- `Microsoft.Extensions.Configuration.Abstractions`
- `Microsoft.Extensions.DependencyInjection`

**Rationale:**
- `EntityFrameworkCore` provides ORM support for persistence
- SQL Server provider is used for both local and cloud environments
- EF Core tools support migrations and database updates
- Configuration packages enable environment-based settings
- Dependency Injection package allows registering concrete implementations
- `MediatR` is used to publish domain events or handle cross-layer concerns

---

### WebAPI Layer
**Purpose:**  
Expose backend functionality over HTTP and act as the entry point for clients.

**Selected Packages:**
- `FluentValidation.AspNetCore`
- `MediatR`
- `Microsoft.AspNetCore.OpenApi`
- `Microsoft.EntityFrameworkCore.Design`
- `Swashbuckle.AspNetCore`

**Rationale:**
- `FluentValidation.AspNetCore` integrates validation into the HTTP pipeline
- `MediatR` connects API endpoints to application use cases
- OpenAPI and Swagger packages provide API documentation and discoverability
- EF Core design package supports development-time tooling

---

## Consequences

### Positive
- Clear architectural boundaries between backend layers
- Reduced risk of accidental cross-layer dependencies
- Improved testability and maintainability
- Backend remains frontend-agnostic
- Package usage aligns with Clean Architecture principles

### Negative
- Slightly higher initial setup effort
- Developers must understand where each package belongs
- Package updates must be evaluated per layer

## Notes
> All new backend packages must be reviewed to ensure they align with the responsibility of the target layer and do not violate dependency rules.
