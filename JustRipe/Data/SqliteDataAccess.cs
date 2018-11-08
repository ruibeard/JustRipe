using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using JustRipe.Models;

//This need to be removed just used dureing development
// it violates mvvm pattern
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;

namespace JustRipe.Data
{
    public class SqliteDataAccess
    {
        public static List<User> LoadUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<User>("select * from users", new DynamicParameters());
                return output.ToList();
            }
        }



        //This also violates MVVM pattern data layer sholdn't be able to know about windows controls
        // The password at this moment is as string on memory. its a potenlialy break point to the application
        // this shoulb be implemented using SecureString
        public static void CheckUserCredentials(string username, string password)
        {

            string query = string.Format("Select * form users where username = {0} and password = {1}", username, password);

            MessageBox.Show(query);


            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                var output = cnn.Query("select * from users where username = @Username and password = @Password");
                Debug.Assert(false, output.ToString());
                

            }

        }

        //public static void SaveUser(User user)
        //{
        //    using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        //    {
        //        cnn.Execute("insert into users (Username,Password) VALUES (@Username,@Password ) ", user);
        //    }

        //}

        private static string LoadConnectionString(string id = "SQLiteConnectionString")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}