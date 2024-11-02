# ArunEstatesTest

## Project Description

A simple e-commerce web application built with ASP.NET Core and Entity Framework Core using an in-memory SQLite database. Features include user management and a product catalog.

## Setup and Run Instructions

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download)

### Cloning the Repository

1. Clone the repository:

   ```git clone https://github.com/yourusername/your-repository.git```

   ```cd your-repository```

3. Restore dependencies:

   ```dotnet restore```

5. Run the application:

   ```dotnet run```

7. Access the application:

   This will be

   ```https://localhost:[equivalent port number]```

## Testing

### Running Unit Tests

To run tests, navigate to the test project directory and execute ```dotnet test```

## Summary of Design Decisions

* Architecture: Layered architecture separating Controllers, Services, and Data.
* EF Core: Used for data access with a code-first approach.
* In-Memory Database: For simplicity in testing and development.
* Dependency Injection: For managing service lifetimes and testing ease.
* TDD: Unit tests for service logic to ensure correctness.
