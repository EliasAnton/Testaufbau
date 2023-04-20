using GraphQLClient;

var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:7052/graphql") };
var client = new GraphQlClient(httpClient);

