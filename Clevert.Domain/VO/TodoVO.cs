using System;

namespace Clevert.Domain
{
    public class TodoVO
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Category { get; set; }        
    }
}
