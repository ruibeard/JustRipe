using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace JustRipe.Data.Repositories
{
   public class UserRepository : IDisposable
   {
      private readonly IRepository<UserDTO> repositoryUser;
      private readonly IRepository<RoleDTO> repositoryRole;
      private readonly IRepository<UserRoleDTO> repositoryUserRole;

      public UserRepository(IRepository<UserDTO> repositoryUser)
      {
         this.repositoryUser = repositoryUser;
      }

      public UserRepository(IRepository<UserDTO> repositoryUser, IRepository<RoleDTO> repositoryRole, IRepository<UserRoleDTO> repositoryUserRole)
      {
         this.repositoryUser = repositoryUser;
         this.repositoryRole = repositoryRole;
         this.repositoryUserRole = repositoryUserRole;
      }

      public IEnumerable<User> GetAllUsers()
      {
         return from user in repositoryUser.GetAll()
                select new User()
                {
                   Id = user.Id,
                   Username = user.Username,
                   Password = user.Password,
                   FirstName = user.FirstName,
                   LastName = user.LastName,
                   FullName = user.FirstName + " " + user.LastName,
                   Email = user.Email,
                   PhoneNumber = user.PhoneNumber,
                   Address = user.Address,
                   DateOfBirth = user.DateOfBirth,
                   AnnualWage = user.AnnualWage,
                };
      }

      public IEnumerable<User> CheckUserCredentials(string _username, string _password)
      {
         return from user in repositoryUser.GetAll()
                join user_role in repositoryUserRole.GetAll() on user.Id equals user_role.UserId
                join role in repositoryRole.GetAll() on user_role.RoleId equals role.Id
                where user.Username == _username
                where user.Password == _password
                select new User()
                {
                   Id = user.Id,
                   FirstName = user.FirstName,
                   Role = role.Name,
                   PhoneNumber = user.PhoneNumber,
                };
      }

      public IEnumerable<User> GetAllLabourUsers()
      {
         return from user in repositoryUser.GetAll()
                join u_r in repositoryUserRole.GetAll() on user.Id equals u_r.UserId
                join role in repositoryRole.GetAll() on u_r.RoleId equals role.Id
                where role.Name is "labourer"
                select new User()
                {
                   Id = user.Id,
                   FirstName = user.FirstName,
                   Role = role.Name
                };
      }

      public void UpdateUser(UserDTO _user)
      {
         repositoryUser.Update(_user);
      }
      public void AddUser(UserDTO _user)
      {
         repositoryUser.Add(_user);
      }
      public void DeleteUser(UserDTO _user)
      {
         repositoryUser.Delete(_user);
      }
      public void Dispose()
      {
         repositoryUser.Dispose();
      }
   }
}
