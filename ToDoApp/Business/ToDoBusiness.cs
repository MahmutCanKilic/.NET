using Data;
using DataAccess;
using System.ComponentModel;

namespace Business
{
    
    public class ToDoBusiness
    {
        ToDoRepository repository = new ToDoRepository();
        
        public void Add(int id, string description)
        {
            repository.AddToDo(id, description);
            Console.WriteLine("eklendi");
        }
        public void Delete(int id)
        {
            repository.DeleteToDo(id);
        }
        public ToDo FindId(int id)
        {
           return repository.FindWithId(id);
        }
        public IEnumerable<ToDo> All()
        {
             return repository.AllToDo();
        }
        public ToDo FindDetailed(int id, string description)
        {
          return repository.FindToDo(id, description);
        }
        public void Update(int id,string description)
        {
            repository.UpdateToDo(id, description);
        }
        public void UpdateAll(List<ToDo> toDoList)
        {
            repository.UpdateAllToDo(toDoList);
        }
    }
}