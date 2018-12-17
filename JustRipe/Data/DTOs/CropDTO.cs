using SQLite.Net.Attributes;

namespace JustRipe.Data.DTOs
{
   [Table("cropItem")]
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

      [Column("numContainers")]
      public int NumContainers { get; set; }

      [Column("storageRequired")]
      public string StorageRequired { get; set; }


      [Column("product_id")]
      public int ProductId { get; set; }

      [Column("user_id")]
      public int UserId { get; set; }
   }
}