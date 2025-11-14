Fitness-API-Microservices

This repository contains the backend microservices for the Elevate Fitness mobile application. The system is built using a .NET microservices architecture, with services communicating via a message broker and all public traffic routed through an API Gateway.

View the project on GitHub: https://github.com/Mohamed-Magdy-Dewidar/Fitness-API-Microservices

Technology Stack

.NET 9 (for all services)

ASP.NET Core Web API (for service endpoints)

Entity Framework Core (for data access)

SQL Server (for all databases, run in Docker)

RabbitMQ (for asynchronous messaging)

MassTransit (as the .NET abstraction layer for RabbitMQ)

Docker & Docker Compose (for containerization and development)

JWT (JSON Web Tokens) (for stateless authentication)

API Gateway (YARP or Ocelot, as the single entry point)

Project Architecture

The architecture follows a standard microservice pattern. A client (mobile app) makes all requests to a single API Gateway. The gateway is responsible for authenticating the request (validating the JWT) and routing it to the appropriate downstream service.

Services are decoupled and communicate with each other asynchronously using a "database-per-service" model and event-driven patterns. When a significant event occurs (like a new user registering), the service publishes an event to a RabbitMQ message bus. Other services (like the UserProfileService or NotificationsService) subscribe to these events and react accordingly.

Services Overview

api.gateway: The single entry point for all client requests. Handles routing and JWT validation.

authenticationservice: Manages user registration, login, and the creation of JWTs.

userprofileservice: Manages all user data (weight, height, goals, age, etc.).

workoutcatalogservice: Read-only library of all exercises and workout plans.

nutritioncatalogservice: Read-only library of all food, recipes, and nutrition data.

usertrainingtrackingservice: "Write" service for logging user activity (completed workouts, meals eaten).

analyticsservice: "Read" service that consumes tracking events to build user stats and dashboards.

notificationsservice: Handles sending emails and push notifications.

Getting Started

You can run this project in two ways. Hybrid Development is recommended for day-to-day coding.

Prerequisites

.NET 9 SDK

Docker Desktop

A code editor like Visual Studio 2022 or VS Code.

A database management tool like Azure Data Studio or SSMS.

Option 1: Hybrid Development (Recommended)

This workflow is the easiest for development and debugging.

Infrastructure (SQL Server, RabbitMQ) runs in Docker.

.NET Services (Auth, Profile, Gateway) run on your local machine (via Visual Studio or dotnet run).

1. Start Infrastructure:
Run the docker-compose.infra.yml file. This starts only SQL Server and RabbitMQ.

docker-compose -f docker-compose.infra.yml up -d


2. Configure Your Services:
Ensure your appsettings.Development.json file in each .NET service points to localhost and the correct ports.

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=ElevateAuthDb;User Id=sa;Password=Strong_password_123!;TrustServerCertificate=True"
  },
  "RabbitMQ": {
    "Host": "localhost"
  }
}


(Remember to use the correct Database name for each service, e.g., ElevateProfileDb for UserProfileService).

3. Run Migrations:
Open a terminal for each service that has a database (AuthenticationService, UserProfileService, etc.) and run your migrations.

# Navigate to the service folder
cd src/AuthenticationService

# Run the EF Core commands
dotnet ef migrations add InitialCreate
dotnet ef database update


4. Run Your .NET Services:
Open the .sln file in Visual Studio, configure your startup projects (to launch the Gateway, Auth, and Profile services), and press F5.

Option 2: Full Docker (Integration Testing)

This workflow runs everything inside Docker. It's best for testing the complete, deployed system.

1. Run Docker Compose:
Use your main docker-compose.yml file. The environment variables in this file will automatically override your appsettings.json to use the Docker container names (e.g., Server=fitness-db).

# --build: Rebuilds your .NET images
# -d: Runs in detached mode
docker-compose up --build -d


2. Wait for Services:
Wait 30-60 seconds for all services to start and for the fitness-db health check to pass.

3. Test Your Endpoints:
Your entire application is now running and accessible.

Service Endpoints (Development)

When running in Full Docker mode:

API Gateway: http://localhost:8080/

Auth Service Swagger: http://localhost:5001/swagger

Profile Service Swagger: http://localhost:5002/swagger

RabbitMQ Dashboard: http://localhost:15672 (User: guest, Pass: guest)

SQL Server (for SSMS): localhost,1433 (User: sa, Pass: Strong_password_123!)

(Note: When running in Hybrid mode, your .NET services will be on their Visual Studio ports, e.g., http://localhost:5001/swagger)

Project Structure

/Fitness-API-Microservices/
├── .containers/              # (Empty folder for local bind mounts if needed)
├── src/
│   ├── API.Gateway/
│   ├── AuthenticationService/
│   ├── UserProfileService/
│   ├── ... (other services)
│   ├── ElevateFitness.Contracts/ # Shared DTOs and MassTransit Events
│   └── Shared/                   # Shared libraries
├── .dockerignore
├── .gitignore
├── docker-compose.yml            # For "Full Docker" mode
├── docker-compose.infra.yml      # For "Hybrid" development
├── Fitness-API-Microservices.sln
└── README.md                     # This file
