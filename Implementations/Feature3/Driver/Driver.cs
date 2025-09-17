using System.Text.Json;
using System.Text;

namespace Driver;

public class Driver
{
    private static readonly HttpClient server = new HttpClient();
    public int DriverId { get; set; }
    public int OrderId { get; set; }

    public async void Send()
    {
        while (true)
        {
            var location = new
            {
                DriverId = DriverId,
                OrderId = OrderId,
                Location = "get My Location",
                Timestamp = DateTime.UtcNow
            };

            var json = JsonSerializer.Serialize(location);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                await server.PostAsync("https://localhost:5001/api/driver/location", content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending location: " + ex.Message);
            }

            await Task.Delay(10000);
        }
    }
}    

