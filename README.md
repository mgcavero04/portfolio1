# Full-Stack E-Commerce Portfolio

A real-world full-stack e-commerce web application featuring a decoupled client-server architecture. Originally engineered for Microsoft Azure deployment, this application was migrated to a high-efficiency containerized architecture hosted on Render using Docker pipelines to maintain high performance under cost-effective cloud scaling.

## 🚀 Live Demo
* **Production Deployment:** [(https://portfolio1-api.onrender.com/)]

## 🛠 Tech Stack
* **Frontend:** React, Redux, HTML5, CSS3, JavaScript
* **Backend:** .NET (C#) Web API
* **Database:** PostgreSQL (Production) / SQLite (Local Development)
* **DevOps & Infrastructure:** Docker, Docker Compose, Render Cloud Engine Architecture

---

## ⚙️ Environment Variables & Configuration

To secure sensitive database credentials, API endpoints, and production secrets, this project utilizes runtime environment variables. These variables override standard configuration files during container execution.

### Required Environment Variables

When running the application inside a production container (such as Render) or a local Docker multi-container environment, ensure the following environment keys are defined:

#### 1. Database Connectivity
* `ConnectionStrings__DefaultConnection`  
  * **Description:** The full connection string required for the .NET backend to establish a secure runtime handshake with the live PostgreSQL database instance on Render.
  * **Format Example:** `Host=://render.com;Database=db_name;Username=user;Password=secret_pwd;SSL Mode=Require;Trust Server Certificate=True;`

#### 2. Application Environments
* `ASPNETCORE_ENVIRONMENT`  
  * **Description:** Configures the execution behavior of the C# core engine.
  * **Values:** `Production` (enforces strict security, optimal caching, and error masks) or `Development` (enables detailed exceptions).

---

## 🐋 DevOps Docker Deployment Workflow

The infrastructure utilizes multi-stage Docker builds to minimize final image sizes, ensuring fast deployments and secure file separations on cloud platforms.

### Building & Running via Docker Compose
To replicate the cloud infrastructure environment locally, run the following command from the root directory:

```bash
docker-compose up --build
```

