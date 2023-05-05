using GraphQL.Instrumentation;
using GraphQL.Types;

namespace Testaufbau.DataAccess.GraphQl;

public class GraphQlSchema : Schema
{
    public GraphQlSchema(IServiceProvider provider)
        : base(provider)
    {
        Query = (GraphQlQuery)provider.GetService(typeof(GraphQlQuery))! ?? throw new InvalidOperationException();
        //Mutation = (GraphQlMutation)provider.GetService(typeof(GraphQlMutation))! ?? throw new InvalidOperationException();
        FieldMiddleware.Use(new InstrumentFieldsMiddleware());
    }
}