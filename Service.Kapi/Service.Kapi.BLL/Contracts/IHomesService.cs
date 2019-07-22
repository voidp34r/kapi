using Service.Kapi.BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Kapi.BLL.Contracts
{
    public interface IHomesService
    {
        /// <summary>
        /// Create a new home
        /// </summary>
        /// <param name="home"></param>
        /// <returns></returns>
        Task<Home> CreateHomeAsync(Home home);

        /// <summary>
        /// Get home by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Home> GetHomeAsync(Guid id);

        /// <summary>
        /// Update home parameters
        /// </summary>
        /// <param name="home"></param>
        /// <returns></returns>
        Task<bool> UpdateHomeAsync(Home home);

        /// <summary>
        /// Delete home by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteHomeAsync(Guid id);

        /// <summary>
        /// Get homes list 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<Home>> GetHomesListAsync(int pageNumber, int pageSize);
    }
}
