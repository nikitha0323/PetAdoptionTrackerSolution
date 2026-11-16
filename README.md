Pet Adoption Tracker
A web application built for Minor Project 4 using ASP.NET Core MVC and .NET 8.
Features
- Add, view, edit, and delete pets, adopters, and adoption applications.
- Search pets by name and description.
- Manage shelters through the Admin page (no login required).
- Switch between light and dark themes.
Database
Uses SQL Server LocalDB with five tables: Pets, Shelters, Breeds, Adopters, and AdoptionApplications. Includes 34 sample records.

The database models and context are in the separate PetAdoptionTracker.Data Class Library project.
How to Run
1. Open the solution in Visual Studio with .NET 8 and SQL Server LocalDB installed.
2. Restore NuGet packages and set PetAdoptionTracker as the startup project.
3. Open Tools > NuGet Package Manager > Package Manager Console and run:
Update-Database -Project PetAdoptionTracker.Data -StartupProject PetAdoptionTracker
4. Press Ctrl + F5 to launch the app. Sample data is added automatically on the first run with empty tables.
SQL Scripts
- DatabaseSchema.sql creates the tables in an empty database.
- DatabaseSeed.sql inserts sample records into empty tables.
The scripts are included as an alternative to the setup above. Do not run the seed script after the app has already added sample data.
