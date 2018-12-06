using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRipe.Data.Repositories
{
   public class TimeTableRepository : SQLiteDb, IDisposable
   {
      private readonly IRepository<CropDTO> cropRepo;

      public TimeTableRepository(IRepository<CropDTO> cropRepo)
      {
         this.cropRepo = cropRepo;
      }
     

      public IEnumerable<Crop> GetAllCropsCurrentlyInCultivation()
      {
         return from crop in cropRepo.GetAll()
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




      public void Dispose()
      {
         cropRepo.Dispose();
      }
   }
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