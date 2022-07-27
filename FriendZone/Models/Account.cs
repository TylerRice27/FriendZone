namespace FriendZone.Models
{
    public class Profile
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Picture { get; set; }

        public string Interests { get; set; }
    }

    public class Account : Profile
    {

        public string Email { get; set; }
    }

    public class FollowerViewModel : Profile
    {
        public int FollowId { get; set; }
    }


}