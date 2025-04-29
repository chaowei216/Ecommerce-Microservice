using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Catalog.API.Configurations;

public static class SwaggerConfig
{
    public static void RegisterSwaggerModule(this IServiceCollection services)
    {
        // Config api versioning
        services.AddApiVersioning(x =>
        {
            x.DefaultApiVersion = new ApiVersion(1, 0);
            x.AssumeDefaultVersionWhenUnspecified = true;
            x.ReportApiVersions = true;
        });
        
        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });
        
        services.AddSwaggerGen(c =>
        {
            // Set Description Swagger
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Catalog.Api",
                Version = "v1",
                Description = "Catalog.Api Endpoints",
            });
            
            c.DescribeAllParametersInCamelCase();
            
            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
        services.AddSwaggerGenNewtonsoftSupport();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseApplicationSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger(c =>
        {
            c.RouteTemplate = "{documentName}/api-docs";
        });
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/v1/api-docs", "Catalog.Api v1");
            c.RoutePrefix = "swagger";
        });

        return app;
    }
}