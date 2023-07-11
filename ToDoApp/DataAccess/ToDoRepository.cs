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
        public void AddToDo(int id, string description)
        {

            ToDo toDo = new ToDo();
            toDo.Id = id;
            toDo.Description = description;
            toDo.CreatedTime = DateTime.Now;

            toDoList.Add(toDo);

        }
        public void DeleteToDo(int id)
        {
            //??
            ToDo toDo = FindWithId(id);
            toDoList.Remove(toDo);
            Console.WriteLine("Kayıt silindi");
        }
        public ToDo FindWithId(int id)
        {
            foreach (var toDo in toDoList)
            {
                if (toDo.Id == id)
                {
                    return toDo;
                }
                else
                {

                    Console.WriteLine("Kayıt bulunamadı");
                }
            }
            return null;
        }
        public IEnumerable<ToDo> AllToDo()
        {
            if (toDoList != null)
            {
                return toDoList;
            }
            else
            {

                return null;
            }
        }
        public ToDo FindToDo(int id, string description)
        {
            foreach (var toDo in toDoList)
            {
                if (toDo.Id == id || toDo.Description == description)
                {
                    return toDo;
                }
                else
                {
                    Console.WriteLine("Kayıt bulunamadı");
                }
            }
            return null;
        }
        public void UpdateToDo(int id, string description)
        {
            foreach (var toDo in toDoList)
            {
                if (FindWithId(id) != null)
                {

                    toDo.Description = description;
                    toDo.CreatedTime = DateTime.Now;
                    Console.WriteLine("güncellendi");
                    break;
                    return;
                }
                else
                {
                    AddToDo(id, description);
                    break;
                }
            }
        }

        public void UpdateAllToDo(List<ToDo> toDoListNew)
        {

            for (int i = 0; i < toDoListNew.Count; i++)
            {
                toDoList[i].Id = toDoListNew[i].Id;
                toDoList[i].Description = toDoListNew[i].Description;
                toDoListNew[i].CreatedTime = DateTime.Now;
            }
        }
    }
}