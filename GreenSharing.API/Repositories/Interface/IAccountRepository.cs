using GreenSharing.API.Dtos;
using GreenSharing.API.Repositories.DataAccessLayer.Models;
using System.Threading.Tasks;

namespace GreenSharing.API.Repositories.Interface
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> LoginAsync(LoginDTO loginDto);
    }
}
