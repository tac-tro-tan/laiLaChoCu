using laiLaChoCu.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace laiLaChoCu.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, DataContext dataContext, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var accountId = jwtUtils.ValidateJwtToken(token);
            if (accountId != null)
            {
                // attach account to context on successful jwt validation
                context.Items["Account"] = dataContext.Accounts.Include(x => x.Roles).Where(x => x.Id == accountId).FirstOrDefault();
            }

            await _next(context);
        }
    }
}
