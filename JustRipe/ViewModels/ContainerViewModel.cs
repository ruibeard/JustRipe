using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JustRipe.ViewModels
{
   public class ContainerViewModel : ObservableObject
   {
      #region Fields
      private int _id;
      private string _name;
      private string _capacity;
      private string _unitType;
      private string _numContainers;
      private bool _showingAll = false;
      private ObservableCollection<Object> _cropTable;
      #endregion Fields
       
      #region Properties
      private Container selectedContainer;
      public Container SelectedContainer
      {
         get { return selectedContainer; }
         set
         {
            if (value != null)
            {
               selectedContainer = value;
               FillUpdateCreateForm();
               OnPropertyChanged(nameof(SelectedContainer));
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
      public string Capacity
      {
         get { return _capacity; }
         set { _capacity = value; OnPropertyChanged(nameof(Capacity)); }
      }
      public string Available
      {
         get { return _numContainers; }
         set { _numContainers = value; OnPropertyChanged(nameof(Available)); }
      }
      public string UnitType
      {
         get { return _unitType; }
         set { _unitType = value; OnPropertyChanged(nameof(UnitType)); }
      }
      public RelayCommand AddUpdateContainerCommand { get; set; }
      public RelayCommand DeleteContainerCommand { get; set; }
      public RelayCommand ShowAllContainersToogleCommand { get; set; }

      #endregion Properties
      public ContainerViewModel()
      {
         AddUpdateContainerCommand = new RelayCommand(AddUpdateContainer);
         DeleteContainerCommand = new RelayCommand(DeleteContainer);
         ShowAllContainers();
      }
      void FillUpdateCreateForm()
      {
         Id = SelectedContainer.Id;
         Name = SelectedContainer.Name;
         Capacity = SelectedContainer.Capacity;
         Available = SelectedContainer.Available;
         UnitType = SelectedContainer.UnitType;
      }
      private ContainerRepository GetRepository()
      {
         return new ContainerRepository(new Repository<ContainerDTO>());
      }

      private void ShowAllContainers()
      {

         var crops = GetRepository().GetAllContainers();
         ContainerTable = new ObservableCollection<Object>();
         BuildTable(crops);
      }

      private void BuildTable(IEnumerable<Container> crops)
      {
         foreach (var crop in crops)
         {
            ContainerTable.Add(
                new Container
                {
                   Id = crop.Id,
                   Name = crop.Name,
                   Capacity = crop.Capacity,
                   Available = crop.Available,
                   UnitType = crop.UnitType,
                });
         }
      }
      public ObservableCollection<object> ContainerTable
      {
         get { return _cropTable; }
         set
         {
            if (value != null)
            {
               _cropTable = value;
               OnPropertyChanged(nameof(ContainerTable));
            }
         }
      }
      private void ClearForm()
      {
         //Name = Capacity = Available = UnitType = "";
         //Id = Available = 0;

      }
      private void AddUpdateContainer(object parameter)
      {
         if (SelectedContainer == null)
         {
            AddContainer();
         }
         else
         {
            UpdateContainer();
            SelectedContainer = null;
         }

         ClearForm();

         ContainerTable.Clear();

         ShowAllContainers();
      }
      void AddContainer()
      {
         var newContainer = NewContainerDTO();

         GetRepository().AddContainer(newContainer);


      }
      void UpdateContainer()
      {
         var newContainer = NewContainerDTO();

         GetRepository().UpdateContainer(newContainer);

      }
      private ContainerDTO NewContainerDTO()
      {
         return new ContainerDTO
         {
            Id = Id,
            Name = Name,
            Capacity = Capacity,
            Available = Available,
            UnitType = UnitType,

         };
      }
      private void DeleteContainer(object parameter)
      {
         if (SelectedContainer != null)
         {
            ContainerDTO newContainer = new ContainerDTO
            {
               Id = Id,
            };
            GetRepository().DeleteContainer(newContainer);
            ShowAllContainers();
         }
      }

   }

}