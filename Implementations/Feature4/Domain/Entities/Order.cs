namespace Domain.Entities;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Description { get; set; }
}