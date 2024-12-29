# Custom IAM System Project Structure

## Overview
This document outlines the recommended project folder structure for a Custom IAM system incorporating advanced features such as RBAC, ABAC, a Policy Engine, Identity Federation, SSO, and more.

## Project Directory Structure

### `/src`
Contains the source code of the application, organized into several subdirectories.

#### `/Core`
- **`/Entities`**: Core business models like User, Role, Permission, etc. Example: User.cs, Role.cs, Permission.cs, Policy.cs.
- **`/Enums`**: Enums for roles, permissions, and other categorizations.
- **`/Interfaces`**: Interfaces for IAM services and system components. Example: IUserService.cs, IPermissionService.cs, IABACService.cs.
- **`/Specifications`**: Business rules and specifications for validation and permissions.
- **`/Authorization`**: Core classes and services for handling RBAC, ABAC, and other authorization logic. Example: RoleBasedAuthorization.cs, AttributeBasedAuthorization.cs, AccessControlService.cs.

#### `/Application`
- **`/DTOs`**: Data Transfer Objects for API interactions.
- **`/Interfaces`**: Service interfaces for interacting with the IAM features.
- **`/Services`**: Application-level services managing user and role operations. Example: UserService.cs, RoleService.cs, TokenService.cs, FederationService.cs.
- **`/Validators`**: Validation logic for inputs and entities within the IAM context. Example: RoleValidator.cs, PermissionValidator.cs.
- **`/Policies`**: Policy definitions and management services. Example: PolicyManager.cs, ABACPolicyEngine.cs.

#### `/Infrastructure`
- **`/Data`**: Database context and repositories. Example: ApplicationDbContext.cs, UserRoleMappings.cs.
- **`/Repositories`**: Custom repositories for managing Users, Roles, Permissions. 
- **`/Identity`**: Custom identity management, including user store and token management. Example: CustomUserStore.cs, TokenProvider.cs.
- **`/Logging`**: Logging mechanisms, potentially including IAM-specific events.
- **`/Messaging`**: Services for handling emails, notifications related to IAM operations. Example: EmailService.cs, SmsService.cs.
- **`/Federation`**: Components for handling SSO and identity federation. Example: SsoService.cs, FederatedIdentityManager.cs.
- **`/Security`**: Security-related functionality, including encryption and MFA. Example: MfaService.cs, TokenEncryption.cs.

#### `/WebAPI`
- **`/Controllers`**: Controllers managing API endpoints for IAM tasks. Example: AuthController.cs, UserController.cs, RoleController.cs, FederationController.cs.
- **`/Middlewares`**: Custom middleware for authentication, token handling, etc. Example: JwtAuthenticationMiddleware.cs, SsoTokenMiddleware.cs.
- **`/Models`**: Models for API requests and responses. Example: UserLoginRequest.cs, UserRegistrationResponse.cs.
- **`/Swagger`**: Swagger API documentation setup. 

### `/Tests`
Contains all test-related code.

#### `/UnitTests`
- Testing individual units of code in isolation. Example: UserServiceTests.cs, RoleServiceTests.cs, PolicyManagerTests.cs.

#### `/IntegrationTests`
- Tests integrating multiple components of the IAM system. Example: FederationServiceTests.cs, DatabaseIntegrationTests.cs.

#### `/APITests`
- Tests specifically targeting the API endpoints. Example: AuthApiTests.cs, RoleApiTests.cs.

### `/Docs`
- Documentation for the IAM system.

### `/Build`
- Build scripts and CI/CD pipeline configurations.

### `/Scripts`
- Utility and helper scripts for tasks like database migration or setup routines.

## Files
- **`.gitignore`**: Specifies intentionally untracked files to ignore.
- **`README.md`**: Markdown file with a project overview and general instructions.

## Additional Notes
- **Policy Engine**: Consider separating complex policy logic into a dedicated service or module.
- **Identity Federation & SSO**: Implementations should handle external authentication flows.
- **Multi-Tenancy**: Structures should support multiple tenants with isolated data access.

