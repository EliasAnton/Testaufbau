using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Testaufbau.Models;

namespace Client;

public class LocalClient
{

    public static async Task RunUserPrompts()
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await client.GetAsync("http://localhost:80/WeatherForecast");
        if (response.StatusCode is not HttpStatusCode.OK)
        {
            Console.WriteLine("Not Successful, StatusCode was " + response.StatusCode);
        }

        var responseObject = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
        Console.WriteLine(responseObject!.ToString());
    }
}