using JustRipe.Data;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

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
            CropTable = selectQuery();
        }


        public DataTable selectQuery(string query = "")
        {
            SQLiteDatabase db = new SQLiteDatabase();
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            db.OpenConnection();  

            using (SQLiteCommand cmd = new SQLiteCommand(db.Connection))
            {
                cmd.CommandText = "Select * from Crops";  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource
            }
            return dt;
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
