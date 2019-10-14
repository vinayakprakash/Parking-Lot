using System.Collections.Generic;
using Dapper;
using ParkingLot.Infra.Configuration;
using ParkingLot.Infra.Dto;
using  System.Data.SQLite;
using Authorization.Model;
using Authorization.Repository;
using ParkingLot.Infra.Mappers;

namespace ParkingLot.Infra.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IAppConfiguration _config;
        private readonly IUserRoleMapper _userRoleMapper;

        public UserProfileRepository(IAppConfiguration config, IUserRoleMapper userRoleMapper)
        {
            _config = config;
            _userRoleMapper = userRoleMapper;
        }

        public List<UserRole> Get()
        {
            using (var conn = new SQLiteConnection(_config.GetConnectionString()))
            {
                conn.Open();
                const string userRoleQuery = "SELECT id, role FROM t_user_profile";
                var userRoles = conn.Query<RoleRow>(userRoleQuery);
                const string userAssociationQuery = "SELECT token_id, role_id FROM t_user_association";
                var userAssociation = conn.Query<UserAssociationRow>(userAssociationQuery);
                return _userRoleMapper.Map(userRoles, userAssociation);
            }
        }
    }
}