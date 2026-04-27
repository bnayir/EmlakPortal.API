#  Real Estate Portal API

> **A robust and scalable Real Estate Management System** built with **.NET 8.0**, focusing on a decoupled Web API architecture, secure authentication, and modern design patterns.

---

##  Overview
This project is the backend service of a comprehensive Real Estate Portal. It is designed to handle property listings, user management, and secure role-based access. I implemented this using a **Code-First** approach with **Entity Framework Core**, ensuring a clean and maintainable database structure.

##  Tech Stack & Patterns
* **Framework:** .NET 8.0 (Web API)
* **Database:** MSSQL Server
* **ORM:** Entity Framework Core (Code-First)
* **Security:** ASP.NET Core Identity & JWT (JSON Web Token)
* **Architecture:** * **Repository Pattern:** For data abstraction and cleaner code.
    * **DTO (Data Transfer Objects):** To prevent over-posting and secure sensitive data.
    * **Layered Architecture:** Ensuring separation of concerns.

##  Key Features (Completed up to Phase 1)
* ** Secure Authentication:** Implementation of ASP.NET Core Identity for user management.
* ** JWT Authorization:** Secure token-based access control for API endpoints.
* ** Role-Based Access (RBAC):** Distinct permissions for Admins and Standard Users.
* ** Dynamic CRUD Operations:** Full API support for managing real estate listings with Repository Pattern.
* ** Database Migrations:** Seamless schema management using EF Core Migrations.

##  Architecture Insight
In this project, I prioritized **security and scalability**:

* **JWT Integration:** I chose JWT to allow the backend to be stateless, making it compatible with future mobile or frontend (MVC/React) integrations.
* **Generic Repository:** I implemented the Repository Pattern to decouple the business logic from the data access layer, making the system easier to test and maintain.

---

##  Work in Progress (Next Steps)
- [ ] Integration of **.NET Core MVC** Frontend.
- [ ] Dynamic data fetching using **Jquery AJAX**.
- [ ] Implementation of Admin Dashboard for property management.
