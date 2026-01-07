# ADR-0001: Use Clean Architecture for Backend

## Status: `Accepted`

## Context
Pizza X is expected to grow across POS and CRM domains. A maintainable and testable architecture is required to support long-term development and multiple frontend clients.

## Decision
The backend will follow Clean Architecture with the following layers:
- Domain
- Application
- Infrastructure
- WebAPI

## Consequences
Positive:
- Business logic is isolated and testable
- Frontends can evolve independently

Negative:
- Initial setup is more complex than a monolithic approach
