using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRipe.Data.Repositories
{
   public class VehicleRepository :  IDisposable
   {
      private readonly IRepository<VehicleDTO> vehicleRepo;

      public VehicleRepository(IRepository<VehicleDTO> vehicleRepo)
      {
         this.vehicleRepo = vehicleRepo;
      }   

      public IEnumerable<Vehicle> GetAllVehicles()
      {
         return from vehicle in vehicleRepo.GetAll()
                select new Vehicle()
                {
                   Id = vehicle.Id,
                   Name = vehicle.Name,
                   Year = vehicle.Year,
                   Type = vehicle.Type,
                   Brand = vehicle.Brand,
                   Model = vehicle.Model,
                   Capacity = vehicle.Capacity,
                   LicencePlate = vehicle.LicencePlate,
                   Status = vehicle.Status,
                };
      }

      public void UpdateVehicle(VehicleDTO _vehicle)
      {
         vehicleRepo.Update(_vehicle);
      }
      public void DeleteVehicle(VehicleDTO _vehicle)
      {
         vehicleRepo.Delete(_vehicle);
      }

      public void AddVehicle(VehicleDTO _vehicle)
      {
         vehicleRepo.Add(_vehicle);
      }
       
      public void Dispose()
      {
         vehicleRepo.Dispose();
      }
   }
}
