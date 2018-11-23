using SQLite.Net.Attributes;

namespace JustRipe.Data.DTOs
{
    [Table("tasks")]
    public class TaskDTO
    {
        [PrimaryKey, Column("id"), AutoIncrement]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("task_date")]
        public string TaskDate { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("crop_id")]
        public int CropId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("labour_needed")]
        public int LabourNeeded { get; set; }
    }
}