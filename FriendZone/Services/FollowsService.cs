using FriendZone.Models;
using FriendZone.Repositories;

namespace FriendZone.Services
{
    public class FollowsService
    {


        private readonly FollowsRepository _repo;

        public FollowsService(FollowsRepository repo)
        {
            _repo = repo;
        }

        internal Follow Create(Follow followData)
        {
            return _repo.Create(followData);
        }
    }
}