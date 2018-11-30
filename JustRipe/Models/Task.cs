namespace JustRipe.Models
{
   public class Task
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
      public string TaskDate { get; set; }
      public int CropId { get; set; }
      public string CropName { get; set; }
      public int UserId { get; set; }
      public string CreatedBy { get; set; }
      public string Type { get; set; }
      public int LabourNeeded { get; set; }
   }
}