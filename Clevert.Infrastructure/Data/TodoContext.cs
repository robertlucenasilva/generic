using Clevert.Infrastructure.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cleverti_API.Infrastructure.Data
{    
    public class TodoContext
    {
        SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        public List<Todo> Todo { get; set; }
        public TodoContext()
        {            
            var jsonString = System.IO.File.ReadAllText(@"DB.json");            
            this.Todo = JsonConvert.DeserializeObject<List<Todo>>(jsonString);
            if(this.Todo == null)
            {
                this.Todo = new List<Todo>();
            }
        }

        public void SaveChanges()
        {            
            System.IO.File.WriteAllText("DB.json", JsonConvert.SerializeObject(this.Todo));            
        }
        public async Task SaveChangesAsync()
        {
            await _semaphore.WaitAsync();
            await System.IO.File.WriteAllTextAsync("DB.json", JsonConvert.SerializeObject(this.Todo));
            _semaphore.Release();
        }
    }
}
