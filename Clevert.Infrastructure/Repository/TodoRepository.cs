using Clevert.Infrastructure.Model;
using Cleverti_API.Infrastructure.Data;
using Clevert.Domain.Repository.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clevert.Domain;

namespace Cleverti_API.Infrastructure.Repository
{
    public class TodoRepository : BaseRepository, ITodoRepository
    {
        public TodoRepository(TodoContext context) : base(context)
        { }
        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var item = _context.Todo.Where(p => p.Id == id).FirstOrDefault();
                if (item != null)
                {
                    _context.Todo.Remove(item);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<TodoVO> GetById(Guid id)
        {
            try
            {
                return _context.Todo.Where(p => p.Id == id).FirstOrDefault().GetVO();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TodoVO>> Get()
        {
            try
            {
                var result = new List<TodoVO>();
                foreach (var item in _context.Todo)
                {
                    result.Add(item.GetVO());
                }                
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TodoVO> Insert(TodoVO obj)
        {
            try
            {
                _context.Todo.Add(new Todo().LoadModel(obj));
                await _context.SaveChangesAsync();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public async Task<TodoVO> Update(TodoVO obj)
        {
            try
            {
                var old = _context.Todo.Where(p => p.Id == obj.Id).FirstOrDefault();
                if (old != null)
                {
                    old.Category = obj.Category;
                    old.StartDate = obj.StartDate;
                    old.EndDate = obj.EndDate;
                    old.TaskName = obj.TaskName;
                    await _context.SaveChangesAsync();
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return obj;
            }
        }
    }
}
