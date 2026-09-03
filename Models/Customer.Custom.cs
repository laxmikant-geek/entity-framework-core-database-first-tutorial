namespace DbFirstSample.Models;

// Hand-written additions to the scaffolded Customer entity.
// Lives in its own file so `dotnet ef dbcontext scaffold --force` never overwrites it.
public partial class Customer
{
    public string DisplayName => Email is null ? Name : $"{Name} <{Email}>";
}
