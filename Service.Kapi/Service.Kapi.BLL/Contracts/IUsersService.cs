using Service.Kapi.BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Kapi.BLL.Contracts
{
    public interface IUsersService
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> CreateUserAsync(User user);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUserAsync(Guid id);

        /// <summary>
        /// Update user parameters
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> UpdateUserAsync(User user);

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUserAsync(Guid id);

        /// <summary>
        /// Get users list 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<User>> GetUsersListAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> Authenticate(string  email, string password);

    }
}
