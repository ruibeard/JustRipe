﻿using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using JustRipe.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace JustRipe.ViewModels
{
   public class UserViewModel : ObservableObject
   {

      public UserViewModel()
      {
         AddUpdateUserCommand = new RelayCommand(AddUpdateUser);
         DeleteUserCommand = new RelayCommand(DeleteUser);
         GetAllRoles();
         ShowAllUsers();

      }

      private int _id;
      private string _userName;
      private string _password;
      private string _firstName;
      private string _lastName;
      private string _email;
      private string _phoneNumber;
      private string _address;
      private DateTime _dateOfBirth;
      private Decimal _annualWage;
      private bool _showingAll = false;
      private List<Role> _roleList = new List<Role>();
      private User selectedItem;
      private string _role;

      private int _roleId;
      public int RoleId
      {
         get { return _roleId; }
         set { _roleId = value; OnPropertyChanged(nameof(RoleId)); }
      }
      private int _userRoleId;

      public int UserRoleId
      {
         get { return _userRoleId; }
         set { _userRoleId = value; OnPropertyChanged(nameof(RoleId)); }
      }

      public string Role
      {
         get { return _role; }
         set { _role = value; OnPropertyChanged(nameof(UserName)); }
      }

      public string UserName
      {
         get { return _userName; }
         set { _userName = value; OnPropertyChanged(nameof(UserName)); }
      }
      public int Id
      {
         get { return _id; }
         set { _id = value; OnPropertyChanged(nameof(Id)); }
      }
      public string Password
      {
         get { return _password; }
         set { _password = value; }
      }
      public string FirstName
      {
         get { return _firstName; }
         set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
      }
      public string LastName
      {
         get { return _lastName; }
         set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
      }
      public string Email
      {
         get { return _email; }
         set { _email = value; OnPropertyChanged(nameof(Email)); }
      }
      public string PhoneNumber
      {
         get { return _phoneNumber; }
         set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
      }
      public string Address
      {
         get { return _address; }
         set { _address = value; OnPropertyChanged(nameof(Address)); }
      }
      public DateTime DateOfBirth
      {
         get { return _dateOfBirth; }
         set { _dateOfBirth = value.Date; OnPropertyChanged(nameof(DateOfBirth)); }
      }
      public Decimal AnnualWage
      {
         get { return _annualWage; }
         set { _annualWage = value; OnPropertyChanged(nameof(AnnualWage)); }

      }
      public User SelectedItem
      {
         get { return selectedItem; }
         set
         {
            if (value != null)
            {
               selectedItem = value;
               FillUpdateCreateForm();
               OnPropertyChanged(nameof(SelectedItem));
            }
         }
      }
      public bool ShowingAll
      {
         get { return _showingAll; }
         set { _showingAll = value; OnPropertyChanged(nameof(ShowingAll)); }
      }
      private ObservableCollection<Object> _userTable;

      public ObservableCollection<object> UserTable
      {
         get { return _userTable; }
         set
         {
            if (value != null)
            {
               _userTable = value;
               OnPropertyChanged(nameof(UserTable));
            }
         }
      }
      void FillUpdateCreateForm()
      {
         ShowForm();
         Id = SelectedItem.Id;
         UserName = SelectedItem.Username;
         FirstName = SelectedItem.FirstName;
         LastName = SelectedItem.LastName;
         Email = SelectedItem.Email;
         PhoneNumber = SelectedItem.PhoneNumber;
         Address = SelectedItem.Address;
         DateOfBirth = SelectedItem.DateOfBirth;
         AnnualWage = SelectedItem.AnnualWage;
         Role = SelectedItem.Role;
         RoleId = SelectedItem.RoleId;


      }
      public RelayCommand AddUpdateUserCommand { get; }
      public RelayCommand DeleteUserCommand { get; }
      public RelayCommand ShowAllUsersToogleCommand { get; }
      private UserRepository GetRepository()
      {
         return new UserRepository(new Repository<UserDTO>(), new Repository<RoleDTO>(), new Repository<UserRoleDTO>());
      }
     

      private RoleRepository GetRoleRepository()
      {
         return new RoleRepository(new Repository<RoleDTO>());
      }
      public List<Role> RoleList
      {
         get { return _roleList; }
         set
         {
            _roleList = value;
            OnPropertyChanged(nameof(RoleList));
         }
      }

      private void GetAllRoles()
      {
         var all_Roles = GetRoleRepository().GetAllRoles();
         foreach (var r in all_Roles)
         {
            RoleList.Add(new Role { Id = r.Id, Name = r.Name });
         }
      }
      private void ShowAllUsers()
      {

         var users = GetRepository().GetAllUsersRoles();
         UserTable = new ObservableCollection<Object>();
         BuildTable(users);
      }
      private void BuildTable(IEnumerable<User> users)
      {
         foreach (var user in users)
         {
            UserTable.Add(
                new User
                {
                   Id = user.Id,
                   Username = user.Username,
                   FirstName = user.FirstName,
                   LastName = user.LastName,
                   Email = user.Email,
                   PhoneNumber = user.PhoneNumber,
                   Address = user.Address,
                   DateOfBirth = user.DateOfBirth,
                   AnnualWage = user.AnnualWage,
                   Role = user.Role,
                   RoleId = user.RoleId,
                   UserRoleId = user.UserRoleId,
                });
         }
      }
      private void AddUpdateUser(object parameter)
      {
         if (SelectedItem == null)
         {
            AddUser();
         }
         else
         {
            UpdateUser(parameter);
            SelectedItem = null;
         }
         UserTable.Clear();
         ShowAllUsers();
         HideForm();
      }
      void AddUser()
      {
         var newUser = FillDTO();
         GetRepository().AddUser(newUser);
      }

      private void ClearForm()
      {
         FirstName = LastName = Address = Email = UserName = PhoneNumber = Role = "";
         Id = 0;
         AnnualWage = 0;

      }
      void UpdateUser(object parameter)
      {
         var newUser = FillDTO(parameter);
         GetRepository().UpdateUser(newUser);
      }

      private UserDTO FillDTO(object parameter = null)
      {
         var pass = parameter as PasswordBox;

         return new UserDTO
         {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            Password = EncryptPassword.Encrypt(pass.Password),
            Username = UserName,
            Address = Address,
            Email = Email,
            PhoneNumber = PhoneNumber,
            DateOfBirth = DateOfBirth,
            AnnualWage = AnnualWage,
         };
      }
      private void DeleteUser(object parameter)
      {
         if (SelectedItem != null)
         {
            UserDTO newUser = new UserDTO
            {
               Id = Id,
            };
            GetRepository().DeleteUser(newUser);
            ShowAllUsers();
         }
      }

   }
}
