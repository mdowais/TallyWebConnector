using TallyConnector.Services;
using TallyWebConnector.Services;

namespace TallyWebConnector
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "API Key needed to access the endpoints. X-Api-Key: {apiKey}",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Name = "X-Api-Key",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "ApiKeyScheme"
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            // Configure TallyService with settings from configuration
            builder.Services.AddScoped<TallyService>(provider =>
            {
                var config = provider.GetRequiredService<IConfiguration>();
                var host = config.GetValue<string>("TallyHost") ?? "http://localhost";
                var port = config.GetValue<int>("TallyPort", 9000);
                return new TallyService(host, port);
            });

            // Register business logic services
            builder.Services.AddScoped<VoucherLogic>();
            builder.Services.AddScoped<LedgerLogic>();
            builder.Services.AddScoped<StockItemLogic>();
            builder.Services.AddScoped<StockGroupLogic>();
            builder.Services.AddScoped<CompanyLogic>();
            builder.Services.AddScoped<GroupLogic>();
            builder.Services.AddScoped<GodownLogic>();
            builder.Services.AddScoped<UnitLogic>();
            builder.Services.AddScoped<GstLogic>();
            builder.Services.AddScoped<TdsLogic>();
            builder.Services.AddScoped<ReportLogic>();
            builder.Services.AddScoped<EditLogLogic>();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // API Key Authentication
            app.UseMiddleware<ApiKeyMiddleware>();

            // Company Selection Middleware
            app.UseMiddleware<TallyWebConnector.Middleware.CompanySelectionMiddleware>();

            // Map controllers
            app.MapControllers();

            app.Run();
        }
    }
}