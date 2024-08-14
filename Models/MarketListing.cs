using System;
using System.Collections.Generic;

namespace TheAgoraAPI.Models
{
    public partial class MarketListing
    {
        public int ListingId { get; set; }

        public int? UserId { get; set; }

        public string? Title { get; set; }

        public string? Category { get; set; }

        public string? Descriptions { get; set; }

        public byte[]? Images { get; set; } // Changed from string to byte[]

        public decimal? Price { get; set; }

        public virtual User? User { get; set; }
    }
}
