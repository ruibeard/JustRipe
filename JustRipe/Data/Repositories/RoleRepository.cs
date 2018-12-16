using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRipe.Data.Repositories
{
   public class RoleRepository : IDisposable
   {
      private readonly IRepository<RoleDTO> roleRepo;

      public RoleRepository(IRepository<RoleDTO> roleRepo)
      {
         this.roleRepo = roleRepo;
      }

      public IEnumerable<Role> GetAllRoles()
      {
         return from role in roleRepo.GetAll()
                select new Role()
                {
                   Id = role.Id,
                   Name = role.Name,
                };
      }

      public void UpdateRole(RoleDTO _role)
      {
         roleRepo.Update(_role);
      }
      public void DeleteRole(RoleDTO _role)
      {
         roleRepo.Delete(_role);
      }

      public void AddRole(RoleDTO _role)
      {
         roleRepo.Add(_role);
      }

      public void Dispose()
      {
         roleRepo.Dispose();
      }
   }
}
