using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRipe.Data.Repositories
{
    public class TaskRepository : SQLiteDb, IDisposable
    {
        private readonly IRepository<TaskDTO> taskRepo;
        private readonly IRepository<CropDTO> cropRepo;
        private readonly IRepository<UserDTO> userRepo;

        public TaskRepository(IRepository<TaskDTO> taskRepo, IRepository<CropDTO> cropRepo, IRepository<UserDTO> userRepo)
        {
            this.taskRepo = taskRepo;
            this.cropRepo = cropRepo;
            this.userRepo = userRepo;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return from task in taskRepo.GetAll()
                   join crop in cropRepo.GetAll() on task.CropId equals crop.Id
                   join user in userRepo.GetAll() on task.UserId equals user.Id
                   select new Task()
                   {
                       Id = task.Id,
                       Name = task.Name,
                       CropId = task.CropId,
                       CropName = crop.Name,
                       UserId = task.UserId,
                       CreatedBy = user.FirstName,
                       Type = task.Type,
                       TaskDate = task.TaskDate,
                       LabourNeeded = task.LabourNeeded,
                   };
        }
        public IEnumerable<Task> GetAllHarvestingTasks()
        {
            return from task in taskRepo.GetAll()
                   join crop in cropRepo.GetAll() on task.CropId equals crop.Id
                   join user in userRepo.GetAll() on task.UserId equals user.Id
                   where task.Type is "Harvesting"
                   select new Task()
                   {
                       Id = task.Id,
                       Name = task.Name,
                       CropId = task.CropId,
                       CropName = crop.Name,
                       UserId = task.UserId,
                       CreatedBy = user.FirstName,
                       Type = task.Type,
                       TaskDate = task.TaskDate,
                       LabourNeeded = task.LabourNeeded,
                   };
        }

        public void UpdateTask(TaskDTO _task)
        {
            taskRepo.Update(_task);
        }
        public void DeleteTask(TaskDTO _task)
        {
            taskRepo.Delete(_task);
        }
        public void AddTask(TaskDTO _task)
        {
            taskRepo.Add(_task);
        }

        public void Dispose()
        {
            taskRepo.Dispose();
        }
    }
}
