# Backend Architecture

## Architectural Pattern
The backend follows **Clean Architecture**, ensuring:

- Separation of concerns
- Independence of business logic
- Testability and maintainability

## Layers

### Domain Layer
- Contains core business entities and rules
- Follows Rich-domain model
- Has no dependencies on other layers
- Represents POS and CRM business concepts

### Application Layer
- Contains use cases and business workflows
- Orchestrates domain logic
- Defines interfaces for infrastructure repositories

### Infrastructure Layer
- Implements external concerns such as:
  - Database access (Entity Framework)
  - Third-party services
- Depends on Application and Domain layers

### WebAPI Layer
- Entry point for client applications
- Handles HTTP requests and responses
- Delegates processing to Application layer

## Dependency Rule
Dependencies always point inward:

![backend-architecture-dependency-diagram-image](/documentation/architecture/diagrams/backend/dependency-flow/backend-architecture-dependency-flow-diagram.png)
