# 📦 Inventarium

**Inventarium** is an IT asset inventory system for tracking devices such as PCs, notebooks, monitors, printers, and more. It is a full-stack application built with ASP.NET Core MVC, Entity Framework Core, and SQL Server, supporting a multi-tenant architecture to serve multiple companies with isolated data.

---

## 🧭 Overview

- Web platform with a complementary desktop application  
- Role-based authentication (Administrator / Read-Only)  
- Multi-tenant structure using `TenantId` for company-level data isolation  
- Responsive UI with Bootstrap and Razor Pages  
- Visual feedback with SweetAlert2 and model validation with DataAnnotations  
- Clean, modular, and scalable code architecture

---

## 🚀 Features

- Register and list IT assets (PCs, notebooks, monitors, etc.)
- Role-based access control
- Tenant-based data isolation
- Excel and PDF export (in progress)
- Desktop app for fast local inventory entry

---

## 🏗️ Architecture

- **ASP.NET Core MVC** with Razor views  
- **Entity Framework Core** with SQL Server  
- **Multi-tenant** filtering using `TenantId` in user claims  
- Dependency Injection (DI) with services, context, and Identity managers  
- Clean Code and SOLID principles applied

---

## 🛠️ Tech Stack

| Layer          | Technology/Tool             |
|----------------|-----------------------------|
| Backend        | ASP.NET Core MVC, C#        |
| ORM            | Entity Framework Core       |
| Database       | SQL Server                  |
| Frontend       | Razor Pages, Bootstrap, SweetAlert2 |
| Authentication | ASP.NET Core Identity       |
| Desktop        | C# .NET Windows Forms       |

---

## 📁 Project Structure

```
Inventarium/
│
├── Inventarium.Web/        # Web app (ASP.NET Core MVC)
├── Inventarium.Desktop/    # Desktop app
├── Migrations/             # EF Core migrations
└── README.md               # Project documentation
```

---

## ⚙️ Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/andre-fanelli/Inventarium.git
   ```

2. Update your database connection string in `appsettings.json`.

3. Apply migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the project:
   ```bash
   dotnet run
   ```

---

## ✨ Roadmap / To-Do

- Complete Excel and PDF export features  
- Add unit and integration testing  
- Implement 2FA authentication  
- Add multi-language support  
- Docker containerization  
- Cloud deployment (Azure/AWS)

---

## 📚 Related Articles

- [ASP.NET Core MVC in practice (DIO)](https://www.dio.me/articles/aspnet-core-mvc-na-pratica-como-estou-construindo-um-sistema-web-de-inventario-f1f87e250404)  
- [Multi-Tenant in ASP.NET Core with TenantId (DIO)](https://www.dio.me/articles/multi-tenant-no-aspnet-core-controle-de-acesso-baseado-em-tenantid-6927f06925cc)

---

## 👤 Author

**André Fanelli**  
🔗 [LinkedIn](https://br.linkedin.com/in/andre-fanelli)  
🔗 [GitHub](https://github.com/andre-fanelli)

---

## 📄 License

This project is licensed under the MIT License. See details below:

```
MIT License

Copyright (c) 2024 André Fanelli

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell  
copies of the Software, and to permit persons to whom the Software is  
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in  
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR  
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,  
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE  
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER  
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,  
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE  
SOFTWARE.
```