using Clevert.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverti_API.Service.Domain
{
    public interface ITodoService
    {
        Task<TodoVO> GetById(Guid id);
        Task<List<TodoVO>> Get();
        Task<TodoVO> Insert(TodoVO obj);
        Task<TodoVO> Update(TodoVO obj);
        Task<bool> Delete(Guid id);
    }
}
