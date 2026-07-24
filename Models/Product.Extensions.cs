namespace DbFirstSample.Models;

// Your own members live in partial classes in separate files,
// so re-scaffolding with --force never overwrites them.
public partial class Product
{
    public decimal DiscountedPrice => ListPrice * 0.9m;
}
