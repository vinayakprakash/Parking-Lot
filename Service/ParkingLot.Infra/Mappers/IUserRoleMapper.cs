using System.Collections.Generic;
using Authorization.Model;
using ParkingLot.Infra.Dto;

namespace ParkingLot.Infra.Mappers
{
    public interface IUserRoleMapper
    {
        List<UserRole> Map(IEnumerable<RoleRow> roleRows,
            IEnumerable<UserAssociationRow> userAssociationRows);
    }
}