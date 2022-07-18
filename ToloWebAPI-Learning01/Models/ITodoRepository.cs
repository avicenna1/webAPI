using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToloWebAPI_Learning01.Models
{
    public interface ITodoRepository
    {
        void Add(ToDoItem item);
        void Update(ToDoItem item);
        ToDoItem Find(string key);
        ToDoItem Remove(string key);
        IEnumerable<ToDoItem> GetAll();
    }
}
