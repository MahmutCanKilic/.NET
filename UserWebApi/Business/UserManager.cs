using Data.Entity;
using DataAccess.Repository;

namespace Business
{
    public class UserManager
    {
        UserRepository repository = new ();

        public User GetUserById(int id)
        {
           return repository.GetUserById(id);
        }
    }


}