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
    public class HomesRepository : IHomesRepository
    {

        private readonly IOptionsMonitor<HomesMySqlRepositoryOption> _options;

        public HomesRepository(IOptionsMonitor<HomesMySqlRepositoryOption> options)
        {
            _options = options;            
        }        

        public async Task<HomeEntity> CreateHomeAsync(HomeEntity newHome)
        {
            if(newHome.Id == Guid.Empty.ToString())
            {
                newHome.Id = Guid.NewGuid().ToString();
            }
            var dnow = DateTime.UtcNow;
            newHome.CreatedOn = dnow;
            newHome.ModifiedOn = dnow;

            const string sqlQuery = @"INSERT INTO homes (
                    id,
                    name,
                    block,
                    number,
                    hometype,
                    lives,
                    createdon,
                    modifiedon                   
                )
                VALUES (
                    @id,
                    @name,                   
                    @block,
                    @number,
                    @hometype,
                    @lives,
                    @createdon,
                    @modifiedon);";

            using (var db = new MySqlConnection(_options.CurrentValue.HomesDbConnectionString))
            {                
                try
                {
                    await db.ExecuteAsync(sqlQuery, newHome, commandType: CommandType.Text);
                    return newHome;
                }
                    catch(Exception ex)
                {
                    throw new System.Exception(ex.Message);
                }
            }
        }

        public async Task<HomeEntity> GetHomeAsync(Guid id)
        {
            using (var db = new MySqlConnection(_options.CurrentValue.HomesDbConnectionString))
            {
                const string sqlQuery = @"SELECT 
                    id,
                    name,      
                    block,
                    number,
                    hometype,
                    lives,
                    createdon,
                    modifiedon
                FROM homes
                WHERE id=@id;";
                return await db.QueryFirstAsync<HomeEntity>(sqlQuery, new { id = id.ToString() }, commandType: CommandType.Text);
            }
        }

        public async Task<bool> UpdateHomeAsync(HomeEntity home)
        {
            home.ModifiedOn = DateTime.UtcNow;

            const string sqlQuery = @"UPDATE homes SET                
                name = @name,
                block = @block,
                number = @number,
                hometype = @hometype,
                lives = @lives,
                createdon = @createdon,
                modifiedon = @modifiedon
            WHERE id = @id;";

            using (var db = new MySqlConnection(_options.CurrentValue.HomesDbConnectionString))
            {
                await db.ExecuteAsync(sqlQuery, home, commandType: CommandType.Text);
                return true;
            }
        }

        public async Task<bool> DeleteHomeAsync(Guid id)
        {
            const string sqlQuery = @"DELETE FROM homes WHERE id = @id;";
            using (var db = new MySqlConnection(_options.CurrentValue.HomesDbConnectionString))
            {  
                await db.ExecuteAsync(sqlQuery, new { id = id.ToString() }, commandType: CommandType.Text);
                return true;
            }            
        }

        public async Task<IEnumerable<HomeEntity>> GetHomesListAsync(int pageNumber, int pageSize)
        {
            using (var db = new MySqlConnection(_options.CurrentValue.HomesDbConnectionString))
            {
                var offset = pageNumber <= 1 ? 0 : (pageNumber-1) * pageSize;
                const string sqlQuery = @"SELECT 
                    id,
                    name,
                    block,
                    number,
                    hometype,
                    lives,
                    createdon,
                    modifiedon
                FROM homes
                LIMIT @pageSize OFFSET @offset;";
                try
                {
                    return await db.QueryAsync<HomeEntity>(sqlQuery, new { pageSize, offset }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return await db.QueryAsync<HomeEntity>(sqlQuery, new { pageSize, offset }, commandType: CommandType.Text);
                }
            }
        }
    }
}
