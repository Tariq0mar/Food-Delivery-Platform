namespace Domain.Entities;

public class Message
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; }
    public string SenderId { get; set; }
    public string SenderRole { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeliveredAt { get; set; }
    public DateTime? ReadAt { get; set; }
    public bool IsSystem { get; set; } = false;
}