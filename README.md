# 🛒 E-Commerce API (ASP.NET Core)

A clean, modular E-Commerce Web API built using ASP.NET Core Web API and MySQL. Implements core backend functionality such as product listings, category management, and order processing.

## ✨ Features

- ✅ Product & Category Management (CRUD)
- ✅ Order & OrderItem creation with auto-calculated totals
- ✅ Clean Architecture (Controller → Service → Repository)
- ✅ DTOs used to structure responses and requests
- ✅ MySQL + Entity Framework Core

## 🏗️ Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- Visual Studio
- RESTful API Design

## 📁 Folder Structure
```
📦 eCommerceAPI
├── Controllers
├── DTOs
├── Models
├── Repositories
├── Services
└── Program.cs
```
pgsql
Copy
Edit

## 🚀 Getting Started

1. Clone this repo
2. Configure your `appsettings.json` connection string
3. Run migrations or create your MySQL DB manually
4. Run the API from Visual Studio

## 🔐 appsettings.json

**Don’t forget to set up your DB connection!**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ecommerce_db;User Id=youruser;Password=yourpassword;"
  }
}
```
📌 Note
Authentication and full frontend integration are not yet implemented. This is a backend-focused project.

yaml
Copy
Edit

---


