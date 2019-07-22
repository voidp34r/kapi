using Service.Kapi.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Kapi.BLL.Contracts
{
    public interface ITodosMockProxyService
    {
        Task<IEnumerable<Todo>> GetTodos();
        Task<Todo> GetTodoById(int id);
    }
}
