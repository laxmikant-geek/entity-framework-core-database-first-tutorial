# EF Core 9 Database-First Sample

A minimal .NET 9 console app showing the EF Core 9 database-first workflow against
SQL Server 2022: scaffold a `DbContext` and entities from an existing schema, keep
customizations across re-scaffolds, and query with LINQ.

## What it shows

- `schema.sql` — a small `Sales` schema (Customers, Orders) to scaffold from.
- `Models/` — representative scaffolded output: `Customer`, `Order`, and
  `AppDbContext`, generated with `--data-annotations --no-onconfiguring`.
- `Models/Customer.Custom.cs` — a hand-written `partial` extension that survives
  re-scaffolding with `--force`.
- `Program.cs` — LINQ queries over the scaffolded context.

## How to run

1. Create the database and schema:

   ```bash
   sqlcmd -S localhost -Q "CREATE DATABASE Sales"
   sqlcmd -S localhost -d Sales -i schema.sql
   ```

2. Install the EF Core tools and packages:

   ```bash
   dotnet tool install --global dotnet-ef
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.0
   dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
   ```

3. Scaffold the model (exact command):

   ```bash
   dotnet ef dbcontext scaffold \
     "Server=localhost;Database=Sales;Trusted_Connection=True;TrustServerCertificate=True" \
     Microsoft.EntityFrameworkCore.SqlServer \
     -o Models --context AppDbContext --data-annotations --no-onconfiguring
   ```

   Re-run with `--force` whenever the schema changes.

4. Run the sample:

   ```bash
   dotnet run
   ```

The `Models/` files here are hand-written to match what scaffolding produces, so the
app builds and runs without a live database connection to reverse-engineer first.

Part of the GeeksArray blog: https://geeksarray.com
