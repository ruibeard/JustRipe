using System;
using System.Linq.Expressions;
using System.Windows;
using SQLite.Net;

namespace JustRipe.Data
{

    public class SQLiteDatabase : IDisposable
    {
        #region fields
        private const string _DBFilePath = @".\Data\";
        private const string _DBFileName = "JustRipe.db";
        private SQLiteConnection _Connection = null;
        #endregion



        public static SQLiteConnection Open()
        {
            return new SQLiteConnection(new SQLite.Net.Platform.Win32.SQLitePlatformWin32(), DBFileNamePath);
        }

        public static string DBFileNamePath
        {
            get
            {
                return System.IO.Path.Combine(_DBFilePath, _DBFileName);
            }
        }

        public SQLiteConnection Connection
        {
            get
            {
                return _Connection;
            }
        }


        public void CloseConnection()
        {
            _Connection.Close();
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}

