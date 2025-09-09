using Microsoft.AspNetCore.Http;

namespace TallyWebConnector.Context
{
    public static class CompanyContextAccessor
    {
        public static string? GetSelectedCompanyId(HttpContext context)
        {
            if (context.Items.TryGetValue(Middleware.CompanySelectionMiddleware.CompanyContextKey, out var value))
            {
                return value as string;
            }
            return null;
        }
    }
}
