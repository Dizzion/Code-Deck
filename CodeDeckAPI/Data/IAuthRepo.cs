using System.Threading.Tasks;
using CodeDeckAPI.Models;

namespace CodeDeckAPI.Data
{
    public interface IAuthRepo
    {
         Task<ServiceResponse<int>> Register(User user, string password);
         Task<ServiceResponse<string>> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}