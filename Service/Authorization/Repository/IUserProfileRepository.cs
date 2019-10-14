using System.Collections.Generic;
using Authorization.Model;

namespace Authorization.Repository
{
    public interface IUserProfileRepository
    {
        List<UserRole> Get();
    }
}
