namespace Domain.Entities;

public record Customer
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Email { get; set; }
    public string FullName { get; set; }
    public string PasswordHash { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; } = new();
}