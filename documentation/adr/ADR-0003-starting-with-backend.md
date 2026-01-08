# ADR-0003: Starting with Backend

## Status: `Accepted`

## Context
Pizza X consists of a single backend and multi-client (frontend) architecture. The backend is most important part of the application. Every frontend client uses APIs to communicate with backend.

## Decision
I decided to start with backend first, because it is the central point of the application, containing business rules, invariants, trade-offs, and database communication.

## Consequences

### Positive
- System can be easily scalable and maintained
- All business rules and core logic lives inside backend
- Frontend only handles UI/UX and API calls
- Adding a new feature will be easier

### Negative
- Backend becomes too complex and large in files size
- Adding a new feature might be easier but also costly if done a serious mistake
