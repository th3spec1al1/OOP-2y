namespace Lab5.Presentation.Http;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationHttp(
        this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }
}