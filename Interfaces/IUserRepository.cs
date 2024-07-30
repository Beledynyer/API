

namespace TheAgoraAPI.Interfaces
{
    public interface IUserRepository
    {
        public  Task<List<User>> GetUsers();
        public Task<User> GetUserById(int id);
    }
}
