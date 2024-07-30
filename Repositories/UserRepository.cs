
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
            //Include(x=>x.UserId).
            return users;
        }
    }
}
