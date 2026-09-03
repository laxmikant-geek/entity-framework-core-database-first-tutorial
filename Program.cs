using DbFirstSample.Models;
using Microsoft.EntityFrameworkCore;

// Supply the connection string at runtime (the scaffolded context was generated
// with --no-onconfiguring, so nothing is baked into the generated files).
var connectionString =
    "Server=localhost;Database=Sales;Trusted_Connection=True;TrustServerCertificate=True";

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(connectionString)
    .Options;

await using var db = new AppDbContext(options);

// Query the scaffolded model with LINQ, pulling the related Customer in one query.
var recentOrders = await db.Orders
    .Where(o => o.Total > 100m)
    .Include(o => o.Customer)
    .OrderByDescending(o => o.OrderDate)
    .Take(10)
    .ToListAsync();

Console.WriteLine($"Orders over $100: {recentOrders.Count}");
foreach (var o in recentOrders)
    Console.WriteLine($"  {o.Customer.DisplayName}: {o.Total:C} on {o.OrderDate:d}");

// A simple aggregate over the same scaffolded DbSet.
var byCustomer = await db.Customers
    .Select(c => new { c.Name, OrderCount = c.Orders.Count, Spent = c.Orders.Sum(o => o.Total) })
    .OrderByDescending(x => x.Spent)
    .ToListAsync();

Console.WriteLine();
foreach (var c in byCustomer)
    Console.WriteLine($"  {c.Name}: {c.OrderCount} orders, {c.Spent:C}");
