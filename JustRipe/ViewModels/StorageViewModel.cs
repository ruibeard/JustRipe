using JustRipe.Models;

namespace JustRipe.ViewModels
{
   public class StorageViewModel : ObservableObject
   {
      public RelayCommand AddStorageCommand { get; set; }
      private string pageName;

      public string PageName
      {
         get { return pageName; }
         set { pageName = value; }
      }
      public StorageViewModel()
      {
         PageName = "Storages";
         AddStorageCommand = new RelayCommand(AddStorage);
      }

      void AddStorage(object parameter)
      {

      }
   }

}
