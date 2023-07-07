namespace Server.Models
{
    public class Profile
    {
        public int Id { get; set; }
        
        public string Introduction { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
