using Testaufbau.DataAccess.Models;

namespace GraphQLClient;

public class GraphQlClient
{
    private readonly HttpClient _httpClient;

    public GraphQlClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<Article> GetAllArticles()
    {
        //call the /graphql endpoint defined in the GraphQService project
        throw new NotImplementedException();
    }

    //write a client that talks to the /graphql endpoint defined in the GraphQService project with some queries
    //the data models used can be found in Testaufbau/DataAccess/Models
    //the client should be able to send a query and receive a response
    //the response should be deserialized into a C# object
    //the C# object should be printed to the console
    
    
    
}