using FooWebApp.Controllers;
using System.Collections.Generic;

namespace FooWebApp.Store
{
    public class InMemoryStudentStore : IStudentStore
    {
        private Dictionary<string, Student> _students = new Dictionary<string, Student>();

        public bool TryGet(string id, out Student student)
        {
            return _students.TryGetValue(id, out student);
        }

        public bool TryAdd(string id, Student student)
        {
            return _students.TryAdd(id, student);
        }

        public bool TryDelete(string id)
        {
            return _students.Remove(id);
        }
    }
}
