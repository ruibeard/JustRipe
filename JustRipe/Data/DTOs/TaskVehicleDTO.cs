using SQLite.Net.Attributes;

namespace JustRipe.Data.DTOs
{
    [Table("tasks_vehicles")]
    public class TaskVehicleDTO
   {
        [PrimaryKey, Column("id"), AutoIncrement]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId{ get; set; }

        [Column("role_id")]
        public int RoleId{ get; set; }

    }
}
