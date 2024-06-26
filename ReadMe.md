OmniaRetail .Net Challenge :

A basic Web API project is created using .Net and C# to illustrate functionality of tracking retailer's action of altering the product prices.

Commands for Reqiured Packages :

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

AutoMapper -
dotnet add package AutoMapper => Working and Used
dotnet add package AutoMapper.Extension.Microsoft.DependencyInjection => command not working with current version i.e. .Net 8
--version 7.0.0

Sequence of Execution for Unit Test Cases:
Reference - "https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test"
dotnet new sln -o unit-testing-using-dotnet-test
cd unit-testing-using-dotnet-test
dotnet new classlib -o PrimeService
ren .\PrimeService\Class1.cs PrimeService.cs
dotnet sln add ./PrimeService/PrimeService.csproj
dotnet new xunit -o PrimeService.Tests
dotnet add ./PrimeService.Tests/PrimeService.Tests.csproj reference ./PrimeService/PrimeService.csproj
dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj

Commands Used for creating test cases for this project -
dotnet new xunit -o DynamicPrisingTests
dotnet add .\DynamicPricing.csproj reference .\DynamicPricingTests\DynamicPricingTests.csproj

dotnet add package Microsoft.AspNetCore.Mvc.Testing
dotnet add package Moq
