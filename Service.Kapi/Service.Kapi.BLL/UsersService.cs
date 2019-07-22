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
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;

        public IUsersRepository _usersRepo { get; }

        public UsersService(IMapper mapper, IUsersRepository usersRepo)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usersRepo = usersRepo ?? throw new ArgumentNullException(nameof(usersRepo));
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var newUser = await _usersRepo.CreateUserAsync(_mapper.Map<UserEntity>(user));
            return _mapper.Map<User>(newUser);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var result = await _usersRepo.DeleteUserAsync(id);
            return result;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await _usersRepo.GetUserAsync(id);
            return _mapper.Map<User>(user);
        }

        public async Task<IEnumerable<User>> GetUsersListAsync(int pageNumber, int pageSize)
        {
            var users = await _usersRepo.GetUsersListAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<User>>(users);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var result = await _usersRepo.UpdateUserAsync(_mapper.Map<UserEntity>(user));
            return result;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _usersRepo.GetUserAuth(email, password);
            var foo = new { };
            if (string.IsNullOrEmpty(user.Email))
            {
                return _mapper.Map<User>(foo);
            }
            return  _mapper.Map<User>(user);
        }
    }
}
