using Service.Kapi.DAL.MySql.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Kapi.DAL.MySql.Contract
{
    public interface IUsersRepository
    {
        Task<UserEntity> CreateUserAsync(UserEntity user);
        Task<UserEntity> GetUserAsync(Guid id);
        Task<UserEntity> GetUserAuth(string email, string password);
        Task<bool> UpdateUserAsync(UserEntity user);
        Task<bool> DeleteUserAsync(Guid id);

        Task<IEnumerable<UserEntity>> GetUsersListAsync(int pageNumber, int pageSize);
    }
}
