using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.ObjectModel;

namespace JustRipe.ViewModels
{
    public class LabourerViewModel : ObservableObject
    {
        #region Fields

        private int _id;
        private string _name;

        #endregion Fields

        #region Properties
        private User selectedLabourer;
        public User SelectedLabour
        {
            get { return selectedLabourer; }
            set
            {
                if (value != null)
                {
                    selectedLabourer = value;
                    OnPropertyChanged(nameof(SelectedLabour));
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
        
        public RelayCommand AddUpdateLabourCommand { get; set; }
        public RelayCommand DeleteLabourCommand { get; set; }
        #endregion Properties

        public LabourerViewModel()
        {
            FillAllLabours();
            AddUpdateLabourCommand = new RelayCommand(AddUpdateLabour);
            DeleteLabourCommand = new RelayCommand(DeleteUser);
        }

        private void DeleteUser(object obj)
        {
            throw new NotImplementedException();
        }
 

        private UserRepository GetRepository()
        {
            return new UserRepository(new Repository<UserDTO>(), new Repository<RoleDTO>(), new Repository<UserRoleDTO>());
        }

        private void FillAllLabours()
        {
            var labourers = GetRepository().GetAllLabourUsers();
            LabourTable = new ObservableCollection<Object>();

            foreach (var lab in labourers)
            {
                LabourTable.Add(
                    new User
                    {
                        Id = lab.Id,
                        FirstName = lab.FirstName,
                        Role = lab.Role,
                    });
            }
        }

        private ObservableCollection<Object> _labourTable;
        public ObservableCollection<object> LabourTable
        {
            get { return _labourTable; }
            set
            {
                if (value != null)
                {
                    _labourTable = value;
                    OnPropertyChanged(nameof(LabourTable));
                }
            }
        }


        private void AddUpdateLabour(object parameter)
        {
            if (SelectedLabour == null) { AddUser(parameter); }
            else
            {
                //UpdateLabour(parameter);
                SelectedLabour = null;
            }
            LabourTable.Clear();
            FillAllLabours();
        }

        void AddUser(object parameter)
        {
            UserDTO newUser = new UserDTO
            {
                FirstName = Name,

            };
            GetRepository().AddUser(newUser);
        }
         
    }

}