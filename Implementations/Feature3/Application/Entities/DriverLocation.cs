namespace Domain.Entities;

public class DriverLocation
{
    public int DriverId { get; set; }
    public int OrderId { get; set; }
    public string Location { get; set; }
    public DateTime Timestamp { get; set; }
}