namespace TheAgoraAPI.Interfaces
{
    public interface IMarketListingRepository
    {
        public Task<List<MarketListing>> GetMarketListings();
    }
}
