# Restaurant Interior-Exterior Order Tracking Automation
![**Pre-Accounting Automation (Image)**](logo.png)  


## Table of Contents
1. [Project Overview](#project-overview)
2. [Features](#features)
   - [Dual Platform Development](#dual-platform-development)
   - [Order Management](#order-management)
   - [Invoice & Payment](#invoice--payment)
   - [Inventory & Customer Management](#inventory--customer-management)
   - [Real-Time Processing](#real-time-processing)
   - [User Roles & Security](#user-roles--security)
3. [Program Features](#Programfeatures)
   - [Login Form](#login-form)
   - [Homepage](#homepage)
     - [Indoor Orders Tab](#indoor-orders-tab)
     - [Outdoor Orders Tab](#outdoor-orders-tab)
     - [Reservation Tab](#reservation-tab)
     - [Waiter Menu Management Tab](#waiter-menu-management-tab)
4. [Technologies Used](#technologies-used)
5. [System Architecture](#system-architecture)
   - [Presentation Layer](#presentation-layer)
   - [Business Logic Layer](#business-logic-layer)
   - [Data Access Layer](#data-access-layer)
   - [API Layer](#api-layer)
6. [Database Integration](#database-integration)
7. [User Interface](#user-interface)
8. [User Interface](#user-interface)
9. [Installation & Setup](#installation-setup)
   - [Prerequisites](#prerequisites)
   - [Setup Instructions](#setup-instructions)
10. [Usage](#usage)
12. [Program UseExample](#programusageexample)
13. [Version Control](#version-control)
14. [License](#license)

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

## Program Features
### Login Form
- The application begins with a **Login Form**.
- Users must enter valid credentials stored in the database, including a security code.
- If incorrect credentials are provided:
  - Displays an error message for invalid username/password.
  - Displays a separate error message for incorrect security code.
- Upon successful login, redirects to the **Homepage**.

### Homepage
The Homepage consists of multiple tabs for managing restaurant operations:

#### Indoor Orders Tab
- **Selected Table Section**:
  - Displays the company logo if no table is selected.
  - If a table is selected, shows:
    - A corresponding image of the table (occupied or unoccupied).
    - Table number.
- **Order Details Section**:
  - Lists orders placed for the selected table.
  - Dynamically updates the total cost in TL.
- **Table View**:
  - Displays all tables, each represented by a color-coded image:
    - Brown: Unoccupied.
    - Green: Occupied.
  - Selecting a table activates it for order placement.
  - Table details update in real-time in both the "Selected Table" section and the table view.
- **Menu Management**:
  - Users can:
    - Select items from categorized tabs in the menu.
    - Add items to the order list by selecting a checkbox.
    - Adjust item quantities by right-clicking to increase or decrease the count.
    - Dynamically update the total cost.
- **Table Closure**:
  - To close a table:
    - Click "Close Table" after selecting it.
    - Clears the order list and resets the total cost.
  - Before closure, clicking "Generate Bill" redirects to a payment page.

#### Outdoor Orders Tab
- Functions similarly to the Indoor Orders Tab but is tailored for takeaway or delivery orders.
- Includes additional fields for:
  - Customer phone number.
  - Delivery address (can include company name or individual name).
  - Delivery personnel selection from a dropdown (ComboBox).

#### Reservation Tab
- **Reservation Form**:
  - Allows entering customer reservation details.
- **Reservation List**:
  - Displays all reservations.
  - Includes search functionality by name or phone number.
- **Editing Reservations**:
  - Clicking a reservation in the list populates the form for editing.
  - Changes can be saved using an "Update" button.

#### Waiter Menu Management Tab
1. **Menu Group Management**:
   - Allows updating menu group details.
   - Automatically saves changes to the database upon text field updates.
   - Warns the user before deleting an entry.
   - Adding a new menu item prompts a form for entering the name and price.
2. **Waiter Management**:
   - Displays a list of waiters with their images and details.
   - Allows updating waiter details and images via dedicated buttons.
   - Provides options to add new waiters or refresh the list.

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

## Program Usage Example

1. **Login**:
   - Start the application and log in with valid credentials.
2. **Indoor Orders**:
   - Select tables, manage orders, and generate bills.
3. **Outdoor Orders**:
   - Add customer details and assign delivery personnel.
4. **Reservations**:
   - Add, update, or search for reservations.
5. **Waiter Menu Management**:
   - Update menu items and waiter details efficiently.

## Installation & Setup

### Prerequisites:
- **Visual Studio 2017** or higher for development.
- **SQL Server 2014** or higher.
- **.NET Framework 4.5** or higher.

### Setup Instructions:

1. **Clone the Repository:**
   ```bash
   git clone https://your-repository-url.com
