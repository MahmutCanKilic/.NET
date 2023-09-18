using Data.Entity;
using DataAccess;
using DataAccess.Repos;

namespace Business.Managers
{
    public class UserManager
    {
        private readonly UserRepository _userRepository;
        public UserManager(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void SignIn(User user)
        {
            user.Password = user.Password.GetMd5();
            _userRepository.Add(user);
        }

        public bool LogIn(User user)
        {
            user.Password = user.Password.GetMd5();
            return _userRepository.Exist(user);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}