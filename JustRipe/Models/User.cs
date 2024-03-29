﻿using System;

namespace JustRipe.Models
{
   public class User
   {
      private int id;
      public int Id
      {
         get { return id; }
         set
         {
            if (value > 0)
               id = value;
         }
      }
      public string Username { get; set; }
      public string Password { get; set; }
      public string FirstName { get; set; }

      private string _fullName;

      public string FullName
      {
         get { return _fullName; }
         set { _fullName = value; }
      }

      public string LastName { get; set; }
      public string Email { get; set; }
      public string PhoneNumber { get; set; }
      public string Address { get; set; }
      public DateTime DateOfBirth { get; set; }
      public decimal AnnualWage { get; set; }
      public string Role { get; set; }
      public int RoleId { get; set; }
      public int UserRoleId { get; set; }

   }
}
