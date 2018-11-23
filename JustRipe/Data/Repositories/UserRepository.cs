﻿using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRipe.Data.Repositories
{
    public class UserRepository : SQLiteDb, IDisposable
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
                       Name = user.Name,

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
                       Name = user.Name,
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

        public void Dispose()
        {
            repositoryUser.Dispose();
        }
    }
}
