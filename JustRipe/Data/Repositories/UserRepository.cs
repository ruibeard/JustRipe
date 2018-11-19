using Dapper;
using JustRipe.Models;
using System.Linq;

namespace JustRipe.Data
{
    public class UserRepository : SQLiteDb, IUserRepository
    {


        public static int CheckUserCredentials(User user)
        {
            using (var cnn = DbConnection())
            {
                var rows = cnn.Query(
                "SELECT COUNT(1) as 'Count' FROM Users WHERE Username = @Username and Password = @Password", user);
                return (int)rows.First().Count;
            }
        }

        public User GetUser(long id)
        {
            using (var cnn = DbConnection())
            {
                cnn.Open();
                User result = cnn.Query<User>(
                    @"SELECT Id, FirstName, LastName, DateOfBirth
                    FROM User
                    WHERE Id = @id", new { id }).FirstOrDefault();
                return result;
            }
        }

        public void SaveUser(User user)
        {
            using (var cnn = DbConnection())
            {
                cnn.Open();
                user.Id = cnn.Query<long>(
                    @"INSERT INTO Users
                    ( FirstName, LastName, DateOfBirth ) VALUES 
                    ( @FirstName, @LastName, @DateOfBirth );
                    select last_insert_rowid()", user).First();
            }
        }

        private static void CreateDatabase()
        {
            using (var cnn = DbConnection())
            {
                cnn.Open();
                cnn.Execute(
                    @"create table Users
                      (
                         ID          integer primary key AUTOINCREMENT,
                         FirstName   varchar(100) not null,
                         LastName    varchar(100) not null,
                         DateOfBirth datetime not null
                      )");
            }
        }
    }
}
