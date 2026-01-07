# Architecture Overview

## System Overview
Pizza X is built as a **distributed system** with a clear separation between
frontend clients and backend services.

The system supports both **POS** and **CRM** domains and is designed for
scalability and maintainability.

## High-Level Components
The system consists of the following components:

- Backend: ASP.NET Web APIs
- Desktop Frontend: .NET WPF (MVVM)
- Web Frontend: React
- Database: Cloud-hosted SQL database

## Communication Flow
- Frontend clients communicate with the backend using HTTP-based REST APIs.
- The backend handles all business logic and data access.
- Frontends are thin clients that focus on UI and user interaction.

## Architectural Style
- Clean Architecture is used in the backend. [*More about backend architecture*](/documentation/architecture/backend.md)
- Frontends consume backend APIs and do not duplicate business logic.
