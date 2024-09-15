using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TheAgoraAPI.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string? CommentType { get; set; }

    public string? Content { get; set; }

    public DateTime? DateAndTimeOfCreation { get; set; }

    [JsonIgnore]
    public virtual AnnouncementComment? AnnouncementComment { get; set; }

    [JsonIgnore]
    public virtual ForumComment? ForumComment { get; set; }
}
