using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRipe.Data.Repositories
{
   public class CropRepository : SQLiteDb, IDisposable
   {
      private readonly IRepository<CropDTO> cropRepo;
      private readonly IRepository<ContainerDTO> containerRepo;

      public CropRepository(IRepository<CropDTO> cropRepo)
      {
         this.cropRepo = cropRepo;
      }
      public CropRepository(IRepository<CropDTO> cropRepo, IRepository<ContainerDTO> containerRepo)
      {
         this.cropRepo = cropRepo;
         this.containerRepo = containerRepo;
      }

      public IEnumerable<Crop> GetAllCropsCurrentlyInCultivation()
      {
         return from crop in cropRepo.GetAll()
                join container in containerRepo.GetAll() on crop.ContainerId equals container.Id
                where crop.Stage is "Cultivating"
                select new Crop()
                {
                   Id = crop.Id,
                   Name = crop.Name,
                   Stage = crop.Stage,
                   Area = crop.Area,
                   Type = crop.Type,
                   NumContainers = crop.NumContainers,
                   StorageRequired = crop.StorageRequired,
                   ContainerId = crop.ContainerId,
                   Container = container.Name,

                };
      }
      public IEnumerable<Crop> GetAllCropsAndContainers()
      {
         return from crop in cropRepo.GetAll()
                join container in containerRepo.GetAll() on crop.ContainerId equals container.Id
                select new Crop()
                {
                   Id = crop.Id,
                   Name = crop.Name,
                   Stage = crop.Stage,
                   Area = crop.Area,
                   Type = crop.Type,
                   StorageRequired = crop.StorageRequired,
                   NumContainers = crop.NumContainers,
                   ContainerId = crop.ContainerId,
                   Container = container.Name,
                };
      }
      public IEnumerable<Crop> GetAllCrops()
      {
         return from crop in cropRepo.GetAll()
                select new Crop()
                {
                   Id = crop.Id,
                   Name = crop.Name,
                   Stage = crop.Stage,
                   Area = crop.Area,
                   Type = crop.Type,
                   StorageRequired = crop.StorageRequired,
                   NumContainers = crop.NumContainers,
                   ContainerId = crop.ContainerId,
                };
      }

      public void UpdateCrop(CropDTO _crop)
      {
         cropRepo.Update(_crop);
      }
      public void DeleteCrop(CropDTO _crop)
      {
         cropRepo.Delete(_crop);
      }

      public void AddCrop(CropDTO _crop)
      {
         cropRepo.Add(_crop);
      }


      //using (var cnn = DbConnection())
      //{
      //    cnn.Open();
      //    var newCrop = cnn.Query(
      //        @"INSERT INTO Crops (name, stage, type, area) VALUES (@Name, @Stage, @Type, @Area)", _crop);
      //}
      //_crop.
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
         cropRepo.Dispose();
      }
   }
}
