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
        private List<Crop> _cropss = new List<Crop>();


        public List<Crop> CropList
        {
            get { return _cropss; }
            set
            {
                _cropss = value;
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
            AddUpdateTaskCommand = new RelayCommand(AddUpdateTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
        }

        private CropRepository GetCropRepository()
        {
            return new CropRepository(new Repository<CropDTO>());
        }

        void FillUpdateCreateForm()
        {
            GetAllCropsCurrentlyInCultivation();
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
        private TaskRepository GetRepository()
        {
            return new TaskRepository(new Repository<TaskDTO>(), new Repository<CropDTO>(), new Repository<UserDTO>());
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

        private void GetAllCropsCurrentlyInCultivation()
        {
            var all_Cropss = GetCropRepository().GetAllCrops();

            foreach (var crop in all_Cropss)
            {
                CropList.Add(new Crop { Id = crop.Id, Name = crop.Name });
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
        }

        void AddTask(object parameter)
        {
            TaskDTO newTask = new TaskDTO
            {
                Name = Name,
                Type = Type,
                CropId = CropId,
                UserId = UserId,
                TaskDate = TaskDate
            };
            GetRepository().AddTask(newTask);
        }

        void UpdateTask(object parameter)
        {
            TaskDTO newTask = new TaskDTO
            {
                Id = Id,
                Name = Name,
                Type = Type,
                UserId = UserId,
                CropId = CropId,
                TaskDate = TaskDate,
                LabourNeeded = LabourNeeded

            };
            GetRepository().UpdateTask(newTask);
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