using System;
using System.Collections.Generic;

namespace TheAgoraAPI.Models
{
    public partial class ForumPost
    {
        public int PostId { get; set; }

        public int? UserId { get; set; }

        public string? Title { get; set; } // Added Title attribute

        public string? Content { get; set; }

        public DateTime? DateAndTimeOfCreation { get; set; }

        public int? NumberOfLikes { get; set; }

        public bool? IsApproved { get; set; }

        public byte[]? Image { get; set; } // Changed from string to byte[]

        public string? Tags { get; set; }

        public virtual ICollection<ForumComment> ForumComments { get; set; } = new List<ForumComment>();

        public virtual User? User { get; set; }
    }
}
