# ContactManagement.API

Professional RESTful API for managing contacts built with .NET 8 and EF Core.

---

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Getting Started](#getting-started)
- [Endpoints](#endpoints)
- [Architecture](#architecture)
- [Contributing](#contributing)
- [License](#license)

---

## Project Overview

This project is a contact management system API.  
It demonstrates professional backend practices including:

- Layered architecture (Controller → Service → DbContext)  
- Async/Await for database operations  
- Soft delete for data integrity  
- DTOs for request/response separation  
- Validation of input data  
- Pagination and dynamic filtering  
- Global error handling  
- Swagger documentation for easy testing

---

## Features

- Create, read, update, delete contacts  
- Filter by name and active status  
- Pagination support  
- Soft delete (does not remove data from the database)  
- Swagger/OpenAPI documentation  
- Fully async database operations  

---

## Technology Stack

- **Language:** C#  
- **Framework:** .NET 8  
- **ORM:** Entity Framework Core  
- **Database:** SQL Server (local or Azure)  
- **API Docs:** Swagger / Swashbuckle  

---

## Getting Started

1. Clone the repository:

```bash
git clone https://github.com/your-username/ContactManagement.API.git
