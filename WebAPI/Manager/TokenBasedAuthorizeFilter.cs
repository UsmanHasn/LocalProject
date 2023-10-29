using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Service.Interface;
using Data.Interface;

public class TokenBasedAuthorizeFilter : IAuthorizationFilter
{
    private readonly IUserService _userService;

    public TokenBasedAuthorizeFilter(IUserService userService)
    {
        _userService = userService;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Get the JWT token from the request
        string token = GetTokenFromRequest(context.HttpContext.Request.Headers);

        // Check if the token is valid and not revoked
        if (!IsTokenValid(token))
        {
            // Token is not valid or revoked, return Unauthorized
            context.Result = new UnauthorizedResult();
        }
    }

    private string GetTokenFromRequest(IHeaderDictionary headers)
    {
        StringValues authorizationHeader;
        if (headers.TryGetValue("Authorization", out authorizationHeader))
        {
            string headerValue = authorizationHeader.ToString();
            if (headerValue.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                // Extract the token part after "Bearer "
                return headerValue.Substring("Bearer ".Length).Trim();
            }
        }
        return null; // Token not found in the headers
    }

    private bool IsTokenValid(string token)
    {

        var data = _userService.GetrevokedTokenModel(null, token);
        if (data != null) {
            if (data.IsActive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false; //case for first run case when data is empty or null
        }
    }
}
