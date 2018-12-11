using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JustRipe.ViewModels
{
   public class TimeTableViewModel : ObservableObject
   {
      #region Fields
      private int _id;
      private string _name;
      private string _area;
      private string _stage;
      private string _type;
      private string _storageRequired;
      private int _numContainers;
      private bool _showingAll = false;
      private int _productId;
      private Task _selectedTask;
      private ObservableCollection<Object> _harvestTable = new ObservableCollection<Object>();

      private List<Product> _productList = new List<Product>();


      private string _productName;
      #endregion Fields

      #region Properties

      public bool ShowingAll
      {
         get { return _showingAll; }
         set { _showingAll = value; OnPropertyChanged(nameof(ShowingAll)); }
      }
      public Task SelectedTask
      {
         get { return _selectedTask; }
         set
         {
            if (value != null)
            {
               _selectedTask = value;
               FillUpdateCreateForm();
               OnPropertyChanged(nameof(SelectedTask));
            }
         }
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
      public string Stage
      {
         get { return _stage; }
         set { _stage = value; OnPropertyChanged(nameof(Stage)); }
      }
      public string Area
      {
         get { return _area; }
         set { _area = value; OnPropertyChanged(nameof(Area)); }
      }
      public int ProductId
      {
         get { return _productId; }
         set { _productId = value; OnPropertyChanged(nameof(ProductId)); }
      }
      public string ProductName
      {
         get { return _productName; }
         set { _productName = value; OnPropertyChanged(nameof(ProductName)); }
      }
      public int NumContainers
      {
         get { return _numContainers; }
         set { _numContainers = value; OnPropertyChanged(nameof(NumContainers)); }
      }
      public string StorageRequired
      {
         get { return _storageRequired; }
         set { _storageRequired = value; OnPropertyChanged(nameof(StorageRequired)); }
      }
      #endregion Properties
      public TimeTableViewModel()
      {
         //AddUpdateCropCommand = new RelayCommand(AddUpdateCrop);
         //DeleteCropCommand = new RelayCommand(DeleteCrop);
         //ShowAllCropsToogleCommand = new RelayCommand(ToogleTable);
         ShowAll();

      }
      void FillUpdateCreateForm()
      {
         ShowForm();
         Id = SelectedTask.Id;
         Name = SelectedTask.Name;
         Type = SelectedTask.Type;
      }
      private TaskRepository GetRepository()
      {
         return new TaskRepository(new Repository<TaskDTO>(), new Repository<CropDTO>(), new Repository<UserDTO>());
      }
      
      private void ShowAll()
      {
         var tasks = GetRepository().GetAllHarvestingTasks();
         BuildTable(tasks);
      }
      private void BuildTable(IEnumerable<Task> tasks)
      {
         foreach (var task in tasks)
         {
            HarvestTable.Add(
                new Task
                {

                   Id = task.Id,
                   Name = task.Name,
                   CropId = task.CropId,
                   CropName = task.CropName,
                   UserId = task.UserId,
                   CreatedBy = task.CreatedBy,
                   Type = task.Type,
                   TaskDate = task.TaskDate,
                   LabourNeeded = task.LabourNeeded,
                });
         }
      }
      public ObservableCollection<object> HarvestTable
      {
         get { return _harvestTable; }
         set
         {
            if (value != null)
            {
               _harvestTable = value;
               OnPropertyChanged(nameof(HarvestTable));
            }
         }
      }
      private void ClearForm()
      {
         Name = Stage = Type = Area = StorageRequired = "";
         Id = NumContainers = 0;
      }

      private TaskDTO NewTaskDTO()
      {
         return new TaskDTO
         {
            Id = Id,
            Name = Name,
            Type = Type,
         };
      }
   }
}