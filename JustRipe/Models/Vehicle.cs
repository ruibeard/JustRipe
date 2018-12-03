namespace JustRipe.Models
{
   public class Vehicle
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
      public string Year { get; set; }
      public string Type { get; set; }
      public string Brand { get; set; }
      public string Model { get; set; }
      public string Capacity { get; set; }
      public string LicencePlate { get; set; }
      public string Status { get; set; }
   }
}
