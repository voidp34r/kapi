using Service.Kapi.BLL.Contracts;
using Service.Kapi.BLL.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service.Kapi.BLL
{
    public class TodosMockProxyService: ITodosMockProxyService
    {
        private HttpClient _client { get; }       

        public TodosMockProxyService(HttpClient client)
        {
            _client = client;          
        }        

        public async Task<IEnumerable<Todo>> GetTodos()
        {
            var response = await _client.GetAsync("");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = await response.Content.ReadAsAsync<IEnumerable<Todo>>();
            return result;
        }

        public async Task<Todo> GetTodoById(int id)
        {
            var response = await _client.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = await response.Content.ReadAsAsync<Todo>();
            return result;
        }
    }
}
