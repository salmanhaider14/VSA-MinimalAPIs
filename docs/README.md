# Minimal API with VSA Architecture and CQRS Pattern

This project demonstrates a **Minimal API** implementation following the **Vertical Slice Architecture (VSA)** and **CQRS (Command Query Responsibility Segregation)** pattern. It includes features such as validation using **FluentValidation**, caching with **IMemoryCache**, and a **Global Exception Handler** to provide a clean, scalable, and maintainable API structure.

---

## Features

1. **Minimal API with Vertical Slice Architecture (VSA)**  
   Each feature (e.g., `Books`) is organized into its own slice containing:
   - Endpoints
   - Commands/Queries
   - Handlers
   - Validation logic

2. **CQRS Pattern**  
   Segregates read and write operations for better separation of concerns.

3. **FluentValidation**  
   Ensures incoming data is validated consistently and declaratively.

4. **Caching with IMemoryCache**  
   Implements in-memory caching for improving GET endpoint performance.

5. **Global Exception Handling**  
   Provides a centralized mechanism to handle unexpected errors and return meaningful error responses.

6. **Pagination**  
   Built-in pagination for listing endpoints.

---
### Blazor WASM Demonstration Project

This solution also includes a **Blazor WebAssembly demonstration project** in the `src/BlazorWASM` folder. The project showcases a simple CRUD application for managing books with features like listing, creating, editing, and deleting books. It serves as an example of how to use a client-side Blazor application with the Minimal API.

The project includes:
- Razor components for CRUD operations.
- Integration with the Minimal API using an `HttpClient`.
- Responsive design styled with **Bootstrap**.

---

## Tech Stack

- **.NET 9**
- **Entity Framework Core (In Memory)** for database operations
- **IMemoryCache** for caching
- **FluentValidation** for data validation

---

## Project Structure

```plaintext
VSAMinimalApi/
│
├── Features/
│   ├── Books/
│   │   ├── CreateBook/
│   │   │   ├── CreateBookCommand.cs
│   │   │   ├── CreateBookHandler.cs
│   │   │   ├── CreateBookValidator.cs
│   │   │   └── CreateBookEndpoint.cs
│   │   ├── DeleteBook/
│   │   │   ├── DeleteBookHandler.cs
│   │   │   └── DeleteBookEndpoint.cs
│   │   ├── GetBook/
│   │   │   ├── GetBookEndpoint.cs
│   │   │   ├── GetBookHandler.cs
│   │   │   └── GetBookResponse.cs
│   │   ├── GetBooks/
│   │   │   ├── GetBooksEndpoint.cs
│   │   │   └── GetBooksHandler.cs
│   │   ├── UpdateBook/
│   │   │   ├── UpdateBookCommand.cs
│   │   │   ├── UpdateBookHandler.cs
│   │   │   ├── UpdateBookEndpoint.cs
│   │   │   └── UpdateBookValidator.cs
│   │   ├── BookEndpoints.cs
│   │
│   └── ExceptionHandling/
│       └── ExceptionHandlingMiddleware.cs
│
├── Database/
│   ├── Models/                # EF Core models
│   └── MyContext.cs           # EF Core DbContext
│
├
├──Program.cs # Application entry point
│          
└── appsettings.json           # Configuration file
```

---

## Endpoints

### Book Feature
| HTTP Method | Endpoint        | Description                       |
|-------------|-----------------|-----------------------------------|
| GET         | `/books/{id}`   | Fetch a single book by ID (cached)|
| GET         | `/books`        | Fetch all books with pagination   |
| POST        | `/books`        | Create a new book                 |
| PUT         | `/books/{id}`   | Update an existing book           |
| DELETE      | `/books/{id}`   | Delete a book                     |

---

## Getting Started

### Prerequisites
- .NET 9 SDK

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/salmanhaider14/VSA-MinimalAPIs.git
   cd VSAMinimalApi
   ```

2. Install dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run --project src
   ```

---

## Database

This project is currently configured to use an **In-Memory Database** for simplicity and demonstration purposes. This allows you to quickly test the application without setting up a database server.

### Switching to a Persistent Database
You can configure the application to use a persistent database like **SQL Server**, **PostgreSQL**, or **SQLite** by modifying the `MyContext` configuration in the `Program.cs` file.

1. Update the `Program.cs` file to use a persistent database provider:
   ```csharp
   builder.Services.AddDbContext<MyContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
   ```

2. Add a connection string to the `appsettings.json` file:
   ```json
   {
       "ConnectionStrings": {
           "DefaultConnection": "YourDatabaseConnectionString"
       }
   }
   ```

3. Apply migrations:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

---

## Validation

The project uses **FluentValidation** for validating requests. Example rules:
- **Title**: Required and must not exceed 100 characters.
- **PublishedDate**: Cannot be in the future.
- **AuthorName**: Required and must not exceed 50 characters.

Validation errors return a structured `400 Bad Request` response.

---

## Caching

- **IMemoryCache** is used for caching single book retrievals (`/books/{id}`).
- Cache entries expire after **5 minutes**.
- Cache is invalidated after book updates or deletions.

---

## Global Exception Handling

The **ExceptionHandlingMiddleware** provides centralized error handling for unexpected exceptions. This middleware ensures:
1. All unhandled exceptions are logged using `ILogger`.
2. Clients receive a structured `500 Internal Server Error` response with a meaningful error message.

To add this middleware, the `Program.cs` file includes:
```csharp
app.UseExceptionHandling();
```

---

## Pagination

- The `GET /books` endpoint supports pagination:
   - Query parameters: `pageNumber` (default: 1), `pageSize` (default: 10).
   - Example: `/books?pageNumber=2&pageSize=5`.

---

## Contributing

All types of contributions are welcome! If you have suggestions, feel free to open a pull request or issue.

---
