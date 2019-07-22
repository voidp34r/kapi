using Service.Kapi.DAL.MySql.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Kapi.DAL.MySql.Contract
{
    public interface IHomesRepository
    {
        Task<HomeEntity> CreateHomeAsync(HomeEntity home);
        Task<HomeEntity> GetHomeAsync(Guid id);
        Task<bool> UpdateHomeAsync(HomeEntity home);
        Task<bool> DeleteHomeAsync(Guid id);

        Task<IEnumerable<HomeEntity>> GetHomesListAsync(int pageNumber, int pageSize);
    }
}
