# BankApi

A simple REST API for managing bank accounts, built with ASP.NET Core Web API, Entity Framework Core and SQL Server.

## Tech stack

- C# / .NET
- ASP.NET Core Web API
- Entity Framework Core (Code First, migrations)
- SQL Server
- Swagger for testing endpoints

## Endpoints

| Method | URL | Description |
|--------|-----|-------------|
| GET | `/api/accounts` | Get all accounts (supports filters, see below) |
| GET | `/api/accounts/{id}` | Get one account by id |
| POST | `/api/accounts` | Create a new account |
| PUT | `/api/accounts/{id}` | Update the name and balance of an account |
| DELETE | `/api/accounts/{id}` | Delete an account |

### Filters for `GET /api/accounts`

- `search`: returns accounts whose name contains the given text
- `minBalance`: returns accounts with balance greater than or equal to the given value

Example: `GET /api/accounts?search=Ivan&minBalance=1000`

## Validation

- `name` is required, up to 100 characters
- `balance` must be between 0 and 100,000,000
- Invalid requests return `400 Bad Request`; a missing account returns `404 Not Found`

## How to run

1. Clone the repository.
2. Check the connection string in `appsettings.json` and change the server name if needed.
3. Apply migrations: `Update-Database` in Package Manager Console.
4. Run the project and open Swagger in the browser.