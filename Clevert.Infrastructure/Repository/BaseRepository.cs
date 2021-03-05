using Clevert.Infrastructure.Data.Interface;
using Cleverti_API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverti_API.Infrastructure.Repository
{
    public class BaseRepository
    {
        protected readonly ITodoContext _context;

        public BaseRepository(ITodoContext context)
        {
            _context = context;
        }
    }
}
