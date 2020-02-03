using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FooWebApp.Store;
using Microsoft.AspNetCore.Mvc;

namespace FooWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentStore _studentStore;

        public StudentsController(IStudentStore studentStore)
        {
            _studentStore = studentStore;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (!_studentStore.TryGet(id, out var student))
            {
                return NotFound($"The student with id {id} was not found");
            }
            return Ok(student);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (!_studentStore.TryAdd(student.Id, student))
            {
                return Conflict($"Student {student.Id} already exists");
            }
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!_studentStore.TryDelete(id))
            {
                return NotFound($"The student with id {id} was not found");
            }
            return Ok();
        }
    }

    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set;}
        public int GradePercentage { get; set; }
    }
}
