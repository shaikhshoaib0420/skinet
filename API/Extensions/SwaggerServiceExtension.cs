public static class SwaggerServiceExtension {
    public static IServiceCollection AddSwaggerService(this IServiceCollection services) 
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    public static WebApplication UseSwaggerService(this WebApplication app) {
        app.UseSwagger();
        app.UseSwaggerUI(c => {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
        return app;
    } 
}