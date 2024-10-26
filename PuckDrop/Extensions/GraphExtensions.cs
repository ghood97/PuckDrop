using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using static PuckDrop.Services.GraphService;

namespace PuckDrop.Extensions;

public static class GraphExtensions
{
    public static IServiceCollection AddMicrosoftGraph(this IServiceCollection services, IConfiguration config)
    {
        GraphApiConfig graphConfig = config.GetSection("GraphApi").Get<GraphApiConfig>();
        var confidentialClient = ConfidentialClientApplicationBuilder
            .Create(graphConfig.ClientId)
            .WithClientSecret(graphConfig.ClientSecret)
            .WithTenantId(graphConfig.TenantId)
            .Build();

        ClientSecretCredential credential = new(graphConfig.TenantId, graphConfig.ClientId, graphConfig.ClientSecret);

        services.AddScoped(sp =>
        {
            return new GraphServiceClient(credential);
        });

        return services;
    }
}

public struct GraphApiConfig
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string TenantId { get; set; }
}
