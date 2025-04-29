namespace Catalog.API.Configurations;

public static class ApplicationExtensions
{
    public static void UseInfrastructure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("Allow");
        
        if (env.IsProduction())
        {
            app.UseHttpsRedirection();
        }
        else
        {
            app.UseApplicationSwagger();
        }
        
        app.UseRouting();
        app.UseStaticFiles();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            endpoints.MapDefaultControllerRoute();
        });
    }
}