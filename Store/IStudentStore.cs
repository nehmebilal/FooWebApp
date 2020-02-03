using FooWebApp.Controllers;

namespace FooWebApp.Store
{
    public interface IStudentStore
    {
        bool TryAdd(string id, Student student);
        bool TryGet(string id, out Student student);
        bool TryDelete(string id);
    }
}
