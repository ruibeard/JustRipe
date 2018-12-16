using SQLite.Net;
using System;

namespace JustRipe.Data
{
   public class SQLiteDatabase : IDisposable
   {
      private SQLiteConnection _Connection = null;
      public bool IsOpen { get; private set; }
      public static string MessageError { get; private set; }
      public static SQLiteConnection Open()
      {
         try
         {
            return new SQLiteConnection(new SQLite.Net.Platform.Win32.SQLitePlatformWin32(), DBFileNamePath);
         }
         catch (Exception ex)
         {
            MessageError = ex.Message;
         }
         return default(SQLiteConnection);
      }

      public static string DBFileNamePath
      {

         get { return JustRipe.Properties.Settings.Default.SqliteDbPath; }

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

