namespace JustRipe.Models
{
   public class Container : ObservableObject
   {

      public int Id { get; set; }
      public string Name { get; set; }
      public string Capacity { get; set; }
      public string UnitType { get; set; }
      public string Available { get; set; }
   }
}