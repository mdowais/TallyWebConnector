using TallyConnector.Services;
using TallyWebConnector.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TallyWebConnector.Middleware
{
    public class CompanySelectionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        public const string CompanyHeader = "X-Company-Id";
        public const string CompanyContextKey = "SelectedCompanyId";

        public CompanySelectionMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue(CompanyHeader, out var companyId))
            {
                context.Items[CompanyContextKey] = companyId.ToString();
                var companyLogic = context.RequestServices.GetService(typeof(CompanyLogic)) as CompanyLogic;
                var tallyService = context.RequestServices.GetService(typeof(TallyService)) as TallyService;
                if (companyLogic != null && tallyService != null)
                {
                    var company = await companyLogic.GetCompanyByIdAsync(companyId.ToString());
                    if (company != null)
                    {
                        tallyService.SetCompany(company as TallyConnector.Core.Models.Company);
                    }
                }
            }
            await _next(context);
        }
    }
}
