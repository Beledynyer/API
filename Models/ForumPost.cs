using System;
using System.Collections.Generic;

namespace TheAgoraAPI.Models;

public partial class ForumPost
{
    public int PostId { get; set; }

    public int? UserId { get; set; }

    public string? Content { get; set; }

    public DateTime? DateAndTimeOfCreation { get; set; }

    public int? NumberOfLikes { get; set; }

    public bool? IsApproved { get; set; }

    public string? Image { get; set; }

    public string? Tags { get; set; }

    public virtual ICollection<ForumComment> ForumComments { get; set; } = new List<ForumComment>();

    public virtual User? User { get; set; }
}
