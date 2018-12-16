using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace JustRipe.ViewModels
{
   public class TaskViewModel : ObservableObject
   {
      #region Fields
      private int _id;
      private string _name;
      private string _type;
      private int _userId;
      private int _cropId;
      private string _taskDate;
      private Task selectedTask;
      #endregion Fields

      #region Properties
      public Task SelectedTask
      {
         get { return selectedTask; }
         set
         {
            if (value != null)
            {
               selectedTask = value;
               OnPropertyChanged(nameof(SelectedTask));
               FillUpdateCreateForm();
            }
         }
      }
      private List<User> _users = new List<User>();

      public List<User> UserList
      {
         get { return _users; }
         set
         {
            _users = value;
            OnPropertyChanged(nameof(UserList));
         }
      }

      private List<Crop> _crops = new List<Crop>();

      public List<Crop> CropList
      {
         get { return _crops; }
         set
         {
            _crops = value;
            OnPropertyChanged(nameof(CropList));
         }
      }
      public string TaskDate
      {
         get { return _taskDate; }
         set { _taskDate = value; OnPropertyChanged(nameof(TaskDate)); }
      }

      public int Id
      {
         get { return _id; }
         set { _id = value; OnPropertyChanged(nameof(Id)); }
      }
      public string Name
      {
         get { return _name; }
         set { _name = value; OnPropertyChanged(nameof(Name)); }
      }
      public string Type
      {
         get { return _type; }
         set { _type = value; OnPropertyChanged(nameof(Type)); }
      }
      public int CropId
      {
         get { return _cropId; }
         set { _cropId = value; OnPropertyChanged(nameof(CropId)); }
      }
      public int UserId
      {
         get { return _userId; }
         set { _userId = value; OnPropertyChanged(nameof(UserId)); }
      }

      private string _cropName;
      public string CropName
      {
         get { return _cropName; }
         set { _cropName = value; OnPropertyChanged(nameof(CropName)); }
      }

      private string _createdBy;
      public string CreatedBy
      {
         get { return _createdBy; }
         set { _createdBy = value; OnPropertyChanged(nameof(CreatedBy)); }
      }

      private int _labourNeeded;

      public int LabourNeeded
      {
         get { return _labourNeeded; }
         set { _labourNeeded = value; OnPropertyChanged(nameof(LabourNeeded)); }
      }

      public RelayCommand AddUpdateTaskCommand { get; set; }
      public RelayCommand DeleteTaskCommand { get; private set; }
      public RelayCommand AddCommand { get; set; }

      #endregion Properties

      private Crop _selectedCrop;
      public Crop SelectedCrop
      {
         get { return _selectedCrop; }
         set
         {
            _selectedCrop = value; OnPropertyChanged(nameof(SelectedCrop));

            MessageBox.Show(SelectedCrop.Id.ToString());
         }
      }
      public TaskViewModel()
      {
         FillAllTasks();
         GetAllCrops();
         GetAllUsers();
         AddUpdateTaskCommand = new RelayCommand(AddUpdateTask);
         AddCommand = new RelayCommand(ShowFormAndClear);
         DeleteTaskCommand = new RelayCommand(DeleteTask);
      }
      private CropRepository GetCropRepository()
      {
         return new CropRepository(new Repository<CropDTO>());
      }
      private UserRepository GetUserRepository()
      {
         return new UserRepository(new Repository<UserDTO>());
      }
      private TaskRepository GetRepository()
      {
         return new TaskRepository(new Repository<TaskDTO>(), new Repository<CropDTO>(), new Repository<UserDTO>());
      }
      void FillUpdateCreateForm()
      {
         ShowForm();
         Id = SelectedTask.Id;
         Name = SelectedTask.Name;
         TaskDate = SelectedTask.TaskDate;
         Type = SelectedTask.Type;
         CropName = SelectedTask.CropName;
         CreatedBy = SelectedTask.CreatedBy;
         LabourNeeded = SelectedTask.LabourNeeded;
         CropId = SelectedTask.CropId;
         UserId = SelectedTask.UserId;
      }
      private ObservableCollection<Object> _taskTable;
      public ObservableCollection<object> TaskTable
      {
         get { return _taskTable; }
         set
         {
            _taskTable = value;
            OnPropertyChanged(nameof(TaskTable));
         }
      }
      private void GetAllCrops()
      {
         var all_Cropss = GetCropRepository().GetAllCrops();

         foreach (var crop in all_Cropss)
         {
            CropList.Add(new Crop { Id = crop.Id, Name = crop.Name });
         }
      }
      private void GetAllUsers()
      {
         var all_Users = GetUserRepository().GetAllUsers();

         foreach (var user in all_Users)
         {
            UserList.Add(new User { Id = user.Id, FullName = user.FullName });
         }
      }
      private void FillAllTasks()
      {
         var tasks = GetRepository().GetAllTasks();

         TaskTable = new ObservableCollection<object>();

         foreach (var task in tasks)
         {
            TaskTable.Add(
            new Task
            {
               Id = task.Id,
               Name = task.Name,
               TaskDate = task.TaskDate,
               CropName = task.CropName,
               CreatedBy = task.CreatedBy,
               CropId = task.CropId,
               UserId = task.UserId,
               Type = task.Type,
               LabourNeeded = task.LabourNeeded,
            });
         }
      }

      private void ShowFormAndClear(object param = null)
      {
         ShowForm();
         ClearForm();
      }
      private void ClearForm()
      {
         Name = Type = Type = "";
         Id = UserId = CropId = LabourNeeded = 0;
         TaskDate = "";
      }
      private void AddUpdateTask(object parameter)
      {
         if (SelectedTask == null)
         {
            AddTask(parameter);
         }
         else
         {
            UpdateTask(parameter);
         }
         FillAllTasks();
         HideForm();
      }

      void AddTask(object parameter)
      {
         var newTask = NewTaskDTO();
         GetRepository().AddTask(newTask);
         ClearForm();
      }

      void UpdateTask(object parameter)
      {
         GetRepository().UpdateTask(NewTaskDTO());
      }

      private TaskDTO NewTaskDTO()
      {
         MessageBox.Show(Name);
         MessageBox.Show(TaskDate);
         MessageBox.Show(CropId.ToString());
         MessageBox.Show(Type);
         MessageBox.Show(UserId.ToString());
         MessageBox.Show(LabourNeeded.ToString());
         return new TaskDTO
         {
            Name = Name,
            TaskDate = TaskDate,
            CropId = CropId,
            Type = Type,
            UserId = UserId,
            LabourNeeded = LabourNeeded,
         };
      }

      private void DeleteTask(object parameter)
      {
         if (SelectedTask != null)
         {
            TaskDTO newTask = new TaskDTO
            {
               Id = Id,
            };
            GetRepository().DeleteTask(newTask);
            FillAllTasks();
         }
      }
   }
}