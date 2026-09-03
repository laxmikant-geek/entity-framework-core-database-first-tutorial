using System.ComponentModel.DataAnnotations;

namespace DbFirstSample.Models;

// Representative of a scaffolded entity (dotnet ef dbcontext scaffold --data-annotations).
// Generated classes are partial — keep hand-written members in Customer.Custom.cs.
public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [MaxLength(120)]
    public string Name { get; set; } = null!;

    [MaxLength(200)]
    public string? Email { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
