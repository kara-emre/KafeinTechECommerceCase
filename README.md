 
# KafeinTech E-Commerce Case

This project is a microservice-based e-commerce application built using .NET 8.

The project consists of four main microservices: Order, Identity, Invoices, and Mails.

Each microservice operates independently and communicates via MassTransit.

## Microservices

### Order Microservice
- **Tables:** Product, Order, OrderItem
- **Initial Data:** Five sample products
- **Functions:** Creating products and handling orders
- **Communication:** Order info and invoice info queues

### Identity Microservice
- **Functions:** Generating JWT tokens
- **Endpoint:** Login

### Invoices Microservice
- **Functions:** Creating invoices and sending emails
- **Communication:** Invoice info queues

### Mails Microservice
- **Functions:** Sending emails
- **Communication:** Email info queues

## Setup and Execution

1. Navigate to each microservice directory and start it using `dotnet run`.
2. Send dummy user credentials to the Identity Microservice's Login endpoint to get a token.
3. Use the token to send `productId` and `quantity` to the Order Microservice's CreateOrder endpoint.
4. Communication between microservices will be handled by MassTransit, and relevant processes will be executed automatically.

## Technologies Used

- **.NET 8**
- **MassTransit** for inter-service communication
- **JWT** for authentication
- **Docker** for containerization (if applicable)
- **C#** - Primary programming language used for development
- **ASP.NET Core** - Framework for building web applications and services
- **Entity Framework Core** - ORM for database management
- **MediatR** - Library for implementing CQRS (Command Query Responsibility Segregation) pattern
- **AutoMapper** - Object-object mapping tool
- **FluentValidation** - Library for building strongly-typed validation rules

 
