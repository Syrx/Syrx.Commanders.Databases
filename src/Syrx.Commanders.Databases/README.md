# Syrx.Commanders.Databases

Database command execution abstractions and implementations for the Syrx data access framework.

## Table of Contents

- [Overview](#overview)
- [Key Features](#key-features)
- [Installation](#installation)
- [Core Components](#core-components)
  - [DatabaseCommander](#databasecommander)
  - [Command Resolution](#command-resolution)
  - [Transaction Management](#transaction-management)
- [Usage](#usage)
  - [Basic Implementation](#basic-implementation)
  - [Query Operations](#query-operations)
  - [Execute Operations](#execute-operations)
  - [Multi-map Queries](#multi-map-queries)
  - [Multiple Result Sets](#multiple-result-sets)
- [Configuration](#configuration)
- [Transaction Handling](#transaction-handling)
- [Error Handling](#error-handling)
- [Performance Considerations](#performance-considerations)
- [Related Packages](#related-packages)
- [License](#license)
- [Credits](#credits)

## Overview

`Syrx.Commanders.Databases` provides the core database command execution implementation for the Syrx framework. This package contains the `DatabaseCommander` class that implements the `ICommander<T>` interface, providing database-agnostic command execution capabilities built on top of Dapper.

## Key Features

- **Database-Agnostic Commands**: Execute SQL commands against any supported database
- **High Performance**: Built on Dapper for optimal performance
- **Transaction Management**: Automatic transaction handling for execute operations
- **Multi-map Support**: Complex object composition with up to 16 parameters
- **Multiple Result Sets**: Handle multiple result sets from stored procedures
- **Connection Management**: Efficient connection pooling and lifetime management
- **Command Timeout**: Configurable command timeout settings
- **Error Handling**: Comprehensive error handling with detailed exceptions

## Installation

```bash
dotnet add package Syrx.Commanders.Databases
```

**Package Manager**
```bash
Install-Package Syrx.Commanders.Databases
```

**PackageReference**
```xml
<PackageReference Include="Syrx.Commanders.Databases" Version="3.0.0" />
```

> **Note**: This package provides the core database abstractions. You'll also need a database-specific connector package and configuration.

## Core Components

### DatabaseCommander

The primary implementation of `ICommander<T>` that handles all database operations:

```csharp
public class DatabaseCommander<T> : ICommander<T>
{
    // Implements all ICommander<T> methods
    // Handles connection management
    // Manages transactions for execute operations
    // Resolves commands from configuration
}
```

### Command Resolution

Commands are resolved using the following pattern:
```
{Namespace}.{TypeName}.{MethodName}
```

For example:
- Class: `MyApp.Repositories.UserRepository`
- Method: `GetUserByIdAsync`
- Resolved Command: `MyApp.Repositories.UserRepository.GetUserByIdAsync`

### Transaction Management

- **Query Operations**: No transaction (read-only)
- **Execute Operations**: Automatically wrapped in transactions with rollback on exceptions

## Usage

### Basic Implementation

```csharp
// Dependency injection setup
services.AddScoped<ICommander<UserRepository>, DatabaseCommander<UserRepository>>();

// Repository implementation
public class UserRepository
{
    private readonly ICommander<UserRepository> _commander;

    public UserRepository(ICommander<UserRepository> commander)
    {
        _commander = commander;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var users = await _commander.QueryAsync<User>(new { id });
        return users.FirstOrDefault();
    }
}
```

### Query Operations

```csharp
// Simple query
public async Task<IEnumerable<User>> GetAllAsync()
{
    return await _commander.QueryAsync<User>();
}

// Parameterized query
public async Task<User> GetByEmailAsync(string email)
{
    var users = await _commander.QueryAsync<User>(new { email });
    return users.FirstOrDefault();
}

// Complex query with multiple parameters
public async Task<IEnumerable<User>> GetActiveUsersByRoleAsync(string role, DateTime since)
{
    return await _commander.QueryAsync<User>(new { role, since });
}
```

### Execute Operations

```csharp
// Insert operation
public async Task<User> CreateAsync(User user)
{
    var success = await _commander.ExecuteAsync(user);
    return success ? user : null;
}

// Update operation
public async Task<User> UpdateAsync(User user)
{
    return await _commander.ExecuteAsync(user) ? user : null;
}

// Delete operation
public async Task<User> DeleteAsync(User user)
{
    return await _commander.ExecuteAsync(user) ? user : null;
}
```

### Multi-map Queries

Handle complex object relationships:

```csharp
// Two-table join
public async Task<IEnumerable<User>> GetUsersWithProfilesAsync()
{
    return await _commander.QueryAsync<User, Profile, User>(
        (user, profile) => 
        {
            user.Profile = profile;
            return user;
        });
}

// Three-table join
public async Task<IEnumerable<Order>> GetOrdersWithDetailsAsync()
{
    return await _commander.QueryAsync<Order, OrderItem, Product, Order>(
        (order, item, product) =>
        {
            item.Product = product;
            order.Items ??= new List<OrderItem>();
            order.Items.Add(item);
            return order;
        });
}
```

### Multiple Result Sets

Handle stored procedures returning multiple result sets:

```csharp
public async Task<UserDashboardData> GetUserDashboardAsync(int userId)
{
    var (users, orders, notifications) = await _commander
        .QueryMultipleAsync<User, Order, Notification>(new { userId });
    
    return new UserDashboardData
    {
        User = users.FirstOrDefault(),
        RecentOrders = orders.ToList(),
        Notifications = notifications.ToList()
    };
}
```

## Configuration

Command configuration varies by database provider, but typically includes:

```csharp
// Example configuration structure
var command = new CommandSetting
{
    CommandText = "SELECT * FROM Users WHERE Id = @id",
    CommandTimeout = 30,
    CommandType = CommandType.Text,
    ConnectionAlias = "DefaultConnection"
};
```

## Transaction Handling

### Automatic Transactions

Execute operations are automatically wrapped in transactions:

```csharp
public async Task<User> UpdateUserAsync(User user)
{
    // Automatically starts transaction
    // Commits on success
    // Rolls back on exception
    return await _commander.ExecuteAsync(user) ? user : null;
}
```

### Transaction Scope

```csharp
public async Task<bool> ComplexOperationAsync(User user, List<Order> orders)
{
    // Each execute operation runs in its own transaction
    // For multi-operation transactions, use explicit transaction scope
    
    var userSuccess = await _commander.ExecuteAsync(user);
    if (!userSuccess) return false;
    
    foreach (var order in orders)
    {
        var orderSuccess = await _commander.ExecuteAsync(order);
        if (!orderSuccess) return false;
    }
    
    return true;
}
```

## Error Handling

The DatabaseCommander provides comprehensive error handling:

```csharp
try
{
    var user = await _commander.QueryAsync<User>(new { id });
}
catch (InvalidOperationException ex)
{
    // Command configuration not found
    // Connection string not found
}
catch (SqlException ex)
{
    // Database-specific errors
}
catch (TimeoutException ex)
{
    // Command timeout exceeded
}
```

## Performance Considerations

- **Connection Pooling**: Utilizes database provider connection pools
- **Command Caching**: Dapper caches prepared statements
- **Async Operations**: Fully async to avoid thread blocking
- **Memory Management**: Efficient object materialization
- **Batch Operations**: Consider batching for bulk operations

### Best Practices

```csharp
// Good: Use parameters for security and performance
return await _commander.QueryAsync<User>(new { email, isActive = true });

// Good: Use appropriate timeout for long operations
// (configured in command settings)

// Good: Use async methods consistently
public async Task<User> GetUserAsync(int id)
{
    var users = await _commander.QueryAsync<User>(new { id });
    return users.FirstOrDefault();
}
```

## Related Packages

### Database Connectors
- **[Syrx.Commanders.Databases.Connectors.SqlServer](https://www.nuget.org/packages/Syrx.Commanders.Databases.Connectors.SqlServer/)**: SQL Server connector
- **[Syrx.Commanders.Databases.Connectors.MySql](https://www.nuget.org/packages/Syrx.Commanders.Databases.Connectors.MySql/)**: MySQL connector
- **[Syrx.Commanders.Databases.Connectors.Npgsql](https://www.nuget.org/packages/Syrx.Commanders.Databases.Connectors.Npgsql/)**: PostgreSQL connector
- **[Syrx.Commanders.Databases.Connectors.Oracle](https://www.nuget.org/packages/Syrx.Commanders.Databases.Connectors.Oracle/)**: Oracle connector

### Configuration & Extensions
- **[Syrx.Commanders.Databases.Extensions](https://www.nuget.org/packages/Syrx.Commanders.Databases.Extensions/)**: Dependency injection extensions
- **[Syrx.Commanders.Databases.Settings](https://www.nuget.org/packages/Syrx.Commanders.Databases.Settings/)**: Configuration settings
- **[Syrx.Commanders.Databases.Settings.Extensions.Json](https://www.nuget.org/packages/Syrx.Commanders.Databases.Settings.Extensions.Json/)**: JSON configuration
- **[Syrx.Commanders.Databases.Settings.Extensions.Xml](https://www.nuget.org/packages/Syrx.Commanders.Databases.Settings.Extensions.Xml/)**: XML configuration

### Core Framework
- **[Syrx](https://www.nuget.org/packages/Syrx/)**: Core interfaces and abstractions

## License

This project is licensed under the [MIT License](https://github.com/Syrx/Syrx/blob/main/LICENSE).

## Credits

Built on top of [Dapper](https://github.com/DapperLib/Dapper) for high-performance database access.
