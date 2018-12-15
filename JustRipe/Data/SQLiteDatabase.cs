using SQLite.Net;
using System;
using System.Configuration;
using System.Windows;

namespace JustRipe.Data
{
   public class SQLiteDatabase : IDisposable
   {
    
      //private const string _DBFilePath = @"..\..\Data\";
      //private const string _DBFileName = "JustRipe.db";

      private SQLiteConnection _Connection = null;

      public static SQLiteConnection Open()
      {

         return new SQLiteConnection(new SQLite.Net.Platform.Win32.SQLitePlatformWin32(), DBFileNamePath);
      }

      public static string DBFileNamePath
      {

         /// Get the settings from the file JustRipe.exe.config
         get { return JustRipe.Properties.Settings.Default.SqliteDbPath; }


         //get { return System.IO.Path.Combine(_DBFilePath, _DBFileName); }
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

