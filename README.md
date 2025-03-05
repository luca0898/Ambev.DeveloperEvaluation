# Ambev.DeveloperEvaluation.WebApi

## Description

**Ambev.DeveloperEvaluation.WebApi** is an API developed as part of a challenge for a .NET software developer position. This application showcases modern practices in building RESTful APIs with .NET, containerized for easy deployment and execution.

## Prerequisites

Before running the application, ensure that you have the following installed:

- **.NET SDK**  
  Download and install the .NET SDK from [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

- **Docker**  
  Download and install Docker Desktop from [https://www.docker.com/products/docker-desktop](https://www.docker.com/products/docker-desktop).

- **Docker Compose**  
  Docker Compose is usually included with Docker Desktop.

## Setup and Execution

### 1. Clone the Repository

Clone the project repository and navigate into the directory:

```bash
git clone https://github.com/your-username/Ambev.DeveloperEvaluation.WebApi.git
cd Ambev.DeveloperEvaluation.WebApi
```

### 2. Configure the Application

Ensure that `appsettings.json` is properly configured with database connections, logging, and other necessary settings.

### 3. Running the Application with Docker Compose

To start the application using Docker Compose, follow these steps:

1. Make sure Docker and Docker Compose are running.
2. Run the following command from the project root:

   ```bash
   docker compose up --build
   ```

   The `--build` flag ensures that images are rebuilt as needed.

3. Once the containers are up, the API will be accessible at `http://localhost:<port>` as defined in `docker-compose.yml`.

### 4. Stopping the Application

To stop the running containers, execute:

```bash
docker compose down
```

## API Documentation

For detailed information on available endpoints, request/response examples, and expected behaviors, refer to the [`API.md`](./API.md) file, which contains the definitions extracted from `swagger.json`.

## Running Tests and Coverage Report

To run tests and generate a coverage report, use one of the provided scripts:

```bash
./coverage-report.bash
```
or  
```bash
./coverage-report.sh
```

These scripts will execute the test suite and generate a test coverage report.

This API was developed as part of a technical challenge for a .NET developer position, demonstrating expertise in building robust and containerized applications with Docker. Feel free to explore, modify, and integrate it as needed.