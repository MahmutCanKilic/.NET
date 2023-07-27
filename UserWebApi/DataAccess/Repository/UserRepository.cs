using Data.Entity;

namespace DataAccess.Repository
{
    public class UserRepository
    {
        List<User> users = new() { new User { Id = 1, Age = 12, Name = "Can", Salary = 9999, Surname="Kilic" },
        new User { Id = 2, Age = 15, Name = "Harun", Salary = 9329, Surname="Ust" },
            new User { Id = 3, Age = 23, Name = "Hasan", Salary = 1092, Surname="Akpolad" }
        };

        public User GetUserById(int id)
        {
            return users.Single(x => x.Id == id);
            
        }

    }
}