Reqiured Packages :

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet tool install --global dotnet-ef

Database Configuration Scripts :

Create Migration -
dotnet ef migrations add InitialCreate --context DynamicPricingContext

Create Database using Miration Scripts -
dotnet ef database update --context DynamicPricingContext

Remove Migration -
dotnet ef migrations remove