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
using Clevert.Infrastructure.Data.Interface;
using Microsoft.Extensions.Logging;

namespace Cleverti_API.Infrastructure.Repository
{
    public class TodoRepository : BaseRepository, ITodoRepository
    {
        private readonly ILogger _logger;
        public TodoRepository(ITodoContext context, ILogger<TodoRepository> logger) : base(context)
        {
            _logger = logger;
        }
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
            catch(Exception ex)
            {
                _logger.LogInformation(string.Format("Error trying delete id = {0}.  Error message = {1}",id, ex.Message));
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
                _logger.LogInformation(string.Format("Error trying get by id = {0}.  Error message = {1}", id, ex.Message));
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
                _logger.LogInformation(string.Format("Error trying get all records .  Error message = {0}", ex.Message));
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
            catch(Exception ex)
            {
                _logger.LogInformation(string.Format("Error trying insert new record with id = {0}.  Error message = {1}", obj.Id, ex.Message));
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
                _logger.LogInformation(string.Format("Error trying update object with id = {0}.  Error message = {1}", obj.Id, ex.Message));
                return obj;
            }
        }
    }
}
