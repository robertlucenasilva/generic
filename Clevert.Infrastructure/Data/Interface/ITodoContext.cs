using Clevert.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clevert.Infrastructure.Data.Interface
{
    public interface ITodoContext
    {
        List<Todo> Todo { get; set; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
