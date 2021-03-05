using Clevert.Domain;
using Clevert.Domain.Repository.Interface;
using Cleverti_API.Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverti_API.Domain
{
    public class TodoService : ITodoService
    {

        private readonly ITodoRepository _todoRepository;
            
        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _todoRepository.Delete(id);
        }

        public async Task<TodoVO> GetById(Guid id)
        {
            return await _todoRepository.GetById(id);
        }

        public async Task<List<TodoVO>> Get()
        {
            return await _todoRepository.Get();
        }

        public async Task<TodoVO> Insert(TodoVO obj)
        {
            return await _todoRepository.Insert(obj);
        }

        public async Task<TodoVO> Update(TodoVO obj)
        {
            return await _todoRepository.Update(obj);
        }
    }
}
