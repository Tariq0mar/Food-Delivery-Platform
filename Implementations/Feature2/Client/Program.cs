class Program
{
    static async Task Main()
    {
        var client = new HttpClient();
        var orderId = 123;
        var pollingInterval = 30000;

        while (true)
        {
            var response = await client.GetAsync($"https://localhost:5001/api/orders/{orderId}/status");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Order status: {content}");
            }

            await Task.Delay(pollingInterval);
        }
    }
}