using TheAgoraAPI.Repositories;

namespace TheAgoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketListingController : ControllerBase
    {
        private readonly IMarketListingRepository marketListingRepository;

        public MarketListingController(IMarketListingRepository marketListingRepository)
        {
            this.marketListingRepository = marketListingRepository;
        }

        [HttpGet("GetMarketListings")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var marketLs = await marketListingRepository.GetMarketListings();
                return Ok(marketLs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
