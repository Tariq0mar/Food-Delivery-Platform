namespace Domain.Entities;

public class Chat
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CustomerId { get; set; }
    public string? AgentId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ClosedAt { get; set; }
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}