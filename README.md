# Restaurant Interior-Exterior Order Tracking Automation

## Table of Contents
1. [Project Overview](#project-overview)
2. [Features](#features)
   - [Dual Platform Development](#dual-platform-development)
   - [Order Management](#order-management)
   - [Invoice & Payment](#invoice--payment)
   - [Inventory & Customer Management](#inventory--customer-management)
   - [Real-Time Processing](#real-time-processing)
   - [User Roles & Security](#user-roles--security)
3. [Technologies Used](#technologies-used)
4. [System Architecture](#system-architecture)
   - [Presentation Layer](#presentation-layer)
   - [Business Logic Layer](#business-logic-layer)
   - [Data Access Layer](#data-access-layer)
   - [API Layer](#api-layer)
5. [Database Integration](#database-integration)
6. [User Interface](#user-interface)
7. [Installation & Setup](#installation-setup)
   - [Prerequisites](#prerequisites)
   - [Setup Instructions](#setup-instructions)
8. [Usage](#usage)
9. [Version Control](#version-control)
10. [License](#license)

## Project Overview
Restaurant Interior-Exterior Order Tracking Automation is an advanced system designed to manage restaurant orders (both dine-in and delivery) in real-time. Developed for both **web** and **desktop** environments, the system integrates multiple modules such as order management, invoice & payment handling, inventory tracking, and customer management. 

This solution was built using **ASP.NET MVC 5** for web-based functionalities and **C# Forms App (.NET Framework)** for the desktop version, ensuring maximum flexibility for restaurant operators.

---

## Features

### Dual Platform Development
- **ASP.NET MVC 5** (Web Platform) and **C# Forms App (.NET Framework)** (Desktop Platform) to accommodate both restaurant staff and managers with flexible access.

### Order Management
- **Dine-in and delivery order tracking**: Real-time tracking of orders from placement to completion, with dynamic updates for restaurant operators.
- **Multi-payment support**: Integration of various payment methods, including card and cash.

### Invoice & Payment
- **Automated Invoice Generation**: Upon order completion, invoices are automatically generated.
- **Multi-Payment Handling**: Supports multiple payment options and real-time payment status tracking.

### Inventory & Customer Management
- **Inventory Tracking**: Basic stock management, alerting when certain inventory items need replenishment.
- **Customer Management**: Tracks customer information, order history, and feedback collection.

### Real-Time Processing
- **Asynchronous Programming**: Ensures real-time order tracking and updates.
- **Multithreading**: Multiple tasks are handled concurrently for smooth user experience and timely processing of orders.

### User Roles & Security
- Role-based access control using **ASP.NET Identity** to restrict access to various parts of the system (e.g., Admin, Manager, Staff).

---

## Technologies Used
- **Backend**: 
  - C#, ASP.NET MVC 5, .NET Framework
- **Database**:
  - SQL Server
  - Dapper (for querying)
  - Entity Framework (for ORM and entity modeling)
- **API & Web Services**:
  - Web API, RESTful Services
- **Real-Time Processing**:
  - Asynchronous Programming, Multithreading
- **Design Patterns**:
  - Layered Architecture, Singleton, Factory Method, Abstract Factory, Adapter, Composite, Decorator, Command, Mediator
- **Version Control**: Git
- **Reporting & Data Processing**:
  - Reporting, JSON
- **UI/UX**:
  - HTML5, CSS3, Material CSS, Responsive Design
- **Other Tools**:
  - Swagger (API Documentation)
  - Postman (API Testing)
  - Identity (User Authentication)

---

## System Architecture

The system is based on a **Layered Architecture**, separating concerns into different layers for better maintainability and scalability.

### Presentation Layer
- Handles the **user interface** elements of the web and desktop platforms, allowing users to interact with the system.

### Business Logic Layer
- Contains the core business logic for order processing, invoicing, and inventory management.

### Data Access Layer
- **Entity Framework** and **Dapper** are used for interacting with the SQL Server database, abstracting direct database calls for maintainability.

### API Layer
- Exposes **RESTful APIs** that allow third-party integrations and offer flexibility for extending the application.

---

## Database Integration

The system uses **SQL Server** to manage restaurant orders, inventory, and customer data. The database structure is optimized for performance and includes tables for:

- **Orders**: Order details, statuses, and timestamps.
- **Invoices**: Invoice data related to orders.
- **Customers**: Customer contact information, order history, and feedback.
- **Inventory**: Track stock levels and item prices.

Database interactions are abstracted through **Entity Framework** and queried using **Dapper** for performance optimization.

---

## User Interface

The interface is designed to be intuitive, with a focus on usability. Key features of the UI include:

- **Real-Time Dashboard**: Displays current order statuses, inventory levels, and customer feedback.
- **Responsive Design**: The web application is fully responsive to ensure accessibility on all devices (desktops, tablets, smartphones).
- **Easy Navigation**: The UI uses **Material CSS** for a clean and modern look, ensuring ease of use for operators.

---

## Installation & Setup

### Prerequisites:
- **Visual Studio 2017** or higher for development.
- **SQL Server 2014** or higher.
- **.NET Framework 4.5** or higher.

### Setup Instructions:

1. **Clone the Repository:**
   ```bash
   git clone https://your-repository-url.com
