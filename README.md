---

# **Fitness API Microservices**

This repository contains the backend microservices for the **Elevate Fitness** mobile application.
The system uses a **high-performance, event-driven .NET microservices architecture** with CQRS, caching, and asynchronous messaging.

🔗 **GitHub Repository:**
[https://github.com/Mohamed-Magdy-Dewidar/Fitness-API-Microservices](https://github.com/Mohamed-Magdy-Dewidar/Fitness-API-Microservices)

---

# 🚀 Overview

The **Elevate Fitness API** is designed to support:

* High-throughput user activity tracking
* Personalized workout/nutrition content delivery
* Efficient, scalable read/write separation

This system solves real-world scaling challenges by separating **content/catalog services** (read-heavy) from **progress tracking services** (write-heavy).

---

# ⭐ Key Features

### **✓ Decoupled Microservices**

Services communicate asynchronously through **RabbitMQ**, improving resilience and reliability.

### **✓ High Performance**

Redis is used for:

* Rate limiting
* Active workout session tracking
* Read-through caching

### **✓ Transactional Integrity**

A fully implemented **Transactional Outbox Pattern** guarantees atomic consistency between:

* SQL Server writes
* RabbitMQ event publishing

### **✓ Flexible Data Modeling**

Workout logs use the **Table-Per-Hierarchy (TPH)** pattern for:

* Weight workouts
* Cardio workouts
* Timed sessions

### **✓ CQRS Architecture**

Clear separation of responsibilities using:

* Command Handlers
* Query Handlers
* MediatR Pipeline

---

# 🧱 Architecture & Technology Stack

The system consists of **8 microservices**, all accessed through a single API Gateway.

## **Tech Stack**

| Component        | Technology                        |
| ---------------- | --------------------------------- |
| Framework        | **.NET 9 (ASP.NET Core Web API)** |
| Database         | SQL Server 2022 (DB-per-Service)  |
| Messaging        | RabbitMQ using MassTransit        |
| Cache            | Redis                             |
| API Gateway      | YARP                              |
| ORM              | Entity Framework Core             |
| Validation       | FluentValidation                  |
| Containerization | Docker & Docker Compose           |

---

# 🗂️ Service Responsibilities

| Service                       | Description                         | Storage            |
| ----------------------------- | ----------------------------------- | ------------------ |
| **API Gateway**               | Routes requests, validates JWTs     | —                  |
| **Authentication**            | Registration, login, JWT issuance   | SQL Server         |
| **User Profile**              | User info, settings, profile images | SQL Server         |
| **Workout Service**           | Read-only workout catalog           | SQL Server + Redis |
| **Progress Tracking**         | Logs workouts, meals, metrics       | SQL Server + Redis |
| **Nutrition Service**         | Read-only meals & recipes           | SQL Server         |
| **FCE (Fitness Calc Engine)** | BMR, TDEE, calorie targets          | SQL Server         |
| **Smart Coach**               | AI-driven recommendations           | —                  |

---

# 🔌 Event-Driven Workflows

## **1. Workout Session Flow**

A hybrid synchronous + asynchronous workflow ensures speed + durability.

### **Start Session**

```
POST /workouts/{id}/start
```

Workout Service:

* Validates workout
* Returns a **SessionId** (cached in Redis)

### **Publish**

Workout Service publishes:

```
WorkoutSessionStartedEvent
```

### **Consume**

Progress Tracking Service:

* Saves permanent ActiveSession record in SQL

### **Finish Session**

```
POST /progress/workouts
```

Progress Tracking Service:

* Logs workout
* Publishes `WorkoutCompletedEvent` for analytics

---

# 🛠️ Getting Started

You can run the system in **two different modes**.

---

# **Option 1: Hybrid Development (Recommended)**

Run infrastructure in Docker and run .NET code locally for the best debugging experience.

---

## **1. Start Required Infrastructure**

```sh
docker-compose -f docker-compose.infra.yml up -d
```

This launches:

* SQL Server (port 1433)
* RabbitMQ (port 5672)

---

## **2. Update Configuration**

Ensure every service's `appsettings.Development.json` contains:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;User Id=sa;Password=YourPassword!;"
},
"RabbitMQ": {
  "Host": "localhost"
}
```

---

## **3. Apply Migrations**

```sh
cd src/AuthenticationService
dotnet ef database update
```

Repeat for any service that uses SQL Server.

---

## **4. Run the Services Locally**

Open the solution:

```
Fitness-API-Microservices.sln
```

Then press **F5** in Visual Studio or run:

```sh
dotnet run
```

---

# **Option 2: Full Docker Mode (Integration Testing)**

Runs **all microservices + databases + gateway** inside containers.

### Build & run everything:

```sh
docker-compose up --build -d
```

### Access endpoints:

| Component                   | URL                                                            |
| --------------------------- | -------------------------------------------------------------- |
| **API Gateway**             | [http://localhost:8080](http://localhost:8080)                 |
| **Auth Service Swagger**    | [http://localhost:5001/swagger](http://localhost:5001/swagger) |
| **Profile Service Swagger** | [http://localhost:5002/swagger](http://localhost:5002/swagger) |
| **Progress Tracking**       | [http://localhost:5003/swagger](http://localhost:5003/swagger) |

---

# 📁 Project Structure

```
/Fitness-API-Microservices
├── src/
│   ├── API.Gateway/              
│   ├── AuthenticationService/    
│   ├── UserProfileService/       
│   ├── WorkOutService/           
│   ├── ProgressTrackingService/  
│   ├── NutritionService/         
│   ├── Contracts/                # Shared event definitions
│   └── Shared/                   # Shared kernel utilities
├── docker-compose.yml            # Full stack
├── docker-compose.infra.yml      # Infrastructure only
└── README.md
```

---

# 📜 Recent Improvements

### ✓ Transactional Outbox Pattern

Ensures event publishing and SQL writes are always consistent.

### ✓ Redis Caching

Used for:

* Active session state
* Read-through caching for workout catalog
* Rate limiting

### ✓ TPH Model

Allows different workout types to be stored in a single table using inheritance.

---

# 🎉 Final Notes

This system is designed to be:

* **Fast**
* **Scalable**
* **Event-driven**
* **Developer friendly**

Feel free to fork, clone, or contribute!

---
