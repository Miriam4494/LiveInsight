namespace LiveFeedback.API.PostModels
{
    public class UserPostModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Points { get; set; }
        public int RoleId { get; set; }
    }
}
