namespace TheAgoraAPI.Models
{
    public class UserRegistrationDto
    {
        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsStaffMember { get; set; }
        public string PhoneNumber { get; set; }
    }
}
