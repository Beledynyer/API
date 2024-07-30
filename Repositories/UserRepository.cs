
namespace TheAgoraAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly TheAgoraDbContext dbContext;

        public UserRepository(TheAgoraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<User> GetUserById(int id)
        {
           var users = dbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
            return Task.FromResult(users);
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await dbContext.Users.ToListAsync();
            return users;
        }

        public Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            var user = dbContext.Users
                                .Where(x => x.Email.Equals(email) && x.Password.Equals(password))
                                .FirstOrDefault();
            return Task.FromResult(user);
        }

        public async Task<int> Register(User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return user.UserId;
        }
    }
}
