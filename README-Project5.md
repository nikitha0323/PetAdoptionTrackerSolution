# Pet Adoption Tracker – Project 5

An ASP.NET Core Web API with a console client, using .NET 8 and SQL Server LocalDB.

## Features

- Get all records or one record by ID for all five tables.
- Create, update, and delete pets, adopters, and applications through the API.
- Create, update, and delete pets through the console client.
- Validate records using business rules.

## Projects

- PetAdoptionTracker.Api: API controllers, business layer, and service models.
- PetAdoptionTracker.Data: Database models, context, migrations, and data access.
- PetAdoptionTracker.Client: Console client that calls the API.

The solution also includes the MVC application from Project 4.

## How to Run

1. Open the solution in Visual Studio with .NET 8 and SQL Server LocalDB installed.
2. Restore NuGet packages.
3. Open Package Manager Console and run:

```powershell
Update-Database -Project PetAdoptionTracker.Data -StartupProject PetAdoptionTracker.Api
```

4. If using a new, empty database, run the Project 4 MVC application once to add sample data.
5. Configure multiple startup projects:
   - PetAdoptionTracker.Api: Start, using the HTTPS profile.
   - PetAdoptionTracker.Client: Start.
   - Other projects: None.
6. Press Ctrl + F5.
7. Wait for the API to start, then use the console menu.

The client uses https://localhost:7140/. If the API port changes, update the address in the client's Program.cs.

## Database

Tables: Pets, Adopters, AdoptionApplications, Shelters, and Breeds.

DatabaseSchema.sql and DatabaseSeed.sql are included as an alternative database setup method. Run them against a new database named PetAdoptionTrackerDb, with the schema script first. Do not run the seed script on an already populated database.