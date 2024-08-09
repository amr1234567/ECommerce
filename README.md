# eCommerce Backend API

This is the backend API for an eCommerce application built using ASP.NET Core, following the Onion Architecture. The project uses MongoDB as the primary database and Entity Framework (EF) as the ORM (Object-Relational Mapper). The API is designed to manage various types of users and their respective roles in the system: Customers, Admins, Delivery Personnel, and Sellers.

## Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Technologies Used](#technologies-used)
- [Features](#features)
- [User Roles](#user-roles)
  - [Customer](#customer)
  - [Admin](#admin)
  - [Delivery Personnel](#delivery-personnel)
  - [Seller](#seller)
- [Database](#database)
- [Payment Integration](#payment-integration)
- [Installation](#installation)

## Overview

This project is a backend API for an eCommerce platform. It serves as the foundation for an online marketplace where customers can browse, purchase products, and make payments. The system supports various user roles, each with different levels of access and functionality.

## Architecture

The project follows the Onion Architecture, which is a clean and modular approach that promotes separation of concerns and encourages maintainable and testable code. The architecture is structured into layers:

- **Core Layer:** Contains the domain entities, business logic, and interfaces.
- **Application Layer:** Contains services and DTOs (Data Transfer Objects) for implementing the use cases.
- **Infrastructure Layer:** Contains the implementation details like database access (using MongoDB and EF), external services, and repositories.
- **Presentation Layer:** The API controllers that expose the functionality to the outside world.

## Technologies Used

- **ASP.NET Core:** The web framework used for building the API.
- **MongoDB:** The NoSQL database used for data storage.
- **Entity Framework (EF):** The ORM used for database interactions.
- **Stripe:** Payment processing service integrated for handling transactions.
- **JWT (JSON Web Token):** Used for secure authentication and authorization.
- **AutoMapper:** For mapping between domain entities and DTOs.

## Features

- **User Authentication and Authorization:** Secure user authentication using JWT.
- **Product Management:** CRUD operations for products managed by sellers and admins.
- **Order Management:** Customers can create orders, and the delivery personnel can manage deliveries.
- **Payment Processing:** Secure payment processing using Stripe.
- **Reporting:** Admins can view reports and perform various administrative tasks.

## User Roles

### Customer

- Browse products.
- Add products to the cart.
- Place orders.
- Make payments using Stripe.
- View order history.

### Admin

- Manage users (customers, sellers, delivery personnel).
- Manage products across all sellers.
- View and manage orders.
- Access and generate reports.
- Perform administrative tasks.

### Delivery Personnel

- View assigned orders.
- Update the delivery status.
- Confirm delivery of orders to customers.

### Seller

- Manage their own products.
- View orders placed by customers for their products.
- Update product availability and prices.

## Database

The project uses MongoDB as the database to store all the data, including user information, products, orders, and transactions. Entity Framework is used as the ORM to manage database interactions in a more abstract and object-oriented manner.

## Payment Integration

Stripe is integrated into the system for secure payment processing. Customers can make payments for their orders directly through the API, and the payment status is updated in real-time.

## Installation

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MongoDB](https://www.mongodb.com/try/download/community) (or use a cloud provider like [MongoDB Atlas](https://www.mongodb.com/cloud/atlas))
- [Stripe Account](https://stripe.com)
