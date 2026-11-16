Pet Adoption Tracker
Pet Adoption Tracker is an ASP.NET Core MVC web application I built for Minor Project 4. It manages pets, adopters, adoption applications, and shelters, with a separate Class Library for database code.
Features
- Create, view, edit, and delete pets, adopters, and adoption applications.
- Search pets by name and description. When both fields are filled in, results must match both.
- Manage shelters through the Admin section.
- Switch between light and dark themes without restarting the app.
- Save the theme preference in the browser using localStorage.
- Load 34 sample records when the application first runs against the empty database.
The Admin section has no login or password, as authentication was not required for this assignment. Its URL does not provide access control.
Technologies
- C# and .NET 8
- ASP.NET Core MVC
- Entity Framework Core 8
- SQL Server Express LocalDB
- Razor views, Bootstrap, CSS, and JavaScript
Solution structure
Project	Purpose
PetAdoptionTracker	MVC web application containing controllers, views, navigation, settings, and styling
PetAdoptionTracker.Data	Separate Class Library containing the five models, AdoptionDbContext, migrations, and DbSeeder


The web project references the Class Library and registers its database context in Program.cs.
Database
The database is named PetAdoptionTrackerDb and contains five application tables:
Table	Initial records
Shelters	3
Breeds	5
Pets	12
Adopters	8
AdoptionApplications	6
Total	34


Each pet references a shelter and a breed. Each adoption application references a pet and an adopter. Foreign keys restrict deleting records that are still referenced by other records.
Requirements
- Windows with SQL Server Express LocalDB installed
- .NET 8 SDK
- Visual Studio with the ASP.NET and web development workload
Setup and launch
1. Clone or download this repository and open the solution in Visual Studio.
2. Restore NuGet packages by right-clicking the solution and choosing Restore NuGet Packages.
3. Set PetAdoptionTracker as the startup project.
4. Confirm that the web project's appsettings.json contains this connection string:
   "ConnectionStrings": {
     "AdoptionConnection": "Server=(localdb)\\MSSQLLocalDB;Database=PetAdoptionTrackerDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   This is a section within the existing JSON file; keep the other settings.
5. Open Tools > NuGet Package Manager > Package Manager Console and run:
   Update-Database -Project PetAdoptionTracker.Data -StartupProject PetAdoptionTracker
6. Press Ctrl + F5 to launch the application. The seeder adds the sample records if the Shelters table is empty. For initial setup, use a new database with empty application tables.
7. If the browser does not open, use the localhost URL shown beside Now listening on in the application console. Keep that console open while using the app.
Application pages
Use the navigation bar or append these paths to the application's localhost address:
Page	Path
Pets and search	/Pets
Adopters	/Adopters
Adoption applications	/AdoptionApplications
Shelter administration	/Admin/Shelters/Index
Theme settings	/Settings


SQL scripts
- DatabaseSchema.sql: DDL generated from the Entity Framework migration to create the tables and relationships.
- DatabaseSeed.sql: DML to insert the 34 sample records and display the record counts.
These files provide an alternative to migration-based setup. To use them, first create an empty SQL Server database named PetAdoptionTrackerDb. Run the schema script against that database, then run the seed script before launching the application. The files may be inside a project folder in the repository.

Do not run the seed script after the application's seeder has already populated the database. The SQL seed script intentionally stops if any application table contains records.
Basic testing
- Search for Buddy by name; only Buddy should appear.
- Clear the name field and search for quiet in the description; Luna and Cleo should appear.
- Use Clear to return to the full pet list.
- Create, edit, view, and delete a temporary record in Pets, Adopters, and Adoption Applications.
- Test shelter management using a temporary shelter with no linked pets.
- Switch themes in Settings and navigate to another page to confirm the preference stays applied.
When deleting related test records, delete applications first, then their pets or adopters. Remove a shelter only after its pets have been removed or reassigned.
LocalDB troubleshooting
If the application cannot connect, open Developer PowerShell and run:
sqllocaldb start MSSQLLocalDB
During development, LocalDB failed to start. Restarting the computer and starting the instance resolved that issue. Once LocalDB is running, retry the database update or launch the application again.
Future improvements
- Add authentication and enforce admin permissions.
- Add pet photos and improve the page designs.
- Show friendly messages when related records prevent deletion.
- Add validation for application statuses and prevent conflicting adoption approvals.
- Test deployment with a hosted database and production configuration.
