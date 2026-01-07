# Domain Design Notes

## Purpose of the Domain Layer
The Domain layer represents the core business rules of Pizza X.

It is designed to be:
- Framework-independent
- Database-agnostic
- Reusable across different interfaces

## Domain Responsibilities
- Define business entities
- Enforce business rules
- Prevent invalid state transitions

## What is NOT Allowed in Domain
- Database access
- HTTP concerns
- UI logic
- Framework-specific code

## Evolution Strategy
Domain models are expected to evolve as:
- POS features expand
- CRM requirements grow
