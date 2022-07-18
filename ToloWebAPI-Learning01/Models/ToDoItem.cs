using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToloWebAPI_Learning01.Models
{
    public class ToDoItem
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
