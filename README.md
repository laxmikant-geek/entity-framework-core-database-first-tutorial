# Entity Framework Core Database-First Tutorial

Companion sample for the GeeksArray tutorial
[Entity Framework Core Database-First Tutorial](https://geeksarray.com/blog/entity-framework-core-database-first-tutorial).

A .NET 10 console app whose `Models/` folder was generated with:

```bash
dotnet ef dbcontext scaffold "<connection>" Microsoft.EntityFrameworkCore.SqlServer \
  --table Production.Product --output-dir Models \
  --context AdventureWorksContext --no-onconfiguring
```

against the AdventureWorks database
([scripts + seed rows](https://github.com/laxmikant-geek/SQLSampleDatabase)).

`Models/Product.Extensions.cs` shows the partial-class pattern for adding your
own members without losing them on re-scaffold. Point the connection string in
`Program.cs` at your server and `dotnet run` prints the first five products.
