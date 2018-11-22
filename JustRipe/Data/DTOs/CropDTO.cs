using SQLite.Net.Attributes;

namespace JustRipe.Data.DTOs
{
    [Table("crops")]
    public class CropDTO
    {
        [PrimaryKey, Column("id"), AutoIncrement]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("stage")]
        public string Stage { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("area")]
        public string Area { get; set; }
    }
}
