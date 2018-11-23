using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace JustRipe.ViewModels
{
    public class CropViewModel : ObservableObject
    {
        #region Fields

        private int _id;
        private string _name;
        private string _area;
        private string _stage;
        private string _type;
        private Crop selectedCrop;

        #endregion

        #region Propierties
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        public Crop SelectedCrop
        {
            get { return selectedCrop; }
            set
            {
                selectedCrop = value; OnPropertyChanged(nameof(SelectedCrop));
                FillUpdateCreateForm();
                MessageBox.Show(SelectedCrop.Id.ToString());
            }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
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

        public RelayCommand AddUpdateCropCommand { get; set; }

        #endregion


        public CropViewModel()
        {
            AddUpdateCropCommand = new RelayCommand(AddUpdateCrop);
            FillAllCrops();
        }

        void FillUpdateCreateForm()
        {
            Id = SelectedCrop.Id;
            Name = SelectedCrop.Name;
            Stage = SelectedCrop.Stage;
            Type = SelectedCrop.Type;
            Area = SelectedCrop.Area;
        }
        private CropRepository GetRepository()
        {
            return new CropRepository(new Repository<CropDTO>(), new Repository<UserDTO>());
        }

        //private DataTable _cropTable;
        //public DataTable CropTable
        //{
        //    get { return _cropTable; }
        //    set { _cropTable = value; }
        //}

        //private void FillAllCrops()
        //{
        //    var crops = GetRepository().GetAllCrops();

        //    CropTable = new DataTable();

        //    CropTable.Columns.Add("Id");
        //    CropTable.Columns.Add("Name");
        //    CropTable.Columns.Add("Stage");
        //    CropTable.Columns.Add("Type");
        //    CropTable.Columns.Add("Area");

        //    foreach (var crop in crops)
        //    {
        //        CropTable.Rows.Add(crop.Id, crop.Name, crop.Stage, crop.Type, crop.Area);
        //    }
        //}
        private ObservableCollection<Crop> _cropTable;

        public ObservableCollection<Crop> CropTable
        {
            get { return _cropTable; }
            set { _cropTable = value; OnPropertyChanged(nameof(CropTable)); }
        }


        private void FillAllCrops()
        {
            var crops = GetRepository().GetAllCrops();
            CropTable = new ObservableCollection<Crop>();

            foreach (var crop in crops)
            {
                CropTable.Add(
                    new Crop
                    {
                        Id = crop.Id,
                        Name = crop.Name,
                        Stage = crop.Stage,
                        Type = crop.Type,
                        Area = crop.Area
                    });
            }
        }

        private void AddUpdateCrop(object parameter)
        {
            if (SelectedCrop == null)
            {
                AddCrop(parameter);
            }
            else
            {
                UpdateCrop(parameter);
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

        void UpdateCrop(object parameter)
        {
            CropDTO newCrop = new CropDTO
            {
                Id = Id,
                Name = Name,
                Stage = Stage,
                Type = Type,
                Area = Area
            };
            GetRepository().UpdateCrop(newCrop);
        }

        //void AddCrop(object parameter)
        //{
        //    GetRepository().AddCrop(new Crop { Name = Name, Stage = Stage, Area = Area, Type = Type });
        //}
    }

}