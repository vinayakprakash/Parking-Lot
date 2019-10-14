using System.Linq;
using Authorization.Repository;

namespace Authorization.Validate
{
    public class Authorizer : IAuthorizer
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public Authorizer(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public string AuthorizeUser(string userId)
        {
            return _userProfileRepository.Get().Where(x => x.UserId == userId).Select(x => x.Role).FirstOrDefault();
        }
    }
}