using System.Threading.Tasks;

namespace Service.Kapi.BLL.Contracts
{
    public interface IJwtTokenService
    {
        Task<string> GenerateToken();
        Task<bool> ValidateToken(string token);
    }
}
