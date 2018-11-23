using SQLite.Net.Attributes;

namespace JustRipe.Data.DTOs
{
    [Table("roles")]
    public class RoleDTO
    {
        [PrimaryKey, Column("id"), AutoIncrement]
        public int Id { get; set; }

        [Column("name")]
        public string Name{ get; set; }
    }
}
