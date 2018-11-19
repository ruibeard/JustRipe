using SQLite.Net;
using System;

namespace JustRipe.Data
{
    public class SQLiteDatabase : IDisposable
    {
        private const string _DBFilePath = @".\Data\";
        private const string _DBFileName = "JustRipe.db";

        private SQLiteConnection _Connection = null;


        /// </summary>
        public SQLiteDatabase()
        {

        }

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

        public void OpenConnection(bool overwriteFile = false)
        {
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

