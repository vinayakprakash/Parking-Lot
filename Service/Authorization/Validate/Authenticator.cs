using FirebaseAdmin.Auth;

namespace Authorization.Validate
{
    public class Authenticator : IAuthenticator
    {
        public string AuthenticateWithFirebase(string userToken)
        {
            var decodedToken = FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(userToken).Result;
            var userId = decodedToken.Uid;
            return userId;
        }
    }
}