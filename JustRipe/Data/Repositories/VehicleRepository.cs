using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRipe.Data.Repositories
{
    public class VehicleRepository : SQLiteDb, IDisposable
    {
        private readonly IRepository<VehicleDTO> repository;

        public VehicleRepository(IRepository<VehicleDTO> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return from vehicle in repository.GetAll()
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
            repository.Update(_vehicle);
        }
        public void DeleteVehicle(VehicleDTO _vehicle)
        {
            repository.Delete(_vehicle);
        }

        public void AddVehicle(VehicleDTO _vehicle)
        {
            repository.Add(_vehicle);
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
