using SQLite.Net.Attributes;

namespace JustRipe.Data.DTOs
{
    [Table("vehicles")]
    public class VehicleDTO
    {
        [PrimaryKey, Column("id"), AutoIncrement]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("year")]
        public string Year { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("brand")]
        public string Brand { get; set; }
        [Column("model")]
        public string Model { get; set; }
        [Column("capacity")]
        public string Capacity { get; set; }
        [Column("licence_Plate")]
        public string LicencePlate { get; set; }
        [Column("status")]
        public string Status { get; set; }
    }
}