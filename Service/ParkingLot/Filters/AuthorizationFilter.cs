using Authorization.Validate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ParkingLotApi.Filters
{
    public class Authorization : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["token"];
            string userId = null;
            if (!string.IsNullOrEmpty(token))
            {
                userId = new Authenticator().AuthenticateWithFirebase(token);
            }
            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new UnauthorizedResult();
            }
        }
        

    }
}
