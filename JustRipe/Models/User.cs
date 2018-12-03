using System;

namespace JustRipe.Models
{
   public class User
   {
      public int Id { get; set; }
      public string Username { get; set; }
      public string Password { get; set; }
      public string FirstName { get; set; }
      private string _fullName;

      public string FullName
      {
         get { return FirstName + " " + LastName; }
         set { _fullName = value; }
      }

      public string LastName { get; set; }
      public string Email { get; set; }
      public string PhoneNumber { get; set; }
      public string Address { get; set; }
      public DateTime DateOfBirth { get; set; }
      public decimal AnualWage { get; set; }
      public string Role { get; set; }
   }
}
