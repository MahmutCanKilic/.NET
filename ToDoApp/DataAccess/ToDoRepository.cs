using Data;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class ToDoRepository
    {
        private List<ToDo> toDoList;
        public ToDoRepository()
        {
            toDoList = new List<ToDo>();
        }
        private void AddToDo(int id, string description)
        {
            ToDo toDo = new ToDo();

            toDo.Id = id;
            toDo.Description = description;
            DateTime createdTime = DateTime.Now;
            toDo.CreatedTime = createdTime;

            toDoList.Add(toDo);
        }
        private void DeleteToDo(int id, string description, DateTime deletedTime)
        {
            ToDo toDo = new ToDo();
            toDo.Id = id;
            toDo.Description = description;
            deletedTime = DateTime.Now;
            toDo.DeletedTime = deletedTime;
            toDoList.Remove(toDo);
        }
        private ToDo FindWithId(int id)
        {
            foreach (var toDo in toDoList)
            {
                if (toDo.Id == id)
                {
                    return toDo;
                }
            }
            return null;
        }
        private ToDo AllToDo(int id)
        {
            foreach (var toDo in toDoList)
            {
                return toDo;
            }
            return null;
        }
        private ToDo FindToDo(int id, string description, DateTime createdTime)
        {
            foreach (var toDo in toDoList)
            {
                if (toDo.Id == id || toDo.Description == description || toDo.CreatedTime == createdTime)
                {
                    return toDo;
                }
            }
            return null;
        }
        private void UpdateToDo(int id, string description, DateTime createdTime)
        {
            foreach (var toDo in toDoList)
            {
                if (toDo.Id == id || toDo.CreatedTime == createdTime)
                {
                    toDoList.Remove(toDo);
                    AddToDo(id, description);
                }
            }
        }
    }
}