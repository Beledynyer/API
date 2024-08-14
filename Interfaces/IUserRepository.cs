

namespace TheAgoraAPI.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByEmailAndPassword(string email, string password);
        public Task<User> Register(User user);
    }
}
