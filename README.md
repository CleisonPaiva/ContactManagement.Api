# ContactManagement.API

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4)
![EF Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4)

Professional RESTful API for contact management built with **.NET 8** and **EF Core**.  
Demonstrates best practices like async operations, soft delete, DTOs, validation, filters, pagination, and Swagger documentation.

---

## ✨ Features

- ✅ Full CRUD operations
- ✅ Pagination (`?page=1&pageSize=10`)
- ✅ Filters by name and status (`?name=John&active=true`)
- ✅ Soft delete (`IsDeleted` flag)
- ✅ Data validation
- ✅ Async operations
- ✅ Swagger documentation

---

## 🛠 Tech Stack

- **.NET 8**
- **Entity Framework Core**
- **SQL Server**
- **Swagger**
- **FluentValidation**

---

## 🚀 Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server (or LocalDB)

### Installation

```bash
# Clone the repository
git clone https://github.com/CleisonPaiva/ContactManagement.API.git

# Navigate to the folder
cd ContactManagement.API

# Configure the connection string in appsettings.json
# "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ContactDb;Trusted_Connection=True;"

# Run migrations
dotnet ef database update

# Run the application
dotnet run
```
# Access https://localhost:5001/swagger to test the API.



## 📡 Endpoints

| Method | Route | Description |
|--------|------|-----------|
| GET | `/api/contacts` | List all (with pagination/filters) |
| GET | `/api/contacts/{id}` | Get by ID |
| POST | `/api/contacts` | 	Create new contact |
| PUT | `/api/contacts/{id}` | Update contact |
| DELETE | `/api/contacts/{id}` | Soft delete |

### Request example (POST)

```json
POST /api/contacts
{
  "firstName": "João",
  "lastName": "Silva",
  "email": "joao@email.com",
  "phoneNumber": "11999999999",
  "isActive": true
}
```

## 📁 Folder Structure

The structure follows a clean architecture pattern:

```
ContactManagement.API/ 
├── Controllers/
├── Services/
├── DTOs/
├── Entities/
├── Data/
└── Middlewares/
```