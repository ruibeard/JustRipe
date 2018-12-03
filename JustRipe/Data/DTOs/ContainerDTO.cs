using SQLite.Net.Attributes;

namespace JustRipe.Data.DTOs
{
   [Table("containers")]
   public class ContainerDTO
   {
      [PrimaryKey, Column("id"), AutoIncrement]
      public int Id { get; set; }
      [Column("name")]
      public string Name { get; set; }
      [Column("capacity")]
      public string Capacity { get; set; }

      [Column("unitType")]
      public string UnitType { get; set; }

      [Column("available")]
      public string Available { get; set; }

   }
}