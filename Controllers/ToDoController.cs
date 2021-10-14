using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private List<ToDo> toDoList { get; set; }        
        public ToDoController()
        {
            this.toDoList = new List<ToDo>()
           {
            new ToDo(){ Task = "getData", Cost= 200  , Summary ="Get the Data"},
            new ToDo(){Task = "getSystem", Cost= 400  , Summary ="Get the System" }
            };
        }

        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
        
           return this.toDoList;
        }

        [HttpPost]
        public IEnumerable<ToDo> Add(ToDo todo)
        {
            this.toDoList.Add(todo);
            return this.toDoList;
        }
    }
}
