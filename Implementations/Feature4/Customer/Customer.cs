using System.Net.Http.Json;
using Domain.Entities;

namespace Customer;

public class Customer
{
    private static readonly HttpClient server = new HttpClient();

    public int CustomerId { get; set; }

    async void Send(Order order)
    {
        try
        {
            var response = await server.PostAsJsonAsync("orders", order);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Order sent successfully!");
            }
            else
            {
                Console.WriteLine($"Failed to send order. Status: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending order: {ex.Message}");
        }
    }
}
