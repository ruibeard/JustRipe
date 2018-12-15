using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRipe.Data.Repositories
{
   public class CropRepository : IDisposable
   {
      private readonly IRepository<CropDTO> cropRepo;
      private readonly IRepository<ProductDTO> productRepo;
      private readonly IRepository<CategoryDTO> categoryRepo;

      public CropRepository(IRepository<CropDTO> cropRepo)
      {
         this.cropRepo = cropRepo;
      }
      public CropRepository(IRepository<CropDTO> _cropRepo, IRepository<ProductDTO> _productRepo, IRepository<CategoryDTO> _categoryRepo)
      {
         cropRepo = _cropRepo;
         categoryRepo = _categoryRepo;
         productRepo = _productRepo;
      }

      public IEnumerable<Crop> GetAllCropsCurrentlyInCultivation()
      {
         return from crop in cropRepo.GetAll()
                join prod in productRepo.GetAll() on crop.ProductId equals prod.Id
                join cat in categoryRepo.GetAll() on prod.CategoryId equals cat.Id
                where crop.Stage is "Cultivating"
                where cat.Name is "Container"
                select new Crop()
                {
                   Id = crop.Id,
                   Name = crop.Name,
                   Stage = crop.Stage,
                   Area = crop.Area,
                   Type = crop.Type,
                   NumContainers = crop.NumContainers,
                   StorageRequired = crop.StorageRequired,
                   ProductId = crop.ProductId,
                   ProductName = prod.Name,
                };
      }
      public IEnumerable<Crop> GetAllCropsAndContainers()
      {
         return from crop in cropRepo.GetAll()
                join prod in productRepo.GetAll() on crop.ProductId equals prod.Id
                join cat in categoryRepo.GetAll() on prod.CategoryId equals cat.Id
                where cat.Name is "Container"
                select new Crop()
                {
                   Id = crop.Id,
                   Name = crop.Name,
                   Stage = crop.Stage,
                   Area = crop.Area,
                   Type = crop.Type,
                   NumContainers = crop.NumContainers,
                   StorageRequired = crop.StorageRequired,
                   ProductId = crop.ProductId,
                   ProductName = prod.Name,
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
                   ProductId = crop.ProductId,
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