using SQLite.Net.Attributes;

namespace JustRipe.Data.DTOs
{
    [Table("users")]
    public class UserDTO
    {
        [PrimaryKey, Column("id")]
        public int Id { get; set; }
        [Column("username")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
    }
}
