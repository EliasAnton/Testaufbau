using System.Globalization;
using System.Net.Http.Headers;
using Testaufbau.DataAccess.Models;

namespace RestClient;

public class LocalClient
{

    public static async Task RunUserPrompts()
    {
        string continuePrompt;
        do
        {
            Console.WriteLine("Welcome to the REST client");

            Console.WriteLine("Take:");
            var take = int.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

            Console.WriteLine("Skip:");
            var skip = int.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

            // Send REST request and receive response
            List<Article> response = await CallService(take, skip);

            Console.WriteLine("Found " + response.Count + " results:");
            foreach (var article in response)
            {
                Console.WriteLine(article.Id);
                Console.WriteLine(article.Name);
                Console.WriteLine("--------------------");
            }
            
            Console.WriteLine("Continue? (y/n)");
            continuePrompt = Console.ReadLine()!;
        } while (continuePrompt == "y");
    }

    private static async Task<List<Article>> CallService(int take, int skip)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var requestUri = $"https://localhost:7123/Rest/Articles?take={take}&skip={skip}";
        var response = await client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        var responseObject = await response.Content.ReadAsAsync<List<Article>>();
        return responseObject;
    }

}