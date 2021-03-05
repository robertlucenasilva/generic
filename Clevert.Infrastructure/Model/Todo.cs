using Clevert.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clevert.Infrastructure.Model
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Category { get; set; }

        public TodoVO GetVO()
        {
            return new TodoVO()
            {
                Id = this.Id,
                Category = this.Category,
                CreatedDate = this.CreatedDate,
                EndDate = this.EndDate,
                StartDate = this.StartDate,
                TaskName = this.TaskName
            };
        }

        public Todo LoadModel(TodoVO vo)
        {
            return new Todo()
            {
                Id = vo.Id,
                Category = vo.Category,
                CreatedDate = vo.CreatedDate,
                EndDate = vo.EndDate,
                StartDate = vo.StartDate,
                TaskName = vo.TaskName
            };
        }
    }
}
