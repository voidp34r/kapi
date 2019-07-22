using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Service.Kapi.DAL.MySql.Contract;
using Service.Kapi.DAL.MySql.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Service.Kapi.DAL.MySql
{
    public class UsersRepository : IUsersRepository
    {

        private readonly IOptionsMonitor<UsersMySqlRepositoryOption> _options;

        public UsersRepository(IOptionsMonitor<UsersMySqlRepositoryOption> options)
        {
            _options = options;            
        }        

        public async Task<UserEntity> CreateUserAsync(UserEntity newUser)
        {
            if(newUser.Id == Guid.Empty.ToString())
            {
                newUser.Id = Guid.NewGuid().ToString();
            }
            var dnow = DateTime.UtcNow;
            newUser.CreatedOn = dnow;
            newUser.ModifiedOn = dnow;

            const string sqlQuery = @"INSERT INTO users (
                    id,
                    name,                   
                    usertype,
                    email,
                    password,
                    cpf,
                    birth,
                    telephone,
                    createdon,
                    modifiedon,
                    deletedon,
                    deleted                   
                )
                VALUES (
                    @id,
                    @name,                   
                    @usertype,
                    @email,
                    @password,
                    @cpf,
                    @birth,
                    @telephone,
                    @createdon,
                    @modifiedon,
                    @deletedon,
                    @deleted);";

            using (var db = new MySqlConnection(_options.CurrentValue.UsersDbConnectionString))
            {                
                await db.ExecuteAsync(sqlQuery, newUser, commandType: CommandType.Text);
                return newUser;
            }
        }

        public async Task<UserEntity> GetUserAsync(Guid id)
        {
            using (var db = new MySqlConnection(_options.CurrentValue.UsersDbConnectionString))
            {
                const string sqlQuery = @"SELECT 
                    id,
                    name,                   
                    usertype,
                    email,
                    password,
                    cpf,
                    birth,
                    telephone,
                    createdon,
                    modifiedon,
                    deletedon,
                    deleted
                FROM users
                WHERE id=@id;";
                return await db.QueryFirstAsync<UserEntity>(sqlQuery, new { id = id.ToString() }, commandType: CommandType.Text);
            }
        }

        public async Task<bool> UpdateUserAsync(UserEntity user)
        {
            user.ModifiedOn = DateTime.UtcNow;

            const string sqlQuery = @"UPDATE users SET                
                name = @name,                
                usertype = @usertype,
                email = @email,
                password = @password,
				cpf = @cpf,
                birth = @birth,
				telephone = @telephone,
				createdon = @createdon,
                modifiedon = @modifiedon,
                deletedon = @deletedon,
                deleted = @deleted
            WHERE id = @id;";

            using (var db = new MySqlConnection(_options.CurrentValue.UsersDbConnectionString))
            {
                await db.ExecuteAsync(sqlQuery, user, commandType: CommandType.Text);
                return true;
            }
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            const string sqlQuery = @"DELETE FROM users WHERE id = @id;";
            using (var db = new MySqlConnection(_options.CurrentValue.UsersDbConnectionString))
            {  
                await db.ExecuteAsync(sqlQuery, new { id = id.ToString() }, commandType: CommandType.Text);
                return true;
            }            
        }

        public async Task<IEnumerable<UserEntity>> GetUsersListAsync(int pageNumber, int pageSize)
        {
            using (var db = new MySqlConnection(_options.CurrentValue.UsersDbConnectionString))
            {
                var offset = pageNumber <= 1 ? 0 : (pageNumber-1) * pageSize;
                const string sqlQuery = @"SELECT 
                    id,
                    name,                   
                    usertype,
                    email,
                    password,
                    cpf,
                    birth,
                    telephone,
                    createdon,
                    modifiedon,
                    deletedon,
                    deleted
                FROM users
                LIMIT @pageSize OFFSET @offset;";
                var response = await db.QueryAsync<UserEntity>(sqlQuery, new { pageSize, offset }, commandType: CommandType.Text);

                return response;
            }
        }

        public async Task<UserEntity> GetUserAuth(string email, string password)
        {
            using (var db = new MySqlConnection(_options.CurrentValue.UsersDbConnectionString))
            {
                const string sqlQuery = @"SELECT 
                    id,
                    name,                   
                    usertype,
                    email,
                    password
                FROM users
                WHERE email=@email and password=@password;";

                var response = await db.QueryFirstAsync<UserEntity>(sqlQuery, new { email = email.ToString(), password = password.ToString() }, commandType: CommandType.Text);
                return response;
            }
        }
    }
}
