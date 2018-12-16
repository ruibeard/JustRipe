namespace JustRipe.Models
{
   public class Product
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
      public string ProductName { get; set; }
      public string Description { get; set; }
      public string Status { get; set; }
      public double Quantity { get; set; }
      public double Price { get; set; }
      public string Unit { get; set; }
      public int CategoryId { get; set; }
      public string CategoryName { get; set; }

   }

}
