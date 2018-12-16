using JustRipe.Data.DTOs;
using System;

namespace JustRipe.Data.Repositories
{
   public class UserRoleRepository : IDisposable
   {
      private readonly IRepository<UserDTO> repositoryUser;
      private readonly IRepository<RoleDTO> repositoryRole;
      private readonly IRepository<UserRoleDTO> repositoryUserRole;

      public UserRoleRepository(IRepository<UserDTO> repositoryUser, IRepository<RoleDTO> repositoryRole, IRepository<UserRoleDTO> repositoryUserRole)
      {
         this.repositoryUser = repositoryUser;
         this.repositoryRole = repositoryRole;
         this.repositoryUserRole = repositoryUserRole;
      }

      public void UpdateUserRole(UserRoleDTO _userRole)
      {
         repositoryUserRole.Update(_userRole);
      }
      public void AddUserRole(UserRoleDTO _userRole)
      {
         repositoryUserRole.Add(_userRole);
      }
      public void DeleteUserRole(UserRoleDTO _userRole)
      {
         repositoryUserRole.Delete(_userRole);
      }
      public void Dispose()
      {
         repositoryUserRole.Dispose();
      }
   }
}
