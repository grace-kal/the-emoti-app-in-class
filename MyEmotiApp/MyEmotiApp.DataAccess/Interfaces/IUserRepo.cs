using MyEmotiApp.Models;

namespace MyEmotiApp.DataAccess.Interfaces
{
    public interface IUserRepo
    {
        Task<bool> Register(string username, string password);
        Task<User> Login(string username, string password);
    }
}
