using System.Reflection;
using Catalog.Application;
using Catalog.Application.Features.Product.Queries.GetAllProducts;
using Catalog.Infrastructure;
using Google.Apis.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Catalog.API.Configurations;

public static class ServiceExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers().AddNewtonsoftJson(o =>
        {
            o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            o.SerializerSettings.ContractResolver = new NewtonsoftJsonContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            o.SerializerSettings.Converters.Add(new StringEnumConverter()
            {
                AllowIntegerValues = true
            });
            o.SerializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
        });
        
        var assemlies = new Assembly[] { typeof(GetAllProductsQuery).Assembly };
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemlies));
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        services.AddHttpClient();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
        services.RegisterSwaggerModule();
        services.AddInfrastructureServices();
        services.AddApplicationServices();
        return services;
    }
}