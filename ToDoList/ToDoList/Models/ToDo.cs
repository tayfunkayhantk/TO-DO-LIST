using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ToDo
    {
        [Key]
            public int id { get; set; }
            public  string title { get; set; }
            public string todo { get; set; }
            public DateTime time { get; set; }
            public bool check { get; set; }

    }

}
