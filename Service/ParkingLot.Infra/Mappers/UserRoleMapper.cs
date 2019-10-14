using System.Collections.Generic;
using System.Linq;
using Authorization.Model;
using ParkingLot.Infra.Dto;

namespace ParkingLot.Infra.Mappers
{
    public class UserRoleMapper : IUserRoleMapper
    {
        public List<UserRole> Map(IEnumerable<RoleRow> roleRows,
            IEnumerable<UserAssociationRow> userAssociationRows)
        {
            var roles = roleRows.ToDictionary(x => x.id, x => x.role);
            return userAssociationRows.Select(userAssociationRow => new UserRole()
                {UserId = userAssociationRow.token_id, Role = roles[userAssociationRow.role_id]}).ToList();
        }
    }
}