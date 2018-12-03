using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRipe.Data.Repositories
{
   public class ContainerRepository : SQLiteDb, IDisposable
   {
      private readonly IRepository<ContainerDTO> repository;
      public ContainerRepository(IRepository<ContainerDTO> repository)
      {
         this.repository = repository;
      }

      public IEnumerable<Container> GetAllContainers()
      {
         return from cat in repository.GetAll()
                select new Container()
                {
                   Id = cat.Id,
                   Name = cat.Name,
                   Capacity = cat.Capacity,
                   UnitType = cat.UnitType,
                   Available = cat.Available,
                };
      }

      public void UpdateContainer(ContainerDTO _category)
      {
         repository.Update(_category);
      }
      public void DeleteContainer(ContainerDTO _category)
      {
         repository.Delete(_category);
      }

      public void AddContainer(ContainerDTO _category)
      {
         repository.Add(_category);
      }

      public void Dispose()
      {
         repository.Dispose();
      }
   }
}
