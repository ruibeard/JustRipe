using SQLite.Net.Attributes;

namespace JustRipe.Data.DTOs
{
    [Table("users")]
    public class UserDTO
    {
        [PrimaryKey, Column("id"), AutoIncrement]
        public int Id { get; set; }

        [Column("fullName")]
        public string Name { get; set; }

        [Column("username")]
        public string UserName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [Column("wage")]
        public string Wage{ get; set; }
    }
}
