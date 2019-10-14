using Authorization.Validate;

namespace ParkingLotApi.Service
{
    public class LoginService: ILoginService
    {
        private readonly IAuthenticator _authenticator;
        private readonly IAuthorizer _authorizer;
        
        public LoginService(IAuthenticator authenticator,IAuthorizer authorizer)
        {
            _authenticator = authenticator;
            _authorizer = authorizer;
        }

        public string GetUserRole(string tokenId)
        {
            var userId = _authenticator.AuthenticateWithFirebase(tokenId);
            return _authorizer.AuthorizeUser(userId);
        }
    }
}
