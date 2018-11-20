using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System.Data;
using System.Windows.Media;

namespace JustRipe.ViewModels
{
    public class CropViewModel : ObservableObject, IBaseViewModel
    {
        #region Fields

        private string _stage;
        private string _name;
        private string _area;
        private string _type;

        private Brush _color;

        private DataTable _cropTable;

        #endregion

        #region Propierties

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value; OnPropertyChanged(nameof(Name));
            }
        }
        public string Stage
        {
            get { return _stage; }
            set { _stage = value; OnPropertyChanged(nameof(Stage)); }
        }

        public string Area
        {
            get { return _area; }
            set { _area = value; OnPropertyChanged(nameof(Area)); }
        }

        public Brush Color
        {
            get { return _color; }
            set { _color = value; OnPropertyChanged(nameof(Color)); }
        }

        public DataTable CropTable
        {
            get { return _cropTable; }
            set { _cropTable = value; }
        }

        public RelayCommand AddCropCommand { get; set; }

        #endregion


        public CropViewModel()
        {
            _color = Brushes.Red;
            AddCropCommand = new RelayCommand(AddCrop);
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

        void AddCrop(object parameter)
        {

            CropDTO newCrop = new CropDTO
            {
                Name = Name,
                Stage = Stage,
                Type = Type,
                Area = Area
            };
            GetRepository().AddCrop(newCrop);
        }
        //void AddCrop(object parameter)
        //{

        //    GetRepository().AddCrop(new Crop { Name = Name, Stage = Stage, Area = Area, Type = Type });
        //}
    }

}