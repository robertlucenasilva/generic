using Clevert.Domain;
using Cleverti_API;
using Cleverti_API.Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleerti_API_Test.Fake
{

    public class TodoServiceFake : ITodoService
    {
        private readonly List<TodoVO> _todo;
        public TodoServiceFake()
        {
            _todo = new List<TodoVO>()
            {
                new TodoVO() { Id = Guid.Parse("6da0e0a9-143e-466e-b594-4ddb3d0fb5d3"), Category = "Personal Appointment",  CreatedDate=DateTime.Now,  EndDate = DateTime.Now.AddDays(2).AddHours(2), StartDate = DateTime.Now.AddDays(2).AddHours(1), TaskName = "Dentist" },
                new TodoVO() { Id = Guid.Parse("9f7f1932-5e24-4169-a8ac-dbe110fe7862"), Category = "Personal Appointment",  CreatedDate=DateTime.Now,  EndDate = DateTime.Now.AddDays(5).AddHours(8), StartDate = DateTime.Now.AddDays(5).AddHours(5), TaskName = "Soccer Game" },
                new TodoVO() { Id = Guid.Parse("fd2b469b-20c5-48e8-bebf-3feef2390cbc"), Category = "Work Appointment",  CreatedDate=DateTime.Now,  EndDate = DateTime.Now.AddDays(9).AddHours(16), StartDate = DateTime.Now.AddDays(9).AddHours(17), TaskName = "Post station" },
                new TodoVO() { Id = Guid.Parse("21b995f1-9e2d-41f2-b20b-9b87c231b04d"), Category = "Personal Appointment",  CreatedDate=DateTime.Now,  EndDate = DateTime.Now.AddDays(2).AddHours(2), StartDate = DateTime.Now.AddDays(2).AddHours(1), TaskName = "Doctor" },
                new TodoVO() { Id = Guid.Parse("5231bf6f-d7e7-4234-8fb4-70ba58cc7293"), Category = "Personal Appointment",  CreatedDate=DateTime.Now,  EndDate = DateTime.Now.AddDays(30), StartDate = DateTime.Now.AddDays(10), TaskName = "Vacation" },

            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = _todo.FirstOrDefault(a => a.Id == id);
            _todo.Remove(existing);
            return true;
        }

        public async Task<TodoVO> GetById(Guid id)
        {
            return _todo.Where(a => a.Id == id).FirstOrDefault();
        }

        public async Task<List<TodoVO>> Get()
        {
            return _todo;
        }

        public async Task<TodoVO> Insert(TodoVO obj)
        {
            obj.Id = Guid.NewGuid();
            _todo.Add(obj);
            return obj;
        }

        public async Task<TodoVO> Update(TodoVO obj)
        {
            var old = _todo.Where(p => p.Id == obj.Id).FirstOrDefault();
            old.Category = obj.Category;
            old.StartDate = obj.StartDate;
            old.EndDate = obj.EndDate;
            old.TaskName = obj.TaskName;
            return obj;
        }
    }
}
