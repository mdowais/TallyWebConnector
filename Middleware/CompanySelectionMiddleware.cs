using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TallyWebConnector.Middleware
{
    public class CompanySelectionMiddleware
    {
        private readonly RequestDelegate _next;
        public const string CompanyHeader = "X-Company-Id";
        public const string CompanyContextKey = "SelectedCompanyId";

        public CompanySelectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue(CompanyHeader, out var companyId))
            {
                context.Items[CompanyContextKey] = companyId.ToString();
            }
            await _next(context);
        }
    }
}
