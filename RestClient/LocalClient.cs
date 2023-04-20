using System.Net.Http.Headers;
using Testaufbau.DataAccess.SharedModels;

namespace RestClient;

public class LocalClient
{

    public async Task RunUserPrompts()
    {
        do
        {
            Console.WriteLine("Welcome to the REST client");

            Console.WriteLine("Take:");
            var take = int.Parse(Console.ReadLine());

            Console.WriteLine("Skip:");
            var skip = int.Parse(Console.ReadLine());

            // Send REST request and receive response
            List<Article> response = await CallService(take, skip);

            Console.WriteLine("Found " + response.Count + " results");

        } while (true);
    }

    private async Task<List<Article>> CallService(int take, int skip)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var requestUri = $"https://localhost:7273/Products?take={take}&skip={skip}";
        var response = await client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        var responseObject = await response.Content.ReadAsAsync<List<Article>>();
        return responseObject;
    }

}