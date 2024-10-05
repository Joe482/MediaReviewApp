# MediaReviewApp

**MediaReviewApp** is a simple web application built using **C#**, **.NET 8**, **ASP.NET Core Razor Pages**, and **PostgreSQL**. It allows users to review and keep track of various forms of media (e.g., movies, books, games, etc.). Users can view, add, edit, and delete reviews.

## Features

- Add new reviews of media items.
- View a list of all reviews with details.
- Edit and delete existing reviews.
- Navigate between different review pages via a user-friendly interface.

## Technologies Used

- **Language**: C# with .NET 8
- **Web Framework**: ASP.NET Core Razor Pages
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core (EFC)
- **UI**: HTML, CSS, Bootstrap

## Getting Started

These instructions will help you set up and run the project on your local machine.

### Prerequisites

Ensure you have the following installed:

1. **.NET 8 SDK**: You can download it [here](https://dotnet.microsoft.com/download/dotnet/8.0).
2. **PostgreSQL**: Download and install it from [here](https://www.postgresql.org/download/).
3. **Entity Framework Core Tools**: Install the EF Core command-line tools by running the following command:
   ```bash
   dotnet tool install --global dotnet-ef
   ```
4. **Git**: To clone the repository.

### Steps to Run the Application

Follow these steps to set up and run the project:

#### 1. Clone the Repository

Open a terminal or command prompt and run the following command to clone the repository:

```bash
git clone https://github.com/yourusername/MediaReviewApp.git
```

Replace `yourusername` with your actual GitHub username.

#### 2. Navigate to the Project Directory

```bash
cd MediaReviewApp
```

#### 3. Set Up the PostgreSQL Database

1. **Start PostgreSQL**: Make sure PostgreSQL is running on your local machine or server.

2. **Create a Database**:
   Open `psql` (PostgreSQL's command-line interface) or pgAdmin and create a new database:
   ```sql
   CREATE DATABASE MediaReviews;
   ```

3. **Update `appsettings.json`**:
   In the root of the project, open the `appsettings.json` file and configure the database connection string to point to your local PostgreSQL instance:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=MediaReviews;Username=postgres;Password=yourpassword"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }
   ```

   Replace `yourpassword` with your PostgreSQL password.

#### 4. Run Database Migrations

In the terminal, run the following commands to create the required database tables using Entity Framework Core:

```bash
dotnet ef database update
```

This will apply any pending migrations and create the necessary tables in the `MediaReviews` database.

#### 5. Build the Project

Run the following command to restore dependencies and build the project:

```bash
dotnet build
```

#### 6. Run the Application

Once the build is successful, you can run the application:

```bash
dotnet run
```

The application will now be running at `http://localhost:5156` (or the port specified in `launchSettings.json`).

#### 7. Access the Application

Open a browser and go to:

```
http://localhost:5156
```

You should see the home page of the **MediaReviewApp**.

- Navigate to the **Reviews** page to view all reviews.
- Use the **Create Review** option to add new media reviews.
- Use the **Edit** and **Delete** options to modify or remove reviews.

### Troubleshooting

If you encounter issues with the PostgreSQL connection, ensure the following:

1. PostgreSQL is running on your machine and listening on the correct port (`5432` by default).
2. The connection string in `appsettings.json` is configured correctly with the right database credentials.
3. If the HTTPS port isn’t working, try running the application on HTTP (`http://localhost:5156`).

### Future Improvements

- Add authentication and user roles (admin vs user).
- Improve the UI with more styling or JavaScript interactivity.
- Add more filtering and sorting options to the reviews list.

## Acknowledgments

- Built with ASP.NET Core Razor Pages and PostgreSQL.
- Entity Framework Core for database interaction.
