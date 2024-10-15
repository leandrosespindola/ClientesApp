namespace ClientesApp.API.Extensions
{
    public static class CorsConfigExtension
    {
        public static IServiceCollection AddCorsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var origins = configuration.GetSection("CorsConfigSettings:Origins").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy("ClientesAppPolicy", builder =>
                {
                    builder.WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors("ClientesAppPolicy");
            return app;
        }
    }
}
