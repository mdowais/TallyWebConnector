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
            builder.Services.AddSwaggerGen();

            // Configure TallyService with settings from configuration
            builder.Services.AddScoped<TallyService>(provider =>
            {
                var config = provider.GetRequiredService<IConfiguration>();
                var host = config.GetValue<string>("TallyHost") ?? "http://localhost";
                var port = config.GetValue<int>("TallyPort", 9000);
                return new TallyService(host, port);
            });

            // Register business logic services
            builder.Services.AddScoped<VoucherService>();
            builder.Services.AddScoped<LedgerService>();
            builder.Services.AddScoped<StockItemService>();
            builder.Services.AddScoped<StockGroupService>();
            builder.Services.AddScoped<CompanyService>();
            builder.Services.AddScoped<GroupService>();
            builder.Services.AddScoped<GodownService>();
            builder.Services.AddScoped<UnitService>();
            builder.Services.AddScoped<GstService>();
            builder.Services.AddScoped<TdsService>();
            builder.Services.AddScoped<ReportService>();
            builder.Services.AddScoped<EditLogService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Map controllers
            app.MapControllers();

            app.Run();
        }
    }
}