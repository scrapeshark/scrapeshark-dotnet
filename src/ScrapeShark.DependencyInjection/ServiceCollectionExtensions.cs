using Microsoft.Extensions.DependencyInjection;

namespace ScrapeShark.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddScrapeShark(this IServiceCollection services, string apiKey)
    {
        services.Configure<ScrapeSharkOptions>(options => options.ApiKey = apiKey);

        services.AddScoped<IScrapeSharkClient, ScrapeSharkClient>();

        return services;
    }
}
