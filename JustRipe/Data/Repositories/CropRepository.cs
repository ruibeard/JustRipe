using System;
using System.Collections.Generic;
using System.Linq;
using JustRipe.Data.DTOs;
using JustRipe.Models;

namespace JustRipe.Data.Repositories
{
    public class CropRepository : IDisposable
    {
        private readonly IRepository<CropDTO> repository;
        private readonly IRepository<UserDTO> repositoryUser;

        public CropRepository(
            IRepository<CropDTO> repository,
            IRepository<UserDTO> repositoryUser)
        {
            this.repository = repository;
            this.repositoryUser = repositoryUser;
        }

        public IEnumerable<Crop> GetAllCrops()
        {
            return from crop in repository.GetAll()
                   select new Crop()
                   {
                       Name = crop.Name,
                       Stage = crop.Stage,
                       Area = crop.Area,
                       Type = crop.Type,
                   };

            //return repository.GetAll().Select(crop => new Crop()
            //{
            //    Name = crop.Name,
            //    Stage = crop.Stage,
            //    Area = crop.Area,
            //    Type = crop.Type,
            //});
        }

        //public IEnumerable<Crop> GetCropsByUser(string username)
        //{
        //    var crops =
        //        from crop in repository.GetAll()
        //        join user in repositoryUser.SearchFor(x => x.UserName == username) on crop.Name equals user.UserName
        //        where user.UserName == username
        //        select crop;

        //    return
        //    from crop in repository.GetAll()
        //    join user in repositoryUser.GetAll() on crop.Name equals user.UserName
        //    where user.UserName == username
        //    select crop;


        //}

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
