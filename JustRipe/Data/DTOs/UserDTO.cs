using SQLite.Net.Attributes;
using System;

namespace JustRipe.Data.DTOs
{
   [Table("users")]
   public class UserDTO
   {
      [PrimaryKey, Column("id"), AutoIncrement]
      public int Id { get; set; }

      [Column("firstName")]
      public string FirstName { get; set; }
      [Column("lastName")]
      public string LastName { get; set; }


      private string _fullName;

      public string FullName
      {
         get { return FirstName + " " + LastName; }
         set { _fullName = value; }
      }

      [Column("username")]
      public string Username { get; set; }

      [Column("password")]
      public string Password { get; set; }

      [Column("email")]
      public string Email { get; set; }

      [Column("phoneNumber")]
      public string PhoneNumber { get; set; }

      [Column("address")]
      public string Address { get; set; }

      [Column("dateOfBirth")]
      public DateTime DateOfBirth { get; set; }

      [Column("anualWage")]
      public decimal AnnualWage { get; set; }
   }
}
