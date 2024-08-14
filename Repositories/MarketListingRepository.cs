
namespace TheAgoraAPI.Repositories
{
    public class MarketListingRepository : IMarketListingRepository
    {
        private readonly TheAgoraDbContext dbContext;

        public MarketListingRepository(TheAgoraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<MarketListing>> GetMarketListings()
        {
            var marketListings = await dbContext.MarketListings.ToListAsync();
            return marketListings;
        }
    }
}
