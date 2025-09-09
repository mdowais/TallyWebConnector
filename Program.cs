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

            // Map minimal API endpoints
            MapCoreEndpoints(app);
            MapVoucherEndpoints(app);
            MapLedgerEndpoints(app);
            MapStockItemEndpoints(app);
            MapStockGroupEndpoints(app);
            MapCompanyEndpoints(app);
            MapGroupEndpoints(app);
            MapGodownEndpoints(app);
            MapUnitEndpoints(app);
            MapGstEndpoints(app);
            MapTdsEndpoints(app);
            MapReportEndpoints(app);
            MapEditLogEndpoints(app);

            app.Run();
        }

        private static void MapCoreEndpoints(WebApplication app)
        {
            app.MapGet("/api/core/check", async (TallyService tallyService) =>
            {
                return await tallyService.CheckAsync();
            })
            .WithName("CheckTallyConnection")
            .WithTags("Core");

            app.MapGet("/api/core/info", async (TallyService tallyService) =>
            {
                return await tallyService.GetLicenseInfoAsync();
            })
            .WithName("GetTallyInfo")
            .WithTags("Core");
        }

        private static void MapVoucherEndpoints(WebApplication app)
        {
            app.MapGet("/api/vouchers", async (VoucherService service) =>
            {
                return await service.GetVouchersAsync();
            })
            .WithName("GetVouchers")
            .WithTags("Vouchers");

            app.MapGet("/api/vouchers/{id}", async (string id, VoucherService service) =>
            {
                return await service.GetVoucherByIdAsync(id);
            })
            .WithName("GetVoucherById")
            .WithTags("Vouchers");

            app.MapGet("/api/voucher-types", async (VoucherService service) =>
            {
                return await service.GetVoucherTypesAsync();
            })
            .WithName("GetVoucherTypes")
            .WithTags("Vouchers");
        }

        private static void MapLedgerEndpoints(WebApplication app)
        {
            app.MapGet("/api/ledgers", async (LedgerService service) =>
            {
                return await service.GetLedgersAsync();
            })
            .WithName("GetLedgers")
            .WithTags("Ledgers");

            app.MapGet("/api/ledgers/{id}", async (string id, LedgerService service) =>
            {
                return await service.GetLedgerByIdAsync(id);
            })
            .WithName("GetLedgerById")
            .WithTags("Ledgers");

            app.MapGet("/api/ledgers/{id}/balance", async (string id, LedgerService service) =>
            {
                return await service.GetLedgerBalanceAsync(id);
            })
            .WithName("GetLedgerBalance")
            .WithTags("Ledgers");
        }

        private static void MapStockItemEndpoints(WebApplication app)
        {
            app.MapGet("/api/stock-items", async (StockItemService service) =>
            {
                return await service.GetStockItemsAsync();
            })
            .WithName("GetStockItems")
            .WithTags("Stock Items");

            app.MapGet("/api/stock-items/{id}", async (string id, StockItemService service) =>
            {
                return await service.GetStockItemByIdAsync(id);
            })
            .WithName("GetStockItemById")
            .WithTags("Stock Items");

            app.MapGet("/api/stock-items/{id}/balance", async (string id, StockItemService service) =>
            {
                return await service.GetStockItemBalanceAsync(id);
            })
            .WithName("GetStockItemBalance")
            .WithTags("Stock Items");
        }

        private static void MapStockGroupEndpoints(WebApplication app)
        {
            app.MapGet("/api/stock-groups", async (StockGroupService service) =>
            {
                return await service.GetStockGroupsAsync();
            })
            .WithName("GetStockGroups")
            .WithTags("Stock Groups");

            app.MapGet("/api/stock-groups/{id}", async (string id, StockGroupService service) =>
            {
                return await service.GetStockGroupByIdAsync(id);
            })
            .WithName("GetStockGroupById")
            .WithTags("Stock Groups");
        }

        private static void MapCompanyEndpoints(WebApplication app)
        {
            app.MapGet("/api/companies", async (CompanyService service) =>
            {
                return await service.GetCompaniesAsync();
            })
            .WithName("GetCompanies")
            .WithTags("Companies");

            app.MapGet("/api/companies/{id}", async (string id, CompanyService service) =>
            {
                return await service.GetCompanyByIdAsync(id);
            })
            .WithName("GetCompanyById")
            .WithTags("Companies");

            app.MapGet("/api/companies/current", async (CompanyService service) =>
            {
                return await service.GetCurrentCompanyAsync();
            })
            .WithName("GetCurrentCompany")
            .WithTags("Companies");
        }

        private static void MapGroupEndpoints(WebApplication app)
        {
            app.MapGet("/api/groups", async (GroupService service) =>
            {
                return await service.GetGroupsAsync();
            })
            .WithName("GetGroups")
            .WithTags("Groups");

            app.MapGet("/api/groups/{id}", async (string id, GroupService service) =>
            {
                return await service.GetGroupByIdAsync(id);
            })
            .WithName("GetGroupById")
            .WithTags("Groups");
        }

        private static void MapGodownEndpoints(WebApplication app)
        {
            app.MapGet("/api/godowns", async (GodownService service) =>
            {
                return await service.GetGodownsAsync();
            })
            .WithName("GetGodowns")
            .WithTags("Godowns");

            app.MapGet("/api/godowns/{id}", async (string id, GodownService service) =>
            {
                return await service.GetGodownByIdAsync(id);
            })
            .WithName("GetGodownById")
            .WithTags("Godowns");
        }

        private static void MapUnitEndpoints(WebApplication app)
        {
            app.MapGet("/api/units", async (UnitService service) =>
            {
                return await service.GetUnitsAsync();
            })
            .WithName("GetUnits")
            .WithTags("Units");

            app.MapGet("/api/units/{id}", async (string id, UnitService service) =>
            {
                return await service.GetUnitByIdAsync(id);
            })
            .WithName("GetUnitById")
            .WithTags("Units");
        }

        private static void MapGstEndpoints(WebApplication app)
        {
            app.MapGet("/api/gst/reports", async (GstService service) =>
            {
                return await service.GetGstReportsAsync();
            })
            .WithName("GetGstReports")
            .WithTags("GST");

            app.MapGet("/api/gst/returns", async (GstService service) =>
            {
                return await service.GetGstReturnsAsync();
            })
            .WithName("GetGstReturns")
            .WithTags("GST");

            app.MapGet("/api/gst/gstr1", async (DateTime fromDate, DateTime toDate, GstService service) =>
            {
                return await service.GetGstr1Async(fromDate, toDate);
            })
            .WithName("GetGstr1")
            .WithTags("GST");

            app.MapGet("/api/gst/gstr3b", async (DateTime fromDate, DateTime toDate, GstService service) =>
            {
                return await service.GetGstr3bAsync(fromDate, toDate);
            })
            .WithName("GetGstr3b")
            .WithTags("GST");
        }

        private static void MapTdsEndpoints(WebApplication app)
        {
            app.MapGet("/api/tds/reports", async (TdsService service) =>
            {
                return await service.GetTdsReportsAsync();
            })
            .WithName("GetTdsReports")
            .WithTags("TDS");

            app.MapGet("/api/tds/returns", async (TdsService service) =>
            {
                return await service.GetTdsReturnsAsync();
            })
            .WithName("GetTdsReturns")
            .WithTags("TDS");

            app.MapGet("/api/tds/quarterly", async (int quarter, int year, TdsService service) =>
            {
                return await service.GetTdsQuarterlyAsync(quarter, year);
            })
            .WithName("GetTdsQuarterly")
            .WithTags("TDS");
        }

        private static void MapReportEndpoints(WebApplication app)
        {
            app.MapGet("/api/reports/balance-sheet", async (DateTime? asOnDate, ReportService service) =>
            {
                return await service.GetBalanceSheetAsync(asOnDate);
            })
            .WithName("GetBalanceSheet")
            .WithTags("Reports");

            app.MapGet("/api/reports/profit-loss", async (DateTime? fromDate, DateTime? toDate, ReportService service) =>
            {
                return await service.GetProfitAndLossAsync(fromDate, toDate);
            })
            .WithName("GetProfitAndLoss")
            .WithTags("Reports");

            app.MapGet("/api/reports/trial-balance", async (DateTime? asOnDate, ReportService service) =>
            {
                return await service.GetTrialBalanceAsync(asOnDate);
            })
            .WithName("GetTrialBalance")
            .WithTags("Reports");

            app.MapGet("/api/reports/cash-flow", async (DateTime? fromDate, DateTime? toDate, ReportService service) =>
            {
                return await service.GetCashFlowAsync(fromDate, toDate);
            })
            .WithName("GetCashFlow")
            .WithTags("Reports");
        }

        private static void MapEditLogEndpoints(WebApplication app)
        {
            app.MapGet("/api/edit-log", async (DateTime? fromDate, DateTime? toDate, EditLogService service) =>
            {
                return await service.GetEditLogAsync(fromDate, toDate);
            })
            .WithName("GetEditLog")
            .WithTags("Edit Log");

            app.MapGet("/api/edit-log/{entityType}/{entityId}", async (string entityType, string entityId, EditLogService service) =>
            {
                return await service.GetEditLogByEntityAsync(entityType, entityId);
            })
            .WithName("GetEditLogByEntity")
            .WithTags("Edit Log");

            app.MapGet("/api/edit-log/user-activity", async (string? userId, EditLogService service) =>
            {
                return await service.GetUserActivityAsync(userId);
            })
            .WithName("GetUserActivity")
            .WithTags("Edit Log");
        }
    }
}