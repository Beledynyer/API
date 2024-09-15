using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TheAgoraAPI.Models;

public partial class ForumComment
{
    public int CommentId { get; set; }

    public int? UserId { get; set; }

    public int? PostId { get; set; }

    [JsonIgnore]
    public virtual Comment Comment { get; set; } = null!;

    [JsonIgnore]
    public virtual ForumPost? Post { get; set; }

    [JsonIgnore]
    public virtual User? User { get; set; }
}
