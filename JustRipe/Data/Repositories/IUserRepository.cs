using JustRipe.Models;

namespace JustRipe.Data
{
    public interface IUserRepository
    {
        User GetUser(long id);
        void SaveUser(User user);
    }
}