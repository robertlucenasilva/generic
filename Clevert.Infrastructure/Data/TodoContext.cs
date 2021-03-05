using Clevert.Infrastructure.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverti_API.Infrastructure.Data
{    
    public class TodoContext
    {
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
        public Task SaveChangesAsync()
        {
            return System.IO.File.WriteAllTextAsync("DB.json", JsonConvert.SerializeObject(this.Todo));
        }
    }
}
