namespace Authorization.Validate
{
    public interface IAuthorizer
    {
        string AuthorizeUser(string userToken);

    }
}