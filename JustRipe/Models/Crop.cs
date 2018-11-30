namespace JustRipe.Models
{
   public class Crop
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Stage { get; set; }
      public string Type { get; set; }
      public string Area { get; set; }
      public int NumContainers { get; set; }
      public string FertilizeRequired { get; set; }
      public string StorageRequired { get; set; }

   }
}