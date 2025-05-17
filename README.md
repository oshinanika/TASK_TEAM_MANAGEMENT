
# Task & Team Management System

A mini Task & Team Management System built with modern backend architecture principles using .NET Core Web API. The system supports team and task coordination with secure, role-based access.

---

## 📦 Entities

- **User**
  - `Id`, `FullName`, `Email`, `Role` (Admin / Manager / Employee)
- **Team**
  - `Id`, `Name`, `Description`
- **Task**
  - `Id`, `Title`, `Description`, `Status` (Todo / InProgress / Done)
  - `AssignedToUserId`, `CreatedByUserId`, `TeamId`, `DueDate`

---

## 🔧 API Features

- **CRUD Operations** for:
  - Users
  - Teams
  - Tasks
- **Task Filtering & Search**
  - By `Status`, `AssignedToUser`, `Team`, `DueDate`
- **Pagination & Sorting**
- **Role-Based Functionality**
  - Admins: Full access to Users and Teams
  - Managers: Create and edit any tasks
  - Employees: View and update status of assigned tasks only

---

## 🔐 Authentication & Authorization

- JWT-based authentication
- Role-based authorization using policies
- **Seed Users (on startup):**
  - Admin: `admin@demo.com` / `Admin123!`
  - Manager: `manager@demo.com` / `Manager123!`
  - Employee: `employee@demo.com` / `Employee123!`

---

## 🛠 Technology Stack

- **.NET Core Web API** (Latest LTS)
- **Entity Framework Core**
- **Relational Database** (e.g., SQL Server, PostgreSQL)
- **CQRS** (Command Query Responsibility Segregation)
- **JWT Authentication**
- **FluentValidation** for input validation
- **Swagger / OpenAPI** for API documentation
- **Centralized Logging** to file system (e.g., Serilog)
- **Global Exception Handling** via custom middleware
- **Unit Testing** using xUnit / NUnit / MSTest

---

## 📂 Folder Structure (Suggested)

