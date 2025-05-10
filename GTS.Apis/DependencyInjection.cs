namespace GTS.Apis
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApis(this IServiceCollection services)
        {
            #region CORS
            // var allowedOrgins = configuration.GetSection("AllowedOrgins").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyOrigin()    // Allow requests from any origin
                        .AllowAnyHeader()    // Allow any headers
                        .AllowAnyMethod();   // Allow any HTTP methods (GET, POST, etc.)
                });
            });

            #endregion

            return services;
        }
    }
}
