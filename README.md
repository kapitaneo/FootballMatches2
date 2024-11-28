# Football Matches

Welcome to the Football Matches project! This project provides a web interface to view recent and upcoming football matches from popular leagues.

## Table of Contents
- [Project Overview](#project-overview)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
- [Running the Project](#running-the-project)
- [Additional Information](#additional-information)

## Project Overview
The Football Matches project is a web application that allows users to track recent and upcoming football matches from multiple leagues. The application is built using **ASP.NET Core** for the server-side backend and serves a simple, responsive UI for football enthusiasts.

## Prerequisites
Before setting up and running the project, ensure you have the following dependencies installed:
- **.NET 6 SDK**
- **Docker** (if you want to deploy using Docker)

## Installation
1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/football-matches.git
   cd football-matches
   ```

2. **Install Dependencies**
   Restore the required NuGet packages:
   ```bash
   dotnet restore
   ```

## Configuration
1. **App Settings Configuration**
   - Update the `appsettings.json` or create a new `appsettings.Development.json` file to include your Football Data API key:
     ```json
     "FootballDataApi": {
       "ApiKey": "your_api_key_here",
       "BaseUrl": "https://api.football-data.org/v4"
     }
     ```

2. **Environment Variables**
   Alternatively, you can set environment variables for the API key to avoid hardcoding sensitive information:
   ```bash
   FOOTBALL_API_KEY=your_api_key_here
   ```

## Running the Project
1. **Run the Application Locally**
   Use the following command to run the application locally:
   ```bash
   dotnet run
   ```
   The application will be available at [http://localhost:5000](http://localhost:5000).

2. **Running with Docker**
   - **Build the Docker Image**
     ```bash
     docker build -t football-matches .
     ```
   - **Run the Docker Container**
     ```bash
     docker run -p 8080:80 football-matches
     ```

## Additional Information
- **Dependencies**
  - `Microsoft.AspNetCore.App`: Framework for building web applications with ASP.NET Core.
  - `Newtonsoft.Json`: Used for deserializing the Football Data API responses.

- **Deployment**
  - The project can be deployed using services like Render. Ensure that the `Dockerfile` and `render.yaml` are configured correctly for deployment.

- **Notes**
  - Ensure your Football Data API key is active and has sufficient quota for the number of requests you expect to make.
  - The `ApiKey` should be kept secure and not committed to version control.

