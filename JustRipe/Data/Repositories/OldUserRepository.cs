using Dapper;
using JustRipe.Models;
using System.Linq;

namespace JustRipe.Data
{
    public class UserRepository : SQLiteDb, IUserRepository
    {
        public static User CheckUserCredentials(string _username, string _password)
        {
            using (var cnn = DbConnection())
            {
                cnn.Open();
                User u = cnn.Query<User>(
                "SELECT * FROM Users WHERE Username = @_username and Password = @_password", new { _username, _password }).FirstOrDefault();
                return u;
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
                user.Id = cnn.Query<int>(
                    @"INSERT INTO Users
                    ( FirstName, LastName, DateOfBirth ) VALUES 
                    ( @FirstName, @LastName, @DateOfBirth );
                    select last_insert_rowid()", user).First();
            }
        }

    }
}
