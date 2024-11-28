Football Matches Web Application

This project is a web application for tracking recent and upcoming football matches from popular leagues. It provides information about different competitions, teams, and match details.

Table of Contents

Features

Technologies Used

Setup and Installation

Running the Project

Environment Configuration

Usage

Contact

Features

Track upcoming and recent football matches from popular leagues.

Switch between recent matches and upcoming matches view.

Responsive design.

Technologies Used

Backend: ASP.NET Core MVC

Frontend: HTML, CSS, JavaScript (reused styles from the original project)

API Integration: Football-Data.org API

Database: No database, data comes from an external API

Setup and Installation

To set up and run this project locally, please follow these instructions:

Clone the repository:

git clone https://github.com/your-username/football-matches.git
cd football-matches

Install the dependencies:
Ensure you have .NET 7.0 SDK installed.

Set up API Key:
Create an environment variable FOOTBALL_API_KEY or add it to the appsettings.json under FootballDataApi.ApiKey. You need to get an API key from Football-Data.org.

Configure Environment:
If you plan to use Render or any hosting, ensure you have set up your environment variables in their respective environment settings.

Running the Project

Local Development

Start the application:

dotnet run

View the application:
The application runs on https://localhost:5001 (HTTPS) or http://localhost:5000 (HTTP).

Deployment

This application is set up to be deployed using Render. To deploy it:

Ensure Docker is installed if using a Docker deployment.

Push the repository to Render and use the .yaml file to set up the deployment.

Add required environment variables (such as FOOTBALL_API_KEY) in Render Dashboard under Environment settings.

Environment Configuration

Ensure you configure the following environment variables:

FOOTBALL_API_KEY: API key to access football match data from Football-Data.org.

To set environment variables in Render, go to your app's environment settings and add them manually.

Usage

Open the homepage, which displays upcoming and recent football matches.

Click on "Upcoming Matches" or "Recent Matches" to switch between different match types.

Matches are grouped by leagues and displayed as a carousel for easy browsing.
