﻿using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        private int _numContainers;

        #endregion Fields

        #region Properties
        private Crop selectedCrop;
        public Crop SelectedCrop
        {
            get { return selectedCrop; }
            set
            {
                if (value != null)
                {
                    selectedCrop = value;
                    FillUpdateCreateForm();
                    OnPropertyChanged(nameof(SelectedCrop));
                }
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
        public string Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged(nameof(Type)); }
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
        public int NumContainers
        {
            get { return _numContainers; }
            set { _numContainers = value; OnPropertyChanged(nameof(NumContainers)); }
        }

        public RelayCommand AddUpdateCropCommand { get; set; }
        public RelayCommand DeleteCropCommand { get; set; }
        public RelayCommand ShowAllCropsCommand { get; set; }
        #endregion Properties

        public CropViewModel()
        {
            AddUpdateCropCommand = new RelayCommand(AddUpdateCrop);
            DeleteCropCommand = new RelayCommand(DeleteCrop);
            ShowAllCropsCommand = new RelayCommand(ShowAllCrops);
            ShowCropsInCultivation();
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
            return new CropRepository(new Repository<CropDTO>());
        }

        private void ShowAllCrops(object param)
        {
            var crops = GetRepository().GetAllCrops();
            CropTable = new ObservableCollection<Object>();
            BuildTable(crops);
        }

        private void ShowCropsInCultivation()
        {
            var crops = GetRepository().GetAllCropsCurrentlyInCultivation();
            CropTable = new ObservableCollection<Object>();

            foreach (var crop in crops)
            {
                CropTable.Add(
                    new Crop
                    {
                        Id = crop.Id,
                        Name = crop.Name,
                        Stage = crop.Stage,
                        Type = crop.Type,
                        Area = crop.Area,
                        NumContainers = crop.NumContainers,

                    });
            }
        }

        private void BuildTable(IEnumerable<Crop> crops)
        {
            foreach (var crop in crops)
            {
                CropTable.Add(
                    new Crop
                    {
                        Id = crop.Id,
                        Name = crop.Name,
                        Stage = crop.Stage,
                        Type = crop.Type,
                        Area = crop.Area,
                        NumContainers = crop.NumContainers,
                    });
            }
        }

        private ObservableCollection<Object> _cropTable;
        public ObservableCollection<object> CropTable
        {
            get { return _cropTable; }
            set
            {
                if (value != null)
                {
                    _cropTable = value;
                    OnPropertyChanged(nameof(CropTable));
                }
            }
        }


        private void AddUpdateCrop(object parameter)
        {
            if (SelectedCrop == null) { AddCrop(parameter); }
            else
            {
                UpdateCrop(parameter);
                SelectedCrop = null;
            }
            Name = Stage = Type = Area = "";
            Id = 0;
            CropTable.Clear();
            ShowCropsInCultivation();
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

        private void DeleteCrop(object parameter)
        {
            if (SelectedCrop != null)
            {
                CropDTO newCrop = new CropDTO
                {
                    Id = Id,
                };
                GetRepository().DeleteCrop(newCrop);
                ShowCropsInCultivation();
            }
        }

        //void AddCrop(object parameter)
        //{
        //    GetRepository().AddCrop(new Crop { Name = Name, Stage = Stage, Area = Area, Type = Type });
        //}
    }

}