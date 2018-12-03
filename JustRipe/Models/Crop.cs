namespace JustRipe.Models
{
   public class Crop
   {
      private int id;
      public int Id
      {
         get { return id; }
         set
         {
            if (value > 0)
               id = value;
         }
      }
      public string Name { get; set; }
      public string Stage { get; set; }
      public string Type { get; set; }
      public string Area { get; set; }
      public int NumContainers { get; set; }
      public string FertilizeRequired { get; set; }
      public string StorageRequired { get; set; }
      public int ContainerId{ get; set; }
      public string  Container{ get; set; }

   }
}