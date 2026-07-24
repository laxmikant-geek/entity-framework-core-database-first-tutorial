using DbFirstSample.Models;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<AdventureWorksContext>()
    .UseSqlServer("<your connection string>")
    .Options;

using var context = new AdventureWorksContext(options);
var products = await context.Products.AsNoTracking().Take(5).ToListAsync();
foreach (var p in products)
    Console.WriteLine($"{p.ProductId}  {p.Name}  {p.ListPrice:0.00}");
