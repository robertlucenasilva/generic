using Cleverti_API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverti_API.Infrastructure.Repository
{
    public class BaseRepository
    {
        protected readonly TodoContext _context;

        public BaseRepository(TodoContext context)
        {
            _context = context;
        }
    }
}
