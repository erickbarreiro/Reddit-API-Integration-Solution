# Reddit API Integration Solution

## Overview
This project is designed to fetch posts from various subreddits using the Reddit API and categorize them into different internal categories based on their metadata. It supports dynamic addition of subreddits and stores the fetched data into a SQL database using Entity Framework Core. The project is structured with .NET 8 and follows best practices for scalability, reliability, and maintainability.

## Features
- Fetch posts from specified subreddits.
- Categorize posts and route them to appropriate internal teams.
- Save fetched data with subreddit details and timestamps.
- Scalable architecture to handle different load sizes and prevent data duplication.

## Prerequisites
To run this solution, you'll need:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB or Express is sufficient for development purposes)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later (for development and running the project)

## Setup
1. **Clone the Repository**
   git clone https://yourrepositoryurl.com/RedditAPI.git
   cd RedditAPI

##App Settings

    Navigate to appsettings.json.
    Update the ConnectionStrings section with your SQL Server instance.

##json

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=RedditDb;Trusted_Connection=True;"
}

##Database Migration

    Open a command prompt or terminal in the project directory.
    Run the following commands to apply the database migrations.

bash dotnet ef database update

##Running the Application

    Start the Application
        You can run the application directly using Visual Studio or through the command line:

    bash dotnet run

##Access the API
        Once the application is running, navigate to https://localhost:5001/swagger to view the Swagger UI and interact with the API.

##Testing

    Run integration tests and unit tests by executing:

    bash

    dotnet test

##Using the API

    Add a Subreddit
        Use the POST endpoint /subreddit to add a new subreddit to track.
    Fetch Posts
        Use the GET endpoint /posts/{subredditName} to fetch posts from a specific subreddit.

##Dockerization

    This project includes Docker support. To build and run the application in a Docker container, use:

    bash

    docker-compose up --build

##Logging

    The application uses built-in logging mechanisms provided by ASP.NET Core. Check the console or configured log output destinations for runtime information.

##Contributing

Feel free to fork the repository, make changes, and submit pull requests. Contributions are welcome!
License

This project is licensed under the MIT License - see the LICENSE file for details.