using sanpaolo.Models;
using sanpaolo.Utility;
using System.Threading.Tasks;

namespace sanpaolo.Data
{
    public interface IAuthRepository
    {
        Task<Response<int>> Register(Utente utente, string password);
        Task<Response<string>> Login(string email, string password);
        Task<bool> UtenteExists(string email, string numeroCartaIdentita);
    }
}
