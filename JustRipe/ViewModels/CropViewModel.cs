using System.Data;
using System.Windows.Media;
using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;

namespace JustRipe.ViewModels
{
    public class CropViewModel : ObservableObject, IBaseViewModel
    {
        private DataTable _cropTable;

        public DataTable CropTable
        {
            get { return _cropTable; }
            set { _cropTable = value; }
        }

        public RelayCommand AddCropCommand { get; set; }

        public CropViewModel()
        {
            _color = Brushes.Red;
            PageName = "Crops";
            AddCropCommand = new RelayCommand(AddCrop);
            //CropTable = selectQuery();

            FillAllCrops();
        }

        private CropRepository GetRepository()
        {
            return new CropRepository(new Repository<CropDTO>(), new Repository<UserDTO>());
        }

        private void FillAllCrops()
        {
            var crops = GetRepository().GetAllCrops();

            CropTable = new DataTable();

            CropTable.Columns.Add("Name");
            CropTable.Columns.Add("Stage");
            CropTable.Columns.Add("Type");
            CropTable.Columns.Add("Area");

            foreach (var crop in crops)
            {
                CropTable.Rows.Add(crop.Name, crop.Stage, crop.Type, crop.Area);
            }
        }

        private string pageName;

        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }


        private Brush _color;

        public Brush Color
        {
            get { return _color; }
            set { _color = value; }
        }

        void AddCrop(object parameter)
        {

        }
    }

}
