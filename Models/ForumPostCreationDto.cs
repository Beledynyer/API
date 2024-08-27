namespace TheAgoraAPI.Models
{
    public class ForumPostCreationDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateAndTimeOfCreation { get; set; }
        public int NumberOfLikes { get; set; }
        public bool IsApproved {  get; set; }
        public byte[] Image {  get; set; }
        public string Tags { get; set; }
    }
}
