# Todo Management Application

A simple Todo management system with CRUD operations, status tracking, and filtering capabilities. Built with ASP.NET Core, Entity Framework Core, and Bootstrap.

![Todo Management Preview](screenshot.png) <!-- Add screenshot if available -->

## Features

### Core Features
- **CRUD Operations**: Create, Read, Update, and Delete todos
- **Status Management**: 
  - Pending → InProgress → Completed
  - Direct mark-as-complete action
- **Filtering**:
  - Filter todos by status (Pending/InProgress/Completed)
  - Filter todos by priority (Low/Medium/High)
- **Validation**:
  - Title required (max 100 chars)
  - Valid future dates for DueDate
  - Priority/Status value validation

### Technical Implementation
- **Backend**:
  - ASP.NET Core 8 Web API
  - Entity Framework Core (Code-First)
  - Repository pattern
  - FluentValidation
  - ABP Framework integration
- **Frontend**:
  - React-based UI (CDN-hosted)
  - Bootstrap 5 styling
  - Responsive design
  - Error handling
### Challanges
- first time to face ABP Framework "didn't implement it but i started learn it"
- it's first for me link a front end with apis some problem still persist in the link 

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Express
- [Node.js](https://nodejs.org/) (Optional for frontend tooling)
- Modern web browser

## Installation

### 1. Clone Repository
```bash
git clone https://github.com/yourusername/todo-management.git
cd todo-management
