using AutoMapper;
using Service.Kapi.BLL.Contracts;
using Service.Kapi.BLL.Models;
using Service.Kapi.DAL.MySql.Contract;
using Service.Kapi.DAL.MySql.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Kapi.BLL
{
    public class HomesService: IHomesService
    {
        private readonly IMapper _mapper;

        public IHomesRepository _homesRepo { get; }

        public HomesService(IMapper mapper, IHomesRepository homesRepo)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _homesRepo = homesRepo ?? throw new ArgumentNullException(nameof(homesRepo));
        }

        public async Task<Home> CreateHomeAsync(Home home)
        {
            try
            {
                var newHome = await _homesRepo.CreateHomeAsync(_mapper.Map<HomeEntity>(home));
                return _mapper.Map<Home>(newHome);
            }
                catch ( Exception ex)
            {
                Console.WriteLine(ex);
                return _mapper.Map<Home>(ex);
            }
        }

        public async Task<bool> DeleteHomeAsync(Guid id)
        {
            var result = await _homesRepo.DeleteHomeAsync(id);
            return result;
        }

        public async Task<Home> GetHomeAsync(Guid id)
        {
            var home = await _homesRepo.GetHomeAsync(id);
            return _mapper.Map<Home>(home);
        }

        public async Task<IEnumerable<Home>> GetHomesListAsync(int pageNumber, int pageSize)
        {
            var homes = await _homesRepo.GetHomesListAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<Home>>(homes);
        }

        public async Task<bool> UpdateHomeAsync(Home home)
        {
            var result = await _homesRepo.UpdateHomeAsync(_mapper.Map<HomeEntity>(home));
            return result;
        }
    }
}
