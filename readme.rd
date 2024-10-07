** Execute the commands above to install useful packages, migrations and create dabatabase

** This is to be run in specifiques projects, not at all.

dotnet add package Microsoft.Data.SQLite
dotnet add package System.Data.Linq
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialCreate

** Open Migrations/yyyyMMddnnnnnn_InitialCreate.cs and insert above code to Up(): 

            migrationBuilder.Sql(
                "INSERT INTO Customer(Id, Name) Values(1, 'Alex Pimenta')"
                );

            migrationBuilder.Sql(
                "INSERT INTO Customer(Id, Name) Values(2, 'Arthur Gregorio Pimenta')"
                );

            migrationBuilder.Sql(
                "INSERT INTO Customer(Id, Name) Values(3, 'Estela Gregorio Pimenta')"
                );

** Then run it:

dotnet ef database update