namespace JustRipe.Models
{
   public class Labour
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
   }
}