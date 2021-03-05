using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clevert.Domain.Repository.Interface
{
    public interface ITodoRepository
    {
        Task<TodoVO> GetById(Guid id);
        Task<List<TodoVO>> Get();
        Task<TodoVO> Insert(TodoVO obj);
        Task<TodoVO> Update(TodoVO obj);
        Task<bool> Delete(Guid id);
    }
}
