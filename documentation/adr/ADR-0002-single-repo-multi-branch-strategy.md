# ADR-0002: Single Repository with Multi-Branch Strategy

## Status: `Accepted`

## Context
Pizza X consists of multiple applications that are closely related:

- Backend (ASP.NET Web APIs)
- Desktop frontend (.NET WPF using MVVM)
- Web frontend (React)
- Project documentation

These components share a common domain, evolve together, and must remain aligned in terms of API contracts, business rules, and overall architecture.

Managing them in separate repositories would increase coordination overhead, version mismatches, and maintenance complexity.

Additionally, a dedicated environment is required for validating features before merging them into stable branches.

## Decision
Pizza X will use a **single GitHub repository** with a **multi-branch strategy** to isolate concerns while maintaining centralized version control.

The following branches are defined:

- **main**
  - Root branch
  - Contains high-level project information
  - Holds shared files such as README, LICENSE, and global `.gitignore`

- **backend**
  - Contains ASP.NET Web API source code
  - Implements Domain, Application, Infrastructure, and WebAPI layers

- **desktop-frontend**
  - Contains the WPF desktop application
  - Uses MVVM and consumes backend APIs

- **web-frontend**
  - Contains the React-based web application
  - Consumes backend APIs and follows web best practices

- **testing**
  - Used for integration testing and validation
  - Acts as a pre-stable branch before changes are merged into target branches
  - Helps verify API compatibility and cross-application behavior

- **documentation**
  - Contains all project documentation
  - Includes architecture, ADRs, technical notes, and user manuals

## Consequences

### Positive
- Centralized visibility of the entire system
- Easier synchronization between backend and frontends
- Clear separation of responsibilities using branches
- Dedicated testing branch improves stability and confidence
- Documentation evolves alongside code

### Negative
- Repository size may grow over time
- Requires disciplined branch management
- Developers must be careful to work in the correct branch

## Notes
This strategy supports the long-term goal of evolving Pizza X as a
maintainable, scalable POS & CRM system while keeping development workflows
structured and predictable.
