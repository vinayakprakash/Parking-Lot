namespace Authorization.Validate
{
    public interface IAuthenticator
    {
        string AuthenticateWithFirebase(string userToken);
    }
}